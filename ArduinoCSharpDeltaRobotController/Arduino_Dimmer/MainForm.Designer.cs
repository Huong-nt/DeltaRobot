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
            this.btDisconnect = new System.Windows.Forms.Button();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.step2 = new System.Windows.Forms.NumericUpDown();
            this.step1 = new System.Windows.Forms.NumericUpDown();
            this.step0 = new System.Windows.Forms.NumericUpDown();
            this.dir2 = new System.Windows.Forms.CheckBox();
            this.dir1 = new System.Windows.Forms.CheckBox();
            this.dir0 = new System.Windows.Forms.CheckBox();
            this.grpDest = new System.Windows.Forms.GroupBox();
            this.btnGoto = new System.Windows.Forms.Button();
            this.numZ = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnStabityTest1 = new System.Windows.Forms.Button();
            this.btnStabityTest2 = new System.Windows.Forms.Button();
            this.btnTestKinematics = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.step2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.step1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.step0)).BeginInit();
            this.grpDest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // btDisconnect
            // 
            this.btDisconnect.Enabled = false;
            this.btDisconnect.Location = new System.Drawing.Point(300, 10);
            this.btDisconnect.Name = "btDisconnect";
            this.btDisconnect.Size = new System.Drawing.Size(119, 23);
            this.btDisconnect.TabIndex = 4;
            this.btDisconnect.Text = "Disconnect";
            this.btDisconnect.UseVisualStyleBackColor = true;
            this.btDisconnect.Click += new System.EventHandler(this.btDisconnect_Click);
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(114, 11);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(118, 23);
            this.btnTest1.TabIndex = 9;
            this.btnTest1.Text = "Test 1";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // lbCopyright
            // 
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Location = new System.Drawing.Point(333, 382);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(85, 13);
            this.lbCopyright.TabIndex = 7;
            this.lbCopyright.Text = "(c) Arduino 2015";
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(12, 235);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(118, 23);
            this.btnCalibrate.TabIndex = 10;
            this.btnCalibrate.Text = "Calibrate";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(264, 11);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(118, 23);
            this.btnTest2.TabIndex = 11;
            this.btnTest2.Text = "Test 2";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Controls.Add(this.step2);
            this.groupBox1.Controls.Add(this.step1);
            this.groupBox1.Controls.Add(this.step0);
            this.groupBox1.Controls.Add(this.dir2);
            this.groupBox1.Controls.Add(this.dir1);
            this.groupBox1.Controls.Add(this.dir0);
            this.groupBox1.Location = new System.Drawing.Point(15, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Point";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Stepper 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Stepper 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Stepper 0";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(335, 58);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(38, 23);
            this.btnGo.TabIndex = 12;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // step2
            // 
            this.step2.Location = new System.Drawing.Point(230, 61);
            this.step2.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.step2.Name = "step2";
            this.step2.Size = new System.Drawing.Size(51, 20);
            this.step2.TabIndex = 5;
            // 
            // step1
            // 
            this.step1.Location = new System.Drawing.Point(127, 61);
            this.step1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.step1.Name = "step1";
            this.step1.Size = new System.Drawing.Size(51, 20);
            this.step1.TabIndex = 4;
            // 
            // step0
            // 
            this.step0.Location = new System.Drawing.Point(7, 61);
            this.step0.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.step0.Name = "step0";
            this.step0.Size = new System.Drawing.Size(51, 20);
            this.step0.TabIndex = 3;
            // 
            // dir2
            // 
            this.dir2.AutoSize = true;
            this.dir2.Location = new System.Drawing.Point(230, 41);
            this.dir2.Name = "dir2";
            this.dir2.Size = new System.Drawing.Size(15, 14);
            this.dir2.TabIndex = 2;
            this.dir2.UseVisualStyleBackColor = true;
            // 
            // dir1
            // 
            this.dir1.AutoSize = true;
            this.dir1.Location = new System.Drawing.Point(127, 41);
            this.dir1.Name = "dir1";
            this.dir1.Size = new System.Drawing.Size(15, 14);
            this.dir1.TabIndex = 1;
            this.dir1.UseVisualStyleBackColor = true;
            // 
            // dir0
            // 
            this.dir0.AutoSize = true;
            this.dir0.Location = new System.Drawing.Point(7, 41);
            this.dir0.Name = "dir0";
            this.dir0.Size = new System.Drawing.Size(15, 14);
            this.dir0.TabIndex = 0;
            this.dir0.UseVisualStyleBackColor = true;
            // 
            // grpDest
            // 
            this.grpDest.Controls.Add(this.btnGoto);
            this.grpDest.Controls.Add(this.numZ);
            this.grpDest.Controls.Add(this.numY);
            this.grpDest.Controls.Add(this.numX);
            this.grpDest.Location = new System.Drawing.Point(15, 63);
            this.grpDest.Name = "grpDest";
            this.grpDest.Size = new System.Drawing.Size(403, 60);
            this.grpDest.TabIndex = 13;
            this.grpDest.TabStop = false;
            this.grpDest.Text = "Destination(x, y, z)  z from -121 to -273 mm";
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(307, 17);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(75, 23);
            this.btnGoto.TabIndex = 3;
            this.btnGoto.Text = "Go to";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // numZ
            // 
            this.numZ.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numZ.Location = new System.Drawing.Point(217, 20);
            this.numZ.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numZ.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.numZ.Name = "numZ";
            this.numZ.Size = new System.Drawing.Size(64, 20);
            this.numZ.TabIndex = 2;
            // 
            // numY
            // 
            this.numY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numY.Location = new System.Drawing.Point(114, 20);
            this.numY.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(64, 20);
            this.numY.TabIndex = 1;
            // 
            // numX
            // 
            this.numX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numX.Location = new System.Drawing.Point(10, 20);
            this.numX.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(64, 20);
            this.numX.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTest1);
            this.groupBox2.Controls.Add(this.btnTest2);
            this.groupBox2.Location = new System.Drawing.Point(15, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 40);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accuracy test";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnStabityTest1);
            this.groupBox3.Controls.Add(this.btnStabityTest2);
            this.groupBox3.Location = new System.Drawing.Point(14, 327);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(404, 40);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stability test";
            // 
            // btnStabityTest1
            // 
            this.btnStabityTest1.Location = new System.Drawing.Point(114, 11);
            this.btnStabityTest1.Name = "btnStabityTest1";
            this.btnStabityTest1.Size = new System.Drawing.Size(118, 23);
            this.btnStabityTest1.TabIndex = 9;
            this.btnStabityTest1.Text = "Test 1";
            this.btnStabityTest1.UseVisualStyleBackColor = true;
            this.btnStabityTest1.Click += new System.EventHandler(this.btnStabityTest1_Click);
            // 
            // btnStabityTest2
            // 
            this.btnStabityTest2.Location = new System.Drawing.Point(264, 11);
            this.btnStabityTest2.Name = "btnStabityTest2";
            this.btnStabityTest2.Size = new System.Drawing.Size(118, 23);
            this.btnStabityTest2.TabIndex = 11;
            this.btnStabityTest2.Text = "Test 2";
            this.btnStabityTest2.UseVisualStyleBackColor = true;
            // 
            // btnTestKinematics
            // 
            this.btnTestKinematics.Location = new System.Drawing.Point(211, 235);
            this.btnTestKinematics.Name = "btnTestKinematics";
            this.btnTestKinematics.Size = new System.Drawing.Size(118, 23);
            this.btnTestKinematics.TabIndex = 16;
            this.btnTestKinematics.Text = "Test Kinematics";
            this.btnTestKinematics.UseVisualStyleBackColor = true;
            this.btnTestKinematics.Click += new System.EventHandler(this.btnTestKinematics_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 396);
            this.Controls.Add(this.btnTestKinematics);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpDest);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCalibrate);
            this.Controls.Add(this.lbCopyright);
            this.Controls.Add(this.btDisconnect);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.cbAvailablePorts);
            this.Name = "MainForm";
            this.Text = "Delta Robot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.step2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.step1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.step0)).EndInit();
            this.grpDest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAvailablePorts;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btDisconnect;
        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Button btnTest2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.NumericUpDown step2;
        private System.Windows.Forms.NumericUpDown step1;
        private System.Windows.Forms.NumericUpDown step0;
        private System.Windows.Forms.CheckBox dir2;
        private System.Windows.Forms.CheckBox dir1;
        private System.Windows.Forms.CheckBox dir0;
        private System.Windows.Forms.GroupBox grpDest;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.NumericUpDown numZ;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStabityTest1;
        private System.Windows.Forms.Button btnStabityTest2;
        private System.Windows.Forms.Button btnTestKinematics;

    }
}

