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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlControlsBG = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.pbarConnecting = new System.Windows.Forms.ProgressBar();
            this.grpFunctionality = new System.Windows.Forms.GroupBox();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
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
            this.radAutoConnect = new System.Windows.Forms.CheckBox();
            this.tmrConnecting = new System.Windows.Forms.Timer(this.components);
            this.pnlControlsBG.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.grpFunctionality.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlSimulationBG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControlsBG
            // 
            this.pnlControlsBG.Controls.Add(this.pnlControls);
            this.pnlControlsBG.Location = new System.Drawing.Point(1132, 15);
            this.pnlControlsBG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlControlsBG.Name = "pnlControlsBG";
            this.pnlControlsBG.Size = new System.Drawing.Size(380, 862);
            this.pnlControlsBG.TabIndex = 0;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.pbarConnecting);
            this.pnlControls.Controls.Add(this.grpFunctionality);
            this.pnlControls.Controls.Add(this.btnConnect);
            this.pnlControls.Controls.Add(this.lblServerState);
            this.pnlControls.Controls.Add(this.lblServerStatus);
            this.pnlControls.Controls.Add(this.lblServerEcho);
            this.pnlControls.Controls.Add(this.lstServerEcho);
            this.pnlControls.Controls.Add(this.pictureBox1);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Location = new System.Drawing.Point(4, 4);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(372, 854);
            this.pnlControls.TabIndex = 1;
            // 
            // pbarConnecting
            // 
            this.pbarConnecting.Location = new System.Drawing.Point(4, 176);
            this.pbarConnecting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbarConnecting.Name = "pbarConnecting";
            this.pbarConnecting.Size = new System.Drawing.Size(364, 12);
            this.pbarConnecting.TabIndex = 14;
            // 
            // grpFunctionality
            // 
            this.grpFunctionality.Controls.Add(this.btnAddCar);
            this.grpFunctionality.Location = new System.Drawing.Point(5, 196);
            this.grpFunctionality.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFunctionality.Name = "grpFunctionality";
            this.grpFunctionality.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFunctionality.Size = new System.Drawing.Size(363, 409);
            this.grpFunctionality.TabIndex = 11;
            this.grpFunctionality.TabStop = false;
            // 
            // btnAddCar
            // 
            this.btnAddCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCar.Location = new System.Drawing.Point(8, 23);
            this.btnAddCar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(347, 64);
            this.btnAddCar.TabIndex = 12;
            this.btnAddCar.Text = "Add New Car";
            this.btnAddCar.UseVisualStyleBackColor = true;
            this.btnAddCar.Click += new System.EventHandler(this.btnAddCar_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(4, 103);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(364, 64);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblServerState
            // 
            this.lblServerState.AutoSize = true;
            this.lblServerState.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerState.Location = new System.Drawing.Point(184, 814);
            this.lblServerState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerState.Name = "lblServerState";
            this.lblServerState.Size = new System.Drawing.Size(146, 29);
            this.lblServerState.TabIndex = 10;
            this.lblServerState.Text = "current-state";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.Location = new System.Drawing.Point(4, 814);
            this.lblServerStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(162, 29);
            this.lblServerStatus.TabIndex = 9;
            this.lblServerStatus.Text = "Server Status:";
            // 
            // lblServerEcho
            // 
            this.lblServerEcho.AutoSize = true;
            this.lblServerEcho.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerEcho.Location = new System.Drawing.Point(4, 608);
            this.lblServerEcho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerEcho.Name = "lblServerEcho";
            this.lblServerEcho.Size = new System.Drawing.Size(291, 31);
            this.lblServerEcho.TabIndex = 8;
            this.lblServerEcho.Text = "Recent Server Activity:";
            // 
            // lstServerEcho
            // 
            this.lstServerEcho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstServerEcho.FormattingEnabled = true;
            this.lstServerEcho.ItemHeight = 20;
            this.lstServerEcho.Location = new System.Drawing.Point(4, 645);
            this.lstServerEcho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstServerEcho.Name = "lstServerEcho";
            this.lstServerEcho.Size = new System.Drawing.Size(363, 144);
            this.lstServerEcho.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(37, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "User Controls";
            // 
            // pnlSimulationBG
            // 
            this.pnlSimulationBG.Controls.Add(this.pnlSimulation);
            this.pnlSimulationBG.Location = new System.Drawing.Point(16, 122);
            this.pnlSimulationBG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSimulationBG.Name = "pnlSimulationBG";
            this.pnlSimulationBG.Size = new System.Drawing.Size(1108, 754);
            this.pnlSimulationBG.TabIndex = 1;
            // 
            // pnlSimulation
            // 
            this.pnlSimulation.Location = new System.Drawing.Point(4, 4);
            this.pnlSimulation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSimulation.Name = "pnlSimulation";
            this.pnlSimulation.Size = new System.Drawing.Size(1100, 747);
            this.pnlSimulation.TabIndex = 2;
            // 
            // picAppLogo
            // 
            this.picAppLogo.Image = ((System.Drawing.Image)(resources.GetObject("picAppLogo.Image")));
            this.picAppLogo.Location = new System.Drawing.Point(16, 15);
            this.picAppLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picAppLogo.Name = "picAppLogo";
            this.picAppLogo.Size = new System.Drawing.Size(117, 100);
            this.picAppLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAppLogo.TabIndex = 2;
            this.picAppLogo.TabStop = false;
            // 
            // lblMainHeading
            // 
            this.lblMainHeading.AutoSize = true;
            this.lblMainHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainHeading.Location = new System.Drawing.Point(141, 38);
            this.lblMainHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainHeading.Name = "lblMainHeading";
            this.lblMainHeading.Size = new System.Drawing.Size(363, 39);
            this.lblMainHeading.TabIndex = 3;
            this.lblMainHeading.Text = "Traffic Light Simulation";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(16, 880);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(451, 20);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "©2018 James Hunt and Kyle Rusby Some Rights Reserved";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(1399, 880);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(111, 20);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Version: 1.0.0";
            // 
            // radAutoConnect
            // 
            this.radAutoConnect.AutoSize = true;
            this.radAutoConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAutoConnect.Location = new System.Drawing.Point(881, 85);
            this.radAutoConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radAutoConnect.Name = "radAutoConnect";
            this.radAutoConnect.Size = new System.Drawing.Size(229, 29);
            this.radAutoConnect.TabIndex = 13;
            this.radAutoConnect.Text = "Connect Automatically";
            this.radAutoConnect.UseVisualStyleBackColor = true;
            this.radAutoConnect.CheckedChanged += new System.EventHandler(this.radAutoConnect_CheckedChanged);
            // 
            // tmrConnecting
            // 
            this.tmrConnecting.Tick += new System.EventHandler(this.tmrConnecting_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 908);
            this.Controls.Add(this.radAutoConnect);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblMainHeading);
            this.Controls.Add(this.picAppLogo);
            this.Controls.Add(this.pnlSimulationBG);
            this.Controls.Add(this.pnlControlsBG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Traffic Light Simulation - Client Application";
            this.pnlControlsBG.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.grpFunctionality.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlSimulationBG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAppLogo)).EndInit();
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
        private System.Windows.Forms.CheckBox radAutoConnect;
        private System.Windows.Forms.ProgressBar pbarConnecting;
        private System.Windows.Forms.Timer tmrConnecting;
    }
}

