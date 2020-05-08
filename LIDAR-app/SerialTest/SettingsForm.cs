using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialTest
{
    public partial class SettingsForm : Form
    {

        SerialPort _serialPort = new SerialPort();
        bool _setupComplete;
        public SettingsForm()
        {
            InitializeComponent();
            GetAvailablePorts();

            _setupComplete = false;
        }

        void GetAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();

            if(ports == null)
            {
                MessageBox.Show("No ports detected!");
                throw new NullReferenceException("No ports detected!");
            }

            if(ports.Length == 0)
            {
                MessageBox.Show("No devices detected!\n Try plugging your device in and try again.");
            }

            comboPortNames.Items.AddRange(ports);
        }

        private void buttonGetPorts_Click(object sender, EventArgs e)
        {
            GetAvailablePorts();
        }

        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboPortNames.Text.Length == 0 || comboBaudRate.Text.Length == 0)
                {
                    MessageBox.Show("Please select port settings!");
                } else
                {
                    _serialPort.PortName = comboPortNames.Text;
                    _serialPort.BaudRate = Convert.ToInt32(comboBaudRate.Text);
                    _serialPort.Open();

                    progressBar.Value = 100;
                    buttonClosePort.Enabled = true;
                    buttonOpenPort.Enabled = false;

                    buttonSend.Enabled = true;
                    buttonReceive.Enabled = true;

                    _setupComplete = true;
                }
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
                _setupComplete = false;
            }
        }

        private void buttonClosePort_Click(object sender, EventArgs e)
        {
            _serialPort.Close();

            progressBar.Value = 0;

            buttonSend.Enabled = false;
            buttonReceive.Enabled = false;

            buttonOpenPort.Enabled = true;
            buttonClosePort.Enabled = false;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            _serialPort.WriteLine(textBoxSend.Text);
            textBoxSend.Text = "";
        }

        private void buttonReceive_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxReceive.Text =_serialPort.ReadLine();
            } catch (TimeoutException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool IsSetup()
        {
            return _setupComplete;
        }

        public SerialPort GetSerialPort()
        {
            if (_serialPort.IsOpen)
            {
                return _serialPort;
            } else
            {
                MessageBox.Show("The serial port to the Arduino isn't open! \n" +
                    " Try configuring it in the settings.");
                return null;
            }
            
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
