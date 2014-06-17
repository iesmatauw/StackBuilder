#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using TreeDim.UserControls;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class OptionPanelReporting : GLib.Options.OptionsPanel
    {
        #region Constructor
        public OptionPanelReporting()
        {
            InitializeComponent();
            // initialize
            chkbUseCompanySpecificReportTemplate.Checked = Properties.Settings.Default.UseCompanySpecificReportTemplate;
            fileSelectCtrlUsedReportTemplate.FileName = Properties.Settings.Default.CompanySpecificReportTemplate;
            fileSelectCompanyLogo.FileName = Properties.Settings.Default.CompanyLogoPath;
            cbImageSizes.SelectedIndex = Properties.Settings.Default.ReporterImageSize;
        }

        void OptionsForm_OptionsSaving(object sender, EventArgs e)
        {
            Properties.Settings.Default.CompanySpecificReportTemplate = fileSelectCtrlUsedReportTemplate.FileName;
            Properties.Settings.Default.UseCompanySpecificReportTemplate
                = chkbUseCompanySpecificReportTemplate.Checked
                && System.IO.File.Exists(fileSelectCtrlUsedReportTemplate.FileName);
            Properties.Settings.Default.CompanyLogoPath = fileSelectCompanyLogo.FileName;
            Properties.Settings.Default.ReporterImageSize = cbImageSizes.SelectedIndex;
        }
        #endregion

        #region Handlers
        private void OptionPanelReporting_Load(object sender, EventArgs e)
        {
            // events
            OptionsForm.OptionsSaving += new EventHandler(OptionsForm_OptionsSaving);
            // update fileSelectControl
            chkbUseCompanySpecificReportTemplate_CheckedChanged(this, null);
        }
        private void btReportTemplateDir_Click(object sender, EventArgs e)
        {
            folderBrowserDlg.SelectedPath = tbReportTemplateDir.Text;
            if (DialogResult.OK == folderBrowserDlg.ShowDialog())
                tbReportTemplateDir.Text = folderBrowserDlg.SelectedPath;
        }
        private void chkbUseCompanySpecificReportTemplate_CheckedChanged(object sender, EventArgs e)
        {
            fileSelectCtrlUsedReportTemplate.Enabled = chkbUseCompanySpecificReportTemplate.Checked;
        }
        #endregion
    }
}
