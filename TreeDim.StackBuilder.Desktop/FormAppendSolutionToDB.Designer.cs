namespace TreeDim.StackBuilder.Desktop
{
    partial class FormAppendSolutionToDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAppendSolutionToDB));
            this.lbFriendlyName = new System.Windows.Forms.Label();
            this.tbFriendlyName = new System.Windows.Forms.TextBox();
            this.bnOk = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbFriendlyName
            // 
            this.lbFriendlyName.AccessibleDescription = null;
            this.lbFriendlyName.AccessibleName = null;
            resources.ApplyResources(this.lbFriendlyName, "lbFriendlyName");
            this.lbFriendlyName.Font = null;
            this.lbFriendlyName.Name = "lbFriendlyName";
            // 
            // tbFriendlyName
            // 
            this.tbFriendlyName.AccessibleDescription = null;
            this.tbFriendlyName.AccessibleName = null;
            resources.ApplyResources(this.tbFriendlyName, "tbFriendlyName");
            this.tbFriendlyName.BackgroundImage = null;
            this.tbFriendlyName.Font = null;
            this.tbFriendlyName.Name = "tbFriendlyName";
            // 
            // bnOk
            // 
            this.bnOk.AccessibleDescription = null;
            this.bnOk.AccessibleName = null;
            resources.ApplyResources(this.bnOk, "bnOk");
            this.bnOk.BackgroundImage = null;
            this.bnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOk.Font = null;
            this.bnOk.Name = "bnOk";
            this.bnOk.UseVisualStyleBackColor = true;
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
            // FormAppendSolutionToDB
            // 
            this.AcceptButton = this.bnOk;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOk);
            this.Controls.Add(this.tbFriendlyName);
            this.Controls.Add(this.lbFriendlyName);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAppendSolutionToDB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFriendlyName;
        private System.Windows.Forms.TextBox tbFriendlyName;
        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnCancel;
    }
}