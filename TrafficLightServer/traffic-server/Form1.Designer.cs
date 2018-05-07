namespace traffic_server
{
    partial class Form1
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
            this.richLog = new System.Windows.Forms.RichTextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripOpenMap = new System.Windows.Forms.ToolStripButton();
            this.trafficPanel = new TrafficLightPanel.TrafficPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // richLog
            // 
            this.richLog.Location = new System.Drawing.Point(12, 80);
            this.richLog.Name = "richLog";
            this.richLog.ReadOnly = true;
            this.richLog.Size = new System.Drawing.Size(426, 458);
            this.richLog.TabIndex = 1;
            this.richLog.Text = "";
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(192, 39);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(71, 38);
            this.lblLog.TabIndex = 2;
            this.lblLog.Text = "Log";
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpenMap});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(956, 35);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripOpenMap
            // 
            this.toolStripOpenMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripOpenMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpenMap.Name = "toolStripOpenMap";
            this.toolStripOpenMap.Size = new System.Drawing.Size(108, 32);
            this.toolStripOpenMap.Text = "Open map";
            this.toolStripOpenMap.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // trafficPanel
            // 
            this.trafficPanel.Location = new System.Drawing.Point(444, 38);
            this.trafficPanel.Name = "trafficPanel";
            this.trafficPanel.Size = new System.Drawing.Size(500, 500);
            this.trafficPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add car";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(956, 550);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.richLog);
            this.Controls.Add(this.trafficPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Traffic Light Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripOpenMap;
        public TrafficLightPanel.TrafficPanel trafficPanel;
        private System.Windows.Forms.Button button1;
    }
}

