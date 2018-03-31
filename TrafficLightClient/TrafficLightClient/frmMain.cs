using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        // Method to style form elements & set form properties
        private void prepareForm()
        {
            // set copyright date
            string currentYear = DateTime.Now.Year.ToString();
            this.lblCopyright.Text = "© " + currentYear + " James Hunt and Kyle Rusby Some Rights Reserved";

            // style form colors
            this.BackColor = ColorTranslator.FromHtml("#ffffff");
            this.pnlControlsBG.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            this.pnlControls.BackColor = ColorTranslator.FromHtml("#ffffff");
            this.pnlSimulationBG.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            this.pnlSimulation.BackColor = ColorTranslator.FromHtml("#ffffff");

            // Move this to seperate method when connection testing become possible...
            if (connected)
            {
                this.lblServerState.Text = "Connected";
                this.lblServerState.ForeColor = Color.Green;
                this.lstServerEcho.Items.Add("You are now connected.");
            }
            else
            {
                this.lblServerState.Text = "Disconnected";
                this.lblServerState.ForeColor = Color.Red;
                this.lstServerEcho.Items.Add("You are not currently connected.");
            }
        }
    }
}
