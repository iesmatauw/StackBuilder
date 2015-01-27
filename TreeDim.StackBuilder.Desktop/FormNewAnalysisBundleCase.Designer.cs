namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewAnalysisBundleCase
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
            this.lbBundle = new System.Windows.Forms.Label();
            this.lbCase = new System.Windows.Forms.Label();
            this.cbBundle = new System.Windows.Forms.ComboBox();
            this.cbCase = new System.Windows.Forms.ComboBox();
            this.gbStopStackingConditions = new System.Windows.Forms.GroupBox();
            this.lbStopStacking = new System.Windows.Forms.Label();
            this.uMassCase = new System.Windows.Forms.Label();
            this.nudMaximumCaseWeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaximumNumberOfBoxes = new System.Windows.Forms.NumericUpDown();
            this.checkBoxMaximumCaseWeight = new System.Windows.Forms.CheckBox();
            this.checkBoxMaximumNumberOfBoxes = new System.Windows.Forms.CheckBox();
            this.gbStopStackingConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumCaseWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfBoxes)).BeginInit();
            this.SuspendLayout();
            // 
            // lbBundle
            // 
            this.lbBundle.AutoSize = true;
            this.lbBundle.Location = new System.Drawing.Point(13, 67);
            this.lbBundle.Name = "lbBundle";
            this.lbBundle.Size = new System.Drawing.Size(40, 13);
            this.lbBundle.TabIndex = 7;
            this.lbBundle.Text = "Bundle";
            // 
            // lbCase
            // 
            this.lbCase.AutoSize = true;
            this.lbCase.Location = new System.Drawing.Point(296, 67);
            this.lbCase.Name = "lbCase";
            this.lbCase.Size = new System.Drawing.Size(31, 13);
            this.lbCase.TabIndex = 8;
            this.lbCase.Text = "Case";
            // 
            // cbBundle
            // 
            this.cbBundle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBundle.FormattingEnabled = true;
            this.cbBundle.Location = new System.Drawing.Point(111, 64);
            this.cbBundle.Name = "cbBundle";
            this.cbBundle.Size = new System.Drawing.Size(145, 21);
            this.cbBundle.TabIndex = 9;
            // 
            // cbCase
            // 
            this.cbCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCase.FormattingEnabled = true;
            this.cbCase.Location = new System.Drawing.Point(346, 64);
            this.cbCase.Name = "cbCase";
            this.cbCase.Size = new System.Drawing.Size(145, 21);
            this.cbCase.TabIndex = 10;
            // 
            // gbStopStackingConditions
            // 
            this.gbStopStackingConditions.Controls.Add(this.lbStopStacking);
            this.gbStopStackingConditions.Controls.Add(this.uMassCase);
            this.gbStopStackingConditions.Controls.Add(this.nudMaximumCaseWeight);
            this.gbStopStackingConditions.Controls.Add(this.nudMaximumNumberOfBoxes);
            this.gbStopStackingConditions.Controls.Add(this.checkBoxMaximumCaseWeight);
            this.gbStopStackingConditions.Controls.Add(this.checkBoxMaximumNumberOfBoxes);
            this.gbStopStackingConditions.Location = new System.Drawing.Point(13, 99);
            this.gbStopStackingConditions.Name = "gbStopStackingConditions";
            this.gbStopStackingConditions.Size = new System.Drawing.Size(478, 103);
            this.gbStopStackingConditions.TabIndex = 11;
            this.gbStopStackingConditions.TabStop = false;
            this.gbStopStackingConditions.Text = "Additional stop stacking conditions";
            // 
            // lbStopStacking
            // 
            this.lbStopStacking.AutoSize = true;
            this.lbStopStacking.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbStopStacking.Location = new System.Drawing.Point(3, 26);
            this.lbStopStacking.Name = "lbStopStacking";
            this.lbStopStacking.Size = new System.Drawing.Size(75, 13);
            this.lbStopStacking.TabIndex = 35;
            this.lbStopStacking.Text = "Stop stacking:";
            // 
            // uMassCase
            // 
            this.uMassCase.AutoSize = true;
            this.uMassCase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uMassCase.Location = new System.Drawing.Point(263, 79);
            this.uMassCase.Name = "uMassCase";
            this.uMassCase.Size = new System.Drawing.Size(38, 13);
            this.uMassCase.TabIndex = 34;
            this.uMassCase.Text = "uMass";
            // 
            // nudMaximumCaseWeight
            // 
            this.nudMaximumCaseWeight.DecimalPlaces = 3;
            this.nudMaximumCaseWeight.Location = new System.Drawing.Point(203, 75);
            this.nudMaximumCaseWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumCaseWeight.Name = "nudMaximumCaseWeight";
            this.nudMaximumCaseWeight.Size = new System.Drawing.Size(55, 20);
            this.nudMaximumCaseWeight.TabIndex = 33;
            // 
            // nudMaximumNumberOfBoxes
            // 
            this.nudMaximumNumberOfBoxes.Location = new System.Drawing.Point(203, 50);
            this.nudMaximumNumberOfBoxes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaximumNumberOfBoxes.Name = "nudMaximumNumberOfBoxes";
            this.nudMaximumNumberOfBoxes.Size = new System.Drawing.Size(55, 20);
            this.nudMaximumNumberOfBoxes.TabIndex = 32;
            // 
            // checkBoxMaximumCaseWeight
            // 
            this.checkBoxMaximumCaseWeight.AutoSize = true;
            this.checkBoxMaximumCaseWeight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMaximumCaseWeight.Location = new System.Drawing.Point(6, 77);
            this.checkBoxMaximumCaseWeight.Name = "checkBoxMaximumCaseWeight";
            this.checkBoxMaximumCaseWeight.Size = new System.Drawing.Size(176, 17);
            this.checkBoxMaximumCaseWeight.TabIndex = 31;
            this.checkBoxMaximumCaseWeight.Text = "when total case weight reaches";
            this.checkBoxMaximumCaseWeight.UseVisualStyleBackColor = true;
            this.checkBoxMaximumCaseWeight.CheckedChanged += new System.EventHandler(this.checkBoxMaximumCaseWeight_CheckedChanged);
            // 
            // checkBoxMaximumNumberOfBoxes
            // 
            this.checkBoxMaximumNumberOfBoxes.AutoSize = true;
            this.checkBoxMaximumNumberOfBoxes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMaximumNumberOfBoxes.Location = new System.Drawing.Point(6, 52);
            this.checkBoxMaximumNumberOfBoxes.Name = "checkBoxMaximumNumberOfBoxes";
            this.checkBoxMaximumNumberOfBoxes.Size = new System.Drawing.Size(183, 17);
            this.checkBoxMaximumNumberOfBoxes.TabIndex = 30;
            this.checkBoxMaximumNumberOfBoxes.Text = "when number of bundles reaches";
            this.checkBoxMaximumNumberOfBoxes.UseVisualStyleBackColor = true;
            this.checkBoxMaximumNumberOfBoxes.CheckedChanged += new System.EventHandler(this.checkBoxMaximumNumberOfBoxes_CheckedChanged);
            // 
            // FormNewAnalysisBundleCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.gbStopStackingConditions);
            this.Controls.Add(this.cbCase);
            this.Controls.Add(this.cbBundle);
            this.Controls.Add(this.lbCase);
            this.Controls.Add(this.lbBundle);
            this.Name = "FormNewAnalysisBundleCase";
            this.Text = "Create new bundle/case analysis...";
            this.Controls.SetChildIndex(this.lbBundle, 0);
            this.Controls.SetChildIndex(this.lbCase, 0);
            this.Controls.SetChildIndex(this.cbBundle, 0);
            this.Controls.SetChildIndex(this.cbCase, 0);
            this.Controls.SetChildIndex(this.gbStopStackingConditions, 0);
            this.gbStopStackingConditions.ResumeLayout(false);
            this.gbStopStackingConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumCaseWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumNumberOfBoxes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBundle;
        private System.Windows.Forms.Label lbCase;
        private System.Windows.Forms.ComboBox cbBundle;
        private System.Windows.Forms.ComboBox cbCase;
        private System.Windows.Forms.GroupBox gbStopStackingConditions;
        private System.Windows.Forms.Label uMassCase;
        private System.Windows.Forms.NumericUpDown nudMaximumCaseWeight;
        private System.Windows.Forms.NumericUpDown nudMaximumNumberOfBoxes;
        private System.Windows.Forms.CheckBox checkBoxMaximumCaseWeight;
        private System.Windows.Forms.CheckBox checkBoxMaximumNumberOfBoxes;
        private System.Windows.Forms.Label lbStopStacking;
    }
}