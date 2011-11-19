#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class OptionPanelReporting : GLib.Options.OptionsPanel
    {
        #region Constructor
        public OptionPanelReporting()
        {
            InitializeComponent();
        }
        #endregion

        #region Handlers
        private void btReportTemplateDir_Click(object sender, EventArgs e)
        {
            folderBrowserDlg.SelectedPath = tbReportTemplateDir.Text;
            if (DialogResult.OK == folderBrowserDlg.ShowDialog())
                tbReportTemplateDir.Text = folderBrowserDlg.SelectedPath;
        }
        #endregion
    }
}
