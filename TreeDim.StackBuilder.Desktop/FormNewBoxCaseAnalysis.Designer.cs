namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewBoxCaseAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewBoxCaseAnalysis));
            this.bnOk = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbBox = new System.Windows.Forms.Label();
            this.lbCase = new System.Windows.Forms.Label();
            this.cbBox = new System.Windows.Forms.ComboBox();
            this.cbCase = new System.Windows.Forms.ComboBox();
            this.checkBoxPositionZ = new System.Windows.Forms.CheckBox();
            this.checkBoxPositionY = new System.Windows.Forms.CheckBox();
            this.checkBoxPositionX = new System.Windows.Forms.CheckBox();
            this.gbAllowedBoxPositions = new System.Windows.Forms.GroupBox();
            this.pictureBoxPositionZ = new System.Windows.Forms.PictureBox();
            this.pictureBoxPositionY = new System.Windows.Forms.PictureBox();
            this.pictureBoxPositionX = new System.Windows.Forms.PictureBox();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.uMassCaseWeight = new System.Windows.Forms.Label();
            this.nudMaximumCaseWeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumNumberOfBoxes = new System.Windows.Forms.NumericUpDown();
            this.checkBoxMaximumCaseWeight = new System.Windows.Forms.CheckBox();
            this.gbStopStackingCondition = new System.Windows.Forms.GroupBox();
            this.lbStopStacking = new System.Windows.Forms.Label();
            this.checkBoxMaximumNumberOfBoxes = new System.Windows.Forms.CheckBox();
            this.chkIncludeCases = new System.Windows.Forms.CheckBox();
            this.gbAllowedBoxPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionX)).BeginInit();
            this.statusStripDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumCaseWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfBoxes)).BeginInit();
            this.gbStopStackingCondition.SuspendLayout();
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
            this.tbName.Validated += new System.EventHandler(this.onFormContentChanged);
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.TextChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // lbBox
            // 
            resources.ApplyResources(this.lbBox, "lbBox");
            this.lbBox.Name = "lbBox";
            // 
            // lbCase
            // 
            resources.ApplyResources(this.lbCase, "lbCase");
            this.lbCase.Name = "lbCase";
            // 
            // cbBox
            // 
            this.cbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBox.FormattingEnabled = true;
            resources.ApplyResources(this.cbBox, "cbBox");
            this.cbBox.Name = "cbBox";
            this.cbBox.SelectedIndexChanged += new System.EventHandler(this.onBoxChanged);
            // 
            // cbCase
            // 
            resources.ApplyResources(this.cbCase, "cbCase");
            this.cbCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCase.FormattingEnabled = true;
            this.cbCase.Name = "cbCase";
            this.cbCase.SelectedIndexChanged += new System.EventHandler(this.onCaseChanged);
            // 
            // checkBoxPositionZ
            // 
            resources.ApplyResources(this.checkBoxPositionZ, "checkBoxPositionZ");
            this.checkBoxPositionZ.Name = "checkBoxPositionZ";
            this.checkBoxPositionZ.UseVisualStyleBackColor = true;
            this.checkBoxPositionZ.CheckedChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // checkBoxPositionY
            // 
            resources.ApplyResources(this.checkBoxPositionY, "checkBoxPositionY");
            this.checkBoxPositionY.Name = "checkBoxPositionY";
            this.checkBoxPositionY.UseVisualStyleBackColor = true;
            this.checkBoxPositionY.CheckedChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // checkBoxPositionX
            // 
            resources.ApplyResources(this.checkBoxPositionX, "checkBoxPositionX");
            this.checkBoxPositionX.Name = "checkBoxPositionX";
            this.checkBoxPositionX.UseVisualStyleBackColor = true;
            this.checkBoxPositionX.CheckedChanged += new System.EventHandler(this.onFormContentChanged);
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
            // uMassCaseWeight
            // 
            resources.ApplyResources(this.uMassCaseWeight, "uMassCaseWeight");
            this.uMassCaseWeight.Name = "uMassCaseWeight";
            // 
            // nudMaximumCaseWeight
            // 
            this.nudMaximumCaseWeight.DecimalPlaces = 1;
            resources.ApplyResources(this.nudMaximumCaseWeight, "nudMaximumCaseWeight");
            this.nudMaximumCaseWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumCaseWeight.Name = "nudMaximumCaseWeight";
            this.nudMaximumCaseWeight.ValueChanged += new System.EventHandler(this.onFormContentChanged);
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
            // checkBoxMaximumCaseWeight
            // 
            resources.ApplyResources(this.checkBoxMaximumCaseWeight, "checkBoxMaximumCaseWeight");
            this.checkBoxMaximumCaseWeight.Name = "checkBoxMaximumCaseWeight";
            this.checkBoxMaximumCaseWeight.UseVisualStyleBackColor = true;
            this.checkBoxMaximumCaseWeight.CheckedChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // gbStopStackingCondition
            // 
            this.gbStopStackingCondition.Controls.Add(this.uMassCaseWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumCaseWeight);
            this.gbStopStackingCondition.Controls.Add(this.nudMaximumNumberOfBoxes);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumCaseWeight);
            this.gbStopStackingCondition.Controls.Add(this.lbStopStacking);
            this.gbStopStackingCondition.Controls.Add(this.checkBoxMaximumNumberOfBoxes);
            resources.ApplyResources(this.gbStopStackingCondition, "gbStopStackingCondition");
            this.gbStopStackingCondition.Name = "gbStopStackingCondition";
            this.gbStopStackingCondition.TabStop = false;
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
            this.checkBoxMaximumNumberOfBoxes.CheckedChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // chkIncludeCases
            // 
            resources.ApplyResources(this.chkIncludeCases, "chkIncludeCases");
            this.chkIncludeCases.Name = "chkIncludeCases";
            this.chkIncludeCases.UseVisualStyleBackColor = true;
            this.chkIncludeCases.CheckedChanged += new System.EventHandler(this.chkIncludeCases_CheckedChanged);
            // 
            // FormNewBoxCaseAnalysis
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkIncludeCases);
            this.Controls.Add(this.gbStopStackingCondition);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.gbAllowedBoxPositions);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.bnOk);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lbBox);
            this.Controls.Add(this.lbCase);
            this.Controls.Add(this.cbBox);
            this.Controls.Add(this.cbCase);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewBoxCaseAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewBoxCaseAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.FormNewBoxCaseAnalysis_Load);
            this.gbAllowedBoxPositions.ResumeLayout(false);
            this.gbAllowedBoxPositions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPositionX)).EndInit();
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumCaseWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfBoxes)).EndInit();
            this.gbStopStackingCondition.ResumeLayout(false);
            this.gbStopStackingCondition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbBox;
        private System.Windows.Forms.Label lbCase;
        private System.Windows.Forms.ComboBox cbBox;
        private System.Windows.Forms.ComboBox cbCase;
        private System.Windows.Forms.CheckBox checkBoxPositionZ;
        private System.Windows.Forms.CheckBox checkBoxPositionY;
        private System.Windows.Forms.CheckBox checkBoxPositionX;
        private System.Windows.Forms.GroupBox gbAllowedBoxPositions;
        private System.Windows.Forms.PictureBox pictureBoxPositionZ;
        private System.Windows.Forms.PictureBox pictureBoxPositionY;
        private System.Windows.Forms.PictureBox pictureBoxPositionX;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
        private System.Windows.Forms.Label uMassCaseWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumCaseWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumNumberOfBoxes;
        private System.Windows.Forms.CheckBox checkBoxMaximumCaseWeight;
        private System.Windows.Forms.GroupBox gbStopStackingCondition;
        private System.Windows.Forms.Label lbStopStacking;
        private System.Windows.Forms.CheckBox checkBoxMaximumNumberOfBoxes;
        private System.Windows.Forms.CheckBox chkIncludeCases;
    }
}