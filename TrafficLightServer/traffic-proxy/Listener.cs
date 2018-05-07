using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace traffic_proxy
{
    class Listener
    {
        private static TcpListener listener;

        /// <summary>
        /// Starts the TcpListener on port 5000
        /// </summary>
        public static void Start()
        {
            //listener = new TcpListener(IPAddress.Any, 5000);
            listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                new Thread(() => checkClient(client)).Start();
            }
        }

        /// <summary>
        /// Checks if its a client or server connecting with timeout
        /// </summary>
        /// <param name="client"></param>
        private static void checkClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            bool server = false;
            DateTime timeout = DateTime.Now.AddSeconds(5);
            try
            {
                while (!stream.DataAvailable)
                {
                    if ((DateTime.Now - timeout).Seconds >= 5)
                        throw new Exception("Timed out");

                    Thread.Sleep(10);
                }

                int byteRead = stream.ReadByte();

                if (byteRead == 0)
                    server = false;
                else if (byteRead == 1)
                    server = true;
                else
                    throw new Exception("Client didn't send correct connection byte");

                ClientManager.AddClient(server, client);
            }
            catch (Exception ex)
            {
                Debugger.WriteLine(Debugger.DebuggerType.Error, "{0} Error {1}", client.Client.RemoteEndPoint, ex.Message);
                client.Close();
            }
        }
    }
}
