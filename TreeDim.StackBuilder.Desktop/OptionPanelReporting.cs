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
using TreeDim.StackBuilder;
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
            nudTop.Value = (decimal)Reporting.Properties.Settings.Default.MarginTop;
            nudBottom.Value = (decimal)Reporting.Properties.Settings.Default.MarginBottom;
            nudLeft.Value = (decimal)Reporting.Properties.Settings.Default.MarginLeft;
            nudRight.Value = (decimal)Reporting.Properties.Settings.Default.MarginRight;
        }

        void OptionsForm_OptionsSaving(object sender, EventArgs e)
        {
            Properties.Settings.Default.ReportTemplatePath = fileSelectCtrlReportTemplate.FileName;
            Properties.Settings.Default.CompanyLogoPath = fileSelectCompanyLogo.FileName;
            Properties.Settings.Default.ReporterImageSize = cbImageSizes.SelectedIndex;
            Reporting.Properties.Settings.Default.MarginTop = (float)nudTop.Value;
            Reporting.Properties.Settings.Default.MarginBottom = (float)nudBottom.Value;
            Reporting.Properties.Settings.Default.MarginLeft = (float)nudLeft.Value;
            Reporting.Properties.Settings.Default.MarginRight = (float)nudRight.Value;
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
