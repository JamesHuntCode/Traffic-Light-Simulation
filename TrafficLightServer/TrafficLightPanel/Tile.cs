using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightPanel
{
   public class Tile
    {
        public Rectangle RectLoc { get; set; }
        public string TypeTile { get; set; }

        public Tile(Rectangle location, string type)
        {
            this.RectLoc = location;
            this.TypeTile = type;
        }
    }
}
