using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeDim.StackBuilder.Desktop
{
    public partial class OptionPanelPlugins : GLib.Options.OptionsPanel
    {
        #region Constructor
        public OptionPanelPlugins()
        {
            InitializeComponent();
            chkbPluginINTEX.Checked = Properties.Settings.Default.HasPluginINTEX;

        }
        #endregion

        #region Handlers
        private void OptionPanelPlugins_Load(object sender, EventArgs e)
        {
            // events
            OptionsForm.OptionsSaving += new EventHandler(OptionsForm_OptionsSaving);
        }

        void OptionsForm_OptionsSaving(object sender, EventArgs e)
        {
            Properties.Settings.Default.HasPluginINTEX = chkbPluginINTEX.Checked;
        }
        #endregion
    }
}
