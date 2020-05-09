namespace LIDAR_app
{
    partial class LidarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LidarForm));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAutoRecord = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCurrentReading = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.azimuth_box = new System.Windows.Forms.NumericUpDown();
            this.elevation_box = new System.Windows.Forms.NumericUpDown();
            this.buttonCommSettings = new System.Windows.Forms.Button();
            this.buttonMoveSensor = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonVisualize = new System.Windows.Forms.Button();
            this.buttonSetPort = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonImport = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.adjustLimitsButton = new System.Windows.Forms.Button();
            this.azimuthLimitBox = new System.Windows.Forms.TextBox();
            this.azimuthStepBox = new System.Windows.Forms.TextBox();
            this.elevationLimitBox = new System.Windows.Forms.TextBox();
            this.elevationStepBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.azimuth_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevation_box)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "EnE LIDAR System";
            // 
            // buttonAutoRecord
            // 
            this.buttonAutoRecord.Location = new System.Drawing.Point(21, 178);
            this.buttonAutoRecord.Name = "buttonAutoRecord";
            this.buttonAutoRecord.Size = new System.Drawing.Size(132, 23);
            this.buttonAutoRecord.TabIndex = 1;
            this.buttonAutoRecord.Text = "Begin Recording Process";
            this.buttonAutoRecord.UseVisualStyleBackColor = true;
            this.buttonAutoRecord.Click += new System.EventHandler(this.buttonAutoRecord_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Automatic acquisition";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Current reading (mm)";
            // 
            // textBoxCurrentReading
            // 
            this.textBoxCurrentReading.Location = new System.Drawing.Point(152, 143);
            this.textBoxCurrentReading.Name = "textBoxCurrentReading";
            this.textBoxCurrentReading.ReadOnly = true;
            this.textBoxCurrentReading.Size = new System.Drawing.Size(138, 20);
            this.textBoxCurrentReading.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Manual motor system control";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Azimuth (°)";
            this.label5.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Elevation (°)";
            this.label6.Click += new System.EventHandler(this.label4_Click);
            // 
            // azimuth_box
            // 
            this.azimuth_box.Location = new System.Drawing.Point(134, 284);
            this.azimuth_box.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.azimuth_box.Name = "azimuth_box";
            this.azimuth_box.Size = new System.Drawing.Size(120, 20);
            this.azimuth_box.TabIndex = 5;
            this.azimuth_box.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // elevation_box
            // 
            this.elevation_box.Location = new System.Drawing.Point(134, 320);
            this.elevation_box.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.elevation_box.Name = "elevation_box";
            this.elevation_box.Size = new System.Drawing.Size(120, 20);
            this.elevation_box.TabIndex = 5;
            this.elevation_box.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonCommSettings
            // 
            this.buttonCommSettings.Location = new System.Drawing.Point(422, 59);
            this.buttonCommSettings.Name = "buttonCommSettings";
            this.buttonCommSettings.Size = new System.Drawing.Size(171, 23);
            this.buttonCommSettings.TabIndex = 1;
            this.buttonCommSettings.Text = "Sensor comm. settings";
            this.buttonCommSettings.UseVisualStyleBackColor = true;
            this.buttonCommSettings.Click += new System.EventHandler(this.buttonCommSettings_Click);
            // 
            // buttonMoveSensor
            // 
            this.buttonMoveSensor.Location = new System.Drawing.Point(83, 365);
            this.buttonMoveSensor.Name = "buttonMoveSensor";
            this.buttonMoveSensor.Size = new System.Drawing.Size(171, 23);
            this.buttonMoveSensor.TabIndex = 1;
            this.buttonMoveSensor.Text = "Move Sensor";
            this.buttonMoveSensor.UseVisualStyleBackColor = true;
            this.buttonMoveSensor.Click += new System.EventHandler(this.buttonMoveSensor_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(313, 143);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(171, 23);
            this.buttonExport.TabIndex = 1;
            this.buttonExport.Text = "Export Data As .txt";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(422, 178);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(171, 23);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear Data";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonVisualize
            // 
            this.buttonVisualize.Location = new System.Drawing.Point(306, 365);
            this.buttonVisualize.Name = "buttonVisualize";
            this.buttonVisualize.Size = new System.Drawing.Size(171, 23);
            this.buttonVisualize.TabIndex = 1;
            this.buttonVisualize.Text = "Visualize Data";
            this.buttonVisualize.UseVisualStyleBackColor = true;
            this.buttonVisualize.Click += new System.EventHandler(this.buttonVisualize_Click);
            // 
            // buttonSetPort
            // 
            this.buttonSetPort.Location = new System.Drawing.Point(422, 98);
            this.buttonSetPort.Name = "buttonSetPort";
            this.buttonSetPort.Size = new System.Drawing.Size(171, 23);
            this.buttonSetPort.TabIndex = 6;
            this.buttonSetPort.Text = "Set Port";
            this.buttonSetPort.UseVisualStyleBackColor = true;
            this.buttonSetPort.Click += new System.EventHandler(this.buttonSetPort_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(306, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 152);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distance Data";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(376, 126);
            this.textBox1.TabIndex = 0;
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(504, 143);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(164, 23);
            this.buttonImport.TabIndex = 8;
            this.buttonImport.Text = "Import Data";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Azimuth limit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Elevation limit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(157, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Azimuth step";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(154, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Elevation step";
            // 
            // adjustLimitsButton
            // 
            this.adjustLimitsButton.Location = new System.Drawing.Point(164, 178);
            this.adjustLimitsButton.Name = "adjustLimitsButton";
            this.adjustLimitsButton.Size = new System.Drawing.Size(126, 23);
            this.adjustLimitsButton.TabIndex = 9;
            this.adjustLimitsButton.Text = "Adjust limits";
            this.adjustLimitsButton.UseVisualStyleBackColor = true;
            this.adjustLimitsButton.Click += new System.EventHandler(this.adjustLimitsButton_Click);
            // 
            // azimuthLimitBox
            // 
            this.azimuthLimitBox.Location = new System.Drawing.Point(95, 84);
            this.azimuthLimitBox.Name = "azimuthLimitBox";
            this.azimuthLimitBox.ReadOnly = true;
            this.azimuthLimitBox.Size = new System.Drawing.Size(49, 20);
            this.azimuthLimitBox.TabIndex = 10;
            // 
            // azimuthStepBox
            // 
            this.azimuthStepBox.Location = new System.Drawing.Point(234, 84);
            this.azimuthStepBox.Name = "azimuthStepBox";
            this.azimuthStepBox.ReadOnly = true;
            this.azimuthStepBox.Size = new System.Drawing.Size(56, 20);
            this.azimuthStepBox.TabIndex = 11;
            // 
            // elevationLimitBox
            // 
            this.elevationLimitBox.Location = new System.Drawing.Point(95, 117);
            this.elevationLimitBox.Name = "elevationLimitBox";
            this.elevationLimitBox.ReadOnly = true;
            this.elevationLimitBox.Size = new System.Drawing.Size(49, 20);
            this.elevationLimitBox.TabIndex = 12;
            // 
            // elevationStepBox
            // 
            this.elevationStepBox.Location = new System.Drawing.Point(234, 114);
            this.elevationStepBox.Name = "elevationStepBox";
            this.elevationStepBox.ReadOnly = true;
            this.elevationStepBox.Size = new System.Drawing.Size(56, 20);
            this.elevationStepBox.TabIndex = 13;
            // 
            // LidarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 450);
            this.Controls.Add(this.elevationStepBox);
            this.Controls.Add(this.elevationLimitBox);
            this.Controls.Add(this.azimuthStepBox);
            this.Controls.Add(this.azimuthLimitBox);
            this.Controls.Add(this.adjustLimitsButton);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSetPort);
            this.Controls.Add(this.elevation_box);
            this.Controls.Add(this.azimuth_box);
            this.Controls.Add(this.textBoxCurrentReading);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCommSettings);
            this.Controls.Add(this.buttonMoveSensor);
            this.Controls.Add(this.buttonVisualize);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonAutoRecord);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LidarForm";
            this.Text = "LIDAR by Edin & Erik";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LidarForm_FormClosed);
            this.Load += new System.EventHandler(this.LidarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.azimuth_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevation_box)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAutoRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCurrentReading;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown azimuth_box;
        private System.Windows.Forms.NumericUpDown elevation_box;
        private System.Windows.Forms.Button buttonCommSettings;
        private System.Windows.Forms.Button buttonMoveSensor;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonVisualize;
        private System.Windows.Forms.Button buttonSetPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button adjustLimitsButton;
        private System.Windows.Forms.TextBox azimuthLimitBox;
        private System.Windows.Forms.TextBox azimuthStepBox;
        private System.Windows.Forms.TextBox elevationLimitBox;
        private System.Windows.Forms.TextBox elevationStepBox;
    }
}

