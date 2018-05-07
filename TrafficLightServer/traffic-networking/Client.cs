using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace traffic_networking
{
    public class Client
    {
        public static EndPoint IPAddress { get; private set; }
        public static bool Connected { get { if (client != null) return client.Connected; else return false; } }
        public static bool Ready { get; private set; }

        private static TcpClient client;
        private static NetworkStream stream;
        private static Func<Packet, Packet> packetHandler;
        private static Action<Exception> exceptionHandler;
        private static byte[] buffer;
        private static object sendPacketLock = new object();

        /// <summary>
        /// Connects to a proxy as a server or client
        /// </summary>
        /// <param name="asServer"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="pHandler"></param>
        /// <param name="eHandler"></param>
        public static void Connect(bool asServer, string server, int port, Func<Packet, Packet> pHandler, 
            Action<Exception> eHandler)
        {
            packetHandler = pHandler;
            exceptionHandler = eHandler;

            Ready = false;
            try { client = new TcpClient(server, port); }
            catch (Exception ex) { exceptionHandler(ex); return; }

            stream = client.GetStream();

            //Send server connect
            stream.WriteByte(asServer == true ? (byte)1 : (byte)0);

            IPAddress = client.Client.RemoteEndPoint;
            new Thread(beginRead).Start();
            Ready = true;
        }

        /// <summary>
        /// Starts an async read
        /// </summary>
        private static void beginRead()
        {
            try
            {
                buffer = new byte[4];
                stream.BeginRead(buffer, 0, buffer.Length, readPacketLength, null);
            }
            catch (Exception ex)
            {
                //Form1.MainForm.WriteLog(string.Format("{0} beginRead() -> {1}", IPAddress, ex.Message));
                exceptionHandler(ex);
            }
        }

        /// <summary>
        /// Reads the packet length async
        /// </summary>
        /// <param name="ar"></param>
        private static void readPacketLength(IAsyncResult ar)
        {
            try
            {
                int read = stream.EndRead(ar);
                if (read < buffer.Length)
                    throw new Exception("readPacketLength() stream read less than expected");

                int toRead = 0;

                using (MemoryStream ms = new MemoryStream(buffer))
                using (BinaryReader br = new BinaryReader(ms))
                    toRead = br.ReadInt32();

                //if (toRead > 200)
                //    throw new Exception("Houston, we have a problem... update pls");

                buffer = new byte[toRead];
                stream.BeginRead(buffer, 0, buffer.Length, readPacket, null);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("{0} readPacketLength() -> {1}", IPAddress, ex.Message));
                exceptionHandler(ex);
            }
        }

        /// <summary>
        /// Reads a packet as async
        /// </summary>
        /// <param name="ar"></param>
        private static void readPacket(IAsyncResult ar)
        {
            try
            {
                int read = stream.EndRead(ar);
                if (read < buffer.Length)
                    throw new Exception("readPacket() stream read less than expected");

                Packet returnPacket = packetHandler(new Packet(buffer));
                if (returnPacket != null)
                    SendPacket(returnPacket);

                beginRead();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("{0} readPacket() -> {1}\n{2}", IPAddress, ex.Message, ex.StackTrace));
                exceptionHandler(ex);
            }
        }

        /// <summary>
        /// Closes the connection
        /// </summary>
        public static void Kill()
        {
            client.Close();
        }

        /// <summary>
        /// Sends a packet to the proxy
        /// </summary>
        /// <param name="packet"></param>
        public static void SendPacket(Packet packet)
        {
            lock (sendPacketLock)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (BinaryWriter bw = new BinaryWriter(ms))
                    {
                        byte[] bytes = packet.GetBytes();
                        bw.Write(bytes.Length + 4);
                        bw.Write(packet.ID);
                        bw.Write(bytes);

                        byte[] toSend = ms.ToArray();
                        stream.Write(toSend, 0, toSend.Length);
                    }
                }
            }
        }

        /// <summary>
        /// Sends a byte array to the proxy
        /// </summary>
        /// <param name="bytes"></param>
        public static void SendBytes(byte[] bytes)
        {
            lock (sendPacketLock)
            {
                stream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
