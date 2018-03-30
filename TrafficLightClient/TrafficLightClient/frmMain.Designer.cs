namespace TrafficLightClient
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlUserControls = new System.Windows.Forms.Panel();
            this.pnlSimulation = new System.Windows.Forms.Panel();
            this.picAppLogo = new System.Windows.Forms.PictureBox();
            this.lblMainHeading = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAppLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUserControls
            // 
            this.pnlUserControls.Location = new System.Drawing.Point(849, 12);
            this.pnlUserControls.Name = "pnlUserControls";
            this.pnlUserControls.Size = new System.Drawing.Size(285, 700);
            this.pnlUserControls.TabIndex = 0;
            // 
            // pnlSimulation
            // 
            this.pnlSimulation.Location = new System.Drawing.Point(12, 99);
            this.pnlSimulation.Name = "pnlSimulation";
            this.pnlSimulation.Size = new System.Drawing.Size(831, 613);
            this.pnlSimulation.TabIndex = 1;
            // 
            // picAppLogo
            // 
            this.picAppLogo.Image = ((System.Drawing.Image)(resources.GetObject("picAppLogo.Image")));
            this.picAppLogo.Location = new System.Drawing.Point(12, 12);
            this.picAppLogo.Name = "picAppLogo";
            this.picAppLogo.Size = new System.Drawing.Size(88, 81);
            this.picAppLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAppLogo.TabIndex = 2;
            this.picAppLogo.TabStop = false;
            // 
            // lblMainHeading
            // 
            this.lblMainHeading.AutoSize = true;
            this.lblMainHeading.Font = new System.Drawing.Font("DINPro-Regular", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainHeading.Location = new System.Drawing.Point(106, 31);
            this.lblMainHeading.Name = "lblMainHeading";
            this.lblMainHeading.Size = new System.Drawing.Size(294, 35);
            this.lblMainHeading.TabIndex = 3;
            this.lblMainHeading.Text = "Traffic Light Simulation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("DINPro-Regular", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 715);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "©2018 James Hunt and Kyle Rusby Some Rights Reserved";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("DINPro-Regular", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1049, 715);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Version: 1.0.0";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 738);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMainHeading);
            this.Controls.Add(this.picAppLogo);
            this.Controls.Add(this.pnlSimulation);
            this.Controls.Add(this.pnlUserControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Traffic Light Simulation - Client";
            ((System.ComponentModel.ISupportInitialize)(this.picAppLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlUserControls;
        private System.Windows.Forms.Panel pnlSimulation;
        private System.Windows.Forms.PictureBox picAppLogo;
        private System.Windows.Forms.Label lblMainHeading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

