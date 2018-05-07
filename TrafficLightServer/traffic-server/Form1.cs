using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using traffic_networking;
using traffic_server.Networking;
using TrafficLightPanel;

namespace traffic_server
{
    public partial class Form1 : Form
    {
        public static Form1 MainForm { get; private set; }

        private SynchronizationContext context;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.trafficPanel.Init(true, 500, 500);

            //Gets a static version of this form for access with context
            MainForm = this;
            this.context = SynchronizationContext.Current;
            if (this.context == null)
                throw new Exception("No UI context");

            new Thread(this.ConnectClient).Start();
        }

        /// <summary>
        /// Loops until connected to proxy
        /// </summary>
        public void ConnectClient()
        {
            int attempts = 0;
            do
            {
                attempts++;
                this.WriteLog("Connecting to proxy, attempt {0}", attempts);
               Client.Connect(true, "127.0.0.1", 5000, Networking.PacketHandler.Handle, this.exceptionHandler);
            } while (Client.Ready == false);
            this.WriteLog("Connected on attempt {0}", attempts);
        }

        /// <summary>
        /// Handles exceptions from the TcpClient connected to the proxy
        /// </summary>
        /// <param name="ex"></param>
        private void exceptionHandler(Exception ex)
        {
            this.WriteLog("{0}\n{1}", ex.Message, ex.StackTrace);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Tile Map|*.timap",
                Title = "Open a map file"
            };
            dialog.ShowDialog();

            //Uses the Panel DLL to fetch the map tiles
            if (dialog.FileName != "")
            {
                Tuple<int, int, List<Tile>> mapParams = MapManager.OpenMap(dialog.FileName);
                this.trafficPanel.UpdateTiles(mapParams.Item1, mapParams.Item2, mapParams.Item3);
                Logic.TrafficManager.Init();
                this.WriteLog("Map changed: " + dialog.FileName);
            }
        }

        /// <summary>
        /// Writes a log to the log richtextbox regardless of current thread
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void WriteLog(string message, params object[] args)
        {
            string packedMessage = string.Format("[{0}] {1}\n", DateTime.Now.ToLongTimeString(), string.Format(message, args));
            this.context.Post(this.writeLog, packedMessage);
        }

        private void writeLog(object message)
        {
            this.richLog.AppendText((String)message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Adds a new vehicle for testing (also shows on clients connected to proxy)
            Logic.TrafficManager.AddVehicle("#FFFFFF");
        }
    }
}
