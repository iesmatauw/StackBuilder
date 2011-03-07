namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewInterlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewInterlayer));
            this.bnOk = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.nudThickness = new System.Windows.Forms.NumericUpDown();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.lbUnitThickness = new System.Windows.Forms.Label();
            this.lbUnitWidth = new System.Windows.Forms.Label();
            this.lbUnitLength = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lbThickness = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.lbWeight = new System.Windows.Forms.Label();
            this.gbWeight = new System.Windows.Forms.GroupBox();
            this.lbUnitWeight = new System.Windows.Forms.Label();
            this.gbColor = new System.Windows.Forms.GroupBox();
            this.trackBarHorizAngle = new System.Windows.Forms.TrackBar();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).BeginInit();
            this.gbDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            this.gbWeight.SuspendLayout();
            this.gbColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.statusStripDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnOk
            // 
            resources.ApplyResources(this.bnOk, "bnOk");
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Name = "bnOk";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
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
            // nudLength
            // 
            resources.ApplyResources(this.nudLength, "nudLength");
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
            1,
            0,
            0,
            0});
            this.nudLength.ValueChanged += new System.EventHandler(this.onInterlayerPropertyChanged);
            // 
            // nudThickness
            // 
            resources.ApplyResources(this.nudThickness, "nudThickness");
            this.nudThickness.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThickness.Name = "nudThickness";
            this.nudThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThickness.ValueChanged += new System.EventHandler(this.onInterlayerPropertyChanged);
            // 
            // gbDimensions
            // 
            this.gbDimensions.Controls.Add(this.lbUnitThickness);
            this.gbDimensions.Controls.Add(this.lbUnitWidth);
            this.gbDimensions.Controls.Add(this.lbUnitLength);
            this.gbDimensions.Controls.Add(this.nudLength);
            this.gbDimensions.Controls.Add(this.nudThickness);
            this.gbDimensions.Controls.Add(this.nudWidth);
            this.gbDimensions.Controls.Add(this.lbThickness);
            this.gbDimensions.Controls.Add(this.lbWidth);
            this.gbDimensions.Controls.Add(this.lbLength);
            resources.ApplyResources(this.gbDimensions, "gbDimensions");
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.TabStop = false;
            // 
            // lbUnitThickness
            // 
            resources.ApplyResources(this.lbUnitThickness, "lbUnitThickness");
            this.lbUnitThickness.Name = "lbUnitThickness";
            // 
            // lbUnitWidth
            // 
            resources.ApplyResources(this.lbUnitWidth, "lbUnitWidth");
            this.lbUnitWidth.Name = "lbUnitWidth";
            // 
            // lbUnitLength
            // 
            resources.ApplyResources(this.lbUnitLength, "lbUnitLength");
            this.lbUnitLength.Name = "lbUnitLength";
            // 
            // nudWidth
            // 
            resources.ApplyResources(this.nudWidth, "nudWidth");
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
            1,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.onInterlayerPropertyChanged);
            // 
            // lbThickness
            // 
            resources.ApplyResources(this.lbThickness, "lbThickness");
            this.lbThickness.Name = "lbThickness";
            // 
            // lbWidth
            // 
            resources.ApplyResources(this.lbWidth, "lbWidth");
            this.lbWidth.Name = "lbWidth";
            // 
            // lbLength
            // 
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Name = "lbLength";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.Beige;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
            resources.ApplyResources(this.cbColor, "cbColor");
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
            resources.GetString("cbColor.Items14")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onInterlayerPropertyChanged);
            // 
            // nudWeight
            // 
            this.nudWeight.DecimalPlaces = 3;
            resources.ApplyResources(this.nudWeight, "nudWeight");
            this.nudWeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.ValueChanged += new System.EventHandler(this.onInterlayerPropertyChanged);
            // 
            // lbWeight
            // 
            resources.ApplyResources(this.lbWeight, "lbWeight");
            this.lbWeight.Name = "lbWeight";
            // 
            // gbWeight
            // 
            this.gbWeight.Controls.Add(this.lbUnitWeight);
            this.gbWeight.Controls.Add(this.nudWeight);
            this.gbWeight.Controls.Add(this.lbWeight);
            resources.ApplyResources(this.gbWeight, "gbWeight");
            this.gbWeight.Name = "gbWeight";
            this.gbWeight.TabStop = false;
            // 
            // lbUnitWeight
            // 
            resources.ApplyResources(this.lbUnitWeight, "lbUnitWeight");
            this.lbUnitWeight.Name = "lbUnitWeight";
            // 
            // gbColor
            // 
            this.gbColor.Controls.Add(this.cbColor);
            this.gbColor.Controls.Add(this.label1);
            resources.ApplyResources(this.gbColor, "gbColor");
            this.gbColor.Name = "gbColor";
            this.gbColor.TabStop = false;
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
            // FormNewInterlayer
            // 
            this.AcceptButton = this.bnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.trackBarHorizAngle);
            this.Controls.Add(this.gbColor);
            this.Controls.Add(this.gbWeight);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.gbDimensions);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewInterlayer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormNewInterlayer_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewInterlayer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).EndInit();
            this.gbDimensions.ResumeLayout(false);
            this.gbDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            this.gbWeight.ResumeLayout(false);
            this.gbWeight.PerformLayout();
            this.gbColor.ResumeLayout(false);
            this.gbColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.NumericUpDown nudThickness;
        private System.Windows.Forms.GroupBox gbDimensions;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label lbThickness;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.Label lbWeight;
        private System.Windows.Forms.GroupBox gbWeight;
        private System.Windows.Forms.GroupBox gbColor;
        private System.Windows.Forms.TrackBar trackBarHorizAngle;
        private System.Windows.Forms.Label lbUnitWidth;
        private System.Windows.Forms.Label lbUnitLength;
        private System.Windows.Forms.Label lbUnitThickness;
        private System.Windows.Forms.Label lbUnitWeight;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
    }
}