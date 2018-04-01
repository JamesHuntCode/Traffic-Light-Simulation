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

            // panels
            this.BackColor = ColorTranslator.FromHtml("#ffffff");
            this.pnlControlsBG.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            this.pnlControls.BackColor = ColorTranslator.FromHtml("#ffffff");
            this.pnlSimulationBG.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            this.pnlSimulation.BackColor = ColorTranslator.FromHtml("#ffffff");

            // buttons
            this.btnConnect.FlatStyle = FlatStyle.Flat;
            this.btnConnect.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#E0E0E0");
            this.btnConnect.FlatAppearance.BorderSize = 2;
            this.btnConnect.BackColor = ColorTranslator.FromHtml("#ffffff");
             
            // labels
            this.lblServerState.Text = "Disconnected";
            this.lblServerState.ForeColor = Color.Red;
        }

        // Method to connect client app to server
        private void btnConnect_Click(object sender, EventArgs e)
        {

        }
    }
}
