namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewAnalysis
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.pictureBoxPositionX = new System.Windows.Forms.PictureBox();
            this.pictureBoxPositionY = new System.Windows.Forms.PictureBox();
            this.pictureBoxPositionZ = new System.Windows.Forms.PictureBox();
            this.checkBoxPositionX = new System.Windows.Forms.CheckBox();
            this.checkBoxPositionY = new System.Windows.Forms.CheckBox();
            this.checkBoxPositionZ = new System.Windows.Forms.CheckBox();
            this.gbAllowedBoxPositions = new System.Windows.Forms.GroupBox();
            this.lbBox = new System.Windows.Forms.Label();
            this.lbPallet = new System.Windows.Forms.Label();
            this.cbBox = new System.Windows.Forms.ComboBox();
            this.cbPallet = new System.Windows.Forms.ComboBox();
            this.checkedListBoxPatterns = new System.Windows.Forms.CheckedListBox();
            this.gbAllowedLayerPatterns = new System.Windows.Forms.GroupBox();
            this.checkBoxMaximumNumberOfBoxes = new System.Windows.Forms.CheckBox();
            this.checkBoxMaximumPalletHeight = new System.Windows.Forms.CheckBox();
            this.lbStopStacking = new System.Windows.Forms.Label();
            this.checkBoxMaximumPalletWeight = new System.Windows.Forms.CheckBox();
            this.checkBoxMaximumLoadOnBox = new System.Windows.Forms.CheckBox();
            this.nudMaximumNumberOfBoxes = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumPalletHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumPalletWeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumLoadOnBox = new System.Windows.Forms.NumericUpDown();
            this.lbKg2 = new System.Windows.Forms.Label();
            this.lbKg1 = new System.Windows.Forms.Label();
            this.lbMm = new System.Windows.Forms.Label();
            this.checkBoxInterlayer = new System.Windows.Forms.CheckBox();
            this.cbInterlayer = new System.Windows.Forms.ComboBox();
            this.lbInterlayerFreq1 = new System.Windows.Forms.Label();
            this.nudInterlayerFreq = new System.Windows.Forms.NumericUpDown();
            this.lbInterlayerFreq2 = new System.Windows.Forms.Label();
            this.lbPalletOverhangLength = new System.Windows.Forms.Label();
            this.lbPalletOverhangWidth = new System.Windows.Forms.Label();
            this.nudPalletOverhangX = new System.Windows.Forms.NumericUpDown();
            this.nudPalletOverhangY = new System.Windows.Forms.NumericUpDown();
            this.gbOverhangUnderhang = new System.Windows.Forms.GroupBox();
            this.lbMm2 = new System.Windows.Forms.Label();
            this.lbMm1 = new System.Windows.Forms.Label();
            this.checkBoxAllowAlignedLayer = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowAlternateLayer = new System.Windows.Forms.CheckBox();
            this.gbLayerAlignment = new System.Windows.Forms.GroupBox();
            this.gbStopStackingCondition = new System.Windows.Forms.GroupBox();
            this.checkBoxNumberOfPallets = new System.Windows.Forms.CheckBox();
            this.nudNumberOfBoxes = new System.Windows.Forms.NumericUpDown();
            this.lbBoxes = new System.Windows.Forms.Label();
            this.gbAdditionalData = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionZ)).BeginInit();
            this.gbAllowedBoxPositions.SuspendLayout();
            this.gbAllowedLayerPatterns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfBoxes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumLoadOnBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterlayerFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangY)).BeginInit();
            this.gbOverhangUnderhang.SuspendLayout();
            this.gbLayerAlignment.SuspendLayout();
            this.gbStopStackingCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfBoxes)).BeginInit();
            this.gbAdditionalData.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnAccept
            // 
            this.bnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnAccept.Location = new System.Drawing.Point(497, 9);
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
            this.bnCancel.Location = new System.Drawing.Point(497, 38);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "&Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(128, 10);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 20);
            this.tbName.TabIndex = 4;
            this.tbName.Validated += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(128, 36);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(280, 20);
            this.tbDescription.TabIndex = 5;
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // pictureBoxPositionX
            // 
            this.pictureBoxPositionX.Location = new System.Drawing.Point(8, 18);
            this.pictureBoxPositionX.Name = "pictureBoxPositionX";
            this.pictureBoxPositionX.Size = new System.Drawing.Size(107, 92);
            this.pictureBoxPositionX.TabIndex = 6;
            this.pictureBoxPositionX.TabStop = false;
            // 
            // pictureBoxPositionY
            // 
            this.pictureBoxPositionY.Location = new System.Drawing.Point(131, 18);
            this.pictureBoxPositionY.Name = "pictureBoxPositionY";
            this.pictureBoxPositionY.Size = new System.Drawing.Size(107, 92);
            this.pictureBoxPositionY.TabIndex = 7;
            this.pictureBoxPositionY.TabStop = false;
            // 
            // pictureBoxPositionZ
            // 
            this.pictureBoxPositionZ.Location = new System.Drawing.Point(254, 18);
            this.pictureBoxPositionZ.Name = "pictureBoxPositionZ";
            this.pictureBoxPositionZ.Size = new System.Drawing.Size(107, 92);
            this.pictureBoxPositionZ.TabIndex = 8;
            this.pictureBoxPositionZ.TabStop = false;
            // 
            // checkBoxPositionX
            // 
            this.checkBoxPositionX.AutoSize = true;
            this.checkBoxPositionX.Location = new System.Drawing.Point(8, 117);
            this.checkBoxPositionX.Name = "checkBoxPositionX";
            this.checkBoxPositionX.Size = new System.Drawing.Size(33, 17);
            this.checkBoxPositionX.TabIndex = 9;
            this.checkBoxPositionX.Text = "X";
            this.checkBoxPositionX.UseVisualStyleBackColor = true;
            // 
            // checkBoxPositionY
            // 
            this.checkBoxPositionY.AutoSize = true;
            this.checkBoxPositionY.Location = new System.Drawing.Point(131, 117);
            this.checkBoxPositionY.Name = "checkBoxPositionY";
            this.checkBoxPositionY.Size = new System.Drawing.Size(33, 17);
            this.checkBoxPositionY.TabIndex = 10;
            this.checkBoxPositionY.Text = "Y";
            this.checkBoxPositionY.UseVisualStyleBackColor = true;
            // 
            // checkBoxPositionZ
            // 
            this.checkBoxPositionZ.AutoSize = true;
            this.checkBoxPositionZ.Location = new System.Drawing.Point(254, 117);
            this.checkBoxPositionZ.Name = "checkBoxPositionZ";
            this.checkBoxPositionZ.Size = new System.Drawing.Size(33, 17);
            this.checkBoxPositionZ.TabIndex = 11;
            this.checkBoxPositionZ.Text = "Z";
            this.checkBoxPositionZ.UseVisualStyleBackColor = true;
            // 
            // gbAllowedBoxPositions
            // 
            this.gbAllowedBoxPositions.Controls.Add(this.checkBoxPositionZ);
            this.gbAllowedBoxPositions.Controls.Add(this.checkBoxPositionY);
            this.gbAllowedBoxPositions.Controls.Add(this.checkBoxPositionX);
            this.gbAllowedBoxPositions.Controls.Add(this.pictureBoxPositionZ);
            this.gbAllowedBoxPositions.Controls.Add(this.pictureBoxPositionY);
            this.gbAllowedBoxPositions.Controls.Add(this.pictureBoxPositionX);
            this.gbAllowedBoxPositions.Location = new System.Drawing.Point(5, 203);
            this.gbAllowedBoxPositions.Name = "gbAllowedBoxPositions";
            this.gbAllowedBoxPositions.Size = new System.Drawing.Size(377, 144);
            this.gbAllowedBoxPositions.TabIndex = 12;
            this.gbAllowedBoxPositions.TabStop = false;
            this.gbAllowedBoxPositions.Text = "Allowed box positions";
            // 
            // lbBox
            // 
            this.lbBox.AutoSize = true;
            this.lbBox.Location = new System.Drawing.Point(17, 63);
            this.lbBox.Name = "lbBox";
            this.lbBox.Size = new System.Drawing.Size(25, 13);
            this.lbBox.TabIndex = 13;
            this.lbBox.Text = "Box";
            // 
            // lbPallet
            // 
            this.lbPallet.AutoSize = true;
            this.lbPallet.Location = new System.Drawing.Point(312, 63);
            this.lbPallet.Name = "lbPallet";
            this.lbPallet.Size = new System.Drawing.Size(33, 13);
            this.lbPallet.TabIndex = 14;
            this.lbPallet.Text = "Pallet";
            // 
            // cbBox
            // 
            this.cbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBox.FormattingEnabled = true;
            this.cbBox.Location = new System.Drawing.Point(129, 63);
            this.cbBox.Name = "cbBox";
            this.cbBox.Size = new System.Drawing.Size(121, 21);
            this.cbBox.TabIndex = 15;
            this.cbBox.SelectedIndexChanged += new System.EventHandler(this.onBoxChanged);
            // 
            // cbPallet
            // 
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            this.cbPallet.Location = new System.Drawing.Point(362, 63);
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.Size = new System.Drawing.Size(121, 21);
            this.cbPallet.TabIndex = 16;
            // 
            // checkedListBoxPatterns
            // 
            this.checkedListBoxPatterns.FormattingEnabled = true;
            this.checkedListBoxPatterns.Items.AddRange(new object[] {
            "Column",
            "Interlocked",
            "Spirale"});
            this.checkedListBoxPatterns.Location = new System.Drawing.Point(12, 18);
            this.checkedListBoxPatterns.Name = "checkedListBoxPatterns";
            this.checkedListBoxPatterns.Size = new System.Drawing.Size(162, 109);
            this.checkedListBoxPatterns.TabIndex = 17;
            // 
            // gbAllowedLayerPatterns
            // 
            this.gbAllowedLayerPatterns.Controls.Add(this.checkedListBoxPatterns);
            this.gbAllowedLayerPatterns.Location = new System.Drawing.Point(388, 203);
            this.gbAllowedLayerPatterns.Name = "gbAllowedLayerPatterns";
            this.gbAllowedLayerPatterns.Size = new System.Drawing.Size(188, 144);
            this.gbAllowedLayerPatterns.TabIndex = 18;
            this.gbAllowedLayerPatterns.TabStop = false;
            this.gbAllowedLayerPatterns.Text = "Allowed layer patterns";
            // 
            // checkBoxMaximumNumberOfBoxes
            // 
            this.checkBoxMaximumNumberOfBoxes.AutoSize = true;
            this.checkBoxMaximumNumberOfBoxes.Location = new System.Drawing.Point(8, 40);
            this.checkBoxMaximumNumberOfBoxes.Name = "checkBoxMaximumNumberOfBoxes";
            this.checkBoxMaximumNumberOfBoxes.Size = new System.Drawing.Size(174, 17);
            this.checkBoxMaximumNumberOfBoxes.TabIndex = 19;
            this.checkBoxMaximumNumberOfBoxes.Text = "when number of boxes reaches";
            this.checkBoxMaximumNumberOfBoxes.UseVisualStyleBackColor = true;
            this.checkBoxMaximumNumberOfBoxes.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
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
            this.checkBoxMaximumPalletHeight.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
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
            // checkBoxMaximumPalletWeight
            // 
            this.checkBoxMaximumPalletWeight.AutoSize = true;
            this.checkBoxMaximumPalletWeight.Location = new System.Drawing.Point(8, 100);
            this.checkBoxMaximumPalletWeight.Name = "checkBoxMaximumPalletWeight";
            this.checkBoxMaximumPalletWeight.Size = new System.Drawing.Size(178, 17);
            this.checkBoxMaximumPalletWeight.TabIndex = 22;
            this.checkBoxMaximumPalletWeight.Text = "when total pallet weight reaches";
            this.checkBoxMaximumPalletWeight.UseVisualStyleBackColor = true;
            this.checkBoxMaximumPalletWeight.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
            // 
            // checkBoxMaximumLoadOnBox
            // 
            this.checkBoxMaximumLoadOnBox.AutoSize = true;
            this.checkBoxMaximumLoadOnBox.Location = new System.Drawing.Point(8, 130);
            this.checkBoxMaximumLoadOnBox.Name = "checkBoxMaximumLoadOnBox";
            this.checkBoxMaximumLoadOnBox.Size = new System.Drawing.Size(190, 17);
            this.checkBoxMaximumLoadOnBox.TabIndex = 23;
            this.checkBoxMaximumLoadOnBox.Text = "when load on lower boxes reaches";
            this.checkBoxMaximumLoadOnBox.UseVisualStyleBackColor = true;
            this.checkBoxMaximumLoadOnBox.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
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
            // nudMaximumLoadOnBox
            // 
            this.nudMaximumLoadOnBox.DecimalPlaces = 1;
            this.nudMaximumLoadOnBox.Location = new System.Drawing.Point(205, 127);
            this.nudMaximumLoadOnBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumLoadOnBox.Name = "nudMaximumLoadOnBox";
            this.nudMaximumLoadOnBox.Size = new System.Drawing.Size(55, 20);
            this.nudMaximumLoadOnBox.TabIndex = 27;
            // 
            // lbKg2
            // 
            this.lbKg2.AutoSize = true;
            this.lbKg2.Location = new System.Drawing.Point(270, 129);
            this.lbKg2.Name = "lbKg2";
            this.lbKg2.Size = new System.Drawing.Size(19, 13);
            this.lbKg2.TabIndex = 28;
            this.lbKg2.Text = "kg";
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
            // lbMm
            // 
            this.lbMm.AutoSize = true;
            this.lbMm.Location = new System.Drawing.Point(270, 71);
            this.lbMm.Name = "lbMm";
            this.lbMm.Size = new System.Drawing.Size(23, 13);
            this.lbMm.TabIndex = 30;
            this.lbMm.Text = "mm";
            // 
            // checkBoxInterlayer
            // 
            this.checkBoxInterlayer.AutoSize = true;
            this.checkBoxInterlayer.Location = new System.Drawing.Point(20, 93);
            this.checkBoxInterlayer.Name = "checkBoxInterlayer";
            this.checkBoxInterlayer.Size = new System.Drawing.Size(69, 17);
            this.checkBoxInterlayer.TabIndex = 31;
            this.checkBoxInterlayer.Text = "Interlayer";
            this.checkBoxInterlayer.UseVisualStyleBackColor = true;
            this.checkBoxInterlayer.CheckedChanged += new System.EventHandler(this.onInterlayerChecked);
            // 
            // cbInterlayer
            // 
            this.cbInterlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterlayer.FormattingEnabled = true;
            this.cbInterlayer.Location = new System.Drawing.Point(129, 93);
            this.cbInterlayer.Name = "cbInterlayer";
            this.cbInterlayer.Size = new System.Drawing.Size(121, 21);
            this.cbInterlayer.TabIndex = 32;
            // 
            // lbInterlayerFreq1
            // 
            this.lbInterlayerFreq1.AutoSize = true;
            this.lbInterlayerFreq1.Location = new System.Drawing.Point(262, 97);
            this.lbInterlayerFreq1.Name = "lbInterlayerFreq1";
            this.lbInterlayerFreq1.Size = new System.Drawing.Size(39, 13);
            this.lbInterlayerFreq1.TabIndex = 33;
            this.lbInterlayerFreq1.Text = "every  ";
            // 
            // nudInterlayerFreq
            // 
            this.nudInterlayerFreq.Location = new System.Drawing.Point(308, 93);
            this.nudInterlayerFreq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterlayerFreq.Name = "nudInterlayerFreq";
            this.nudInterlayerFreq.Size = new System.Drawing.Size(45, 20);
            this.nudInterlayerFreq.TabIndex = 34;
            this.nudInterlayerFreq.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbInterlayerFreq2
            // 
            this.lbInterlayerFreq2.AutoSize = true;
            this.lbInterlayerFreq2.Location = new System.Drawing.Point(368, 97);
            this.lbInterlayerFreq2.Name = "lbInterlayerFreq2";
            this.lbInterlayerFreq2.Size = new System.Drawing.Size(34, 13);
            this.lbInterlayerFreq2.TabIndex = 35;
            this.lbInterlayerFreq2.Text = "layers";
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
            // lbPalletOverhangWidth
            // 
            this.lbPalletOverhangWidth.AutoSize = true;
            this.lbPalletOverhangWidth.Location = new System.Drawing.Point(12, 47);
            this.lbPalletOverhangWidth.Name = "lbPalletOverhangWidth";
            this.lbPalletOverhangWidth.Size = new System.Drawing.Size(35, 13);
            this.lbPalletOverhangWidth.TabIndex = 37;
            this.lbPalletOverhangWidth.Text = "Width";
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
            // gbOverhangUnderhang
            // 
            this.gbOverhangUnderhang.Controls.Add(this.lbMm2);
            this.gbOverhangUnderhang.Controls.Add(this.lbMm1);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangY);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangX);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangWidth);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangLength);
            this.gbOverhangUnderhang.Location = new System.Drawing.Point(5, 119);
            this.gbOverhangUnderhang.Name = "gbOverhangUnderhang";
            this.gbOverhangUnderhang.Size = new System.Drawing.Size(247, 78);
            this.gbOverhangUnderhang.TabIndex = 40;
            this.gbOverhangUnderhang.TabStop = false;
            this.gbOverhangUnderhang.Text = "Pallet overhang / underhang";
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
            // checkBoxAllowAlignedLayer
            // 
            this.checkBoxAllowAlignedLayer.AutoSize = true;
            this.checkBoxAllowAlignedLayer.Location = new System.Drawing.Point(10, 20);
            this.checkBoxAllowAlignedLayer.Name = "checkBoxAllowAlignedLayer";
            this.checkBoxAllowAlignedLayer.Size = new System.Drawing.Size(112, 17);
            this.checkBoxAllowAlignedLayer.TabIndex = 41;
            this.checkBoxAllowAlignedLayer.Text = "allow aligned layer";
            this.checkBoxAllowAlignedLayer.UseVisualStyleBackColor = true;
            this.checkBoxAllowAlignedLayer.CheckedChanged += new System.EventHandler(this.onCheckedChangedAlignedLayer);
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
            this.checkBoxAllowAlternateLayer.CheckedChanged += new System.EventHandler(this.onCheckedChangedAlternateLayer);
            // 
            // gbLayerAlignment
            // 
            this.gbLayerAlignment.Controls.Add(this.checkBoxAllowAlternateLayer);
            this.gbLayerAlignment.Controls.Add(this.checkBoxAllowAlignedLayer);
            this.gbLayerAlignment.Location = new System.Drawing.Point(258, 119);
            this.gbLayerAlignment.Name = "gbLayerAlignment";
            this.gbLayerAlignment.Size = new System.Drawing.Size(317, 78);
            this.gbLayerAlignment.TabIndex = 43;
            this.gbLayerAlignment.TabStop = false;
            this.gbLayerAlignment.Text = "Layer alignment";
            // 
            // gbStopStackingCondition
            // 
            this.gbStopStackingCondition.Controls.Add(this.lbMm);
            this.gbStopStackingCondition.Controls.Add(this.lbKg1);
            this.gbStopStackingCondition.Controls.Add(this.lbKg2);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumLoadOnBox);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumNumberOfBoxes);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumLoadOnBox);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.lbStopStacking);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumNumberOfBoxes);
            this.gbStopStackingCondition.Location = new System.Drawing.Point(8, 356);
            this.gbStopStackingCondition.Name = "gbStopStackingCondition";
            this.gbStopStackingCondition.Size = new System.Drawing.Size(373, 154);
            this.gbStopStackingCondition.TabIndex = 44;
            this.gbStopStackingCondition.TabStop = false;
            this.gbStopStackingCondition.Text = "Stop stacking condition";
            // 
            // checkBoxNumberOfPallets
            // 
            this.checkBoxNumberOfPallets.AutoSize = true;
            this.checkBoxNumberOfPallets.Location = new System.Drawing.Point(8, 27);
            this.checkBoxNumberOfPallets.Name = "checkBoxNumberOfPallets";
            this.checkBoxNumberOfPallets.Size = new System.Drawing.Size(221, 17);
            this.checkBoxNumberOfPallets.TabIndex = 45;
            this.checkBoxNumberOfPallets.Text = "Show number of pallets required to stack ";
            this.checkBoxNumberOfPallets.UseVisualStyleBackColor = true;
            // 
            // nudNumberOfBoxes
            // 
            this.nudNumberOfBoxes.Location = new System.Drawing.Point(231, 27);
            this.nudNumberOfBoxes.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudNumberOfBoxes.Name = "nudNumberOfBoxes";
            this.nudNumberOfBoxes.Size = new System.Drawing.Size(73, 20);
            this.nudNumberOfBoxes.TabIndex = 46;
            // 
            // lbBoxes
            // 
            this.lbBoxes.AutoSize = true;
            this.lbBoxes.Location = new System.Drawing.Point(310, 27);
            this.lbBoxes.Name = "lbBoxes";
            this.lbBoxes.Size = new System.Drawing.Size(35, 13);
            this.lbBoxes.TabIndex = 47;
            this.lbBoxes.Text = "boxes";
            // 
            // gbAdditionalData
            // 
            this.gbAdditionalData.Controls.Add(this.lbBoxes);
            this.gbAdditionalData.Controls.Add(this.nudNumberOfBoxes);
            this.gbAdditionalData.Controls.Add(this.checkBoxNumberOfPallets);
            this.gbAdditionalData.Location = new System.Drawing.Point(8, 516);
            this.gbAdditionalData.Name = "gbAdditionalData";
            this.gbAdditionalData.Size = new System.Drawing.Size(568, 54);
            this.gbAdditionalData.TabIndex = 48;
            this.gbAdditionalData.TabStop = false;
            this.gbAdditionalData.Text = "Additional data";
            // 
            // FormNewAnalysis
            // 
            this.AcceptButton = this.bnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(584, 575);
            this.Controls.Add(this.gbAdditionalData);
            this.Controls.Add(this.gbStopStackingCondition);
            this.Controls.Add(this.gbLayerAlignment);
            this.Controls.Add(this.gbOverhangUnderhang);
            this.Controls.Add(this.lbInterlayerFreq2);
            this.Controls.Add(this.nudInterlayerFreq);
            this.Controls.Add(this.lbInterlayerFreq1);
            this.Controls.Add(this.cbInterlayer);
            this.Controls.Add(this.checkBoxInterlayer);
            this.Controls.Add(this.gbAllowedLayerPatterns);
            this.Controls.Add(this.cbPallet);
            this.Controls.Add(this.cbBox);
            this.Controls.Add(this.lbPallet);
            this.Controls.Add(this.lbBox);
            this.Controls.Add(this.gbAllowedBoxPositions);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnAccept);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Create new Analysis...";
            this.Load += new System.EventHandler(this.FormNewAnalysis_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewAnalysis_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionZ)).EndInit();
            this.gbAllowedBoxPositions.ResumeLayout(false);
            this.gbAllowedBoxPositions.PerformLayout();
            this.gbAllowedLayerPatterns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfBoxes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumLoadOnBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterlayerFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangY)).EndInit();
            this.gbOverhangUnderhang.ResumeLayout(false);
            this.gbOverhangUnderhang.PerformLayout();
            this.gbLayerAlignment.ResumeLayout(false);
            this.gbLayerAlignment.PerformLayout();
            this.gbStopStackingCondition.ResumeLayout(false);
            this.gbStopStackingCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfBoxes)).EndInit();
            this.gbAdditionalData.ResumeLayout(false);
            this.gbAdditionalData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnAccept;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.PictureBox pictureBoxPositionX;
        private System.Windows.Forms.PictureBox pictureBoxPositionY;
        private System.Windows.Forms.PictureBox pictureBoxPositionZ;
        private System.Windows.Forms.CheckBox checkBoxPositionX;
        private System.Windows.Forms.CheckBox checkBoxPositionY;
        private System.Windows.Forms.CheckBox checkBoxPositionZ;
        private System.Windows.Forms.GroupBox gbAllowedBoxPositions;
        private System.Windows.Forms.Label lbBox;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.ComboBox cbBox;
        private System.Windows.Forms.ComboBox cbPallet;
        private System.Windows.Forms.CheckedListBox checkedListBoxPatterns;
        private System.Windows.Forms.GroupBox gbAllowedLayerPatterns;
        private System.Windows.Forms.CheckBox checkBoxMaximumNumberOfBoxes;
        private System.Windows.Forms.CheckBox checkBoxMaximumPalletHeight;
        private System.Windows.Forms.Label lbStopStacking;
        private System.Windows.Forms.CheckBox checkBoxMaximumPalletWeight;
        private System.Windows.Forms.CheckBox checkBoxMaximumLoadOnBox;
        private System.Windows.Forms.NumericUpDown nudMaximumNumberOfBoxes;
        private System.Windows.Forms.NumericUpDown nudMaximumPalletHeight;
        private System.Windows.Forms.NumericUpDown nudMaximumPalletWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumLoadOnBox;
        private System.Windows.Forms.Label lbKg2;
        private System.Windows.Forms.Label lbKg1;
        private System.Windows.Forms.Label lbMm;
        private System.Windows.Forms.CheckBox checkBoxInterlayer;
        private System.Windows.Forms.ComboBox cbInterlayer;
        private System.Windows.Forms.Label lbInterlayerFreq1;
        private System.Windows.Forms.NumericUpDown nudInterlayerFreq;
        private System.Windows.Forms.Label lbInterlayerFreq2;
        private System.Windows.Forms.Label lbPalletOverhangLength;
        private System.Windows.Forms.Label lbPalletOverhangWidth;
        private System.Windows.Forms.NumericUpDown nudPalletOverhangX;
        private System.Windows.Forms.NumericUpDown nudPalletOverhangY;
        private System.Windows.Forms.GroupBox gbOverhangUnderhang;
        private System.Windows.Forms.Label lbMm2;
        private System.Windows.Forms.Label lbMm1;
        private System.Windows.Forms.CheckBox checkBoxAllowAlignedLayer;
        private System.Windows.Forms.CheckBox checkBoxAllowAlternateLayer;
        private System.Windows.Forms.GroupBox gbLayerAlignment;
        private System.Windows.Forms.GroupBox gbStopStackingCondition;
        private System.Windows.Forms.CheckBox checkBoxNumberOfPallets;
        private System.Windows.Forms.NumericUpDown nudNumberOfBoxes;
        private System.Windows.Forms.Label lbBoxes;
        private System.Windows.Forms.GroupBox gbAdditionalData;
    }
}