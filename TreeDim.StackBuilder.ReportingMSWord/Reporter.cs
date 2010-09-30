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
    /// <summary>
    /// Builds a word file from a Microsoft Word template file
    /// Ideas are from a codeproject article:
    /// http://www.codeproject.com/KB/office/Generating_Word_Reports.aspx
    /// Template production process decomposes as follow:
    /// 1. Create Report.doc
    /// 2. Import xml schema (xsd)
    /// 3. Map data on the document
    /// 4. Save the document as xml (Word ML)
    /// 5. Convert to xslt document template using the following command line:
    ///     WML2XSLT.EXE "Report.xml" -o "Report.xslt"
    /// 6. Edit generated xslt file and add conditions when necessary (e.g. missing xml data elements)
    ///     using <!-- <xsl:if test="ElementName"></xsl:if> -->
    /// 7. Edit generated xslt images and replace template definition with:
    /*
       <xsl:template match="/ns0:report/ns0:palletAnalysis/ns0:case/ns0:view_case_iso">
         <ns0:view_case_iso>
          <xsl:for-each select="@ns1:*|@*[namespace-uri()='']">
            <xsl:attribute name="{name()}" namespace="{namespace-uri()}">
              <xsl:value-of select="." />
            </xsl:attribute>
          </xsl:for-each>
          <w:r>
            <w:pict>
			    <w:binData w:name="wordml://01000001.gif">
			      <xsl:value-of select="." />
			    </w:binData>
			    <v:shape id="_x0000_i1025" type="#_x0000_t75">
				    <xsl:attribute name="style">
					    <xsl:value-of select="@style"/>
				    </xsl:attribute>
				    <v:imagedata src="wordml://01000001.gif" o:title="convert" />
			    </v:shape>
            </w:pict>
          </w:r>
        </ns0:view_case_iso>
      </xsl:template>
    */
    /// </summary>
    public class Reporter
    {
        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(Reporter));
        #endregion
        #region Static helpers
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
        #endregion

        #region Static methods
        /// <summary>
        /// Creates Word document from XML using XSLT
        /// </summary>
        /// <param name="xmlData">Report data as XML</param>
        /// <param name="xsltReader">XSLT transformation as Stream, used for document creation</param>
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
            if (analysis.BProperties is BoxProperties)
                AppendCaseElement(analysis, sol, elemPalletAnalysis, xmlDoc);
            else if (analysis.BProperties is BundleProperties)
                AppendBundleElement(analysis, sol, elemPalletAnalysis, xmlDoc);
            // interlayer
            AppendInterlayerElement(analysis, sol, elemPalletAnalysis, xmlDoc);
            // constraintSet
            AppendConstraintSet(analysis, sol, elemPalletAnalysis, xmlDoc);
            // solution
            AppendSolutionElement(analysis, sol, elemPalletAnalysis, xmlDoc);
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
            Graphics3DImage graphics = new Graphics3DImage(new Size(256,256));
            graphics.CameraPosition = Graphics3D.Iso;
            Pallet pallet = new Pallet(palletProp);
            pallet.Draw(graphics);
            graphics.Flush();
            // ---
            // view_pallet_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_pallet_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width, graphics.Bitmap.Height);
            elemImage.Attributes.Append(styleAttribute);
            elemPallet.AppendChild(elemImage);
        }

        private static void AppendCaseElement(Analysis analysis, Solution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
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
            graphics.CameraPosition = Graphics3D.Iso;
            Box box = new Box(0, boxProp);
            box.Draw(graphics);
            graphics.Flush();
            // ---
            // view_case_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_case_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width, graphics.Bitmap.Height);
            elemImage.Attributes.Append(styleAttribute);
            elemCase.AppendChild(elemImage);
        }

        private static void AppendBundleElement(Analysis analysis, Solution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            // get BundleProperties
            BundleProperties bundleProp = analysis.BProperties as BundleProperties;
            if (null == bundleProp) return;
            // bundle
            XmlElement elemBundle = xmlDoc.CreateElement("case", ns);
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
            // unitThickness
            XmlElement elemHeight = xmlDoc.CreateElement("unitThickness", ns);
            elemHeight.InnerText = string.Format("{0:F}", bundleProp.UnitThickness);
            elemBundle.AppendChild(elemHeight);
            // --- build image
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Iso;
            Box box = new Box(0, bundleProp);
            box.Draw(graphics);
            graphics.Flush();
            // ---
            // view_bundle_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_case_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width, graphics.Bitmap.Height);
            elemImage.Attributes.Append(styleAttribute);
            elemBundle.AppendChild(elemImage);      
        }

        private static void AppendConstraintSet(Analysis analysis, Solution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;
            ConstraintSet cs = analysis.ConstraintSet;
            // solution
            XmlElement elemConstraintSet = xmlDoc.CreateElement("constraintSet", ns);
            elemPalletAnalysis.AppendChild(elemConstraintSet);
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangX", cs.OverhangX);
            AppendElementValue(xmlDoc, elemConstraintSet, "overhangY", cs.OverhangY);
            // allowedPatterns
            XmlElement elemAllowedPatterns = xmlDoc.CreateElement("allowedPatterns", ns);
            elemAllowedPatterns.InnerText = cs.AllowedPatternString;
            elemConstraintSet.AppendChild(elemAllowedPatterns);
            // interlayerPeriod
            if (cs.HasInterlayer)
            {
                XmlElement elemInterlayerPeriod = xmlDoc.CreateElement("interlayerPeriod", ns);
                elemInterlayerPeriod.InnerText = string.Format("{0}", cs.InterlayerPeriod);
                elemConstraintSet.AppendChild(elemInterlayerPeriod);
            }
            // stopCriterion
            if (cs.UseMaximumHeight)
            {
                XmlElement maximumPalletHeight = xmlDoc.CreateElement("maximumPalletHeight", ns);
                maximumPalletHeight.InnerText = string.Format("{0}", cs.MaximumHeight);
                elemConstraintSet.AppendChild(maximumPalletHeight);
            }
            if (cs.UseMaximumNumberOfItems)
            {
                XmlElement maximumNumberOfItems = xmlDoc.CreateElement("maximumNumberOfItems", ns);
                maximumNumberOfItems.InnerText = string.Format("{0}", cs.MaximumNumberOfItems);
                elemConstraintSet.AppendChild(maximumNumberOfItems);

            }
            if (cs.UseMaximumPalletWeight)
            {
                XmlElement maximumPalletWeight = xmlDoc.CreateElement("maximumPalletWeight", ns);
                maximumPalletWeight.InnerText = string.Format("{0:F}", cs.MaximumPalletWeight);
                elemConstraintSet.AppendChild(maximumPalletWeight);
            }
            if (cs.UseMaximumWeightOnBox)
            {
                XmlElement admissibleLoadOnTop = xmlDoc.CreateElement("admissibleLoadOnTop", ns);
                admissibleLoadOnTop.InnerText = string.Format("{0:F}", cs.MaximumWeightOnBox);
                elemConstraintSet.AppendChild(admissibleLoadOnTop);
            }
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
            Graphics3DImage graphics = new Graphics3DImage(new Size(256, 256));
            graphics.CameraPosition = Graphics3D.Iso;
            Box box = new Box(0, interlayerProp);
            box.Draw(graphics);
            graphics.Flush();
            // ---
            // view_interlayer_iso
            XmlElement elemImage = xmlDoc.CreateElement("view_interlayer_iso", ns);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
            XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
            styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width, graphics.Bitmap.Height);
            elemImage.Attributes.Append(styleAttribute);
            elemInterlayer.AppendChild(elemImage); 
        }

        private static void AppendSolutionElement(Analysis analysis, Solution sol, XmlElement elemPalletAnalysis, XmlDocument xmlDoc)
        {
            string ns = xmlDoc.DocumentElement.NamespaceURI;

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
            // interlayer count
            if (analysis.ConstraintSet.HasInterlayer)
            { 
            }
            // layers
            // --- build images
            for (int i = 0; i < 5; ++i)
            {
                // initialize drawing values
                string viewName = string.Empty;
                Vector3D cameraPos = Vector3D.Zero;
                int imageWidth = 128;
                switch (i)
                {
                case 0:
                    viewName = "view_palletsolution_front"; cameraPos = Graphics3D.Front; imageWidth = 128;
                    break;
                case 1:
                    viewName = "view_palletsolution_left"; cameraPos = Graphics3D.Left; imageWidth = 128;
                    break;
                case 2:
                    viewName = "view_palletsolution_right"; cameraPos = Graphics3D.Right; imageWidth = 128;
                    break;
                case 3:
                    viewName = "view_palletsolution_back"; cameraPos = Graphics3D.Back; imageWidth = 128;
                    break;
                case 4:
                    viewName = "view_palletsolution_iso"; cameraPos = Graphics3D.Iso; imageWidth = 256;
                    break;
                default:
                    break;
                }
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(imageWidth, imageWidth));
                // set camera position 
                graphics.CameraPosition = cameraPos;
                // instantiate solution viewer
                SolutionViewer sv = new SolutionViewer(analysis, sol);
                sv.Draw(graphics);
                // ---
                XmlElement elemImage = xmlDoc.CreateElement(viewName, ns);
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
                elemImage.InnerText = Convert.ToBase64String((byte[])converter.ConvertTo(graphics.Bitmap, typeof(byte[])));
                XmlAttribute styleAttribute = xmlDoc.CreateAttribute("style");
                styleAttribute.Value = string.Format("width:{0}pt;height:{1}pt", graphics.Bitmap.Width, graphics.Bitmap.Height);
                elemImage.Attributes.Append(styleAttribute);
                elemSolution.AppendChild(elemImage);
            }
        }
        #endregion
    }
}
