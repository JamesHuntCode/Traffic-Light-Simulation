using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightPanel
{
    public class Vehicle
    {
        public Rectangle VehicleRect { get; set; }
        public string HexColour { get; set; }

        public Vehicle(Rectangle vehicle, string hex)
        {
            this.VehicleRect = vehicle;
            this.HexColour = hex;
        }
    }
}
