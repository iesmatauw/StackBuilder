namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewBox));
            this.bnAccept = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbLength = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.lbFace = new System.Windows.Forms.Label();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.cbFace = new System.Windows.Forms.ComboBox();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.gbFaceColor = new System.Windows.Forms.GroupBox();
            this.lbWeight = new System.Windows.Forms.Label();
            this.lbWeightOnTop = new System.Windows.Forms.Label();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.nudWeightOnTop = new System.Windows.Forms.NumericUpDown();
            this.gbWeight = new System.Windows.Forms.GroupBox();
            this.trackBarHorizAngle = new System.Windows.Forms.TrackBar();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.gbDimensions.SuspendLayout();
            this.gbFaceColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeightOnTop)).BeginInit();
            this.gbWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bnAccept
            // 
            this.bnAccept.AccessibleDescription = null;
            this.bnAccept.AccessibleName = null;
            resources.ApplyResources(this.bnAccept, "bnAccept");
            this.bnAccept.BackgroundImage = null;
            this.bnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnAccept.Font = null;
            this.bnAccept.Name = "bnAccept";
            this.bnAccept.UseVisualStyleBackColor = true;
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
            // lbLength
            // 
            this.lbLength.AccessibleDescription = null;
            this.lbLength.AccessibleName = null;
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Font = null;
            this.lbLength.Name = "lbLength";
            // 
            // lbWidth
            // 
            this.lbWidth.AccessibleDescription = null;
            this.lbWidth.AccessibleName = null;
            resources.ApplyResources(this.lbWidth, "lbWidth");
            this.lbWidth.Font = null;
            this.lbWidth.Name = "lbWidth";
            // 
            // lbHeight
            // 
            this.lbHeight.AccessibleDescription = null;
            this.lbHeight.AccessibleName = null;
            resources.ApplyResources(this.lbHeight, "lbHeight");
            this.lbHeight.Font = null;
            this.lbHeight.Name = "lbHeight";
            // 
            // nudLength
            // 
            this.nudLength.AccessibleDescription = null;
            this.nudLength.AccessibleName = null;
            resources.ApplyResources(this.nudLength, "nudLength");
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
            1,
            0,
            0,
            0});
            this.nudLength.ValueChanged += new System.EventHandler(this.onBoxPropertyChanged);
            // 
            // nudWidth
            // 
            this.nudWidth.AccessibleDescription = null;
            this.nudWidth.AccessibleName = null;
            resources.ApplyResources(this.nudWidth, "nudWidth");
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
            1,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.onBoxPropertyChanged);
            // 
            // nudHeight
            // 
            this.nudHeight.AccessibleDescription = null;
            this.nudHeight.AccessibleName = null;
            resources.ApplyResources(this.nudHeight, "nudHeight");
            this.nudHeight.Font = null;
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
            this.nudHeight.ValueChanged += new System.EventHandler(this.onBoxPropertyChanged);
            // 
            // lbFace
            // 
            this.lbFace.AccessibleDescription = null;
            this.lbFace.AccessibleName = null;
            resources.ApplyResources(this.lbFace, "lbFace");
            this.lbFace.Font = null;
            this.lbFace.Name = "lbFace";
            // 
            // gbDimensions
            // 
            this.gbDimensions.AccessibleDescription = null;
            this.gbDimensions.AccessibleName = null;
            resources.ApplyResources(this.gbDimensions, "gbDimensions");
            this.gbDimensions.BackgroundImage = null;
            this.gbDimensions.Controls.Add(this.nudLength);
            this.gbDimensions.Controls.Add(this.nudHeight);
            this.gbDimensions.Controls.Add(this.nudWidth);
            this.gbDimensions.Controls.Add(this.lbHeight);
            this.gbDimensions.Controls.Add(this.lbWidth);
            this.gbDimensions.Controls.Add(this.lbLength);
            this.gbDimensions.Font = null;
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.TabStop = false;
            // 
            // cbFace
            // 
            this.cbFace.AccessibleDescription = null;
            this.cbFace.AccessibleName = null;
            resources.ApplyResources(this.cbFace, "cbFace");
            this.cbFace.BackgroundImage = null;
            this.cbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFace.Font = null;
            this.cbFace.FormattingEnabled = true;
            this.cbFace.Items.AddRange(new object[] {
            resources.GetString("cbFace.Items"),
            resources.GetString("cbFace.Items1"),
            resources.GetString("cbFace.Items2"),
            resources.GetString("cbFace.Items3"),
            resources.GetString("cbFace.Items4"),
            resources.GetString("cbFace.Items5")});
            this.cbFace.Name = "cbFace";
            this.cbFace.SelectedIndexChanged += new System.EventHandler(this.onSelectedFaceChanged);
            // 
            // cbColor
            // 
            this.cbColor.AccessibleDescription = null;
            this.cbColor.AccessibleName = null;
            resources.ApplyResources(this.cbColor, "cbColor");
            this.cbColor.BackgroundImage = null;
            this.cbColor.Color = System.Drawing.Color.Chocolate;
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
            resources.GetString("cbColor.Items9")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onFaceColorChanged);
            // 
            // gbFaceColor
            // 
            this.gbFaceColor.AccessibleDescription = null;
            this.gbFaceColor.AccessibleName = null;
            resources.ApplyResources(this.gbFaceColor, "gbFaceColor");
            this.gbFaceColor.BackgroundImage = null;
            this.gbFaceColor.Controls.Add(this.cbColor);
            this.gbFaceColor.Controls.Add(this.cbFace);
            this.gbFaceColor.Controls.Add(this.lbFace);
            this.gbFaceColor.Font = null;
            this.gbFaceColor.Name = "gbFaceColor";
            this.gbFaceColor.TabStop = false;
            // 
            // lbWeight
            // 
            this.lbWeight.AccessibleDescription = null;
            this.lbWeight.AccessibleName = null;
            resources.ApplyResources(this.lbWeight, "lbWeight");
            this.lbWeight.Font = null;
            this.lbWeight.Name = "lbWeight";
            // 
            // lbWeightOnTop
            // 
            this.lbWeightOnTop.AccessibleDescription = null;
            this.lbWeightOnTop.AccessibleName = null;
            resources.ApplyResources(this.lbWeightOnTop, "lbWeightOnTop");
            this.lbWeightOnTop.Font = null;
            this.lbWeightOnTop.Name = "lbWeightOnTop";
            // 
            // nudWeight
            // 
            this.nudWeight.AccessibleDescription = null;
            this.nudWeight.AccessibleName = null;
            resources.ApplyResources(this.nudWeight, "nudWeight");
            this.nudWeight.Font = null;
            this.nudWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            // 
            // nudWeightOnTop
            // 
            this.nudWeightOnTop.AccessibleDescription = null;
            this.nudWeightOnTop.AccessibleName = null;
            resources.ApplyResources(this.nudWeightOnTop, "nudWeightOnTop");
            this.nudWeightOnTop.Font = null;
            this.nudWeightOnTop.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeightOnTop.Name = "nudWeightOnTop";
            // 
            // gbWeight
            // 
            this.gbWeight.AccessibleDescription = null;
            this.gbWeight.AccessibleName = null;
            resources.ApplyResources(this.gbWeight, "gbWeight");
            this.gbWeight.BackgroundImage = null;
            this.gbWeight.Controls.Add(this.nudWeightOnTop);
            this.gbWeight.Controls.Add(this.nudWeight);
            this.gbWeight.Controls.Add(this.lbWeightOnTop);
            this.gbWeight.Controls.Add(this.lbWeight);
            this.gbWeight.Font = null;
            this.gbWeight.Name = "gbWeight";
            this.gbWeight.TabStop = false;
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
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // lblName
            // 
            this.lblName.AccessibleDescription = null;
            this.lblName.AccessibleName = null;
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Font = null;
            this.lblName.Name = "lblName";
            // 
            // lblDescription
            // 
            this.lblDescription.AccessibleDescription = null;
            this.lblDescription.AccessibleName = null;
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Font = null;
            this.lblDescription.Name = "lblDescription";
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
            // FormNewBox
            // 
            this.AcceptButton = this.bnAccept;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.trackBarHorizAngle);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.gbWeight);
            this.Controls.Add(this.gbFaceColor);
            this.Controls.Add(this.gbDimensions);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnAccept);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormNewBox_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewBox_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            this.gbDimensions.ResumeLayout(false);
            this.gbDimensions.PerformLayout();
            this.gbFaceColor.ResumeLayout(false);
            this.gbFaceColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeightOnTop)).EndInit();
            this.gbWeight.ResumeLayout(false);
            this.gbWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnAccept;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label lbFace;
        private System.Windows.Forms.GroupBox gbDimensions;
        private System.Windows.Forms.ComboBox cbFace;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.GroupBox gbFaceColor;
        private System.Windows.Forms.Label lbWeight;
        private System.Windows.Forms.Label lbWeightOnTop;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.NumericUpDown nudWeightOnTop;
        private System.Windows.Forms.GroupBox gbWeight;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.TrackBar trackBarHorizAngle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
    }
}