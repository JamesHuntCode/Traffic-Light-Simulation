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

        // Method to style form elements & set form properties
        private void prepareForm()
        { 
            Color backgroundColor = ColorTranslator.FromHtml("#ffffff");
            //Color panelColor = ColorTranslator.FromHtml("#E0E0E0");

            this.BackColor = backgroundColor;
            //this.pnlUserControls.BackColor = panelColor;
        }
    }
}
