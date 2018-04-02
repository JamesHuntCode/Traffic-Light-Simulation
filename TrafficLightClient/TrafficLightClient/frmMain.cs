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
        private bool connected = false;

        // User preference indication
        private bool autoconnect;

        // Method to style form elements & set form properties
        private void prepareForm()
        {
            // evaluate autoconnect status
            autoconnect = this.checkAutoConnect();
            this.radAutoConnect.Checked = autoconnect;

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

            // labels
            this.lblServerState.Text = "Disconnected";
            this.lblServerState.ForeColor = Color.Red;

            // group boxes 
            this.grpFunctionality.Enabled = false;
        }

        // Method to invoke update regarding autoconnect preferences
        private void radAutoConnect_CheckedChanged(object sender, EventArgs e)
        {

        }

        // Method to invoke connection from client application to server
        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.connected = !this.connected;

            if (connected)
            {
                // update form styles & content
                this.btnConnect.Text = "Disconnect";
                this.lblServerState.Text = "Connected";
                this.lblServerState.ForeColor = Color.Green;
                this.grpFunctionality.Enabled = true;

                // connect to server
                this.connectToServer();
            }
            else
            {
                // make sure user wants to disconnect
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to disconnect from the server?", "Warning", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // update form styles & content
                    this.btnConnect.Text = "Connect";
                    this.lblServerState.Text = "Disconnected";
                    this.lblServerState.ForeColor = Color.Red;
                    this.grpFunctionality.Enabled = false;

                    // disconnect from server
                    this.disconnectFromServer();
                }
            }
        }

        // Method to invoke the addition of a new car to the server
        private void btnAddCar_Click(object sender, EventArgs e)
        {
            this.createNewCar();
        }

        // Method to connect client application to server
        private void connectToServer()
        {
            // come back here...
        }

        // Method to break connection from client application to server
        private void disconnectFromServer()
        {
            // come back here...
        }

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
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private void updateAutoConnect()
        {

        }
    }
}
