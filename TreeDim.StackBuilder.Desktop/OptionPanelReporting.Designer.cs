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
            this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSelectCtrlReportTemplate = new TreeDim.UserControls.FileSelect();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSelectCompanyLogo = new TreeDim.UserControls.FileSelect();
            this.lbImageSizes = new System.Windows.Forms.Label();
            this.cbImageSizes = new System.Windows.Forms.ComboBox();
            this.lbReportTemplate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // folderBrowserDlg
            // 
            resources.ApplyResources(this.folderBrowserDlg, "folderBrowserDlg");
            // 
            // fileSelectCtrlReportTemplate
            // 
            resources.ApplyResources(this.fileSelectCtrlReportTemplate, "fileSelectCtrlReportTemplate");
            this.fileSelectCtrlReportTemplate.Filter = "XSLT Stylesheet (.xsl)|*.xsl";
            this.fileSelectCtrlReportTemplate.Name = "fileSelectCtrlReportTemplate";
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
            // lbReportTemplate
            // 
            resources.ApplyResources(this.lbReportTemplate, "lbReportTemplate");
            this.lbReportTemplate.Name = "lbReportTemplate";
            // 
            // OptionPanelReporting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Reporting";
            this.Controls.Add(this.lbReportTemplate);
            this.Controls.Add(this.cbImageSizes);
            this.Controls.Add(this.lbImageSizes);
            this.Controls.Add(this.fileSelectCompanyLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileSelectCtrlReportTemplate);
            this.DisplayName = "Reporting";
            this.Name = "OptionPanelReporting";
            this.Load += new System.EventHandler(this.OptionPanelReporting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
        private TreeDim.UserControls.FileSelect fileSelectCtrlReportTemplate;
        private System.Windows.Forms.Label label1;
        private UserControls.FileSelect fileSelectCompanyLogo;
        private System.Windows.Forms.Label lbImageSizes;
        private System.Windows.Forms.ComboBox cbImageSizes;
        private System.Windows.Forms.Label lbReportTemplate;
    }
}
