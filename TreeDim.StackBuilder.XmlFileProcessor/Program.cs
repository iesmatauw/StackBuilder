#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;

// logging
using log4net;
using log4net.Config;

// stackbuilder
using TreeDim.StackBuilder.Basics;

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

                string inputFilePath = options.i;
                // validating
                if (Settings.Default.ValidateInputFile && !Validate(inputFilePath))
                {
                    _log.Error(string.Format("File {0} failed to Validate", inputFilePath));
                    return -1;
                }

               _log.Info(string.Format("Processing input file {0}", inputFilePath));

            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                return -1;
            }
            return 0;
        }
        #endregion

        #region Validation
        private static bool Validate(string infile)
        {
            _success = true;
            try
            {
                // build path to schema
                string schemaPath = Settings.Default.XmlSchemaFilePath;
                // build schema set
                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.Add("http://www.treedim.com/StackBuilderSchema.xsd", schemaPath);
                // build reader settings
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = schemas;
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
                // create a validating reader.
                XmlReader vreader = XmlReader.Create(infile, settings);
                // set the validation event handler
                // read and validate the XML data.
                while (vreader.Read()) { }
            }
            catch (XmlException XmlExp)
            {
                _log.Error(XmlExp.Message);
                _success = false;
            }
            catch (XmlSchemaException XmlSchExp)
            {
                _log.Error(XmlSchExp.Message);
                _success = false;
            }
            catch (Exception GenExp)
            {
                _log.Error(GenExp.Message);
                _success = false;
            }
            finally
            {
            }
            return _success;
        }
        private static void ValidationCallback(Object sender, ValidationEventArgs args)
        {
            _log.Error(args.Message);
            _success = false;
        }

        private static bool _success;
        #endregion
    }
    #endregion
}
