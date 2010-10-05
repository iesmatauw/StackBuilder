using System;
#region Using directives
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class SplashScreen : Form
    {
        #region Constructor
        public SplashScreen()
        {
            InitializeComponent();

            // make lower right pixel color transparent
            Bitmap b = new Bitmap(this.BackgroundImage);
            b.MakeTransparent(b.GetPixel(1, 1));
            this.BackgroundImage = b;

            // version
            lblVersion.Text = String.Format("Version {0}", AssemblyVersion); ;
        }
        #endregion

        #region Public properties
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public int TimerInterval
        {
            set { timerClose.Interval = value;  }
            get { return timerClose.Interval; }
        }
        #endregion

        private void timerClose_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
