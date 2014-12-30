namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewPalletCorners
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
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbThickness = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudThickness = new System.Windows.Forms.NumericUpDown();
            this.uLengthLength = new System.Windows.Forms.Label();
            this.uLengthWidth = new System.Windows.Forms.Label();
            this.uLengthThickness = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lbColor = new System.Windows.Forms.Label();
            this.cbColorCorners = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(12, 98);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(35, 13);
            this.lbWidth.TabIndex = 7;
            this.lbWidth.Text = "Width";
            // 
            // lbThickness
            // 
            this.lbThickness.AutoSize = true;
            this.lbThickness.Location = new System.Drawing.Point(12, 127);
            this.lbThickness.Name = "lbThickness";
            this.lbThickness.Size = new System.Drawing.Size(56, 13);
            this.lbThickness.TabIndex = 8;
            this.lbThickness.Text = "Thickness";
            // 
            // lbLength
            // 
            this.lbLength.AutoSize = true;
            this.lbLength.Location = new System.Drawing.Point(12, 70);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(40, 13);
            this.lbLength.TabIndex = 9;
            this.lbLength.Text = "Length";
            // 
            // nudLength
            // 
            this.nudLength.DecimalPlaces = 2;
            this.nudLength.Location = new System.Drawing.Point(111, 68);
            this.nudLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(66, 20);
            this.nudLength.TabIndex = 10;
            // 
            // nudWidth
            // 
            this.nudWidth.DecimalPlaces = 2;
            this.nudWidth.Location = new System.Drawing.Point(111, 96);
            this.nudWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(66, 20);
            this.nudWidth.TabIndex = 11;
            // 
            // nudThickness
            // 
            this.nudThickness.DecimalPlaces = 2;
            this.nudThickness.Location = new System.Drawing.Point(111, 125);
            this.nudThickness.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudThickness.Name = "nudThickness";
            this.nudThickness.Size = new System.Drawing.Size(66, 20);
            this.nudThickness.TabIndex = 12;
            // 
            // uLengthLength
            // 
            this.uLengthLength.AutoSize = true;
            this.uLengthLength.Location = new System.Drawing.Point(184, 74);
            this.uLengthLength.Name = "uLengthLength";
            this.uLengthLength.Size = new System.Drawing.Size(46, 13);
            this.uLengthLength.TabIndex = 13;
            this.uLengthLength.Text = "uLength";
            // 
            // uLengthWidth
            // 
            this.uLengthWidth.AutoSize = true;
            this.uLengthWidth.Location = new System.Drawing.Point(184, 102);
            this.uLengthWidth.Name = "uLengthWidth";
            this.uLengthWidth.Size = new System.Drawing.Size(46, 13);
            this.uLengthWidth.TabIndex = 14;
            this.uLengthWidth.Text = "uLength";
            // 
            // uLengthThickness
            // 
            this.uLengthThickness.AutoSize = true;
            this.uLengthThickness.Location = new System.Drawing.Point(184, 127);
            this.uLengthThickness.Name = "uLengthThickness";
            this.uLengthThickness.Size = new System.Drawing.Size(46, 13);
            this.uLengthThickness.TabIndex = 15;
            this.uLengthThickness.Text = "uLength";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox.Location = new System.Drawing.Point(362, 70);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(210, 255);
            this.pictureBox.TabIndex = 20;
            this.pictureBox.TabStop = false;
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(13, 160);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(31, 13);
            this.lbColor.TabIndex = 21;
            this.lbColor.Text = "Color";
            // 
            // cbColorCorners
            // 
            this.cbColorCorners.Color = System.Drawing.Color.Chocolate;
            this.cbColorCorners.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColorCorners.DropDownHeight = 1;
            this.cbColorCorners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorCorners.DropDownWidth = 1;
            this.cbColorCorners.IntegralHeight = false;
            this.cbColorCorners.ItemHeight = 16;
            this.cbColorCorners.Items.AddRange(new object[] {
            "Color"});
            this.cbColorCorners.Location = new System.Drawing.Point(111, 155);
            this.cbColorCorners.Name = "cbColorCorners";
            this.cbColorCorners.Size = new System.Drawing.Size(66, 22);
            this.cbColorCorners.TabIndex = 22;
            // 
            // FormNewPalletCorners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.cbColorCorners);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.uLengthThickness);
            this.Controls.Add(this.uLengthWidth);
            this.Controls.Add(this.uLengthLength);
            this.Controls.Add(this.nudThickness);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.nudLength);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.lbThickness);
            this.Controls.Add(this.lbWidth);
            this.Name = "FormNewPalletCorners";
            this.Text = "Create new pallet corner protector...";
            this.Controls.SetChildIndex(this.lbWidth, 0);
            this.Controls.SetChildIndex(this.lbThickness, 0);
            this.Controls.SetChildIndex(this.lbLength, 0);
            this.Controls.SetChildIndex(this.nudLength, 0);
            this.Controls.SetChildIndex(this.nudWidth, 0);
            this.Controls.SetChildIndex(this.nudThickness, 0);
            this.Controls.SetChildIndex(this.uLengthLength, 0);
            this.Controls.SetChildIndex(this.uLengthWidth, 0);
            this.Controls.SetChildIndex(this.uLengthThickness, 0);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            this.Controls.SetChildIndex(this.lbColor, 0);
            this.Controls.SetChildIndex(this.cbColorCorners, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbThickness;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.NumericUpDown nudThickness;
        private System.Windows.Forms.Label uLengthLength;
        private System.Windows.Forms.Label uLengthWidth;
        private System.Windows.Forms.Label uLengthThickness;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lbColor;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColorCorners;
    }
}
