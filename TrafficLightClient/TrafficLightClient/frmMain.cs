using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TrafficLightClient
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.prepareForm();
        }

        private bool connected;
        private bool autoconnectStatus;
        SynchronizationContext uiContext = null;

        /* ------------- Networking attributes -------------- */
        private int portNumber = 8080;
        private int bufferSize = 200;
        private TcpClient client = null;
        private string server = "eeyore.fost.plymouth.ac.uk";
        private NetworkStream connectionStream = null;
        private BinaryReader inStream = null;
        private BinaryWriter outStream = null;
        private ThreadConnection threadConnection = null;
        /* ---------------------------------------------------*/

        // Method to style form elements & set form properties
        private void prepareForm()
        {
            // output user's IP information
            IPHostEntry currentPCInfo = Dns.GetHostEntry(Dns.GetHostName());
            this.createMessageBreak();
            foreach (IPAddress address in currentPCInfo.AddressList)
            {
                this.lstServerEcho.Items.Add(address.ToString());
            }
            this.createMessageBreak();

            // get sync-context for current form thread 
            uiContext = SynchronizationContext.Current;
            if (this.uiContext == null)
            {
                lstServerEcho.Items.Add("No context established.");
            }
            else
            {
                lstServerEcho.Items.Add("Context established.");
            }
            this.createMessageBreak();

            // begin initiation connection (if required)
            autoconnectStatus = this.checkAutoConnect();
            this.radAutoConnect.Checked = autoconnectStatus;
            this.updateAutoConnect(autoconnectStatus);

            connected = false;

            if (autoconnectStatus)
            {
                this.updateForm("waiting");
                connected = this.connectToServer();

                if (connected)
                {
                    this.updateForm("connected");
                    this.connected = true;
                }
                else
                {
                    MessageBox.Show(text: "Oops! There has been an error connecting to the server. Please try again later.");
                    this.pushNotification("failure");
                    this.connected = false;
                    this.updateForm("disconnected");
                }
            }
            else
            {
                connected = false;

                // group boxes 
                this.grpFunctionality.Enabled = false;

                // labels
                this.lblServerState.Text = "Disconnected";
                this.lblServerState.ForeColor = Color.Red;
            }

            // set copyright date
            string currentYear = DateTime.Now.Year.ToString();
            this.lblCopyright.Text = "© " + currentYear + " James Hunt and Kyle Rusby Some Rights Reserved";

            // style form colors

            // panels
            this.BackColor = ColorTranslator.FromHtml("#ffffff");
            this.pnlControlsBG.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            this.pnlControls.BackColor = ColorTranslator.FromHtml("#ffffff");
            this.pnlSimulationBG.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            this.pnlSimulation.BackColor = ColorTranslator.FromHtml("#ffffff");

            // buttons
            Button[] buttons = { this.btnConnect, this.btnAddCar };
            
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].FlatAppearance.BorderColor = ColorTranslator.FromHtml("#E0E0E0");
                buttons[i].FlatAppearance.BorderSize = 2;
                buttons[i].BackColor = ColorTranslator.FromHtml("#ffffff");
            }

            // radio buttons
            this.radRed.Checked = true;
        }

        // Invoke method to safely exit application
        private void frmMain_FormClosing(object sender, FormClosedEventArgs e)
        {
            this.closeForm();
        }

        // Method invoked when application is terminated
        private void closeForm()
        {
            if (this.threadConnection != null)
            {
                // kill current connection
                //this.threadConnection.StopThread();
            }
        }

        // Method to invoke update regarding autoconnect preferences
        private void radAutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            this.updateAutoConnect(!autoconnectStatus);
        }

        // Method to invoke connection from client application to server
        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.connected = !this.connected;

            if (connected)
            {
                this.updateForm("waiting");

                // connect to server
                bool connection = this.connectToServer();

                if (connection)
                {
                    this.updateForm("connected");
                    this.connected = true;
                }
                else
                {
                    MessageBox.Show(text: "Oops! There has been an error connecting to the server. Please try again later.");
                    this.pushNotification("failure");
                    this.updateForm("disconnected");
                    this.connected = false;
                }
            }
            else
            {
                // make sure user wants to disconnect
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to disconnect from the server?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    this.updateForm("waiting");

                    // disconnect from server
                    this.disconnectFromServer();
                    this.updateForm("disconnected");
                    this.pushNotification("disconnected");
                    this.createMessageBreak();
                }
            }
        }

        // Method to invoke the addition of a new car to the server
        private void btnAddCar_Click(object sender, EventArgs e)
        {
            this.createNewCar();
        }

        // Method to connect client application to server
        private bool connectToServer()
        {
            return true;
        }

        // Method to break connection from client application to server
        private bool disconnectFromServer()
        {
            // come back here...
            return true;
        }

        // Method to allow clients to add new cars to server
        private void createNewCar()
        {
            // come back here...
        }

        // Method to see if user wishes to connect automatically (upon app open)
        private bool checkAutoConnect()
        {
            string filePath = Environment.CurrentDirectory + @"\preferences.txt";
            
            if (File.Exists(filePath))
            {
                using (StreamReader mySR = new StreamReader(filePath))
                {
                    if (mySR.ReadLine() == "true")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Method to update current user preferences (auto connect)
        private void updateAutoConnect(bool newPreference)
        {
            string filePath = Environment.CurrentDirectory + @"\preferences.txt";

            if (File.Exists(filePath))
            {
                using (StreamWriter mySW = new StreamWriter(filePath))
                {
                    mySW.WriteLine(newPreference.ToString().ToLower());
                }
            }
        }

        // Method to display current status of server / program state
        private void updateForm(string status)
        {
            if (status == "connected")
            {
                this.btnConnect.Text = "Disconnect";
                this.lblServerState.Text = "Connected";
                this.lblServerState.ForeColor = Color.Green;
                this.grpFunctionality.Enabled = true;
                this.btnConnect.Enabled = true;
                this.pushNotification("connected");
                this.createMessageBreak();
            }
            else if (status == "disconnected")
            {
                this.btnConnect.Text = "Connect";
                this.lblServerState.Text = "Disconnected";
                this.lblServerState.ForeColor = Color.Red;
                this.grpFunctionality.Enabled = false;
                this.btnConnect.Enabled = true;
            }
            else
            {
                this.btnConnect.Text = "Disconnect";
                this.lblServerState.Text = "Connecting...";
                this.lblServerState.ForeColor = Color.Teal;
                this.grpFunctionality.Enabled = false;
                this.btnConnect.Enabled = false;
            }
        }

        // Method to update list box with server responses etc
        private void pushNotification(string type)
        {
            string theTime = DateTime.Now.ToShortTimeString();

            switch (type)
            {
                case "connected":

                    this.lstServerEcho.Items.Add("You connected to the sever @ " + theTime);

                    break;
                case "disconnected":

                    this.lstServerEcho.Items.Add("You disconnected from the sever @ " + theTime);

                    break;
                case "failure":

                    this.lstServerEcho.Items.Add("Server connection failed @ " + theTime);

                    break;
            }
        }

        // Method called when break is needed between server echo messages
        private void createMessageBreak()
        {
            this.lstServerEcho.Items.Add("-------------------------------------------");
        }
    }
}
