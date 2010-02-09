namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewBundle
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
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbColor = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lbWeight = new System.Windows.Forms.Label();
            this.gbFaceColor = new System.Windows.Forms.GroupBox();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.gbWeight = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbThickness = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.trackBarHorizAngle = new System.Windows.Forms.TrackBar();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.lbNoFlats = new System.Windows.Forms.Label();
            this.nudNoFlats = new System.Windows.Forms.NumericUpDown();
            this.nudThickness = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnAccept = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.gbFaceColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            this.gbWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).BeginInit();
            this.gbDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoFlats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.Beige;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
            this.cbColor.IntegralHeight = false;
            this.cbColor.ItemHeight = 16;
            this.cbColor.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color"});
            this.cbColor.Location = new System.Drawing.Point(161, 20);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(75, 22);
            this.cbColor.TabIndex = 12;
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(10, 23);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(31, 13);
            this.lbColor.TabIndex = 9;
            this.lbColor.Text = "Color";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(15, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 32;
            this.lblName.Text = "Name";
            // 
            // lbWeight
            // 
            this.lbWeight.AutoSize = true;
            this.lbWeight.Location = new System.Drawing.Point(10, 24);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(60, 13);
            this.lbWeight.TabIndex = 14;
            this.lbWeight.Text = "Unit weight";
            // 
            // gbFaceColor
            // 
            this.gbFaceColor.Controls.Add(this.cbColor);
            this.gbFaceColor.Controls.Add(this.lbColor);
            this.gbFaceColor.Location = new System.Drawing.Point(8, 199);
            this.gbFaceColor.Name = "gbFaceColor";
            this.gbFaceColor.Size = new System.Drawing.Size(246, 51);
            this.gbFaceColor.TabIndex = 28;
            this.gbFaceColor.TabStop = false;
            this.gbFaceColor.Text = "Face color";
            // 
            // nudWeight
            // 
            this.nudWeight.DecimalPlaces = 3;
            this.nudWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudWeight.Location = new System.Drawing.Point(161, 21);
            this.nudWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(75, 20);
            this.nudWeight.TabIndex = 16;
            this.nudWeight.ValueChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // nudLength
            // 
            this.nudLength.Location = new System.Drawing.Point(161, 23);
            this.nudLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(75, 20);
            this.nudLength.TabIndex = 8;
            this.nudLength.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudLength.ValueChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // gbWeight
            // 
            this.gbWeight.Controls.Add(this.nudWeight);
            this.gbWeight.Controls.Add(this.lbWeight);
            this.gbWeight.Location = new System.Drawing.Point(8, 250);
            this.gbWeight.Name = "gbWeight";
            this.gbWeight.Size = new System.Drawing.Size(245, 48);
            this.gbWeight.TabIndex = 29;
            this.gbWeight.TabStop = false;
            this.gbWeight.Text = "Weight";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(101, 33);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(266, 20);
            this.tbDescription.TabIndex = 35;
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(101, 7);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(143, 20);
            this.tbName.TabIndex = 34;
            this.tbName.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // lbThickness
            // 
            this.lbThickness.AutoSize = true;
            this.lbThickness.Location = new System.Drawing.Point(10, 76);
            this.lbThickness.Name = "lbThickness";
            this.lbThickness.Size = new System.Drawing.Size(74, 13);
            this.lbThickness.TabIndex = 4;
            this.lbThickness.Text = "Unit thickness";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(14, 33);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 33;
            this.lblDescription.Text = "Description";
            // 
            // trackBarHorizAngle
            // 
            this.trackBarHorizAngle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarHorizAngle.LargeChange = 90;
            this.trackBarHorizAngle.Location = new System.Drawing.Point(262, 287);
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.Size = new System.Drawing.Size(210, 45);
            this.trackBarHorizAngle.TabIndex = 31;
            this.trackBarHorizAngle.TickFrequency = 90;
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // gbDimensions
            // 
            this.gbDimensions.Controls.Add(this.lbNoFlats);
            this.gbDimensions.Controls.Add(this.nudNoFlats);
            this.gbDimensions.Controls.Add(this.nudLength);
            this.gbDimensions.Controls.Add(this.nudThickness);
            this.gbDimensions.Controls.Add(this.nudWidth);
            this.gbDimensions.Controls.Add(this.lbThickness);
            this.gbDimensions.Controls.Add(this.lbWidth);
            this.gbDimensions.Controls.Add(this.lbLength);
            this.gbDimensions.Location = new System.Drawing.Point(8, 63);
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.Size = new System.Drawing.Size(246, 130);
            this.gbDimensions.TabIndex = 27;
            this.gbDimensions.TabStop = false;
            this.gbDimensions.Text = "Dimentions";
            // 
            // lbNoFlats
            // 
            this.lbNoFlats.AutoSize = true;
            this.lbNoFlats.Location = new System.Drawing.Point(10, 103);
            this.lbNoFlats.Name = "lbNoFlats";
            this.lbNoFlats.Size = new System.Drawing.Size(78, 13);
            this.lbNoFlats.TabIndex = 10;
            this.lbNoFlats.Text = "Number of flats";
            // 
            // nudNoFlats
            // 
            this.nudNoFlats.Location = new System.Drawing.Point(161, 103);
            this.nudNoFlats.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNoFlats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoFlats.Name = "nudNoFlats";
            this.nudNoFlats.Size = new System.Drawing.Size(75, 20);
            this.nudNoFlats.TabIndex = 9;
            this.nudNoFlats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoFlats.ValueChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // nudThickness
            // 
            this.nudThickness.DecimalPlaces = 2;
            this.nudThickness.Location = new System.Drawing.Point(161, 76);
            this.nudThickness.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudThickness.Name = "nudThickness";
            this.nudThickness.Size = new System.Drawing.Size(75, 20);
            this.nudThickness.TabIndex = 7;
            this.nudThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThickness.ValueChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(161, 49);
            this.nudWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(75, 20);
            this.nudWidth.TabIndex = 6;
            this.nudWidth.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(10, 49);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(35, 13);
            this.lbWidth.TabIndex = 3;
            this.lbWidth.Text = "Width";
            // 
            // lbLength
            // 
            this.lbLength.AutoSize = true;
            this.lbLength.Location = new System.Drawing.Point(10, 22);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(40, 13);
            this.lbLength.TabIndex = 2;
            this.lbLength.Text = "Length";
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(395, 33);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 26;
            this.bnCancel.Text = "&Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnAccept
            // 
            this.bnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnAccept.Location = new System.Drawing.Point(395, 7);
            this.bnAccept.Name = "bnAccept";
            this.bnAccept.Size = new System.Drawing.Size(75, 23);
            this.bnAccept.TabIndex = 25;
            this.bnAccept.Text = "&Ok";
            this.bnAccept.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(261, 70);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(210, 210);
            this.pictureBox.TabIndex = 30;
            this.pictureBox.TabStop = false;
            // 
            // FormNewBundle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 339);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gbFaceColor);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.gbWeight);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.trackBarHorizAngle);
            this.Controls.Add(this.gbDimensions);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnAccept);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewBundle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Create new Bundle...";
            this.gbFaceColor.ResumeLayout(false);
            this.gbFaceColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            this.gbWeight.ResumeLayout(false);
            this.gbWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).EndInit();
            this.gbDimensions.ResumeLayout(false);
            this.gbDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoFlats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lbWeight;
        private System.Windows.Forms.GroupBox gbFaceColor;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox gbWeight;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbThickness;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TrackBar trackBarHorizAngle;
        private System.Windows.Forms.GroupBox gbDimensions;
        private System.Windows.Forms.NumericUpDown nudThickness;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnAccept;
        private System.Windows.Forms.NumericUpDown nudNoFlats;
        private System.Windows.Forms.Label lbNoFlats;
    }
}