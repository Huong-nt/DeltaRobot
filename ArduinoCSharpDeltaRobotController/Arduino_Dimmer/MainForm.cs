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

        private void btnTestStepper_Click(object sender, EventArgs e)
        {

            _arduinoController.setDataStepper(false, 20, false, 20, false, 20);
            _arduinoController.setDataStepper(true, 20, true, 20, true, 20);

            //_arduinoController.setDataStepper(false, 30, true, 100, true, 200);
            //_arduinoController.setDataStepper(false, 96, false, 93, true, 147);
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            _arduinoController.calibrate();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _arduinoController.setDataStepper(false, 200, false, 100, false, 200);
            _arduinoController.setDataStepper(true, 30, false, 100, false, 200);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            
            _arduinoController.setDataStepper(dir0.Checked, (int)step0.Value, dir1.Checked, (int)step1.Value, dir2.Checked, (int)step2.Value);
        }
    }
}
