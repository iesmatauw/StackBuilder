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
            resources.ApplyResources(this.lbFriendlyName, "lbFriendlyName");
            this.lbFriendlyName.Name = "lbFriendlyName";
            // 
            // tbFriendlyName
            // 
            resources.ApplyResources(this.tbFriendlyName, "tbFriendlyName");
            this.tbFriendlyName.Name = "tbFriendlyName";
            this.tbFriendlyName.TextChanged += new System.EventHandler(this.tbFriendlyName_TextChanged);
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
            // labelQuestion
            // 
            resources.ApplyResources(this.labelQuestion, "labelQuestion");
            this.labelQuestion.Name = "labelQuestion";
            // 
            // rbKeepReplace1
            // 
            resources.ApplyResources(this.rbKeepReplace1, "rbKeepReplace1");
            this.rbKeepReplace1.Checked = true;
            this.rbKeepReplace1.Name = "rbKeepReplace1";
            this.rbKeepReplace1.TabStop = true;
            this.rbKeepReplace1.UseVisualStyleBackColor = true;
            // 
            // rbKeepReplace2
            // 
            resources.ApplyResources(this.rbKeepReplace2, "rbKeepReplace2");
            this.rbKeepReplace2.Name = "rbKeepReplace2";
            this.rbKeepReplace2.UseVisualStyleBackColor = true;
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
            // FormAppendSolutionToDB
            // 
            this.AcceptButton = this.bnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.Controls.Add(this.statusStripDef);
            this.Controls.Add(this.rbKeepReplace2);
            this.Controls.Add(this.rbKeepReplace1);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOk);
            this.Controls.Add(this.tbFriendlyName);
            this.Controls.Add(this.lbFriendlyName);
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