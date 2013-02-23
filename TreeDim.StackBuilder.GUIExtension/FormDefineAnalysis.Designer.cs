namespace TreeDim.StackBuilder.GUIExtension
{
    partial class FormDefineAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDefineAnalysis));
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.nudCaseLength = new System.Windows.Forms.NumericUpDown();
            this.lbCaseLength = new System.Windows.Forms.Label();
            this.lbCaseWidth = new System.Windows.Forms.Label();
            this.nudCaseWidth = new System.Windows.Forms.NumericUpDown();
            this.lbCaseHeight = new System.Windows.Forms.Label();
            this.nudCaseHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.pbCaseX = new System.Windows.Forms.PictureBox();
            this.pbCaseY = new System.Windows.Forms.PictureBox();
            this.pbCaseZ = new System.Windows.Forms.PictureBox();
            this.chkX = new System.Windows.Forms.CheckBox();
            this.chkY = new System.Windows.Forms.CheckBox();
            this.chkZ = new System.Windows.Forms.CheckBox();
            this.gbCase = new System.Windows.Forms.GroupBox();
            this.bnCaseColors = new System.Windows.Forms.Button();
            this.lbCaseWeight = new System.Windows.Forms.Label();
            this.nudCaseWeight = new System.Windows.Forms.NumericUpDown();
            this.lbWeight = new System.Windows.Forms.Label();
            this.bnRevertZ = new System.Windows.Forms.Button();
            this.bnRevertY = new System.Windows.Forms.Button();
            this.bnRevertX = new System.Windows.Forms.Button();
            this.gbPallet = new System.Windows.Forms.GroupBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.bnEditPalletList = new System.Windows.Forms.Button();
            this.lbPalletDescription = new System.Windows.Forms.Label();
            this.pbPallet = new System.Windows.Forms.PictureBox();
            this.cbPallet = new System.Windows.Forms.ComboBox();
            this.lbPallet = new System.Windows.Forms.Label();
            this.gbConstraints = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudMaxPalletWeight = new System.Windows.Forms.NumericUpDown();
            this.chkMaxPalletWeight = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMaxPalletHeight = new System.Windows.Forms.NumericUpDown();
            this.nudOverhangY = new System.Windows.Forms.NumericUpDown();
            this.nudOverhangX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lbOverhangWidth = new System.Windows.Forms.Label();
            this.lbOverhangLength = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseZ)).BeginInit();
            this.gbCase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseWeight)).BeginInit();
            this.gbPallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPallet)).BeginInit();
            this.gbConstraints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangX)).BeginInit();
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
            // nudCaseLength
            // 
            resources.ApplyResources(this.nudCaseLength, "nudCaseLength");
            this.nudCaseLength.DecimalPlaces = 1;
            this.nudCaseLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCaseLength.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCaseLength.Name = "nudCaseLength";
            this.nudCaseLength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCaseLength.ValueChanged += new System.EventHandler(this.CaseDimensionChanged);
            // 
            // lbCaseLength
            // 
            resources.ApplyResources(this.lbCaseLength, "lbCaseLength");
            this.lbCaseLength.Name = "lbCaseLength";
            // 
            // lbCaseWidth
            // 
            resources.ApplyResources(this.lbCaseWidth, "lbCaseWidth");
            this.lbCaseWidth.Name = "lbCaseWidth";
            // 
            // nudCaseWidth
            // 
            resources.ApplyResources(this.nudCaseWidth, "nudCaseWidth");
            this.nudCaseWidth.DecimalPlaces = 1;
            this.nudCaseWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCaseWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCaseWidth.Name = "nudCaseWidth";
            this.nudCaseWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCaseWidth.ValueChanged += new System.EventHandler(this.CaseDimensionChanged);
            // 
            // lbCaseHeight
            // 
            resources.ApplyResources(this.lbCaseHeight, "lbCaseHeight");
            this.lbCaseHeight.Name = "lbCaseHeight";
            // 
            // nudCaseHeight
            // 
            resources.ApplyResources(this.nudCaseHeight, "nudCaseHeight");
            this.nudCaseHeight.DecimalPlaces = 1;
            this.nudCaseHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCaseHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCaseHeight.Name = "nudCaseHeight";
            this.nudCaseHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCaseHeight.ValueChanged += new System.EventHandler(this.CaseDimensionChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // pbCaseX
            // 
            resources.ApplyResources(this.pbCaseX, "pbCaseX");
            this.pbCaseX.Name = "pbCaseX";
            this.pbCaseX.TabStop = false;
            // 
            // pbCaseY
            // 
            resources.ApplyResources(this.pbCaseY, "pbCaseY");
            this.pbCaseY.Name = "pbCaseY";
            this.pbCaseY.TabStop = false;
            // 
            // pbCaseZ
            // 
            resources.ApplyResources(this.pbCaseZ, "pbCaseZ");
            this.pbCaseZ.Name = "pbCaseZ";
            this.pbCaseZ.TabStop = false;
            // 
            // chkX
            // 
            resources.ApplyResources(this.chkX, "chkX");
            this.chkX.Name = "chkX";
            this.chkX.UseVisualStyleBackColor = true;
            // 
            // chkY
            // 
            resources.ApplyResources(this.chkY, "chkY");
            this.chkY.Name = "chkY";
            this.chkY.UseVisualStyleBackColor = true;
            // 
            // chkZ
            // 
            resources.ApplyResources(this.chkZ, "chkZ");
            this.chkZ.Name = "chkZ";
            this.chkZ.UseVisualStyleBackColor = true;
            // 
            // gbCase
            // 
            resources.ApplyResources(this.gbCase, "gbCase");
            this.gbCase.Controls.Add(this.bnCaseColors);
            this.gbCase.Controls.Add(this.lbCaseWeight);
            this.gbCase.Controls.Add(this.nudCaseWeight);
            this.gbCase.Controls.Add(this.lbWeight);
            this.gbCase.Controls.Add(this.bnRevertZ);
            this.gbCase.Controls.Add(this.pbCaseY);
            this.gbCase.Controls.Add(this.bnRevertY);
            this.gbCase.Controls.Add(this.nudCaseLength);
            this.gbCase.Controls.Add(this.bnRevertX);
            this.gbCase.Controls.Add(this.lbCaseLength);
            this.gbCase.Controls.Add(this.lbCaseWidth);
            this.gbCase.Controls.Add(this.chkZ);
            this.gbCase.Controls.Add(this.nudCaseWidth);
            this.gbCase.Controls.Add(this.chkY);
            this.gbCase.Controls.Add(this.lbCaseHeight);
            this.gbCase.Controls.Add(this.chkX);
            this.gbCase.Controls.Add(this.nudCaseHeight);
            this.gbCase.Controls.Add(this.pbCaseZ);
            this.gbCase.Controls.Add(this.label4);
            this.gbCase.Controls.Add(this.pbCaseX);
            this.gbCase.Name = "gbCase";
            this.gbCase.TabStop = false;
            // 
            // bnCaseColors
            // 
            resources.ApplyResources(this.bnCaseColors, "bnCaseColors");
            this.bnCaseColors.Name = "bnCaseColors";
            this.bnCaseColors.UseVisualStyleBackColor = true;
            // 
            // lbCaseWeight
            // 
            resources.ApplyResources(this.lbCaseWeight, "lbCaseWeight");
            this.lbCaseWeight.Name = "lbCaseWeight";
            // 
            // nudCaseWeight
            // 
            resources.ApplyResources(this.nudCaseWeight, "nudCaseWeight");
            this.nudCaseWeight.DecimalPlaces = 2;
            this.nudCaseWeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCaseWeight.Name = "nudCaseWeight";
            // 
            // lbWeight
            // 
            resources.ApplyResources(this.lbWeight, "lbWeight");
            this.lbWeight.Name = "lbWeight";
            // 
            // bnRevertZ
            // 
            resources.ApplyResources(this.bnRevertZ, "bnRevertZ");
            this.bnRevertZ.Name = "bnRevertZ";
            this.bnRevertZ.UseVisualStyleBackColor = true;
            // 
            // bnRevertY
            // 
            resources.ApplyResources(this.bnRevertY, "bnRevertY");
            this.bnRevertY.Name = "bnRevertY";
            this.bnRevertY.UseVisualStyleBackColor = true;
            // 
            // bnRevertX
            // 
            resources.ApplyResources(this.bnRevertX, "bnRevertX");
            this.bnRevertX.Name = "bnRevertX";
            this.bnRevertX.UseVisualStyleBackColor = true;
            this.bnRevertX.Click += new System.EventHandler(this.bnRevertX_Click);
            // 
            // gbPallet
            // 
            resources.ApplyResources(this.gbPallet, "gbPallet");
            this.gbPallet.Controls.Add(this.lbDescription);
            this.gbPallet.Controls.Add(this.bnEditPalletList);
            this.gbPallet.Controls.Add(this.lbPalletDescription);
            this.gbPallet.Controls.Add(this.pbPallet);
            this.gbPallet.Controls.Add(this.cbPallet);
            this.gbPallet.Controls.Add(this.lbPallet);
            this.gbPallet.Name = "gbPallet";
            this.gbPallet.TabStop = false;
            // 
            // lbDescription
            // 
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Name = "lbDescription";
            // 
            // bnEditPalletList
            // 
            resources.ApplyResources(this.bnEditPalletList, "bnEditPalletList");
            this.bnEditPalletList.Name = "bnEditPalletList";
            this.bnEditPalletList.UseVisualStyleBackColor = true;
            this.bnEditPalletList.Click += new System.EventHandler(this.bnEditPalletList_Click);
            // 
            // lbPalletDescription
            // 
            resources.ApplyResources(this.lbPalletDescription, "lbPalletDescription");
            this.lbPalletDescription.Name = "lbPalletDescription";
            // 
            // pbPallet
            // 
            resources.ApplyResources(this.pbPallet, "pbPallet");
            this.pbPallet.Name = "pbPallet";
            this.pbPallet.TabStop = false;
            // 
            // cbPallet
            // 
            resources.ApplyResources(this.cbPallet, "cbPallet");
            this.cbPallet.AllowDrop = true;
            this.cbPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPallet.FormattingEnabled = true;
            this.cbPallet.Name = "cbPallet";
            this.cbPallet.SelectedIndexChanged += new System.EventHandler(this.cbPallet_SelectedIndexChanged);
            // 
            // lbPallet
            // 
            resources.ApplyResources(this.lbPallet, "lbPallet");
            this.lbPallet.Name = "lbPallet";
            // 
            // gbConstraints
            // 
            resources.ApplyResources(this.gbConstraints, "gbConstraints");
            this.gbConstraints.Controls.Add(this.label7);
            this.gbConstraints.Controls.Add(this.label6);
            this.gbConstraints.Controls.Add(this.label5);
            this.gbConstraints.Controls.Add(this.nudMaxPalletWeight);
            this.gbConstraints.Controls.Add(this.chkMaxPalletWeight);
            this.gbConstraints.Controls.Add(this.label3);
            this.gbConstraints.Controls.Add(this.nudMaxPalletHeight);
            this.gbConstraints.Controls.Add(this.nudOverhangY);
            this.gbConstraints.Controls.Add(this.nudOverhangX);
            this.gbConstraints.Controls.Add(this.label2);
            this.gbConstraints.Controls.Add(this.lbOverhangWidth);
            this.gbConstraints.Controls.Add(this.lbOverhangLength);
            this.gbConstraints.Controls.Add(this.label1);
            this.gbConstraints.Name = "gbConstraints";
            this.gbConstraints.TabStop = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // nudMaxPalletWeight
            // 
            resources.ApplyResources(this.nudMaxPalletWeight, "nudMaxPalletWeight");
            this.nudMaxPalletWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxPalletWeight.Name = "nudMaxPalletWeight";
            // 
            // chkMaxPalletWeight
            // 
            resources.ApplyResources(this.chkMaxPalletWeight, "chkMaxPalletWeight");
            this.chkMaxPalletWeight.Name = "chkMaxPalletWeight";
            this.chkMaxPalletWeight.UseVisualStyleBackColor = true;
            this.chkMaxPalletWeight.CheckedChanged += new System.EventHandler(this.chkMaxPalletWeight_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // nudMaxPalletHeight
            // 
            resources.ApplyResources(this.nudMaxPalletHeight, "nudMaxPalletHeight");
            this.nudMaxPalletHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxPalletHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMaxPalletHeight.Name = "nudMaxPalletHeight";
            this.nudMaxPalletHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudOverhangY
            // 
            resources.ApplyResources(this.nudOverhangY, "nudOverhangY");
            this.nudOverhangY.DecimalPlaces = 1;
            this.nudOverhangY.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudOverhangY.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudOverhangY.Name = "nudOverhangY";
            // 
            // nudOverhangX
            // 
            resources.ApplyResources(this.nudOverhangX, "nudOverhangX");
            this.nudOverhangX.DecimalPlaces = 1;
            this.nudOverhangX.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudOverhangX.Name = "nudOverhangX";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lbOverhangWidth
            // 
            resources.ApplyResources(this.lbOverhangWidth, "lbOverhangWidth");
            this.lbOverhangWidth.Name = "lbOverhangWidth";
            // 
            // lbOverhangLength
            // 
            resources.ApplyResources(this.lbOverhangLength, "lbOverhangLength");
            this.lbOverhangLength.Name = "lbOverhangLength";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // FormDefineAnalysis
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.gbConstraints);
            this.Controls.Add(this.gbPallet);
            this.Controls.Add(this.gbCase);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDefineAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDefineAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.FormDefineAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaseZ)).EndInit();
            this.gbCase.ResumeLayout(false);
            this.gbCase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaseWeight)).EndInit();
            this.gbPallet.ResumeLayout(false);
            this.gbPallet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPallet)).EndInit();
            this.gbConstraints.ResumeLayout(false);
            this.gbConstraints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPalletHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverhangX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.NumericUpDown nudCaseLength;
        private System.Windows.Forms.Label lbCaseLength;
        private System.Windows.Forms.Label lbCaseWidth;
        private System.Windows.Forms.NumericUpDown nudCaseWidth;
        private System.Windows.Forms.Label lbCaseHeight;
        private System.Windows.Forms.NumericUpDown nudCaseHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbCaseX;
        private System.Windows.Forms.PictureBox pbCaseY;
        private System.Windows.Forms.PictureBox pbCaseZ;
        private System.Windows.Forms.CheckBox chkX;
        private System.Windows.Forms.CheckBox chkY;
        private System.Windows.Forms.CheckBox chkZ;
        private System.Windows.Forms.GroupBox gbCase;
        private System.Windows.Forms.Button bnRevertZ;
        private System.Windows.Forms.Button bnRevertY;
        private System.Windows.Forms.Button bnRevertX;
        private System.Windows.Forms.GroupBox gbPallet;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Button bnEditPalletList;
        private System.Windows.Forms.Label lbPalletDescription;
        private System.Windows.Forms.PictureBox pbPallet;
        private System.Windows.Forms.ComboBox cbPallet;
        private System.Windows.Forms.Label lbPallet;
        private System.Windows.Forms.GroupBox gbConstraints;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudMaxPalletWeight;
        private System.Windows.Forms.CheckBox chkMaxPalletWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMaxPalletHeight;
        private System.Windows.Forms.NumericUpDown nudOverhangY;
        private System.Windows.Forms.NumericUpDown nudOverhangX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbOverhangWidth;
        private System.Windows.Forms.Label lbOverhangLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCaseWeight;
        private System.Windows.Forms.NumericUpDown nudCaseWeight;
        private System.Windows.Forms.Label lbWeight;
        private System.Windows.Forms.Button bnCaseColors;
    }
}