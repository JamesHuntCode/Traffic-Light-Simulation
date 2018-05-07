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
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblServerState = new System.Windows.Forms.Label();
            this.grpFunctionality = new System.Windows.Forms.GroupBox();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.grpCarColors = new System.Windows.Forms.GroupBox();
            this.radPurple = new System.Windows.Forms.RadioButton();
            this.radPink = new System.Windows.Forms.RadioButton();
            this.radOrange = new System.Windows.Forms.RadioButton();
            this.radCyan = new System.Windows.Forms.RadioButton();
            this.radGray = new System.Windows.Forms.RadioButton();
            this.radBlack = new System.Windows.Forms.RadioButton();
            this.radYellow = new System.Windows.Forms.RadioButton();
            this.radBlue = new System.Windows.Forms.RadioButton();
            this.radGreen = new System.Windows.Forms.RadioButton();
            this.radRed = new System.Windows.Forms.RadioButton();
            this.lblColorPref = new System.Windows.Forms.Label();
            this.lblAddCar = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radAutoConnect = new System.Windows.Forms.CheckBox();
            this.lstServerEcho = new System.Windows.Forms.ListBox();
            this.picAppLogo = new System.Windows.Forms.PictureBox();
            this.lblMainHeading = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlSimulationBG = new System.Windows.Forms.Panel();
            this.grpNotConnected = new System.Windows.Forms.GroupBox();
            this.lblNoConnection = new System.Windows.Forms.Label();
            this.picNoConnection = new System.Windows.Forms.PictureBox();
            this.trafficPanel = new TrafficLightPanel.TrafficPanel();
            this.pnlControlsBG.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.grpFunctionality.SuspendLayout();
            this.grpCarColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAppLogo)).BeginInit();
            this.pnlSimulationBG.SuspendLayout();
            this.grpNotConnected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNoConnection)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControlsBG
            // 
            this.pnlControlsBG.Controls.Add(this.pnlControls);
            this.pnlControlsBG.Location = new System.Drawing.Point(533, 13);
            this.pnlControlsBG.Margin = new System.Windows.Forms.Padding(4);
            this.pnlControlsBG.Name = "pnlControlsBG";
            this.pnlControlsBG.Size = new System.Drawing.Size(380, 618);
            this.pnlControlsBG.TabIndex = 0;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnConnect);
            this.pnlControls.Controls.Add(this.lblServerState);
            this.pnlControls.Controls.Add(this.grpFunctionality);
            this.pnlControls.Controls.Add(this.lblServerStatus);
            this.pnlControls.Controls.Add(this.pictureBox1);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Location = new System.Drawing.Point(4, 4);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(4);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(372, 608);
            this.pnlControls.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(4, 105);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(364, 61);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect To Server";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblServerState
            // 
            this.lblServerState.AutoSize = true;
            this.lblServerState.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerState.Location = new System.Drawing.Point(212, 574);
            this.lblServerState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerState.Name = "lblServerState";
            this.lblServerState.Size = new System.Drawing.Size(113, 24);
            this.lblServerState.TabIndex = 10;
            this.lblServerState.Text = "current-state";
            // 
            // grpFunctionality
            // 
            this.grpFunctionality.Controls.Add(this.btnAddCar);
            this.grpFunctionality.Controls.Add(this.grpCarColors);
            this.grpFunctionality.Controls.Add(this.lblColorPref);
            this.grpFunctionality.Controls.Add(this.lblAddCar);
            this.grpFunctionality.Location = new System.Drawing.Point(4, 174);
            this.grpFunctionality.Margin = new System.Windows.Forms.Padding(4);
            this.grpFunctionality.Name = "grpFunctionality";
            this.grpFunctionality.Padding = new System.Windows.Forms.Padding(4);
            this.grpFunctionality.Size = new System.Drawing.Size(364, 385);
            this.grpFunctionality.TabIndex = 11;
            this.grpFunctionality.TabStop = false;
            // 
            // btnAddCar
            // 
            this.btnAddCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCar.Location = new System.Drawing.Point(8, 313);
            this.btnAddCar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(346, 64);
            this.btnAddCar.TabIndex = 12;
            this.btnAddCar.Text = "Add New Car";
            this.btnAddCar.UseVisualStyleBackColor = true;
            this.btnAddCar.Click += new System.EventHandler(this.btnAddCar_Click);
            // 
            // grpCarColors
            // 
            this.grpCarColors.Controls.Add(this.radPurple);
            this.grpCarColors.Controls.Add(this.radPink);
            this.grpCarColors.Controls.Add(this.radOrange);
            this.grpCarColors.Controls.Add(this.radCyan);
            this.grpCarColors.Controls.Add(this.radGray);
            this.grpCarColors.Controls.Add(this.radBlack);
            this.grpCarColors.Controls.Add(this.radYellow);
            this.grpCarColors.Controls.Add(this.radBlue);
            this.grpCarColors.Controls.Add(this.radGreen);
            this.grpCarColors.Controls.Add(this.radRed);
            this.grpCarColors.Location = new System.Drawing.Point(8, 102);
            this.grpCarColors.Margin = new System.Windows.Forms.Padding(4);
            this.grpCarColors.Name = "grpCarColors";
            this.grpCarColors.Padding = new System.Windows.Forms.Padding(4);
            this.grpCarColors.Size = new System.Drawing.Size(347, 203);
            this.grpCarColors.TabIndex = 16;
            this.grpCarColors.TabStop = false;
            // 
            // radPurple
            // 
            this.radPurple.AutoSize = true;
            this.radPurple.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPurple.Location = new System.Drawing.Point(238, 172);
            this.radPurple.Margin = new System.Windows.Forms.Padding(4);
            this.radPurple.Name = "radPurple";
            this.radPurple.Size = new System.Drawing.Size(72, 24);
            this.radPurple.TabIndex = 9;
            this.radPurple.TabStop = true;
            this.radPurple.Text = "Purple";
            this.radPurple.UseVisualStyleBackColor = true;
            // 
            // radPink
            // 
            this.radPink.AutoSize = true;
            this.radPink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPink.Location = new System.Drawing.Point(238, 135);
            this.radPink.Margin = new System.Windows.Forms.Padding(4);
            this.radPink.Name = "radPink";
            this.radPink.Size = new System.Drawing.Size(57, 24);
            this.radPink.TabIndex = 8;
            this.radPink.TabStop = true;
            this.radPink.Text = "Pink";
            this.radPink.UseVisualStyleBackColor = true;
            // 
            // radOrange
            // 
            this.radOrange.AutoSize = true;
            this.radOrange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOrange.Location = new System.Drawing.Point(239, 98);
            this.radOrange.Margin = new System.Windows.Forms.Padding(4);
            this.radOrange.Name = "radOrange";
            this.radOrange.Size = new System.Drawing.Size(80, 24);
            this.radOrange.TabIndex = 7;
            this.radOrange.TabStop = true;
            this.radOrange.Text = "Orange";
            this.radOrange.UseVisualStyleBackColor = true;
            // 
            // radCyan
            // 
            this.radCyan.AutoSize = true;
            this.radCyan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCyan.Location = new System.Drawing.Point(238, 62);
            this.radCyan.Margin = new System.Windows.Forms.Padding(4);
            this.radCyan.Name = "radCyan";
            this.radCyan.Size = new System.Drawing.Size(63, 24);
            this.radCyan.TabIndex = 6;
            this.radCyan.TabStop = true;
            this.radCyan.Text = "Cyan";
            this.radCyan.UseVisualStyleBackColor = true;
            // 
            // radGray
            // 
            this.radGray.AutoSize = true;
            this.radGray.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGray.Location = new System.Drawing.Point(239, 25);
            this.radGray.Margin = new System.Windows.Forms.Padding(4);
            this.radGray.Name = "radGray";
            this.radGray.Size = new System.Drawing.Size(61, 24);
            this.radGray.TabIndex = 5;
            this.radGray.TabStop = true;
            this.radGray.Text = "Gray";
            this.radGray.UseVisualStyleBackColor = true;
            // 
            // radBlack
            // 
            this.radBlack.AutoSize = true;
            this.radBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBlack.Location = new System.Drawing.Point(8, 172);
            this.radBlack.Margin = new System.Windows.Forms.Padding(4);
            this.radBlack.Name = "radBlack";
            this.radBlack.Size = new System.Drawing.Size(66, 24);
            this.radBlack.TabIndex = 4;
            this.radBlack.TabStop = true;
            this.radBlack.Text = "Black";
            this.radBlack.UseVisualStyleBackColor = true;
            // 
            // radYellow
            // 
            this.radYellow.AutoSize = true;
            this.radYellow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radYellow.Location = new System.Drawing.Point(8, 135);
            this.radYellow.Margin = new System.Windows.Forms.Padding(4);
            this.radYellow.Name = "radYellow";
            this.radYellow.Size = new System.Drawing.Size(73, 24);
            this.radYellow.TabIndex = 3;
            this.radYellow.TabStop = true;
            this.radYellow.Text = "Yellow";
            this.radYellow.UseVisualStyleBackColor = true;
            // 
            // radBlue
            // 
            this.radBlue.AutoSize = true;
            this.radBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBlue.Location = new System.Drawing.Point(9, 98);
            this.radBlue.Margin = new System.Windows.Forms.Padding(4);
            this.radBlue.Name = "radBlue";
            this.radBlue.Size = new System.Drawing.Size(59, 24);
            this.radBlue.TabIndex = 2;
            this.radBlue.TabStop = true;
            this.radBlue.Text = "Blue";
            this.radBlue.UseVisualStyleBackColor = true;
            // 
            // radGreen
            // 
            this.radGreen.AutoSize = true;
            this.radGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGreen.Location = new System.Drawing.Point(8, 62);
            this.radGreen.Margin = new System.Windows.Forms.Padding(4);
            this.radGreen.Name = "radGreen";
            this.radGreen.Size = new System.Drawing.Size(72, 24);
            this.radGreen.TabIndex = 1;
            this.radGreen.TabStop = true;
            this.radGreen.Text = "Green";
            this.radGreen.UseVisualStyleBackColor = true;
            // 
            // radRed
            // 
            this.radRed.AutoSize = true;
            this.radRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRed.Location = new System.Drawing.Point(9, 25);
            this.radRed.Margin = new System.Windows.Forms.Padding(4);
            this.radRed.Name = "radRed";
            this.radRed.Size = new System.Drawing.Size(57, 24);
            this.radRed.TabIndex = 0;
            this.radRed.TabStop = true;
            this.radRed.Text = "Red";
            this.radRed.UseVisualStyleBackColor = true;
            // 
            // lblColorPref
            // 
            this.lblColorPref.AutoSize = true;
            this.lblColorPref.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorPref.Location = new System.Drawing.Point(102, 59);
            this.lblColorPref.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColorPref.Name = "lblColorPref";
            this.lblColorPref.Size = new System.Drawing.Size(145, 24);
            this.lblColorPref.TabIndex = 15;
            this.lblColorPref.Text = "Pick Car Colour:";
            // 
            // lblAddCar
            // 
            this.lblAddCar.AutoSize = true;
            this.lblAddCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddCar.Location = new System.Drawing.Point(89, 17);
            this.lblAddCar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddCar.Name = "lblAddCar";
            this.lblAddCar.Size = new System.Drawing.Size(175, 31);
            this.lblAddCar.TabIndex = 15;
            this.lblAddCar.Text = "Add New Car";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.Location = new System.Drawing.Point(8, 574);
            this.lblServerStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(125, 24);
            this.lblServerStatus.TabIndex = 9;
            this.lblServerStatus.Text = "Server Status:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(62, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "User Controls";
            // 
            // radAutoConnect
            // 
            this.radAutoConnect.AutoSize = true;
            this.radAutoConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAutoConnect.Location = new System.Drawing.Point(135, 62);
            this.radAutoConnect.Margin = new System.Windows.Forms.Padding(4);
            this.radAutoConnect.Name = "radAutoConnect";
            this.radAutoConnect.Size = new System.Drawing.Size(119, 24);
            this.radAutoConnect.TabIndex = 13;
            this.radAutoConnect.Text = "Autoconnect";
            this.radAutoConnect.UseVisualStyleBackColor = true;
            this.radAutoConnect.CheckedChanged += new System.EventHandler(this.radAutoConnect_CheckedChanged);
            // 
            // lstServerEcho
            // 
            this.lstServerEcho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstServerEcho.FormattingEnabled = true;
            this.lstServerEcho.ItemHeight = 20;
            this.lstServerEcho.Location = new System.Drawing.Point(16, 639);
            this.lstServerEcho.Margin = new System.Windows.Forms.Padding(4);
            this.lstServerEcho.Name = "lstServerEcho";
            this.lstServerEcho.Size = new System.Drawing.Size(897, 124);
            this.lstServerEcho.TabIndex = 7;
            // 
            // picAppLogo
            // 
            this.picAppLogo.Image = ((System.Drawing.Image)(resources.GetObject("picAppLogo.Image")));
            this.picAppLogo.Location = new System.Drawing.Point(16, 14);
            this.picAppLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picAppLogo.Name = "picAppLogo";
            this.picAppLogo.Size = new System.Drawing.Size(105, 100);
            this.picAppLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAppLogo.TabIndex = 2;
            this.picAppLogo.TabStop = false;
            // 
            // lblMainHeading
            // 
            this.lblMainHeading.AutoSize = true;
            this.lblMainHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainHeading.Location = new System.Drawing.Point(129, 27);
            this.lblMainHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainHeading.Name = "lblMainHeading";
            this.lblMainHeading.Size = new System.Drawing.Size(290, 31);
            this.lblMainHeading.TabIndex = 3;
            this.lblMainHeading.Text = "Traffic Light Simulation";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(13, 772);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(358, 16);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "©2018 James Hunt and Kyle Rusby Some Rights Reserved";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(802, 772);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(87, 16);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Version: 1.1.2";
            // 
            // pnlSimulationBG
            // 
            this.pnlSimulationBG.Controls.Add(this.grpNotConnected);
            this.pnlSimulationBG.Controls.Add(this.trafficPanel);
            this.pnlSimulationBG.Location = new System.Drawing.Point(16, 122);
            this.pnlSimulationBG.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSimulationBG.Name = "pnlSimulationBG";
            this.pnlSimulationBG.Size = new System.Drawing.Size(509, 509);
            this.pnlSimulationBG.TabIndex = 1;
            // 
            // grpNotConnected
            // 
            this.grpNotConnected.Controls.Add(this.lblNoConnection);
            this.grpNotConnected.Controls.Add(this.picNoConnection);
            this.grpNotConnected.Location = new System.Drawing.Point(3, 3);
            this.grpNotConnected.Name = "grpNotConnected";
            this.grpNotConnected.Size = new System.Drawing.Size(503, 503);
            this.grpNotConnected.TabIndex = 0;
            this.grpNotConnected.TabStop = false;
            // 
            // lblNoConnection
            // 
            this.lblNoConnection.AutoSize = true;
            this.lblNoConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoConnection.Location = new System.Drawing.Point(38, 358);
            this.lblNoConnection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoConnection.Name = "lblNoConnection";
            this.lblNoConnection.Size = new System.Drawing.Size(417, 31);
            this.lblNoConnection.TabIndex = 14;
            this.lblNoConnection.Text = "Looks Like You\'re Not Connected";
            // 
            // picNoConnection
            // 
            this.picNoConnection.Image = ((System.Drawing.Image)(resources.GetObject("picNoConnection.Image")));
            this.picNoConnection.Location = new System.Drawing.Point(116, 141);
            this.picNoConnection.Name = "picNoConnection";
            this.picNoConnection.Size = new System.Drawing.Size(240, 214);
            this.picNoConnection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNoConnection.TabIndex = 0;
            this.picNoConnection.TabStop = false;
            // 
            // trafficPanel
            // 
            this.trafficPanel.Location = new System.Drawing.Point(4, 3);
            this.trafficPanel.Name = "trafficPanel";
            this.trafficPanel.Size = new System.Drawing.Size(500, 500);
            this.trafficPanel.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(928, 801);
            this.Controls.Add(this.radAutoConnect);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblMainHeading);
            this.Controls.Add(this.lstServerEcho);
            this.Controls.Add(this.picAppLogo);
            this.Controls.Add(this.pnlSimulationBG);
            this.Controls.Add(this.pnlControlsBG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Traffic Light Simulation - Client Application";
            this.pnlControlsBG.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.grpFunctionality.ResumeLayout(false);
            this.grpFunctionality.PerformLayout();
            this.grpCarColors.ResumeLayout(false);
            this.grpCarColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAppLogo)).EndInit();
            this.pnlSimulationBG.ResumeLayout(false);
            this.grpNotConnected.ResumeLayout(false);
            this.grpNotConnected.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNoConnection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControlsBG;
        private System.Windows.Forms.PictureBox picAppLogo;
        private System.Windows.Forms.Label lblMainHeading;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lstServerEcho;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblServerState;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpFunctionality;
        private System.Windows.Forms.Button btnAddCar;
        private System.Windows.Forms.CheckBox radAutoConnect;
        private System.Windows.Forms.Label lblColorPref;
        private System.Windows.Forms.Label lblAddCar;
        private System.Windows.Forms.GroupBox grpCarColors;
        private System.Windows.Forms.RadioButton radPurple;
        private System.Windows.Forms.RadioButton radPink;
        private System.Windows.Forms.RadioButton radOrange;
        private System.Windows.Forms.RadioButton radCyan;
        private System.Windows.Forms.RadioButton radGray;
        private System.Windows.Forms.RadioButton radBlack;
        private System.Windows.Forms.RadioButton radYellow;
        private System.Windows.Forms.RadioButton radBlue;
        private System.Windows.Forms.RadioButton radGreen;
        private System.Windows.Forms.RadioButton radRed;
        private System.Windows.Forms.Panel pnlSimulationBG;
        private TrafficLightPanel.TrafficPanel trafficPanel;
        private System.Windows.Forms.GroupBox grpNotConnected;
        private System.Windows.Forms.PictureBox picNoConnection;
        private System.Windows.Forms.Label lblNoConnection;
    }
}

