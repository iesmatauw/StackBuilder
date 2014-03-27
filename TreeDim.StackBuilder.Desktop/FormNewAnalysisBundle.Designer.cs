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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewAnalysisBundle));
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnOk = new System.Windows.Forms.Button();
            this.uLengthPalletOverhangY = new System.Windows.Forms.Label();
            this.uLengthPalletOverhangX = new System.Windows.Forms.Label();
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
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
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
            this.uLengthPalletHeight = new System.Windows.Forms.Label();
            this.uMassPalletWeight = new System.Windows.Forms.Label();
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
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnAccept
            // 
            resources.ApplyResources(this.bnOk, "bnAccept");
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Name = "bnAccept";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // uLengthPalletOverhangY
            // 
            resources.ApplyResources(this.uLengthPalletOverhangY, "uLengthPalletOverhangY");
            this.uLengthPalletOverhangY.Name = "uLengthPalletOverhangY";
            // 
            // uLengthPalletOverhangX
            // 
            resources.ApplyResources(this.uLengthPalletOverhangX, "uLengthPalletOverhangX");
            this.uLengthPalletOverhangX.Name = "uLengthPalletOverhangX";
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
            // checkBoxAllowAlignedLayer
            // 
            resources.ApplyResources(this.checkBoxAllowAlignedLayer, "checkBoxAllowAlignedLayer");
            this.checkBoxAllowAlignedLayer.Name = "checkBoxAllowAlignedLayer";
            this.checkBoxAllowAlignedLayer.UseVisualStyleBackColor = true;
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
            // lbPalletOverhangWidth
            // 
            resources.ApplyResources(this.lbPalletOverhangWidth, "lbPalletOverhangWidth");
            this.lbPalletOverhangWidth.Name = "lbPalletOverhangWidth";
            // 
            // gbLayerAlignment
            // 
            this.gbLayerAlignment.Controls.Add(this.checkBoxAllowAlternateLayer);
            this.gbLayerAlignment.Controls.Add(this.checkBoxAllowAlignedLayer);
            resources.ApplyResources(this.gbLayerAlignment, "gbLayerAlignment");
            this.gbLayerAlignment.Name = "gbLayerAlignment";
            this.gbLayerAlignment.TabStop = false;
            // 
            // checkBoxAllowAlternateLayer
            // 
            resources.ApplyResources(this.checkBoxAllowAlternateLayer, "checkBoxAllowAlternateLayer");
            this.checkBoxAllowAlternateLayer.Name = "checkBoxAllowAlternateLayer";
            this.checkBoxAllowAlternateLayer.UseVisualStyleBackColor = true;
            // 
            // lbPalletOverhangLength
            // 
            resources.ApplyResources(this.lbPalletOverhangLength, "lbPalletOverhangLength");
            this.lbPalletOverhangLength.Name = "lbPalletOverhangLength";
            // 
            // gbOverhangUnderhang
            // 
            this.gbOverhangUnderhang.Controls.Add(this.uLengthPalletOverhangY);
            this.gbOverhangUnderhang.Controls.Add(this.uLengthPalletOverhangX);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangY);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangX);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangWidth);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangLength);
            resources.ApplyResources(this.gbOverhangUnderhang, "gbOverhangUnderhang");
            this.gbOverhangUnderhang.Name = "gbOverhangUnderhang";
            this.gbOverhangUnderhang.TabStop = false;
            // 
            // cbPallet
            // 
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            resources.ApplyResources(this.cbPallet, "cbPallet");
            this.cbPallet.Name = "cbPallet";
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // lbBundle
            // 
            resources.ApplyResources(this.lbBundle, "lbBundle");
            this.lbBundle.Name = "lbBundle";
            // 
            // cbBox
            // 
            this.cbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBox.FormattingEnabled = true;
            resources.ApplyResources(this.cbBox, "cbBox");
            this.cbBox.Name = "cbBox";
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.onNameDescriptionChanged);
            // 
            // lbDescription
            // 
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Name = "lbDescription";
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // checkedListBoxPatterns
            // 
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
            // lbBoxes
            // 
            resources.ApplyResources(this.lbBoxes, "lbBoxes");
            this.lbBoxes.Name = "lbBoxes";
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
            // checkBoxNumberOfPallets
            // 
            resources.ApplyResources(this.checkBoxNumberOfPallets, "checkBoxNumberOfPallets");
            this.checkBoxNumberOfPallets.Name = "checkBoxNumberOfPallets";
            this.checkBoxNumberOfPallets.UseVisualStyleBackColor = true;
            // 
            // gbStopStackingCondition
            // 
            this.gbStopStackingCondition.Controls.Add(this.uLengthPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.uMassPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumNumberOfBoxes);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.lbStopStacking);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumNumberOfBoxes);
            resources.ApplyResources(this.gbStopStackingCondition, "gbStopStackingCondition");
            this.gbStopStackingCondition.Name = "gbStopStackingCondition";
            this.gbStopStackingCondition.TabStop = false;
            // 
            // uLengthPalletHeight
            // 
            resources.ApplyResources(this.uLengthPalletHeight, "uLengthPalletHeight");
            this.uLengthPalletHeight.Name = "uLengthPalletHeight";
            // 
            // uMassPalletWeight
            // 
            resources.ApplyResources(this.uMassPalletWeight, "uMassPalletWeight");
            this.uMassPalletWeight.Name = "uMassPalletWeight";
            // 
            // nudMaximumPalletWeight
            // 
            this.nudMaximumPalletWeight.DecimalPlaces = 3;
            resources.ApplyResources(this.nudMaximumPalletWeight, "nudMaximumPalletWeight");
            this.nudMaximumPalletWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumPalletWeight.Name = "nudMaximumPalletWeight";
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
            // checkBoxMaximumPalletWeight
            // 
            resources.ApplyResources(this.checkBoxMaximumPalletWeight, "checkBoxMaximumPalletWeight");
            this.checkBoxMaximumPalletWeight.Name = "checkBoxMaximumPalletWeight";
            this.checkBoxMaximumPalletWeight.UseVisualStyleBackColor = true;
            // 
            // lbStopStacking
            // 
            resources.ApplyResources(this.lbStopStacking, "lbStopStacking");
            this.lbStopStacking.Name = "lbStopStacking";
            // 
            // checkBoxMaximumPalletHeight
            // 
            resources.ApplyResources(this.checkBoxMaximumPalletHeight, "checkBoxMaximumPalletHeight");
            this.checkBoxMaximumPalletHeight.Name = "checkBoxMaximumPalletHeight";
            this.checkBoxMaximumPalletHeight.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaximumNumberOfBoxes
            // 
            resources.ApplyResources(this.checkBoxMaximumNumberOfBoxes, "checkBoxMaximumNumberOfBoxes");
            this.checkBoxMaximumNumberOfBoxes.Name = "checkBoxMaximumNumberOfBoxes";
            this.checkBoxMaximumNumberOfBoxes.UseVisualStyleBackColor = true;
            // 
            // FormNewAnalysisBundle
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewAnalysisBundle";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewAnalysisBundle_FormClosing);
            this.Load += new System.EventHandler(this.FormNewAnalysisBundle_Load);
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
        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Label uLengthPalletOverhangY;
        private System.Windows.Forms.Label uLengthPalletOverhangX;
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
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbName;
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
        private System.Windows.Forms.Label uLengthPalletHeight;
        private System.Windows.Forms.Label uMassPalletWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumPalletWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumPalletHeight;
        private System.Windows.Forms.NumericUpDown nudMaximumNumberOfBoxes;
        private System.Windows.Forms.CheckBox checkBoxMaximumPalletWeight;
        private System.Windows.Forms.Label lbStopStacking;
        private System.Windows.Forms.CheckBox checkBoxMaximumPalletHeight;
        private System.Windows.Forms.CheckBox checkBoxMaximumNumberOfBoxes;
    }
}