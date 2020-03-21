namespace LIDAR_app
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAutoRecord = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_current_reading = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.azimuth_box = new System.Windows.Forms.NumericUpDown();
            this.elevation_box = new System.Windows.Forms.NumericUpDown();
            this.buttonCommTest = new System.Windows.Forms.Button();
            this.buttonMoveSensor = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonVisualize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.azimuth_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevation_box)).BeginInit();
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
            this.buttonAutoRecord.Location = new System.Drawing.Point(83, 98);
            this.buttonAutoRecord.Name = "buttonAutoRecord";
            this.buttonAutoRecord.Size = new System.Drawing.Size(171, 23);
            this.buttonAutoRecord.TabIndex = 1;
            this.buttonAutoRecord.Text = "Begin recording process";
            this.buttonAutoRecord.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Automatic acquisition";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Current reading (mm)";
            // 
            // textBox_current_reading
            // 
            this.textBox_current_reading.Location = new System.Drawing.Point(156, 143);
            this.textBox_current_reading.Name = "textBox_current_reading";
            this.textBox_current_reading.ReadOnly = true;
            this.textBox_current_reading.Size = new System.Drawing.Size(100, 20);
            this.textBox_current_reading.TabIndex = 4;
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
            // buttonCommTest
            // 
            this.buttonCommTest.Location = new System.Drawing.Point(292, 64);
            this.buttonCommTest.Name = "buttonCommTest";
            this.buttonCommTest.Size = new System.Drawing.Size(171, 23);
            this.buttonCommTest.TabIndex = 1;
            this.buttonCommTest.Text = "Sensor comm. test";
            this.buttonCommTest.UseVisualStyleBackColor = true;
            // 
            // buttonMoveSensor
            // 
            this.buttonMoveSensor.Location = new System.Drawing.Point(83, 365);
            this.buttonMoveSensor.Name = "buttonMoveSensor";
            this.buttonMoveSensor.Size = new System.Drawing.Size(171, 23);
            this.buttonMoveSensor.TabIndex = 1;
            this.buttonMoveSensor.Text = "Move sensor";
            this.buttonMoveSensor.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(292, 108);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(171, 23);
            this.buttonExport.TabIndex = 1;
            this.buttonExport.Text = "Export data as .txt";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(292, 146);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(171, 23);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear data";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonVisualize
            // 
            this.buttonVisualize.Location = new System.Drawing.Point(292, 266);
            this.buttonVisualize.Name = "buttonVisualize";
            this.buttonVisualize.Size = new System.Drawing.Size(171, 23);
            this.buttonVisualize.TabIndex = 1;
            this.buttonVisualize.Text = "Visualize data";
            this.buttonVisualize.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 450);
            this.Controls.Add(this.elevation_box);
            this.Controls.Add(this.azimuth_box);
            this.Controls.Add(this.textBox_current_reading);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCommTest);
            this.Controls.Add(this.buttonMoveSensor);
            this.Controls.Add(this.buttonVisualize);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonAutoRecord);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LIDAR by Edin & Erik";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.azimuth_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevation_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAutoRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_current_reading;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown azimuth_box;
        private System.Windows.Forms.NumericUpDown elevation_box;
        private System.Windows.Forms.Button buttonCommTest;
        private System.Windows.Forms.Button buttonMoveSensor;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonVisualize;
    }
}

