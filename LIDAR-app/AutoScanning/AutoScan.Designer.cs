namespace AutoScanning
{
    partial class FormAutoScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutoScan));
            this.label1 = new System.Windows.Forms.Label();
            this.azimuthLimit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.azimuthStep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.elevationLimit = new System.Windows.Forms.NumericUpDown();
            this.elevationStep = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.azimuthLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.azimuthStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevationLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevationStep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Azimuth limit";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // azimuthLimit
            // 
            this.azimuthLimit.Location = new System.Drawing.Point(113, 26);
            this.azimuthLimit.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.azimuthLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.azimuthLimit.Name = "azimuthLimit";
            this.azimuthLimit.Size = new System.Drawing.Size(69, 20);
            this.azimuthLimit.TabIndex = 2;
            this.azimuthLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Azimuth step";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // azimuthStep
            // 
            this.azimuthStep.Location = new System.Drawing.Point(299, 25);
            this.azimuthStep.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.azimuthStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.azimuthStep.Name = "azimuthStep";
            this.azimuthStep.Size = new System.Drawing.Size(66, 20);
            this.azimuthStep.TabIndex = 3;
            this.azimuthStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Elevation limit";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(203, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Elevation step";
            this.label5.Click += new System.EventHandler(this.label1_Click);
            // 
            // elevationLimit
            // 
            this.elevationLimit.Location = new System.Drawing.Point(113, 83);
            this.elevationLimit.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.elevationLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.elevationLimit.Name = "elevationLimit";
            this.elevationLimit.Size = new System.Drawing.Size(69, 20);
            this.elevationLimit.TabIndex = 4;
            this.elevationLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // elevationStep
            // 
            this.elevationStep.Location = new System.Drawing.Point(299, 82);
            this.elevationStep.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.elevationStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.elevationStep.Name = "elevationStep";
            this.elevationStep.Size = new System.Drawing.Size(66, 20);
            this.elevationStep.TabIndex = 5;
            this.elevationStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(196, 123);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(291, 123);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // FormAutoScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 158);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.elevationStep);
            this.Controls.Add(this.elevationLimit);
            this.Controls.Add(this.azimuthStep);
            this.Controls.Add(this.azimuthLimit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAutoScan";
            this.Text = "Auto scanning control";
            this.Load += new System.EventHandler(this.FormAutoScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.azimuthLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.azimuthStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevationLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elevationStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown azimuthLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown azimuthStep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown elevationLimit;
        private System.Windows.Forms.NumericUpDown elevationStep;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}

