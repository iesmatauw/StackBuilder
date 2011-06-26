namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewCaseAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewCaseAnalysis));
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbBox = new System.Windows.Forms.Label();
            this.cbBoxes = new System.Windows.Forms.ComboBox();
            this.checkBoxAllowAlternateLayer = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowAlignedLayer = new System.Windows.Forms.CheckBox();
            this.gbAllowedLayerPatterns = new System.Windows.Forms.GroupBox();
            this.checkedListBoxPatterns = new System.Windows.Forms.CheckedListBox();
            this.gbAllowedBoxPositions = new System.Windows.Forms.GroupBox();
            this.checkBoxPositionZ = new System.Windows.Forms.CheckBox();
            this.checkBoxPositionY = new System.Windows.Forms.CheckBox();
            this.checkBoxPositionX = new System.Windows.Forms.CheckBox();
            this.pictureBoxPositionZ = new System.Windows.Forms.PictureBox();
            this.pictureBoxPositionY = new System.Windows.Forms.PictureBox();
            this.pictureBoxPositionX = new System.Windows.Forms.PictureBox();
            this.lbKg1 = new System.Windows.Forms.Label();
            this.nudMaximumCaseWeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumNumberOfBoxes = new System.Windows.Forms.NumericUpDown();
            this.gbStopStackingCondition = new System.Windows.Forms.GroupBox();
            this.checkBoxMaximumCaseWeight = new System.Windows.Forms.CheckBox();
            this.lbStopStacking = new System.Windows.Forms.Label();
            this.checkBoxMaximumNumberOfBoxes = new System.Windows.Forms.CheckBox();
            this.gbSolutionFiltering = new System.Windows.Forms.GroupBox();
            this.lbSolutions = new System.Windows.Forms.Label();
            this.lbBoxes = new System.Windows.Forms.Label();
            this.nudSolutions = new System.Windows.Forms.NumericUpDown();
            this.nudMinBoxPerCase = new System.Windows.Forms.NumericUpDown();
            this.checkBoxKeepSolutions = new System.Windows.Forms.CheckBox();
            this.checkBoxMinNumberOfItems = new System.Windows.Forms.CheckBox();
            this.lbFilterSolutions = new System.Windows.Forms.Label();
            this.gridSolutions = new SourceGrid.Grid();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbPallet = new System.Windows.Forms.Label();
            this.cbPalletDimensions = new System.Windows.Forms.ComboBox();
            this.gbAllowedLayerPatterns.SuspendLayout();
            this.gbAllowedBoxPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumCaseWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfBoxes)).BeginInit();
            this.gbStopStackingCondition.SuspendLayout();
            this.gbSolutionFiltering.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSolutions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinBoxPerCase)).BeginInit();
            this.gridSolutions.SuspendLayout();
            this.statusStripDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnOK
            // 
            this.bnOK.AccessibleDescription = null;
            this.bnOK.AccessibleName = null;
            resources.ApplyResources(this.bnOK, "bnOK");
            this.bnOK.BackgroundImage = null;
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Font = null;
            this.bnOK.Name = "bnOK";
            this.bnOK.UseVisualStyleBackColor = true;
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
            // lbName
            // 
            this.lbName.AccessibleDescription = null;
            this.lbName.AccessibleName = null;
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Font = null;
            this.lbName.Name = "lbName";
            // 
            // lbDescription
            // 
            this.lbDescription.AccessibleDescription = null;
            this.lbDescription.AccessibleName = null;
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Font = null;
            this.lbDescription.Name = "lbDescription";
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
            // lbBox
            // 
            this.lbBox.AccessibleDescription = null;
            this.lbBox.AccessibleName = null;
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Font = null;
            this.lbBox.Name = "lbBox";
            // 
            // cbBoxes
            // 
            this.cbBoxes.AccessibleDescription = null;
            this.cbBoxes.AccessibleName = null;
            resources.ApplyResources(this.cbBoxes, "cbBoxes");
            this.cbBoxes.BackgroundImage = null;
            this.cbBoxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxes.Font = null;
            this.cbBoxes.FormattingEnabled = true;
            this.cbBoxes.Name = "cbBoxes";
            this.cbBoxes.SelectedIndexChanged += new System.EventHandler(this.onBoxChanged);
            // 
            // checkBoxAllowAlternateLayer
            // 
            this.checkBoxAllowAlternateLayer.AccessibleDescription = null;
            this.checkBoxAllowAlternateLayer.AccessibleName = null;
            resources.ApplyResources(this.checkBoxAllowAlternateLayer, "checkBoxAllowAlternateLayer");
            this.checkBoxAllowAlternateLayer.BackgroundImage = null;
            this.checkBoxAllowAlternateLayer.Font = null;
            this.checkBoxAllowAlternateLayer.Name = "checkBoxAllowAlternateLayer";
            this.checkBoxAllowAlternateLayer.UseVisualStyleBackColor = true;
            this.checkBoxAllowAlternateLayer.CheckedChanged += new System.EventHandler(this.onCheckedChangedAlternateLayer);
            // 
            // checkBoxAllowAlignedLayer
            // 
            this.checkBoxAllowAlignedLayer.AccessibleDescription = null;
            this.checkBoxAllowAlignedLayer.AccessibleName = null;
            resources.ApplyResources(this.checkBoxAllowAlignedLayer, "checkBoxAllowAlignedLayer");
            this.checkBoxAllowAlignedLayer.BackgroundImage = null;
            this.checkBoxAllowAlignedLayer.Font = null;
            this.checkBoxAllowAlignedLayer.Name = "checkBoxAllowAlignedLayer";
            this.checkBoxAllowAlignedLayer.UseVisualStyleBackColor = true;
            this.checkBoxAllowAlignedLayer.CheckedChanged += new System.EventHandler(this.onCheckedChangedAlignedLayer);
            // 
            // gbAllowedLayerPatterns
            // 
            this.gbAllowedLayerPatterns.AccessibleDescription = null;
            this.gbAllowedLayerPatterns.AccessibleName = null;
            resources.ApplyResources(this.gbAllowedLayerPatterns, "gbAllowedLayerPatterns");
            this.gbAllowedLayerPatterns.BackgroundImage = null;
            this.gbAllowedLayerPatterns.Controls.Add(this.checkBoxAllowAlternateLayer);
            this.gbAllowedLayerPatterns.Controls.Add(this.checkedListBoxPatterns);
            this.gbAllowedLayerPatterns.Controls.Add(this.checkBoxAllowAlignedLayer);
            this.gbAllowedLayerPatterns.Font = null;
            this.gbAllowedLayerPatterns.Name = "gbAllowedLayerPatterns";
            this.gbAllowedLayerPatterns.TabStop = false;
            // 
            // checkedListBoxPatterns
            // 
            this.checkedListBoxPatterns.AccessibleDescription = null;
            this.checkedListBoxPatterns.AccessibleName = null;
            resources.ApplyResources(this.checkedListBoxPatterns, "checkedListBoxPatterns");
            this.checkedListBoxPatterns.BackgroundImage = null;
            this.checkedListBoxPatterns.CheckOnClick = true;
            this.checkedListBoxPatterns.Font = null;
            this.checkedListBoxPatterns.FormattingEnabled = true;
            this.checkedListBoxPatterns.Items.AddRange(new object[] {
            resources.GetString("checkedListBoxPatterns.Items"),
            resources.GetString("checkedListBoxPatterns.Items1"),
            resources.GetString("checkedListBoxPatterns.Items2"),
            resources.GetString("checkedListBoxPatterns.Items3"),
            resources.GetString("checkedListBoxPatterns.Items4")});
            this.checkedListBoxPatterns.Name = "checkedListBoxPatterns";
            this.checkedListBoxPatterns.Click += new System.EventHandler(this.onAllowedPatternsChanged);
            // 
            // gbAllowedBoxPositions
            // 
            this.gbAllowedBoxPositions.AccessibleDescription = null;
            this.gbAllowedBoxPositions.AccessibleName = null;
            resources.ApplyResources(this.gbAllowedBoxPositions, "gbAllowedBoxPositions");
            this.gbAllowedBoxPositions.BackgroundImage = null;
            this.gbAllowedBoxPositions.Controls.Add(this.checkBoxPositionZ);
            this.gbAllowedBoxPositions.Controls.Add(this.checkBoxPositionY);
            this.gbAllowedBoxPositions.Controls.Add(this.checkBoxPositionX);
            this.gbAllowedBoxPositions.Controls.Add(this.pictureBoxPositionZ);
            this.gbAllowedBoxPositions.Controls.Add(this.pictureBoxPositionY);
            this.gbAllowedBoxPositions.Controls.Add(this.pictureBoxPositionX);
            this.gbAllowedBoxPositions.Font = null;
            this.gbAllowedBoxPositions.Name = "gbAllowedBoxPositions";
            this.gbAllowedBoxPositions.TabStop = false;
            // 
            // checkBoxPositionZ
            // 
            this.checkBoxPositionZ.AccessibleDescription = null;
            this.checkBoxPositionZ.AccessibleName = null;
            resources.ApplyResources(this.checkBoxPositionZ, "checkBoxPositionZ");
            this.checkBoxPositionZ.BackgroundImage = null;
            this.checkBoxPositionZ.Font = null;
            this.checkBoxPositionZ.Name = "checkBoxPositionZ";
            this.checkBoxPositionZ.UseVisualStyleBackColor = true;
            // 
            // checkBoxPositionY
            // 
            this.checkBoxPositionY.AccessibleDescription = null;
            this.checkBoxPositionY.AccessibleName = null;
            resources.ApplyResources(this.checkBoxPositionY, "checkBoxPositionY");
            this.checkBoxPositionY.BackgroundImage = null;
            this.checkBoxPositionY.Font = null;
            this.checkBoxPositionY.Name = "checkBoxPositionY";
            this.checkBoxPositionY.UseVisualStyleBackColor = true;
            // 
            // checkBoxPositionX
            // 
            this.checkBoxPositionX.AccessibleDescription = null;
            this.checkBoxPositionX.AccessibleName = null;
            resources.ApplyResources(this.checkBoxPositionX, "checkBoxPositionX");
            this.checkBoxPositionX.BackgroundImage = null;
            this.checkBoxPositionX.Font = null;
            this.checkBoxPositionX.Name = "checkBoxPositionX";
            this.checkBoxPositionX.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPositionZ
            // 
            this.pictureBoxPositionZ.AccessibleDescription = null;
            this.pictureBoxPositionZ.AccessibleName = null;
            resources.ApplyResources(this.pictureBoxPositionZ, "pictureBoxPositionZ");
            this.pictureBoxPositionZ.BackgroundImage = null;
            this.pictureBoxPositionZ.Font = null;
            this.pictureBoxPositionZ.ImageLocation = null;
            this.pictureBoxPositionZ.Name = "pictureBoxPositionZ";
            this.pictureBoxPositionZ.TabStop = false;
            // 
            // pictureBoxPositionY
            // 
            this.pictureBoxPositionY.AccessibleDescription = null;
            this.pictureBoxPositionY.AccessibleName = null;
            resources.ApplyResources(this.pictureBoxPositionY, "pictureBoxPositionY");
            this.pictureBoxPositionY.BackgroundImage = null;
            this.pictureBoxPositionY.Font = null;
            this.pictureBoxPositionY.ImageLocation = null;
            this.pictureBoxPositionY.Name = "pictureBoxPositionY";
            this.pictureBoxPositionY.TabStop = false;
            // 
            // pictureBoxPositionX
            // 
            this.pictureBoxPositionX.AccessibleDescription = null;
            this.pictureBoxPositionX.AccessibleName = null;
            resources.ApplyResources(this.pictureBoxPositionX, "pictureBoxPositionX");
            this.pictureBoxPositionX.BackgroundImage = null;
            this.pictureBoxPositionX.Font = null;
            this.pictureBoxPositionX.ImageLocation = null;
            this.pictureBoxPositionX.Name = "pictureBoxPositionX";
            this.pictureBoxPositionX.TabStop = false;
            // 
            // lbKg1
            // 
            this.lbKg1.AccessibleDescription = null;
            this.lbKg1.AccessibleName = null;
            resources.ApplyResources(this.lbKg1, "lbKg1");
            this.lbKg1.Font = null;
            this.lbKg1.Name = "lbKg1";
            // 
            // nudMaximumCaseWeight
            // 
            this.nudMaximumCaseWeight.AccessibleDescription = null;
            this.nudMaximumCaseWeight.AccessibleName = null;
            resources.ApplyResources(this.nudMaximumCaseWeight, "nudMaximumCaseWeight");
            this.nudMaximumCaseWeight.DecimalPlaces = 1;
            this.nudMaximumCaseWeight.Font = null;
            this.nudMaximumCaseWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumCaseWeight.Name = "nudMaximumCaseWeight";
            // 
            // nudMaximumNumberOfBoxes
            // 
            this.nudMaximumNumberOfBoxes.AccessibleDescription = null;
            this.nudMaximumNumberOfBoxes.AccessibleName = null;
            resources.ApplyResources(this.nudMaximumNumberOfBoxes, "nudMaximumNumberOfBoxes");
            this.nudMaximumNumberOfBoxes.Font = null;
            this.nudMaximumNumberOfBoxes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumNumberOfBoxes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaximumNumberOfBoxes.Name = "nudMaximumNumberOfBoxes";
            this.nudMaximumNumberOfBoxes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gbStopStackingCondition
            // 
            this.gbStopStackingCondition.AccessibleDescription = null;
            this.gbStopStackingCondition.AccessibleName = null;
            resources.ApplyResources(this.gbStopStackingCondition, "gbStopStackingCondition");
            this.gbStopStackingCondition.BackgroundImage = null;
            this.gbStopStackingCondition.Controls.Add(this.lbKg1);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumCaseWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumNumberOfBoxes);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumCaseWeight);
            this.gbStopStackingCondition.Controls.Add(this.lbStopStacking);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumNumberOfBoxes);
            this.gbStopStackingCondition.Font = null;
            this.gbStopStackingCondition.Name = "gbStopStackingCondition";
            this.gbStopStackingCondition.TabStop = false;
            // 
            // checkBoxMaximumCaseWeight
            // 
            this.checkBoxMaximumCaseWeight.AccessibleDescription = null;
            this.checkBoxMaximumCaseWeight.AccessibleName = null;
            resources.ApplyResources(this.checkBoxMaximumCaseWeight, "checkBoxMaximumCaseWeight");
            this.checkBoxMaximumCaseWeight.BackgroundImage = null;
            this.checkBoxMaximumCaseWeight.Font = null;
            this.checkBoxMaximumCaseWeight.Name = "checkBoxMaximumCaseWeight";
            this.checkBoxMaximumCaseWeight.UseVisualStyleBackColor = true;
            this.checkBoxMaximumCaseWeight.CheckedChanged += new System.EventHandler(this.UpdateConditionStatus);
            // 
            // lbStopStacking
            // 
            this.lbStopStacking.AccessibleDescription = null;
            this.lbStopStacking.AccessibleName = null;
            resources.ApplyResources(this.lbStopStacking, "lbStopStacking");
            this.lbStopStacking.Font = null;
            this.lbStopStacking.Name = "lbStopStacking";
            // 
            // checkBoxMaximumNumberOfBoxes
            // 
            this.checkBoxMaximumNumberOfBoxes.AccessibleDescription = null;
            this.checkBoxMaximumNumberOfBoxes.AccessibleName = null;
            resources.ApplyResources(this.checkBoxMaximumNumberOfBoxes, "checkBoxMaximumNumberOfBoxes");
            this.checkBoxMaximumNumberOfBoxes.BackgroundImage = null;
            this.checkBoxMaximumNumberOfBoxes.Font = null;
            this.checkBoxMaximumNumberOfBoxes.Name = "checkBoxMaximumNumberOfBoxes";
            this.checkBoxMaximumNumberOfBoxes.UseVisualStyleBackColor = true;
            this.checkBoxMaximumNumberOfBoxes.CheckedChanged += new System.EventHandler(this.UpdateConditionStatus);
            // 
            // gbSolutionFiltering
            // 
            this.gbSolutionFiltering.AccessibleDescription = null;
            this.gbSolutionFiltering.AccessibleName = null;
            resources.ApplyResources(this.gbSolutionFiltering, "gbSolutionFiltering");
            this.gbSolutionFiltering.BackgroundImage = null;
            this.gbSolutionFiltering.Controls.Add(this.lbSolutions);
            this.gbSolutionFiltering.Controls.Add(this.lbBoxes);
            this.gbSolutionFiltering.Controls.Add(this.nudSolutions);
            this.gbSolutionFiltering.Controls.Add(this.nudMinBoxPerCase);
            this.gbSolutionFiltering.Controls.Add(this.checkBoxKeepSolutions);
            this.gbSolutionFiltering.Controls.Add(this.checkBoxMinNumberOfItems);
            this.gbSolutionFiltering.Controls.Add(this.lbFilterSolutions);
            this.gbSolutionFiltering.Font = null;
            this.gbSolutionFiltering.Name = "gbSolutionFiltering";
            this.gbSolutionFiltering.TabStop = false;
            // 
            // lbSolutions
            // 
            this.lbSolutions.AccessibleDescription = null;
            this.lbSolutions.AccessibleName = null;
            resources.ApplyResources(this.lbSolutions, "lbSolutions");
            this.lbSolutions.Font = null;
            this.lbSolutions.Name = "lbSolutions";
            // 
            // lbBoxes
            // 
            this.lbBoxes.AccessibleDescription = null;
            this.lbBoxes.AccessibleName = null;
            resources.ApplyResources(this.lbBoxes, "lbBoxes");
            this.lbBoxes.Font = null;
            this.lbBoxes.Name = "lbBoxes";
            // 
            // nudSolutions
            // 
            this.nudSolutions.AccessibleDescription = null;
            this.nudSolutions.AccessibleName = null;
            resources.ApplyResources(this.nudSolutions, "nudSolutions");
            this.nudSolutions.Font = null;
            this.nudSolutions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSolutions.Name = "nudSolutions";
            this.nudSolutions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudMinBoxPerCase
            // 
            this.nudMinBoxPerCase.AccessibleDescription = null;
            this.nudMinBoxPerCase.AccessibleName = null;
            resources.ApplyResources(this.nudMinBoxPerCase, "nudMinBoxPerCase");
            this.nudMinBoxPerCase.Font = null;
            this.nudMinBoxPerCase.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMinBoxPerCase.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMinBoxPerCase.Name = "nudMinBoxPerCase";
            this.nudMinBoxPerCase.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxKeepSolutions
            // 
            this.checkBoxKeepSolutions.AccessibleDescription = null;
            this.checkBoxKeepSolutions.AccessibleName = null;
            resources.ApplyResources(this.checkBoxKeepSolutions, "checkBoxKeepSolutions");
            this.checkBoxKeepSolutions.BackgroundImage = null;
            this.checkBoxKeepSolutions.Font = null;
            this.checkBoxKeepSolutions.Name = "checkBoxKeepSolutions";
            this.checkBoxKeepSolutions.UseVisualStyleBackColor = true;
            this.checkBoxKeepSolutions.CheckedChanged += new System.EventHandler(this.UpdateConditionStatus);
            // 
            // checkBoxMinNumberOfItems
            // 
            this.checkBoxMinNumberOfItems.AccessibleDescription = null;
            this.checkBoxMinNumberOfItems.AccessibleName = null;
            resources.ApplyResources(this.checkBoxMinNumberOfItems, "checkBoxMinNumberOfItems");
            this.checkBoxMinNumberOfItems.BackgroundImage = null;
            this.checkBoxMinNumberOfItems.Font = null;
            this.checkBoxMinNumberOfItems.Name = "checkBoxMinNumberOfItems";
            this.checkBoxMinNumberOfItems.UseVisualStyleBackColor = true;
            this.checkBoxMinNumberOfItems.CheckedChanged += new System.EventHandler(this.UpdateConditionStatus);
            // 
            // lbFilterSolutions
            // 
            this.lbFilterSolutions.AccessibleDescription = null;
            this.lbFilterSolutions.AccessibleName = null;
            resources.ApplyResources(this.lbFilterSolutions, "lbFilterSolutions");
            this.lbFilterSolutions.Font = null;
            this.lbFilterSolutions.Name = "lbFilterSolutions";
            // 
            // gridSolutions
            // 
            this.gridSolutions.AcceptsInputChar = false;
            this.gridSolutions.AccessibleDescription = null;
            this.gridSolutions.AccessibleName = null;
            resources.ApplyResources(this.gridSolutions, "gridSolutions");
            this.gridSolutions.BackgroundImage = null;
            this.gridSolutions.Controls.Add(this.statusStripDef);
            this.gridSolutions.EnableSort = false;
            this.gridSolutions.Font = null;
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
            // 
            // statusStripDef
            // 
            this.statusStripDef.AccessibleDescription = null;
            this.statusStripDef.AccessibleName = null;
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.BackgroundImage = null;
            this.statusStripDef.Font = null;
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.SizingGrip = false;
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.AccessibleDescription = null;
            this.toolStripStatusLabelDef.AccessibleName = null;
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            this.toolStripStatusLabelDef.BackgroundImage = null;
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            // 
            // lbPallet
            // 
            this.lbPallet.AccessibleDescription = null;
            this.lbPallet.AccessibleName = null;
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Font = null;
            this.lbPallet.Name = "lbPallet";
            // 
            // cbPalletDimensions
            // 
            this.cbPalletDimensions.AccessibleDescription = null;
            this.cbPalletDimensions.AccessibleName = null;
            resources.ApplyResources(this.cbPalletDimensions, "cbPalletDimensions");
            this.cbPalletDimensions.BackgroundImage = null;
            this.cbPalletDimensions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletDimensions.Font = null;
            this.cbPalletDimensions.FormattingEnabled = true;
            this.cbPalletDimensions.Name = "cbPalletDimensions";
            // 
            // FormNewCaseAnalysis
            // 
            this.AcceptButton = this.bnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.cbPalletDimensions);
            this.Controls.Add(this.lbPallet);
            this.Controls.Add(this.gridSolutions);
            this.Controls.Add(this.gbSolutionFiltering);
            this.Controls.Add(this.gbStopStackingCondition);
            this.Controls.Add(this.gbAllowedLayerPatterns);
            this.Controls.Add(this.gbAllowedBoxPositions);
            this.Controls.Add(this.cbBoxes);
            this.Controls.Add(this.lbBox);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewCaseAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormNewCaseAnalysis_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewCaseAnalysis_FormClosing);
            this.gbAllowedLayerPatterns.ResumeLayout(false);
            this.gbAllowedLayerPatterns.PerformLayout();
            this.gbAllowedBoxPositions.ResumeLayout(false);
            this.gbAllowedBoxPositions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumCaseWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfBoxes)).EndInit();
            this.gbStopStackingCondition.ResumeLayout(false);
            this.gbStopStackingCondition.PerformLayout();
            this.gbSolutionFiltering.ResumeLayout(false);
            this.gbSolutionFiltering.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSolutions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinBoxPerCase)).EndInit();
            this.gridSolutions.ResumeLayout(false);
            this.gridSolutions.PerformLayout();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbBox;
        private System.Windows.Forms.ComboBox cbBoxes;
        private System.Windows.Forms.CheckBox checkBoxAllowAlternateLayer;
        private System.Windows.Forms.CheckBox checkBoxAllowAlignedLayer;
        private System.Windows.Forms.GroupBox gbAllowedLayerPatterns;
        private System.Windows.Forms.CheckedListBox checkedListBoxPatterns;
        private System.Windows.Forms.GroupBox gbAllowedBoxPositions;
        private System.Windows.Forms.CheckBox checkBoxPositionZ;
        private System.Windows.Forms.CheckBox checkBoxPositionY;
        private System.Windows.Forms.CheckBox checkBoxPositionX;
        private System.Windows.Forms.PictureBox pictureBoxPositionZ;
        private System.Windows.Forms.PictureBox pictureBoxPositionY;
        private System.Windows.Forms.PictureBox pictureBoxPositionX;
        private System.Windows.Forms.Label lbKg1;
        private System.Windows.Forms.NumericUpDown nudMaximumCaseWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumNumberOfBoxes;
        private System.Windows.Forms.GroupBox gbStopStackingCondition;
        private System.Windows.Forms.CheckBox checkBoxMaximumCaseWeight;
        private System.Windows.Forms.Label lbStopStacking;
        private System.Windows.Forms.CheckBox checkBoxMaximumNumberOfBoxes;
        private System.Windows.Forms.GroupBox gbSolutionFiltering;
        private System.Windows.Forms.Label lbFilterSolutions;
        private System.Windows.Forms.CheckBox checkBoxKeepSolutions;
        private System.Windows.Forms.CheckBox checkBoxMinNumberOfItems;
        private System.Windows.Forms.NumericUpDown nudMinBoxPerCase;
        private System.Windows.Forms.Label lbSolutions;
        private System.Windows.Forms.Label lbBoxes;
        private System.Windows.Forms.NumericUpDown nudSolutions;
        private SourceGrid.Grid gridSolutions;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.ComboBox cbPalletDimensions;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
    }
}