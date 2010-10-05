#region Using directives
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using log4net;
using log4net.Config;
using System.Diagnostics;
#endregion

#region File association
using Utilities;
using System.Threading;
using System.Reflection;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    static class Program
    {
        #region Private members
        static readonly ILog _log = LogManager.GetLogger(typeof(Program));
        #endregion

        #region Main
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // set up a simple logging configuration
            XmlConfigurator.Configure();
            if (!LogManager.GetRepository().Configured)
                Debug.Fail("Logging not configured!\n Press ignore to continue");

            // note: arguments are handled within FormMain constructor
            // using Environment.GetCommandLineArgs()
            try
            {
                // get 
                _log.Info(string.Format("Starting {0} with user culture {1}", Application.ProductName, Thread.CurrentThread.CurrentUICulture));

                // file association
                RegisterFileType();

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
        #endregion

        #region File association
        private static void RegisterFileType()
        {
            try
            {
                FileAssociation FA = new FileAssociation();
                FA.Extension = "stb";
                FA.ContentType = "application/xml";
                FA.FullName = "TreeDim StackBuilder Data Files";
                FA.ProperName = "StackBuilder File";
                FA.AddCommand("open", Assembly.GetExecutingAssembly().Location + " \"%1\"");
                FA.IconPath = Assembly.GetExecutingAssembly().Location;
                FA.IconIndex = 0;
                FA.Create();
            }
            catch (Exception ex)
            {
                _log.Error(string.Format("File association failed! Exception : {0}", ex.Message));
            }
        }
        #endregion
    }
}