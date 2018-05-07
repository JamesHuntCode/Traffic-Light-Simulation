using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic_proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientManager.Init();
            Listener.Start();
        }
    }
}
