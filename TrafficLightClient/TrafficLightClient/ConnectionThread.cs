using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using traffic_networking;

namespace TrafficLightClient
{
    public class ConnectionThread
    {
        /* -------------- Class Properties -------------- */
        NetworkStream stream = null;
        frmMain owner = null;
        BinaryReader inStream = null;
        BinaryWriter outStream = null;
        TcpClient client = null;
        int readSize = 0;
        byte[] buffer = null;
        byte[] address = new byte[4];
        bool running = true;
        SynchronizationContext uiContext = null;
        /* ---------------------------------------------- */


        // Constructor ( Create listening socket )
        public ConnectionThread(SynchronizationContext context, TcpClient newClient, frmMain mainForm)
        {
            this.client = newClient;
            this.stream = this.client.GetStream();
            this.owner = mainForm;
            this.uiContext = context;
            this.inStream = new BinaryReader(stream);
            this.outStream = new BinaryWriter(stream);
        }

        // Method to transform class instance into seperate thead
        public void Run()
        {
            try
            {
                this.buffer = new byte[4];
                this.client.GetStream().BeginRead(this.buffer, 0, this.buffer.Length, readLength, null);

                //this.uiContext.Post(this.owner.messageReceived, message);
            }
            catch (Exception)
            {
                this.running = false;
            }
        }

        private void readLength(IAsyncResult ar)
        {
            int read = this.client.GetStream().EndRead(ar);
            if (read < this.buffer.Length)
                throw new Exception("err");

            int length = 0;
            using (MemoryStream ms = new MemoryStream())
            using (BinaryReader br = new BinaryReader(ms))
                length = br.ReadInt32();

            this.buffer = new byte[length];
            this.client.GetStream().BeginRead(this.buffer, 0, this.buffer.Length, readPacket, null);
        }

        private void readPacket(IAsyncResult ar)
        {
            int read = this.client.GetStream().EndRead(ar);
            if (read < this.buffer.Length)
                throw new Exception("err");

            Packet packet = new Packet(this.buffer);
            MessageBox.Show(packet.ID.ToString());
            //HANDLE PACKET
            this.Run();
        }

        // Method to stop running thread and terminate active connection
        public void StopThread()
        {
            this.running = false;
            this.client.GetStream().Close();
            this.client.Close();
        }
    }
}
