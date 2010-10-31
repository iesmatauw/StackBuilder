namespace TreeDim.StackBuilder.Desktop
{
    partial class FormNewCaseAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewCaseAnalysis));
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            // lbName
            // 
            this.lbName.AccessibleDescription = null;
            this.lbName.AccessibleName = null;
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Font = null;
            this.lbName.Name = "lbName";
            // 
            // lbDescription
            // 
            this.lbDescription.AccessibleDescription = null;
            this.lbDescription.AccessibleName = null;
            resources.ApplyResources(this.lbDescription, "lbDescription");
            this.lbDescription.Font = null;
            this.lbDescription.Name = "lbDescription";
            // 
            // tbName
            // 
            this.tbName.AccessibleDescription = null;
            this.tbName.AccessibleName = null;
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.BackgroundImage = null;
            this.tbName.Font = null;
            this.tbName.Name = "tbName";
            // 
            // tbDescription
            // 
            this.tbDescription.AccessibleDescription = null;
            this.tbDescription.AccessibleName = null;
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.BackgroundImage = null;
            this.tbDescription.Font = null;
            this.tbDescription.Name = "tbDescription";
            // 
            // FormNewCaseAnalysis
            // 
            this.AcceptButton = this.bnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewCaseAnalysis";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormNewCaseAnalysis_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewCaseAnalysis_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
    }
}