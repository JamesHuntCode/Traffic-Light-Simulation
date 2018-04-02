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

namespace TrafficLightClient
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.prepareForm();
        }

        // Server status indication
        private bool connected;

        // User preference indication
        private bool autoconnectStatus;

        // Method to style form elements & set form properties
        private void prepareForm()
        {
            // evaluate autoconnect status
            autoconnectStatus = this.checkAutoConnect();
            this.radAutoConnect.Checked = autoconnectStatus;
            this.updateAutoConnect(autoconnectStatus);

            connected = this.connectToServer();

            if (autoconnectStatus)
            {
                if (connected)
                {
                    // put program in loading phase
                    this.updateForm("waiting");

                    // mimic time delay (remove later) to simulate server loading times in application
                    Timer timer = new Timer();
                    timer.Interval = 3000;
                    timer.Tick += new EventHandler(callConnected);
                    timer.Start();

                    // display connected
                    //this.updateForm("connected");
                }
                else
                {
                    MessageBox.Show(text: "Oops! There has been an error connecting to the server. Please try again later.");
                }
            }
            else
            {
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
                // put program in loading phase
                this.updateForm("waiting");

                // connect to server
                this.connectToServer();

                // mimic time delay (remove later) to simulate server loading times in application
                Timer timer = new Timer();
                timer.Interval = 3000;
                timer.Tick += new EventHandler(callConnected);
                timer.Start();

                // display connected
                //this.updateForm("connected");
            }
            else
            {
                // make sure user wants to disconnect
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to disconnect from the server?", "Alert", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // put program in loading phase
                    this.updateForm("waiting");

                    // disconnect from server
                    this.disconnectFromServer();

                    // display disconnected
                    this.updateForm("disconnected");
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
            // come back here...
            return true;
        }

        // Method to break connection from client application to server
        private bool disconnectFromServer()
        {
            // come back here...
            return true;
        }

        private bool createNewCar()
        {
            // come back here...
            return true;
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
                this.lblServerState.Text = "Loading...";
                this.lblServerState.ForeColor = Color.Teal;
                this.grpFunctionality.Enabled = false;
                this.btnConnect.Enabled = false;
            }
        }

        // REMOVE LATER - Method used to demo connection waiting times to program loading screen
        private void callConnected(object sender, EventArgs e)
        {
            this.updateForm("connected");
            Timer timer = (Timer)sender;
            timer.Stop();
        }
    }
}
