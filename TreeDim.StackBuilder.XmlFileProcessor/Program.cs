#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Drawing;

// logging
using log4net;
using log4net.Config;

// sharp3D
using Sharp3D.Math.Core;

// stackbuilder
using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;

// plossum command line
using Plossum;
using Plossum.CommandLine;

#endregion

namespace TreeDim.StackBuilder.XmlFileProcessor
{
    #region Command line manager : class Options
    [CommandLineManager(ApplicationName = "TreeDim.StackBuilder.XmlFileProcessor.exe", Copyright = "Copyright (c) TreeDim")]
    class Options
    {
        [CommandLineOption(Description = "Displays this help text")]
        public bool Help = false;

        [CommandLineOption(Description = "Specifies the input file (.xml)", MinOccurs = 1)]
        public string i
        {
            get { return inputFilePath; }
            set
            {
                inputFilePath = value;
                if (String.IsNullOrEmpty(value))
                    throw new InvalidOptionValueException("The input file path must not be empty", false);
                if (!File.Exists(value))
                {
                    if (Path.GetPathRoot(value) == "\\")
                        inputFilePath = "\\" + value;
                    if (!File.Exists(inputFilePath))
                        throw new InvalidOptionValueException(string.Format("The file {0} could not be found.", value), false);
                }
            }
        }
        private string inputFilePath;
    }
    #endregion

    #region Program
    class Program
    {
        #region Constants
        private static int LINE_WIDTH = 78;
        private static ILog _log;
        #endregion

        #region Main
        static int Main(string[] args)
        {
            _log = LogManager.GetLogger(typeof(Program));
            XmlConfigurator.Configure();

            try
            {
                #region Command line parsing
                Options options = new Options();
                CommandLineParser parser = new CommandLineParser(options);
                parser.Parse();

                Console.WriteLine(parser.UsageInfo.GetHeaderAsString(LINE_WIDTH));
                if (options.Help)
                {
                    _log.Info(parser.UsageInfo.GetOptionsAsString(LINE_WIDTH));
                    return 0;
                }
                else if (parser.HasErrors)
                {
                    _log.Error(parser.UsageInfo.GetErrorsAsString(LINE_WIDTH));
                    return -1;
                }
                #endregion

                #region Running File processor
                XmlFileLoader fileLoader = new XmlFileLoader(options.i);
                fileLoader.Process();
                #endregion
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                return -1;
            }
            return 0;
        }
        #endregion
    }
    #endregion
 
}
