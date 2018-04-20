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
    public class ConnectionThread
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
                while (this.running)
                {
                    // wait until something is readible (block until so)
                    byte[] dataPacket = new Byte[this.bufferSize];
                    inStream.Read(dataPacket, 0, this.bufferSize);

                    // get sender IP (first 4 bytes of packet)
                    byte ip1 = dataPacket[0];
                    byte ip2 = dataPacket[1];
                    byte ip3 = dataPacket[2];
                    byte ip4 = dataPacket[3];
                    string senderIP = ip1.ToString() + "." + ip2.ToString() + "." + ip3.ToString() + "." + ip4.ToString();
                    char[] chars = new char[this.bufferSize];

                    // assemble char array (iterate through buffer)
                    int charCount = 0;
                    int bufferIndex = 4;

                    for (int i = 0; i < (this.bufferSize - 4); i++)
                    {
                        chars[i] = (char)dataPacket[bufferIndex++];
                        charCount++;

                        if (chars[i] == 0)
                        {
                            break;
                        }
                    }

                    // send message from server back to main form
                    String messageFromServer = new String(chars, 0, charCount);
                    String message = senderIP + " sent: " + messageFromServer;
                    this.uiContext.Post(this.owner.messageReceived, message);
                }
            }
            catch (Exception)
            {
                this.running = false;
            }
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
