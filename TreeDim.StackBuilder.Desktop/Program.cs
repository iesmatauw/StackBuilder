#region Using directives
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net;
using log4net.Config;

using System.Diagnostics;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    static class Program
    {
        #region Private members
        static readonly ILog _log = LogManager.GetLogger(typeof(Program));
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // set up a simple configuration
            XmlConfigurator.Configure();
            if (!LogManager.GetRepository().Configured)
                Debug.Fail("Logging not configured!\n Press ignore to continue");

            try
            {
                _log.Info("Starting " + Application.ProductName);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());

                _log.Info("Closing " + Application.ProductName);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
    }
}