namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewPalletCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewPalletCap));
            this.nudCapLength = new System.Windows.Forms.NumericUpDown();
            this.nudCapInnerLength = new System.Windows.Forms.NumericUpDown();
            this.nudCapWidth = new System.Windows.Forms.NumericUpDown();
            this.nudCapInnerWidth = new System.Windows.Forms.NumericUpDown();
            this.nudCapHeight = new System.Windows.Forms.NumericUpDown();
            this.nudCapInnerHeight = new System.Windows.Forms.NumericUpDown();
            this.nudCapWeight = new System.Windows.Forms.NumericUpDown();
            this.lbLength = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbWeight = new System.Windows.Forms.Label();
            this.cbColor = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbInsideLength = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbPalletCap = new System.Windows.Forms.PictureBox();
            this.uLengthLength = new System.Windows.Forms.Label();
            this.uLengthWidth = new System.Windows.Forms.Label();
            this.uLengthHeight = new System.Windows.Forms.Label();
            this.uMassWeight = new System.Windows.Forms.Label();
            this.uLengthInsideLength = new System.Windows.Forms.Label();
            this.uLengthInsideWidth = new System.Windows.Forms.Label();
            this.uLengthInsideHeight = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapInnerLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapInnerWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapInnerHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPalletCap)).BeginInit();
            this.SuspendLayout();
            // 
            // nudCapLength
            // 
            this.nudCapLength.DecimalPlaces = 2;
            resources.ApplyResources(this.nudCapLength, "nudCapLength");
            this.nudCapLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCapLength.Name = "nudCapLength";
            this.nudCapLength.ValueChanged += new System.EventHandler(this.UpdateThicknesses);
            // 
            // nudCapInnerLength
            // 
            this.nudCapInnerLength.DecimalPlaces = 2;
            resources.ApplyResources(this.nudCapInnerLength, "nudCapInnerLength");
            this.nudCapInnerLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCapInnerLength.Name = "nudCapInnerLength";
            this.nudCapInnerLength.ValueChanged += new System.EventHandler(this.UpdateThicknesses);
            // 
            // nudCapWidth
            // 
            this.nudCapWidth.DecimalPlaces = 2;
            resources.ApplyResources(this.nudCapWidth, "nudCapWidth");
            this.nudCapWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCapWidth.Name = "nudCapWidth";
            this.nudCapWidth.ValueChanged += new System.EventHandler(this.UpdateThicknesses);
            // 
            // nudCapInnerWidth
            // 
            this.nudCapInnerWidth.DecimalPlaces = 2;
            resources.ApplyResources(this.nudCapInnerWidth, "nudCapInnerWidth");
            this.nudCapInnerWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCapInnerWidth.Name = "nudCapInnerWidth";
            this.nudCapInnerWidth.ValueChanged += new System.EventHandler(this.UpdateThicknesses);
            // 
            // nudCapHeight
            // 
            this.nudCapHeight.DecimalPlaces = 2;
            resources.ApplyResources(this.nudCapHeight, "nudCapHeight");
            this.nudCapHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCapHeight.Name = "nudCapHeight";
            this.nudCapHeight.ValueChanged += new System.EventHandler(this.UpdateThicknesses);
            // 
            // nudCapInnerHeight
            // 
            this.nudCapInnerHeight.DecimalPlaces = 2;
            resources.ApplyResources(this.nudCapInnerHeight, "nudCapInnerHeight");
            this.nudCapInnerHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCapInnerHeight.Name = "nudCapInnerHeight";
            this.nudCapInnerHeight.ValueChanged += new System.EventHandler(this.UpdateThicknesses);
            // 
            // nudCapWeight
            // 
            this.nudCapWeight.DecimalPlaces = 2;
            resources.ApplyResources(this.nudCapWeight, "nudCapWeight");
            this.nudCapWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCapWeight.Name = "nudCapWeight";
            // 
            // lbLength
            // 
            resources.ApplyResources(this.lbLength, "lbLength");
            this.lbLength.Name = "lbLength";
            // 
            // lbWidth
            // 
            resources.ApplyResources(this.lbWidth, "lbWidth");
            this.lbWidth.Name = "lbWidth";
            // 
            // lbHeight
            // 
            resources.ApplyResources(this.lbHeight, "lbHeight");
            this.lbHeight.Name = "lbHeight";
            // 
            // lbWeight
            // 
            resources.ApplyResources(this.lbWeight, "lbWeight");
            this.lbWeight.Name = "lbWeight";
            // 
            // cbColor
            // 
            this.cbColor.Color = System.Drawing.Color.Chocolate;
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
            resources.GetString("cbColor.Items10")});
            this.cbColor.Name = "cbColor";
            this.cbColor.SelectedColorChanged += new System.EventHandler(this.cbColor_SelectedColorChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbInsideLength
            // 
            resources.ApplyResources(this.lbInsideLength, "lbInsideLength");
            this.lbInsideLength.Name = "lbInsideLength";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // pbPalletCap
            // 
            resources.ApplyResources(this.pbPalletCap, "pbPalletCap");
            this.pbPalletCap.Name = "pbPalletCap";
            this.pbPalletCap.TabStop = false;
            // 
            // uLengthLength
            // 
            resources.ApplyResources(this.uLengthLength, "uLengthLength");
            this.uLengthLength.Name = "uLengthLength";
            // 
            // uLengthWidth
            // 
            resources.ApplyResources(this.uLengthWidth, "uLengthWidth");
            this.uLengthWidth.Name = "uLengthWidth";
            // 
            // uLengthHeight
            // 
            resources.ApplyResources(this.uLengthHeight, "uLengthHeight");
            this.uLengthHeight.Name = "uLengthHeight";
            // 
            // uMassWeight
            // 
            resources.ApplyResources(this.uMassWeight, "uMassWeight");
            this.uMassWeight.Name = "uMassWeight";
            // 
            // uLengthInsideLength
            // 
            resources.ApplyResources(this.uLengthInsideLength, "uLengthInsideLength");
            this.uLengthInsideLength.Name = "uLengthInsideLength";
            // 
            // uLengthInsideWidth
            // 
            resources.ApplyResources(this.uLengthInsideWidth, "uLengthInsideWidth");
            this.uLengthInsideWidth.Name = "uLengthInsideWidth";
            // 
            // uLengthInsideHeight
            // 
            resources.ApplyResources(this.uLengthInsideHeight, "uLengthInsideHeight");
            this.uLengthInsideHeight.Name = "uLengthInsideHeight";
            // 
            // FormNewPalletCap
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.uLengthInsideHeight);
            this.Controls.Add(this.uLengthInsideWidth);
            this.Controls.Add(this.uLengthInsideLength);
            this.Controls.Add(this.uMassWeight);
            this.Controls.Add(this.uLengthHeight);
            this.Controls.Add(this.uLengthWidth);
            this.Controls.Add(this.uLengthLength);
            this.Controls.Add(this.pbPalletCap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbInsideLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.lbWeight);
            this.Controls.Add(this.lbHeight);
            this.Controls.Add(this.lbWidth);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.nudCapWeight);
            this.Controls.Add(this.nudCapInnerHeight);
            this.Controls.Add(this.nudCapHeight);
            this.Controls.Add(this.nudCapInnerWidth);
            this.Controls.Add(this.nudCapWidth);
            this.Controls.Add(this.nudCapInnerLength);
            this.Controls.Add(this.nudCapLength);
            this.Name = "FormNewPalletCap";
            this.Controls.SetChildIndex(this.nudCapLength, 0);
            this.Controls.SetChildIndex(this.nudCapInnerLength, 0);
            this.Controls.SetChildIndex(this.nudCapWidth, 0);
            this.Controls.SetChildIndex(this.nudCapInnerWidth, 0);
            this.Controls.SetChildIndex(this.nudCapHeight, 0);
            this.Controls.SetChildIndex(this.nudCapInnerHeight, 0);
            this.Controls.SetChildIndex(this.nudCapWeight, 0);
            this.Controls.SetChildIndex(this.lbLength, 0);
            this.Controls.SetChildIndex(this.lbWidth, 0);
            this.Controls.SetChildIndex(this.lbHeight, 0);
            this.Controls.SetChildIndex(this.lbWeight, 0);
            this.Controls.SetChildIndex(this.cbColor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lbInsideLength, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.pbPalletCap, 0);
            this.Controls.SetChildIndex(this.uLengthLength, 0);
            this.Controls.SetChildIndex(this.uLengthWidth, 0);
            this.Controls.SetChildIndex(this.uLengthHeight, 0);
            this.Controls.SetChildIndex(this.uMassWeight, 0);
            this.Controls.SetChildIndex(this.uLengthInsideLength, 0);
            this.Controls.SetChildIndex(this.uLengthInsideWidth, 0);
            this.Controls.SetChildIndex(this.uLengthInsideHeight, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudCapLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapInnerLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapInnerWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapInnerHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPalletCap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudCapLength;
        private System.Windows.Forms.NumericUpDown nudCapInnerLength;
        private System.Windows.Forms.NumericUpDown nudCapWidth;
        private System.Windows.Forms.NumericUpDown nudCapInnerWidth;
        private System.Windows.Forms.NumericUpDown nudCapHeight;
        private System.Windows.Forms.NumericUpDown nudCapInnerHeight;
        private System.Windows.Forms.NumericUpDown nudCapWeight;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbWeight;
        private OfficePickers.ColorPicker.ComboBoxColorPicker cbColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbInsideLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbPalletCap;
        private System.Windows.Forms.Label uLengthLength;
        private System.Windows.Forms.Label uLengthWidth;
        private System.Windows.Forms.Label uLengthHeight;
        private System.Windows.Forms.Label uMassWeight;
        private System.Windows.Forms.Label uLengthInsideLength;
        private System.Windows.Forms.Label uLengthInsideWidth;
        private System.Windows.Forms.Label uLengthInsideHeight;
    }
}
