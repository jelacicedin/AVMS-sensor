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
using AutoScanning;


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

        bool clickedImportOnce = false;

        private int _azimuthLimit = 360;
        private int _elevationLimit = 50;
        private int _azimuthStep = 5;
        private int _elevationStep = 5;

        delegate void SetTextCallback(string text);


        public LidarForm()
        {
            InitializeComponent();
            Task.Run(() => SetCurrentReading());
            Task.Run(() => DisplayData());
            _dataMatrix = null;

            _azimuthLimit = 360;
            _elevationLimit = 50;
            _azimuthStep = 5;
            _elevationStep = 5;
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

            _dataMatrix = new List<List<double>>();

            Task.Run(() => CoverSphere());
        }

        /// <summary>
        /// Performs rotation around entire sphere.
        /// </summary>
        private void CoverSphere()
        {
            for (az = 0; az < _azimuthLimit; az+=_azimuthStep)
            {
                buttonMoveSensor.Enabled = false;
               
                _serialPort.WriteLine(Motors.Azimuth + "." + az.ToString());
                Thread.Sleep(100);
                


                for (el = 0; el < _elevationLimit; el+=_elevationStep)
                {
                    _serialPort.WriteLine(Motors.Elevation + "." + el.ToString());
                    Thread.Sleep(100);

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

                    Thread.Sleep(100);
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
                double distance = (double)row[2]/100;

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
            if(_dataMatrix == null)
            {
                MessageBox.Show("Your data matrix is empty! \nTry importing data or doing a sensor recording.");
                return;
            }

            if(_dataMatrix.Count == 0)
            {
                MessageBox.Show("Your data matrix is empty! \nTry importing data or doing a sensor recording.");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "DefaultOutputName.txt";

            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)

            {

                StreamWriter writer = new StreamWriter(save.OpenFile());

                foreach (var row in _dataMatrix)
                {
                   writer.WriteLine("Azimuth: " + row[0] + " Elevation: " + row[1] + " distance: " + row[2]);
                }


                writer.Dispose();

                writer.Close();

            }

        }

        private void LidarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void LidarForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            
            if ((_dataMatrix != null) && (clickedImportOnce == false))
            {
                MessageBox.Show("The data matrix isn't empty, if you really want to import click \n" +
                    " Import data again.");
                clickedImportOnce = true;
                return;
            }

            _dataMatrix = new List<List<double>>();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string sourceFile = theDialog.FileName;
                    string[] positionRows = File.ReadAllLines(sourceFile);

                    if(positionRows.Length == 0)
                    {
                        MessageBox.Show("Your file is empty.");
                        return;
                    }

                    foreach(var row in positionRows)
                    {
                        string[] numbers = Regex.Split(row, @"\D+");

                        if (numbers.Length != 4)
                        {
                            MessageBox.Show("Your data file isn't okay.\n" +
                                " Try a new one. Data matrix is reset.");
                            _dataMatrix = null;
                            return;
                        }

                        double az = double.Parse(numbers[1]);
                        double el = double.Parse(numbers[2]);
                        double dist = double.Parse(numbers[3]);

                        _dataMatrix.Add(new List<double>(){ az, el, dist });

                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }


        }

        private void adjustLimitsButton_Click(object sender, EventArgs e)
        {
            FormAutoScan f = new FormAutoScan();

            lock (locker)
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _azimuthLimit = f.AzimuthLimit;
                    _elevationLimit = f.ElevationLimit;
                    _azimuthStep = f.AzimuthStep;
                    _elevationStep = f.ElevationStep;
                }
            }
            

        }

        private void Update1(string text)
        {
            if (this.azimuthLimitBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Update1);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.azimuthLimitBox.Text = text;
            }
        }

        private void Update2(string text)
        {
            if (this.elevationLimitBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Update2);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.elevationLimitBox.Text = text;
            }
        }

        private void Update3(string text)
        {
            if (this.azimuthStepBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Update3);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.azimuthStepBox.Text = text;
            }
        }

        private void Update4(string text)
        {
            if (this.elevationStepBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Update4);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.elevationStepBox.Text = text;
            }
        }

        private void Update5(string textLines)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Update5);
                this.Invoke(d, new object[] { textLines });
            }
            else
            {
                this.textBox1.Text = textLines;
            }
        }

        /// <summary>
        /// Displays what's currently in the _displayMatrix
        /// </summary>
        private void DisplayData()
        {
            while (true)
            {

                Update1(_azimuthLimit.ToString());
                Update2(_elevationLimit.ToString());
                Update3(_azimuthStep.ToString());
                Update4(_elevationStep.ToString());


                if (_dataMatrix == null)
                {
                    continue;
                }

                string tmp = "";
                foreach (var row in _dataMatrix)
                {
                    tmp += "Az: " + row[0] + " El: " + row[1] + " D: " + row[2] + Environment.NewLine;
                }

                Update5(tmp);

                Thread.Sleep(500);

            }
        }
    }
}
