namespace Arduino_Dimmer
{
    partial class MainForm
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
            this.cbAvailablePorts = new System.Windows.Forms.ComboBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tbBrightness = new System.Windows.Forms.TrackBar();
            this.btDisconnect = new System.Windows.Forms.Button();
            this.lbBrightness = new System.Windows.Forms.Label();
            this.btnTestStepper = new System.Windows.Forms.Button();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.btnCalibrate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAvailablePorts
            // 
            this.cbAvailablePorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAvailablePorts.FormattingEnabled = true;
            this.cbAvailablePorts.Location = new System.Drawing.Point(12, 12);
            this.cbAvailablePorts.Name = "cbAvailablePorts";
            this.cbAvailablePorts.Size = new System.Drawing.Size(121, 21);
            this.cbAvailablePorts.TabIndex = 0;
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(153, 10);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(119, 23);
            this.btConnect.TabIndex = 1;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(12, 46);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(109, 13);
            this.lbStatus.TabIndex = 2;
            this.lbStatus.Text = "Status: Disconnected";
            // 
            // tbBrightness
            // 
            this.tbBrightness.Enabled = false;
            this.tbBrightness.LargeChange = 20;
            this.tbBrightness.Location = new System.Drawing.Point(15, 90);
            this.tbBrightness.Maximum = 255;
            this.tbBrightness.Name = "tbBrightness";
            this.tbBrightness.Size = new System.Drawing.Size(397, 45);
            this.tbBrightness.SmallChange = 2;
            this.tbBrightness.TabIndex = 3;
            this.tbBrightness.ValueChanged += new System.EventHandler(this.tbBrightness_ValueChanged);
            // 
            // btDisconnect
            // 
            this.btDisconnect.Enabled = false;
            this.btDisconnect.Location = new System.Drawing.Point(293, 10);
            this.btDisconnect.Name = "btDisconnect";
            this.btDisconnect.Size = new System.Drawing.Size(119, 23);
            this.btDisconnect.TabIndex = 4;
            this.btDisconnect.Text = "Disconnect";
            this.btDisconnect.UseVisualStyleBackColor = true;
            this.btDisconnect.Click += new System.EventHandler(this.btDisconnect_Click);
            // 
            // lbBrightness
            // 
            this.lbBrightness.AutoSize = true;
            this.lbBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBrightness.Location = new System.Drawing.Point(12, 74);
            this.lbBrightness.Name = "lbBrightness";
            this.lbBrightness.Size = new System.Drawing.Size(68, 15);
            this.lbBrightness.TabIndex = 8;
            this.lbBrightness.Text = "Brightness:";
            // 
            // btnTestStepper
            // 
            this.btnTestStepper.Location = new System.Drawing.Point(15, 182);
            this.btnTestStepper.Name = "btnTestStepper";
            this.btnTestStepper.Size = new System.Drawing.Size(118, 23);
            this.btnTestStepper.TabIndex = 9;
            this.btnTestStepper.Text = "Test Stepper";
            this.btnTestStepper.UseVisualStyleBackColor = true;
            this.btnTestStepper.Click += new System.EventHandler(this.btnTestStepper_Click);
            // 
            // lbCopyright
            // 
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Location = new System.Drawing.Point(290, 213);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(85, 13);
            this.lbCopyright.TabIndex = 7;
            this.lbCopyright.Text = "(c) Arduino 2015";
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(191, 182);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(118, 23);
            this.btnCalibrate.TabIndex = 10;
            this.btnCalibrate.Text = "Calibrate";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 235);
            this.Controls.Add(this.btnCalibrate);
            this.Controls.Add(this.btnTestStepper);
            this.Controls.Add(this.lbBrightness);
            this.Controls.Add(this.lbCopyright);
            this.Controls.Add(this.btDisconnect);
            this.Controls.Add(this.tbBrightness);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.cbAvailablePorts);
            this.Name = "MainForm";
            this.Text = "Delta Robot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAvailablePorts;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.TrackBar tbBrightness;
        private System.Windows.Forms.Button btDisconnect;
        private System.Windows.Forms.Label lbBrightness;
        private System.Windows.Forms.Button btnTestStepper;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Button btnCalibrate;

    }
}

