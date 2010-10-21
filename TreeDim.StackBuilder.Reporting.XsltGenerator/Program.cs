#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Windows.Forms;
using System.Diagnostics;

using log4net;
using log4net.Config;
#endregion

namespace TreeDim.StackBuilder.Reporting.XsltGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog log = LogManager.GetLogger(typeof(Program));
            XmlConfigurator.Configure();

            if (args.Length < 2)
            {
                log.Fatal(string.Format("Usage : {0} xsltInPath xsltOutPath", Application.ProductName));
                return;
            }
            string filePathIn = args[0];
            string filePathTemp = Path.Combine(Path.GetDirectoryName(filePathIn), "temp.xslt");
            string filePathOut = args[1];
            if (!File.Exists(filePathIn))
            {
                log.Fatal(string.Format("File {0} does not exist", filePathIn));
                return;
            }

            try
            {
                // generate xslt from xml
                ProcessStartInfo startInfo = new ProcessStartInfo(
                    @"..\..\..\TreeDim.StackBuilder.ReportingMSWord\ReportTemplate\WML2XSLT.EXE"
                    , string.Format("{0} -o {1} -ns \"http://treeDim/StackBuilder/ReportSchema.xsd\""
                    , filePathIn
                    , filePathTemp));
                Process.Start(startInfo);
                System.Threading.Thread.Sleep(1000);
                // load xml file in document and parse document
                using (FileStream fileStream = new FileStream(filePathTemp, FileMode.Open))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(fileStream);
                    log.Info(string.Format("Successfully opened file {0}", filePathIn));
                    XmlElement xmlRootElement = xmlDoc.DocumentElement;


                    XmlNamespaceManager nsm = new XmlNamespaceManager(xmlDoc.NameTable);
                    nsm.AddNamespace("w", "http://schemas.microsoft.com/office/word/2003/wordml");
                    nsm.AddNamespace("xls", "http://www.w3.org/1999/XSL/Transform");
                    nsm.AddNamespace("v", "urn:schemas-microsoft-com:vml");
                    nsm.AddNamespace("o", "urn:schemas-microsoft-com:office:office");

                    ModifyXslt(xmlDoc, xmlRootElement, nsm);
                    // finally save XmlDocument
                    xmlDoc.Save(filePathOut);
                    log.Info(string.Format("Successfully saved file {0}", filePathOut));
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        static public void ModifyXslt(XmlDocument doc, XmlElement rootElement, XmlNamespaceManager nsm)
        {
            XmlNodeList nodeList = rootElement.SelectNodes("//w:pict", nsm);
            Console.WriteLine("Modifying {0} nodes...", nodeList.Count);

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
    }
}
