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
            this.chkbUseCompanySpecificReportTemplate = new System.Windows.Forms.CheckBox();
            this.fileSelectCtrlUsedReportTemplate = new TreeDim.UserControls.FileSelect();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSelectCompanyLogo = new TreeDim.UserControls.FileSelect();
            this.lbImageSizes = new System.Windows.Forms.Label();
            this.cbImageSizes = new System.Windows.Forms.ComboBox();
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
            // chkbUseCompanySpecificReportTemplate
            // 
            resources.ApplyResources(this.chkbUseCompanySpecificReportTemplate, "chkbUseCompanySpecificReportTemplate");
            this.chkbUseCompanySpecificReportTemplate.Name = "chkbUseCompanySpecificReportTemplate";
            this.chkbUseCompanySpecificReportTemplate.UseVisualStyleBackColor = true;
            this.chkbUseCompanySpecificReportTemplate.CheckedChanged += new System.EventHandler(this.chkbUseCompanySpecificReportTemplate_CheckedChanged);
            // 
            // fileSelectCtrlUsedReportTemplate
            // 
            resources.ApplyResources(this.fileSelectCtrlUsedReportTemplate, "fileSelectCtrlUsedReportTemplate");
            this.fileSelectCtrlUsedReportTemplate.Filter = "XSLT Stylesheet (.xsl)|*.xsl";
            this.fileSelectCtrlUsedReportTemplate.Name = "fileSelectCtrlUsedReportTemplate";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // fileSelectCompanyLogo
            // 
            resources.ApplyResources(this.fileSelectCompanyLogo, "fileSelectCompanyLogo");
            this.fileSelectCompanyLogo.Filter = "Image file (.bmp;.gif;.jpg;.png)|*.bmp;*.gif;*.jpg;*.png";
            this.fileSelectCompanyLogo.Name = "fileSelectCompanyLogo";
            // 
            // lbImageSizes
            // 
            resources.ApplyResources(this.lbImageSizes, "lbImageSizes");
            this.lbImageSizes.Name = "lbImageSizes";
            // 
            // cbImageSizes
            // 
            resources.ApplyResources(this.cbImageSizes, "cbImageSizes");
            this.cbImageSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImageSizes.FormattingEnabled = true;
            this.cbImageSizes.Items.AddRange(new object[] {
            resources.GetString("cbImageSizes.Items"),
            resources.GetString("cbImageSizes.Items1")});
            this.cbImageSizes.Name = "cbImageSizes";
            // 
            // OptionPanelReporting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Reporting";
            this.Controls.Add(this.cbImageSizes);
            this.Controls.Add(this.lbImageSizes);
            this.Controls.Add(this.fileSelectCompanyLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileSelectCtrlUsedReportTemplate);
            this.Controls.Add(this.chkbUseCompanySpecificReportTemplate);
            this.Controls.Add(this.btReportTemplateDir);
            this.Controls.Add(this.tbReportTemplateDir);
            this.Controls.Add(this.lbReportTemplatesDir);
            this.DisplayName = "Reporting";
            this.Name = "OptionPanelReporting";
            this.Load += new System.EventHandler(this.OptionPanelReporting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbReportTemplatesDir;
        private System.Windows.Forms.TextBox tbReportTemplateDir;
        private System.Windows.Forms.Button btReportTemplateDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
        private System.Windows.Forms.CheckBox chkbUseCompanySpecificReportTemplate;
        private TreeDim.UserControls.FileSelect fileSelectCtrlUsedReportTemplate;
        private System.Windows.Forms.Label label1;
        private UserControls.FileSelect fileSelectCompanyLogo;
        private System.Windows.Forms.Label lbImageSizes;
        private System.Windows.Forms.ComboBox cbImageSizes;
    }
}
