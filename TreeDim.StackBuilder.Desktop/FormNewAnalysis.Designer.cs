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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewAnalysis));
            this.bnOk = new System.Windows.Forms.Button();
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
            this.uMassLoadLowerCases = new System.Windows.Forms.Label();
            this.uMassPalletWeight = new System.Windows.Forms.Label();
            this.uLengthPalletHeight = new System.Windows.Forms.Label();
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
            this.uLengthOverhangY = new System.Windows.Forms.Label();
            this.uLengthOverhangX = new System.Windows.Forms.Label();
            this.checkBoxAllowAlignedLayer = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowAlternateLayer = new System.Windows.Forms.CheckBox();
            this.gbLayerAlignment = new System.Windows.Forms.GroupBox();
            this.gbStopStackingCondition = new System.Windows.Forms.GroupBox();
            this.checkBoxNumberOfPallets = new System.Windows.Forms.CheckBox();
            this.nudNumberOfBoxes = new System.Windows.Forms.NumericUpDown();
            this.lbBoxes = new System.Windows.Forms.Label();
            this.gbAdditionalData = new System.Windows.Forms.GroupBox();
            this.lbSolutions = new System.Windows.Forms.Label();
            this.nudSolutions = new System.Windows.Forms.NumericUpDown();
            this.checkBoxKeepSolutions = new System.Windows.Forms.CheckBox();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.nudSolutions)).BeginInit();
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.Validated += new System.EventHandler(this.onFormContentChanged);
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.TextChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // pictureBoxPositionX
            // 
            resources.ApplyResources(this.pictureBoxPositionX, "pictureBoxPositionX");
            this.pictureBoxPositionX.Name = "pictureBoxPositionX";
            this.pictureBoxPositionX.TabStop = false;
            // 
            // pictureBoxPositionY
            // 
            resources.ApplyResources(this.pictureBoxPositionY, "pictureBoxPositionY");
            this.pictureBoxPositionY.Name = "pictureBoxPositionY";
            this.pictureBoxPositionY.TabStop = false;
            // 
            // pictureBoxPositionZ
            // 
            resources.ApplyResources(this.pictureBoxPositionZ, "pictureBoxPositionZ");
            this.pictureBoxPositionZ.Name = "pictureBoxPositionZ";
            this.pictureBoxPositionZ.TabStop = false;
            // 
            // checkBoxPositionX
            // 
            resources.ApplyResources(this.checkBoxPositionX, "checkBoxPositionX");
            this.checkBoxPositionX.Name = "checkBoxPositionX";
            this.checkBoxPositionX.UseVisualStyleBackColor = true;
            this.checkBoxPositionX.CheckedChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // checkBoxPositionY
            // 
            resources.ApplyResources(this.checkBoxPositionY, "checkBoxPositionY");
            this.checkBoxPositionY.Name = "checkBoxPositionY";
            this.checkBoxPositionY.UseVisualStyleBackColor = true;
            this.checkBoxPositionY.CheckedChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // checkBoxPositionZ
            // 
            resources.ApplyResources(this.checkBoxPositionZ, "checkBoxPositionZ");
            this.checkBoxPositionZ.Name = "checkBoxPositionZ";
            this.checkBoxPositionZ.UseVisualStyleBackColor = true;
            this.checkBoxPositionZ.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
            // 
            // gbAllowedBoxPositions
            // 
            this.gbAllowedBoxPositions.Controls.Add(this.checkBoxPositionZ);
            this.gbAllowedBoxPositions.Controls.Add(this.checkBoxPositionY);
            this.gbAllowedBoxPositions.Controls.Add(this.checkBoxPositionX);
            this.gbAllowedBoxPositions.Controls.Add(this.pictureBoxPositionZ);
            this.gbAllowedBoxPositions.Controls.Add(this.pictureBoxPositionY);
            this.gbAllowedBoxPositions.Controls.Add(this.pictureBoxPositionX);
            resources.ApplyResources(this.gbAllowedBoxPositions, "gbAllowedBoxPositions");
            this.gbAllowedBoxPositions.Name = "gbAllowedBoxPositions";
            this.gbAllowedBoxPositions.TabStop = false;
            // 
            // lbBox
            // 
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Name = "lbBox";
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // cbBox
            // 
            this.cbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBox.FormattingEnabled = true;
            resources.ApplyResources(this.cbBox, "cbBox");
            this.cbBox.Name = "cbBox";
            this.cbBox.SelectedIndexChanged += new System.EventHandler(this.onBoxChanged);
            // 
            // cbPallet
            // 
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            resources.ApplyResources(this.cbPallet, "cbPallet");
            this.cbPallet.Name = "cbPallet";
            // 
            // checkedListBoxPatterns
            // 
            this.checkedListBoxPatterns.CheckOnClick = true;
            this.checkedListBoxPatterns.FormattingEnabled = true;
            this.checkedListBoxPatterns.Items.AddRange(new object[] {
            resources.GetString("checkedListBoxPatterns.Items"),
            resources.GetString("checkedListBoxPatterns.Items1"),
            resources.GetString("checkedListBoxPatterns.Items2"),
            resources.GetString("checkedListBoxPatterns.Items3"),
            resources.GetString("checkedListBoxPatterns.Items4"),
            resources.GetString("checkedListBoxPatterns.Items5")});
            resources.ApplyResources(this.checkedListBoxPatterns, "checkedListBoxPatterns");
            this.checkedListBoxPatterns.Name = "checkedListBoxPatterns";
            // 
            // gbAllowedLayerPatterns
            // 
            this.gbAllowedLayerPatterns.Controls.Add(this.checkedListBoxPatterns);
            resources.ApplyResources(this.gbAllowedLayerPatterns, "gbAllowedLayerPatterns");
            this.gbAllowedLayerPatterns.Name = "gbAllowedLayerPatterns";
            this.gbAllowedLayerPatterns.TabStop = false;
            // 
            // checkBoxMaximumNumberOfBoxes
            // 
            resources.ApplyResources(this.checkBoxMaximumNumberOfBoxes, "checkBoxMaximumNumberOfBoxes");
            this.checkBoxMaximumNumberOfBoxes.Name = "checkBoxMaximumNumberOfBoxes";
            this.checkBoxMaximumNumberOfBoxes.UseVisualStyleBackColor = true;
            this.checkBoxMaximumNumberOfBoxes.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
            // 
            // checkBoxMaximumPalletHeight
            // 
            resources.ApplyResources(this.checkBoxMaximumPalletHeight, "checkBoxMaximumPalletHeight");
            this.checkBoxMaximumPalletHeight.Name = "checkBoxMaximumPalletHeight";
            this.checkBoxMaximumPalletHeight.UseVisualStyleBackColor = true;
            this.checkBoxMaximumPalletHeight.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
            // 
            // lbStopStacking
            // 
            resources.ApplyResources(this.lbStopStacking, "lbStopStacking");
            this.lbStopStacking.Name = "lbStopStacking";
            // 
            // checkBoxMaximumPalletWeight
            // 
            resources.ApplyResources(this.checkBoxMaximumPalletWeight, "checkBoxMaximumPalletWeight");
            this.checkBoxMaximumPalletWeight.Name = "checkBoxMaximumPalletWeight";
            this.checkBoxMaximumPalletWeight.UseVisualStyleBackColor = true;
            this.checkBoxMaximumPalletWeight.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
            // 
            // checkBoxMaximumLoadOnBox
            // 
            resources.ApplyResources(this.checkBoxMaximumLoadOnBox, "checkBoxMaximumLoadOnBox");
            this.checkBoxMaximumLoadOnBox.Name = "checkBoxMaximumLoadOnBox";
            this.checkBoxMaximumLoadOnBox.UseVisualStyleBackColor = true;
            this.checkBoxMaximumLoadOnBox.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
            // 
            // nudMaximumNumberOfBoxes
            // 
            resources.ApplyResources(this.nudMaximumNumberOfBoxes, "nudMaximumNumberOfBoxes");
            this.nudMaximumNumberOfBoxes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumNumberOfBoxes.Name = "nudMaximumNumberOfBoxes";
            // 
            // nudMaximumPalletHeight
            // 
            resources.ApplyResources(this.nudMaximumPalletHeight, "nudMaximumPalletHeight");
            this.nudMaximumPalletHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumPalletHeight.Name = "nudMaximumPalletHeight";
            // 
            // nudMaximumPalletWeight
            // 
            this.nudMaximumPalletWeight.DecimalPlaces = 1;
            resources.ApplyResources(this.nudMaximumPalletWeight, "nudMaximumPalletWeight");
            this.nudMaximumPalletWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumPalletWeight.Name = "nudMaximumPalletWeight";
            // 
            // nudMaximumLoadOnBox
            // 
            this.nudMaximumLoadOnBox.DecimalPlaces = 1;
            resources.ApplyResources(this.nudMaximumLoadOnBox, "nudMaximumLoadOnBox");
            this.nudMaximumLoadOnBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumLoadOnBox.Name = "nudMaximumLoadOnBox";
            // 
            // uMassLoadLowerCases
            // 
            resources.ApplyResources(this.uMassLoadLowerCases, "uMassLoadLowerCases");
            this.uMassLoadLowerCases.Name = "uMassLoadLowerCases";
            // 
            // uMassPalletWeight
            // 
            resources.ApplyResources(this.uMassPalletWeight, "uMassPalletWeight");
            this.uMassPalletWeight.Name = "uMassPalletWeight";
            // 
            // uLengthPalletHeight
            // 
            resources.ApplyResources(this.uLengthPalletHeight, "uLengthPalletHeight");
            this.uLengthPalletHeight.Name = "uLengthPalletHeight";
            // 
            // checkBoxInterlayer
            // 
            resources.ApplyResources(this.checkBoxInterlayer, "checkBoxInterlayer");
            this.checkBoxInterlayer.Name = "checkBoxInterlayer";
            this.checkBoxInterlayer.UseVisualStyleBackColor = true;
            this.checkBoxInterlayer.CheckedChanged += new System.EventHandler(this.onInterlayerChecked);
            // 
            // cbInterlayer
            // 
            this.cbInterlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterlayer.FormattingEnabled = true;
            resources.ApplyResources(this.cbInterlayer, "cbInterlayer");
            this.cbInterlayer.Name = "cbInterlayer";
            // 
            // lbInterlayerFreq1
            // 
            resources.ApplyResources(this.lbInterlayerFreq1, "lbInterlayerFreq1");
            this.lbInterlayerFreq1.Name = "lbInterlayerFreq1";
            // 
            // nudInterlayerFreq
            // 
            resources.ApplyResources(this.nudInterlayerFreq, "nudInterlayerFreq");
            this.nudInterlayerFreq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterlayerFreq.Name = "nudInterlayerFreq";
            this.nudInterlayerFreq.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbInterlayerFreq2
            // 
            resources.ApplyResources(this.lbInterlayerFreq2, "lbInterlayerFreq2");
            this.lbInterlayerFreq2.Name = "lbInterlayerFreq2";
            // 
            // lbPalletOverhangLength
            // 
            resources.ApplyResources(this.lbPalletOverhangLength, "lbPalletOverhangLength");
            this.lbPalletOverhangLength.Name = "lbPalletOverhangLength";
            // 
            // lbPalletOverhangWidth
            // 
            resources.ApplyResources(this.lbPalletOverhangWidth, "lbPalletOverhangWidth");
            this.lbPalletOverhangWidth.Name = "lbPalletOverhangWidth";
            // 
            // nudPalletOverhangX
            // 
            resources.ApplyResources(this.nudPalletOverhangX, "nudPalletOverhangX");
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
            // 
            // nudPalletOverhangY
            // 
            resources.ApplyResources(this.nudPalletOverhangY, "nudPalletOverhangY");
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
            // 
            // gbOverhangUnderhang
            // 
            this.gbOverhangUnderhang.Controls.Add(this.uLengthOverhangY);
            this.gbOverhangUnderhang.Controls.Add(this.uLengthOverhangX);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangY);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangX);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangWidth);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangLength);
            resources.ApplyResources(this.gbOverhangUnderhang, "gbOverhangUnderhang");
            this.gbOverhangUnderhang.Name = "gbOverhangUnderhang";
            this.gbOverhangUnderhang.TabStop = false;
            // 
            // uLengthOverhangY
            // 
            resources.ApplyResources(this.uLengthOverhangY, "uLengthOverhangY");
            this.uLengthOverhangY.Name = "uLengthOverhangY";
            // 
            // uLengthOverhangX
            // 
            resources.ApplyResources(this.uLengthOverhangX, "uLengthOverhangX");
            this.uLengthOverhangX.Name = "uLengthOverhangX";
            // 
            // checkBoxAllowAlignedLayer
            // 
            resources.ApplyResources(this.checkBoxAllowAlignedLayer, "checkBoxAllowAlignedLayer");
            this.checkBoxAllowAlignedLayer.Name = "checkBoxAllowAlignedLayer";
            this.checkBoxAllowAlignedLayer.UseVisualStyleBackColor = true;
            this.checkBoxAllowAlignedLayer.CheckedChanged += new System.EventHandler(this.onCheckedChangedAlignedLayer);
            // 
            // checkBoxAllowAlternateLayer
            // 
            resources.ApplyResources(this.checkBoxAllowAlternateLayer, "checkBoxAllowAlternateLayer");
            this.checkBoxAllowAlternateLayer.Name = "checkBoxAllowAlternateLayer";
            this.checkBoxAllowAlternateLayer.UseVisualStyleBackColor = true;
            this.checkBoxAllowAlternateLayer.CheckedChanged += new System.EventHandler(this.onCheckedChangedAlternateLayer);
            // 
            // gbLayerAlignment
            // 
            this.gbLayerAlignment.Controls.Add(this.checkBoxAllowAlternateLayer);
            this.gbLayerAlignment.Controls.Add(this.checkBoxAllowAlignedLayer);
            resources.ApplyResources(this.gbLayerAlignment, "gbLayerAlignment");
            this.gbLayerAlignment.Name = "gbLayerAlignment";
            this.gbLayerAlignment.TabStop = false;
            // 
            // gbStopStackingCondition
            // 
            this.gbStopStackingCondition.Controls.Add(this.uLengthPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.uMassPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.uMassLoadLowerCases);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumLoadOnBox);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumNumberOfBoxes);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumLoadOnBox);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.lbStopStacking);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumNumberOfBoxes);
            resources.ApplyResources(this.gbStopStackingCondition, "gbStopStackingCondition");
            this.gbStopStackingCondition.Name = "gbStopStackingCondition";
            this.gbStopStackingCondition.TabStop = false;
            // 
            // checkBoxNumberOfPallets
            // 
            resources.ApplyResources(this.checkBoxNumberOfPallets, "checkBoxNumberOfPallets");
            this.checkBoxNumberOfPallets.Name = "checkBoxNumberOfPallets";
            this.checkBoxNumberOfPallets.UseVisualStyleBackColor = true;
            // 
            // nudNumberOfBoxes
            // 
            resources.ApplyResources(this.nudNumberOfBoxes, "nudNumberOfBoxes");
            this.nudNumberOfBoxes.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudNumberOfBoxes.Name = "nudNumberOfBoxes";
            // 
            // lbBoxes
            // 
            resources.ApplyResources(this.lbBoxes, "lbBoxes");
            this.lbBoxes.Name = "lbBoxes";
            // 
            // gbAdditionalData
            // 
            this.gbAdditionalData.Controls.Add(this.lbSolutions);
            this.gbAdditionalData.Controls.Add(this.nudSolutions);
            this.gbAdditionalData.Controls.Add(this.checkBoxKeepSolutions);
            this.gbAdditionalData.Controls.Add(this.lbBoxes);
            this.gbAdditionalData.Controls.Add(this.nudNumberOfBoxes);
            this.gbAdditionalData.Controls.Add(this.checkBoxNumberOfPallets);
            resources.ApplyResources(this.gbAdditionalData, "gbAdditionalData");
            this.gbAdditionalData.Name = "gbAdditionalData";
            this.gbAdditionalData.TabStop = false;
            // 
            // lbSolutions
            // 
            resources.ApplyResources(this.lbSolutions, "lbSolutions");
            this.lbSolutions.Name = "lbSolutions";
            // 
            // nudSolutions
            // 
            resources.ApplyResources(this.nudSolutions, "nudSolutions");
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
            this.nudSolutions.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkBoxKeepSolutions
            // 
            resources.ApplyResources(this.checkBoxKeepSolutions, "checkBoxKeepSolutions");
            this.checkBoxKeepSolutions.Name = "checkBoxKeepSolutions";
            this.checkBoxKeepSolutions.UseVisualStyleBackColor = true;
            this.checkBoxKeepSolutions.CheckedChanged += new System.EventHandler(this.onCheckedChangedKeepSolutions);
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
            // FormNewAnalysis
            // 
            this.AcceptButton = this.bnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.statusStripDef);
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
            this.Controls.Add(this.bnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.FormNewAnalysis_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudSolutions)).EndInit();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOk;
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
        private System.Windows.Forms.Label uMassLoadLowerCases;
        private System.Windows.Forms.Label uMassPalletWeight;
        private System.Windows.Forms.Label uLengthPalletHeight;
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
        private System.Windows.Forms.Label uLengthOverhangY;
        private System.Windows.Forms.Label uLengthOverhangX;
        private System.Windows.Forms.CheckBox checkBoxAllowAlignedLayer;
        private System.Windows.Forms.CheckBox checkBoxAllowAlternateLayer;
        private System.Windows.Forms.GroupBox gbLayerAlignment;
        private System.Windows.Forms.GroupBox gbStopStackingCondition;
        private System.Windows.Forms.CheckBox checkBoxNumberOfPallets;
        private System.Windows.Forms.NumericUpDown nudNumberOfBoxes;
        private System.Windows.Forms.Label lbBoxes;
        private System.Windows.Forms.GroupBox gbAdditionalData;
        private System.Windows.Forms.CheckBox checkBoxKeepSolutions;
        private System.Windows.Forms.Label lbSolutions;
        private System.Windows.Forms.NumericUpDown nudSolutions;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
    }
}