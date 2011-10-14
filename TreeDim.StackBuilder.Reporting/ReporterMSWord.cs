#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;

using Sharp3D.Math.Core;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;
#endregion

namespace TreeDim.StackBuilder.Reporting
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
    public class ReporterMSWord : Reporter
    {
        #region Xslt template file generation methods
        public override bool RetrieveXsltTemplate(string reportTemplatePath, ref string xsltFilePath)
        {
            // report template name
            string wmlFileName = string.Format("ReportTemplateMSWord_{0}.xml"
                , System.Globalization.CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName);
            // report file path
            string wmlFilePath = Path.Combine(reportTemplatePath, wmlFileName);
            // check if file can be found, else get default
            if (!File.Exists(wmlFilePath))
                wmlFilePath = Path.Combine(reportTemplatePath, "ReportTemplateMSWord_ENU.xml");
            // check template file existence
            if (!File.Exists(wmlFilePath))
                throw new FileNotFoundException(string.Format("Failed to find template file {0}", wmlFilePath), wmlFilePath);
            // get path of wml2xslt.exe
            string wml2xsltPath = Path.Combine(reportTemplatePath, "WML2XSLT.EXE");
            // temp xslt from wml
            string tempXslt = Path.GetTempFileName();
            ProcessStartInfo startInfo = new ProcessStartInfo(
                string.Format("\"{0}\"", wml2xsltPath)
                , string.Format("\"{0}\" -o \"{1}\" -ns \"http://treeDim/StackBuilder/ReportSchema.xsd\""
                , wmlFilePath
                , tempXslt));
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;
            Process procWml2xslt = Process.Start(startInfo);
            _log.Info(procWml2xslt.StandardOutput.ReadToEnd());
            // check xslt existence
            if (!File.Exists(tempXslt))
                throw new FileNotFoundException("Failed to generate .xslt file", tempXslt);
            // create new xslt document
            xsltFilePath = Path.ChangeExtension(Path.GetTempFileName(), "xslt");
            // load xml file in document and parse document
            using (FileStream fileStream = new FileStream(tempXslt, FileMode.Open))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileStream);
                XmlElement xmlRootElement = xmlDoc.DocumentElement;

                XmlNamespaceManager nsm = new XmlNamespaceManager(xmlDoc.NameTable);
                nsm.AddNamespace("w", "http://schemas.microsoft.com/office/word/2003/wordml");
                nsm.AddNamespace("xls", "http://www.w3.org/1999/XSL/Transform");
                nsm.AddNamespace("v", "urn:schemas-microsoft-com:vml");
                nsm.AddNamespace("o", "urn:schemas-microsoft-com:office:office");

                ModifyXslt(xmlDoc, xmlRootElement, nsm);
                // finally save XmlDocument
                XmlTextWriter writer = new XmlTextWriter(xsltFilePath, System.Text.Encoding.UTF8);
                xmlDoc.Save(writer);
                writer.Close();
            }
            return true;
        }

        static public void ModifyXslt(XmlDocument doc, XmlElement rootElement, XmlNamespaceManager nsm)
        {
            XmlNodeList nodeList = rootElement.SelectNodes("//w:pict", nsm);
            _log.DebugFormat("Modifying {0} nodes...", nodeList.Count);

            int imageCounter = 0;

            foreach (XmlNode node in nodeList)
            {
                string imageName = string.Format("wordml://010000{0}.gif", ++imageCounter);
                // ### insert w:binData element
                XmlElement binDataElement = doc.CreateElement("w:binData", "http://schemas.microsoft.com/office/word/2003/wordml");
                // append w:name attribute
                XmlAttribute nameAttribute = doc.CreateAttribute("w:name", "http://schemas.microsoft.com/office/word/2003/wordml");
                nameAttribute.Value = imageName;
                binDataElement.Attributes.Append(nameAttribute);
                // append xsl:value-of element
                XmlElement valueofElement = doc.CreateElement("value-of", "http://www.w3.org/1999/XSL/Transform");
                // append "select" attribute
                XmlAttribute selectAttribute = doc.CreateAttribute("select");
                selectAttribute.Value = ".";
                valueofElement.Attributes.Append(selectAttribute);
                binDataElement.AppendChild(valueofElement);
                // insert v:binary element
                XmlElement pictElement = node as XmlElement;
                pictElement.AppendChild(binDataElement);

                // ### insert imagedata elt in  v:shape
                foreach (XmlNode pictChildNode in node.ChildNodes)
                {
                    XmlElement shapeElt = pictChildNode as XmlElement;
                    if (null == shapeElt) continue;
                    if (0 != string.Compare(shapeElt.Name, "v:shape")) continue;

                    // create imagedata elt
                    XmlElement imageDataElt = doc.CreateElement("imageData", "urn:schemas-microsoft-com:vml");
                    // create src attribute
                    XmlAttribute srcAttribute = doc.CreateAttribute("src");
                    srcAttribute.Value = imageName;
                    imageDataElt.Attributes.Append(srcAttribute);
                    // create title attribute
                    XmlAttribute titleAttribute = doc.CreateAttribute("title", "urn:schemas-microsoft-com:office:office");
                    titleAttribute.Value = "convert";
                    imageDataElt.Attributes.Append(titleAttribute);
                    shapeElt.AppendChild(imageDataElt);
                }

                // ### remove following w:p element
                // get parent node
                XmlNode pNode = node.ParentNode;
                // get grand parent node
                XmlNode ppNode = pNode.ParentNode;
                XmlElement eltToRemove = null;
                foreach (XmlNode childNode in ppNode.ChildNodes)
                {
                    eltToRemove = childNode as XmlElement;
                    if (0 == string.Compare(eltToRemove.Name, "w:p", true))
                    {
                        break;
                    }
                    else
                        eltToRemove = null;
                }
                // remove w:p element
                if (null != eltToRemove)
                    ppNode.RemoveChild(eltToRemove);

                // ### remove following w:r element if it contains w:t
                foreach (XmlNode childNode in ppNode.ChildNodes)
                {
                    eltToRemove = childNode as XmlElement;
                    if (0 == string.Compare(eltToRemove.Name, "w:r", true))
                    {
                        bool hasTChild = false;
                        foreach (XmlNode cNode in eltToRemove.ChildNodes)
                        {
                            if (0 == string.Compare(cNode.Name, "w:t", true))
                            {
                                hasTChild = true;
                                break;
                            }
                        }
                        if (hasTChild == true)
                            break;
                        else
                            eltToRemove = null;
                    }
                    else
                        eltToRemove = null;
                }
                // remove w:r element
                if (null != eltToRemove)
                    ppNode.RemoveChild(eltToRemove);
            }
        }
        #endregion


        public override bool WriteNamespace
        {
            get { return true; }
        }

        public override bool WriteImageFiles
        {
            get { return false; }
        }
    }
}
