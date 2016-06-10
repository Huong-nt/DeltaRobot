using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using PhoneTestLib.RobotPackage;
namespace Arduino_Dimmer
{
    public partial class MainForm : Form
    {
        private enum ArduinoStatus
        {
            Connected,
            Connecting,
            Disconnected
        }

        //private SerialPort _arduinoPort;
        private ArduinoStatus _status;
        private ArduinoControllerMain _arduinoController;
        private float current_x = 0F;
        private float current_y = 0F;
        private float current_z = -270.0959F;
        private float current_theta0 = 0.0F;
        private float current_theta1 = 0.0F;
        private float current_theta2 = 0.0F;

        public MainForm()
        {
            InitializeComponent();
            while (true)
            {
                try
                {
                    cbAvailablePorts.Items.AddRange(SerialPort.GetPortNames());
                    cbAvailablePorts.SelectedIndex = 0;
                    _status = ArduinoStatus.Disconnected;
                    _arduinoController = new ArduinoControllerMain();
                    break;
                }
                catch (Exception e)
                {
                    DialogResult resultBox = MessageBox.Show("Device must be connected!",
                                "Warning",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Error);
                    if (resultBox == DialogResult.Cancel)
                    {
                        System.Environment.Exit(-1);
                    }
                }
            }

        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            _status = ArduinoStatus.Connecting;
            UpdateFormByStatus();
            if (_arduinoController.initPort(cbAvailablePorts.SelectedItem.ToString()))
            {
                _status = ArduinoStatus.Connected;
                UpdateFormByStatus();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_status == ArduinoStatus.Connected)
            {
                _arduinoController.closePort();
            }
        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                _arduinoController.closePort();
                _status = ArduinoStatus.Disconnected;
                UpdateFormByStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lbStatus.Text = "Status: Error";
            }
        }

        private void UpdateFormByStatus()
        {
            switch (_status)
            {
                case ArduinoStatus.Connected:
                    lbStatus.Text = "Status: Successfully connected";
                    btConnect.Enabled = false;
                    btDisconnect.Enabled = true;
                    break;

                case ArduinoStatus.Connecting:
                    lbStatus.Text = "Status: Connecting";
                    break;

                case ArduinoStatus.Disconnected:
                    lbStatus.Text = "Status: Disconnected";
                    btConnect.Enabled = true;
                    btDisconnect.Enabled = false;
                    break;
            }
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            btnCalibrate_Click(null, null);
            int bound = 20;
            gotoPoint(0, bound, -270);
            gotoPoint(0, 0, -270);  
            gotoPoint(0, -bound, -270);
            gotoPoint(0, 0, -270);
            gotoPoint(bound, 0, -270);
            gotoPoint(0, 0, -270);
            gotoPoint(-bound, 0, -270);
            gotoPoint(0, 0, -270);

            bound = 40;
            gotoPoint(0, bound, -270);
            gotoPoint(0, -bound, -270);
            gotoPoint(bound, 0, -270);
            gotoPoint(-bound, 0, -270);
            gotoPoint(0, 0, -270);
            bound = 80;
            gotoPoint(0, bound, -270);
            gotoPoint(0, -bound, -270);
            gotoPoint(bound, 0, -270);
            gotoPoint(-bound, 0, -270);
            gotoPoint(0, 0, -270);
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {
            int z = -290;
            for (int i = 0; i < 3; i++)
            {
                gotoPoint(0, 40, z);
                gotoPoint(20, 20, z);
                gotoPoint(40, 40, z);
                gotoPoint(40, 0, z);
                gotoPoint(20, -20, z);
                gotoPoint(40, -40, z);
                gotoPoint(0, -40, z);
                gotoPoint(-20, -20, z);
                gotoPoint(-40, -40, z);
                gotoPoint(-40, 0, z);
                gotoPoint(-20, 20, z);
                gotoPoint(-40, 40, z);
            }
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            _arduinoController.calibrate();
            setCurrentStatus(0.0F, 0.0F, -270.0959F, 0.0F, 0.0F, 0.0F);
        }

        

        private void btnGo_Click(object sender, EventArgs e)
        {
            
            _arduinoController.setDataStepper(dir0.Checked, (int)step0.Value, dir1.Checked, (int)step1.Value, dir2.Checked, (int)step2.Value);
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            float x = Convert.ToSingle(numX.Value);
            float y = Convert.ToSingle(numY.Value);
            float z = Convert.ToSingle(numZ.Value);

            gotoPoint(x, y, z);

            //int result = (new DeltaKinematics()).delta_calcForward(x, y, z, ref theta0, ref theta1, ref theta2);
            //Console.Out.WriteLine("T1:" + theta0);
            //Console.Out.WriteLine("T2:" + theta1);
            //Console.Out.WriteLine("T3:" + theta2);
        }

        private void setCurrentStatus(float x, float y, float z, float theta0, float theta1, float theta2)
        {
            this.current_x = x;
            this.current_y = y;
            this.current_z = z;
            this.current_theta0 = theta0;
            this.current_theta1 = theta1;
            this.current_theta2 = theta2;
        }

        public void gotoPoint(float x, float y, float z)
        {
            float theta0 = 0.0F;
            float theta1 = 0.0F;
            float theta2 = 0.0F;

            float tisogearbox = 5 + 2.0f / 11;
            float buocnho = 1.8f / tisogearbox;

            int result = (new DeltaKinematics()).delta_calcInverse(x, y, z, ref theta0, ref theta1, ref theta2);
            int numsteps0 = (int)Math.Round((current_theta0 - theta0) / buocnho);
            int numsteps1 = (int)Math.Round((current_theta1 - theta1) / buocnho);
            int numsteps2 = (int)Math.Round((current_theta2 - theta2) / buocnho);
            //Console.Out.WriteLine("Theta:(" + theta0 + "," + theta1 + "," + theta2 + ")");
            _arduinoController.setDataStepper(
                numsteps0 > 0 ? true : false, Math.Abs(numsteps0),
                numsteps1 > 0 ? true : false, Math.Abs(numsteps1),
                numsteps2 > 0 ? true : false, Math.Abs(numsteps2));
            setCurrentStatus(x, y, z, theta0, theta1, theta2);
        }

        private void btnStabityTest1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                gotoPoint(80, 0, -270);

                gotoPoint(-80, 0, -270);
            }
                
        }

        private void btnTestKinematics_Click(object sender, EventArgs e)
        {
            _arduinoController.testKinematics();
        }
    }
}
