using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightPanel;

namespace traffic_server.Logic
{
    class Vehicle : TrafficLightPanel.Vehicle
    {
        public int Direction { get; private set; }

        public Vehicle(Rectangle vehicle, string hex, int direction) : base(vehicle, hex)
        {
            this.Direction = direction;
        }
        public Vehicle(Rectangle vehicle, string hex) : base(vehicle, hex)
        {
        }
    }
}
