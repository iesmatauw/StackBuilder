#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.IO;

using System.Drawing;

using System.Diagnostics;
using System.ComponentModel;

using log4net;

using Sharp3D.Math.Core;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;
#endregion

namespace TreeDim.StackBuilder.Reporting
{
    /// <summary>
    /// class used to encapsulate an analysis and a solution
    /// </summary>
    public class ReportData
    {
        #region Data members
        private PalletAnalysis _palletAnalysis;
        private SelSolution _selSolution;
        private CaseAnalysis _caseAnalysis;
        private SelCaseSolution _selCaseSolution;

        private PalletSolution _palletSolution;
        #endregion

        #region Constructors
        public ReportData(PalletAnalysis palletAnalysis, SelSolution selSolution)
        {
            _palletAnalysis = palletAnalysis;
            _selSolution = selSolution;
        }
        public ReportData(CaseAnalysis caseAnalysis, SelCaseSolution selCaseSolution)
        {
            _caseAnalysis = caseAnalysis;
            _selCaseSolution = selCaseSolution;
        }
        public ReportData(PalletAnalysis palletAnalysis, SelSolution selSolution, CaseAnalysis caseAnalysis, SelCaseSolution selCaseSolution)
        {
            _palletAnalysis = palletAnalysis;
            _selSolution = selSolution;
            _caseAnalysis = caseAnalysis;
            _selCaseSolution = selCaseSolution;
        }
        #endregion

        #region Public accessors
        public Document Document
        {
            get
            {
                if (null != _palletAnalysis)
                    return _palletAnalysis.ParentDocument;
                if (null != _caseAnalysis)
                    return _caseAnalysis.ParentDocument;
                return null;
            }
        }

        public string Title
        {
            get
            {
                if (null != _selSolution)
                    return _selSolution.Name;
                else if (null != _selCaseSolution)
                    return _selCaseSolution.Name;
                return null;
            }
        }



        public PalletAnalysis PalletAnalysis
        {
            get
            {
                if (null != _palletAnalysis)
                    return _palletAnalysis;
                else if (null != _caseAnalysis)
                    return PalletSolution.Analysis;
                else
                    return null;
            }
        }

        public SelSolution SelSolution
        {
            get
            {
                if (null != _palletAnalysis)
                    return _selSolution;
                else if (null != _caseAnalysis)
                    return PalletAnalysis.GetSelSolutionBySolutionIndex(0);
                return null;
            }
        }

        public SelCaseSolution SelCaseSolution
        {   get { return _selCaseSolution; } }

        public CaseAnalysis CaseAnalysis
        { get { return _caseAnalysis; } }

        public bool IsCaseAnalysis
        { get { return (null != _caseAnalysis) && (null != _selCaseSolution); } }
        public bool IsPalletAnalysis
        { get { return (null != _palletAnalysis) && (null != _selSolution);} }
        public bool IsValid
        { get { return IsCaseAnalysis ^ IsPalletAnalysis; } }
        public double ActualCaseWeight
        {
            get
            {
                if (IsPalletAnalysis)
                    return _palletAnalysis.BProperties.Weight;
                else if (IsCaseAnalysis)
                    return _selCaseSolution.Solution.CaseWeight;
                else
                    return 0.0; // invalid
            }
        }
        public double ActualPalletWeight
        {
            get
            {
                if (IsPalletAnalysis)
                    return _selSolution.Solution.PalletWeight;
                else if (IsCaseAnalysis)
                    return _selCaseSolution.Solution.PalletWeight;
                else
                    return 0.0; // invalid
            }
        }
        #endregion

        #region IItemListener related methods
        public void AddListener(IItemListener listener)
        {
            if (null != _selSolution)
                _selSolution.AddListener(listener);
            else if (null != _selCaseSolution)
                _selCaseSolution.AddListener(listener);
        }

        public void RemoveListener(IItemListener listener)
        {
            if (null != _selSolution)
                _selSolution.RemoveListener(listener);
            else if (null != _selCaseSolution)
                _selCaseSolution.RemoveListener(listener);
        }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (obj is ReportData)
            {
                ReportData reportObject = obj as ReportData;
                return _selSolution == reportObject._selSolution
                    && _selCaseSolution == reportObject._selCaseSolution;
            }
            return false;
        }
        #endregion

        #region PalletSolution
        public PalletSolution PalletSolution
        {
            get
            {
                // case analysis
                if (null != _caseAnalysis)
                {
                    if (null == _palletSolution)
                        _palletSolution = _selCaseSolution.Solution.AttachedPalletSolution;
                    return _palletSolution;
                }
                // pallet analysis 
                else if (null != _palletAnalysis)
                    return _selSolution.Solution;
                // error!
                else
                    return null;
            }
        }
        #endregion
    }

    /// <summary>
    /// Generates pallet analyses reports
    /// </summary>
    abstract public class Reporter
    {
        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(ReporterMSWord));
        protected static bool _validateAgainstSchema = false;
        #endregion

        #region Abstract members
        abstract public bool RetrieveXsltTemplate(string reportTemplatePath, ref string xsltTemplateFilePath);
        abstract public bool WriteNamespace { get; }
        abstract public bool WriteImageFiles { get; }
        #endregion

        #region Private properties
        private string ImageDirectory
        {
            get
            {
                return Path.Combine(Path.GetTempPath() , @"Images\");
            }
        }
        #endregion

        #region Report generation
        public void BuildAnalysisReport(ReportData inputData, string reportTemplatePath, string outputFilePath)
        {
            // verify if inputData is a valid entry
            if (!inputData.IsValid)
                throw new Exception("Reporter.BuildAnalysisReport(): ReportData argument is invalid!");
            // create directory if needed
            if (WriteImageFiles && !Directory.Exists(ImageDirectory))
                Directory.CreateDirectory(ImageDirectory); 
            // create xml data file + XmlTextReader
            string xmlFilePath = Path.ChangeExtension(System.IO.Path.GetTempFileName(), "xml");
            CreateAnalysisDataFile(inputData, xmlFilePath, WriteNamespace);
            XmlTextReader xmlData = new XmlTextReader(new FileStream(xmlFilePath, FileMode.Open, FileAccess.Read));
            // validate against schema
            // note xml file validation against xml schema produces a large number of errors
            // For the moment, I can not remove all errors
            if (_validateAgainstSchema)
                Reporter.ValidateXmlDocument(xmlData, Path.Combine(reportTemplatePath, "ReportSchema.xsd"));
            // build xslt file
            string xsltTemplateFilePath = string.Empty;
            if (!RetrieveXsltTemplate(reportTemplatePath, ref xsltTemplateFilePath))
                throw new Exception(string.Format("Failed to build/retrieve xslt template: {0}",reportTemplatePath));
            // check availibility of files
            if (!File.Exists(xsltTemplateFilePath))
                throw new Exception(string.Format("Report template path ({0}) is invalid", xsltTemplateFilePath));
            // load generated xslt
            XmlTextReader xsltReader = new XmlTextReader(new FileStream(xsltTemplateFilePath, FileMode.Open, FileAccess.Read));
            // generate word document
            byte[] wordDoc = GetReport(xmlData, xsltReader);
            // write resulting array to HDD, show process information
            using (FileStream fs = new FileStream(outputFilePath, FileMode.Create))
                fs.Write(wordDoc, 0, wordDoc.Length);
        }
        #endregion

        #region Xml transformation using xsl template
        /// <summary>
        /// Creates document from XML using XSLT
        /// </summary>
        /// <param name="xmlData">Report data as XML</param>
        /// <param name="xsltReader">XSLT transformation as Stream, used for document creation</param>
        /// <returns>Resulting document as byte[]</returns>
        private static byte[] GetReport(XmlReader xmlData, XmlReader xsltReader)
        {
            // Initialize needed variables
            XslCompiledTransform xslt = new XslCompiledTransform();
            XsltArgumentList args = new XsltArgumentList();

            using (MemoryStream swResult = new MemoryStream())
            {
                // Load XSLT to reader and perform transformation
                xslt.Load(xsltReader);
                xslt.Transform(xmlData, args, swResult);

                return swResult.ToArray();
            }
        }
        #endregion

        #region Helpers
        private static void AppendElementValue(XmlDocument xmlDoc, XmlElement parent, string eltName, double eltValue)
        {
            XmlElement createdElement = xmlDoc.CreateElement(eltName, xmlDoc.DocumentElement.NamespaceURI);
            createdElement.InnerText = string.Format("{0}", eltValue);
            parent.AppendChild(createdElement);
        }
        private static void AppendElementValue(XmlDocument xmlDoc, XmlElement parent, string eltName, int eltValue)
        {
            XmlElement createdElement = xmlDoc.CreateElement(eltName, xmlDoc.DocumentElement.NamespaceURI);
            createdElement.InnerText = string.Format("{0}", eltValue);
            parent.AppendChild(createdElement);
        }
        private static void AppendElementValue(XmlDocument xmlDoc, XmlElement parent, string eltName, string eltValue)
        {
            XmlElement createdElement = xmlDoc.CreateElement(eltName, xmlDoc.DocumentElement.NamespaceURI);
            createdElement.InnerText = string.Format("{0}", eltValue);
            parent.AppendChild(createdElement);
        }

        private void SaveImageAs(Bitmap bmp, string fileName)
        {
            if (!WriteImageFiles)
                return;
            try
            {
                bmp.Save(Path.Combine(ImageDirectory, fileName), System.Drawing.Imaging.ImageFormat.Gif);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }

        }
        #endregion

        #region Static methods to build xml report
        public void CreateAnalysisDataFile(ReportData inputData, string xmlDataFilePath, bool writeNamespace)
        {
            // instantiate XmlDocument
            XmlDocument xmlDoc = new XmlDocument();
            // set declaration
            XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "no");
            xmlDoc.AppendChild(declaration);
            // report (root) element
            XmlElement elemDocument;
            if (writeNamespace)
                elemDocument = xmlDoc.CreateElement("report", "http://treeDim/StackBuilder/ReportSchema.xsd");
            else
                elemDocument = xmlDoc.CreateElement("report");
            xmlDoc.AppendChild(elemDocument);

            string ns = xmlDoc.DocumentElement.NamespaceURI;
            Document doc = inputData.Document;
            // name element
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = doc.Name;
            elemDocument.AppendChild(elemName);
            // description element
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = doc.Description;
            elemDocument.AppendChild(elemDescription);
            // author element
            XmlElement elemAuthor = xmlDoc.CreateElement("author", ns);
            elemAuthor.InnerText = doc.Author;
            elemDocument.AppendChild(elemAuthor);
            // date of creation element
            XmlElement elemDateOfCreation = xmlDoc.CreateElement("dateOfCreation", ns);
            elemDateOfCreation.InnerText = doc.DateOfCreation.ToString();
            elemDocument.AppendChild(elemDateOfCreation);

            // case analysis
            AppendCaseAnalysisElement(inputData, elemDocument, xmlDoc);
            // palletAnalysis
            AppendPalletAnalysisElement(inputData, elemDocument, xmlDoc);
            // truckAnalysis
            AppendTruckAnalysisElement(inputData, elemDocument, xmlDoc);
            // ectAnalysis
            AppendEctAnalysisElement(inputData, elemDocument, xmlDoc);

            // finally save xml document
            _log.Debug(string.Format("Generating xml data file {0}", xmlDataFilePath));
            xmlDoc.Save(xmlDataFilePath);
        }


        private void AppendPalletAnalysisElement(ReportData inputData, XmlElement elemDocument, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;

            PalletAnalysis analysis = inputData.PalletAnalysis;
            SelSolution selSolution = inputData.SelSolution;

            // palletAnalysis
            XmlElement elemPalletAnalysis = xmlDoc.CreateElement("palletAnalysis", ns);
            elemDocument.AppendChild(elemPalletAnalysis);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = analysis.Name;
            elemPalletAnalysis.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = analysis.Description;
            elemPalletAnalysis.AppendChild(elemDescription);
            // pallet
            AppendPalletElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            // case
            if (analysis.BProperties is CaseOfBoxesProperties)
            {
                AppendInsideBoxElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
                AppendCaseOfBoxesElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            }
            else if (analysis.BProperties is BoxProperties && inputData.IsPalletAnalysis)
                AppendCaseElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            else if (analysis.BProperties is BundleProperties)
                AppendBundleElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            // interlayer
            AppendInterlayerElement(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            // constraintSet
            AppendConstraintSet(analysis, selSolution.Solution, elemPalletAnalysis, xmlDoc);
            // solution
            AppendSolutionElement(inputData, elemPalletAnalysis, xmlDoc);
        }

        private void AppendPalletElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get PalletProperties
            PalletProperties palletProp = analysis.PalletProperties;
            if (null == palletProp) return;
            // pallet
            XmlElement elemPallet = xmlDoc.CreateElement("pallet", ns);
            elemPalletAnalysis.AppendChild(elemPallet);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = analysis.PalletProperties.Name;
            elemPallet.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = analysis.PalletProperties.Description;
            elemPallet.AppendChild(elemDescription);
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", palletProp.Length);
            elemPallet.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", palletProp.Width);
            elemPallet.AppendChild(elemWidth);
            // height
            XmlElement elemHeight = xmlDoc.CreateElement("height", ns);
            elemHeight.InnerText = string.Format("{0:F}", palletProp.Height);
            elemPallet.AppendChild(elemHeight);
            // weight
            XmlElement elemWeight = xmlDoc.CreateElement("weight", ns);
            elemWeight.InnerText = string.Format("{0:F}", palletProp.Weight);
            elemPallet.AppendChild(elemWeight);
            // admissibleLoad
            XmlElement elemLoad = xmlDoc.CreateElement("admissibleLoad", ns);
            elemLoad.InnerText = string.Format("{0:F}", palletProp.AdmissibleLoadWeight);
            elemPallet.AppendChild(elemLoad);
            // type
            XmlElement elemType = xmlDoc.CreateElement("type", ns);
            elemType.InnerText = palletProp.TypeName;
            elemPallet.AppendChild(elemType);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(512, 512));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Pallet pallet = new Pallet(palletProp);
            pallet.Draw(graphics, Transform3D.Identity);
            graphics.AddDimensions(new DimensionCube(palletProp.Length, palletProp.Width, palletProp.Height));
            graphics.Flush();
            // ---
            // view_pallet_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_pallet_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemPallet.AppendChild(elemImage);
            // save image
            SaveImageAs(graphics.Bitmap, "view_pallet_iso.gif");
        }

        private void AppendCaseElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get BoxProperties
            BoxProperties boxProp = analysis.BProperties as BoxProperties;
            if (null == boxProp) return;
            // case
            XmlElement elemCase = xmlDoc.CreateElement("case", ns);
            elemPalletAnalysis.AppendChild(elemCase);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = boxProp.Name;
            elemCase.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = boxProp.Description;
            elemCase.AppendChild(elemDescription);
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", boxProp.Length);
            elemCase.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", boxProp.Width);
            elemCase.AppendChild(elemWidth);
            // height
            XmlElement elemHeight = xmlDoc.CreateElement("height", ns);
            elemHeight.InnerText = string.Format("{0:F}", boxProp.Height);
            elemCase.AppendChild(elemHeight);
            // weight
            XmlElement elemWeight = xmlDoc.CreateElement("weight", ns);
            elemWeight.InnerText = string.Format("{0:F}", boxProp.Weight);
            elemCase.AppendChild(elemWeight);
            // admissible load
            XmlElement elemAdmissibleLoad = xmlDoc.CreateElement("admissibleLoadOnTop", ns);
            elemAdmissibleLoad.InnerText = string.Format("{0:F}", 0.0);
            elemCase.AppendChild(elemAdmissibleLoad);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Box box = new Box(0, boxProp);
            graphics.AddBox(box);
            graphics.AddDimensions(new DimensionCube(box.Length, box.Width, box.Height));
            graphics.Flush();
            // ---
            // view_case_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_case_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemCase.AppendChild(elemImage);
            // save image
            SaveImageAs(graphics.Bitmap, "view_case_iso.gif");
        }

        private void AppendBundleElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get BundleProperties
            BundleProperties bundleProp = analysis.BProperties as BundleProperties;
            if (null == bundleProp) return;
            // bundle
            XmlElement elemBundle = xmlDoc.CreateElement("bundle", ns);
            elemPalletAnalysis.AppendChild(elemBundle);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = bundleProp.Name;
            elemBundle.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = bundleProp.Description;
            elemBundle.AppendChild(elemDescription);
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", bundleProp.Length);
            elemBundle.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", bundleProp.Width);
            elemBundle.AppendChild(elemWidth);
            // numberOfFlats
            XmlElement elemNumber = xmlDoc.CreateElement("numberOfFlats", ns);
            elemNumber.InnerText = string.Format("{0}", bundleProp.NoFlats);
            elemBundle.AppendChild(elemNumber);
            // unitThickness
            XmlElement elemUnitThickness = xmlDoc.CreateElement("unitThickness", ns);
            elemUnitThickness.InnerText = string.Format("{0:F}", bundleProp.UnitThickness);
            elemBundle.AppendChild(elemUnitThickness);
            // unitWeight
            XmlElement elemUnitWeight = xmlDoc.CreateElement("unitWeight", ns);
            elemUnitWeight.InnerText = string.Format("{0:F}", bundleProp.UnitWeight);
            elemBundle.AppendChild(elemUnitWeight);
            // totalThickness
            XmlElement elemTotalThickness = xmlDoc.CreateElement("totalThickness", ns);
            elemTotalThickness.InnerText = string.Format("{0:F}", bundleProp.UnitThickness * bundleProp.NoFlats);
            elemBundle.AppendChild(elemTotalThickness);
            // totalWeight
            XmlElement elemTotalWeight = xmlDoc.CreateElement("totalWeight", ns);
            elemTotalWeight.InnerText = string.Format("{0:F}", bundleProp.UnitWeight * bundleProp.NoFlats);
            elemBundle.AppendChild(elemTotalWeight);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Box box = new Box(0, bundleProp);
            graphics.AddBox(box);
            graphics.AddDimensions(new DimensionCube(bundleProp.Length, bundleProp.Width, bundleProp.Height));
            graphics.Flush();
            // ---
            // view_bundle_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_bundle_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemBundle.AppendChild(elemImage);
            // save images ?
            SaveImageAs(graphics.Bitmap, "view_bundle_iso.gif");
        }

        private void AppendConstraintSet(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            PalletConstraintSet cs = analysis.ConstraintSet;
            // solution
            XmlElement elemConstraintSet = xmlDoc.CreateElement("constraintSet", ns);
            elemPalletAnalysis.AppendChild(elemConstraintSet);
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangX", cs.OverhangX);
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangY", cs.OverhangY);
            // allowedPatterns
            XmlElement elemAllowedPatterns = xmlDoc.CreateElement("allowedPatterns", ns);
            elemAllowedPatterns.InnerText = cs.AllowedPatternString;
            elemConstraintSet.AppendChild(elemAllowedPatterns);
            // allowedBoxAxis
            XmlElement elemAllowedBoxAxis = xmlDoc.CreateElement("allowedOrthoAxis", ns);
            elemAllowedBoxAxis.InnerText = cs.AllowOrthoAxisString;
            elemConstraintSet.AppendChild(elemAllowedBoxAxis);
            // allowAlternateLayers
            XmlElement elemAllowAlternateLayers = xmlDoc.CreateElement("allowAlternateLayers", ns);
            elemAllowAlternateLayers.InnerText = cs.AllowAlternateLayers.ToString();
            elemConstraintSet.AppendChild(elemAllowAlternateLayers);
            // allowAlignedLayers
            XmlElement elemAllowAlignedLayers = xmlDoc.CreateElement("allowAlignedLayers", ns);
            elemAllowAlignedLayers.InnerText = cs.AllowAlignedLayers.ToString();
            elemConstraintSet.AppendChild(elemAllowAlignedLayers);
            // interlayerPeriod
            if (cs.HasInterlayer)
            {
                XmlElement elemInterlayerPeriodGroup = xmlDoc.CreateElement("interlayerPeriodGroup", ns);
                elemConstraintSet.AppendChild(elemInterlayerPeriodGroup);
                XmlElement elemInterlayerPeriod = xmlDoc.CreateElement("interlayerPeriod", ns);
                elemInterlayerPeriod.InnerText = string.Format("{0}", cs.InterlayerPeriod);
                elemInterlayerPeriodGroup.AppendChild(elemInterlayerPeriod);
            }
            // stopCriterion
            if (cs.UseMaximumHeight)
            {
                XmlElement maximumPalletHeightGroup = xmlDoc.CreateElement("maximumPalletHeightGroup", ns);
                elemConstraintSet.AppendChild(maximumPalletHeightGroup);
                XmlElement maximumPalletHeight = xmlDoc.CreateElement("maximumPalletHeight", ns);
                maximumPalletHeight.InnerText = string.Format("{0:F}", cs.MaximumHeight);
                maximumPalletHeightGroup.AppendChild(maximumPalletHeight);
            }
            if (cs.UseMaximumNumberOfCases)
            {
                XmlElement maximumNumberOfItemsGroup = xmlDoc.CreateElement("maximumNumberOfItemsGroup", ns);
                elemConstraintSet.AppendChild(maximumNumberOfItemsGroup);
                XmlElement maximumNumberOfItems = xmlDoc.CreateElement("maximumNumberOfItems", ns);
                maximumNumberOfItems.InnerText = string.Format("{0}", cs.MaximumNumberOfItems);
                maximumNumberOfItemsGroup.AppendChild(maximumNumberOfItems);
            }
            if (cs.UseMaximumPalletWeight)
            {
                XmlElement maximumPalletWeightGroup = xmlDoc.CreateElement("maximumPalletWeightGroup", ns);
                elemConstraintSet.AppendChild(maximumPalletWeightGroup);
                XmlElement maximumPalletWeight = xmlDoc.CreateElement("maximumPalletWeight", ns);
                maximumPalletWeight.InnerText = string.Format("{0:F}", cs.MaximumPalletWeight);
                maximumPalletWeightGroup.AppendChild(maximumPalletWeight);
            }
            if (cs.UseMaximumWeightOnBox)
            {
                XmlElement maximumWeightOnBoxGroup = xmlDoc.CreateElement("maximumWeightOnBoxGroup", ns);
                elemConstraintSet.AppendChild(maximumWeightOnBoxGroup);
                XmlElement admissibleLoadOnTop = xmlDoc.CreateElement("admissibleLoadOnTop", ns);
                admissibleLoadOnTop.InnerText = string.Format("{0:F}", cs.MaximumWeightOnBox);
                maximumWeightOnBoxGroup.AppendChild(admissibleLoadOnTop);
            }
        }
        private void AppendInsideBoxElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get caseOfBoxProperties
            CaseOfBoxesProperties caseOfBoxes = analysis.BProperties as CaseOfBoxesProperties;
            // get box properties
            BoxProperties boxProperties = caseOfBoxes.InsideBoxProperties;
            // elemBoxes
            XmlElement elemBox = xmlDoc.CreateElement("box", ns);
            elemPalletAnalysis.AppendChild(elemBox);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = boxProperties.Name;
            elemBox.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = boxProperties.Description;
            elemBox.AppendChild(elemDescription);
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", boxProperties.Length);
            elemBox.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", boxProperties.Width);
            elemBox.AppendChild(elemWidth);
            // height
            XmlElement elemHeight = xmlDoc.CreateElement("height", ns);
            elemHeight.InnerText = string.Format("{0:F}", boxProperties.Height);
            elemBox.AppendChild(elemHeight);
            // weight
            XmlElement elemWeight = xmlDoc.CreateElement("weight", ns);
            elemWeight.InnerText = string.Format("{0:F}", boxProperties.Weight);
            elemBox.AppendChild(elemWeight);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Box box = new Box(0, boxProperties);
            graphics.AddBox(box);
            graphics.AddDimensions(new DimensionCube(box.Length, box.Width, box.Height));
            graphics.Flush();
            // ---
            // view_box_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_box_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemBox.AppendChild(elemImage);
            // save image ?
            SaveImageAs(graphics.Bitmap, "view_box_iso.gif");
        }
        private void AppendCaseOfBoxesElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get CaseOfBoxProperties
            CaseOfBoxesProperties caseOfBoxes = analysis.BProperties as CaseOfBoxesProperties;
            if (null == caseOfBoxes) return;
            // elemCaseOfBoxes
            XmlElement elemCaseOfBoxes = xmlDoc.CreateElement("caseOfBoxes", ns);
            elemPalletAnalysis.AppendChild(elemCaseOfBoxes);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = caseOfBoxes.Name;
            elemCaseOfBoxes.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = caseOfBoxes.Description;
            elemCaseOfBoxes.AppendChild(elemDescription);
            // length
            XmlElement elemNoX = xmlDoc.CreateElement("noX", ns);
            elemNoX.InnerText = string.Format("{0}", caseOfBoxes.CaseDefinition.Arrangement._iLength);
            elemCaseOfBoxes.AppendChild(elemNoX);
            // width
            XmlElement elemNoY = xmlDoc.CreateElement("noY", ns);
            elemNoY.InnerText = string.Format("{0}", caseOfBoxes.CaseDefinition.Arrangement._iWidth);
            elemCaseOfBoxes.AppendChild(elemNoY);
            // height
            XmlElement elemNoZ = xmlDoc.CreateElement("noZ", ns);
            elemNoZ.InnerText = string.Format("{0}", caseOfBoxes.CaseDefinition.Arrangement._iHeight);
            elemCaseOfBoxes.AppendChild(elemNoZ);
            // number of boxes
            XmlElement elemNoBoxes = xmlDoc.CreateElement("numberOfBoxes", ns);
            elemNoBoxes.InnerText = string.Format("{0}", caseOfBoxes.NumberOfBoxes);
            elemCaseOfBoxes.AppendChild(elemNoBoxes);
            // dim0
            XmlElement eltDim0 = xmlDoc.CreateElement("dim0", ns);
            eltDim0.InnerText = string.Format("{0}", caseOfBoxes.CaseDefinition.Dim0);
            elemCaseOfBoxes.AppendChild(eltDim0);
            // dim1
            XmlElement eltDim1 = xmlDoc.CreateElement("dim1", ns);
            eltDim1.InnerText = string.Format("{0}", caseOfBoxes.CaseDefinition.Dim1);
            elemCaseOfBoxes.AppendChild(eltDim1);
            // inner length
            XmlElement eltInnerLength = xmlDoc.CreateElement("innerLength", ns);
            eltInnerLength.InnerText = string.Format("{0}", caseOfBoxes.InsideLength);
            elemCaseOfBoxes.AppendChild(eltInnerLength);
            // inner width
            XmlElement eltInnerWidth = xmlDoc.CreateElement("innerWidth", ns);
            eltInnerWidth.InnerText = string.Format("{0}", caseOfBoxes.InsideWidth);
            elemCaseOfBoxes.AppendChild(eltInnerWidth);
            // inner height
            XmlElement eltInnerHeight = xmlDoc.CreateElement("innerHeight", ns);
            eltInnerHeight.InnerText = string.Format("{0}", caseOfBoxes.InsideHeight);
            elemCaseOfBoxes.AppendChild(eltInnerHeight);
            // inner volume
            XmlElement eltInnerVolume = xmlDoc.CreateElement("innerVolume", ns);
            eltInnerVolume.InnerText = string.Format("{0:F}", caseOfBoxes.InsideVolume * 1.0E-06);
            elemCaseOfBoxes.AppendChild(eltInnerVolume);
            // outer length
            XmlElement eltOuterLength = xmlDoc.CreateElement("outerLength", ns);
            eltOuterLength.InnerText = string.Format("{0:F}", caseOfBoxes.Length);
            elemCaseOfBoxes.AppendChild(eltOuterLength);
            // outer width
            XmlElement eltOuterWidth = xmlDoc.CreateElement("outerWidth", ns);
            eltOuterWidth.InnerText = string.Format("{0:F}", caseOfBoxes.Width);
            elemCaseOfBoxes.AppendChild(eltOuterWidth);
            // outer height
            XmlElement eltOuterHeight = xmlDoc.CreateElement("outerHeight", ns);
            eltOuterHeight.InnerText = string.Format("{0:F}", caseOfBoxes.Height);
            elemCaseOfBoxes.AppendChild(eltOuterHeight);
            // outer volume
            XmlElement eltOuterVolume = xmlDoc.CreateElement("outerVolume", ns);
            eltOuterVolume.InnerText = string.Format("{0:F}", caseOfBoxes.Volume * 1.0E-06);
            elemCaseOfBoxes.AppendChild(eltOuterVolume);
            // empty weight
            XmlElement eltEmptyWeight = xmlDoc.CreateElement("emptyWeight", ns);
            eltEmptyWeight.InnerText = string.Format("{0:F}", caseOfBoxes.Weight);
            elemCaseOfBoxes.AppendChild(eltEmptyWeight);
            // weight
            XmlElement eltWeight = xmlDoc.CreateElement("weight", ns);
            eltWeight.InnerText = string.Format("{0:F}", caseOfBoxes.Weight);
            elemCaseOfBoxes.AppendChild(eltWeight);
            // type converter
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            // view case of boxes iso1
            Graphics3DImage graphics1 = new Graphics3DImage(new Size(256, 256));
            graphics1.CameraPosition = Graphics3D.Corner_0;
            CaseDefinitionViewer viewer = new CaseDefinitionViewer(caseOfBoxes.CaseDefinition, caseOfBoxes.InsideBoxProperties, caseOfBoxes.CaseOptimConstraintSet);
            viewer.CaseProperties = caseOfBoxes;
            viewer.Orientation = sol.FirstCaseOrientation;
            viewer.Draw(graphics1);
            graphics1.Flush();
            // view case of boxes iso2
            Graphics3DImage graphics2 = new Graphics3DImage(new Size(256, 256));
            graphics2.CameraPosition = Graphics3D.Corner_0;
            Box box = new Box(0, caseOfBoxes);
            graphics2.AddBox(box);
            graphics2.AddDimensions(new DimensionCube(caseOfBoxes.Length, caseOfBoxes.Width, caseOfBoxes.Height));
            graphics2.Flush();
            // view_caseOfBoxes_iso1
            XmlElement elemImage1 = xmlDoc.CreateElement("view_caseOfBoxes_iso1", ns);
            elemImage1.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics1.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute1 = xmlDoc.CreateAttribute("style");
            styleAttribute1.Value = string.Format("width:{0}pt;height:{1}pt", graphics1.Bitmap.Width / 3, graphics1.Bitmap.Height / 3);
            elemImage1.Attributes.Append(styleAttribute1);
            elemCaseOfBoxes.AppendChild(elemImage1);
            // save image
            SaveImageAs(graphics1.Bitmap, "view_caseOfBoxes_iso1.gif");
            // view_caseOfBoxes_iso2
            XmlElement elemImage2 = xmlDoc.CreateElement("view_caseOfBoxes_iso2", ns);
            elemImage2.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics2.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute2 = xmlDoc.CreateAttribute("style");
            styleAttribute2.Value = string.Format("width:{0}pt;height:{1}pt", graphics2.Bitmap.Width / 3, graphics2.Bitmap.Height / 3);
            elemImage2.Attributes.Append(styleAttribute2);
            elemCaseOfBoxes.AppendChild(elemImage2);
            // save image
            SaveImageAs(graphics2.Bitmap, "view_caseOfBoxes_iso2.gif");
        }

        private void AppendInterlayerElement(PalletAnalysis analysis, PalletSolution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get BoxProperties
            InterlayerProperties interlayerProp = analysis.InterlayerProperties;
            if (null == interlayerProp) return;
            // interlayer
            XmlElement elemInterlayer = xmlDoc.CreateElement("interlayer", ns);
            elemPalletAnalysis.AppendChild(elemInterlayer);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = interlayerProp.Name;
            elemInterlayer.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = interlayerProp.Description;
            elemInterlayer.AppendChild(elemDescription);
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", interlayerProp.Length);
            elemInterlayer.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", interlayerProp.Width);
            elemInterlayer.AppendChild(elemWidth);
            // height
            XmlElement elemThickness = xmlDoc.CreateElement("thickness", ns);
            elemThickness.InnerText = string.Format("{0:F}", interlayerProp.Thickness);
            elemInterlayer.AppendChild(elemThickness);
            // weight
            XmlElement elemWeight = xmlDoc.CreateElement("weight", ns);
            elemWeight.InnerText = string.Format("{0:F}", interlayerProp.Weight);
            elemInterlayer.AppendChild(elemWeight);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Box box = new Box(0, interlayerProp);
            graphics.AddBox(box);
            graphics.Flush();
            // ---
            // view_interlayer_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_interlayer_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemInterlayer.AppendChild(elemImage);
            // save image ?
            SaveImageAs(graphics.Bitmap, "view_interlayer_iso.gif");
        }

        private void AppendSolutionElement(ReportData inputData, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;

            SelSolution selSolution = inputData.SelSolution;
            PalletSolution sol = inputData.PalletSolution;

            // solution
            XmlElement elemSolution = xmlDoc.CreateElement("palletSolution", ns);
            elemPalletAnalysis.AppendChild(elemSolution);
            // title
            XmlElement elemTitle = xmlDoc.CreateElement("title", ns);
            elemTitle.InnerText = sol.Title;
            elemSolution.AppendChild(elemTitle);
            // homogeneousLayer
            XmlElement elemHomogeneousLayer = xmlDoc.CreateElement("homogeneousLayer", ns);
            elemHomogeneousLayer.InnerText = sol.HasHomogeneousLayers.ToString();
            elemSolution.AppendChild(elemHomogeneousLayer);
            // efficiency
            XmlElement elemEfficiency = xmlDoc.CreateElement("efficiency", ns);
            elemEfficiency.InnerText = string.Format("{0:F}", sol.Efficiency);
            elemSolution.AppendChild(elemEfficiency);
            // palletWeight
            XmlElement elemPalletWeight = xmlDoc.CreateElement("palletWeight", ns);
            elemPalletWeight.InnerText = string.Format("{0:F}", inputData.ActualPalletWeight);
            elemSolution.AppendChild(elemPalletWeight);
            // palletHeight
            XmlElement elemPalletHeight = xmlDoc.CreateElement("palletHeight", ns);
            elemPalletHeight.InnerText = string.Format("{0:F}", sol.PalletHeight);
            elemSolution.AppendChild(elemPalletHeight);
            // caseCount
            XmlElement elemCaseCount = xmlDoc.CreateElement("caseCount", ns);
            elemCaseCount.InnerText = string.Format("{0}", sol.CaseCount);
            elemSolution.AppendChild(elemCaseCount);
            // if case of boxes, add box count + box efficiency
            if (sol.Analysis.BProperties is CaseOfBoxesProperties)
            {
                CaseOfBoxesProperties caseOfBoxes = sol.Analysis.BProperties as CaseOfBoxesProperties;
                XmlElement elemBoxCount = xmlDoc.CreateElement("boxCount", ns);
                elemBoxCount.InnerText = string.Format("{0:F}", caseOfBoxes.NumberOfBoxes);
                elemSolution.AppendChild(elemBoxCount);
                XmlElement elemBoxEfficiency = xmlDoc.CreateElement("boxEfficiency", ns);
                elemBoxEfficiency.InnerText = string.Format("{0:F}", sol.Efficiency);
            }
            // interlayer count
            if (sol.Analysis.ConstraintSet.HasInterlayer)
            {
                XmlElement elemInterlayerCount = xmlDoc.CreateElement("interlayerCount", ns);
                elemInterlayerCount.InnerText = string.Format("{0}", sol.InterlayerCount);
                elemSolution.AppendChild(elemInterlayerCount);
            }
            // --- layer images
            for (int i = 0; i < (sol.HasHomogeneousLayers ? 1 : 2); ++i)
            {
                XmlElement elemLayer = xmlDoc.CreateElement("layer", ns);
                // layerId
                XmlElement xmlLayerId = xmlDoc.CreateElement("layerId", ns);
                xmlLayerId.InnerText = string.Format("{0}", i + 1);
                elemLayer.AppendChild(xmlLayerId);

                // --- build layer image
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
                // set camera position 
                graphics.CameraPosition = Graphics3D.Top;
                // instantiate solution viewer
                SolutionViewer sv = new SolutionViewer(sol);
                sv.DrawLayers(graphics, true, i /* layer index*/);
                // ---
                // layerImage
                XmlElement elemLayerImage = xmlDoc.CreateElement("layerImage", ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemLayerImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 2, graphics.Bitmap.Height / 2);
                elemLayerImage.Attributes.Append(styleAttribute);
                elemLayer.AppendChild(elemLayerImage);
                // layerBoxCount
                XmlElement elemLayerBoxCount = xmlDoc.CreateElement("layerCaseCount", ns);
                elemLayerBoxCount.InnerText = "0";
                elemLayer.AppendChild(elemLayerBoxCount);

                elemSolution.AppendChild(elemLayer);
                // save image
                SaveImageAs(graphics.Bitmap, string.Format("layerImage{0}.gif", i + 1));
            }
            // --- pallet images
            for (int i = 0; i < 5; ++i)
            {
                // initialize drawing values
                string viewName = string.Empty;
                Vector3D cameraPos = Vector3D.Zero;
                int imageWidth = 256;
                bool showDimensions = false;
                switch (i)
                {
                    case 0:
                        viewName = "view_palletsolution_front"; cameraPos = Graphics3D.Front; imageWidth = 256;
                        break;
                    case 1:
                        viewName = "view_palletsolution_left"; cameraPos = Graphics3D.Left; imageWidth = 256;
                        break;
                    case 2:
                        viewName = "view_palletsolution_right"; cameraPos = Graphics3D.Right; imageWidth = 256;
                        break;
                    case 3:
                        viewName = "view_palletsolution_back"; cameraPos = Graphics3D.Back; imageWidth = 256;
                        break;
                    case 4:
                        viewName = "view_palletsolution_iso"; cameraPos = Graphics3D.Corner_0; imageWidth = 768; showDimensions = true;
                        break;
                    default:
                        break;
                }
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(imageWidth, imageWidth));
                // set camera position 
                graphics.CameraPosition = cameraPos;
                // instantiate solution viewer
                SolutionViewer sv = new SolutionViewer(sol);
                sv.ShowDimensions = showDimensions;
                sv.Draw(graphics);
                // ---
                XmlElement elemImage = xmlDoc.CreateElement(viewName, ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 3, graphics.Bitmap.Height / 3);
                elemImage.Attributes.Append(styleAttribute);
                elemSolution.AppendChild(elemImage);
                // Save image ?
                SaveImageAs(graphics.Bitmap, viewName + ".gif");
            }
        }
        private void AppendTruckAnalysisElement(ReportData inputData, XmlElement elemDocument, XmlDocument xmlDoc)
        {
            PalletAnalysis analysis = inputData.PalletAnalysis;
            SelSolution selSolution = inputData.SelSolution;

            // retrieve truck analysis if any
            if (!selSolution.HasTruckAnalyses) return;  // no truck analysis available -> exit

            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // truckAnalysis
            XmlElement elemTruckAnalysis = xmlDoc.CreateElement("truckAnalysis", ns);
            elemDocument.AppendChild(elemTruckAnalysis);

            TruckAnalysis truckAnalysis = selSolution.TruckAnalyses[0];
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = analysis.Name;
            elemTruckAnalysis.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = analysis.Description;
            elemTruckAnalysis.AppendChild(elemDescription);
            // truck
            AppendTruckElement(truckAnalysis, elemTruckAnalysis, xmlDoc);
            // solution
            AppendTruckSolutionElement(inputData, elemTruckAnalysis, xmlDoc);
        }

        private void AppendEctAnalysisElement(ReportData inputData, XmlElement elemDocument, XmlDocument xmlDoc)
        {
            PalletAnalysis analysis = inputData.PalletAnalysis;
            SelSolution selSolution = inputData.SelSolution;

            // retrieve ect analysis if any
            if (!selSolution.HasECTAnalyses) return;

            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // ectAnalysis
            XmlElement elemEctAnalysis = xmlDoc.CreateElement("ectAnalysis", ns);
            elemDocument.AppendChild(elemEctAnalysis);

            ECTAnalysis ectAnalysis = selSolution.EctAnalyses[0];
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = ectAnalysis.Name;
            elemEctAnalysis.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = ectAnalysis.Description;
            elemEctAnalysis.AppendChild(elemDescription);
            // cardboard
            XmlElement elemCardboard = xmlDoc.CreateElement("cardboard", ns);
            elemEctAnalysis.AppendChild(elemCardboard);
            XmlElement elemCardboardName = xmlDoc.CreateElement("name", ns);
            elemCardboardName.InnerText = ectAnalysis.Cardboard.Name;
            elemCardboard.AppendChild(elemCardboardName);
            XmlElement elemCardboardThickness = xmlDoc.CreateElement("thickness", ns);
            elemCardboardThickness.InnerText = string.Format("{0:0.00}", ectAnalysis.Cardboard.Thickness);
            elemCardboard.AppendChild(elemCardboardThickness);
            XmlElement elemCardboadECT = xmlDoc.CreateElement("ect", ns);
            elemCardboadECT.InnerText = string.Format("{0:0.00}", ectAnalysis.Cardboard.ECT);
            elemCardboard.AppendChild(elemCardboadECT);
            XmlElement elemCardboardStiffnessX = xmlDoc.CreateElement("stiffnessX", ns);
            elemCardboardStiffnessX.InnerText = string.Format("{0:0.00}", ectAnalysis.Cardboard.RigidityDX);
            elemCardboard.AppendChild(elemCardboardStiffnessX);
            XmlElement elemCardboardStiffnessY = xmlDoc.CreateElement("stiffnessY", ns);
            elemCardboardStiffnessY.InnerText = string.Format("{0:0.00}", ectAnalysis.Cardboard.RigidityDY);
            elemCardboard.AppendChild(elemCardboardStiffnessY);
            // case type
            XmlElement elemCaseType = xmlDoc.CreateElement("caseType", ns);
            elemCaseType.InnerText = ectAnalysis.CaseType;
            elemEctAnalysis.AppendChild(elemCaseType);
            // printed surface
            XmlElement elemPrintedSurface = xmlDoc.CreateElement("printedSurface", ns);
            elemPrintedSurface.InnerText = ectAnalysis.PrintSurface;
            elemEctAnalysis.AppendChild(elemPrintedSurface);
            // mc kee formula mode
            XmlElement elemMcKeeFormula = xmlDoc.CreateElement("mcKeeFormulaMode", ns);
            elemMcKeeFormula.InnerText = ectAnalysis.McKeeFormulaText;
            elemEctAnalysis.AppendChild(elemMcKeeFormula);
            // bct_static
            XmlElement elemStaticBCT = xmlDoc.CreateElement("bct_static", ns);
            elemEctAnalysis.AppendChild(elemStaticBCT);
            XmlElement elemStaticValue = xmlDoc.CreateElement("static_value", ns);
            elemStaticValue.InnerText = string.Format("{0:0.00}", ectAnalysis.StaticBCT);
            elemStaticBCT.AppendChild(elemStaticValue);
            // bct_dynamic
            XmlElement elemDynamicBCT = xmlDoc.CreateElement("bct_dynamic", ns);
            elemEctAnalysis.AppendChild(elemDynamicBCT);
            Dictionary<KeyValuePair<string, string>, double> ectDictionary = ectAnalysis.DynamicBCTDictionary;
            foreach (string storageKey in TreeDim.EdgeCrushTest.McKeeFormula.StockCoefDictionary.Keys)
            {
                XmlElement elemBCTStorage = xmlDoc.CreateElement("bct_dynamic_storage", ns);
                elemDynamicBCT.AppendChild(elemBCTStorage);
                // duration
                XmlElement elemStorageDuration = xmlDoc.CreateElement("duration", ns);
                elemStorageDuration.InnerText = storageKey;
                elemBCTStorage.AppendChild(elemStorageDuration);
                // humidity rate -> values
                string[] elementHumidityNames
                    = {
                      "humidity_0_45"
                      , "humidity_46_55"
                      , "humidity_56_65"
                      , "humidity_66_75"
                      , "humidity_76_85"
                      , "humidity_86_100"
                   };
                int indexHumidity = 0;
                foreach (string humidityKey in TreeDim.EdgeCrushTest.McKeeFormula.HumidityCoefDictionary.Keys)
                {
                    XmlElement elemHumidity = xmlDoc.CreateElement(elementHumidityNames[indexHumidity++], ns);
                    elemHumidity.InnerText = string.Format("{0:0.00}", ectDictionary[new KeyValuePair<string, string>(storageKey, humidityKey)]);
                    elemBCTStorage.AppendChild(elemHumidity);
                } 
            }
        }

        private void AppendTruckElement(TruckAnalysis truckAnalysis, XmlElement elemTruckAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get PalletProperties
            TruckProperties truckProp = truckAnalysis.TruckProperties;
            if (null == truckProp) return;
            // create "truck" element
            XmlElement elemTruck = xmlDoc.CreateElement("truck", ns);
            elemTruckAnalysis.AppendChild(elemTruck);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = truckProp.Name;
            elemTruck.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = truckProp.Description;
            elemTruck.AppendChild(elemDescription);
            // length
            XmlElement elemLength = xmlDoc.CreateElement("length", ns);
            elemLength.InnerText = string.Format("{0:F}", truckProp.Length);
            elemTruck.AppendChild(elemLength);
            // width
            XmlElement elemWidth = xmlDoc.CreateElement("width", ns);
            elemWidth.InnerText = string.Format("{0:F}", truckProp.Width);
            elemTruck.AppendChild(elemWidth);
            // height
            XmlElement elemHeight = xmlDoc.CreateElement("height", ns);
            elemHeight.InnerText = string.Format("{0:F}", truckProp.Height);
            elemTruck.AppendChild(elemHeight);
            // admissibleLoad
            XmlElement elemWeight = xmlDoc.CreateElement("admissibleLoad", ns);
            elemWeight.InnerText = string.Format("{0:F}", truckProp.AdmissibleLoadWeight);
            elemTruck.AppendChild(elemWeight);

            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            Truck truck = new Truck(truckProp);
            truck.DrawBegin(graphics);
            truck.DrawEnd(graphics);
            graphics.AddDimensions(new DimensionCube(truckProp.Length, truckProp.Width, truckProp.Height));
            graphics.Flush();
            // ---
            // view_truck_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_truck_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemTruck.AppendChild(elemImage);
            // Save image ?
            SaveImageAs(graphics.Bitmap, "view_truck_iso.gif");
        }
        private void AppendTruckSolutionElement(ReportData inputData, XmlElement elemTruckAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;

            PalletSolution palletSolution = inputData.PalletSolution;
            TruckAnalysis truckAnalysis = inputData.SelSolution.TruckAnalyses[0];

            // retrieve selected truckSolution
            TruckSolution truckSolution = truckAnalysis.SelectedSolution;
            if (null == truckSolution) return;
            // create "truckSolution" element
            XmlElement elemTruckSolution = xmlDoc.CreateElement("truckSolution", ns);
            elemTruckAnalysis.AppendChild(elemTruckSolution);
            // title
            XmlElement elemTitle = xmlDoc.CreateElement("title", ns);
            elemTitle.InnerText = truckSolution.Title;
            elemTruckSolution.AppendChild(elemTitle);
            // palletCount
            XmlElement elemPalletCount = xmlDoc.CreateElement("palletCount", ns);
            elemPalletCount.InnerText = string.Format("{0}", truckSolution.PalletCount);
            elemTruckSolution.AppendChild(elemPalletCount);
            // boxCount
            XmlElement elemBoxCount = xmlDoc.CreateElement("caseCount", ns);
            elemBoxCount.InnerText = string.Format("{0}", truckSolution.BoxCount);
            elemTruckSolution.AppendChild(elemBoxCount);

            double loadWeight = truckSolution.PalletCount * inputData.ActualPalletWeight;
            // loadWeight
            XmlElement elemLoadWeight = xmlDoc.CreateElement("loadWeight", ns);
            elemLoadWeight.InnerText = string.Format("{0:F}", loadWeight);
            elemTruckSolution.AppendChild(elemLoadWeight);
            // loadEfficiency
            XmlElement elemLoadEfficiency = xmlDoc.CreateElement("loadEfficiency", ns);
            elemLoadEfficiency.InnerText = string.Format("{0:F}", 100.0 * loadWeight / truckAnalysis.TruckProperties.AdmissibleLoadWeight);
            elemTruckSolution.AppendChild(elemLoadEfficiency);
            // volumeEfficiency
            XmlElement elemVolumeEfficiency = xmlDoc.CreateElement("volumeEfficiency", ns);
            elemVolumeEfficiency.InnerText = string.Format("{0:F}", truckSolution.Efficiency);
            elemTruckSolution.AppendChild(elemVolumeEfficiency);

            // --- truck images
            for (int i = 0; i < 2; ++i)
            {
                // initialize drawing values
                string viewName = string.Empty;
                Vector3D cameraPos = Vector3D.Zero;
                int imageWidth = 768;
                switch (i)
                {
                    case 0: viewName = "view_trucksolution_top"; cameraPos = Graphics3D.Top; imageWidth = 768; break;
                    case 1: viewName = "view_trucksolution_iso"; cameraPos = Graphics3D.Corner_0; imageWidth = 768; break;
                    default: break;
                }
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(imageWidth, imageWidth));
                // set camera position 
                graphics.CameraPosition = cameraPos;
                // instantiate solution viewer
                TruckSolutionViewer sv = new TruckSolutionViewer(truckSolution);
                sv.Draw(graphics);
                // ---
                XmlElement elemImage = xmlDoc.CreateElement(viewName, ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 3, graphics.Bitmap.Height / 3);
                elemImage.Attributes.Append(styleAttribute);
                elemTruckSolution.AppendChild(elemImage);
                // Save image ?
                SaveImageAs(graphics.Bitmap, viewName + ".gif");
            }
        }
        #endregion

        #region Case analysis

        private void AppendCaseAnalysisElement(ReportData inputData, XmlElement elemDocument, XmlDocument xmlDoc)
        {
            // check if case analysis
            if (!inputData.IsCaseAnalysis)
                return;
            CaseAnalysis caseAnalysis = inputData.CaseAnalysis;
            SelCaseSolution selSolution = inputData.SelCaseSolution;

            // namespace
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // caseAnalysis
            XmlElement elemCaseAnalysis = xmlDoc.CreateElement("caseAnalysis", ns);
            elemDocument.AppendChild(elemCaseAnalysis);
            // name
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = caseAnalysis.Name;
            elemCaseAnalysis.AppendChild(elemName);
            // description
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = caseAnalysis.Description;
            elemCaseAnalysis.AppendChild(elemDescription);
            // box
            AppendBoxElement(caseAnalysis, elemCaseAnalysis, xmlDoc);
            // case
            AppendCaseElement(selSolution, elemCaseAnalysis, xmlDoc);
            // constraint set
            AppendCaseConstraintSet(caseAnalysis, elemCaseAnalysis, xmlDoc);
            // case solution
            AppendCaseSolutionElement(selSolution, elemCaseAnalysis, xmlDoc);
        }

        private void AppendBoxElement(CaseAnalysis caseAnalysis, XmlElement elemCaseAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            BoxProperties boxProperties = caseAnalysis.BoxProperties;
            // box element
            XmlElement elemBox = CreateElement("box", null, elemCaseAnalysis, xmlDoc, ns);
            // name
            CreateElement("name", boxProperties.Name, elemBox, xmlDoc, ns);
            // description
            CreateElement("description", boxProperties.Description, elemBox, xmlDoc, ns);
            // length / width / height
            CreateElement("length", boxProperties.Length, elemBox, xmlDoc, ns);
            CreateElement("width", boxProperties.Width, elemBox, xmlDoc, ns);
            CreateElement("height", boxProperties.Height, elemBox, xmlDoc, ns);
            // weight
            CreateElement("weight", boxProperties.Weight, elemBox, xmlDoc, ns);
            // view_box_iso
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Box box = new Box(0, boxProperties);
            graphics.AddBox(box);
            graphics.AddDimensions(new DimensionCube(box.Length, box.Width, box.Height));
            graphics.Flush();
            // ---
            // view_box_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_box_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemBox.AppendChild(elemImage);
            // save image ?
            SaveImageAs(graphics.Bitmap, "view_box_iso.gif");
             
        }
        private void AppendCaseElement(SelCaseSolution caseSolution, XmlElement elemCaseAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            BoxProperties boxProp = caseSolution.Solution.AttachedPalletSolution.Analysis.BProperties as BoxProperties;
            // case element
            XmlElement elemCase = CreateElement("caseWithInnerDims", null, elemCaseAnalysis, xmlDoc, ns);
            // name
            CreateElement("name", boxProp.Name, elemCase, xmlDoc, ns);
            // description
            CreateElement("description", boxProp.Description, elemCase, xmlDoc, ns);
            // length / width /height
            CreateElement("length", boxProp.Length, elemCase, xmlDoc, ns);
            CreateElement("width", boxProp.Width, elemCase, xmlDoc, ns);
            CreateElement("height", boxProp.Height, elemCase, xmlDoc, ns);
            // innerLength / innerWidth / innerHeight
            CreateElement("innerLength", boxProp.InsideLength, elemCase, xmlDoc, ns);
            CreateElement("innerWidth", boxProp.InsideWidth, elemCase, xmlDoc, ns);
            CreateElement("innerHeight", boxProp.InsideHeight, elemCase, xmlDoc, ns);
            // weight
            CreateElement("weight", boxProp.Weight, elemCase, xmlDoc, ns);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Box box = new Box(0, boxProp);
            graphics.AddBox(box);
            graphics.AddDimensions(new DimensionCube(box.Length, box.Width, box.Height));
            graphics.Flush();
            // ---
            // view_case_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_case_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemCase.AppendChild(elemImage);
            // save image
            SaveImageAs(graphics.Bitmap, "view_case_iso.gif");
        }

        private void AppendCaseConstraintSet(CaseAnalysis caseAnalysis, XmlElement elemCaseAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            CaseConstraintSet cs = caseAnalysis.ConstraintSet;
            // caseConstraintSet element
            XmlElement elemCaseConstraintSet = CreateElement("caseConstraintSet", null, elemCaseAnalysis, xmlDoc, ns);
            // allowedPatterns
            CreateElement("allowedPatterns", cs.AllowedPatternString, elemCaseConstraintSet, xmlDoc, ns);
            // allowedOrthoAxis
            CreateElement("allowedOrthoAxis", cs.AllowOrthoAxisString, elemCaseConstraintSet, xmlDoc, ns);
            // allowAlignedLayers
            CreateElement("allowAlignedLayers", cs.AllowAlignedLayers ? "Y" : "N", elemCaseConstraintSet, xmlDoc, ns);
            // allowAlternateLayers
            CreateElement("allowAlternateLayers", cs.AllowAlternateLayers ? "Y" : "N", elemCaseConstraintSet, xmlDoc, ns);
            // maximumCaseWeightGroup
            if (cs.UseMaximumCaseWeight)
            {
                XmlElement maximumCaseWeightGroup = CreateElement("maximumCaseWeightGroup", null, elemCaseConstraintSet, xmlDoc, ns);
                CreateElement("maximumCaseWeight", cs.MaximumCaseWeight, maximumCaseWeightGroup, xmlDoc, ns);
            }
            // minimumBoxPerCaseGroup
            if (cs.UseMinimumNumberOfItems)
            {
                XmlElement minimumBoxPerCaseGroup = CreateElement("minimumBoxPerCaseGroup", null, elemCaseConstraintSet, xmlDoc, ns);
                CreateElement("minimumBoxPerCase", cs.MinimumNumberOfItems, minimumBoxPerCaseGroup, xmlDoc, ns);
            }
            // maximumBoxPerCaseGroup
            if (cs.UseMaximumNumberOfItems)
            {
                XmlElement maximumBoxPerCaseGroup = CreateElement("minimumBoxPerCaseGroup", null, elemCaseConstraintSet, xmlDoc, ns);
                CreateElement("maximumBoxPerCase", cs.MinimumNumberOfItems, maximumBoxPerCaseGroup, xmlDoc, ns);
            }
        }
        private void AppendCaseSolutionElement(SelCaseSolution selSolution, XmlElement elemCaseAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            CaseSolution caseSolution = selSolution.Solution;
            // caseSolution element
            XmlElement elemCaseSolution = CreateElement("caseSolution", null, elemCaseAnalysis, xmlDoc, ns);
            // title
            CreateElement("title", caseSolution.Title, elemCaseSolution, xmlDoc, ns);
            // homogeneousLayer
            CreateElement("homogeneousLayer", caseSolution.HasHomogeneousLayers ? "Y" : "N", elemCaseSolution, xmlDoc, ns);
            // casePerPalletCount
            CreateElement("casePerPalletCount", caseSolution.CasePerPalletCount, elemCaseSolution, xmlDoc, ns);
            // boxPerCaseCount
            CreateElement("boxPerCaseCount", caseSolution.BoxPerCaseCount, elemCaseSolution, xmlDoc, ns);
            // boxPerPalletCount
            CreateElement("boxPerPalletCount", caseSolution.BoxPerPalletCount, elemCaseSolution, xmlDoc, ns);
            // caseEfficiency
            CreateElement("caseEfficiency", caseSolution.CaseEfficiency, elemCaseSolution, xmlDoc, ns);
            // palletEfficiency
            CreateElement("palletEfficiency", caseSolution.PalletEfficiency, elemCaseSolution, xmlDoc, ns);
            // caseWeight
            CreateElement("caseWeight", caseSolution.CaseWeight, elemCaseSolution, xmlDoc, ns);
            // palletWeight
            CreateElement("palletWeight", caseSolution.PalletWeight, elemCaseSolution, xmlDoc, ns);
            // palletWeight
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(512, 512));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            // instantiate solution viewer
            CaseSolutionViewer sv = new CaseSolutionViewer(caseSolution);
            sv.Draw(graphics);
            // ---
            // view_caseSolution_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_caseSolution_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width / 4, graphics.Bitmap.Height / 4);
            elemImage.Attributes.Append(styleAttribute);
            elemCaseSolution.AppendChild(elemImage);
            // save image
            SaveImageAs(graphics.Bitmap, "view_caseSolution_iso.gif");
        }
        #endregion

        #region Helpers
        private static XmlElement CreateElement(string eltName, string innerValue, XmlElement parentElt, XmlDocument xmlDoc, string ns)
        {
            XmlElement elt = xmlDoc.CreateElement(eltName, ns);
            if (!string.IsNullOrEmpty(innerValue))
                elt.InnerText = innerValue;
            parentElt.AppendChild(elt);
            return elt;
        }
        private static XmlElement CreateElement(string eltName, double v, XmlElement parentElt, XmlDocument xmlDoc, string ns)
        {
            XmlElement elt = xmlDoc.CreateElement(eltName, ns);
            elt.InnerText = string.Format("{0:F}", v);
            parentElt.AppendChild(elt);
            return elt;
        }
        private static XmlElement CreateElement(string eltName, int v, XmlElement parentElt, XmlDocument xmlDoc, string ns)
        {
            XmlElement elt = xmlDoc.CreateElement(eltName, ns);
            elt.InnerText = string.Format("{0}", v);
            parentElt.AppendChild(elt);
            return elt;
        }
        #endregion

        #region XML validator
        // Validation Error Count
        static int ErrorsCount = 0;
        // Validation Error Message
        static string ErrorMessage = "";

        private static void ValidateXmlDocument(XmlReader documentToValidate, string schemaPath)
        {
            XmlSchema schema;
            using (var schemaReader = XmlReader.Create(schemaPath))
            {
                schema = XmlSchema.Read(schemaReader, ValidationEventHandler);
            }

            var schemas = new XmlSchemaSet();
            schemas.Add(schema);
            var settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schemas;
            settings.ValidationFlags =
                XmlSchemaValidationFlags.ProcessIdentityConstraints |
                XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += ValidationEventHandler;

            using (var validationReader = XmlReader.Create(documentToValidate, settings))
            { while (validationReader.Read()) { } }

            if (ErrorsCount > 0)
                throw new Exception(ErrorMessage);
        }

        private static void ValidationEventHandler(
            object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Error)
            {
                ErrorMessage = ErrorMessage + args.Message + "\r\n";
                ErrorsCount++;
            }
        }
        #endregion
    }
}
