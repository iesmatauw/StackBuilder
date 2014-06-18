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
            fileSelectCtrlReportTemplate.FileName = Properties.Settings.Default.ReportTemplatePath;
            fileSelectCompanyLogo.FileName = Properties.Settings.Default.CompanyLogoPath;
            cbImageSizes.SelectedIndex = Properties.Settings.Default.ReporterImageSize;
        }

        void OptionsForm_OptionsSaving(object sender, EventArgs e)
        {
            Properties.Settings.Default.ReportTemplatePath = fileSelectCtrlReportTemplate.FileName;
            Properties.Settings.Default.CompanyLogoPath = fileSelectCompanyLogo.FileName;
            Properties.Settings.Default.ReporterImageSize = cbImageSizes.SelectedIndex;
        }
        #endregion

        #region Handlers
        private void OptionPanelReporting_Load(object sender, EventArgs e)
        {
            // events
            OptionsForm.OptionsSaving += new EventHandler(OptionsForm_OptionsSaving);
        }
        #endregion
    }
}
