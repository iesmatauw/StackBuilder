namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewAnalysisHCylinder
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
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbCylinders = new System.Windows.Forms.ComboBox();
            this.gbOverhangUnderhang = new System.Windows.Forms.GroupBox();
            this.uLengthOverhangY = new System.Windows.Forms.Label();
            this.uLengthOverhangX = new System.Windows.Forms.Label();
            this.lbMm2 = new System.Windows.Forms.Label();
            this.lbMm1 = new System.Windows.Forms.Label();
            this.nudPalletOverhangY = new System.Windows.Forms.NumericUpDown();
            this.nudPalletOverhangX = new System.Windows.Forms.NumericUpDown();
            this.lbPalletOverhangWidth = new System.Windows.Forms.Label();
            this.lbPalletOverhangLength = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPallets = new System.Windows.Forms.ComboBox();
            this.lbPallet = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnOK = new System.Windows.Forms.Button();
            this.lbStopStacking = new System.Windows.Forms.Label();
            this.checkBoxMaximumPalletHeight = new System.Windows.Forms.CheckBox();
            this.checkBoxMaximumNumberOfItems = new System.Windows.Forms.CheckBox();
            this.gbStopStackingCondition = new System.Windows.Forms.GroupBox();
            this.uLengthPalletHeight = new System.Windows.Forms.Label();
            this.uMassPalletWeight = new System.Windows.Forms.Label();
            this.nudMaximumPalletWeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumPalletHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumNumberOfItems = new System.Windows.Forms.NumericUpDown();
            this.checkBoxMaximumPalletWeight = new System.Windows.Forms.CheckBox();
            this.gbPatterns = new System.Windows.Forms.GroupBox();
            this.chkPatternDefault = new System.Windows.Forms.CheckBox();
            this.chkPatternStaggered = new System.Windows.Forms.CheckBox();
            this.chkPatternColumnized = new System.Windows.Forms.CheckBox();
            this.lbRowSpacing = new System.Windows.Forms.Label();
            this.nudRowSpacing = new System.Windows.Forms.NumericUpDown();
            this.uLengthRowSpacing = new System.Windows.Forms.Label();
            this.statusStripDef.SuspendLayout();
            this.gbOverhangUnderhang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangX)).BeginInit();
            this.gbStopStackingCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfItems)).BeginInit();
            this.gbPatterns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRowSpacing)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Location = new System.Drawing.Point(0, 290);
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.Size = new System.Drawing.Size(596, 22);
            this.statusStripDef.TabIndex = 65;
            this.statusStripDef.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            this.toolStripStatusLabelDef.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabelDef.Text = "toolStripStatusLabelDef";
            // 
            // cbCylinders
            // 
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            this.cbCylinders.Location = new System.Drawing.Point(121, 56);
            this.cbCylinders.Name = "cbCylinders";
            this.cbCylinders.Size = new System.Drawing.Size(158, 21);
            this.cbCylinders.TabIndex = 64;
            // 
            // gbOverhangUnderhang
            // 
            this.gbOverhangUnderhang.Controls.Add(this.uLengthOverhangY);
            this.gbOverhangUnderhang.Controls.Add(this.uLengthOverhangX);
            this.gbOverhangUnderhang.Controls.Add(this.lbMm2);
            this.gbOverhangUnderhang.Controls.Add(this.lbMm1);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangY);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangX);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangWidth);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangLength);
            this.gbOverhangUnderhang.Location = new System.Drawing.Point(5, 85);
            this.gbOverhangUnderhang.Name = "gbOverhangUnderhang";
            this.gbOverhangUnderhang.Size = new System.Drawing.Size(274, 78);
            this.gbOverhangUnderhang.TabIndex = 63;
            this.gbOverhangUnderhang.TabStop = false;
            this.gbOverhangUnderhang.Text = "Pallet overhang / underhang";
            // 
            // uLengthOverhangY
            // 
            this.uLengthOverhangY.AutoSize = true;
            this.uLengthOverhangY.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uLengthOverhangY.Location = new System.Drawing.Point(224, 51);
            this.uLengthOverhangY.Name = "uLengthOverhangY";
            this.uLengthOverhangY.Size = new System.Drawing.Size(46, 13);
            this.uLengthOverhangY.TabIndex = 43;
            this.uLengthOverhangY.Text = "uLength";
            // 
            // uLengthOverhangX
            // 
            this.uLengthOverhangX.AutoSize = true;
            this.uLengthOverhangX.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uLengthOverhangX.Location = new System.Drawing.Point(224, 24);
            this.uLengthOverhangX.Name = "uLengthOverhangX";
            this.uLengthOverhangX.Size = new System.Drawing.Size(46, 13);
            this.uLengthOverhangX.TabIndex = 42;
            this.uLengthOverhangX.Text = "uLength";
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
            this.nudPalletOverhangY.Location = new System.Drawing.Point(164, 47);
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
            // nudPalletOverhangX
            // 
            this.nudPalletOverhangX.Location = new System.Drawing.Point(164, 20);
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
            this.lbPalletOverhangWidth.Location = new System.Drawing.Point(6, 51);
            this.lbPalletOverhangWidth.Name = "lbPalletOverhangWidth";
            this.lbPalletOverhangWidth.Size = new System.Drawing.Size(35, 13);
            this.lbPalletOverhangWidth.TabIndex = 37;
            this.lbPalletOverhangWidth.Text = "Width";
            // 
            // lbPalletOverhangLength
            // 
            this.lbPalletOverhangLength.AutoSize = true;
            this.lbPalletOverhangLength.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPalletOverhangLength.Location = new System.Drawing.Point(6, 24);
            this.lbPalletOverhangLength.Name = "lbPalletOverhangLength";
            this.lbPalletOverhangLength.Size = new System.Drawing.Size(40, 13);
            this.lbPalletOverhangLength.TabIndex = 36;
            this.lbPalletOverhangLength.Text = "Length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Cylinder";
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            this.cbPallets.Location = new System.Drawing.Point(355, 56);
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.Size = new System.Drawing.Size(136, 21);
            this.cbPallets.TabIndex = 61;
            // 
            // lbPallet
            // 
            this.lbPallet.AutoSize = true;
            this.lbPallet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPallet.Location = new System.Drawing.Point(316, 60);
            this.lbPallet.Name = "lbPallet";
            this.lbPallet.Size = new System.Drawing.Size(33, 13);
            this.lbPallet.TabIndex = 60;
            this.lbPallet.Text = "Pallet";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(121, 31);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(370, 20);
            this.tbDescription.TabIndex = 59;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(121, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 20);
            this.tbName.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Name";
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnCancel.Location = new System.Drawing.Point(514, 34);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 55;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnOK
            // 
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnOK.Location = new System.Drawing.Point(514, 5);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 54;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
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
            this.checkBoxMaximumPalletHeight.Location = new System.Drawing.Point(8, 69);
            this.checkBoxMaximumPalletHeight.Name = "checkBoxMaximumPalletHeight";
            this.checkBoxMaximumPalletHeight.Size = new System.Drawing.Size(153, 17);
            this.checkBoxMaximumPalletHeight.TabIndex = 20;
            this.checkBoxMaximumPalletHeight.Text = "when pallet height reaches";
            this.checkBoxMaximumPalletHeight.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaximumNumberOfItems
            // 
            this.checkBoxMaximumNumberOfItems.AutoSize = true;
            this.checkBoxMaximumNumberOfItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMaximumNumberOfItems.Location = new System.Drawing.Point(8, 39);
            this.checkBoxMaximumNumberOfItems.Name = "checkBoxMaximumNumberOfItems";
            this.checkBoxMaximumNumberOfItems.Size = new System.Drawing.Size(187, 17);
            this.checkBoxMaximumNumberOfItems.TabIndex = 19;
            this.checkBoxMaximumNumberOfItems.Text = "when number of cylinders reaches";
            this.checkBoxMaximumNumberOfItems.UseVisualStyleBackColor = true;
            // 
            // gbStopStackingCondition
            // 
            this.gbStopStackingCondition.Controls.Add(this.uLengthPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.uMassPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumNumberOfItems);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.lbStopStacking);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumNumberOfItems);
            this.gbStopStackingCondition.Location = new System.Drawing.Point(285, 85);
            this.gbStopStackingCondition.Name = "gbStopStackingCondition";
            this.gbStopStackingCondition.Size = new System.Drawing.Size(304, 122);
            this.gbStopStackingCondition.TabIndex = 66;
            this.gbStopStackingCondition.TabStop = false;
            this.gbStopStackingCondition.Text = "Additional stop stacking condition";
            // 
            // uLengthPalletHeight
            // 
            this.uLengthPalletHeight.AutoSize = true;
            this.uLengthPalletHeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uLengthPalletHeight.Location = new System.Drawing.Point(272, 71);
            this.uLengthPalletHeight.Name = "uLengthPalletHeight";
            this.uLengthPalletHeight.Size = new System.Drawing.Size(46, 13);
            this.uLengthPalletHeight.TabIndex = 30;
            this.uLengthPalletHeight.Text = "uLength";
            // 
            // uMassPalletWeight
            // 
            this.uMassPalletWeight.AutoSize = true;
            this.uMassPalletWeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uMassPalletWeight.Location = new System.Drawing.Point(272, 101);
            this.uMassPalletWeight.Name = "uMassPalletWeight";
            this.uMassPalletWeight.Size = new System.Drawing.Size(38, 13);
            this.uMassPalletWeight.TabIndex = 29;
            this.uMassPalletWeight.Text = "uMass";
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
            // nudMaximumNumberOfItems
            // 
            this.nudMaximumNumberOfItems.Location = new System.Drawing.Point(213, 37);
            this.nudMaximumNumberOfItems.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumNumberOfItems.Name = "nudMaximumNumberOfItems";
            this.nudMaximumNumberOfItems.Size = new System.Drawing.Size(55, 20);
            this.nudMaximumNumberOfItems.TabIndex = 24;
            // 
            // checkBoxMaximumPalletWeight
            // 
            this.checkBoxMaximumPalletWeight.AutoSize = true;
            this.checkBoxMaximumPalletWeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMaximumPalletWeight.Location = new System.Drawing.Point(8, 99);
            this.checkBoxMaximumPalletWeight.Name = "checkBoxMaximumPalletWeight";
            this.checkBoxMaximumPalletWeight.Size = new System.Drawing.Size(178, 17);
            this.checkBoxMaximumPalletWeight.TabIndex = 22;
            this.checkBoxMaximumPalletWeight.Text = "when total pallet weight reaches";
            this.checkBoxMaximumPalletWeight.UseVisualStyleBackColor = true;
            // 
            // gbPatterns
            // 
            this.gbPatterns.Controls.Add(this.uLengthRowSpacing);
            this.gbPatterns.Controls.Add(this.nudRowSpacing);
            this.gbPatterns.Controls.Add(this.lbRowSpacing);
            this.gbPatterns.Controls.Add(this.chkPatternColumnized);
            this.gbPatterns.Controls.Add(this.chkPatternStaggered);
            this.gbPatterns.Controls.Add(this.chkPatternDefault);
            this.gbPatterns.Location = new System.Drawing.Point(0, 169);
            this.gbPatterns.Name = "gbPatterns";
            this.gbPatterns.Size = new System.Drawing.Size(279, 118);
            this.gbPatterns.TabIndex = 67;
            this.gbPatterns.TabStop = false;
            this.gbPatterns.Text = "Patterns";
            // 
            // chkPatternDefault
            // 
            this.chkPatternDefault.AutoSize = true;
            this.chkPatternDefault.Location = new System.Drawing.Point(9, 20);
            this.chkPatternDefault.Name = "chkPatternDefault";
            this.chkPatternDefault.Size = new System.Drawing.Size(60, 17);
            this.chkPatternDefault.TabIndex = 0;
            this.chkPatternDefault.Text = "Default";
            this.chkPatternDefault.UseVisualStyleBackColor = true;
            // 
            // chkPatternStaggered
            // 
            this.chkPatternStaggered.AutoSize = true;
            this.chkPatternStaggered.Location = new System.Drawing.Point(9, 43);
            this.chkPatternStaggered.Name = "chkPatternStaggered";
            this.chkPatternStaggered.Size = new System.Drawing.Size(103, 17);
            this.chkPatternStaggered.TabIndex = 1;
            this.chkPatternStaggered.Text = "Pallet with frame";
            this.chkPatternStaggered.UseVisualStyleBackColor = true;
            // 
            // chkPatternColumnized
            // 
            this.chkPatternColumnized.AutoSize = true;
            this.chkPatternColumnized.Location = new System.Drawing.Point(9, 66);
            this.chkPatternColumnized.Name = "chkPatternColumnized";
            this.chkPatternColumnized.Size = new System.Drawing.Size(233, 17);
            this.chkPatternColumnized.TabIndex = 2;
            this.chkPatternColumnized.Text = "With special interlayers for columnized pallet";
            this.chkPatternColumnized.UseVisualStyleBackColor = true;
            this.chkPatternColumnized.CheckedChanged += new System.EventHandler(this.chkPatternColumnized_CheckedChanged);
            // 
            // lbRowSpacing
            // 
            this.lbRowSpacing.AutoSize = true;
            this.lbRowSpacing.Location = new System.Drawing.Point(31, 86);
            this.lbRowSpacing.Name = "lbRowSpacing";
            this.lbRowSpacing.Size = new System.Drawing.Size(69, 13);
            this.lbRowSpacing.TabIndex = 3;
            this.lbRowSpacing.Text = "Row spacing";
            // 
            // nudRowSpacing
            // 
            this.nudRowSpacing.Location = new System.Drawing.Point(169, 82);
            this.nudRowSpacing.Name = "nudRowSpacing";
            this.nudRowSpacing.Size = new System.Drawing.Size(56, 20);
            this.nudRowSpacing.TabIndex = 4;
            // 
            // uLengthRowSpacing
            // 
            this.uLengthRowSpacing.AutoSize = true;
            this.uLengthRowSpacing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uLengthRowSpacing.Location = new System.Drawing.Point(229, 86);
            this.uLengthRowSpacing.Name = "uLengthRowSpacing";
            this.uLengthRowSpacing.Size = new System.Drawing.Size(46, 13);
            this.uLengthRowSpacing.TabIndex = 43;
            this.uLengthRowSpacing.Text = "uLength";
            // 
            // FormNewAnalysisHCylinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 312);
            this.Controls.Add(this.gbPatterns);
            this.Controls.Add(this.gbStopStackingCondition);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.cbCylinders);
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
            this.MaximumSize = new System.Drawing.Size(612, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(612, 350);
            this.Name = "FormNewAnalysisHCylinder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Create new cylinder analysis...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewAnalysisHCylinder_FormClosing);
            this.Load += new System.EventHandler(this.FormNewAnalysisHCylinder_Load);
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.gbOverhangUnderhang.ResumeLayout(false);
            this.gbOverhangUnderhang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangX)).EndInit();
            this.gbStopStackingCondition.ResumeLayout(false);
            this.gbStopStackingCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfItems)).EndInit();
            this.gbPatterns.ResumeLayout(false);
            this.gbPatterns.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRowSpacing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.ComboBox cbCylinders;
        private System.Windows.Forms.GroupBox gbOverhangUnderhang;
        private System.Windows.Forms.Label uLengthOverhangY;
        private System.Windows.Forms.Label uLengthOverhangX;
        private System.Windows.Forms.Label lbMm2;
        private System.Windows.Forms.Label lbMm1;
        private System.Windows.Forms.NumericUpDown nudPalletOverhangY;
        private System.Windows.Forms.NumericUpDown nudPalletOverhangX;
        private System.Windows.Forms.Label lbPalletOverhangWidth;
        private System.Windows.Forms.Label lbPalletOverhangLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPallets;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Label lbStopStacking;
        private System.Windows.Forms.CheckBox checkBoxMaximumPalletHeight;
        private System.Windows.Forms.CheckBox checkBoxMaximumNumberOfItems;
        private System.Windows.Forms.GroupBox gbStopStackingCondition;
        private System.Windows.Forms.Label uLengthPalletHeight;
        private System.Windows.Forms.Label uMassPalletWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumPalletWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumPalletHeight;
        private System.Windows.Forms.NumericUpDown nudMaximumNumberOfItems;
        private System.Windows.Forms.CheckBox checkBoxMaximumPalletWeight;
        private System.Windows.Forms.GroupBox gbPatterns;
        private System.Windows.Forms.CheckBox chkPatternColumnized;
        private System.Windows.Forms.CheckBox chkPatternStaggered;
        private System.Windows.Forms.CheckBox chkPatternDefault;
        private System.Windows.Forms.Label uLengthRowSpacing;
        private System.Windows.Forms.NumericUpDown nudRowSpacing;
        private System.Windows.Forms.Label lbRowSpacing;
    }
}