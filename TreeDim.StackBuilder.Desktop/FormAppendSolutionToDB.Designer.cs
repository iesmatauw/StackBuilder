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
            this.labelQuestion = new System.Windows.Forms.Label();
            this.rbKeepReplace1 = new System.Windows.Forms.RadioButton();
            this.rbKeepReplace2 = new System.Windows.Forms.RadioButton();
            this.statusStripDef = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDef = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripDef.SuspendLayout();
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
            this.tbFriendlyName.TextChanged += new System.EventHandler(this.tbFriendlyName_TextChanged);
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
            // labelQuestion
            // 
            this.labelQuestion.AccessibleDescription = null;
            this.labelQuestion.AccessibleName = null;
            resources.ApplyResources(this.labelQuestion, "labelQuestion");
            this.labelQuestion.Font = null;
            this.labelQuestion.Name = "labelQuestion";
            // 
            // rbKeepReplace1
            // 
            this.rbKeepReplace1.AccessibleDescription = null;
            this.rbKeepReplace1.AccessibleName = null;
            resources.ApplyResources(this.rbKeepReplace1, "rbKeepReplace1");
            this.rbKeepReplace1.BackgroundImage = null;
            this.rbKeepReplace1.Checked = true;
            this.rbKeepReplace1.Font = null;
            this.rbKeepReplace1.Name = "rbKeepReplace1";
            this.rbKeepReplace1.TabStop = true;
            this.rbKeepReplace1.UseVisualStyleBackColor = true;
            // 
            // rbKeepReplace2
            // 
            this.rbKeepReplace2.AccessibleDescription = null;
            this.rbKeepReplace2.AccessibleName = null;
            resources.ApplyResources(this.rbKeepReplace2, "rbKeepReplace2");
            this.rbKeepReplace2.BackgroundImage = null;
            this.rbKeepReplace2.Font = null;
            this.rbKeepReplace2.Name = "rbKeepReplace2";
            this.rbKeepReplace2.UseVisualStyleBackColor = true;
            // 
            // statusStripDef
            // 
            this.statusStripDef.AccessibleDescription = null;
            this.statusStripDef.AccessibleName = null;
            resources.ApplyResources(this.statusStripDef, "statusStripDef");
            this.statusStripDef.BackgroundImage = null;
            this.statusStripDef.Font = null;
            this.statusStripDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDef});
            this.statusStripDef.Name = "statusStripDef";
            this.statusStripDef.SizingGrip = false;
            // 
            // toolStripStatusLabelDef
            // 
            this.toolStripStatusLabelDef.AccessibleDescription = null;
            this.toolStripStatusLabelDef.AccessibleName = null;
            resources.ApplyResources(this.toolStripStatusLabelDef, "toolStripStatusLabelDef");
            this.toolStripStatusLabelDef.BackgroundImage = null;
            this.toolStripStatusLabelDef.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelDef.Name = "toolStripStatusLabelDef";
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
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.rbKeepReplace2);
            this.Controls.Add(this.rbKeepReplace1);
            this.Controls.Add(this.labelQuestion);
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
            this.statusStripDef.ResumeLayout(false);
            this.statusStripDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFriendlyName;
        private System.Windows.Forms.TextBox tbFriendlyName;
        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.RadioButton rbKeepReplace1;
        private System.Windows.Forms.RadioButton rbKeepReplace2;
        private System.Windows.Forms.StatusStrip statusStripDef;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDef;
    }
}