namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewStackingStrengthAnalysis
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
            this.lbCase = new System.Windows.Forms.Label();
            this.cbCases = new System.Windows.Forms.ComboBox();
            this.lbCardboard = new System.Windows.Forms.Label();
            this.lbHumidity = new System.Windows.Forms.Label();
            this.lbStorageDuration = new System.Windows.Forms.Label();
            this.cbCardboard = new System.Windows.Forms.ComboBox();
            this.cbRateOfHumidity = new System.Windows.Forms.ComboBox();
            this.cbStorageDuration = new System.Windows.Forms.ComboBox();
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCase
            // 
            this.lbCase.AutoSize = true;
            this.lbCase.Location = new System.Drawing.Point(8, 10);
            this.lbCase.Name = "lbCase";
            this.lbCase.Size = new System.Drawing.Size(31, 13);
            this.lbCase.TabIndex = 0;
            this.lbCase.Text = "Case";
            // 
            // cbCases
            // 
            this.cbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCases.FormattingEnabled = true;
            this.cbCases.Location = new System.Drawing.Point(119, 10);
            this.cbCases.Name = "cbCases";
            this.cbCases.Size = new System.Drawing.Size(230, 21);
            this.cbCases.TabIndex = 1;
            this.cbCases.SelectedIndexChanged += new System.EventHandler(this.onDataChanged);
            // 
            // lbCardboard
            // 
            this.lbCardboard.AutoSize = true;
            this.lbCardboard.Location = new System.Drawing.Point(8, 42);
            this.lbCardboard.Name = "lbCardboard";
            this.lbCardboard.Size = new System.Drawing.Size(56, 13);
            this.lbCardboard.TabIndex = 2;
            this.lbCardboard.Text = "Cardboard";
            // 
            // lbHumidity
            // 
            this.lbHumidity.AutoSize = true;
            this.lbHumidity.Location = new System.Drawing.Point(8, 74);
            this.lbHumidity.Name = "lbHumidity";
            this.lbHumidity.Size = new System.Drawing.Size(83, 13);
            this.lbHumidity.TabIndex = 3;
            this.lbHumidity.Text = "Rate of humidity";
            // 
            // lbStorageDuration
            // 
            this.lbStorageDuration.AutoSize = true;
            this.lbStorageDuration.Location = new System.Drawing.Point(8, 106);
            this.lbStorageDuration.Name = "lbStorageDuration";
            this.lbStorageDuration.Size = new System.Drawing.Size(85, 13);
            this.lbStorageDuration.TabIndex = 4;
            this.lbStorageDuration.Text = "Storage duration";
            // 
            // cbCardboard
            // 
            this.cbCardboard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCardboard.FormattingEnabled = true;
            this.cbCardboard.Location = new System.Drawing.Point(119, 42);
            this.cbCardboard.Name = "cbCardboard";
            this.cbCardboard.Size = new System.Drawing.Size(230, 21);
            this.cbCardboard.TabIndex = 5;
            this.cbCardboard.SelectedIndexChanged += new System.EventHandler(this.onDataChanged);
            // 
            // cbRateOfHumidity
            // 
            this.cbRateOfHumidity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRateOfHumidity.FormattingEnabled = true;
            this.cbRateOfHumidity.Location = new System.Drawing.Point(119, 74);
            this.cbRateOfHumidity.Name = "cbRateOfHumidity";
            this.cbRateOfHumidity.Size = new System.Drawing.Size(230, 21);
            this.cbRateOfHumidity.TabIndex = 6;
            this.cbRateOfHumidity.SelectedIndexChanged += new System.EventHandler(this.onDataChanged);
            // 
            // cbStorageDuration
            // 
            this.cbStorageDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStorageDuration.FormattingEnabled = true;
            this.cbStorageDuration.Location = new System.Drawing.Point(119, 106);
            this.cbStorageDuration.Name = "cbStorageDuration";
            this.cbStorageDuration.Size = new System.Drawing.Size(230, 21);
            this.cbStorageDuration.TabIndex = 7;
            this.cbStorageDuration.SelectedIndexChanged += new System.EventHandler(this.onDataChanged);
            // 
            // bnOK
            // 
            this.bnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Location = new System.Drawing.Point(407, 10);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 8;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(407, 40);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 9;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // FormNewStackingStrengthAnalysis
            // 
            this.AcceptButton = this.bnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(492, 385);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.cbStorageDuration);
            this.Controls.Add(this.cbRateOfHumidity);
            this.Controls.Add(this.cbCardboard);
            this.Controls.Add(this.lbStorageDuration);
            this.Controls.Add(this.lbHumidity);
            this.Controls.Add(this.lbCardboard);
            this.Controls.Add(this.cbCases);
            this.Controls.Add(this.lbCase);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewStackingStrengthAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Create new strength analysis...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCase;
        private System.Windows.Forms.ComboBox cbCases;
        private System.Windows.Forms.Label lbCardboard;
        private System.Windows.Forms.Label lbHumidity;
        private System.Windows.Forms.Label lbStorageDuration;
        private System.Windows.Forms.ComboBox cbCardboard;
        private System.Windows.Forms.ComboBox cbRateOfHumidity;
        private System.Windows.Forms.ComboBox cbStorageDuration;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
    }
}