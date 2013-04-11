namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewAnalysisCylinder
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
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.cbPallets = new System.Windows.Forms.ComboBox();
            this.lbPallet = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMm2 = new System.Windows.Forms.Label();
            this.lbMm1 = new System.Windows.Forms.Label();
            this.nudPalletOverhangY = new System.Windows.Forms.NumericUpDown();
            this.lbPalletOverhangLength = new System.Windows.Forms.Label();
            this.gbOverhangUnderhang = new System.Windows.Forms.GroupBox();
            this.nudPalletOverhangX = new System.Windows.Forms.NumericUpDown();
            this.lbPalletOverhangWidth = new System.Windows.Forms.Label();
            this.lbMm = new System.Windows.Forms.Label();
            this.lbKg1 = new System.Windows.Forms.Label();
            this.lbKg2 = new System.Windows.Forms.Label();
            this.nudMaximumLoadOnBox = new System.Windows.Forms.NumericUpDown();
            this.gbStopStackingCondition = new System.Windows.Forms.GroupBox();
            this.nudMaximumPalletWeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumPalletHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumNumberOfItems = new System.Windows.Forms.NumericUpDown();
            this.checkBoxMaximumLoadOnCylinder = new System.Windows.Forms.CheckBox();
            this.checkBoxMaximumPalletWeight = new System.Windows.Forms.CheckBox();
            this.lbStopStacking = new System.Windows.Forms.Label();
            this.checkBoxMaximumPalletHeight = new System.Windows.Forms.CheckBox();
            this.checkBoxMaximumNumberOfItems = new System.Windows.Forms.CheckBox();
            this.cbCylinders = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangY)).BeginInit();
            this.gbOverhangUnderhang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumLoadOnBox)).BeginInit();
            this.gbStopStackingCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfItems)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOK
            // 
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Location = new System.Drawing.Point(514, 9);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 0;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(514, 38);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            this.cbPallets.Location = new System.Drawing.Point(355, 63);
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.Size = new System.Drawing.Size(136, 21);
            this.cbPallets.TabIndex = 22;
            // 
            // lbPallet
            // 
            this.lbPallet.AutoSize = true;
            this.lbPallet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPallet.Location = new System.Drawing.Point(316, 63);
            this.lbPallet.Name = "lbPallet";
            this.lbPallet.Size = new System.Drawing.Size(33, 13);
            this.lbPallet.TabIndex = 21;
            this.lbPallet.Text = "Pallet";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(121, 35);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(370, 20);
            this.tbDescription.TabIndex = 20;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(121, 9);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 20);
            this.tbName.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Cylinder";
            // 
            // lbMm2
            // 
            this.lbMm2.AutoSize = true;
            this.lbMm2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMm2.Location = new System.Drawing.Point(276, 47);
            this.lbMm2.Name = "lbMm2";
            this.lbMm2.Size = new System.Drawing.Size(23, 13);
            this.lbMm2.TabIndex = 41;
            this.lbMm2.Text = "mm";
            // 
            // lbMm1
            // 
            this.lbMm1.AutoSize = true;
            this.lbMm1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMm1.Location = new System.Drawing.Point(276, 20);
            this.lbMm1.Name = "lbMm1";
            this.lbMm1.Size = new System.Drawing.Size(23, 13);
            this.lbMm1.TabIndex = 40;
            this.lbMm1.Text = "mm";
            // 
            // nudPalletOverhangY
            // 
            this.nudPalletOverhangY.Location = new System.Drawing.Point(208, 47);
            this.nudPalletOverhangY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPalletOverhangY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudPalletOverhangY.Name = "nudPalletOverhangY";
            this.nudPalletOverhangY.Size = new System.Drawing.Size(56, 20);
            this.nudPalletOverhangY.TabIndex = 39;
            // 
            // lbPalletOverhangLength
            // 
            this.lbPalletOverhangLength.AutoSize = true;
            this.lbPalletOverhangLength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPalletOverhangLength.Location = new System.Drawing.Point(6, 22);
            this.lbPalletOverhangLength.Name = "lbPalletOverhangLength";
            this.lbPalletOverhangLength.Size = new System.Drawing.Size(40, 13);
            this.lbPalletOverhangLength.TabIndex = 36;
            this.lbPalletOverhangLength.Text = "Length";
            // 
            // gbOverhangUnderhang
            // 
            this.gbOverhangUnderhang.Controls.Add(this.lbMm2);
            this.gbOverhangUnderhang.Controls.Add(this.lbMm1);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangY);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangX);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangWidth);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangLength);
            this.gbOverhangUnderhang.Location = new System.Drawing.Point(5, 92);
            this.gbOverhangUnderhang.Name = "gbOverhangUnderhang";
            this.gbOverhangUnderhang.Size = new System.Drawing.Size(274, 78);
            this.gbOverhangUnderhang.TabIndex = 41;
            this.gbOverhangUnderhang.TabStop = false;
            this.gbOverhangUnderhang.Text = "Pallet overhang / underhang";
            // 
            // nudPalletOverhangX
            // 
            this.nudPalletOverhangX.Location = new System.Drawing.Point(208, 20);
            this.nudPalletOverhangX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPalletOverhangX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudPalletOverhangX.Name = "nudPalletOverhangX";
            this.nudPalletOverhangX.Size = new System.Drawing.Size(56, 20);
            this.nudPalletOverhangX.TabIndex = 38;
            // 
            // lbPalletOverhangWidth
            // 
            this.lbPalletOverhangWidth.AutoSize = true;
            this.lbPalletOverhangWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPalletOverhangWidth.Location = new System.Drawing.Point(6, 47);
            this.lbPalletOverhangWidth.Name = "lbPalletOverhangWidth";
            this.lbPalletOverhangWidth.Size = new System.Drawing.Size(35, 13);
            this.lbPalletOverhangWidth.TabIndex = 37;
            this.lbPalletOverhangWidth.Text = "Width";
            // 
            // lbMm
            // 
            this.lbMm.AutoSize = true;
            this.lbMm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMm.Location = new System.Drawing.Point(278, 71);
            this.lbMm.Name = "lbMm";
            this.lbMm.Size = new System.Drawing.Size(23, 13);
            this.lbMm.TabIndex = 30;
            this.lbMm.Text = "mm";
            // 
            // lbKg1
            // 
            this.lbKg1.AutoSize = true;
            this.lbKg1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbKg1.Location = new System.Drawing.Point(278, 99);
            this.lbKg1.Name = "lbKg1";
            this.lbKg1.Size = new System.Drawing.Size(19, 13);
            this.lbKg1.TabIndex = 29;
            this.lbKg1.Text = "kg";
            // 
            // lbKg2
            // 
            this.lbKg2.AutoSize = true;
            this.lbKg2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbKg2.Location = new System.Drawing.Point(278, 129);
            this.lbKg2.Name = "lbKg2";
            this.lbKg2.Size = new System.Drawing.Size(19, 13);
            this.lbKg2.TabIndex = 28;
            this.lbKg2.Text = "kg";
            // 
            // nudMaximumLoadOnBox
            // 
            this.nudMaximumLoadOnBox.DecimalPlaces = 1;
            this.nudMaximumLoadOnBox.Location = new System.Drawing.Point(213, 127);
            this.nudMaximumLoadOnBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumLoadOnBox.Name = "nudMaximumLoadOnBox";
            this.nudMaximumLoadOnBox.Size = new System.Drawing.Size(55, 20);
            this.nudMaximumLoadOnBox.TabIndex = 27;
            // 
            // gbStopStackingCondition
            // 
            this.gbStopStackingCondition.Controls.Add(this.lbMm);
            this.gbStopStackingCondition.Controls.Add(this.lbKg1);
            this.gbStopStackingCondition.Controls.Add(this.lbKg2);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumLoadOnBox);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumNumberOfItems);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumLoadOnCylinder);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.lbStopStacking);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumNumberOfItems);
            this.gbStopStackingCondition.Location = new System.Drawing.Point(285, 92);
            this.gbStopStackingCondition.Name = "gbStopStackingCondition";
            this.gbStopStackingCondition.Size = new System.Drawing.Size(304, 154);
            this.gbStopStackingCondition.TabIndex = 45;
            this.gbStopStackingCondition.TabStop = false;
            this.gbStopStackingCondition.Text = "Additional stop stacking condition";
            // 
            // nudMaximumPalletWeight
            // 
            this.nudMaximumPalletWeight.DecimalPlaces = 1;
            this.nudMaximumPalletWeight.Location = new System.Drawing.Point(213, 97);
            this.nudMaximumPalletWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumPalletWeight.Name = "nudMaximumPalletWeight";
            this.nudMaximumPalletWeight.Size = new System.Drawing.Size(55, 20);
            this.nudMaximumPalletWeight.TabIndex = 26;
            // 
            // nudMaximumPalletHeight
            // 
            this.nudMaximumPalletHeight.Location = new System.Drawing.Point(213, 67);
            this.nudMaximumPalletHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumPalletHeight.Name = "nudMaximumPalletHeight";
            this.nudMaximumPalletHeight.Size = new System.Drawing.Size(55, 20);
            this.nudMaximumPalletHeight.TabIndex = 25;
            // 
            // nudMaximumNumberOfBoxes
            // 
            this.nudMaximumNumberOfItems.Location = new System.Drawing.Point(213, 37);
            this.nudMaximumNumberOfItems.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumNumberOfItems.Name = "nudMaximumNumberOfBoxes";
            this.nudMaximumNumberOfItems.Size = new System.Drawing.Size(55, 20);
            this.nudMaximumNumberOfItems.TabIndex = 24;
            // 
            // checkBoxMaximumLoadOnBox
            // 
            this.checkBoxMaximumLoadOnCylinder.AutoSize = true;
            this.checkBoxMaximumLoadOnCylinder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMaximumLoadOnCylinder.Location = new System.Drawing.Point(8, 130);
            this.checkBoxMaximumLoadOnCylinder.Name = "checkBoxMaximumLoadOnBox";
            this.checkBoxMaximumLoadOnCylinder.Size = new System.Drawing.Size(203, 17);
            this.checkBoxMaximumLoadOnCylinder.TabIndex = 23;
            this.checkBoxMaximumLoadOnCylinder.Text = "when load on lower cylinders reaches";
            this.checkBoxMaximumLoadOnCylinder.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaximumPalletWeight
            // 
            this.checkBoxMaximumPalletWeight.AutoSize = true;
            this.checkBoxMaximumPalletWeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMaximumPalletWeight.Location = new System.Drawing.Point(8, 100);
            this.checkBoxMaximumPalletWeight.Name = "checkBoxMaximumPalletWeight";
            this.checkBoxMaximumPalletWeight.Size = new System.Drawing.Size(178, 17);
            this.checkBoxMaximumPalletWeight.TabIndex = 22;
            this.checkBoxMaximumPalletWeight.Text = "when total pallet weight reaches";
            this.checkBoxMaximumPalletWeight.UseVisualStyleBackColor = true;
            // 
            // lbStopStacking
            // 
            this.lbStopStacking.AutoSize = true;
            this.lbStopStacking.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbStopStacking.Location = new System.Drawing.Point(9, 20);
            this.lbStopStacking.Name = "lbStopStacking";
            this.lbStopStacking.Size = new System.Drawing.Size(75, 13);
            this.lbStopStacking.TabIndex = 21;
            this.lbStopStacking.Text = "Stop stacking:";
            // 
            // checkBoxMaximumPalletHeight
            // 
            this.checkBoxMaximumPalletHeight.AutoSize = true;
            this.checkBoxMaximumPalletHeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMaximumPalletHeight.Location = new System.Drawing.Point(8, 70);
            this.checkBoxMaximumPalletHeight.Name = "checkBoxMaximumPalletHeight";
            this.checkBoxMaximumPalletHeight.Size = new System.Drawing.Size(153, 17);
            this.checkBoxMaximumPalletHeight.TabIndex = 20;
            this.checkBoxMaximumPalletHeight.Text = "when pallet height reaches";
            this.checkBoxMaximumPalletHeight.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaximumNumberOfBoxes
            // 
            this.checkBoxMaximumNumberOfItems.AutoSize = true;
            this.checkBoxMaximumNumberOfItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMaximumNumberOfItems.Location = new System.Drawing.Point(8, 40);
            this.checkBoxMaximumNumberOfItems.Name = "checkBoxMaximumNumberOfBoxes";
            this.checkBoxMaximumNumberOfItems.Size = new System.Drawing.Size(174, 17);
            this.checkBoxMaximumNumberOfItems.TabIndex = 19;
            this.checkBoxMaximumNumberOfItems.Text = "when number of boxes reaches";
            this.checkBoxMaximumNumberOfItems.UseVisualStyleBackColor = true;
            // 
            // cbCylinders
            // 
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            this.cbCylinders.Location = new System.Drawing.Point(121, 63);
            this.cbCylinders.Name = "cbCylinders";
            this.cbCylinders.Size = new System.Drawing.Size(158, 21);
            this.cbCylinders.TabIndex = 47;
            // 
            // FormNewAnalysisCylinder
            // 
            this.AcceptButton = this.bnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(596, 248);
            this.Controls.Add(this.cbCylinders);
            this.Controls.Add(this.gbStopStackingCondition);
            this.Controls.Add(this.gbOverhangUnderhang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPallets);
            this.Controls.Add(this.lbPallet);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewAnalysisCylinder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Create new cylinder analysis... ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewAnalysisCylinder_FormClosing);
            this.Load += new System.EventHandler(this.FormNewAnalysisCylinder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangY)).EndInit();
            this.gbOverhangUnderhang.ResumeLayout(false);
            this.gbOverhangUnderhang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumLoadOnBox)).EndInit();
            this.gbStopStackingCondition.ResumeLayout(false);
            this.gbStopStackingCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.ComboBox cbPallets;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbMm2;
        private System.Windows.Forms.Label lbMm1;
        private System.Windows.Forms.NumericUpDown nudPalletOverhangY;
        private System.Windows.Forms.Label lbPalletOverhangLength;
        private System.Windows.Forms.GroupBox gbOverhangUnderhang;
        private System.Windows.Forms.NumericUpDown nudPalletOverhangX;
        private System.Windows.Forms.Label lbPalletOverhangWidth;
        private System.Windows.Forms.Label lbMm;
        private System.Windows.Forms.Label lbKg1;
        private System.Windows.Forms.Label lbKg2;
        private System.Windows.Forms.NumericUpDown nudMaximumLoadOnBox;
        private System.Windows.Forms.GroupBox gbStopStackingCondition;
        private System.Windows.Forms.NumericUpDown nudMaximumPalletWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumPalletHeight;
        private System.Windows.Forms.NumericUpDown nudMaximumNumberOfItems;
        private System.Windows.Forms.CheckBox checkBoxMaximumLoadOnCylinder;
        private System.Windows.Forms.CheckBox checkBoxMaximumPalletWeight;
        private System.Windows.Forms.Label lbStopStacking;
        private System.Windows.Forms.CheckBox checkBoxMaximumPalletHeight;
        private System.Windows.Forms.CheckBox checkBoxMaximumNumberOfItems;
        private System.Windows.Forms.ComboBox cbCylinders;
    }
}