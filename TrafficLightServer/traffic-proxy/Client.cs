using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using traffic_networking;

namespace traffic_proxy
{
    class Client
    {
        public DateTime LastPing { get; private set; }
        public EndPoint IPAddress { get; private set; }

        private TcpClient client;
        private NetworkStream stream;
        private byte[] buffer;
        private object sendPacketLock;

        private bool server;

        public Client(bool server, TcpClient client)
        {
            this.LastPing = DateTime.Now;
            this.client = client;
            this.stream = client.GetStream();
            this.IPAddress = client.Client.RemoteEndPoint;
            this.server = server;
            this.sendPacketLock = new object();
            new Thread(this.beginRead).Start();
        }

        /// <summary>
        /// Starts async read for packets
        /// </summary>
        private void beginRead()
        {
            try
            {
                this.buffer = new byte[4];
                this.stream.BeginRead(this.buffer, 0, this.buffer.Length, this.readPacketLength, null);
            }
            catch (Exception ex)
            {
                Debugger.WriteLine(Debugger.DebuggerType.Error, "{0} beginRead() -> {1}", this.IPAddress, ex.Message);
                ClientManager.RemoveClient(this);
            }
        }

        /// <summary>
        /// Async method for reading packet length
        /// </summary>
        /// <param name="ar"></param>
        private void readPacketLength(IAsyncResult ar)
        {
            try
            {
                int read = this.stream.EndRead(ar);
                if (read < this.buffer.Length)
                    throw new Exception("readPacketLength() stream read less than expected");

                int toRead = 0;

                using (MemoryStream ms = new MemoryStream(this.buffer))
                using (BinaryReader br = new BinaryReader(ms))
                    toRead = br.ReadInt32();

                //if (toRead > 200)
                //    throw new Exception("Houston, we have a problem... update pls");

                this.buffer = new byte[toRead];
                this.stream.BeginRead(this.buffer, 0, this.buffer.Length, this.readPacket, null);
            }
            catch (Exception ex)
            {
                Debugger.WriteLine(Debugger.DebuggerType.Error, "{0} readPacketLength() -> {1}", this.IPAddress, ex.Message);
                ClientManager.RemoveClient(this);
            }
        }

        /// <summary>
        /// Async method for reading packet
        /// </summary>
        /// <param name="ar"></param>
        private void readPacket(IAsyncResult ar)
        {
            try
            {
                int read = this.stream.EndRead(ar);
                if (read < this.buffer.Length)
                    throw new Exception("readPacket() stream read less than expected");

                if (this.server)
                {
                    ClientManager.SendBytesToAll(this.buffer, false);
                    Debugger.WriteLine(Debugger.DebuggerType.Event, "server sent packet to all");
                }
                else
                {
                    if (ClientManager.ServerConnection != null)
                    {
                        ClientManager.ServerConnection.SendBytes(this.buffer);
                        Debugger.WriteLine(Debugger.DebuggerType.Event, "{0} sent packet to server", this.IPAddress);
                    }
                }

                this.LastPing = DateTime.Now;

                this.beginRead();
            }
            catch (Exception ex)
            {
                Debugger.WriteLine(Debugger.DebuggerType.Error, "{0} readPacket() -> {1}", this.IPAddress, ex.Message);
                ClientManager.RemoveClient(this);
            }
        }

        /// <summary>
        /// Dead method, not in use
        /// </summary>
        /// <param name="reason"></param>
        public void Kill(string reason)
        {
            //Packet packet = new Packet(2);
            //packet.WriteString(reason);
            //this.SendPacket(packet);
        }

        /// <summary>
        /// Sends packet to TcpClient
        /// </summary>
        /// <param name="packet"></param>
        public void SendPacket(Packet packet)
        {
            lock (this.sendPacketLock)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (BinaryWriter br = new BinaryWriter(ms))
                        {
                            byte[] bytes = packet.GetBytes();
                            br.Write(bytes.Length + 4);
                            br.Write(packet.ID);
                            br.Write(bytes);

                            byte[] toSend = ms.ToArray();
                            this.stream.Write(toSend, 0, toSend.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debugger.WriteLine(Debugger.DebuggerType.Error, "{0} sendPacket() -> {1}", this.IPAddress, ex.Message);
                }
            }
        }

        /// <summary>
        /// Sends a byte array to the TcpClient
        /// </summary>
        /// <param name="bytes"></param>
        public void SendBytes(byte[] bytes)
        {
            lock (this.sendPacketLock)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (BinaryWriter bw = new BinaryWriter(ms))
                        {
                            bw.Write(bytes.Length);
                            bw.Write(bytes);
                            byte[] toSend = ms.ToArray();
                            this.stream.Write(toSend, 0, toSend.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debugger.WriteLine(Debugger.DebuggerType.Error, "{0} sendPacket() -> {1}", this.IPAddress, ex.Message);
                }
            }
        }
    }
}
