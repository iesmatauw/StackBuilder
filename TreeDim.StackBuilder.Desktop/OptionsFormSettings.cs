#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class OptionsFormSettings : GLib.Options.OptionsForm
    {
        public OptionsFormSettings()
        {
            InitializeComponent();

            Panels.Add(new OptionPanelReporting());
            Panels.Add(new OptionPanelDebugging());
        }
    }
}
