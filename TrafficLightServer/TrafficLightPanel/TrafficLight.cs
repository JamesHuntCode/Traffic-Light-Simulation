using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightPanel
{
    public class TrafficLight : Tile
    {
        public int ID { get; private set; }
        public int TrafficSide { get; set; }
        public Color LightColour { get; private set; }

        private List<int> syncedLights;
        private bool vertical;

        public TrafficLight(int id, int side, Rectangle location) : base(location, "TrafficLight")
        {
            this.ID = id;
            this.LightColour = Color.Red;
            this.syncedLights = new List<int>();
            this.vertical = true;
            this.TrafficSide = side;
        }

        /// <summary>
        /// Changes this lights colour
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="panel"></param>
        public void ChangeColour(Color colour, TrafficPanel panel)
        {
            this.LightColour = colour;
            panel.Invalidate();
        }

        /// <summary>
        /// Gets cars waiting in the traffic lights wait direction (which side
        /// cars come from)
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="vehicles"></param>
        /// <returns></returns>
        public Vehicle[] GetCarsWaiting(TrafficPanel panel, Vehicle[] vehicles)
        {
            //Creates a 'hitbox' of sorts to check for cars inside
            Rectangle checkArea;
            switch (this.TrafficSide)
            {
                case 0:
                    checkArea = new Rectangle(this.RectLoc.X, 0, 40, this.RectLoc.Y);
                    break;

                case 1:
                    checkArea = new Rectangle(this.RectLoc.X, this.RectLoc.Y, panel.Width - this.RectLoc.X, 40);
                    break;

                case 2:
                    checkArea = new Rectangle(0, this.RectLoc.Y, this.RectLoc.X, 40);
                    break;

                case 3:
                    checkArea = new Rectangle(this.RectLoc.X, this.RectLoc.Y, 40, panel.Height);
                    break;

                default:
                    checkArea = new Rectangle(0, 0, panel.Width, panel.Height);
                    break;
            }

            return vehicles.Where((x) => checkArea.Contains(new Point(x.VehicleRect.X + 5, x.VehicleRect.Y + 5))).ToArray();
        }

        /// <summary>
        /// Rotates the trafficlight
        /// </summary>
        public void Rotate()
        {
            this.vertical = !this.vertical;
            if (this.vertical)
                base.RectLoc = new Rectangle(base.RectLoc.X, base.RectLoc.Y, 10, 40);
            else
                base.RectLoc = new Rectangle(base.RectLoc.X, base.RectLoc.Y, 40, 10);
        }

        /// <summary>
        /// Adds a light to sync to this light
        /// </summary>
        /// <param name="id"></param>
        public void AddSyncedLight(int id)
        {
            this.syncedLights.Add(id);
        }

        /// <summary>
        /// Removes a synced light
        /// </summary>
        /// <param name="id"></param>
        public void RemoveSyncedLight(int id)
        {
            this.syncedLights.Remove(id);
        }

        /// <summary>
        /// Returns all synced lights
        /// </summary>
        /// <returns></returns>
        public int[] GetSyncedLights()
        {
            return this.syncedLights.ToArray();
        }
    }
}
