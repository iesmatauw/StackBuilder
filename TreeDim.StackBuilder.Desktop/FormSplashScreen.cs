#region Using directives
using System;
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
    public partial class FormSplashScreen : Form
    {
        #region Data members
        private Form _parentForm;
        private bool _transparent = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FormSplashScreen(Form parentForm)
        {
            // save parent form
            _parentForm = parentForm;

            InitializeComponent();

            // make lower right pixel color transparent
            Bitmap b = new Bitmap(this.BackgroundImage);
            if (Transparent)
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
        /// <summary>
        /// set / get transparency
        /// </summary>
        public bool Transparent
        {
            get { return _transparent; }
            set { _transparent = value; }
        }
        #endregion

        /// <summary>
        /// handles timer click and closes splashscreen
        /// </summary>
        private void timerClose_Tick(object sender, EventArgs e)
        {
            Close();
            if (null != _parentForm)
                _parentForm.BringToFront();
        }
    }
}
