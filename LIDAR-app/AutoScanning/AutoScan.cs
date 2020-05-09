using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScanning
{
    public partial class FormAutoScan : Form
    {

        private int _azimuthLimit;
        private int _elevationLimit;
        private int _azimuthStep;
        private int _elevationStep;

        public int AzimuthLimit
        {
            get { return _azimuthLimit; }
            set { _azimuthLimit = value; }
        }
        public int ElevationLimit
        {
            get { return _elevationLimit; }
            set { _elevationLimit = value; }
        }
        public int AzimuthStep
        {
            get { return _azimuthStep; }
            set { _azimuthStep = value; }
        }
        public int ElevationStep
        {
            get { return _elevationStep; }
            set { _elevationStep = value; }
        }

        public FormAutoScan()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormAutoScan_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            AzimuthLimit = (int)azimuthLimit.Value;
            ElevationLimit = (int)elevationLimit.Value;
            AzimuthStep = (int)azimuthStep.Value;
            ElevationStep = (int)elevationStep.Value;
        }
    }
}
