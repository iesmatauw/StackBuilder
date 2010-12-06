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

            // 
            MessageFilter oFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(
                                (IMessageFilter)oFilter);

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
            /*
            Control ctr = ctrContext;

            string sHTMLFileName = null;
            while (ctr != null)
            {
                // Get the first control in the parent chain

                // with the IContextHelp interface.

                IContextHelp help = GetIContextHelpControl(ctr);
                // If there isn't one, display the default help for the application.

                if (help == null)
                    break;
                // Check to see if it has a ContextHelpID value.

                if (help.ContextHelpID != null)
                {
                    // Check to see if the ID has a mapped HTML file name.

                    sHTMLFileName = LookupHTMLHelpPathFromID(help.ContextHelpID);
                    if (sHTMLFileName != null && ShowHelp(ctrContext, sHTMLFileName))
                        return;
                }
                // Get the parent control and repeat.

                ctr = ((Control)help).Parent;
            }
            // Show the default topic.

            ShowHelp(ctrContext, "");
             */ 
        }

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