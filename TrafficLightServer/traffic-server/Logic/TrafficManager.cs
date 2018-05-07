using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using traffic_networking;
using TrafficLightPanel;

namespace traffic_server.Logic
{
    class TrafficManager
    {
        private static List<Vehicle> vehicles;
        private static object vehicleLock = new object();

        private static List<TrafficLight> trafficLights;
        private static Pathfinder pathfinder;

        private static Thread lightManagerThread;
        private static Thread vehicleManagerThread;

        private static Tile[] startTiles;
        private static Tile[] endTiles;

        /// <summary>
        /// Makes sure threads aren't currently alive before starting managers
        /// </summary>
        public static void Init()
        {
            closeThreads();
            start();
        }

        private static void closeThreads()
        {
            if (lightManagerThread != null && lightManagerThread.IsAlive)
                lightManagerThread.Abort();

            if (vehicleManagerThread != null && vehicleManagerThread.IsAlive)
                vehicleManagerThread.Abort();
        }

        /// <summary>
        /// Starts the managers and gets everything needed for the TrafficManager
        /// </summary>
        private static void start()
        {
            vehicles = new List<Vehicle>();
            trafficLights = Form1.MainForm.trafficPanel.GetAllTiles().Where(tile => tile.GetType() == typeof(TrafficLight)).Cast<TrafficLight>().ToList();
            startTiles = Form1.MainForm.trafficPanel.GetAllTiles().Where(tile => tile.TypeTile == "StartRoad").ToArray();
            endTiles = Form1.MainForm.trafficPanel.GetAllTiles().Where(tile => tile.TypeTile == "EndRoad").ToArray();

            //Changes all lights to red
            foreach (TrafficLight light in trafficLights)
            {
                light.ChangeColour(Color.Red, Form1.MainForm.trafficPanel);
            }

            //Starts manager threads
            lightManagerThread = new Thread(trafficManagement);
            lightManagerThread.Start();

            vehicleManagerThread = new Thread(vehicleManagement);
            vehicleManagerThread.Start();
        }

        /// <summary>
        /// Handles all traffic light management
        /// </summary>
        private static void trafficManagement()
        {
            while (lightManagerThread != null && lightManagerThread.IsAlive)
            {
                foreach (TrafficLight light in trafficLights)
                {
                    //Skips exit lanes
                    if (light.GetSyncedLights().Length == 0)
                        continue;

                    //Do priority lights
                    TrafficLight[] priorityLights = trafficLights.Where((x) => x.GetCarsWaiting(Form1.MainForm.trafficPanel, vehicles.ToArray()).Length >= 10).ToArray();
                    foreach (TrafficLight priorityLight in priorityLights)
                        changeLights(priorityLight);

                    //Continue with normal loop
                    changeLights(light);
                }
            }
        }

        /// <summary>
        /// Changes all synced lights to green, flashes them all amber, then changes them back to red
        /// </summary>
        /// <param name="light"></param>
        private static void changeLights(TrafficLight light)
        {
            changeLight(Color.LightGreen, light);
            Thread.Sleep(5000);
            DateTime start = DateTime.Now;
            do
            {
                Thread.Sleep(500);
                changeLight(Color.Orange, light);
                Thread.Sleep(500);
                changeLight(Color.Red, light);

            } while (((DateTime.Now.Subtract(start)).Seconds < 5));

            changeLight(Color.Red, light);
        }

        /// <summary>
        /// Changes individual light and synced lights to specific colour and sends through proxy to clients
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="light"></param>
        private static void changeLight(Color colour, TrafficLight light)
        {
            light.ChangeColour(colour, Form1.MainForm.trafficPanel);
            sendLightChange(light);
            TrafficLight[] lightsSynced = trafficLights.Where((x) => light.GetSyncedLights().Contains(x.ID)).ToArray();
            foreach (TrafficLight l in lightsSynced)
            {
                l.ChangeColour(colour, Form1.MainForm.trafficPanel);
                sendLightChange(l);
            }
        }

        /// <summary>
        /// Sends packet through proxy to clients for light change
        /// </summary>
        /// <param name="light"></param>
        private static void sendLightChange(TrafficLight light)
        {
            Packet packet = new Packet(2);
            packet.WriteInt(light.ID);
            packet.WriteString(ColorTranslator.ToHtml(light.LightColour));
            Client.SendPacket(packet);
        }

        /// <summary>
        /// Handles all vehicle management
        /// </summary>
        private static void vehicleManagement()
        {
            while (vehicleManagerThread != null && vehicleManagerThread.IsAlive)
            {
                lock (vehicleLock)
                {
                    for (int i = 0; i < vehicles.Count; i++)
                    {
                        Vehicle vehicle = vehicles[i];

                        //Checks if vehicle should be deleted
                        switch (vehicle.Direction)
                        {
                            case 0:
                                if (vehicle.VehicleRect.Y + 15 == Form1.MainForm.trafficPanel.Height)
                                    RemoveVehicle(vehicle);
                                break;
                            case 1:
                                if (vehicle.VehicleRect.X - 15 == 0)
                                    RemoveVehicle(vehicle);
                                break;
                            case 2:
                                if (vehicle.VehicleRect.X + 15 == Form1.MainForm.trafficPanel.Width)
                                    RemoveVehicle(vehicle);
                                break;
                            case 3:
                                if (vehicle.VehicleRect.Y - 15 == 0)
                                    RemoveVehicle(vehicle);
                                break;
                        }

                        //Extremely messy hardcoded lane changes as pathfinder is currently broken :/
                        #region hardcoded_vehicle_movement
                        switch (vehicle.Direction)
                        {
                            case 0:
                                Point testDown = new Point(vehicle.VehicleRect.X, vehicle.VehicleRect.Y + 15);
                                Tile tileDown = Form1.MainForm.trafficPanel.GetTile(testDown);
                                if (tileDown == null)
                                    break;

                                if (tileDown != null && tileDown.GetType() == typeof(TrafficLight))
                                {
                                    TrafficLight light = (TrafficLight)tileDown;
                                    if (light.LightColour == Color.Red || light.LightColour == Color.Orange)
                                        continue;
                                }
                                Vehicle[] testCollisionDown = vehicles.Where((v) => v.VehicleRect.Contains(testDown)).ToArray();
                                if (testCollisionDown.Length > 0)
                                    continue;
                                vehicle.VehicleRect = new Rectangle(vehicle.VehicleRect.X, vehicle.VehicleRect.Y + 1, 10, 10);
                                break;

                            case 1:
                                Point testPointLeft = new Point(vehicle.VehicleRect.X - 15, vehicle.VehicleRect.Y);
                                Tile tileLeft = Form1.MainForm.trafficPanel.GetTile(testPointLeft);
                                if (tileLeft == null)
                                    break;

                                if (tileLeft != null && tileLeft.GetType() == typeof(TrafficLight))
                                {
                                    TrafficLight light = (TrafficLight)tileLeft;
                                    if (light.LightColour == Color.Red || light.LightColour == Color.Orange)
                                        continue;
                                }
                                Vehicle[] testCollisionLeft = vehicles.Where((v) => v.VehicleRect.Contains(testPointLeft)).ToArray();
                                if (testCollisionLeft.Length > 0)
                                    continue;
                                vehicle.VehicleRect = new Rectangle(vehicle.VehicleRect.X - 1, vehicle.VehicleRect.Y, 10, 10);
                                break;

                            case 2:
                                Point testPointRight = new Point(vehicle.VehicleRect.X + 15, vehicle.VehicleRect.Y);
                                Tile tileRight = Form1.MainForm.trafficPanel.GetTile(testPointRight);
                                if (tileRight == null)
                                    break;

                                if (tileRight != null && tileRight.GetType() == typeof(TrafficLight))
                                {
                                    TrafficLight light = (TrafficLight)tileRight;
                                    if (light.LightColour == Color.Red || light.LightColour == Color.Orange)
                                        continue;
                                }
                                Vehicle[] testCollisionRight = vehicles.Where((v) => v.VehicleRect.Contains(testPointRight)).ToArray();
                                if (testCollisionRight.Length > 0)
                                    continue;
                                vehicle.VehicleRect = new Rectangle(vehicle.VehicleRect.X + 1, vehicle.VehicleRect.Y, 10, 10);
                                break;

                            case 3:
                                Point testPointUp = new Point(vehicle.VehicleRect.X, vehicle.VehicleRect.Y - 15);
                                Tile tileUp = Form1.MainForm.trafficPanel.GetTile(testPointUp);
                                if (tileUp == null)
                                    break;

                                if (tileUp != null && tileUp.GetType() == typeof(TrafficLight))
                                {
                                    TrafficLight light = (TrafficLight)tileUp;
                                    if (light.LightColour == Color.Red || light.LightColour == Color.Orange)
                                        continue;
                                }
                                Vehicle[] testCollisionUp = vehicles.Where((v) => v.VehicleRect.Contains(testPointUp)).ToArray();
                                if (testCollisionUp.Length > 0)
                                    continue;
                                vehicle.VehicleRect = new Rectangle(vehicle.VehicleRect.X, vehicle.VehicleRect.Y - 1, 10, 10);
                                break;
                        }
                        #endregion
                    }

                    //Shows vehicles in panel
                    Form1.MainForm.trafficPanel.AddVehicles(vehicles.Cast<TrafficLightPanel.Vehicle>().ToList());

                    //Send cars through proxy to client
                    Packet packet = new Packet(1);
                    packet.WriteInt(vehicles.Count);
                    foreach (Vehicle v in vehicles)
                    {
                        packet.WriteInt(v.VehicleRect.X);
                        packet.WriteInt(v.VehicleRect.Y);
                        packet.WriteString(v.HexColour);
                    }
                    Client.SendPacket(packet);
                }
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Adds vehicles with a lock for thread saftey
        /// </summary>
        /// <param name="vehicle"></param>
        public static void AddVehicle(Vehicle vehicle)
        {
            try
            {
                lock (vehicleLock)
                    vehicles.Add(vehicle);
            }
            catch { }
        }

        /// <summary>
        /// Adds a vehicle with only the need for a hex colour
        /// </summary>
        /// <param name="hex"></param>
        public static void AddVehicle(string hex)
        {
            int direction = Program.GetNum(0, 4);
            Point startPoint = new Point(0, 0);

            switch (direction)
            {
                case 0:
                    startPoint = new Point(Form1.MainForm.trafficPanel.Width / 2 + 25, 1);
                    break;

                case 1:
                    startPoint = new Point(Form1.MainForm.trafficPanel.Width - 1, Form1.MainForm.trafficPanel.Height / 2 + 25);
                    break;

                case 2:
                    startPoint = new Point(1, Form1.MainForm.trafficPanel.Height / 2 - 25);
                    break;

                case 3:
                    startPoint = new Point(Form1.MainForm.trafficPanel.Width / 2 - 25, Form1.MainForm.trafficPanel.Height - 1);
                    break;
            }

            AddVehicle(new Vehicle(new Rectangle(startPoint.X, startPoint.Y, 10, 10), hex, direction));
        }
        
        /// <summary>
        /// Adds a vehicle when the server receives a new vehicle from proxy
        /// </summary>
        /// <param name="packet"></param>
        public static void AddVehicle(Packet packet)
        {
            string hexColour = packet.ReadString();

            //random pos
            Tile startTile = startTiles[Program.GetNum(0, startTiles.Length)];
            Tile endTile = endTiles[Program.GetNum(0, endTiles.Length)];
            AddVehicle(hexColour);
        }

        /// <summary>
        /// Thread safe removal of vehicles
        /// </summary>
        /// <param name="vehicle"></param>
        public static void RemoveVehicle(Vehicle vehicle)
        {
            lock (vehicleLock)
                vehicles.Remove(vehicle);
        }
    }
}
