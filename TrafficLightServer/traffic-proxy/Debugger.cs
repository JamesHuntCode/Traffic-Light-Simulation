using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic_proxy
{
    class Debugger
    {
        /// <summary>
        /// Formats a string to the console
        /// </summary>
        /// <param name="dType"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void WriteLine(DebuggerType dType, string message, params object[] args)
        {
            setColour(dType);
            Console.WriteLine("[{0}] {1}", DateTime.Now.ToLongTimeString(), string.Format(message, args));
        }

        /// <summary>
        /// Sets a colour for the console output
        /// </summary>
        /// <param name="dType"></param>
        private static void setColour(DebuggerType dType)
        {
            switch (dType)
            {
                case DebuggerType.Normal:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case DebuggerType.Event:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case DebuggerType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }
        }

        public enum DebuggerType
        {
            Normal,
            Error,
            Event,
        }
    }
}
