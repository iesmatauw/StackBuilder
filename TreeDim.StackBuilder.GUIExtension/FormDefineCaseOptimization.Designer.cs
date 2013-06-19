namespace TreeDim.StackBuilder.GUIExtension
{
    partial class FormDefineCaseOptimization
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
            this.bnClose = new System.Windows.Forms.Button();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.chkVerticalOrientationOnly = new System.Windows.Forms.CheckBox();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbBoxLength = new System.Windows.Forms.Label();
            this.lbBoxWidth = new System.Windows.Forms.Label();
            this.lbBoxHeight = new System.Windows.Forms.Label();
            this.nudBoxLength = new System.Windows.Forms.NumericUpDown();
            this.nudBoxWidth = new System.Windows.Forms.NumericUpDown();
            this.nudBoxHeight = new System.Windows.Forms.NumericUpDown();
            this.statusStripDef.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // bnClose
            // 
            this.bnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnClose.Location = new System.Drawing.Point(502, 6);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(75, 23);
            this.bnClose.TabIndex = 0;
            this.bnClose.Text = "Close";
            this.bnClose.UseVisualStyleBackColor = true;
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Location = new System.Drawing.Point(0, 690);
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.Size = new System.Drawing.Size(584, 22);
            this.statusStripDef.TabIndex = 1;
            this.statusStripDef.Text = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            this.toolStripStatusLabelDef.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabelDef.Text = "toolStripStatusLabelDef";
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.nudBoxHeight);
            this.groupBox.Controls.Add(this.nudBoxWidth);
            this.groupBox.Controls.Add(this.nudBoxLength);
            this.groupBox.Controls.Add(this.lbBoxHeight);
            this.groupBox.Controls.Add(this.lbBoxWidth);
            this.groupBox.Controls.Add(this.lbBoxLength);
            this.groupBox.Controls.Add(this.chkVerticalOrientationOnly);
            this.groupBox.Controls.Add(this.nudNumber);
            this.groupBox.Controls.Add(this.lbNumber);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(285, 148);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Box (inner product)";
            // 
            // chkVerticalOrientationOnly
            // 
            this.chkVerticalOrientationOnly.AutoSize = true;
            this.chkVerticalOrientationOnly.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkVerticalOrientationOnly.Location = new System.Drawing.Point(16, 123);
            this.chkVerticalOrientationOnly.Name = "chkVerticalOrientationOnly";
            this.chkVerticalOrientationOnly.Size = new System.Drawing.Size(183, 17);
            this.chkVerticalOrientationOnly.TabIndex = 5;
            this.chkVerticalOrientationOnly.Text = "Only allow vertical box orientation";
            this.chkVerticalOrientationOnly.UseVisualStyleBackColor = true;
            // 
            // nudNumber
            // 
            this.nudNumber.Location = new System.Drawing.Point(207, 93);
            this.nudNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNumber.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Size = new System.Drawing.Size(66, 20);
            this.nudNumber.TabIndex = 4;
            this.nudNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbNumber.Location = new System.Drawing.Point(16, 93);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(131, 13);
            this.lbNumber.TabIndex = 3;
            this.lbNumber.Text = "Number of boxes per case";
            // 
            // lbBoxLength
            // 
            this.lbBoxLength.AutoSize = true;
            this.lbBoxLength.Location = new System.Drawing.Point(16, 17);
            this.lbBoxLength.Name = "lbBoxLength";
            this.lbBoxLength.Size = new System.Drawing.Size(65, 13);
            this.lbBoxLength.TabIndex = 6;
            this.lbBoxLength.Text = "Length (mm)";
            // 
            // lbBoxWidth
            // 
            this.lbBoxWidth.AutoSize = true;
            this.lbBoxWidth.Location = new System.Drawing.Point(16, 41);
            this.lbBoxWidth.Name = "lbBoxWidth";
            this.lbBoxWidth.Size = new System.Drawing.Size(60, 13);
            this.lbBoxWidth.TabIndex = 7;
            this.lbBoxWidth.Text = "Width (mm)";
            // 
            // lbBoxHeight
            // 
            this.lbBoxHeight.AutoSize = true;
            this.lbBoxHeight.Location = new System.Drawing.Point(16, 66);
            this.lbBoxHeight.Name = "lbBoxHeight";
            this.lbBoxHeight.Size = new System.Drawing.Size(63, 13);
            this.lbBoxHeight.TabIndex = 8;
            this.lbBoxHeight.Text = "Height (mm)";
            // 
            // nudBoxLength
            // 
            this.nudBoxLength.DecimalPlaces = 1;
            this.nudBoxLength.Location = new System.Drawing.Point(207, 17);
            this.nudBoxLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudBoxLength.Name = "nudBoxLength";
            this.nudBoxLength.Size = new System.Drawing.Size(66, 20);
            this.nudBoxLength.TabIndex = 9;
            // 
            // nudBoxWidth
            // 
            this.nudBoxWidth.DecimalPlaces = 1;
            this.nudBoxWidth.Location = new System.Drawing.Point(207, 42);
            this.nudBoxWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudBoxWidth.Name = "nudBoxWidth";
            this.nudBoxWidth.Size = new System.Drawing.Size(66, 20);
            this.nudBoxWidth.TabIndex = 10;
            // 
            // nudBoxHeight
            // 
            this.nudBoxHeight.DecimalPlaces = 1;
            this.nudBoxHeight.Location = new System.Drawing.Point(207, 67);
            this.nudBoxHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudBoxHeight.Name = "nudBoxHeight";
            this.nudBoxHeight.Size = new System.Drawing.Size(66, 20);
            this.nudBoxHeight.TabIndex = 11;
            // 
            // FormDefineCaseOptimization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnClose;
            this.ClientSize = new System.Drawing.Size(584, 712);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.bnClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDefineCaseOptimization";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Optimize case dimensions...";
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnClose;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox chkVerticalOrientationOnly;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.NumericUpDown nudBoxHeight;
        private System.Windows.Forms.NumericUpDown nudBoxWidth;
        private System.Windows.Forms.NumericUpDown nudBoxLength;
        private System.Windows.Forms.Label lbBoxHeight;
        private System.Windows.Forms.Label lbBoxWidth;
        private System.Windows.Forms.Label lbBoxLength;
    }
}