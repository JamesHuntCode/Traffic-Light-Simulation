using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_networking;
using TrafficLightPanel;

namespace traffic_server.Networking
{
    class PacketHandler
    {
        /// <summary>
        /// Handles incoming packets from the proxy
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public static Packet Handle(Packet packet)
        {
            Tile[] tiles = Form1.MainForm.trafficPanel.GetAllTiles();
            switch (packet.ID)
            {
                case 1: //New vehicle
                    if (tiles != null && tiles.Length > 0)
                        Logic.TrafficManager.AddVehicle(packet);
                    break;
            }
            return null;
        }
    }
}
