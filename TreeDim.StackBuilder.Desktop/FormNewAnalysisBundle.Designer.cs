namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewAnalysisBundle
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
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnAccept = new System.Windows.Forms.Button();
            this.lbMm2 = new System.Windows.Forms.Label();
            this.lbMm1 = new System.Windows.Forms.Label();
            this.nudPalletOverhangX = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAllowAlignedLayer = new System.Windows.Forms.CheckBox();
            this.nudPalletOverhangY = new System.Windows.Forms.NumericUpDown();
            this.lbPalletOverhangWidth = new System.Windows.Forms.Label();
            this.gbLayerAlignment = new System.Windows.Forms.GroupBox();
            this.checkBoxAllowAlternateLayer = new System.Windows.Forms.CheckBox();
            this.lbPalletOverhangLength = new System.Windows.Forms.Label();
            this.gbOverhangUnderhang = new System.Windows.Forms.GroupBox();
            this.cbPallet = new System.Windows.Forms.ComboBox();
            this.lbPallet = new System.Windows.Forms.Label();
            this.lbBundle = new System.Windows.Forms.Label();
            this.cbBox = new System.Windows.Forms.ComboBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxPatterns = new System.Windows.Forms.CheckedListBox();
            this.gbAllowedLayerPatterns = new System.Windows.Forms.GroupBox();
            this.gbAdditionalData = new System.Windows.Forms.GroupBox();
            this.lbSolutions = new System.Windows.Forms.Label();
            this.nudSolutions = new System.Windows.Forms.NumericUpDown();
            this.checkBoxKeepSolutions = new System.Windows.Forms.CheckBox();
            this.lbBoxes = new System.Windows.Forms.Label();
            this.nudNumberOfBoxes = new System.Windows.Forms.NumericUpDown();
            this.checkBoxNumberOfPallets = new System.Windows.Forms.CheckBox();
            this.gbStopStackingCondition = new System.Windows.Forms.GroupBox();
            this.lbMm = new System.Windows.Forms.Label();
            this.lbKg1 = new System.Windows.Forms.Label();
            this.nudMaximumPalletWeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumPalletHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumNumberOfBoxes = new System.Windows.Forms.NumericUpDown();
            this.checkBoxMaximumPalletWeight = new System.Windows.Forms.CheckBox();
            this.lbStopStacking = new System.Windows.Forms.Label();
            this.checkBoxMaximumPalletHeight = new System.Windows.Forms.CheckBox();
            this.checkBoxMaximumNumberOfBoxes = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangY)).BeginInit();
            this.gbLayerAlignment.SuspendLayout();
            this.gbOverhangUnderhang.SuspendLayout();
            this.gbAllowedLayerPatterns.SuspendLayout();
            this.gbAdditionalData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSolutions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfBoxes)).BeginInit();
            this.gbStopStackingCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfBoxes)).BeginInit();
            this.SuspendLayout();
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(497, 41);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 3;
            this.bnCancel.Text = "&Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnAccept
            // 
            this.bnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnAccept.Location = new System.Drawing.Point(497, 12);
            this.bnAccept.Name = "bnAccept";
            this.bnAccept.Size = new System.Drawing.Size(75, 23);
            this.bnAccept.TabIndex = 2;
            this.bnAccept.Text = "&Ok";
            this.bnAccept.UseVisualStyleBackColor = true;
            // 
            // lbMm2
            // 
            this.lbMm2.AutoSize = true;
            this.lbMm2.Location = new System.Drawing.Point(197, 47);
            this.lbMm2.Name = "lbMm2";
            this.lbMm2.Size = new System.Drawing.Size(23, 13);
            this.lbMm2.TabIndex = 41;
            this.lbMm2.Text = "mm";
            // 
            // lbMm1
            // 
            this.lbMm1.AutoSize = true;
            this.lbMm1.Location = new System.Drawing.Point(197, 20);
            this.lbMm1.Name = "lbMm1";
            this.lbMm1.Size = new System.Drawing.Size(23, 13);
            this.lbMm1.TabIndex = 40;
            this.lbMm1.Text = "mm";
            // 
            // nudPalletOverhangX
            // 
            this.nudPalletOverhangX.Location = new System.Drawing.Point(129, 20);
            this.nudPalletOverhangX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPalletOverhangX.Name = "nudPalletOverhangX";
            this.nudPalletOverhangX.Size = new System.Drawing.Size(56, 20);
            this.nudPalletOverhangX.TabIndex = 38;
            // 
            // checkBoxAllowAlignedLayer
            // 
            this.checkBoxAllowAlignedLayer.AutoSize = true;
            this.checkBoxAllowAlignedLayer.Location = new System.Drawing.Point(10, 20);
            this.checkBoxAllowAlignedLayer.Name = "checkBoxAllowAlignedLayer";
            this.checkBoxAllowAlignedLayer.Size = new System.Drawing.Size(112, 17);
            this.checkBoxAllowAlignedLayer.TabIndex = 41;
            this.checkBoxAllowAlignedLayer.Text = "allow aligned layer";
            this.checkBoxAllowAlignedLayer.UseVisualStyleBackColor = true;
            // 
            // nudPalletOverhangY
            // 
            this.nudPalletOverhangY.Location = new System.Drawing.Point(129, 47);
            this.nudPalletOverhangY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPalletOverhangY.Name = "nudPalletOverhangY";
            this.nudPalletOverhangY.Size = new System.Drawing.Size(56, 20);
            this.nudPalletOverhangY.TabIndex = 39;
            // 
            // lbPalletOverhangWidth
            // 
            this.lbPalletOverhangWidth.AutoSize = true;
            this.lbPalletOverhangWidth.Location = new System.Drawing.Point(12, 47);
            this.lbPalletOverhangWidth.Name = "lbPalletOverhangWidth";
            this.lbPalletOverhangWidth.Size = new System.Drawing.Size(35, 13);
            this.lbPalletOverhangWidth.TabIndex = 37;
            this.lbPalletOverhangWidth.Text = "Width";
            // 
            // gbLayerAlignment
            // 
            this.gbLayerAlignment.Controls.Add(this.checkBoxAllowAlternateLayer);
            this.gbLayerAlignment.Controls.Add(this.checkBoxAllowAlignedLayer);
            this.gbLayerAlignment.Location = new System.Drawing.Point(260, 120);
            this.gbLayerAlignment.Name = "gbLayerAlignment";
            this.gbLayerAlignment.Size = new System.Drawing.Size(317, 78);
            this.gbLayerAlignment.TabIndex = 53;
            this.gbLayerAlignment.TabStop = false;
            this.gbLayerAlignment.Text = "Layer alignment";
            // 
            // checkBoxAllowAlternateLayer
            // 
            this.checkBoxAllowAlternateLayer.AutoSize = true;
            this.checkBoxAllowAlternateLayer.Location = new System.Drawing.Point(10, 47);
            this.checkBoxAllowAlternateLayer.Name = "checkBoxAllowAlternateLayer";
            this.checkBoxAllowAlternateLayer.Size = new System.Drawing.Size(119, 17);
            this.checkBoxAllowAlternateLayer.TabIndex = 42;
            this.checkBoxAllowAlternateLayer.Text = "allow alternate layer";
            this.checkBoxAllowAlternateLayer.UseVisualStyleBackColor = true;
            // 
            // lbPalletOverhangLength
            // 
            this.lbPalletOverhangLength.AutoSize = true;
            this.lbPalletOverhangLength.Location = new System.Drawing.Point(12, 22);
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
            this.gbOverhangUnderhang.Location = new System.Drawing.Point(7, 120);
            this.gbOverhangUnderhang.Name = "gbOverhangUnderhang";
            this.gbOverhangUnderhang.Size = new System.Drawing.Size(247, 78);
            this.gbOverhangUnderhang.TabIndex = 52;
            this.gbOverhangUnderhang.TabStop = false;
            this.gbOverhangUnderhang.Text = "Pallet overhang / underhang";
            // 
            // cbPallet
            // 
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            this.cbPallet.Location = new System.Drawing.Point(364, 64);
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.Size = new System.Drawing.Size(121, 21);
            this.cbPallet.TabIndex = 51;
            // 
            // lbPallet
            // 
            this.lbPallet.AutoSize = true;
            this.lbPallet.Location = new System.Drawing.Point(314, 64);
            this.lbPallet.Name = "lbPallet";
            this.lbPallet.Size = new System.Drawing.Size(33, 13);
            this.lbPallet.TabIndex = 49;
            this.lbPallet.Text = "Pallet";
            // 
            // lbBundle
            // 
            this.lbBundle.AutoSize = true;
            this.lbBundle.Location = new System.Drawing.Point(15, 64);
            this.lbBundle.Name = "lbBundle";
            this.lbBundle.Size = new System.Drawing.Size(40, 13);
            this.lbBundle.TabIndex = 48;
            this.lbBundle.Text = "Bundle";
            // 
            // cbBox
            // 
            this.cbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBox.FormattingEnabled = true;
            this.cbBox.Location = new System.Drawing.Point(131, 64);
            this.cbBox.Name = "cbBox";
            this.cbBox.Size = new System.Drawing.Size(121, 21);
            this.cbBox.TabIndex = 50;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(130, 37);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(355, 20);
            this.tbDescription.TabIndex = 47;
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(130, 11);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 20);
            this.tbName.TabIndex = 46;
            this.tbName.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Name";
            // 
            // checkedListBoxPatterns
            // 
            this.checkedListBoxPatterns.FormattingEnabled = true;
            this.checkedListBoxPatterns.Items.AddRange(new object[] {
            "Column",
            "Interlocked",
            "Diagonale",
            "Trilock"});
            this.checkedListBoxPatterns.Location = new System.Drawing.Point(12, 18);
            this.checkedListBoxPatterns.Name = "checkedListBoxPatterns";
            this.checkedListBoxPatterns.Size = new System.Drawing.Size(162, 94);
            this.checkedListBoxPatterns.TabIndex = 17;
            // 
            // gbAllowedLayerPatterns
            // 
            this.gbAllowedLayerPatterns.Controls.Add(this.checkedListBoxPatterns);
            this.gbAllowedLayerPatterns.Location = new System.Drawing.Point(387, 212);
            this.gbAllowedLayerPatterns.Name = "gbAllowedLayerPatterns";
            this.gbAllowedLayerPatterns.Size = new System.Drawing.Size(188, 125);
            this.gbAllowedLayerPatterns.TabIndex = 54;
            this.gbAllowedLayerPatterns.TabStop = false;
            this.gbAllowedLayerPatterns.Text = "Allowed layer patterns";
            // 
            // gbAdditionalData
            // 
            this.gbAdditionalData.Controls.Add(this.lbSolutions);
            this.gbAdditionalData.Controls.Add(this.nudSolutions);
            this.gbAdditionalData.Controls.Add(this.checkBoxKeepSolutions);
            this.gbAdditionalData.Controls.Add(this.lbBoxes);
            this.gbAdditionalData.Controls.Add(this.nudNumberOfBoxes);
            this.gbAdditionalData.Controls.Add(this.checkBoxNumberOfPallets);
            this.gbAdditionalData.Location = new System.Drawing.Point(8, 348);
            this.gbAdditionalData.Name = "gbAdditionalData";
            this.gbAdditionalData.Size = new System.Drawing.Size(568, 62);
            this.gbAdditionalData.TabIndex = 56;
            this.gbAdditionalData.TabStop = false;
            this.gbAdditionalData.Text = "Additional data";
            // 
            // lbSolutions
            // 
            this.lbSolutions.AutoSize = true;
            this.lbSolutions.Location = new System.Drawing.Point(191, 40);
            this.lbSolutions.Name = "lbSolutions";
            this.lbSolutions.Size = new System.Drawing.Size(71, 13);
            this.lbSolutions.TabIndex = 50;
            this.lbSolutions.Text = "best solutions";
            // 
            // nudSolutions
            // 
            this.nudSolutions.Location = new System.Drawing.Point(103, 37);
            this.nudSolutions.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSolutions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSolutions.Name = "nudSolutions";
            this.nudSolutions.Size = new System.Drawing.Size(72, 20);
            this.nudSolutions.TabIndex = 49;
            this.nudSolutions.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkBoxKeepSolutions
            // 
            this.checkBoxKeepSolutions.AutoSize = true;
            this.checkBoxKeepSolutions.Location = new System.Drawing.Point(8, 39);
            this.checkBoxKeepSolutions.Name = "checkBoxKeepSolutions";
            this.checkBoxKeepSolutions.Size = new System.Drawing.Size(95, 17);
            this.checkBoxKeepSolutions.TabIndex = 48;
            this.checkBoxKeepSolutions.Text = "Only keep the ";
            this.checkBoxKeepSolutions.UseVisualStyleBackColor = true;
            // 
            // lbBoxes
            // 
            this.lbBoxes.AutoSize = true;
            this.lbBoxes.Location = new System.Drawing.Point(310, 16);
            this.lbBoxes.Name = "lbBoxes";
            this.lbBoxes.Size = new System.Drawing.Size(44, 13);
            this.lbBoxes.TabIndex = 47;
            this.lbBoxes.Text = "bundles";
            // 
            // nudNumberOfBoxes
            // 
            this.nudNumberOfBoxes.Location = new System.Drawing.Point(231, 16);
            this.nudNumberOfBoxes.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudNumberOfBoxes.Name = "nudNumberOfBoxes";
            this.nudNumberOfBoxes.Size = new System.Drawing.Size(73, 20);
            this.nudNumberOfBoxes.TabIndex = 46;
            // 
            // checkBoxNumberOfPallets
            // 
            this.checkBoxNumberOfPallets.AutoSize = true;
            this.checkBoxNumberOfPallets.Location = new System.Drawing.Point(8, 16);
            this.checkBoxNumberOfPallets.Name = "checkBoxNumberOfPallets";
            this.checkBoxNumberOfPallets.Size = new System.Drawing.Size(221, 17);
            this.checkBoxNumberOfPallets.TabIndex = 45;
            this.checkBoxNumberOfPallets.Text = "Show number of pallets required to stack ";
            this.checkBoxNumberOfPallets.UseVisualStyleBackColor = true;
            // 
            // gbStopStackingCondition
            // 
            this.gbStopStackingCondition.Controls.Add(this.lbMm);
            this.gbStopStackingCondition.Controls.Add(this.lbKg1);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumNumberOfBoxes);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.lbStopStacking);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumNumberOfBoxes);
            this.gbStopStackingCondition.Location = new System.Drawing.Point(8, 212);
            this.gbStopStackingCondition.Name = "gbStopStackingCondition";
            this.gbStopStackingCondition.Size = new System.Drawing.Size(304, 125);
            this.gbStopStackingCondition.TabIndex = 55;
            this.gbStopStackingCondition.TabStop = false;
            this.gbStopStackingCondition.Text = "Stop stacking condition";
            // 
            // lbMm
            // 
            this.lbMm.AutoSize = true;
            this.lbMm.Location = new System.Drawing.Point(270, 71);
            this.lbMm.Name = "lbMm";
            this.lbMm.Size = new System.Drawing.Size(23, 13);
            this.lbMm.TabIndex = 30;
            this.lbMm.Text = "mm";
            // 
            // lbKg1
            // 
            this.lbKg1.AutoSize = true;
            this.lbKg1.Location = new System.Drawing.Point(270, 99);
            this.lbKg1.Name = "lbKg1";
            this.lbKg1.Size = new System.Drawing.Size(19, 13);
            this.lbKg1.TabIndex = 29;
            this.lbKg1.Text = "kg";
            // 
            // nudMaximumPalletWeight
            // 
            this.nudMaximumPalletWeight.DecimalPlaces = 1;
            this.nudMaximumPalletWeight.Location = new System.Drawing.Point(205, 97);
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
            this.nudMaximumPalletHeight.Location = new System.Drawing.Point(205, 67);
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
            this.nudMaximumNumberOfBoxes.Location = new System.Drawing.Point(205, 37);
            this.nudMaximumNumberOfBoxes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumNumberOfBoxes.Name = "nudMaximumNumberOfBoxes";
            this.nudMaximumNumberOfBoxes.Size = new System.Drawing.Size(55, 20);
            this.nudMaximumNumberOfBoxes.TabIndex = 24;
            // 
            // checkBoxMaximumPalletWeight
            // 
            this.checkBoxMaximumPalletWeight.AutoSize = true;
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
            this.lbStopStacking.Location = new System.Drawing.Point(9, 20);
            this.lbStopStacking.Name = "lbStopStacking";
            this.lbStopStacking.Size = new System.Drawing.Size(75, 13);
            this.lbStopStacking.TabIndex = 21;
            this.lbStopStacking.Text = "Stop stacking:";
            // 
            // checkBoxMaximumPalletHeight
            // 
            this.checkBoxMaximumPalletHeight.AutoSize = true;
            this.checkBoxMaximumPalletHeight.Location = new System.Drawing.Point(8, 70);
            this.checkBoxMaximumPalletHeight.Name = "checkBoxMaximumPalletHeight";
            this.checkBoxMaximumPalletHeight.Size = new System.Drawing.Size(153, 17);
            this.checkBoxMaximumPalletHeight.TabIndex = 20;
            this.checkBoxMaximumPalletHeight.Text = "when pallet height reaches";
            this.checkBoxMaximumPalletHeight.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaximumNumberOfBoxes
            // 
            this.checkBoxMaximumNumberOfBoxes.AutoSize = true;
            this.checkBoxMaximumNumberOfBoxes.Location = new System.Drawing.Point(8, 40);
            this.checkBoxMaximumNumberOfBoxes.Name = "checkBoxMaximumNumberOfBoxes";
            this.checkBoxMaximumNumberOfBoxes.Size = new System.Drawing.Size(183, 17);
            this.checkBoxMaximumNumberOfBoxes.TabIndex = 19;
            this.checkBoxMaximumNumberOfBoxes.Text = "when number of bundles reaches";
            this.checkBoxMaximumNumberOfBoxes.UseVisualStyleBackColor = true;
            // 
            // FormNewAnalysisBundle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.gbAdditionalData);
            this.Controls.Add(this.gbStopStackingCondition);
            this.Controls.Add(this.gbAllowedLayerPatterns);
            this.Controls.Add(this.gbLayerAlignment);
            this.Controls.Add(this.gbOverhangUnderhang);
            this.Controls.Add(this.cbPallet);
            this.Controls.Add(this.lbPallet);
            this.Controls.Add(this.lbBundle);
            this.Controls.Add(this.cbBox);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnAccept);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewAnalysisBundle";
            this.ShowIcon = false;
            this.Text = "Create new bundle analysis...";
            this.Load += new System.EventHandler(this.FormNewAnalysisBundle_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewAnalysisBundle_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangY)).EndInit();
            this.gbLayerAlignment.ResumeLayout(false);
            this.gbLayerAlignment.PerformLayout();
            this.gbOverhangUnderhang.ResumeLayout(false);
            this.gbOverhangUnderhang.PerformLayout();
            this.gbAllowedLayerPatterns.ResumeLayout(false);
            this.gbAdditionalData.ResumeLayout(false);
            this.gbAdditionalData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSolutions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfBoxes)).EndInit();
            this.gbStopStackingCondition.ResumeLayout(false);
            this.gbStopStackingCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfBoxes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnAccept;
        private System.Windows.Forms.Label lbMm2;
        private System.Windows.Forms.Label lbMm1;
        private System.Windows.Forms.NumericUpDown nudPalletOverhangX;
        private System.Windows.Forms.CheckBox checkBoxAllowAlignedLayer;
        private System.Windows.Forms.NumericUpDown nudPalletOverhangY;
        private System.Windows.Forms.Label lbPalletOverhangWidth;
        private System.Windows.Forms.GroupBox gbLayerAlignment;
        private System.Windows.Forms.CheckBox checkBoxAllowAlternateLayer;
        private System.Windows.Forms.Label lbPalletOverhangLength;
        private System.Windows.Forms.GroupBox gbOverhangUnderhang;
        private System.Windows.Forms.ComboBox cbPallet;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.Label lbBundle;
        private System.Windows.Forms.ComboBox cbBox;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxPatterns;
        private System.Windows.Forms.GroupBox gbAllowedLayerPatterns;
        private System.Windows.Forms.GroupBox gbAdditionalData;
        private System.Windows.Forms.Label lbSolutions;
        private System.Windows.Forms.NumericUpDown nudSolutions;
        private System.Windows.Forms.CheckBox checkBoxKeepSolutions;
        private System.Windows.Forms.Label lbBoxes;
        private System.Windows.Forms.NumericUpDown nudNumberOfBoxes;
        private System.Windows.Forms.CheckBox checkBoxNumberOfPallets;
        private System.Windows.Forms.GroupBox gbStopStackingCondition;
        private System.Windows.Forms.Label lbMm;
        private System.Windows.Forms.Label lbKg1;
        private System.Windows.Forms.NumericUpDown nudMaximumPalletWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumPalletHeight;
        private System.Windows.Forms.NumericUpDown nudMaximumNumberOfBoxes;
        private System.Windows.Forms.CheckBox checkBoxMaximumPalletWeight;
        private System.Windows.Forms.Label lbStopStacking;
        private System.Windows.Forms.CheckBox checkBoxMaximumPalletHeight;
        private System.Windows.Forms.CheckBox checkBoxMaximumNumberOfBoxes;
    }
}