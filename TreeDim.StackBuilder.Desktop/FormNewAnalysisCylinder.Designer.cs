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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewAnalysisCylinder));
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
            this.uLengthOverhangY = new System.Windows.Forms.Label();
            this.uLengthOverhangX = new System.Windows.Forms.Label();
            this.nudPalletOverhangX = new System.Windows.Forms.NumericUpDown();
            this.lbPalletOverhangWidth = new System.Windows.Forms.Label();
            this.uLengthPalletHeight = new System.Windows.Forms.Label();
            this.uMassPalletWeight = new System.Windows.Forms.Label();
            this.uMassLoadOnLower = new System.Windows.Forms.Label();
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
            this.checkBoxInterlayer = new System.Windows.Forms.CheckBox();
            this.cbInterlayers = new System.Windows.Forms.ComboBox();
            this.lbInterlayerFreq1 = new System.Windows.Forms.Label();
            this.nudInterlayerFreq = new System.Windows.Forms.NumericUpDown();
            this.lbInterlayerFreq2 = new System.Windows.Forms.Label();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangY)).BeginInit();
            this.gbOverhangUnderhang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPalletOverhangX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumLoadOnBox)).BeginInit();
            this.gbStopStackingCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumPalletHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterlayerFreq)).BeginInit();
            this.statusStripDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnOK
            // 
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.bnOK, "bnOK");
            this.bnOK.Name = "bnOK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.bnCancel, "bnCancel");
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // cbPallets
            // 
            this.cbPallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallets.FormattingEnabled = true;
            resources.ApplyResources(this.cbPallets, "cbPallets");
            this.cbPallets.Name = "cbPallets";
            this.cbPallets.TextChanged += new System.EventHandler(this.onFormContentChanged);
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
            this.tbDescription.TextChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.onFormContentChanged);
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            // lbPalletOverhangLength
            // 
            resources.ApplyResources(this.lbPalletOverhangLength, "lbPalletOverhangLength");
            this.lbPalletOverhangLength.Name = "lbPalletOverhangLength";
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
            // uMassLoadOnLower
            // 
            resources.ApplyResources(this.uMassLoadOnLower, "uMassLoadOnLower");
            this.uMassLoadOnLower.Name = "uMassLoadOnLower";
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
            // gbStopStackingCondition
            // 
            this.gbStopStackingCondition.Controls.Add(this.uLengthPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.uMassPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.uMassLoadOnLower);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumLoadOnBox);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumNumberOfItems);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumLoadOnCylinder);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletWeight);
            this.gbStopStackingCondition.Controls.Add(this.lbStopStacking);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumPalletHeight);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumNumberOfItems);
            resources.ApplyResources(this.gbStopStackingCondition, "gbStopStackingCondition");
            this.gbStopStackingCondition.Name = "gbStopStackingCondition";
            this.gbStopStackingCondition.TabStop = false;
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
            // checkBoxMaximumLoadOnCylinder
            // 
            resources.ApplyResources(this.checkBoxMaximumLoadOnCylinder, "checkBoxMaximumLoadOnCylinder");
            this.checkBoxMaximumLoadOnCylinder.Name = "checkBoxMaximumLoadOnCylinder";
            this.checkBoxMaximumLoadOnCylinder.UseVisualStyleBackColor = true;
            this.checkBoxMaximumLoadOnCylinder.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
            // 
            // checkBoxMaximumPalletWeight
            // 
            resources.ApplyResources(this.checkBoxMaximumPalletWeight, "checkBoxMaximumPalletWeight");
            this.checkBoxMaximumPalletWeight.Name = "checkBoxMaximumPalletWeight";
            this.checkBoxMaximumPalletWeight.UseVisualStyleBackColor = true;
            this.checkBoxMaximumPalletWeight.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
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
            this.checkBoxMaximumPalletHeight.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
            // 
            // checkBoxMaximumNumberOfItems
            // 
            resources.ApplyResources(this.checkBoxMaximumNumberOfItems, "checkBoxMaximumNumberOfItems");
            this.checkBoxMaximumNumberOfItems.Name = "checkBoxMaximumNumberOfItems";
            this.checkBoxMaximumNumberOfItems.UseVisualStyleBackColor = true;
            this.checkBoxMaximumNumberOfItems.CheckedChanged += new System.EventHandler(this.onCriterionCheckChanged);
            // 
            // cbCylinders
            // 
            this.cbCylinders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCylinders.FormattingEnabled = true;
            resources.ApplyResources(this.cbCylinders, "cbCylinders");
            this.cbCylinders.Name = "cbCylinders";
            this.cbCylinders.TextChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // checkBoxInterlayer
            // 
            resources.ApplyResources(this.checkBoxInterlayer, "checkBoxInterlayer");
            this.checkBoxInterlayer.Name = "checkBoxInterlayer";
            this.checkBoxInterlayer.UseVisualStyleBackColor = true;
            this.checkBoxInterlayer.CheckedChanged += new System.EventHandler(this.onInterlayerChecked);
            this.checkBoxInterlayer.TextChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // cbInterlayers
            // 
            this.cbInterlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterlayers.FormattingEnabled = true;
            resources.ApplyResources(this.cbInterlayers, "cbInterlayers");
            this.cbInterlayers.Name = "cbInterlayers";
            this.cbInterlayers.TextChanged += new System.EventHandler(this.onFormContentChanged);
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
            this.nudInterlayerFreq.ValueChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // lbInterlayerFreq2
            // 
            resources.ApplyResources(this.lbInterlayerFreq2, "lbInterlayerFreq2");
            this.lbInterlayerFreq2.Name = "lbInterlayerFreq2";
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.Name = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            // 
            // FormNewAnalysisCylinder
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.lbInterlayerFreq2);
            this.Controls.Add(this.nudInterlayerFreq);
            this.Controls.Add(this.lbInterlayerFreq1);
            this.Controls.Add(this.cbInterlayers);
            this.Controls.Add(this.checkBoxInterlayer);
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
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
            ((System.ComponentModel.ISupportInitialize)(this.nudInterlayerFreq)).EndInit();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
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
        private System.Windows.Forms.Label uLengthPalletHeight;
        private System.Windows.Forms.Label uMassPalletWeight;
        private System.Windows.Forms.Label uMassLoadOnLower;
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
        private System.Windows.Forms.Label uLengthOverhangY;
        private System.Windows.Forms.Label uLengthOverhangX;
        private System.Windows.Forms.CheckBox checkBoxInterlayer;
        private System.Windows.Forms.ComboBox cbInterlayers;
        private System.Windows.Forms.Label lbInterlayerFreq1;
        private System.Windows.Forms.NumericUpDown nudInterlayerFreq;
        private System.Windows.Forms.Label lbInterlayerFreq2;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
    }
}