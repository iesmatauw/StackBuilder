#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Drawing;
using System.ComponentModel;

using Sharp3D.Math.Core;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;

using log4net;
#endregion

namespace TreeDim.StackBuilder.ReportingMSWord
{
    public class Reporter
    {
        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(Reporter));
        #endregion

        #region Static methods
        /// <summary>
        /// Creates Word document from XML using XSLT
        /// </summary>
        /// <param name="xmlData">Report data as XML</param>
        /// <param name="nameOfXslt">XSLT transformation as Stream, used for document creation</param>
        /// <returns>Resulting Word document as byte[]</returns>
        public static byte[] GetWord(XmlReader xmlData, XmlReader xsltReader)
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
        public static void BuidAnalysisReport(Analysis analysis, Solution sol, string xsltTemplateFilePath, string outputFilePath)
        {
            string xmlFilePath = Path.ChangeExtension(System.IO.Path.GetTempFileName(), "xml");
            CreateAnalysisDataFile(analysis, sol, xmlFilePath);
            XmlTextReader xmlData = new XmlTextReader(new FileStream(xmlFilePath, FileMode.Open, FileAccess.Read));
            XmlTextReader xsltReader = new XmlTextReader(new FileStream(xsltTemplateFilePath, FileMode.Open, FileAccess.Read));
            byte[] wordDoc = GetWord(xmlData, xsltReader);
            // Write resulting array to HDD, show process information
            using (FileStream fs = new FileStream(outputFilePath, FileMode.Create))
                fs.Write(wordDoc, 0, wordDoc.Length);

        }

        private static void CreateAnalysisDataFile(Analysis analysis, Solution sol, string xmlDataFilePath)
        {
            // instantiate XmlDocument
            XmlDocument xmlDoc = new XmlDocument();

            // set declaration
            XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "no");
            xmlDoc.AppendChild(declaration);

            // report (root) element
            XmlElement elemDocument = xmlDoc.CreateElement("report", "http://treeDim/StackBuilder/ReportSchema.xsd");
            xmlDoc.AppendChild(elemDocument);

            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // name element
            XmlElement elemName = xmlDoc.CreateElement("name", ns);
            elemName.InnerText = analysis.ParentDocument.Name;
            elemDocument.AppendChild(elemName);
            // description element
            XmlElement elemDescription = xmlDoc.CreateElement("description", ns);
            elemDescription.InnerText = analysis.ParentDocument.Description;
            elemDocument.AppendChild(elemDescription);
            // author element
            XmlElement elemAuthor = xmlDoc.CreateElement("author", ns);
            elemAuthor.InnerText = analysis.ParentDocument.Author;
            elemDocument.AppendChild(elemAuthor);
            // date of creation element
            XmlElement elemDateOfCreation = xmlDoc.CreateElement("dateOfCreation", ns);
            elemDateOfCreation.InnerText = analysis.ParentDocument.DateOfCreation.ToString();
            elemDocument.AppendChild(elemDateOfCreation);

            // palletAnalysis
            AppendPalletAnalysisElement(analysis, sol, elemDocument, xmlDoc);

            // finally save xml document
            _log.Debug(string.Format("Generating xml data file {0}", xmlDataFilePath));
            xmlDoc.Save(xmlDataFilePath);
        }

        private static void AppendPalletAnalysisElement(Analysis analysis, Solution sol, XmlElement elemDocument, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
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
            AppendPalletElement(analysis, sol, elemPalletAnalysis, xmlDoc);
            // case
            AppendCaseElement(analysis, sol, elemPalletAnalysis, xmlDoc);
            // interlayer
            AppendInterlayerElement(analysis, sol, elemPalletAnalysis, xmlDoc);
/*
            // constraintSet
            AppendConstraintSet(analysis, sol, elemPalletAnalysis, xmlDoc);
            // solution
            AppendSolutionElement(analysis, sol, elemPalletAnalysis, xmlDoc);
 */ 
        }

        private static void AppendPalletElement(Analysis analysis, Solution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
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
            elemType.InnerText = palletProp.Type.ToString();
            elemPallet.AppendChild(elemType);
            // --- build image
            double angle = 45.0;
            Graphics3DImage graphics = new Graphics3DImage(new Size(256,256));
            graphics.CameraPosition = new Vector3D(
                Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , 10000.0);
            graphics.Target = new Vector3D(0.0, 0.0, 0.0);
            graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
            Pallet pallet = new Pallet(palletProp);
            pallet.Draw(graphics);
            graphics.Flush();
            // ---

            // imageBinary 256 * 256
            XmlElement elemImage = xmlDoc.CreateElement("imageBinary", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            elemPallet.AppendChild(elemImage);
        }

        private static void AppendCaseElement(Analysis analysis, Solution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get BoxProperties
            BoxProperties boxProp = analysis.BoxProperties;
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
            // --- build image
            double angle = 45.0;
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = new Vector3D(
                Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , 10000.0);
            graphics.Target = new Vector3D(0.0, 0.0, 0.0);
            graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
            Box box = new Box(0, boxProp);
            box.Draw(graphics);
            graphics.Flush();
            // ---
            // imageBinary 256 * 256
            XmlElement elemImage = xmlDoc.CreateElement("imageBinary", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            elemCase.AppendChild(elemImage);
        }

        private static void AppendConstraintSet(Analysis analysis, Solution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            ConstraintSet cs = analysis.ConstraintSet;
            // solution
            XmlElement elemConstraintSet = xmlDoc.CreateElement("constraintSet", ns);
            elemPalletAnalysis.AppendChild(elemConstraintSet);
            // allowedPatterns
            XmlElement elemAllowedPatterns = xmlDoc.CreateElement("allowedPatters", ns);
            elemAllowedPatterns.InnerText = cs.AllowedPatternString;
            elemConstraintSet.AppendChild(elemAllowedPatterns);
            // hasInterlayers
            XmlElement elemHasInterlayers = xmlDoc.CreateElement("hasInterlayers", ns);
            elemHasInterlayers.InnerText = cs.HasInterlayer.ToString();
            elemConstraintSet.AppendChild(elemHasInterlayers);
            // interlayerPeriod
            XmlElement elemInterlayerPeriod = xmlDoc.CreateElement("interlayerPeriod", ns);
            elemInterlayerPeriod.InnerText = string.Format("{0}", cs.InterlayerPeriod);
            elemConstraintSet.AppendChild(elemInterlayerPeriod);
            // stopCriterion

            if (cs.UseMaximumHeight)
            {
                XmlElement elemStopCriterion = xmlDoc.CreateElement("stopCriterion", ns);
                elemConstraintSet.AppendChild(elemStopCriterion);
                XmlElement elemName = xmlDoc.CreateElement("name", ns);
                elemName.InnerText = "Maximum pallet height";
                elemStopCriterion.AppendChild(elemName);
                XmlElement elemValue = xmlDoc.CreateElement("value", ns);
                elemValue.InnerText = string.Format("{0:F}", cs.MaximumHeight);
                elemStopCriterion.AppendChild(elemValue);
                XmlElement elemUnit = xmlDoc.CreateElement("unit", ns);
                elemUnit.InnerText = "mm";
                elemStopCriterion.AppendChild(elemUnit);
            }
            if (cs.UseMaximumNumberOfItems)
            {
                XmlElement elemStopCriterion = xmlDoc.CreateElement("stopCriterion", ns);
                elemConstraintSet.AppendChild(elemStopCriterion);
                XmlElement elemName = xmlDoc.CreateElement("name", ns);
                elemName.InnerText = "Maximum number of items";
                elemStopCriterion.AppendChild(elemName);
                XmlElement elemValue = xmlDoc.CreateElement("value", ns);
                elemValue.InnerText = string.Format("{0}", cs.MaximumNumberOfItems);
                elemStopCriterion.AppendChild(elemValue);
                XmlElement elemUnit = xmlDoc.CreateElement("unit", ns);
                elemUnit.InnerText = "";
                elemStopCriterion.AppendChild(elemUnit);
            }
            if (cs.UseMaximumPalletWeight)
            {
                XmlElement elemStopCriterion = xmlDoc.CreateElement("stopCriterion", ns);
                elemConstraintSet.AppendChild(elemStopCriterion);
                XmlElement elemName = xmlDoc.CreateElement("name", ns);
                elemName.InnerText = "Maximum pallet weight";
                elemStopCriterion.AppendChild(elemName);
                XmlElement elemValue = xmlDoc.CreateElement("value", ns);
                elemValue.InnerText = string.Format("{0:F}", cs.MaximumPalletWeight);
                elemStopCriterion.AppendChild(elemValue);
                XmlElement elemUnit = xmlDoc.CreateElement("unit", ns);
                elemUnit.InnerText = "kg";
                elemStopCriterion.AppendChild(elemUnit);
            }
            // allowedBoxAxis
            XmlElement elemAllowedBoxAxis = xmlDoc.CreateElement("allowedBoxAxis", ns);
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
        }

        private static void AppendInterlayerElement(Analysis analysis, Solution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
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
            double angle = 45.0;
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = new Vector3D(
                Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , 10000.0);
            graphics.Target = new Vector3D(0.0, 0.0, 0.0);
            graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
            Box box = new Box(0, interlayerProp);
            box.Draw(graphics);
            graphics.Flush();
            // ---
            // imageBinary 256 * 256
            XmlElement elemImage = xmlDoc.CreateElement("imageBinary", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            elemInterlayer.AppendChild(elemImage); 
        }

        private static void AppendSolutionElement(Analysis analysis, Solution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // solution
            XmlElement elemSolution = xmlDoc.CreateElement("solution", ns);
            elemPalletAnalysis.AppendChild(elemSolution);
            // efficiency
            XmlElement elemEfficiency = xmlDoc.CreateElement("efficiency", ns);
            elemEfficiency.InnerText = string.Format("{0:F}", sol.Efficiency(analysis));
            elemSolution.AppendChild(elemEfficiency);
            // palletWeight
            XmlElement elemPalletWeight = xmlDoc.CreateElement("palletWeight", ns);
            elemPalletWeight.InnerText = string.Format("{0:F}", sol.PalletWeight(analysis));
            elemSolution.AppendChild(elemPalletWeight);
            // palletHeight
            XmlElement elemPalletHeight = xmlDoc.CreateElement("palletHeight", ns);
            elemPalletHeight.InnerText = string.Format("{0:F}", sol.PalletHeight(analysis));
            elemSolution.AppendChild(elemPalletHeight);
            // boxCount
            XmlElement elemBoxCount = xmlDoc.CreateElement("boxCount", ns);
            elemBoxCount.InnerText = string.Format("{0}", sol.Count);
            elemSolution.AppendChild(elemBoxCount);
            // title
            XmlElement elemTitle = xmlDoc.CreateElement("title", ns);
            elemTitle.InnerText = sol.Title;
            elemSolution.AppendChild(elemTitle);
            // homogeneousLayer
            XmlElement elemHomogeneousLayer = xmlDoc.CreateElement("homogeneousLayer", ns);
            elemHomogeneousLayer.InnerText = sol.HasHomogeneousLayers.ToString();
            elemSolution.AppendChild(elemHomogeneousLayer);
            // layers

            // --- build image
            // instantiate graphics
            Graphics3DImage graphics = new Graphics3DImage(new Size(512, 512));
            // set camera position 
            double angleHorizRad = 45.0 * Math.PI / 180.0;
            double angleVertRad = 45.0 * Math.PI / 180.0;
            graphics.CameraPosition = new Vector3D(
                10000.0 * Math.Cos(angleHorizRad) * Math.Cos(angleVertRad)
                , 10000.0 * Math.Sin(angleHorizRad) * Math.Cos(angleVertRad)
                , 10000.0 * Math.Sin(angleVertRad));
            // set camera target
            graphics.Target = new Vector3D(0.0, 0.0, 0.0);
            // set light direction
            graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
            // set viewport (not actually needed)
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);

            // instantiate solution viewer
            SolutionViewer sv = new SolutionViewer(analysis, sol);
            sv.Draw(graphics);
            // ---
            // imageBinary 512 * 512
            XmlElement elemImage = xmlDoc.CreateElement("imageBinary", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            elemSolution.AppendChild(elemImage);
        }
        #endregion
    }
}
