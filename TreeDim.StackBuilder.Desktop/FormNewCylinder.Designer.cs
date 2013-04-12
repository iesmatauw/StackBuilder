namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewCylinder
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
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnOK = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.lbUnitHeight = new System.Windows.Forms.Label();
            this.lbUnitRadius = new System.Windows.Forms.Label();
            this.nudRadius = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.gbWeight = new System.Windows.Forms.GroupBox();
            this.lbUnitWeight = new System.Windows.Forms.Label();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.lbWeight = new System.Windows.Forms.Label();
            this.trackBarHorizAngle = new System.Windows.Forms.TrackBar();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbFaceColor = new System.Windows.Forms.GroupBox();
            this.cbColorWall = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbWallColor = new System.Windows.Forms.Label();
            this.cbColorTop = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbTop = new System.Windows.Forms.Label();
            this.gbDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.gbWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.statusStripDef.SuspendLayout();
            this.gbFaceColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnCancel.Location = new System.Drawing.Point(497, 38);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 11;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnOK
            // 
            this.bnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnOK.Location = new System.Drawing.Point(497, 12);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 10;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(92, 38);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(399, 20);
            this.tbDescription.TabIndex = 15;
            this.tbDescription.TextChanged += new System.EventHandler(this.onCylinderPropertiesChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(92, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(143, 20);
            this.tbName.TabIndex = 13;
            this.tbName.TextChanged += new System.EventHandler(this.onCylinderPropertiesChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDescription.Location = new System.Drawing.Point(14, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Description";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblName.Location = new System.Drawing.Point(14, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Name";
            // 
            // gbDimensions
            // 
            this.gbDimensions.Controls.Add(this.lbUnitHeight);
            this.gbDimensions.Controls.Add(this.lbUnitRadius);
            this.gbDimensions.Controls.Add(this.nudRadius);
            this.gbDimensions.Controls.Add(this.nudHeight);
            this.gbDimensions.Controls.Add(this.lbHeight);
            this.gbDimensions.Controls.Add(this.lbLength);
            this.gbDimensions.Location = new System.Drawing.Point(8, 64);
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.Size = new System.Drawing.Size(354, 70);
            this.gbDimensions.TabIndex = 16;
            this.gbDimensions.TabStop = false;
            this.gbDimensions.Text = "Dimentions";
            // 
            // lbUnitHeight
            // 
            this.lbUnitHeight.AutoSize = true;
            this.lbUnitHeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbUnitHeight.Location = new System.Drawing.Point(150, 44);
            this.lbUnitHeight.Name = "lbUnitHeight";
            this.lbUnitHeight.Size = new System.Drawing.Size(23, 13);
            this.lbUnitHeight.TabIndex = 13;
            this.lbUnitHeight.Text = "mm";
            // 
            // lbUnitRadius
            // 
            this.lbUnitRadius.AutoSize = true;
            this.lbUnitRadius.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbUnitRadius.Location = new System.Drawing.Point(150, 18);
            this.lbUnitRadius.Name = "lbUnitRadius";
            this.lbUnitRadius.Size = new System.Drawing.Size(23, 13);
            this.lbUnitRadius.TabIndex = 3;
            this.lbUnitRadius.Text = "mm";
            // 
            // nudRadius
            // 
            this.nudRadius.DecimalPlaces = 1;
            this.nudRadius.Location = new System.Drawing.Point(84, 16);
            this.nudRadius.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRadius.Name = "nudRadius";
            this.nudRadius.Size = new System.Drawing.Size(60, 20);
            this.nudRadius.TabIndex = 2;
            this.nudRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRadius.ValueChanged += new System.EventHandler(this.onCylinderPropertiesChanged);
            // 
            // nudHeight
            // 
            this.nudHeight.DecimalPlaces = 1;
            this.nudHeight.Location = new System.Drawing.Point(84, 44);
            this.nudHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(60, 20);
            this.nudHeight.TabIndex = 12;
            this.nudHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.ValueChanged += new System.EventHandler(this.onCylinderPropertiesChanged);
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbHeight.Location = new System.Drawing.Point(6, 44);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(38, 13);
            this.lbHeight.TabIndex = 11;
            this.lbHeight.Text = "Height";
            // 
            // lbLength
            // 
            this.lbLength.AutoSize = true;
            this.lbLength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbLength.Location = new System.Drawing.Point(6, 18);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(40, 13);
            this.lbLength.TabIndex = 1;
            this.lbLength.Text = "Radius";
            // 
            // gbWeight
            // 
            this.gbWeight.Controls.Add(this.lbUnitWeight);
            this.gbWeight.Controls.Add(this.nudWeight);
            this.gbWeight.Controls.Add(this.lbWeight);
            this.gbWeight.Location = new System.Drawing.Point(8, 295);
            this.gbWeight.Name = "gbWeight";
            this.gbWeight.Size = new System.Drawing.Size(354, 78);
            this.gbWeight.TabIndex = 17;
            this.gbWeight.TabStop = false;
            this.gbWeight.Text = "Weight";
            // 
            // lbUnitWeight
            // 
            this.lbUnitWeight.AutoSize = true;
            this.lbUnitWeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbUnitWeight.Location = new System.Drawing.Point(315, 24);
            this.lbUnitWeight.Name = "lbUnitWeight";
            this.lbUnitWeight.Size = new System.Drawing.Size(19, 13);
            this.lbUnitWeight.TabIndex = 2;
            this.lbUnitWeight.Text = "kg";
            // 
            // nudWeight
            // 
            this.nudWeight.DecimalPlaces = 3;
            this.nudWeight.Location = new System.Drawing.Point(249, 20);
            this.nudWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(60, 20);
            this.nudWeight.TabIndex = 1;
            // 
            // lbWeight
            // 
            this.lbWeight.AutoSize = true;
            this.lbWeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbWeight.Location = new System.Drawing.Point(10, 24);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(41, 13);
            this.lbWeight.TabIndex = 0;
            this.lbWeight.Text = "Weight";
            // 
            // trackBarHorizAngle
            // 
            this.trackBarHorizAngle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarHorizAngle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBarHorizAngle.LargeChange = 90;
            this.trackBarHorizAngle.Location = new System.Drawing.Point(368, 328);
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.Size = new System.Drawing.Size(210, 45);
            this.trackBarHorizAngle.TabIndex = 20;
            this.trackBarHorizAngle.TickFrequency = 90;
            this.trackBarHorizAngle.Value = 225;
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox.Location = new System.Drawing.Point(368, 67);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(210, 255);
            this.pictureBox.TabIndex = 21;
            this.pictureBox.TabStop = false;
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Location = new System.Drawing.Point(0, 382);
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.Size = new System.Drawing.Size(584, 22);
            this.statusStripDef.SizingGrip = false;
            this.statusStripDef.TabIndex = 22;
            this.statusStripDef.Text = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            this.toolStripStatusLabelDef.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabelDef.Text = "toolStripStatusLabelDef";
            // 
            // gbFaceColor
            // 
            this.gbFaceColor.Controls.Add(this.cbColorWall);
            this.gbFaceColor.Controls.Add(this.lbWallColor);
            this.gbFaceColor.Controls.Add(this.cbColorTop);
            this.gbFaceColor.Controls.Add(this.lbTop);
            this.gbFaceColor.Location = new System.Drawing.Point(8, 140);
            this.gbFaceColor.Name = "gbFaceColor";
            this.gbFaceColor.Size = new System.Drawing.Size(354, 67);
            this.gbFaceColor.TabIndex = 23;
            this.gbFaceColor.TabStop = false;
            this.gbFaceColor.Text = "Face color";
            // 
            // cbColorWall
            // 
            this.cbColorWall.Color = System.Drawing.Color.LightSkyBlue;
            this.cbColorWall.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColorWall.DropDownHeight = 1;
            this.cbColorWall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorWall.DropDownWidth = 1;
            this.cbColorWall.IntegralHeight = false;
            this.cbColorWall.ItemHeight = 16;
            this.cbColorWall.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Farbe"});
            this.cbColorWall.Location = new System.Drawing.Point(84, 38);
            this.cbColorWall.Name = "cbColorWall";
            this.cbColorWall.Size = new System.Drawing.Size(75, 22);
            this.cbColorWall.TabIndex = 6;
            this.cbColorWall.SelectedColorChanged += new System.EventHandler(this.onCylinderPropertiesChanged);
            // 
            // lbWallColor
            // 
            this.lbWallColor.AutoSize = true;
            this.lbWallColor.Location = new System.Drawing.Point(8, 41);
            this.lbWallColor.Name = "lbWallColor";
            this.lbWallColor.Size = new System.Drawing.Size(54, 13);
            this.lbWallColor.TabIndex = 5;
            this.lbWallColor.Text = "Wall color";
            // 
            // cbColorTop
            // 
            this.cbColorTop.Color = System.Drawing.Color.Gray;
            this.cbColorTop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColorTop.DropDownHeight = 1;
            this.cbColorTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorTop.DropDownWidth = 1;
            this.cbColorTop.IntegralHeight = false;
            this.cbColorTop.ItemHeight = 16;
            this.cbColorTop.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Farbe"});
            this.cbColorTop.Location = new System.Drawing.Point(84, 13);
            this.cbColorTop.Name = "cbColorTop";
            this.cbColorTop.Size = new System.Drawing.Size(75, 22);
            this.cbColorTop.TabIndex = 2;
            this.cbColorTop.SelectedColorChanged += new System.EventHandler(this.onCylinderPropertiesChanged);
            // 
            // lbTop
            // 
            this.lbTop.AutoSize = true;
            this.lbTop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTop.Location = new System.Drawing.Point(6, 16);
            this.lbTop.Name = "lbTop";
            this.lbTop.Size = new System.Drawing.Size(52, 13);
            this.lbTop.TabIndex = 0;
            this.lbTop.Text = "Top color";
            // 
            // FormNewCylinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 404);
            this.Controls.Add(this.gbFaceColor);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.trackBarHorizAngle);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.gbWeight);
            this.Controls.Add(this.gbDimensions);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewCylinder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Define a new cylinder...";
            this.gbDimensions.ResumeLayout(false);
            this.gbDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            this.gbWeight.ResumeLayout(false);
            this.gbWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.gbFaceColor.ResumeLayout(false);
            this.gbFaceColor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox gbDimensions;
        private System.Windows.Forms.Label lbUnitHeight;
        private System.Windows.Forms.Label lbUnitRadius;
        private System.Windows.Forms.NumericUpDown nudRadius;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.GroupBox gbWeight;
        private System.Windows.Forms.Label lbUnitWeight;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.Label lbWeight;
        private System.Windows.Forms.TrackBar trackBarHorizAngle;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.GroupBox gbFaceColor;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColorWall;
        private System.Windows.Forms.Label lbWallColor;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColorTop;
        private System.Windows.Forms.Label lbTop;
    }
}