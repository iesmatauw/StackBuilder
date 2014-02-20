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
            this.bnOk = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.bnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Location = new System.Drawing.Point(504, 5);
            this.bnOk.Name = "bnOk";
            this.bnOk.Size = new System.Drawing.Size(75, 23);
            this.bnOk.TabIndex = 0;
            this.bnOk.Text = "OK";
            this.bnOk.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(504, 34);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(122, 9);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 20);
            this.tbName.TabIndex = 4;
            this.tbName.Validated += new System.EventHandler(this.onFormContentChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(122, 35);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(376, 20);
            this.tbDescription.TabIndex = 5;
            this.tbDescription.TextChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // lbBox
            // 
            this.lbBox.AutoSize = true;
            this.lbBox.Location = new System.Drawing.Point(7, 62);
            this.lbBox.Name = "lbBox";
            this.lbBox.Size = new System.Drawing.Size(25, 13);
            this.lbBox.TabIndex = 13;
            this.lbBox.Text = "Box";
            // 
            // lbCase
            // 
            this.lbCase.AutoSize = true;
            this.lbCase.Location = new System.Drawing.Point(326, 62);
            this.lbCase.Name = "lbCase";
            this.lbCase.Size = new System.Drawing.Size(31, 13);
            this.lbCase.TabIndex = 14;
            this.lbCase.Text = "Case";
            // 
            // cbBox
            // 
            this.cbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBox.FormattingEnabled = true;
            this.cbBox.Location = new System.Drawing.Point(123, 62);
            this.cbBox.Name = "cbBox";
            this.cbBox.Size = new System.Drawing.Size(121, 21);
            this.cbBox.TabIndex = 15;
            this.cbBox.SelectedIndexChanged += new System.EventHandler(this.onBoxChanged);
            // 
            // cbCase
            // 
            this.cbCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCase.FormattingEnabled = true;
            this.cbCase.Location = new System.Drawing.Point(377, 62);
            this.cbCase.Name = "cbCase";
            this.cbCase.Size = new System.Drawing.Size(121, 21);
            this.cbCase.TabIndex = 16;
            this.cbCase.SelectedIndexChanged += new System.EventHandler(this.onCaseChanged);
            // 
            // checkBoxPositionZ
            // 
            this.checkBoxPositionZ.AutoSize = true;
            this.checkBoxPositionZ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxPositionZ.Location = new System.Drawing.Point(254, 117);
            this.checkBoxPositionZ.Name = "checkBoxPositionZ";
            this.checkBoxPositionZ.Size = new System.Drawing.Size(33, 17);
            this.checkBoxPositionZ.TabIndex = 11;
            this.checkBoxPositionZ.Text = "Z";
            this.checkBoxPositionZ.UseVisualStyleBackColor = true;
            this.checkBoxPositionZ.CheckedChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // checkBoxPositionY
            // 
            this.checkBoxPositionY.AutoSize = true;
            this.checkBoxPositionY.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxPositionY.Location = new System.Drawing.Point(131, 117);
            this.checkBoxPositionY.Name = "checkBoxPositionY";
            this.checkBoxPositionY.Size = new System.Drawing.Size(33, 17);
            this.checkBoxPositionY.TabIndex = 10;
            this.checkBoxPositionY.Text = "Y";
            this.checkBoxPositionY.UseVisualStyleBackColor = true;
            this.checkBoxPositionY.CheckedChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // checkBoxPositionX
            // 
            this.checkBoxPositionX.AutoSize = true;
            this.checkBoxPositionX.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxPositionX.Location = new System.Drawing.Point(8, 117);
            this.checkBoxPositionX.Name = "checkBoxPositionX";
            this.checkBoxPositionX.Size = new System.Drawing.Size(33, 17);
            this.checkBoxPositionX.TabIndex = 9;
            this.checkBoxPositionX.Text = "X";
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
            this.gbAllowedBoxPositions.Location = new System.Drawing.Point(12, 89);
            this.gbAllowedBoxPositions.Name = "gbAllowedBoxPositions";
            this.gbAllowedBoxPositions.Size = new System.Drawing.Size(377, 144);
            this.gbAllowedBoxPositions.TabIndex = 17;
            this.gbAllowedBoxPositions.TabStop = false;
            this.gbAllowedBoxPositions.Text = "Allowed box positions";
            // 
            // pictureBoxPositionZ
            // 
            this.pictureBoxPositionZ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxPositionZ.Location = new System.Drawing.Point(254, 18);
            this.pictureBoxPositionZ.Name = "pictureBoxPositionZ";
            this.pictureBoxPositionZ.Size = new System.Drawing.Size(107, 92);
            this.pictureBoxPositionZ.TabIndex = 8;
            this.pictureBoxPositionZ.TabStop = false;
            // 
            // pictureBoxPositionY
            // 
            this.pictureBoxPositionY.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxPositionY.Location = new System.Drawing.Point(131, 18);
            this.pictureBoxPositionY.Name = "pictureBoxPositionY";
            this.pictureBoxPositionY.Size = new System.Drawing.Size(107, 92);
            this.pictureBoxPositionY.TabIndex = 7;
            this.pictureBoxPositionY.TabStop = false;
            // 
            // pictureBoxPositionX
            // 
            this.pictureBoxPositionX.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxPositionX.Location = new System.Drawing.Point(8, 18);
            this.pictureBoxPositionX.Name = "pictureBoxPositionX";
            this.pictureBoxPositionX.Size = new System.Drawing.Size(107, 92);
            this.pictureBoxPositionX.TabIndex = 6;
            this.pictureBoxPositionX.TabStop = false;
            // 
            // statusStripDef
            // 
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Location = new System.Drawing.Point(0, 336);
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.Size = new System.Drawing.Size(584, 22);
            this.statusStripDef.SizingGrip = false;
            this.statusStripDef.TabIndex = 50;
            this.statusStripDef.Text = "statusStripDef";
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
            this.toolStripStatusLabelDef.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabelDef.Text = "toolStripStatusLabelDef";
            // 
            // uMassCaseWeight
            // 
            this.uMassCaseWeight.AutoSize = true;
            this.uMassCaseWeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uMassCaseWeight.Location = new System.Drawing.Point(270, 71);
            this.uMassCaseWeight.Name = "uMassCaseWeight";
            this.uMassCaseWeight.Size = new System.Drawing.Size(47, 13);
            this.uMassCaseWeight.TabIndex = 29;
            this.uMassCaseWeight.Text = "uMass";
            // 
            // nudMaximumCaseWeight
            // 
            this.nudMaximumCaseWeight.DecimalPlaces = 1;
            this.nudMaximumCaseWeight.Location = new System.Drawing.Point(205, 67);
            this.nudMaximumCaseWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumCaseWeight.Name = "nudMaximumCaseWeight";
            this.nudMaximumCaseWeight.Size = new System.Drawing.Size(55, 20);
            this.nudMaximumCaseWeight.TabIndex = 26;
            this.nudMaximumCaseWeight.ValueChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // nudMaximumNumberOfBoxes
            // 
            this.nudMaximumNumberOfBoxes.Location = new System.Drawing.Point(205, 41);
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
            this.nudMaximumNumberOfBoxes.Size = new System.Drawing.Size(55, 20);
            this.nudMaximumNumberOfBoxes.TabIndex = 24;
            this.nudMaximumNumberOfBoxes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxMaximumCaseWeight
            // 
            this.checkBoxMaximumCaseWeight.AutoSize = true;
            this.checkBoxMaximumCaseWeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMaximumCaseWeight.Location = new System.Drawing.Point(8, 69);
            this.checkBoxMaximumCaseWeight.Name = "checkBoxMaximumCaseWeight";
            this.checkBoxMaximumCaseWeight.Size = new System.Drawing.Size(176, 17);
            this.checkBoxMaximumCaseWeight.TabIndex = 22;
            this.checkBoxMaximumCaseWeight.Text = "when total case weight reaches";
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
            this.gbStopStackingCondition.Location = new System.Drawing.Point(12, 238);
            this.gbStopStackingCondition.Name = "gbStopStackingCondition";
            this.gbStopStackingCondition.Size = new System.Drawing.Size(295, 95);
            this.gbStopStackingCondition.TabIndex = 51;
            this.gbStopStackingCondition.TabStop = false;
            this.gbStopStackingCondition.Text = "Additional stop stacking conditions";
            // 
            // lbStopStacking
            // 
            this.lbStopStacking.AutoSize = true;
            this.lbStopStacking.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbStopStacking.Location = new System.Drawing.Point(9, 24);
            this.lbStopStacking.Name = "lbStopStacking";
            this.lbStopStacking.Size = new System.Drawing.Size(75, 13);
            this.lbStopStacking.TabIndex = 21;
            this.lbStopStacking.Text = "Stop stacking:";
            // 
            // checkBoxMaximumNumberOfBoxes
            // 
            this.checkBoxMaximumNumberOfBoxes.AutoSize = true;
            this.checkBoxMaximumNumberOfBoxes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMaximumNumberOfBoxes.Location = new System.Drawing.Point(8, 43);
            this.checkBoxMaximumNumberOfBoxes.Name = "checkBoxMaximumNumberOfBoxes";
            this.checkBoxMaximumNumberOfBoxes.Size = new System.Drawing.Size(174, 17);
            this.checkBoxMaximumNumberOfBoxes.TabIndex = 19;
            this.checkBoxMaximumNumberOfBoxes.Text = "when number of boxes reaches";
            this.checkBoxMaximumNumberOfBoxes.UseVisualStyleBackColor = true;
            this.checkBoxMaximumNumberOfBoxes.CheckedChanged += new System.EventHandler(this.onFormContentChanged);
            // 
            // FormNewBoxCaseAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 358);
            this.Controls.Add(this.gbStopStackingCondition);
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.gbAllowedBoxPositions);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.bnOk);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
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
            this.Text = "Create new Box/Case analysis...";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
    }
}