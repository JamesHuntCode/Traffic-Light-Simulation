using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightPanel
{
    public class MapManager
    {
        //public static TrafficLight[] MapLights { get; private set; }

        /// <summary>
        /// Saves a map as a .timap file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="panel"></param>
        /// <returns></returns>
        public static bool SaveMap(string filePath, TrafficPanel panel)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        //Writes height and width with count of tiles
                        bw.Write(panel.Width);
                        bw.Write(panel.Height);

                        Tile[] tiles = panel.GetAllTiles();
                        bw.Write(tiles.Length);

                        //Writes each tiles X Y and type tile
                        foreach (Tile tile in tiles)
                        {
                            bw.Write(tile.RectLoc.X);
                            bw.Write(tile.RectLoc.Y);
                            bw.Write(tile.TypeTile);

                            //If its a trafficlight it writes its specific properties
                            if (tile.TypeTile == "TrafficLight")
                            {
                                TrafficLight light = (TrafficLight)tile;
                                bw.Write(light.ID);
                                bw.Write(light.RectLoc.Width);
                                bw.Write(light.RectLoc.Height);
                                bw.Write(light.TrafficSide);
                                int[] syncedLights = light.GetSyncedLights();

                                //Writes it's synced lights ID's
                                bw.Write(syncedLights.Length);
                                foreach (int i in syncedLights)
                                {
                                    bw.Write(i);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Reads a map from a .timap file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Tuple<int, int, List<Tile>> OpenMap(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        //Reads maps height and width with count of tiles
                        int width = br.ReadInt32();
                        int height = br.ReadInt32();
                        List<Tile> tiles = new List<Tile>();
                        int tileCount = br.ReadInt32();
                        for (int i = 0; i < tileCount; i++)
                        {
                            //Reads tiles x and y pos
                            int x = br.ReadInt32();
                            int y = br.ReadInt32();
                            string typeTile = br.ReadString();

                            //If a trafficlight it reads its specific properties
                            if (typeTile == "TrafficLight")
                            {
                                //Reads its id, width, heigh and  which direction cars come
                                int id = br.ReadInt32();
                                int rectWidth = br.ReadInt32();
                                int rectHeight = br.ReadInt32();
                                int waitSide = br.ReadInt32();
                                TrafficLight light = new TrafficLight(id, waitSide, new Rectangle(x, y, rectWidth, rectHeight));
                                //Reads synced lights ID's
                                int syncCount = br.ReadInt32();
                                for (int j = 0; j < syncCount; j++)
                                {
                                    light.AddSyncedLight(br.ReadInt32());
                                }
                                tiles.Add(light);
                            }
                            else
                            {
                                tiles.Add(new Tile(new Rectangle(x, y, 10, 10), typeTile));
                            }
                        }
                        return new Tuple<int, int, List<Tile>>(width, height, tiles);
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
