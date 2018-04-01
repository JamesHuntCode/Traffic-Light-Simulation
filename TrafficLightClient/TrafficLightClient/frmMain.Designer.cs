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
            this.pnlControlsBG = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblServerState = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.lblServerEcho = new System.Windows.Forms.Label();
            this.lstServerEcho = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSimulationBG = new System.Windows.Forms.Panel();
            this.pnlSimulation = new System.Windows.Forms.Panel();
            this.picAppLogo = new System.Windows.Forms.PictureBox();
            this.lblMainHeading = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpFunctionality = new System.Windows.Forms.GroupBox();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.pnlControlsBG.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlSimulationBG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppLogo)).BeginInit();
            this.grpFunctionality.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControlsBG
            // 
            this.pnlControlsBG.Controls.Add(this.pnlControls);
            this.pnlControlsBG.Location = new System.Drawing.Point(849, 12);
            this.pnlControlsBG.Name = "pnlControlsBG";
            this.pnlControlsBG.Size = new System.Drawing.Size(285, 700);
            this.pnlControlsBG.TabIndex = 0;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.grpFunctionality);
            this.pnlControls.Controls.Add(this.btnConnect);
            this.pnlControls.Controls.Add(this.lblServerState);
            this.pnlControls.Controls.Add(this.lblServerStatus);
            this.pnlControls.Controls.Add(this.lblServerEcho);
            this.pnlControls.Controls.Add(this.lstServerEcho);
            this.pnlControls.Controls.Add(this.pictureBox1);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Location = new System.Drawing.Point(3, 3);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(279, 694);
            this.pnlControls.TabIndex = 1;
            // 
            // lblServerState
            // 
            this.lblServerState.AutoSize = true;
            this.lblServerState.Font = new System.Drawing.Font("DINPro-Regular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerState.Location = new System.Drawing.Point(138, 661);
            this.lblServerState.Name = "lblServerState";
            this.lblServerState.Size = new System.Drawing.Size(121, 24);
            this.lblServerState.TabIndex = 10;
            this.lblServerState.Text = "current-state";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Font = new System.Drawing.Font("DINPro-Regular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.Location = new System.Drawing.Point(3, 661);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(129, 24);
            this.lblServerStatus.TabIndex = 9;
            this.lblServerStatus.Text = "Server Status:";
            // 
            // lblServerEcho
            // 
            this.lblServerEcho.AutoSize = true;
            this.lblServerEcho.Font = new System.Drawing.Font("DINPro-Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerEcho.Location = new System.Drawing.Point(3, 494);
            this.lblServerEcho.Name = "lblServerEcho";
            this.lblServerEcho.Size = new System.Drawing.Size(149, 27);
            this.lblServerEcho.TabIndex = 8;
            this.lblServerEcho.Text = "Server Activity:";
            // 
            // lstServerEcho
            // 
            this.lstServerEcho.Font = new System.Drawing.Font("DINPro-Regular", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstServerEcho.FormattingEnabled = true;
            this.lstServerEcho.ItemHeight = 17;
            this.lstServerEcho.Location = new System.Drawing.Point(3, 524);
            this.lstServerEcho.Name = "lstServerEcho";
            this.lstServerEcho.Size = new System.Drawing.Size(273, 123);
            this.lstServerEcho.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("DINPro-Regular", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "User Controls";
            // 
            // pnlSimulationBG
            // 
            this.pnlSimulationBG.Controls.Add(this.pnlSimulation);
            this.pnlSimulationBG.Location = new System.Drawing.Point(12, 99);
            this.pnlSimulationBG.Name = "pnlSimulationBG";
            this.pnlSimulationBG.Size = new System.Drawing.Size(831, 613);
            this.pnlSimulationBG.TabIndex = 1;
            // 
            // pnlSimulation
            // 
            this.pnlSimulation.Location = new System.Drawing.Point(3, 3);
            this.pnlSimulation.Name = "pnlSimulation";
            this.pnlSimulation.Size = new System.Drawing.Size(825, 607);
            this.pnlSimulation.TabIndex = 2;
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
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("DINPro-Regular", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(12, 715);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(340, 17);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "©2018 James Hunt and Kyle Rusby Some Rights Reserved";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("DINPro-Regular", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(1049, 715);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(85, 17);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Version: 1.0.0";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("DINPro-Regular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(3, 84);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(273, 52);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpFunctionality
            // 
            this.grpFunctionality.Controls.Add(this.btnAddCar);
            this.grpFunctionality.Location = new System.Drawing.Point(4, 142);
            this.grpFunctionality.Name = "grpFunctionality";
            this.grpFunctionality.Size = new System.Drawing.Size(272, 349);
            this.grpFunctionality.TabIndex = 11;
            this.grpFunctionality.TabStop = false;
            // 
            // btnAddCar
            // 
            this.btnAddCar.Font = new System.Drawing.Font("DINPro-Regular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCar.Location = new System.Drawing.Point(6, 45);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(260, 52);
            this.btnAddCar.TabIndex = 12;
            this.btnAddCar.Text = "Add New Car";
            this.btnAddCar.UseVisualStyleBackColor = true;
            this.btnAddCar.Click += new System.EventHandler(this.btnAddCar_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 738);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblMainHeading);
            this.Controls.Add(this.picAppLogo);
            this.Controls.Add(this.pnlSimulationBG);
            this.Controls.Add(this.pnlControlsBG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Traffic Light Simulation - Client Application";
            this.pnlControlsBG.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlSimulationBG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAppLogo)).EndInit();
            this.grpFunctionality.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControlsBG;
        private System.Windows.Forms.Panel pnlSimulationBG;
        private System.Windows.Forms.PictureBox picAppLogo;
        private System.Windows.Forms.Label lblMainHeading;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Panel pnlSimulation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lstServerEcho;
        private System.Windows.Forms.Label lblServerEcho;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblServerState;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpFunctionality;
        private System.Windows.Forms.Button btnAddCar;
    }
}

