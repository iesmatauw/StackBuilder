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
            // lbCardboard
            // 
            resources.ApplyResources(this.lbCardboard, "lbCardboard");
            this.lbCardboard.Name = "lbCardboard";
            // 
            // lbHumidity
            // 
            resources.ApplyResources(this.lbHumidity, "lbHumidity");
            this.lbHumidity.Name = "lbHumidity";
            // 
            // lbStorageDuration
            // 
            resources.ApplyResources(this.lbStorageDuration, "lbStorageDuration");
            this.lbStorageDuration.Name = "lbStorageDuration";
            // 
            // cbCardboard
            // 
            this.cbCardboard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCardboard.FormattingEnabled = true;
            resources.ApplyResources(this.cbCardboard, "cbCardboard");
            this.cbCardboard.Name = "cbCardboard";
            this.cbCardboard.SelectedIndexChanged += new System.EventHandler(this.onDataChanged);
            // 
            // cbRateOfHumidity
            // 
            this.cbRateOfHumidity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRateOfHumidity.FormattingEnabled = true;
            resources.ApplyResources(this.cbRateOfHumidity, "cbRateOfHumidity");
            this.cbRateOfHumidity.Name = "cbRateOfHumidity";
            this.cbRateOfHumidity.SelectedIndexChanged += new System.EventHandler(this.onDataChanged);
            // 
            // cbStorageDuration
            // 
            this.cbStorageDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStorageDuration.FormattingEnabled = true;
            resources.ApplyResources(this.cbStorageDuration, "cbStorageDuration");
            this.cbStorageDuration.Name = "cbStorageDuration";
            this.cbStorageDuration.SelectedIndexChanged += new System.EventHandler(this.onDataChanged);
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
            // FormNewStackingStrengthAnalysis
            // 
            this.AcceptButton = this.bnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.cbStorageDuration);
            this.Controls.Add(this.cbRateOfHumidity);
            this.Controls.Add(this.cbCardboard);
            this.Controls.Add(this.lbStorageDuration);
            this.Controls.Add(this.lbHumidity);
            this.Controls.Add(this.lbCardboard);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewStackingStrengthAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormNewStackingStrengthAnalysis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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