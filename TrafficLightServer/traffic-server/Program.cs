using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace traffic_server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /// <summary>
        /// Gives the ability to generate a random number without it generating the same one
        /// twice
        /// </summary>
        private static object lockNum = new object();
        private static Random rnd = new Random();
        public static int GetNum(int min, int max)
        {
            lock (rnd)
            {
                return rnd.Next(min, max);
            }
        }
    }
}
