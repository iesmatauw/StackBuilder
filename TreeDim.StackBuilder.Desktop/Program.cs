#region Using directives
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using log4net;
using log4net.Config;
using System.Diagnostics;


using ExceptionReporting;
#endregion

#region File association
using Utilities;
using System.Threading;
using System.Reflection;
using System.IO;
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

            // 
            MessageFilter oFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(
                                (IMessageFilter)oFilter);

            // note: arguments are handled within FormMain constructor
            // using Environment.GetCommandLineArgs()
            try
            {
				// force CultureToUse culture if specified in config file
                string specifiedCulture = TreeDim.StackBuilder.Desktop.Properties.Settings.Default.CultureToUse;
                if (!string.IsNullOrEmpty(specifiedCulture))
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(specifiedCulture);
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(specifiedCulture);
                }

                // get current culture
                _log.Info(string.Format("Starting {0} with user culture {1}", Application.ProductName, Thread.CurrentThread.CurrentUICulture));

                // file association
                RegisterFileType();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

                Application.Run(new FormMain());

                _log.Info("Closing " + Application.ProductName);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                Program.ReportException("Uncaught exception", ex);
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Program.ReportException("Uncaught exception", e.Exception);
        }
        #endregion

        #region Exception reporting
        /// <summary>
        /// Report an exception + custom message
        /// </summary>
        public static void ReportException(string customMessage, Exception exception)
        {
            ExceptionReporter reporter = new ExceptionReporter();
            reporter.ReadConfig();
            reporter.Show(customMessage, exception);
        }
        /// <summary>
        /// Report an exception
        /// </summary>
        public static void ReportException(Exception exception)
        { 
            ExceptionReporter reporter = new ExceptionReporter();
            reporter.ReadConfig();
            reporter.Show(exception);        
        }
        #endregion

        #region Constextual help
        internal class MessageFilter : IMessageFilter
        {
            #region IMessageFilter Members
            bool IMessageFilter.PreFilterMessage(ref Message m)
            {
                // Use a switch so we can trap other messages in the future
                switch (m.Msg)
                {
                    case 0x100: // WM_KEYDOWN

                        if ((int)m.WParam == (int)Keys.F1)
                        {
                            HelpUtility.ProcessHelpRequest(Control.FromHandle(m.HWnd));
                            return true;
                        }
                        break;
                }
                return false;
            }
            #endregion
        }

        public static class HelpUtility
        {
            public static void ProcessHelpRequest(Control ctrContext)
            {
                ShowContextHelp(ctrContext);
            }
        }

        // Process a request to display help
        // for the context specified by ctrContext.
        public static void ShowContextHelp(Control ctrContext)
        {
            int i=0;
            Control ctr = ctrContext;
            Form form = null;
            while (i < 100 && null == form)
            {
                ctr = ctr.Parent;
                form = ctr as Form;
                ++i;
            }
            if (null != form)
            {
                string sHTMLHelp = form.GetType().Name + ".html";
                Help.ShowHelp(ctrContext
                    , Path.ChangeExtension(Application.ExecutablePath, "chm")
                    , HelpNavigator.Topic
                    , sHTMLHelp);
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