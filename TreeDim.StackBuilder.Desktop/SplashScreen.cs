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
    /// <summary>
    /// Splash screen form
    /// </summary>
    public partial class SplashScreen : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
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
        /// <summary>
        /// retrieves assembly version
        /// </summary>
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        /// <summary>
        ///  set / get time interval after which the splash screen will close
        /// </summary>
        public int TimerInterval
        {
            set { timerClose.Interval = value;  }
            get { return timerClose.Interval; }
        }
        #endregion

        /// <summary>
        /// handles timer click and closes splashscreen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerClose_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
