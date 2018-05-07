using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using traffic_networking;

namespace traffic_proxy
{
    class ClientManager
    {
        public static Client ServerConnection { get; private set; }

        private static List<Client> clients;
        private static object clientsLock;

        /// <summary>
        /// Init ClientManager
        /// </summary>
        public static void Init()
        {
            clients = new List<Client>();
            clientsLock = new object();
            //Run loop for timeouts
        }

        /// <summary>
        /// Adds a client to the manager
        /// </summary>
        /// <param name="server"></param>
        /// <param name="client"></param>
        public static void AddClient(bool server, TcpClient client)
        {
            Client packedClient = new Client(server, client);

            if (server)
            {
                ServerConnection = packedClient;
            }
            else
            {
                lock (clientsLock)
                    clients.Add(packedClient);
            }

            Debugger.WriteLine(Debugger.DebuggerType.Event, "Added new {0} {1}", server ? "server" : "client",
                packedClient.IPAddress);
        }

        /// <summary>
        /// Removes a client from the manager, killing it
        /// </summary>
        /// <param name="client"></param>
        /// <param name="reason"></param>
        public static void RemoveClient(Client client, string reason = "")
        {
            client.Kill(reason);

            lock (clientsLock)
                clients.Remove(client);

            Debugger.WriteLine(Debugger.DebuggerType.Event, "Removed client {0}", client.IPAddress);
        }

        /// <summary>
        /// Sends a packet to all clients and optional server
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="sendServer"></param>
        public static void SendPacketToAll(Packet packet, bool sendServer)
        {
            lock (clientsLock)
            {
                foreach (Client c in clients)
                {
                    c.SendPacket(packet);
                }
            }
            if (sendServer)
                ServerConnection.SendPacket(packet);
        }

        /// <summary>
        /// Sends a byte array to all clients
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="sendServer"></param>
        public static void SendBytesToAll(byte[] bytes, bool sendServer)
        {
            lock (clientsLock)
            {
                foreach (Client c in clients)
                {
                    c.SendBytes(bytes);
                }
            }
            if (sendServer)
                ServerConnection.SendBytes(bytes);
        }
    }
}
