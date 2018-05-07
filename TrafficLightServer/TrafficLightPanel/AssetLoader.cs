using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightPanel
{
    public class AssetLoader
    {
        public static Dictionary<string, Tuple<Image, bool>> Assets { get; private set; }

        /// <summary>
        /// Loads all images into a dictionary for reuse
        /// </summary>
        public static void LoadAssets()
        {
            Assets = new Dictionary<string, Tuple<Image, bool>>();
            Assembly assembly = Assembly.GetExecutingAssembly();

            string[] assets = assembly.GetManifestResourceNames();
            assets = assets.Where(str => str.ToLower().Contains(".bmp")).ToArray();

            //Loads images from embedded resource
            foreach (string str in assets)
            {
                Stream image = assembly.GetManifestResourceStream(str);
                string[] parts = str.Split('.');
                string tileType = parts[parts.Length - 2];
                Assets.Add(tileType, new Tuple<Image, bool>(Image.FromStream(image), showItem(tileType)));
            }
        }

        /// <summary>
        /// This is used in the Map Editor where if it returns true it should
        /// show within a combobox or list box
        /// </summary>
        /// <param name="tileType"></param>
        /// <returns></returns>
        private static bool showItem(string tileType)
        {
            switch (tileType)
            {
                //case "RoadDirection":
                //    return false;

                default:
                    return true;
            }
        }
    }
}
