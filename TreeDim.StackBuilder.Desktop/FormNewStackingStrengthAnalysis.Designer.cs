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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewStackingStrengthAnalysis));
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
            this.lbCase.AccessibleDescription = null;
            this.lbCase.AccessibleName = null;
            resources.ApplyResources(this.lbCase, "lbCase");
            this.lbCase.Font = null;
            this.lbCase.Name = "lbCase";
            // 
            // cbCases
            // 
            this.cbCases.AccessibleDescription = null;
            this.cbCases.AccessibleName = null;
            resources.ApplyResources(this.cbCases, "cbCases");
            this.cbCases.BackgroundImage = null;
            this.cbCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCases.Font = null;
            this.cbCases.FormattingEnabled = true;
            this.cbCases.Name = "cbCases";
            this.cbCases.SelectedIndexChanged += new System.EventHandler(this.onDataChanged);
            // 
            // lbCardboard
            // 
            this.lbCardboard.AccessibleDescription = null;
            this.lbCardboard.AccessibleName = null;
            resources.ApplyResources(this.lbCardboard, "lbCardboard");
            this.lbCardboard.Font = null;
            this.lbCardboard.Name = "lbCardboard";
            // 
            // lbHumidity
            // 
            this.lbHumidity.AccessibleDescription = null;
            this.lbHumidity.AccessibleName = null;
            resources.ApplyResources(this.lbHumidity, "lbHumidity");
            this.lbHumidity.Font = null;
            this.lbHumidity.Name = "lbHumidity";
            // 
            // lbStorageDuration
            // 
            this.lbStorageDuration.AccessibleDescription = null;
            this.lbStorageDuration.AccessibleName = null;
            resources.ApplyResources(this.lbStorageDuration, "lbStorageDuration");
            this.lbStorageDuration.Font = null;
            this.lbStorageDuration.Name = "lbStorageDuration";
            // 
            // cbCardboard
            // 
            this.cbCardboard.AccessibleDescription = null;
            this.cbCardboard.AccessibleName = null;
            resources.ApplyResources(this.cbCardboard, "cbCardboard");
            this.cbCardboard.BackgroundImage = null;
            this.cbCardboard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCardboard.Font = null;
            this.cbCardboard.FormattingEnabled = true;
            this.cbCardboard.Name = "cbCardboard";
            this.cbCardboard.SelectedIndexChanged += new System.EventHandler(this.onDataChanged);
            // 
            // cbRateOfHumidity
            // 
            this.cbRateOfHumidity.AccessibleDescription = null;
            this.cbRateOfHumidity.AccessibleName = null;
            resources.ApplyResources(this.cbRateOfHumidity, "cbRateOfHumidity");
            this.cbRateOfHumidity.BackgroundImage = null;
            this.cbRateOfHumidity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRateOfHumidity.Font = null;
            this.cbRateOfHumidity.FormattingEnabled = true;
            this.cbRateOfHumidity.Name = "cbRateOfHumidity";
            this.cbRateOfHumidity.SelectedIndexChanged += new System.EventHandler(this.onDataChanged);
            // 
            // cbStorageDuration
            // 
            this.cbStorageDuration.AccessibleDescription = null;
            this.cbStorageDuration.AccessibleName = null;
            resources.ApplyResources(this.cbStorageDuration, "cbStorageDuration");
            this.cbStorageDuration.BackgroundImage = null;
            this.cbStorageDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStorageDuration.Font = null;
            this.cbStorageDuration.FormattingEnabled = true;
            this.cbStorageDuration.Name = "cbStorageDuration";
            this.cbStorageDuration.SelectedIndexChanged += new System.EventHandler(this.onDataChanged);
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
            // FormNewStackingStrengthAnalysis
            // 
            this.AcceptButton = this.bnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.bnCancel;
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
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewStackingStrengthAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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