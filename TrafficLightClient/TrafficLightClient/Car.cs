using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrafficLightClient
{
    public class Car
    {
        public float PosX { get; set; }
        public float PosY { get; set; }
        public Color Col { get; set; }

        public Car(float x, float y, string c)
        {
            this.PosX = x;
            this.PosY = y;
            this.Col = ColorTranslator.FromHtml(c);
        }
    }
}
