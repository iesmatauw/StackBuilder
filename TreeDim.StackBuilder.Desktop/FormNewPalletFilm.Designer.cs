namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewPalletFilm
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
            this.chkbTransparency = new System.Windows.Forms.CheckBox();
            this.chkbHatching = new System.Windows.Forms.CheckBox();
            this.nudHatchSpacing = new System.Windows.Forms.NumericUpDown();
            this.uLengthHatchSpacing = new System.Windows.Forms.Label();
            this.lbHatchSpacing = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudHatchSpacing)).BeginInit();
            this.SuspendLayout();
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.LightBlue;
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
            "Color",
            "Color"});
            this.cbColor.Location = new System.Drawing.Point(111, 80);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(75, 22);
            this.cbColor.TabIndex = 24;
            // 
            // lbColor
            // 
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(13, 83);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(31, 13);
            this.lbColor.TabIndex = 25;
            this.lbColor.Text = "Color";
            // 
            // chkbTransparency
            // 
            this.chkbTransparency.AutoSize = true;
            this.chkbTransparency.Location = new System.Drawing.Point(16, 118);
            this.chkbTransparency.Name = "chkbTransparency";
            this.chkbTransparency.Size = new System.Drawing.Size(91, 17);
            this.chkbTransparency.TabIndex = 26;
            this.chkbTransparency.Text = "Transparency";
            this.chkbTransparency.UseVisualStyleBackColor = true;
            // 
            // chkbHatching
            // 
            this.chkbHatching.AutoSize = true;
            this.chkbHatching.Location = new System.Drawing.Point(16, 141);
            this.chkbHatching.Name = "chkbHatching";
            this.chkbHatching.Size = new System.Drawing.Size(69, 17);
            this.chkbHatching.TabIndex = 27;
            this.chkbHatching.Text = "Hatching";
            this.chkbHatching.UseVisualStyleBackColor = true;
            this.chkbHatching.CheckedChanged += new System.EventHandler(this.chkbHatching_CheckedChanged);
            // 
            // nudHatchSpacing
            // 
            this.nudHatchSpacing.DecimalPlaces = 2;
            this.nudHatchSpacing.Location = new System.Drawing.Point(111, 162);
            this.nudHatchSpacing.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHatchSpacing.Name = "nudHatchSpacing";
            this.nudHatchSpacing.Size = new System.Drawing.Size(75, 20);
            this.nudHatchSpacing.TabIndex = 28;
            // 
            // uLengthHatchSpacing
            // 
            this.uLengthHatchSpacing.AutoSize = true;
            this.uLengthHatchSpacing.Location = new System.Drawing.Point(193, 166);
            this.uLengthHatchSpacing.Name = "uLengthHatchSpacing";
            this.uLengthHatchSpacing.Size = new System.Drawing.Size(46, 13);
            this.uLengthHatchSpacing.TabIndex = 29;
            this.uLengthHatchSpacing.Text = "uLength";
            // 
            // lbSpacing
            // 
            this.lbHatchSpacing.AutoSize = true;
            this.lbHatchSpacing.Location = new System.Drawing.Point(37, 166);
            this.lbHatchSpacing.Name = "lbSpacing";
            this.lbHatchSpacing.Size = new System.Drawing.Size(46, 13);
            this.lbHatchSpacing.TabIndex = 30;
            this.lbHatchSpacing.Text = "Spacing";
            // 
            // FormNewPalletFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.lbHatchSpacing);
            this.Controls.Add(this.uLengthHatchSpacing);
            this.Controls.Add(this.nudHatchSpacing);
            this.Controls.Add(this.chkbHatching);
            this.Controls.Add(this.chkbTransparency);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.cbColor);
            this.Name = "FormNewPalletFilm";
            this.Text = "Create new pallet film...";
            this.Controls.SetChildIndex(this.cbColor, 0);
            this.Controls.SetChildIndex(this.lbColor, 0);
            this.Controls.SetChildIndex(this.chkbTransparency, 0);
            this.Controls.SetChildIndex(this.chkbHatching, 0);
            this.Controls.SetChildIndex(this.nudHatchSpacing, 0);
            this.Controls.SetChildIndex(this.uLengthHatchSpacing, 0);
            this.Controls.SetChildIndex(this.lbHatchSpacing, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudHatchSpacing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.CheckBox chkbTransparency;
        private System.Windows.Forms.CheckBox chkbHatching;
        private System.Windows.Forms.NumericUpDown nudHatchSpacing;
        private System.Windows.Forms.Label uLengthHatchSpacing;
        private System.Windows.Forms.Label lbHatchSpacing;
    }
}
