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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.trackBarHorizAngle = new System.Windows.Forms.TrackBar();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.gbDimensions.SuspendLayout();
            this.gbFaceColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeightOnTop)).BeginInit();
            this.gbWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // bnAccept
            // 
            this.bnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnAccept.Location = new System.Drawing.Point(393, 6);
            this.bnAccept.Name = "bnAccept";
            this.bnAccept.Size = new System.Drawing.Size(75, 23);
            this.bnAccept.TabIndex = 0;
            this.bnAccept.Text = "&Ok";
            this.bnAccept.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(393, 32);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "&Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
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
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(10, 49);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(35, 13);
            this.lbWidth.TabIndex = 3;
            this.lbWidth.Text = "Width";
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(10, 76);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(38, 13);
            this.lbHeight.TabIndex = 4;
            this.lbHeight.Text = "Height";
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
            1,
            0,
            0,
            0});
            this.nudLength.ValueChanged += new System.EventHandler(this.onBoxPropertyChanged);
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
            1,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.onBoxPropertyChanged);
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(161, 76);
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
            this.nudHeight.Size = new System.Drawing.Size(75, 20);
            this.nudHeight.TabIndex = 7;
            this.nudHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.ValueChanged += new System.EventHandler(this.onBoxPropertyChanged);
            // 
            // lbFace
            // 
            this.lbFace.AutoSize = true;
            this.lbFace.Location = new System.Drawing.Point(6, 23);
            this.lbFace.Name = "lbFace";
            this.lbFace.Size = new System.Drawing.Size(31, 13);
            this.lbFace.TabIndex = 9;
            this.lbFace.Text = "Face";
            // 
            // gbDimensions
            // 
            this.gbDimensions.Controls.Add(this.nudLength);
            this.gbDimensions.Controls.Add(this.nudHeight);
            this.gbDimensions.Controls.Add(this.nudWidth);
            this.gbDimensions.Controls.Add(this.lbHeight);
            this.gbDimensions.Controls.Add(this.lbWidth);
            this.gbDimensions.Controls.Add(this.lbLength);
            this.gbDimensions.Location = new System.Drawing.Point(6, 62);
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.Size = new System.Drawing.Size(246, 112);
            this.gbDimensions.TabIndex = 10;
            this.gbDimensions.TabStop = false;
            this.gbDimensions.Text = "Dimentions";
            // 
            // cbFace
            // 
            this.cbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFace.FormattingEnabled = true;
            this.cbFace.Items.AddRange(new object[] {
            "Rear",
            "Front",
            "Right",
            "Left",
            "Bottom",
            "Top"});
            this.cbFace.Location = new System.Drawing.Point(58, 20);
            this.cbFace.Name = "cbFace";
            this.cbFace.Size = new System.Drawing.Size(96, 21);
            this.cbFace.TabIndex = 11;
            this.cbFace.SelectedIndexChanged += new System.EventHandler(this.onSelectedFaceChanged);
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.Chocolate;
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownHeight = 1;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.DropDownWidth = 1;
            this.cbColor.IntegralHeight = false;
            this.cbColor.ItemHeight = 16;
            this.cbColor.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color"});
            this.cbColor.Location = new System.Drawing.Point(161, 20);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(75, 22);
            this.cbColor.TabIndex = 12;
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.onFaceColorChanged);
            // 
            // gbFaceColor
            // 
            this.gbFaceColor.Controls.Add(this.cbColor);
            this.gbFaceColor.Controls.Add(this.cbFace);
            this.gbFaceColor.Controls.Add(this.lbFace);
            this.gbFaceColor.Location = new System.Drawing.Point(6, 186);
            this.gbFaceColor.Name = "gbFaceColor";
            this.gbFaceColor.Size = new System.Drawing.Size(246, 51);
            this.gbFaceColor.TabIndex = 13;
            this.gbFaceColor.TabStop = false;
            this.gbFaceColor.Text = "Face color";
            // 
            // lbWeight
            // 
            this.lbWeight.AutoSize = true;
            this.lbWeight.Location = new System.Drawing.Point(10, 24);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(41, 13);
            this.lbWeight.TabIndex = 14;
            this.lbWeight.Text = "Weight";
            // 
            // lbWeightOnTop
            // 
            this.lbWeightOnTop.AutoSize = true;
            this.lbWeightOnTop.Location = new System.Drawing.Point(10, 51);
            this.lbWeightOnTop.Name = "lbWeightOnTop";
            this.lbWeightOnTop.Size = new System.Drawing.Size(123, 13);
            this.lbWeightOnTop.TabIndex = 15;
            this.lbWeightOnTop.Text = "Admissible weight on top";
            // 
            // nudWeight
            // 
            this.nudWeight.Location = new System.Drawing.Point(151, 21);
            this.nudWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(75, 20);
            this.nudWeight.TabIndex = 16;
            // 
            // nudWeightOnTop
            // 
            this.nudWeightOnTop.Location = new System.Drawing.Point(151, 51);
            this.nudWeightOnTop.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeightOnTop.Name = "nudWeightOnTop";
            this.nudWeightOnTop.Size = new System.Drawing.Size(75, 20);
            this.nudWeightOnTop.TabIndex = 17;
            // 
            // gbWeight
            // 
            this.gbWeight.Controls.Add(this.nudWeightOnTop);
            this.gbWeight.Controls.Add(this.nudWeight);
            this.gbWeight.Controls.Add(this.lbWeightOnTop);
            this.gbWeight.Controls.Add(this.lbWeight);
            this.gbWeight.Location = new System.Drawing.Point(6, 249);
            this.gbWeight.Name = "gbWeight";
            this.gbWeight.Size = new System.Drawing.Size(245, 81);
            this.gbWeight.TabIndex = 18;
            this.gbWeight.TabStop = false;
            this.gbWeight.Text = "Weight";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(259, 69);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(210, 210);
            this.pictureBox.TabIndex = 19;
            this.pictureBox.TabStop = false;
            // 
            // trackBarHorizAngle
            // 
            this.trackBarHorizAngle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarHorizAngle.LargeChange = 90;
            this.trackBarHorizAngle.Location = new System.Drawing.Point(260, 286);
            this.trackBarHorizAngle.Maximum = 360;
            this.trackBarHorizAngle.Name = "trackBarHorizAngle";
            this.trackBarHorizAngle.Size = new System.Drawing.Size(208, 45);
            this.trackBarHorizAngle.TabIndex = 20;
            this.trackBarHorizAngle.TickFrequency = 90;
            this.trackBarHorizAngle.ValueChanged += new System.EventHandler(this.onHorizAngleChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 32);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 22;
            this.lblDescription.Text = "Description";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(99, 6);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(143, 20);
            this.tbName.TabIndex = 23;
            this.tbName.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(99, 32);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(266, 20);
            this.tbDescription.TabIndex = 24;
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // FormNewBox
            // 
            this.AcceptButton = this.bnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(480, 339);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Create new Box...";
            this.Load += new System.EventHandler(this.FormNewBox_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHorizAngle)).EndInit();
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