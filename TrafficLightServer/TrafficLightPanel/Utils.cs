using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightPanel
{
    public class Utils
    {
        /// <summary>
        /// Rounds a number down to the nearest multiple of 10
        /// </summary>
        /// <param name="toRound"></param>
        /// <returns></returns>
        public static int RoundDown(int toRound)
        {
            return toRound - toRound % 10;
        }
    }
}
