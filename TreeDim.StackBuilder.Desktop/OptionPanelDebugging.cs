#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class OptionPanelDebugging : GLib.Options.OptionsPanel
    {
        #region Constructor
        public OptionPanelDebugging()
        {
            InitializeComponent();
        }
        #endregion

        #region Handlers
        private void chkShowLogConsole_CheckedChanged(object sender, EventArgs e)
        {
            // force setting
            Settings.Default.ShowLogConsole = chkShowLogConsole.Checked;
            // show or hide log console
            FormMain form = FormMain.GetInstance();
            form.ShowLogConsole();
        }
        #endregion
    }
}
