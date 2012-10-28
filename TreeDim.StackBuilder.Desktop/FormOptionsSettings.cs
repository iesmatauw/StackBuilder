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
    public partial class FormOptionsSettings : GLib.Options.OptionsForm
    {
        public FormOptionsSettings()
        {
            InitializeComponent();

            Panels.Add(new OptionPanelReporting());
            Panels.Add(new OptionPanelDebugging());
        }
    }
}
