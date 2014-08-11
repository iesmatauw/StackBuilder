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
            this.gbMSWordMargins = new System.Windows.Forms.GroupBox();
            this.lbCmRight = new System.Windows.Forms.Label();
            this.lbCmLeft = new System.Windows.Forms.Label();
            this.lbcmBottom = new System.Windows.Forms.Label();
            this.lbcm = new System.Windows.Forms.Label();
            this.nudRight = new System.Windows.Forms.NumericUpDown();
            this.nudBottom = new System.Windows.Forms.NumericUpDown();
            this.nudLeft = new System.Windows.Forms.NumericUpDown();
            this.nudTop = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLeft = new System.Windows.Forms.Label();
            this.lbBottom = new System.Windows.Forms.Label();
            this.lbTop = new System.Windows.Forms.Label();
            this.gbMSWordMargins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).BeginInit();
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
            // gbMSWordMargins
            // 
            resources.ApplyResources(this.gbMSWordMargins, "gbMSWordMargins");
            this.gbMSWordMargins.Controls.Add(this.lbCmRight);
            this.gbMSWordMargins.Controls.Add(this.lbCmLeft);
            this.gbMSWordMargins.Controls.Add(this.lbcmBottom);
            this.gbMSWordMargins.Controls.Add(this.lbcm);
            this.gbMSWordMargins.Controls.Add(this.nudRight);
            this.gbMSWordMargins.Controls.Add(this.nudBottom);
            this.gbMSWordMargins.Controls.Add(this.nudLeft);
            this.gbMSWordMargins.Controls.Add(this.nudTop);
            this.gbMSWordMargins.Controls.Add(this.label2);
            this.gbMSWordMargins.Controls.Add(this.lbLeft);
            this.gbMSWordMargins.Controls.Add(this.lbBottom);
            this.gbMSWordMargins.Controls.Add(this.lbTop);
            this.gbMSWordMargins.Name = "gbMSWordMargins";
            this.gbMSWordMargins.TabStop = false;
            // 
            // lbCmRight
            // 
            resources.ApplyResources(this.lbCmRight, "lbCmRight");
            this.lbCmRight.Name = "lbCmRight";
            // 
            // lbCmLeft
            // 
            resources.ApplyResources(this.lbCmLeft, "lbCmLeft");
            this.lbCmLeft.Name = "lbCmLeft";
            // 
            // lbcmBottom
            // 
            resources.ApplyResources(this.lbcmBottom, "lbcmBottom");
            this.lbcmBottom.Name = "lbcmBottom";
            // 
            // lbcm
            // 
            resources.ApplyResources(this.lbcm, "lbcm");
            this.lbcm.Name = "lbcm";
            // 
            // nudRight
            // 
            resources.ApplyResources(this.nudRight, "nudRight");
            this.nudRight.DecimalPlaces = 1;
            this.nudRight.Name = "nudRight";
            // 
            // nudBottom
            // 
            resources.ApplyResources(this.nudBottom, "nudBottom");
            this.nudBottom.DecimalPlaces = 1;
            this.nudBottom.Name = "nudBottom";
            // 
            // nudLeft
            // 
            resources.ApplyResources(this.nudLeft, "nudLeft");
            this.nudLeft.DecimalPlaces = 1;
            this.nudLeft.Name = "nudLeft";
            // 
            // nudTop
            // 
            resources.ApplyResources(this.nudTop, "nudTop");
            this.nudTop.DecimalPlaces = 1;
            this.nudTop.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudTop.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTop.Name = "nudTop";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lbLeft
            // 
            resources.ApplyResources(this.lbLeft, "lbLeft");
            this.lbLeft.Name = "lbLeft";
            // 
            // lbBottom
            // 
            resources.ApplyResources(this.lbBottom, "lbBottom");
            this.lbBottom.Name = "lbBottom";
            // 
            // lbTop
            // 
            resources.ApplyResources(this.lbTop, "lbTop");
            this.lbTop.Name = "lbTop";
            // 
            // OptionPanelReporting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CategoryPath = "Options\\\\Rapports";
            this.Controls.Add(this.gbMSWordMargins);
            this.Controls.Add(this.lbReportTemplate);
            this.Controls.Add(this.cbImageSizes);
            this.Controls.Add(this.lbImageSizes);
            this.Controls.Add(this.fileSelectCompanyLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileSelectCtrlReportTemplate);
            this.DisplayName = "Rapports";
            this.Name = "OptionPanelReporting";
            this.Load += new System.EventHandler(this.OptionPanelReporting_Load);
            this.gbMSWordMargins.ResumeLayout(false);
            this.gbMSWordMargins.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).EndInit();
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
        private System.Windows.Forms.GroupBox gbMSWordMargins;
        private System.Windows.Forms.NumericUpDown nudTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbLeft;
        private System.Windows.Forms.Label lbBottom;
        private System.Windows.Forms.Label lbTop;
        private System.Windows.Forms.NumericUpDown nudRight;
        private System.Windows.Forms.NumericUpDown nudBottom;
        private System.Windows.Forms.NumericUpDown nudLeft;
        private System.Windows.Forms.Label lbCmRight;
        private System.Windows.Forms.Label lbCmLeft;
        private System.Windows.Forms.Label lbcmBottom;
        private System.Windows.Forms.Label lbcm;
    }
}
