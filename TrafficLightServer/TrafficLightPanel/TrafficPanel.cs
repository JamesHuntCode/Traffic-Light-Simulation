using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightPanel
{
    public class TrafficPanel : Panel
    {
        private List<Tile> tilesLst;
        private object tilesLock = new object();

        private List<Vehicle> vehicles;
        private object vehiclesLock = new object();

        //private TrafficLight[] lights;
        //private object lightsLock = new object();

        private object drawLock = new object();

        private bool debug { get; set; }

        /// <summary>
        /// This constructor is used for visual studios designer
        /// </summary>
        public TrafficPanel() : base()
        {
        }

        /// <summary>
        /// Used for initalizing the panel
        /// </summary>
        /// <param name="debug"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="tiles"></param>
        public void Init(bool debug, int width, int height, List<Tile> tiles = null)
        {
            AssetLoader.LoadAssets();
            this.debug = debug;

            base.Size = new Size(width, height);
            this.BackColor = Color.Green;

            if (tiles == null)
                this.tilesLst = new List<Tile>();
            else
                this.tilesLst = tiles;         

            this.vehicles = new List<Vehicle>();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.OptimizedDoubleBuffer, true);

            this.UpdateStyles();

            this.Paint += StagePanel_Paint;
        }

        /// <summary>
        /// Gets items which should be shown to a listbox/comboxbox etc
        /// </summary>
        /// <returns></returns>
        public List<string> GetItemsForShow()
        {
            return AssetLoader.Assets.Where(pair => (pair.Value.Item2 == true)).ToDictionary(x => x.Key, x => x.Value).Keys.ToList();
        }

        /// <summary>
        /// Updates all tiles to a new list<tile>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="tiles"></param>
        public void UpdateTiles(int width, int height, List<Tile> tiles)
        {
            base.Size = new Size(width, height);
            lock (this.tilesLock)
            {
                this.tilesLst.Clear();
                this.tilesLst.AddRange(tiles);
            }

            this.Invalidate();
        }

        /// <summary>
        /// Adds vehicles from a list<vehicle>
        /// </summary>
        /// <param name="vehicles"></param>
        public void AddVehicles(List<Vehicle> vehicles)
        {
            lock (this.vehiclesLock)
            {
                this.vehicles.Clear();
                if (vehicles != null)
                    this.vehicles.AddRange(vehicles);
            }

            this.Invalidate();
        }

        /// <summary>
        /// Gets all vehicles
        /// </summary>
        /// <returns></returns>
        public Vehicle[] GetVehicles()
        {
            return this.vehicles.ToArray();
        }

        /// <summary>
        /// Gets a tile from a point
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public Tile GetTile(Point location)
        {
            location = new Point(Utils.RoundDown(location.X), Utils.RoundDown(location.Y));
            lock (this.tilesLock)
            {
                Tile t = this.tilesLst.Find((tile) => tile.RectLoc.Contains(location));
                if (t != null)
                    return t;
            }
            return null;
        }

        /// <summary>
        /// Gets a tile from an x and y position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Tile GetTile(int x, int y)
        {
            x = Utils.RoundDown(x);
            y = Utils.RoundDown(y);
            lock (this.tilesLock)
            {
                Tile t = this.tilesLst.Find((tile) => tile.RectLoc.Contains(x, y));
                if (t != null)
                    return t;
            }
            return null;
        }

        /// <summary>
        /// Gets the tile above the tile input param
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public Tile GetTileAbove(Tile tile)
        {
            Tile above = this.GetTile(tile.RectLoc.X, tile.RectLoc.Y - 10);
            if (above != null)
                return above;

            return null;
        }

        /// <summary>
        /// Gets the tile to the right of the tile input param
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public Tile GetTileRight(Tile tile)
        {
            Tile right = this.GetTile(tile.RectLoc.X + 10, tile.RectLoc.Y);
            if (right != null)
                return right;

            return null;
        }

        /// <summary>
        /// Gets the tile to the left of the tile input param
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public Tile GetTileLeft(Tile tile)
        {
            Tile left = this.GetTile(tile.RectLoc.X - 10, tile.RectLoc.Y);
            if (left != null)
                return left;

            return null;
        }

        /// <summary>
        /// Gets the tile below the tile input param
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public Tile GetTileBelow(Tile tile)
        {
            Tile below = this.GetTile(tile.RectLoc.X, tile.RectLoc.Y + 10);
            if (below != null)
                return below;

            return null;
        }

        /// <summary>
        /// Gets all tiles
        /// </summary>
        /// <returns></returns>
        public Tile[] GetAllTiles()
        {
            lock (this.tilesLock)
                return this.tilesLst.ToArray();
        }

        /// <summary>
        /// Adds a new tile
        /// </summary>
        /// <param name="tileType"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void AddTile(string tileType, int x, int y, int width, int height)
        {
            Tile tile = new Tile(new Rectangle(x, y, width, height), tileType);

            lock (this.tilesLock)
                this.tilesLst.Add(tile);

            this.Invalidate();
        }

        /// <summary>
        /// Adds a new tile
        /// </summary>
        /// <param name="tile"></param>
        public void AddTile(Tile tile)
        {
            lock (this.tilesLock)
                this.tilesLst.Add(tile);

            this.Invalidate();
        }

        /// <summary>
        /// Changes a tile at a specific point
        /// </summary>
        /// <param name="tileType"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ChangeTile(string tileType, int x, int y)
        {
            Tile tile = this.GetTile(x, y);
            if (tile != null)
            {
               lock (this.tilesLock)
                {
                    tile.TypeTile = tileType;
                }
            }
            this.Invalidate();
        }

        /// <summary>
        /// Removes a tile at a specific point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void RemoveTile(int x, int y)
        {
            lock (this.tilesLock)
            {
                Tile toRemove = this.GetTile(x, y);
                this.tilesLst.Remove(toRemove);
            }
            this.Invalidate();
        }

        /// <summary>
        /// Removes a tile at a specific point
        /// </summary>
        /// <param name="tile"></param>
        public void RemoveTile(Tile tile)
        {
            lock (this.tilesLock)
            { 
                 this.tilesLst.Remove(tile);
            }
            this.Invalidate();
        }

        /// <summary>
        /// Paints to the panel when invalidate() is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StagePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;
            graphic.Clear(Color.Green);
            lock (this.tilesLock)
            {
                foreach (Tile tile in this.tilesLst)
                {
                    if (!AssetLoader.Assets.ContainsKey(tile.TypeTile))
                        continue;

                    if (tile.GetType() != typeof(TrafficLight))
                    {
                        graphic.DrawImage(AssetLoader.Assets[tile.TypeTile].Item1, tile.RectLoc);
                    }
                    else
                    {
                        TrafficLight light = (TrafficLight)tile;
                        graphic.FillRectangle(new SolidBrush(light.LightColour), light.RectLoc);
                    }
                }

                if (debug)
                    graphic.DrawString("Tile count: " + this.tilesLst.Count, DefaultFont, Brushes.White, new PointF(0f, 0f));
            }

            lock (this.vehiclesLock)
            {
                foreach (Vehicle car in this.vehicles)
                {
                    graphic.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(car.HexColour)), car.VehicleRect);
                }

                if (debug)
                    graphic.DrawString("Vehicle count:" + this.vehicles.Count, DefaultFont, Brushes.White, new PointF(0f, 20f));
            }
        }
    }
}
