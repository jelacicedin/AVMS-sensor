using SerialTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIDAR_app
{
    public partial class LidarForm : Form
    {
        SettingsForm _settingsForm = new SettingsForm();
        SerialPort _serialPort = new SerialPort();

        List<List<double>> _dataMatrix = new List<List<double>>();

        const double PI = 3.14159265359;

        private readonly object locker = new object();

        int az = 0, el = 0;


        public LidarForm()
        {
            InitializeComponent();
            Task.Run(() => SetCurrentReading());
            
            _dataMatrix = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonCommSettings_Click(object sender, EventArgs e)
        {
            _settingsForm.Show();
        }

        private void buttonSetPort_Click(object sender, EventArgs e)
        {
            if (_settingsForm.GetSerialPort() != null)
            {
                _serialPort = _settingsForm.GetSerialPort();
            }
        }

        /// <summary>
        /// Automatic recording process, go through the entire spherical system.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAutoRecord_Click(object sender, EventArgs e)
        {
            if (!_serialPort.IsOpen)
            {
                MessageBox.Show("You first need to set the serial port!");
                return;
            }

            Task.Run(() => CoverSphere());
        }

        /// <summary>
        /// Performs rotation around entire sphere.
        /// </summary>
        private void CoverSphere()
        {
            for (az = 0; az < 360; az++)
            {
                buttonMoveSensor.Enabled = false;

                _serialPort.WriteLine(FormCommand(Motors.Azimuth, az));

                for (el = 0; el < 90; el++)
                {
                    _serialPort.WriteLine(FormCommand(Motors.Elevation, el));

                    try
                    {
                        int distance;

                        if (int.TryParse(_serialPort.ReadLine(), out distance))
                        {
                            List<double> row = new List<double>() { AngleToRad(az), AngleToRad(el), (int)distance };

                           

                            _dataMatrix.Add(row);
                        }
                        else
                        {
                            MessageBox.Show("Mistake in parsing the serial return from the Arduino!\n" +
                                "Check the format of the output!");
                            _dataMatrix = null;
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("Error while reading!");
                        _dataMatrix = null;
                    }

                    Thread.Sleep(50);
                }
            }

            buttonMoveSensor.Enabled = true;
        }

        /// <summary>
        /// Returns the command string to be sent to the Arduino 
        /// </summary>
        /// <param name="motor"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private string FormCommand(Motors motor, double angle)
        {
            return motor.ToString() + "." + angle.ToString();
        }

        private double AngleToRad(int angle)
        {
            angle = angle % 360;

            return PI / 180 * (double)angle;
        }

        private void buttonMoveSensor_Click(object sender, EventArgs e)
        {
            int az = (int)azimuth_box.Value;
            int el = (int)elevation_box.Value;

            if (!_serialPort.IsOpen)
            {
                MessageBox.Show("You first need to set the serial port!");
                return;
            }

            lock (locker)
            {
                _serialPort.WriteLine(Motors.Azimuth + "." + az.ToString());
                Thread.Sleep(100);
                _serialPort.WriteLine(Motors.Elevation + "." + el.ToString());
                Thread.Sleep(100);
            }

        }

        private void buttonVisualize_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Not implemented yet...");
            //OpenTKLib.PointCloudVertices cube = OpenTKLib.PointCloudVertices.CreateCube_Corners(50);


            //////string input = "b's357d180p577t\n'";
            ////// Split on one or more non-digit characters.

            //OpenTKLib.PointCloudVertices room = new OpenTKLib.PointCloudVertices();

            //string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "raw_Erik.txt");
            //string[] readText = File.ReadAllLines(path);

            //string[] number1 = Regex.Split(readText[0], @"\D+");

            //string test = "eee";

            //try
            //{

            //    // Open the file to read from.

            //    foreach (string s in readText)
            //    {
            //        string[] numbers = Regex.Split(s, @"\D+");
            //        int distance = int.Parse(numbers[1]);
            //        int phi = int.Parse(numbers[2]);
            //        int theta = int.Parse(numbers[3]);

            //        double distance_geom = (double)distance * 0.1;
            //        double phi_geom = (double)phi * PI / 1024;
            //        double theta_geom = (double)theta * PI / 1024;

            //        double x = distance_geom * Math.Cos(theta_geom) * Math.Cos(phi_geom);
            //        double y = distance_geom * Math.Sin(theta_geom) * Math.Cos(phi_geom);
            //        double z = distance_geom * Math.Sin(phi_geom);

            //        OpenTKLib.Vertex dot = new OpenTKLib.Vertex(x, y, z);
            //        room.Add(dot);
            //    }

            //    OpenTKLib.OpenTKForm fOTK = new OpenTKLib.OpenTKForm();
            //    fOTK.ShowPointCloud(room);
            //    fOTK.ShowDialog();
            //}
            //catch
            //{
            //    Console.WriteLine("Error in path");
            //    throw;
            //}

            //Console.WriteLine(test + number1[0]);

            OpenTKLib.PointCloudVertices room = new OpenTKLib.PointCloudVertices();

            foreach(var row in _dataMatrix)
            {
                double theta = row[0];
                double phi = row[1];
                double distance = row[2];

                double x = distance * Math.Cos(theta) * Math.Cos(phi);
                double y = distance * Math.Sin(theta) * Math.Cos(phi);
                double z = distance * Math.Sin(phi);

                OpenTKLib.Vertex dot = new OpenTKLib.Vertex(x, y, z);
                room.Add(dot);
            }

            OpenTKLib.OpenTKForm fOTK = new OpenTKLib.OpenTKForm();
            fOTK.ShowPointCloud(room);
            fOTK.ShowDialog();

        }

        private void SetCurrentReading()
        {

            int distance;
            while (true)
            {
                if (!_serialPort.IsOpen)
                {
                    continue;
                }

                try
                {
                    if (int.TryParse(_serialPort.ReadLine(), out distance))
                    {
                        textBoxCurrentReading.Text = distance.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Mistake in parsing the serial return from the Arduino!\n" +
                                   "Check the format of the output!");
                        _dataMatrix = null;
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Thread.Sleep(500);
            }
            
            


            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _dataMatrix = null;
            textBox1.Text = string.Empty;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "DefaultOutputName.txt";

            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)

            {

                StreamWriter writer = new StreamWriter(save.OpenFile());

                for (int i = 0; i < textBox1.TextLength; i++)

                {

                    writer.WriteLine(textBox1.Text[i]);

                }

                writer.Dispose();

                writer.Close();

            }

        }

        private void LidarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Displays what's currently in the _displayMatrix
        /// </summary>
        private void DisplayData()
        {
            while (true)
            {
                if(_dataMatrix == null)
                {
                    continue;
                }

                foreach(var row in _dataMatrix)
                {
                    textBox1.Text += "Az: " + row[0] + " El: " + row[1] + " D: " + row[2];
                }

                Thread.Sleep(500);
            }
        }
    }
}
