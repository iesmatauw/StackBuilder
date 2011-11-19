namespace TreeDim.StackBuilder.Desktop
{
    partial class OptionPanelReporting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionPanelReporting));
            this.lbReportTemplatesDir = new System.Windows.Forms.Label();
            this.tbReportTemplateDir = new System.Windows.Forms.TextBox();
            this.btReportTemplateDir = new System.Windows.Forms.Button();
            this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // lbReportTemplatesDir
            // 
            resources.ApplyResources(this.lbReportTemplatesDir, "lbReportTemplatesDir");
            this.lbReportTemplatesDir.Name = "lbReportTemplatesDir";
            // 
            // tbReportTemplateDir
            // 
            resources.ApplyResources(this.tbReportTemplateDir, "tbReportTemplateDir");
            this.tbReportTemplateDir.Name = "tbReportTemplateDir";
            this.tbReportTemplateDir.Text = global::TreeDim.StackBuilder.Desktop.Properties.Settings.Default.ReportTemplatePath;
            // 
            // btReportTemplateDir
            // 
            resources.ApplyResources(this.btReportTemplateDir, "btReportTemplateDir");
            this.btReportTemplateDir.Name = "btReportTemplateDir";
            this.btReportTemplateDir.UseVisualStyleBackColor = true;
            this.btReportTemplateDir.Click += new System.EventHandler(this.btReportTemplateDir_Click);
            // 
            // folderBrowserDlg
            // 
            resources.ApplyResources(this.folderBrowserDlg, "folderBrowserDlg");
            // 
            // OptionPanelReporting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Reporting";
            this.Controls.Add(this.btReportTemplateDir);
            this.Controls.Add(this.tbReportTemplateDir);
            this.Controls.Add(this.lbReportTemplatesDir);
            this.DisplayName = "Reporting";
            this.Name = "OptionPanelReporting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbReportTemplatesDir;
        private System.Windows.Forms.TextBox tbReportTemplateDir;
        private System.Windows.Forms.Button btReportTemplateDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
    }
}
