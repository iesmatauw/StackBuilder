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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewAnalysisHCylinder));
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
            this.uLengthRowSpacing = new System.Windows.Forms.Label();
            this.nudRowSpacing = new System.Windows.Forms.NumericUpDown();
            this.lbRowSpacing = new System.Windows.Forms.Label();
            this.chkPatternColumnized = new System.Windows.Forms.CheckBox();
            this.chkPatternStaggered = new System.Windows.Forms.CheckBox();
            this.chkPatternDefault = new System.Windows.Forms.CheckBox();
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
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Name = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            // 
            // cbCylinders
            // 
            resources.ApplyResources(this.cbCylinders, "cbCylinders");
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            this.cbCylinders.Name = "cbCylinders";
            // 
            // gbOverhangUnderhang
            // 
            resources.ApplyResources(this.gbOverhangUnderhang, "gbOverhangUnderhang");
            this.gbOverhangUnderhang.Controls.Add(this.uLengthOverhangY);
            this.gbOverhangUnderhang.Controls.Add(this.uLengthOverhangX);
            this.gbOverhangUnderhang.Controls.Add(this.lbMm2);
            this.gbOverhangUnderhang.Controls.Add(this.lbMm1);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangY);
            this.gbOverhangUnderhang.Controls.Add(this.nudPalletOverhangX);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangWidth);
            this.gbOverhangUnderhang.Controls.Add(this.lbPalletOverhangLength);
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
            // lbMm2
            // 
            resources.ApplyResources(this.lbMm2, "lbMm2");
            this.lbMm2.Name = "lbMm2";
            // 
            // lbMm1
            // 
            resources.ApplyResources(this.lbMm1, "lbMm1");
            this.lbMm1.Name = "lbMm1";
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
            // lbPalletOverhangWidth
            // 
            resources.ApplyResources(this.lbPalletOverhangWidth, "lbPalletOverhangWidth");
            this.lbPalletOverhangWidth.Name = "lbPalletOverhangWidth";
            // 
            // lbPalletOverhangLength
            // 
            resources.ApplyResources(this.lbPalletOverhangLength, "lbPalletOverhangLength");
            this.lbPalletOverhangLength.Name = "lbPalletOverhangLength";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cbPallets
            // 
            resources.ApplyResources(this.cbPallets, "cbPallets");
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            this.cbPallets.Name = "cbPallets";
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // bnCancel
            // 
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnOK
            // 
            resources.ApplyResources(this.bnOK, "bnOK");
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Name = "bnOK";
            this.bnOK.UseVisualStyleBackColor = true;
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
            // checkBoxMaximumNumberOfItems
            // 
            resources.ApplyResources(this.checkBoxMaximumNumberOfItems, "checkBoxMaximumNumberOfItems");
            this.checkBoxMaximumNumberOfItems.Name = "checkBoxMaximumNumberOfItems";
            this.checkBoxMaximumNumberOfItems.UseVisualStyleBackColor = true;
            // 
            // gbStopStackingCondition
            // 
            resources.ApplyResources(this.gbStopStackingCondition, "gbStopStackingCondition");
            this.gbStopStackingCondition.Controls.Add(this.uLengthPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.uMassPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumNumberOfItems);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.lbStopStacking);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumNumberOfItems);
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
            resources.ApplyResources(this.nudMaximumPalletWeight, "nudMaximumPalletWeight");
            this.nudMaximumPalletWeight.DecimalPlaces = 1;
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
            // nudMaximumNumberOfItems
            // 
            resources.ApplyResources(this.nudMaximumNumberOfItems, "nudMaximumNumberOfItems");
            this.nudMaximumNumberOfItems.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumNumberOfItems.Name = "nudMaximumNumberOfItems";
            // 
            // checkBoxMaximumPalletWeight
            // 
            resources.ApplyResources(this.checkBoxMaximumPalletWeight, "checkBoxMaximumPalletWeight");
            this.checkBoxMaximumPalletWeight.Name = "checkBoxMaximumPalletWeight";
            this.checkBoxMaximumPalletWeight.UseVisualStyleBackColor = true;
            // 
            // gbPatterns
            // 
            resources.ApplyResources(this.gbPatterns, "gbPatterns");
            this.gbPatterns.Controls.Add(this.uLengthRowSpacing);
            this.gbPatterns.Controls.Add(this.nudRowSpacing);
            this.gbPatterns.Controls.Add(this.lbRowSpacing);
            this.gbPatterns.Controls.Add(this.chkPatternColumnized);
            this.gbPatterns.Controls.Add(this.chkPatternStaggered);
            this.gbPatterns.Controls.Add(this.chkPatternDefault);
            this.gbPatterns.Name = "gbPatterns";
            this.gbPatterns.TabStop = false;
            // 
            // uLengthRowSpacing
            // 
            resources.ApplyResources(this.uLengthRowSpacing, "uLengthRowSpacing");
            this.uLengthRowSpacing.Name = "uLengthRowSpacing";
            // 
            // nudRowSpacing
            // 
            resources.ApplyResources(this.nudRowSpacing, "nudRowSpacing");
            this.nudRowSpacing.Name = "nudRowSpacing";
            // 
            // lbRowSpacing
            // 
            resources.ApplyResources(this.lbRowSpacing, "lbRowSpacing");
            this.lbRowSpacing.Name = "lbRowSpacing";
            // 
            // chkPatternColumnized
            // 
            resources.ApplyResources(this.chkPatternColumnized, "chkPatternColumnized");
            this.chkPatternColumnized.Name = "chkPatternColumnized";
            this.chkPatternColumnized.UseVisualStyleBackColor = true;
            this.chkPatternColumnized.CheckedChanged += new System.EventHandler(this.chkPatternColumnized_CheckedChanged);
            // 
            // chkPatternStaggered
            // 
            resources.ApplyResources(this.chkPatternStaggered, "chkPatternStaggered");
            this.chkPatternStaggered.Name = "chkPatternStaggered";
            this.chkPatternStaggered.UseVisualStyleBackColor = true;
            // 
            // chkPatternDefault
            // 
            resources.ApplyResources(this.chkPatternDefault, "chkPatternDefault");
            this.chkPatternDefault.Name = "chkPatternDefault";
            this.chkPatternDefault.UseVisualStyleBackColor = true;
            // 
            // FormNewAnalysisHCylinder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MinimizeBox = false;
            this.Name = "FormNewAnalysisHCylinder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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