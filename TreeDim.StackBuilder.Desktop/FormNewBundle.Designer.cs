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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewBundle));
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.lbColor = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lbWeight = new System.Windows.Forms.Label();
            this.gbFaceColor = new System.Windows.Forms.GroupBox();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.gbWeight = new System.Windows.Forms.GroupBox();
            this.lbUnitWeight = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbThickness = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.trackBarHorizAngle = new System.Windows.Forms.TrackBar();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.lbUnitThickness = new System.Windows.Forms.Label();
            this.lbUnitWidth = new System.Windows.Forms.Label();
            this.lbUnitLength = new System.Windows.Forms.Label();
            this.lbNoFlats = new System.Windows.Forms.Label();
            this.nudNoFlats = new System.Windows.Forms.NumericUpDown();
            this.nudThickness = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnOk = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.statusStripDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbColor
            // 
            this.cbColor.AccessibleDescription = null;
            this.cbColor.AccessibleName = null;
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.BackgroundImage = null;
            this.cbColor.Color = System.Drawing.Color.Beige;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
            this.cbColor.Font = null;
            this.cbColor.Items.AddRange(new object[] {
            resources.GetString("cbColor.Items"),
            resources.GetString("cbColor.Items1"),
            resources.GetString("cbColor.Items2"),
            resources.GetString("cbColor.Items3"),
            resources.GetString("cbColor.Items4"),
            resources.GetString("cbColor.Items5"),
            resources.GetString("cbColor.Items6"),
            resources.GetString("cbColor.Items7"),
            resources.GetString("cbColor.Items8"),
            resources.GetString("cbColor.Items9"),
            resources.GetString("cbColor.Items10"),
            resources.GetString("cbColor.Items11"),
            resources.GetString("cbColor.Items12"),
            resources.GetString("cbColor.Items13"),
            resources.GetString("cbColor.Items14"),
            resources.GetString("cbColor.Items15"),
            resources.GetString("cbColor.Items16")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // lbColor
            // 
            this.lbColor.AccessibleDescription = null;
            this.lbColor.AccessibleName = null;
            resources.ApplyResources(this.lbColor, "lbColor");
            this.lbColor.Font = null;
            this.lbColor.Name = "lbColor";
            // 
            // lblName
            // 
            this.lblName.AccessibleDescription = null;
            this.lblName.AccessibleName = null;
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Font = null;
            this.lblName.Name = "lblName";
            // 
            // lbWeight
            // 
            this.lbWeight.AccessibleDescription = null;
            this.lbWeight.AccessibleName = null;
            resources.ApplyResources(this.lbWeight, "lbWeight");
            this.lbWeight.Font = null;
            this.lbWeight.Name = "lbWeight";
            // 
            // gbFaceColor
            // 
            this.gbFaceColor.AccessibleDescription = null;
            this.gbFaceColor.AccessibleName = null;
            resources.ApplyResources(this.gbFaceColor, "gbFaceColor");
            this.gbFaceColor.BackgroundImage = null;
            this.gbFaceColor.Controls.Add(this.cbColor);
            this.gbFaceColor.Controls.Add(this.lbColor);
            this.gbFaceColor.Font = null;
            this.gbFaceColor.Name = "gbFaceColor";
            this.gbFaceColor.TabStop = false;
            // 
            // nudWeight
            // 
            this.nudWeight.AccessibleDescription = null;
            this.nudWeight.AccessibleName = null;
            resources.ApplyResources(this.nudWeight, "nudWeight");
            this.nudWeight.DecimalPlaces = 3;
            this.nudWeight.Font = null;
            this.nudWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.ValueChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // nudLength
            // 
            this.nudLength.AccessibleDescription = null;
            this.nudLength.AccessibleName = null;
            resources.ApplyResources(this.nudLength, "nudLength");
            this.nudLength.DecimalPlaces = 1;
            this.nudLength.Font = null;
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
            this.nudLength.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudLength.ValueChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // gbWeight
            // 
            this.gbWeight.AccessibleDescription = null;
            this.gbWeight.AccessibleName = null;
            resources.ApplyResources(this.gbWeight, "gbWeight");
            this.gbWeight.BackgroundImage = null;
            this.gbWeight.Controls.Add(this.lbUnitWeight);
            this.gbWeight.Controls.Add(this.nudWeight);
            this.gbWeight.Controls.Add(this.lbWeight);
            this.gbWeight.Font = null;
            this.gbWeight.Name = "gbWeight";
            this.gbWeight.TabStop = false;
            // 
            // lbUnitWeight
            // 
            this.lbUnitWeight.AccessibleDescription = null;
            this.lbUnitWeight.AccessibleName = null;
            resources.ApplyResources(this.lbUnitWeight, "lbUnitWeight");
            this.lbUnitWeight.Font = null;
            this.lbUnitWeight.Name = "lbUnitWeight";
            // 
            // tbDescription
            // 
            this.tbDescription.AccessibleDescription = null;
            this.tbDescription.AccessibleName = null;
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.BackgroundImage = null;
            this.tbDescription.Font = null;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbName
            // 
            this.tbName.AccessibleDescription = null;
            this.tbName.AccessibleName = null;
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.BackgroundImage = null;
            this.tbName.Font = null;
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // lbThickness
            // 
            this.lbThickness.AccessibleDescription = null;
            this.lbThickness.AccessibleName = null;
            resources.ApplyResources(this.lbThickness, "lbThickness");
            this.lbThickness.Font = null;
            this.lbThickness.Name = "lbThickness";
            // 
            // lblDescription
            // 
            this.lblDescription.AccessibleDescription = null;
            this.lblDescription.AccessibleName = null;
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Font = null;
            this.lblDescription.Name = "lblDescription";
            // 
            // trackBarHorizAngle
            // 
            this.trackBarHorizAngle.AccessibleDescription = null;
            this.trackBarHorizAngle.AccessibleName = null;
            resources.ApplyResources(this.trackBarHorizAngle, "trackBarHorizAngle");
            this.trackBarHorizAngle.BackgroundImage = null;
            this.trackBarHorizAngle.Font = null;
            this.trackBarHorizAngle.LargeChange = 90;
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.TickFrequency = 90;
            this.trackBarHorizAngle.Value = 225;
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // gbDimensions
            // 
            this.gbDimensions.AccessibleDescription = null;
            this.gbDimensions.AccessibleName = null;
            resources.ApplyResources(this.gbDimensions, "gbDimensions");
            this.gbDimensions.BackgroundImage = null;
            this.gbDimensions.Controls.Add(this.lbUnitThickness);
            this.gbDimensions.Controls.Add(this.lbUnitWidth);
            this.gbDimensions.Controls.Add(this.lbUnitLength);
            this.gbDimensions.Controls.Add(this.lbNoFlats);
            this.gbDimensions.Controls.Add(this.nudNoFlats);
            this.gbDimensions.Controls.Add(this.nudLength);
            this.gbDimensions.Controls.Add(this.nudThickness);
            this.gbDimensions.Controls.Add(this.nudWidth);
            this.gbDimensions.Controls.Add(this.lbThickness);
            this.gbDimensions.Controls.Add(this.lbWidth);
            this.gbDimensions.Controls.Add(this.lbLength);
            this.gbDimensions.Font = null;
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.TabStop = false;
            // 
            // lbUnitThickness
            // 
            this.lbUnitThickness.AccessibleDescription = null;
            this.lbUnitThickness.AccessibleName = null;
            resources.ApplyResources(this.lbUnitThickness, "lbUnitThickness");
            this.lbUnitThickness.Font = null;
            this.lbUnitThickness.Name = "lbUnitThickness";
            // 
            // lbUnitWidth
            // 
            this.lbUnitWidth.AccessibleDescription = null;
            this.lbUnitWidth.AccessibleName = null;
            resources.ApplyResources(this.lbUnitWidth, "lbUnitWidth");
            this.lbUnitWidth.Font = null;
            this.lbUnitWidth.Name = "lbUnitWidth";
            // 
            // lbUnitLength
            // 
            this.lbUnitLength.AccessibleDescription = null;
            this.lbUnitLength.AccessibleName = null;
            resources.ApplyResources(this.lbUnitLength, "lbUnitLength");
            this.lbUnitLength.Font = null;
            this.lbUnitLength.Name = "lbUnitLength";
            // 
            // lbNoFlats
            // 
            this.lbNoFlats.AccessibleDescription = null;
            this.lbNoFlats.AccessibleName = null;
            resources.ApplyResources(this.lbNoFlats, "lbNoFlats");
            this.lbNoFlats.Font = null;
            this.lbNoFlats.Name = "lbNoFlats";
            // 
            // nudNoFlats
            // 
            this.nudNoFlats.AccessibleDescription = null;
            this.nudNoFlats.AccessibleName = null;
            resources.ApplyResources(this.nudNoFlats, "nudNoFlats");
            this.nudNoFlats.Font = null;
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
            this.nudNoFlats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoFlats.ValueChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // nudThickness
            // 
            this.nudThickness.AccessibleDescription = null;
            this.nudThickness.AccessibleName = null;
            resources.ApplyResources(this.nudThickness, "nudThickness");
            this.nudThickness.DecimalPlaces = 2;
            this.nudThickness.Font = null;
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
            this.nudThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThickness.ValueChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // nudWidth
            // 
            this.nudWidth.AccessibleDescription = null;
            this.nudWidth.AccessibleName = null;
            resources.ApplyResources(this.nudWidth, "nudWidth");
            this.nudWidth.DecimalPlaces = 1;
            this.nudWidth.Font = null;
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
            this.nudWidth.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.onBundlePropertyChanged);
            // 
            // lbWidth
            // 
            this.lbWidth.AccessibleDescription = null;
            this.lbWidth.AccessibleName = null;
            resources.ApplyResources(this.lbWidth, "lbWidth");
            this.lbWidth.Font = null;
            this.lbWidth.Name = "lbWidth";
            // 
            // lbLength
            // 
            this.lbLength.AccessibleDescription = null;
            this.lbLength.AccessibleName = null;
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Font = null;
            this.lbLength.Name = "lbLength";
            // 
            // bnCancel
            // 
            this.bnCancel.AccessibleDescription = null;
            this.bnCancel.AccessibleName = null;
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.BackgroundImage = null;
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Font = null;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnOk
            // 
            this.bnOk.AccessibleDescription = null;
            this.bnOk.AccessibleName = null;
            resources.ApplyResources(this.bnOk, "bnOk");
            this.bnOk.BackgroundImage = null;
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Font = null;
            this.bnOk.Name = "bnOk";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.AccessibleDescription = null;
            this.pictureBox.AccessibleName = null;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.BackgroundImage = null;
            this.pictureBox.Font = null;
            this.pictureBox.ImageLocation = null;
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // statusStripDef
            // 
            this.statusStripDef.AccessibleDescription = null;
            this.statusStripDef.AccessibleName = null;
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.BackgroundImage = null;
            this.statusStripDef.Font = null;
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.SizingGrip = false;
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.AccessibleDescription = null;
            this.toolStripStatusLabelDef.AccessibleName = null;
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            this.toolStripStatusLabelDef.BackgroundImage = null;
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            // 
            // FormNewBundle
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.statusStripDef);
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
            this.Controls.Add(this.bnOk);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewBundle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormNewBundle_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewBundle_FormClosing);
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
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
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
        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.NumericUpDown nudNoFlats;
        private System.Windows.Forms.Label lbNoFlats;
        private System.Windows.Forms.Label lbUnitWeight;
        private System.Windows.Forms.Label lbUnitThickness;
        private System.Windows.Forms.Label lbUnitWidth;
        private System.Windows.Forms.Label lbUnitLength;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
    }
}