#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using log4net;
using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class DockContentStartPage : DockContent
    {
        #region constructor
        public DockContentStartPage()
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        public System.Uri Url
        {
            get { return webBrowserStartPage.Url; }
            set { webBrowserStartPage.Url = value; }
        }
        #endregion
    }
}
