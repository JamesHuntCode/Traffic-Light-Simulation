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
using traffic_networking;
using System.Timers;
using TrafficLightPanel;

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
        private int portNumber = 5000;
        //private int bufferSize = 200;
        //private TcpClient client = null;
        //private string server = "eeyore.fost.plymouth.ac.uk";
        //private string server = "localhost";
        private string server = "10.188.98.47";
        //private NetworkStream connectionStream = null;
        //private BinaryReader inStream = null;
        //private BinaryWriter outStream = null;
        //private ConnectionThread threadConnection = null;
        private object sendLock = new object();
        /* ---------------------------------------------------*/

        // Method to style form elements & set form properties
        private void prepareForm()
        {
            // load traffic panel 
            this.trafficPanel.Init(true, 500, 500);
            Tuple<int, int, List<Tile>> mapParams = MapManager.OpenMap(Environment.CurrentDirectory + @"\crossroad.timap");
            this.trafficPanel.UpdateTiles(mapParams.Item1, mapParams.Item2, mapParams.Item3);

            // output user's IP information
            IPHostEntry currentPCInfo = Dns.GetHostEntry(Dns.GetHostName());
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
            Font programFont = new Font("Arial", 14);

            // panels
            this.BackColor = ColorTranslator.FromHtml("#ffffff");
            this.pnlControlsBG.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            this.pnlControls.BackColor = ColorTranslator.FromHtml("#ffffff");
            this.pnlSimulationBG.BackColor = ColorTranslator.FromHtml("#E0E0E0");

            // buttons
            Button[] buttons = { this.btnConnect, this.btnAddCar };
            
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].FlatAppearance.BorderColor = ColorTranslator.FromHtml("#E0E0E0");
                buttons[i].FlatAppearance.BorderSize = 2;
                buttons[i].BackColor = ColorTranslator.FromHtml("#ffffff");
                //buttons[i].Font = programFont;
            }

            // radio buttons
            this.radRed.Checked = true;

            foreach (Control control in Controls)
            {
                //control.Font = programFont;
            }
        }

        // Invoke method to safely exit application
        private void frmMain_FormClosing(object sender, FormClosedEventArgs e)
        {
            this.closeForm();
        }

        // Method invoked when application is terminated
        private void closeForm()
        {
            this.disconnectFromServer();
        }

        // Method to invoke update regarding autoconnect preferences
        private void radAutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            this.updateAutoConnect(!autoconnectStatus);
        }

        // Method to handle incoming data from server
        public void messageReceived(Object thing)
        {
            String message = (String)thing;
            this.lstServerEcho.Items.Add(message);
            this.createMessageBreak();
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
                }
            }
        }

        // Method to invoke the addition of a new car to the server
        private void btnAddCar_Click(object sender, EventArgs e)
        {
            // add new car
            string color = this.getCarColor();
            string hex = this.getHex(color);
            this.createNewCar(hex);

            // code to prevent car spamming
            //this.btnAddCar.Enabled = false;
            // TIMER GOES HERE...
        }

        // Method used to handle incoming packets
        private Packet packetHandler(Packet packet)
        {
            switch (packet.ID)
            {
                case 1:

                    this.readCar(packet);

                    break;
                case 2:

                    this.readLights(packet);
                       
                    break;
            }

            return null;
        }

        // Method to handle light changes
        private void readLights(Packet packet)
        {
            int ID = packet.ReadInt();
            string color = packet.ReadString();

            TrafficLight[] lights = this.trafficPanel.GetAllTiles().Where(tile => tile.GetType() == typeof(TrafficLight)).Cast<TrafficLight>().ToArray();
            TrafficLight light = lights.Where(l => l.ID == ID).ToArray()[0];
            light.ChangeColour(ColorTranslator.FromHtml(color), this.trafficPanel);
        }

        // Method to handle incoming car data 
        private void readCar(Packet packet)
        {
            int count = packet.ReadInt();
            List <Vehicle> vehicles = new List<Vehicle>();
            
            for (int i = 0; i < count; i++)
            {
                Rectangle rect = new Rectangle(packet.ReadInt(), packet.ReadInt(), 10, 10);
                string hex = packet.ReadString();
                vehicles.Add(new Vehicle(rect, hex));
            }

            this.trafficPanel.AddVehicles(vehicles);
        }

        // Method to handle exceptions in client 
        private void exceptionHandler(Exception exception)
        {
            MessageBox.Show(exception.Message);
        }

        // Method to connect client application to server
        private bool connectToServer()
        {
            Client.Connect(false, this.server, this.portNumber, packetHandler, exceptionHandler);

            return Client.Ready;
        }

        // Method to break connection from client application to server
        private void disconnectFromServer()
        {
            Client.Kill();
        }

        // Method to allow clients to add new cars to server
        private void createNewCar(string data)
        {
            Packet packet = new Packet(1);
            packet.WriteString(data);
            sendDataToServer(packet);
        }
        
        // Method used to deliver data from the client to the server
        private void sendDataToServer(Packet packet)
        {
            try
            {
                Client.SendPacket(packet);

                this.pushNotification("new-car");
            }
            catch (Exception)
            {
                this.connected = false;
                this.pushNotification("fail");
                this.updateForm("disconnected");
                this.pushNotification("disconnected");
            }
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
                case "new-car":

                    this.lstServerEcho.Items.Add("New car added @ " + theTime);

                    break;
                case "fail":

                    this.lstServerEcho.Items.Add("Sever failed to receive car @ " + theTime);

                    break;
                case "denied":

                    this.lstServerEcho.Items.Add("Access denied to send new car @ " + theTime);

                    break;
            }
            this.createMessageBreak();

            // Always show most recent logs
            this.lstServerEcho.TopIndex = this.lstServerEcho.Items.Count - 1;
        }

        // Method called when break is needed between server echo messages
        private void createMessageBreak()
        {
            List<char> messageBreakChars = new List<char>();
            int amountOfChars = 1000;

            for (int i = 0; i < amountOfChars; i++)
            {
                messageBreakChars.Add('-');
            }

            this.lstServerEcho.Items.Add(String.Join("", messageBreakChars));
        }

        // Method used to get hex value of predefined color
        private string getHex(string color)
        {
            string colorCode = "";

            switch (color)
            {
                case "red":

                    colorCode = "#FF0000";

                    break;
                case "green":

                    colorCode = "#008000"; 

                    break;
                case "blue":

                    colorCode = "#0000FF";

                    break;
                case "yellow":

                    colorCode = "#F7DC6F";

                    break;
                case "black":

                    colorCode = "#333";

                    break;
                case "gray":

                    colorCode = "#616A6B";

                    break;
                case "cyan":

                    colorCode = "#1ABC9C";

                    break;
                case "orange":

                    colorCode = "#D35400";

                    break;
                case "pink":

                    colorCode = "#AF7AC5";

                    break;
                case "purple":

                    colorCode = "#7D3C98";

                    break;
            }

            return colorCode;
        }

        // Method used to get color for new car
        private string getCarColor()
        {
            string color = "";
            RadioButton selected = new RadioButton();

            RadioButton[] radioButtons = { this.radRed, this.radGreen, this.radBlue, this.radYellow, this.radBlack,
                this.radGray, this.radCyan, this.radOrange, this.radPink, this.radPurple };

            for (int i = 0; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked)
                {
                    selected = radioButtons[i];
                }
            }

            color = selected.Text.ToLower();

            return color;
        }
    }
}
