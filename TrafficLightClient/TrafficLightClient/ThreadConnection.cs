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

namespace TrafficLightClient
{
    public class ThreadConnection
    {
        /* -------------- Class Properties -------------- */
        NetworkStream stream = null;
        frmMain owner = null;
        BinaryReader inStream = null;
        BinaryWriter outStream = null;
        TcpClient client = null;
        int bufferSize = 200;
        byte[] address = new byte[4];
        bool running = true;
        SynchronizationContext uiContext = null;
        /* ---------------------------------------------- */


        // Constructor ( Create listening socket )
        public ThreadConnection(SynchronizationContext context, TcpClient newClient, frmMain mainForm)
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
