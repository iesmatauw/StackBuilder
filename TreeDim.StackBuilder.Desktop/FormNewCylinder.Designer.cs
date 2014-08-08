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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewCylinder));
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnOK = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.uLengthHeight = new System.Windows.Forms.Label();
            this.uLengthRadius = new System.Windows.Forms.Label();
            this.nudRadius = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.gbWeight = new System.Windows.Forms.GroupBox();
            this.uMassWeight = new System.Windows.Forms.Label();
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
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnOK
            // 
            resources.ApplyResources(this.bnOK, "bnOK");
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Name = "bnOK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.TextChanged += new System.EventHandler(this.onCylinderPropertiesChanged);
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.onCylinderPropertiesChanged);
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // gbDimensions
            // 
            this.gbDimensions.Controls.Add(this.uLengthHeight);
            this.gbDimensions.Controls.Add(this.uLengthRadius);
            this.gbDimensions.Controls.Add(this.nudRadius);
            this.gbDimensions.Controls.Add(this.nudHeight);
            this.gbDimensions.Controls.Add(this.lbHeight);
            this.gbDimensions.Controls.Add(this.lbLength);
            resources.ApplyResources(this.gbDimensions, "gbDimensions");
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.TabStop = false;
            // 
            // uLengthHeight
            // 
            resources.ApplyResources(this.uLengthHeight, "uLengthHeight");
            this.uLengthHeight.Name = "uLengthHeight";
            // 
            // uLengthRadius
            // 
            resources.ApplyResources(this.uLengthRadius, "uLengthRadius");
            this.uLengthRadius.Name = "uLengthRadius";
            // 
            // nudRadius
            // 
            this.nudRadius.DecimalPlaces = 1;
            resources.ApplyResources(this.nudRadius, "nudRadius");
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
            resources.ApplyResources(this.nudHeight, "nudHeight");
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
            this.nudHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.ValueChanged += new System.EventHandler(this.onCylinderPropertiesChanged);
            // 
            // lbHeight
            // 
            resources.ApplyResources(this.lbHeight, "lbHeight");
            this.lbHeight.Name = "lbHeight";
            // 
            // lbLength
            // 
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Name = "lbLength";
            // 
            // gbWeight
            // 
            this.gbWeight.Controls.Add(this.uMassWeight);
            this.gbWeight.Controls.Add(this.nudWeight);
            this.gbWeight.Controls.Add(this.lbWeight);
            resources.ApplyResources(this.gbWeight, "gbWeight");
            this.gbWeight.Name = "gbWeight";
            this.gbWeight.TabStop = false;
            // 
            // uMassWeight
            // 
            resources.ApplyResources(this.uMassWeight, "uMassWeight");
            this.uMassWeight.Name = "uMassWeight";
            // 
            // nudWeight
            // 
            this.nudWeight.DecimalPlaces = 3;
            this.nudWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.nudWeight, "nudWeight");
            this.nudWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            // 
            // lbWeight
            // 
            resources.ApplyResources(this.lbWeight, "lbWeight");
            this.lbWeight.Name = "lbWeight";
            // 
            // trackBarHorizAngle
            // 
            resources.ApplyResources(this.trackBarHorizAngle, "trackBarHorizAngle");
            this.trackBarHorizAngle.LargeChange = 90;
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.TickFrequency = 90;
            this.trackBarHorizAngle.Value = 225;
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.SizingGrip = false;
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            // 
            // gbFaceColor
            // 
            this.gbFaceColor.Controls.Add(this.cbColorWall);
            this.gbFaceColor.Controls.Add(this.lbWallColor);
            this.gbFaceColor.Controls.Add(this.cbColorTop);
            this.gbFaceColor.Controls.Add(this.lbTop);
            resources.ApplyResources(this.gbFaceColor, "gbFaceColor");
            this.gbFaceColor.Name = "gbFaceColor";
            this.gbFaceColor.TabStop = false;
            // 
            // cbColorWall
            // 
            this.cbColorWall.Color = System.Drawing.Color.LightSkyBlue;
            this.cbColorWall.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColorWall.DropDownHeight = 1;
            this.cbColorWall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorWall.DropDownWidth = 1;
            resources.ApplyResources(this.cbColorWall, "cbColorWall");
            this.cbColorWall.Items.AddRange(new object[] {
            resources.GetString("cbColorWall.Items"),
            resources.GetString("cbColorWall.Items1"),
            resources.GetString("cbColorWall.Items2"),
            resources.GetString("cbColorWall.Items3"),
            resources.GetString("cbColorWall.Items4"),
            resources.GetString("cbColorWall.Items5"),
            resources.GetString("cbColorWall.Items6"),
            resources.GetString("cbColorWall.Items7"),
            resources.GetString("cbColorWall.Items8"),
            resources.GetString("cbColorWall.Items9"),
            resources.GetString("cbColorWall.Items10"),
            resources.GetString("cbColorWall.Items11"),
            resources.GetString("cbColorWall.Items12"),
            resources.GetString("cbColorWall.Items13"),
            resources.GetString("cbColorWall.Items14"),
            resources.GetString("cbColorWall.Items15"),
            resources.GetString("cbColorWall.Items16"),
            resources.GetString("cbColorWall.Items17"),
            resources.GetString("cbColorWall.Items18"),
            resources.GetString("cbColorWall.Items19"),
            resources.GetString("cbColorWall.Items20"),
            resources.GetString("cbColorWall.Items21"),
            resources.GetString("cbColorWall.Items22"),
            resources.GetString("cbColorWall.Items23"),
            resources.GetString("cbColorWall.Items24"),
            resources.GetString("cbColorWall.Items25"),
            resources.GetString("cbColorWall.Items26"),
            resources.GetString("cbColorWall.Items27"),
            resources.GetString("cbColorWall.Items28"),
            resources.GetString("cbColorWall.Items29"),
            resources.GetString("cbColorWall.Items30"),
            resources.GetString("cbColorWall.Items31"),
            resources.GetString("cbColorWall.Items32"),
            resources.GetString("cbColorWall.Items33"),
            resources.GetString("cbColorWall.Items34"),
            resources.GetString("cbColorWall.Items35"),
            resources.GetString("cbColorWall.Items36"),
            resources.GetString("cbColorWall.Items37"),
            resources.GetString("cbColorWall.Items38"),
            resources.GetString("cbColorWall.Items39"),
            resources.GetString("cbColorWall.Items40"),
            resources.GetString("cbColorWall.Items41"),
            resources.GetString("cbColorWall.Items42"),
            resources.GetString("cbColorWall.Items43"),
            resources.GetString("cbColorWall.Items44"),
            resources.GetString("cbColorWall.Items45"),
            resources.GetString("cbColorWall.Items46"),
            resources.GetString("cbColorWall.Items47"),
            resources.GetString("cbColorWall.Items48"),
            resources.GetString("cbColorWall.Items49"),
            resources.GetString("cbColorWall.Items50"),
            resources.GetString("cbColorWall.Items51"),
            resources.GetString("cbColorWall.Items52"),
            resources.GetString("cbColorWall.Items53"),
            resources.GetString("cbColorWall.Items54"),
            resources.GetString("cbColorWall.Items55"),
            resources.GetString("cbColorWall.Items56"),
            resources.GetString("cbColorWall.Items57"),
            resources.GetString("cbColorWall.Items58"),
            resources.GetString("cbColorWall.Items59"),
            resources.GetString("cbColorWall.Items60"),
            resources.GetString("cbColorWall.Items61"),
            resources.GetString("cbColorWall.Items62"),
            resources.GetString("cbColorWall.Items63"),
            resources.GetString("cbColorWall.Items64"),
            resources.GetString("cbColorWall.Items65"),
            resources.GetString("cbColorWall.Items66"),
            resources.GetString("cbColorWall.Items67"),
            resources.GetString("cbColorWall.Items68"),
            resources.GetString("cbColorWall.Items69"),
            resources.GetString("cbColorWall.Items70")});
            this.cbColorWall.Name = "cbColorWall";
            this.cbColorWall.SelectedColorChanged += new System.EventHandler(this.onCylinderPropertiesChanged);
            // 
            // lbWallColor
            // 
            resources.ApplyResources(this.lbWallColor, "lbWallColor");
            this.lbWallColor.Name = "lbWallColor";
            // 
            // cbColorTop
            // 
            this.cbColorTop.Color = System.Drawing.Color.Gray;
            this.cbColorTop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColorTop.DropDownHeight = 1;
            this.cbColorTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorTop.DropDownWidth = 1;
            resources.ApplyResources(this.cbColorTop, "cbColorTop");
            this.cbColorTop.Items.AddRange(new object[] {
            resources.GetString("cbColorTop.Items"),
            resources.GetString("cbColorTop.Items1"),
            resources.GetString("cbColorTop.Items2"),
            resources.GetString("cbColorTop.Items3"),
            resources.GetString("cbColorTop.Items4"),
            resources.GetString("cbColorTop.Items5"),
            resources.GetString("cbColorTop.Items6"),
            resources.GetString("cbColorTop.Items7"),
            resources.GetString("cbColorTop.Items8"),
            resources.GetString("cbColorTop.Items9"),
            resources.GetString("cbColorTop.Items10"),
            resources.GetString("cbColorTop.Items11"),
            resources.GetString("cbColorTop.Items12"),
            resources.GetString("cbColorTop.Items13"),
            resources.GetString("cbColorTop.Items14"),
            resources.GetString("cbColorTop.Items15"),
            resources.GetString("cbColorTop.Items16"),
            resources.GetString("cbColorTop.Items17"),
            resources.GetString("cbColorTop.Items18"),
            resources.GetString("cbColorTop.Items19"),
            resources.GetString("cbColorTop.Items20"),
            resources.GetString("cbColorTop.Items21"),
            resources.GetString("cbColorTop.Items22"),
            resources.GetString("cbColorTop.Items23"),
            resources.GetString("cbColorTop.Items24"),
            resources.GetString("cbColorTop.Items25"),
            resources.GetString("cbColorTop.Items26"),
            resources.GetString("cbColorTop.Items27"),
            resources.GetString("cbColorTop.Items28"),
            resources.GetString("cbColorTop.Items29"),
            resources.GetString("cbColorTop.Items30"),
            resources.GetString("cbColorTop.Items31"),
            resources.GetString("cbColorTop.Items32"),
            resources.GetString("cbColorTop.Items33"),
            resources.GetString("cbColorTop.Items34"),
            resources.GetString("cbColorTop.Items35"),
            resources.GetString("cbColorTop.Items36"),
            resources.GetString("cbColorTop.Items37"),
            resources.GetString("cbColorTop.Items38"),
            resources.GetString("cbColorTop.Items39"),
            resources.GetString("cbColorTop.Items40"),
            resources.GetString("cbColorTop.Items41"),
            resources.GetString("cbColorTop.Items42"),
            resources.GetString("cbColorTop.Items43"),
            resources.GetString("cbColorTop.Items44"),
            resources.GetString("cbColorTop.Items45"),
            resources.GetString("cbColorTop.Items46"),
            resources.GetString("cbColorTop.Items47"),
            resources.GetString("cbColorTop.Items48"),
            resources.GetString("cbColorTop.Items49"),
            resources.GetString("cbColorTop.Items50"),
            resources.GetString("cbColorTop.Items51"),
            resources.GetString("cbColorTop.Items52"),
            resources.GetString("cbColorTop.Items53"),
            resources.GetString("cbColorTop.Items54"),
            resources.GetString("cbColorTop.Items55"),
            resources.GetString("cbColorTop.Items56"),
            resources.GetString("cbColorTop.Items57"),
            resources.GetString("cbColorTop.Items58"),
            resources.GetString("cbColorTop.Items59"),
            resources.GetString("cbColorTop.Items60"),
            resources.GetString("cbColorTop.Items61"),
            resources.GetString("cbColorTop.Items62"),
            resources.GetString("cbColorTop.Items63"),
            resources.GetString("cbColorTop.Items64"),
            resources.GetString("cbColorTop.Items65"),
            resources.GetString("cbColorTop.Items66"),
            resources.GetString("cbColorTop.Items67"),
            resources.GetString("cbColorTop.Items68"),
            resources.GetString("cbColorTop.Items69")});
            this.cbColorTop.Name = "cbColorTop";
            this.cbColorTop.SelectedColorChanged += new System.EventHandler(this.onCylinderPropertiesChanged);
            // 
            // lbTop
            // 
            resources.ApplyResources(this.lbTop, "lbTop");
            this.lbTop.Name = "lbTop";
            // 
            // FormNewCylinder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private System.Windows.Forms.Label uLengthHeight;
        private System.Windows.Forms.Label uLengthRadius;
        private System.Windows.Forms.NumericUpDown nudRadius;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.GroupBox gbWeight;
        private System.Windows.Forms.Label uMassWeight;
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