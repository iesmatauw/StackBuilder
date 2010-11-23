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
            this.nudMaximumPalletWeight = new System.Windows.Forms.NumericUpDown();
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
            this.checkBoxCaseContainsMin = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletWeight)).BeginInit();
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
            resources.ApplyResources(this.bnOK, "bnOK");
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Name = "bnOK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // lbDescription
            // 
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Name = "lbDescription";
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // lbBox
            // 
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Name = "lbBox";
            // 
            // cbBoxes
            // 
            this.cbBoxes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxes.FormattingEnabled = true;
            resources.ApplyResources(this.cbBoxes, "cbBoxes");
            this.cbBoxes.Name = "cbBoxes";
            this.cbBoxes.SelectedIndexChanged += new System.EventHandler(this.onBoxChanged);
            // 
            // checkBoxAllowAlternateLayer
            // 
            resources.ApplyResources(this.checkBoxAllowAlternateLayer, "checkBoxAllowAlternateLayer");
            this.checkBoxAllowAlternateLayer.Name = "checkBoxAllowAlternateLayer";
            this.checkBoxAllowAlternateLayer.UseVisualStyleBackColor = true;
            this.checkBoxAllowAlternateLayer.CheckedChanged += new System.EventHandler(this.onCheckedChangedAlternateLayer);
            // 
            // checkBoxAllowAlignedLayer
            // 
            resources.ApplyResources(this.checkBoxAllowAlignedLayer, "checkBoxAllowAlignedLayer");
            this.checkBoxAllowAlignedLayer.Name = "checkBoxAllowAlignedLayer";
            this.checkBoxAllowAlignedLayer.UseVisualStyleBackColor = true;
            this.checkBoxAllowAlignedLayer.CheckedChanged += new System.EventHandler(this.onCheckedChangedAlignedLayer);
            // 
            // gbAllowedLayerPatterns
            // 
            this.gbAllowedLayerPatterns.Controls.Add(this.checkBoxAllowAlternateLayer);
            this.gbAllowedLayerPatterns.Controls.Add(this.checkedListBoxPatterns);
            this.gbAllowedLayerPatterns.Controls.Add(this.checkBoxAllowAlignedLayer);
            resources.ApplyResources(this.gbAllowedLayerPatterns, "gbAllowedLayerPatterns");
            this.gbAllowedLayerPatterns.Name = "gbAllowedLayerPatterns";
            this.gbAllowedLayerPatterns.TabStop = false;
            // 
            // checkedListBoxPatterns
            // 
            this.checkedListBoxPatterns.CheckOnClick = true;
            this.checkedListBoxPatterns.FormattingEnabled = true;
            this.checkedListBoxPatterns.Items.AddRange(new object[] {
            resources.GetString("checkedListBoxPatterns.Items"),
            resources.GetString("checkedListBoxPatterns.Items1"),
            resources.GetString("checkedListBoxPatterns.Items2"),
            resources.GetString("checkedListBoxPatterns.Items3")});
            resources.ApplyResources(this.checkedListBoxPatterns, "checkedListBoxPatterns");
            this.checkedListBoxPatterns.Name = "checkedListBoxPatterns";
            this.checkedListBoxPatterns.Click += new System.EventHandler(this.onAllowedPatternsChanged);
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
            // checkBoxPositionZ
            // 
            resources.ApplyResources(this.checkBoxPositionZ, "checkBoxPositionZ");
            this.checkBoxPositionZ.Name = "checkBoxPositionZ";
            this.checkBoxPositionZ.UseVisualStyleBackColor = true;
            // 
            // checkBoxPositionY
            // 
            resources.ApplyResources(this.checkBoxPositionY, "checkBoxPositionY");
            this.checkBoxPositionY.Name = "checkBoxPositionY";
            this.checkBoxPositionY.UseVisualStyleBackColor = true;
            // 
            // checkBoxPositionX
            // 
            resources.ApplyResources(this.checkBoxPositionX, "checkBoxPositionX");
            this.checkBoxPositionX.Name = "checkBoxPositionX";
            this.checkBoxPositionX.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPositionZ
            // 
            resources.ApplyResources(this.pictureBoxPositionZ, "pictureBoxPositionZ");
            this.pictureBoxPositionZ.Name = "pictureBoxPositionZ";
            this.pictureBoxPositionZ.TabStop = false;
            // 
            // pictureBoxPositionY
            // 
            resources.ApplyResources(this.pictureBoxPositionY, "pictureBoxPositionY");
            this.pictureBoxPositionY.Name = "pictureBoxPositionY";
            this.pictureBoxPositionY.TabStop = false;
            // 
            // pictureBoxPositionX
            // 
            resources.ApplyResources(this.pictureBoxPositionX, "pictureBoxPositionX");
            this.pictureBoxPositionX.Name = "pictureBoxPositionX";
            this.pictureBoxPositionX.TabStop = false;
            // 
            // lbKg1
            // 
            resources.ApplyResources(this.lbKg1, "lbKg1");
            this.lbKg1.Name = "lbKg1";
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
            // nudMaximumNumberOfBoxes
            // 
            resources.ApplyResources(this.nudMaximumNumberOfBoxes, "nudMaximumNumberOfBoxes");
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
            this.gbStopStackingCondition.Controls.Add(this.lbKg1);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumNumberOfBoxes);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumCaseWeight);
            this.gbStopStackingCondition.Controls.Add(this.lbStopStacking);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumNumberOfBoxes);
            resources.ApplyResources(this.gbStopStackingCondition, "gbStopStackingCondition");
            this.gbStopStackingCondition.Name = "gbStopStackingCondition";
            this.gbStopStackingCondition.TabStop = false;
            // 
            // checkBoxMaximumCaseWeight
            // 
            resources.ApplyResources(this.checkBoxMaximumCaseWeight, "checkBoxMaximumCaseWeight");
            this.checkBoxMaximumCaseWeight.Name = "checkBoxMaximumCaseWeight";
            this.checkBoxMaximumCaseWeight.UseVisualStyleBackColor = true;
            // 
            // lbStopStacking
            // 
            resources.ApplyResources(this.lbStopStacking, "lbStopStacking");
            this.lbStopStacking.Name = "lbStopStacking";
            // 
            // checkBoxMaximumNumberOfBoxes
            // 
            resources.ApplyResources(this.checkBoxMaximumNumberOfBoxes, "checkBoxMaximumNumberOfBoxes");
            this.checkBoxMaximumNumberOfBoxes.Name = "checkBoxMaximumNumberOfBoxes";
            this.checkBoxMaximumNumberOfBoxes.UseVisualStyleBackColor = true;
            // 
            // gbSolutionFiltering
            // 
            this.gbSolutionFiltering.Controls.Add(this.lbSolutions);
            this.gbSolutionFiltering.Controls.Add(this.lbBoxes);
            this.gbSolutionFiltering.Controls.Add(this.nudSolutions);
            this.gbSolutionFiltering.Controls.Add(this.nudMinBoxPerCase);
            this.gbSolutionFiltering.Controls.Add(this.checkBoxKeepSolutions);
            this.gbSolutionFiltering.Controls.Add(this.checkBoxCaseContainsMin);
            this.gbSolutionFiltering.Controls.Add(this.lbFilterSolutions);
            resources.ApplyResources(this.gbSolutionFiltering, "gbSolutionFiltering");
            this.gbSolutionFiltering.Name = "gbSolutionFiltering";
            this.gbSolutionFiltering.TabStop = false;
            // 
            // lbSolutions
            // 
            resources.ApplyResources(this.lbSolutions, "lbSolutions");
            this.lbSolutions.Name = "lbSolutions";
            // 
            // lbBoxes
            // 
            resources.ApplyResources(this.lbBoxes, "lbBoxes");
            this.lbBoxes.Name = "lbBoxes";
            // 
            // nudSolutions
            // 
            resources.ApplyResources(this.nudSolutions, "nudSolutions");
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
            resources.ApplyResources(this.nudMinBoxPerCase, "nudMinBoxPerCase");
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
            resources.ApplyResources(this.checkBoxKeepSolutions, "checkBoxKeepSolutions");
            this.checkBoxKeepSolutions.Name = "checkBoxKeepSolutions";
            this.checkBoxKeepSolutions.UseVisualStyleBackColor = true;
            // 
            // checkBoxCaseContainsMin
            // 
            resources.ApplyResources(this.checkBoxCaseContainsMin, "checkBoxCaseContainsMin");
            this.checkBoxCaseContainsMin.Name = "checkBoxCaseContainsMin";
            this.checkBoxCaseContainsMin.UseVisualStyleBackColor = true;
            // 
            // lbFilterSolutions
            // 
            resources.ApplyResources(this.lbFilterSolutions, "lbFilterSolutions");
            this.lbFilterSolutions.Name = "lbFilterSolutions";
            // 
            // gridSolutions
            // 
            this.gridSolutions.AcceptsInputChar = false;
            resources.ApplyResources(this.gridSolutions, "gridSolutions");
            this.gridSolutions.Controls.Add(this.statusStripDef);
            this.gridSolutions.EnableSort = false;
            this.gridSolutions.Name = "gridSolutions";
            this.gridSolutions.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.gridSolutions.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.gridSolutions.SpecialKeys = SourceGrid.GridSpecialKeys.Arrows;
            this.gridSolutions.TabStop = true;
            this.gridSolutions.ToolTipText = "";
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
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // cbPalletDimensions
            // 
            resources.ApplyResources(this.cbPalletDimensions, "cbPalletDimensions");
            this.cbPalletDimensions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletDimensions.FormattingEnabled = true;
            this.cbPalletDimensions.Name = "cbPalletDimensions";
            // 
            // FormNewCaseAnalysis
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletWeight)).EndInit();
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
        private System.Windows.Forms.NumericUpDown nudMaximumPalletWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumNumberOfBoxes;
        private System.Windows.Forms.GroupBox gbStopStackingCondition;
        private System.Windows.Forms.CheckBox checkBoxMaximumCaseWeight;
        private System.Windows.Forms.Label lbStopStacking;
        private System.Windows.Forms.CheckBox checkBoxMaximumNumberOfBoxes;
        private System.Windows.Forms.GroupBox gbSolutionFiltering;
        private System.Windows.Forms.Label lbFilterSolutions;
        private System.Windows.Forms.CheckBox checkBoxKeepSolutions;
        private System.Windows.Forms.CheckBox checkBoxCaseContainsMin;
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