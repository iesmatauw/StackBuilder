#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Windows.Forms;

using TreeDim.StackBuilder.Graphics;
using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;

using Sharp3D.Math.Core;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    #region IDocumentListener
    public interface IDocumentListener
    {
        // new
        void OnNewDocument(Document doc);
        void OnNewTypeCreated(Document doc, ItemProperties itemProperties);
        void OnNewAnalysisCreated(Document doc, Analysis analysis);
        // remove
        void OnTypeRemoved(Document doc, Analysis analysis);
        void OnAnalysisRemoved(Document doc, Analysis analysis);
    }
    #endregion

    #region Document
    public class Document
    {
        #region Data members
        private string _name, _description, _author;
        private DateTime _dateCreated;
        private List<ItemProperties> _typeList = new List<ItemProperties>();
        private List<Analysis> _analyses = new List<Analysis>();
        private List<IDocumentListener> _listeners = new List<IDocumentListener>();
        private string _filePath = string.Empty;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(Document));
        #endregion

        #region Constructor
        public Document(string filePath)
        {
            _filePath = filePath;
            _name = Path.GetFileNameWithoutExtension(_filePath);
        }

        public Document(string name, string description, string author, DateTime dateCreated)
        {
            _name = name;
            _description = description;
            _author = author;
            _dateCreated = dateCreated;
        }
        #endregion

        #region Document Load method
        public static Document Load(string filePath, IDocumentListener docListener)
        {
            Document doc = new Document(filePath);
            doc.AddListener(docListener);
            doc.Load(); // uses _filePath
            return doc;
        }

        #endregion

        #region Public ItemProperties instantiation methods
        public BoxProperties CreateNewBox(
            string name, string description
            , double length, double width, double height, double weight
            , Color[] colors)
        {
            // instantiate and initialize
            BoxProperties boxProperties = new BoxProperties(length, width, height);
            boxProperties.Weight = weight;
            boxProperties.Name = name;
            boxProperties.Description = description;
            boxProperties.Colors = colors;
            // insert in list
            _typeList.Add(boxProperties);
            // notify listeners
            NotifyOnNewTypeCreated(boxProperties);

            return boxProperties;
        }

        public BundleProperties CreateNewBundle(
            string name, string description
            , double length, double width, double thickness
            , double weight
            , Color color
            , int noFlats)
        {
            // instantiate and initialize
            BundleProperties bundle = new BundleProperties(name, description, length, width, thickness, weight, noFlats, color);
            // insert in list
            _typeList.Add(bundle);
            // notify listeners
            NotifyOnNewTypeCreated(bundle);
            return bundle;
        }

        public InterlayerProperties CreateNewInterlayer(
            string name, string description
            , double length, double width, double thickness
            , double weight
            , Color color)
        { 
            // instantiate and intialize
            InterlayerProperties interlayer = new InterlayerProperties(
                name, description
                , length, width, thickness
                , weight, color);
            // insert in list
            _typeList.Add(interlayer);
            // notify listeners
            NotifyOnNewTypeCreated(interlayer);
            return interlayer;
        }

        public PalletProperties CreateNewPallet(
            string name, string description
            , PalletProperties.PalletType type
            , double length, double width, double height
            , double weight, double admissibleLoadWeight
            , double admissibleLoadHeight)
        {
            PalletProperties palletProperties = new PalletProperties(type, length, width, height);
            palletProperties.Name = name;
            palletProperties.Description = description;
            palletProperties.Weight = weight;
            palletProperties.AdmissibleLoadWeight = admissibleLoadWeight;
            palletProperties.AdmissibleLoadHeight = admissibleLoadHeight;
            // insert in list
            _typeList.Add(palletProperties);
            // notify listeners
            NotifyOnNewTypeCreated(palletProperties);

            return palletProperties;
        }

        public Analysis CreateNewAnalysis(string name, string description
            , BoxProperties box, PalletProperties pallet, InterlayerProperties interlayer
            , ConstraintSet constraintSet)
        {
            Analysis analysis = new Analysis(box, pallet, interlayer, constraintSet);
            analysis.Name = name;
            analysis.Description = description;
            // insert in list
            _analyses.Add(analysis);
            // notify listeners
            NotifyOnNewAnalysisCreated(analysis);

            // compute
            Solver solver = new Solver();
            solver.ProcessAnalysis(analysis);

            return analysis;
        }
        #endregion

        #region Name methods
        public bool IsValidTypeName(string name)
        { 
            // make sure is not empty
            if (name.Trim() == string.Empty)
                return false;            
            // make sure that name is not already used
            foreach (ItemProperties item in _typeList)
                if (item.Name.Trim().ToLower() == name.Trim().ToLower())
                    return false;            
            // success
            return true;
        }
        #endregion

        #region Public properties
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<BoxProperties> Boxes
        {
            get
            {
                List<BoxProperties> boxList = new List<BoxProperties>();
                foreach (ItemProperties item in _typeList)
                {
                    BoxProperties boxProperties = item as BoxProperties;
                    if (null != boxProperties)
                        boxList.Add(boxProperties);                        
                }
                return boxList;
            }
        }
        public List<PalletProperties> Pallets
        {
            get
            {
                List<PalletProperties> palletList = new List<PalletProperties>();
                foreach (ItemProperties item in _typeList)
                {
                    PalletProperties palletProperties = item as PalletProperties;
                    if (null != palletProperties)
                        palletList.Add(palletProperties);
                }
                return palletList;
            }
        }
        public List<InterlayerProperties> Interlayers
        {
            get
            {
                List<InterlayerProperties> interlayerList = new List<InterlayerProperties>();
                foreach (ItemProperties item in _typeList)
                {
                    InterlayerProperties interlayerProperties = item as InterlayerProperties;
                    if (null != interlayerProperties)
                        interlayerList.Add(interlayerProperties);
                }
                return interlayerList;
            }
        }

        public bool CanCreateAnalysis
        {
            get
            {
                int iNoBox = 0, iNoPallets = 0;
                foreach (ItemProperties item in _typeList)
                {
                    if (item.GetType() == typeof(BoxProperties))
                        ++iNoBox;
                    else if (item.GetType() == typeof(PalletProperties))
                        ++iNoPallets;
                }
                return iNoBox > 0 && iNoPallets > 0; 
            }
        }
        #endregion

        #region Load methods
        public void Load()
        {
            // get a valid file path
            if (string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
            {
                OpenFileDialog form = new OpenFileDialog();
                form.Filter = "Stackbuilder files (*.stb)|*.stb|All files (*.*)|*.*";
                if (DialogResult.OK == form.ShowDialog())
                    _filePath = form.FileName;
                else
                    return;
            }
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                using (FileStream fileStream = new FileStream(_filePath, FileMode.Open))
                {
                    xmlDoc.Load(fileStream);
                    XmlElement xmlRootElement = xmlDoc.DocumentElement;
                    LoadDocumentElement(xmlRootElement);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        void LoadDocumentElement(XmlElement docElement)
        {
            if (docElement.HasAttribute("Name"))
                _name = docElement.Attributes["Name"].Value;
            if (docElement.HasAttribute("Description"))
                _description = docElement.Attributes["Description"].Value;
            if (docElement.HasAttribute("Description"))
                _author = docElement.Attributes["Author"].Value;
            if (docElement.HasAttribute("DateCreated"))
                _dateCreated = System.Convert.ToDateTime(docElement.Attributes["DateCreated"].Value);

            foreach (XmlNode docChildNode in docElement.ChildNodes)
            {
                // load item properties
                if (string.Equals(docChildNode.Name, "ItemProperties", StringComparison.CurrentCultureIgnoreCase))
                {
                    foreach (XmlNode itemPropertiesNode in docChildNode.ChildNodes)
                    {
                        try
                        {
                            if (string.Equals(itemPropertiesNode.Name, "BoxProperties", StringComparison.CurrentCultureIgnoreCase))
                                LoadBoxProperties(itemPropertiesNode as XmlElement);
                            else if (string.Equals(itemPropertiesNode.Name, "PalletProperties", StringComparison.CurrentCultureIgnoreCase))
                                LoadPalletProperties(itemPropertiesNode as XmlElement);
                            else if (string.Equals(itemPropertiesNode.Name, "InterlayerProperties", StringComparison.CurrentCultureIgnoreCase))
                                LoadInterlayerProperties(itemPropertiesNode as XmlElement);
                            else if (string.Equals(itemPropertiesNode.Name, "BundleProperties", StringComparison.CurrentCultureIgnoreCase))
                                LoadBundleProperties(itemPropertiesNode as XmlElement);
                            else if (string.Equals(itemPropertiesNode.Name, "TruckProperties", StringComparison.CurrentCultureIgnoreCase))
                                LoadTruckProperties(itemPropertiesNode as XmlElement);
                        }
                        catch (Exception ex)
                        {
                            _log.Error(ex.ToString());
                        }
                    }
                }

                // load analyses
                if (string.Equals(docChildNode.Name, "Analyses", StringComparison.CurrentCultureIgnoreCase))
                {
                    foreach (XmlNode analysisNode in docChildNode.ChildNodes)
                    {
                        try
                        {
                            LoadAnalysis(analysisNode as XmlElement);
                        }
                        catch (Exception ex)
                        {
                            _log.Error(ex.ToString());
                        }
                    }
                }
            }
        }
        private void LoadBoxProperties(XmlElement eltBoxProperties)
        {
            string sid = eltBoxProperties.Attributes["Id"].Value;
            string sname = eltBoxProperties.Attributes["Name"].Value;
            string sdescription = eltBoxProperties.Attributes["Description"].Value;
            string slength = eltBoxProperties.Attributes["Length"].Value;
            string swidth = eltBoxProperties.Attributes["Width"].Value;
            string sheight = eltBoxProperties.Attributes["Height"].Value;
            string sweight = eltBoxProperties.Attributes["Weight"].Value;

            Color[] colors = new Color[6];
            foreach (XmlNode node in eltBoxProperties.ChildNodes)
            {
                if (string.Equals(node.Name, "FaceColors", StringComparison.CurrentCultureIgnoreCase))
                {
                    XmlElement faceColorList = node as XmlElement;
                    foreach (XmlNode faceColorNode in faceColorList.ChildNodes)
                    {
                        XmlElement faceColorElt = faceColorNode as XmlElement;
                        string sFaceIndex = faceColorElt.Attributes["FaceIndex"].Value;
                        string sColorArgb = faceColorElt.Attributes["Color"].Value;
                        int iFaceIndex = System.Convert.ToInt32(sFaceIndex);
                        Color faceColor = Color.FromArgb(System.Convert.ToInt32(sColorArgb));
                        colors[iFaceIndex] = faceColor;
                    }
                }
            }
            // create new BoxProperties instance
            BoxProperties boxProperties = CreateNewBox(
                sname
                , sdescription
                , System.Convert.ToDouble(slength)
                , System.Convert.ToDouble(swidth)
                , System.Convert.ToDouble(sheight)
                , System.Convert.ToDouble(sweight)
                , colors);

            boxProperties.Guid = new Guid(sid);
        }
        private void LoadPalletProperties(XmlElement eltPalletProperties)
        {
            string sid = eltPalletProperties.Attributes["Id"].Value;
            string sname = eltPalletProperties.Attributes["Name"].Value;
            string sdescription = eltPalletProperties.Attributes["Description"].Value;
            string slength = eltPalletProperties.Attributes["Length"].Value;
            string swidth = eltPalletProperties.Attributes["Width"].Value;
            string sheight = eltPalletProperties.Attributes["Height"].Value;
            string sweight = eltPalletProperties.Attributes["Weight"].Value;
            string sadmissibleloadweight = eltPalletProperties.Attributes["AdmissibleLoadWeight"].Value;
            string sadmissibleloadheight = eltPalletProperties.Attributes["AdmissibleLoadHeight"].Value;
            string stype = eltPalletProperties.Attributes["Type"].Value;
            string sColor = eltPalletProperties.Attributes["Color"].Value;

            // create new PalletProperties instance
            PalletProperties palletProperties = CreateNewPallet(
                sname
                , sdescription
                , (PalletProperties.PalletType)System.Convert.ToInt32(stype)
                , System.Convert.ToDouble(slength)
                , System.Convert.ToDouble(swidth)
                , System.Convert.ToDouble(sheight)
                , System.Convert.ToDouble(sweight)
                , System.Convert.ToDouble(sadmissibleloadweight)
                , System.Convert.ToDouble(sadmissibleloadheight));
            palletProperties.Color = Color.FromArgb(System.Convert.ToInt32(sColor));
            palletProperties.Guid = new Guid(sid);
        }
        private void LoadInterlayerProperties(XmlElement eltInterlayerProperties)
        {
            string sid = eltInterlayerProperties.Attributes["Id"].Value;
            string sname = eltInterlayerProperties.Attributes["Name"].Value;
            string sdescription = eltInterlayerProperties.Attributes["Description"].Value;
            string slength = eltInterlayerProperties.Attributes["Length"].Value;
            string swidth = eltInterlayerProperties.Attributes["Width"].Value;
            string sthickness = eltInterlayerProperties.Attributes["Thickness"].Value;
            string sweight = eltInterlayerProperties.Attributes["Weight"].Value;
            string sColor = eltInterlayerProperties.Attributes["Color"].Value;

            // create new InterlayerProperties instance
            InterlayerProperties interlayerProperties = CreateNewInterlayer(
                sname
                , sdescription
                , Convert.ToDouble(slength)
                , Convert.ToDouble(swidth)
                , Convert.ToDouble(sthickness)
                , Convert.ToDouble(sweight)
                , Color.FromArgb(System.Convert.ToInt32(sColor)));
            interlayerProperties.Guid = new Guid(sid);
        }
        private void LoadBundleProperties(XmlElement eltBundleProperties)
        { 
        }
        private void LoadTruckProperties(XmlElement eltBundleProperties)
        {
        }
        private void LoadAnalysis(XmlElement eltAnalysis)
        {
            string sName = eltAnalysis.Attributes["Name"].Value;
            string sDescription = eltAnalysis.Attributes["Description"].Value;
            string sBoxId = eltAnalysis.Attributes["BoxId"].Value;
            string sPalletId = eltAnalysis.Attributes["PalletId"].Value;
            string sInterlayerId = string.Empty;
            if (eltAnalysis.HasAttribute("InterlayerId"))
                sInterlayerId = eltAnalysis.Attributes["InterlayerId"].Value;

            // load constraint set / solution list
            ConstraintSet constraintSet = null;
            List<Solution> solutions = new List<Solution>();

            foreach (XmlNode node in eltAnalysis.ChildNodes)
            {
                // load constraint set
                if (string.Equals(node.Name, "ConstraintSet", StringComparison.CurrentCultureIgnoreCase))
                    constraintSet = LoadConstraintSet(node as XmlElement);
                // load solutions
                else if (string.Equals(node.Name, "Solutions", StringComparison.CurrentCultureIgnoreCase))
                {
                    foreach (XmlNode solutionNode in node.ChildNodes)
                        solutions.Add(LoadSolution(solutionNode as XmlElement));
                }
            }

            // instantiate analysis
            Analysis analysis = CreateNewAnalysis(
                sName
                , sDescription
                , GetTypeByGuid(new Guid(sBoxId)) as BoxProperties
                , GetTypeByGuid(new Guid(sPalletId)) as PalletProperties
                , string.IsNullOrEmpty(sInterlayerId) ? null : GetTypeByGuid(new Guid(sInterlayerId)) as InterlayerProperties
                , constraintSet);
            // set solution list
            analysis.Solutions = solutions;
        }
        ConstraintSet LoadConstraintSet(XmlElement eltConstraintSet)
        {
            ConstraintSet constraints = new ConstraintSet();
            return constraints;
        }

        Solution LoadSolution(XmlElement eltSolution)
        {
            string stitle = eltSolution.Attributes["Title"].Value;
            Solution sol = new Solution(stitle, true);

            if (eltSolution.HasAttribute("HomogeneousLayers"))
            {
                string sHomogeneousLayers = eltSolution.Attributes["HomogeneousLayers"].Value;
                sol.HasHomogeneousLayers = string.Equals(sHomogeneousLayers, "true", StringComparison.CurrentCultureIgnoreCase);
            }
            else
                sol.HasHomogeneousLayers = false;

            XmlElement eltLayers = eltSolution.ChildNodes[0] as XmlElement;
            foreach (XmlNode nodeLayer in eltLayers.ChildNodes)
                sol.Add( LoadLayer(nodeLayer as XmlElement));
            return sol;
        }

        ILayer LoadLayer(XmlElement eltLayer)
        {
            ILayer layer = null;
            double zLow = System.Convert.ToDouble(eltLayer.Attributes["ZLow"].Value);
            if (string.Equals(eltLayer.Name, "BoxLayer", StringComparison.CurrentCultureIgnoreCase))
            {
                BoxLayer boxLayer = new BoxLayer(zLow);
                foreach (XmlNode nodeBoxPosition in eltLayer.ChildNodes)
                {

                    XmlElement eltBoxPosition = nodeBoxPosition as XmlElement;
                    string sPosition = eltBoxPosition.Attributes["Position"].Value;
                    string sAxisLength = eltBoxPosition.Attributes["AxisLength"].Value;
                    string sAxisWidth = eltBoxPosition.Attributes["AxisWidth"].Value;
                    boxLayer.AddPosition(Vector3D.Parse(sPosition), HalfAxis.Parse(sAxisLength), HalfAxis.Parse(sAxisWidth));
                }
                layer = boxLayer;
            }
            else if (string.Equals(eltLayer.Name, "InterLayer", StringComparison.CurrentCultureIgnoreCase))
                layer = new InterlayerPos(zLow);

            return layer;
        }
        #endregion

        #region Save methods
        public void Save()
        {
            // get a valid file path
            if ( string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath) )
            {
                SaveFileDialog form = new SaveFileDialog();
                form.FileName = _name + ".stb";
                form.Filter = "StackBuilder files (*.stb)|*.stb|All files (*.*)|*.*";
                if (DialogResult.OK == form.ShowDialog())
                    _filePath = form.FileName;
                else
                    return;
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                // let's add the XML declaration section
                XmlNode xmlnode = xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                xmlDoc.AppendChild(xmlnode);
                // create Document (root) element
                XmlElement xmlRootElement = xmlDoc.CreateElement("Document");
                xmlDoc.AppendChild(xmlRootElement);
                // name
                XmlAttribute xmlDocNameAttribute = xmlDoc.CreateAttribute("Name");
                xmlDocNameAttribute.Value = _name;
                xmlRootElement.Attributes.Append(xmlDocNameAttribute);
                // description
                XmlAttribute xmlDocDescAttribute = xmlDoc.CreateAttribute("Description");
                xmlDocDescAttribute.Value = _description;
                xmlRootElement.Attributes.Append(xmlDocDescAttribute);
                // author
                XmlAttribute xmlDocAuthorAttribute = xmlDoc.CreateAttribute("Author");
                xmlDocAuthorAttribute.Value = _author;
                xmlRootElement.Attributes.Append(xmlDocAuthorAttribute);
                // dateCreated
                XmlAttribute xmlDateCreatedAttribute = xmlDoc.CreateAttribute("DateCreated");
                xmlDateCreatedAttribute.Value = string.Format("{0}", _dateCreated);
                xmlRootElement.Attributes.Append(xmlDateCreatedAttribute);
                // create ItemProperties element
                XmlElement xmlItemPropertiesElt = xmlDoc.CreateElement("ItemProperties");
                xmlRootElement.AppendChild(xmlItemPropertiesElt);
                foreach (ItemProperties itemProperties in _typeList)
                {
                    BoxProperties boxProperties = itemProperties as BoxProperties;
                    if (null != boxProperties)
                        Save(boxProperties, xmlItemPropertiesElt, xmlDoc);
                    PalletProperties palletProperties = itemProperties as PalletProperties;
                    if (null != palletProperties)
                        Save(palletProperties, xmlItemPropertiesElt, xmlDoc);
                    InterlayerProperties interlayerProperties = itemProperties as InterlayerProperties;
                    if (null != interlayerProperties)
                        Save(interlayerProperties, xmlItemPropertiesElt, xmlDoc);
                    BundleProperties bundleProperties = itemProperties as BundleProperties;
                    if (null != bundleProperties)
                        Save(bundleProperties, xmlItemPropertiesElt, xmlDoc);
                    TruckProperties truckProperties = itemProperties as TruckProperties;
                    if (null != truckProperties)
                        Save(truckProperties, xmlItemPropertiesElt, xmlDoc);
                }

                // create Analyses element
                XmlElement xmlAnalysesElt = xmlDoc.CreateElement("Analyses");
                xmlRootElement.AppendChild(xmlAnalysesElt);
                foreach (Analysis analysis in _analyses)
                {
                    Save(analysis, xmlAnalysesElt, xmlDoc);            
                }
                xmlDoc.Save(_filePath);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        public void Save(BoxProperties boxProperties, XmlElement parentElement, XmlDocument xmlDoc)
        {
            // create xmlBoxProperties element
            XmlElement xmlBoxProperties = xmlDoc.CreateElement("BoxProperties");
            parentElement.AppendChild(xmlBoxProperties);
            // Id
            XmlAttribute guidAttribute = xmlDoc.CreateAttribute("Id");
            guidAttribute.Value = boxProperties.Guid.ToString();
            xmlBoxProperties.Attributes.Append(guidAttribute);
            // name
            XmlAttribute nameAttribute = xmlDoc.CreateAttribute("Name");
            nameAttribute.Value = boxProperties.Name;
            xmlBoxProperties.Attributes.Append(nameAttribute);
            // description
            XmlAttribute descAttribute = xmlDoc.CreateAttribute("Description");
            descAttribute.Value = boxProperties.Description;
            xmlBoxProperties.Attributes.Append(descAttribute);
            // length
            XmlAttribute lengthAttribute = xmlDoc.CreateAttribute("Length");
            lengthAttribute.Value = string.Format("{0}", boxProperties.Length);
            xmlBoxProperties.Attributes.Append(lengthAttribute);
            // width
            XmlAttribute widthAttribute = xmlDoc.CreateAttribute("Width");
            widthAttribute.Value = string.Format("{0}", boxProperties.Width);
            xmlBoxProperties.Attributes.Append(widthAttribute);
            // height
            XmlAttribute heightAttribute = xmlDoc.CreateAttribute("Height");
            heightAttribute.Value = string.Format("{0}", boxProperties.Height);
            xmlBoxProperties.Attributes.Append(heightAttribute);
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("Weight");
            weightAttribute.Value = string.Format("{0}", boxProperties.Weight);
            xmlBoxProperties.Attributes.Append(weightAttribute);
            // face colors
            XmlElement xmlFaceColors = xmlDoc.CreateElement("FaceColors");
            xmlBoxProperties.AppendChild(xmlFaceColors);
            short i = 0;
            foreach (Color color in boxProperties.Colors)
            {
                XmlElement xmlFaceColor = xmlDoc.CreateElement("FaceColor");
                xmlFaceColors.AppendChild(xmlFaceColor);
                // face index
                XmlAttribute xmlFaceIndex = xmlDoc.CreateAttribute("FaceIndex");
                xmlFaceIndex.Value = string.Format("{0}", i);
                xmlFaceColor.Attributes.Append(xmlFaceIndex);
                // color
                XmlAttribute xmlColor = xmlDoc.CreateAttribute("Color");
                xmlColor.Value = string.Format("{0}", color.ToArgb());
                xmlFaceColor.Attributes.Append(xmlColor);
                ++i;
            }
            // textures
            XmlElement xmlTexturesElement = xmlDoc.CreateElement("Textures");
            xmlBoxProperties.AppendChild(xmlTexturesElement);
        }
        public void Save(PalletProperties palletProperties, XmlElement parentElement, XmlDocument xmlDoc)
        {
            // create xmlPalletProperties element
            XmlElement xmlPalletProperties = xmlDoc.CreateElement("PalletProperties");
            parentElement.AppendChild(xmlPalletProperties);
            // Id
            XmlAttribute guidAttribute = xmlDoc.CreateAttribute("Id");
            guidAttribute.Value = palletProperties.Guid.ToString();
            xmlPalletProperties.Attributes.Append(guidAttribute);
            // name
            XmlAttribute nameAttribute = xmlDoc.CreateAttribute("Name");
            nameAttribute.Value = palletProperties.Name;
            xmlPalletProperties.Attributes.Append(nameAttribute);
            // description
            XmlAttribute descAttribute = xmlDoc.CreateAttribute("Description");
            descAttribute.Value = palletProperties.Description;
            xmlPalletProperties.Attributes.Append(descAttribute);
            // length
            XmlAttribute lengthAttribute = xmlDoc.CreateAttribute("Length");
            lengthAttribute.Value = string.Format("{0}", palletProperties.Length);
            xmlPalletProperties.Attributes.Append(lengthAttribute);
            // width
            XmlAttribute widthAttribute = xmlDoc.CreateAttribute("Width");
            widthAttribute.Value = string.Format("{0}", palletProperties.Width);
            xmlPalletProperties.Attributes.Append(widthAttribute);
            // height
            XmlAttribute heightAttribute = xmlDoc.CreateAttribute("Height");
            heightAttribute.Value = string.Format("{0}", palletProperties.Height);
            xmlPalletProperties.Attributes.Append(heightAttribute);
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("Weight");
            weightAttribute.Value = string.Format("{0}", palletProperties.Weight);
            xmlPalletProperties.Attributes.Append(weightAttribute);
            // admissible load weight
            XmlAttribute admLoadWeightAttribute = xmlDoc.CreateAttribute("AdmissibleLoadWeight");
            admLoadWeightAttribute.Value = string.Format("{0}", palletProperties.AdmissibleLoadWeight);
            xmlPalletProperties.Attributes.Append(admLoadWeightAttribute);
            // admissible load height
            XmlAttribute admLoadHeightAttribute = xmlDoc.CreateAttribute("AdmissibleLoadHeight");
            admLoadHeightAttribute.Value = string.Format("{0}", palletProperties.AdmissibleLoadHeight);
            xmlPalletProperties.Attributes.Append(admLoadHeightAttribute);
            // type
            XmlAttribute typeAttribute = xmlDoc.CreateAttribute("Type");
            typeAttribute.Value = string.Format("{0}", (int)palletProperties.Type);
            xmlPalletProperties.Attributes.Append(typeAttribute);
            // color
            XmlAttribute colorAttribute = xmlDoc.CreateAttribute("Color");
            colorAttribute.Value = string.Format("{0}", palletProperties.Color.ToArgb());
            xmlPalletProperties.Attributes.Append(colorAttribute);
        }
        public void Save(InterlayerProperties interlayerProperties, XmlElement parentElement, XmlDocument xmlDoc)
        {
            // create xmlPalletProperties element
            XmlElement xmlInterlayerProperties = xmlDoc.CreateElement("InterlayerProperties");
            parentElement.AppendChild(xmlInterlayerProperties);
            // Id
            XmlAttribute guidAttribute = xmlDoc.CreateAttribute("Id");
            guidAttribute.Value = interlayerProperties.Guid.ToString();
            xmlInterlayerProperties.Attributes.Append(guidAttribute);
            // name
            XmlAttribute nameAttribute = xmlDoc.CreateAttribute("Name");
            nameAttribute.Value = interlayerProperties.Name;
            xmlInterlayerProperties.Attributes.Append(nameAttribute);
            // description
            XmlAttribute descAttribute = xmlDoc.CreateAttribute("Description");
            descAttribute.Value = interlayerProperties.Description;
            xmlInterlayerProperties.Attributes.Append(descAttribute);
            // length
            XmlAttribute lengthAttribute = xmlDoc.CreateAttribute("Length");
            lengthAttribute.Value = string.Format("{0}", interlayerProperties.Length);
            xmlInterlayerProperties.Attributes.Append(lengthAttribute);
            // width
            XmlAttribute widthAttribute = xmlDoc.CreateAttribute("Width");
            widthAttribute.Value = string.Format("{0}", interlayerProperties.Width);
            xmlInterlayerProperties.Attributes.Append(widthAttribute);
            // height
            XmlAttribute heightAttribute = xmlDoc.CreateAttribute("Thickness");
            heightAttribute.Value = string.Format("{0}", interlayerProperties.Thickness);
            xmlInterlayerProperties.Attributes.Append(heightAttribute);
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("Weight");
            weightAttribute.Value = string.Format("{0}", interlayerProperties.Weight);
            xmlInterlayerProperties.Attributes.Append(weightAttribute);
            // color
            XmlAttribute colorAttribute = xmlDoc.CreateAttribute("Color");
            colorAttribute.Value = string.Format("{0}", interlayerProperties.Color.ToArgb());
            xmlInterlayerProperties.Attributes.Append(colorAttribute);
        }
        public void Save(BundleProperties bundleProperties, XmlElement parentElement, XmlDocument xmlDoc)
        {
            // create xmlPalletProperties element
            XmlElement xmlInterlayerProperties = xmlDoc.CreateElement("BundleProperties");
            parentElement.AppendChild(xmlInterlayerProperties);
            // Id
            XmlAttribute guidAttribute = xmlDoc.CreateAttribute("Id");
            guidAttribute.Value = bundleProperties.Guid.ToString();
            xmlInterlayerProperties.Attributes.Append(guidAttribute);
            // name
            XmlAttribute nameAttribute = xmlDoc.CreateAttribute("Name");
            nameAttribute.Value = bundleProperties.Name;
            xmlInterlayerProperties.Attributes.Append(nameAttribute);
            // description
            XmlAttribute descAttribute = xmlDoc.CreateAttribute("Description");
            descAttribute.Value = bundleProperties.Description;
            xmlInterlayerProperties.Attributes.Append(descAttribute);
            // length
            XmlAttribute lengthAttribute = xmlDoc.CreateAttribute("Length");
            lengthAttribute.Value = string.Format("{0}", bundleProperties.Length);
            xmlInterlayerProperties.Attributes.Append(lengthAttribute);
            // width
            XmlAttribute widthAttribute = xmlDoc.CreateAttribute("Width");
            widthAttribute.Value = string.Format("{0}", bundleProperties.Width);
            xmlInterlayerProperties.Attributes.Append(widthAttribute);
            // height
            XmlAttribute heightAttribute = xmlDoc.CreateAttribute("UnitThickness");
            heightAttribute.Value = string.Format("{0}", bundleProperties.UnitThickness);
            xmlInterlayerProperties.Attributes.Append(heightAttribute);
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("UnitWeight");
            weightAttribute.Value = string.Format("{0}", bundleProperties.UnitWeight);
            xmlInterlayerProperties.Attributes.Append(weightAttribute);
            // color
            XmlAttribute colorAttribute = xmlDoc.CreateAttribute("Color");
            colorAttribute.Value = string.Format("{0}", bundleProperties.Color.ToArgb());
            xmlInterlayerProperties.Attributes.Append(colorAttribute);
            // numberFlats
            XmlAttribute numberFlatsAttribute = xmlDoc.CreateAttribute("NumberFlats");
            numberFlatsAttribute.Value = string.Format("{0}", bundleProperties.NoFlats);
            xmlInterlayerProperties.Attributes.Append(numberFlatsAttribute);

        }
        public void Save(TruckProperties truckProperties, XmlElement parentElement, XmlDocument xmlDoc)
        { 
        }
        public void Save(Analysis analysis, XmlElement parentElement, XmlDocument xmlDoc)
        {
            // create analysis element
            XmlElement xmlAnalysisElt = xmlDoc.CreateElement("AnalysisPallet");
            parentElement.AppendChild(xmlAnalysisElt);
            // Name
            XmlAttribute analysisNameAttribute = xmlDoc.CreateAttribute("Name");
            analysisNameAttribute.Value = analysis.Name;
            xmlAnalysisElt.Attributes.Append(analysisNameAttribute);
            // Description
            XmlAttribute analysisDescriptionAttribute = xmlDoc.CreateAttribute("Description");
            analysisDescriptionAttribute.Value = analysis.Description;
            xmlAnalysisElt.Attributes.Append(analysisDescriptionAttribute);
            // BoxId
            XmlAttribute boxIdAttribute = xmlDoc.CreateAttribute("BoxId");
            boxIdAttribute.Value = string.Format("{0}", analysis.BoxProperties.Guid);
            xmlAnalysisElt.Attributes.Append(boxIdAttribute);
            // PalletId
            XmlAttribute palletIdAttribute = xmlDoc.CreateAttribute("PalletId");
            palletIdAttribute.Value = string.Format("{0}", analysis.PalletProperties.Guid);
            xmlAnalysisElt.Attributes.Append(palletIdAttribute);
            // InterlayerId
            if (null != analysis.InterlayerProperties)
            {
                XmlAttribute interlayerIdAttribute = xmlDoc.CreateAttribute("InterlayerId");
                interlayerIdAttribute.Value = string.Format("{0}", analysis.InterlayerProperties.Guid);
                xmlAnalysisElt.Attributes.Append(interlayerIdAttribute);
            }
            // ConstraintSet
            XmlElement constraintSetElement = xmlDoc.CreateElement("ConstraintSet");
            xmlAnalysisElt.AppendChild(constraintSetElement);

            // Solutions
            XmlElement solutionsElt = xmlDoc.CreateElement("Solutions");
            xmlAnalysisElt.AppendChild(solutionsElt);
            foreach (Solution sol in analysis.Solutions)
            {
                // Solution
                XmlElement solutionElt = xmlDoc.CreateElement("Solution");
                solutionsElt.AppendChild(solutionElt);
                // title
                XmlAttribute titleAttribute = xmlDoc.CreateAttribute("Title");
                titleAttribute.Value = sol.Title;
                solutionElt.Attributes.Append(titleAttribute);
                // homogeneousLayers ?
                XmlAttribute homogeneousLayersAttribute = xmlDoc.CreateAttribute("HomogeneousLayers");
                homogeneousLayersAttribute.Value = sol.HasHomogeneousLayers ? "true" : "false";
                solutionElt.Attributes.Append(homogeneousLayersAttribute);
                // layers
                XmlElement layersElt = xmlDoc.CreateElement("Layers");
                solutionElt.AppendChild(layersElt);
                foreach (ILayer layer in sol)
                {
                    BoxLayer boxLayer = layer as BoxLayer;
                    if (null != boxLayer)
                    {
                        // BoxLayer
                        XmlElement boxlayerElt = xmlDoc.CreateElement("BoxLayer");
                        layersElt.AppendChild(boxlayerElt);
                        // ZLow
                        XmlAttribute zlowAttribute = xmlDoc.CreateAttribute("ZLow");
                        zlowAttribute.Value = string.Format("{0}", boxLayer.ZLow);
                        boxlayerElt.Attributes.Append(zlowAttribute);
                        foreach (BoxPosition boxPosition in boxLayer)
                        {
                            // BoxPosition
                            XmlElement boxPositionElt = xmlDoc.CreateElement("BoxPosition");
                            boxlayerElt.AppendChild(boxPositionElt);
                            // Position
                            XmlAttribute positionAttribute = xmlDoc.CreateAttribute("Position");
                            positionAttribute.Value = boxPosition.Position.ToString();
                            boxPositionElt.Attributes.Append(positionAttribute);
                            // AxisLength
                            XmlAttribute axisLengthAttribute = xmlDoc.CreateAttribute("AxisLength");
                            axisLengthAttribute.Value = AxisToEnum(boxPosition.DirectionLength);
                            boxPositionElt.Attributes.Append(axisLengthAttribute);
                            // AxisWidth
                            XmlAttribute axisWidthAttribute = xmlDoc.CreateAttribute("AxisWidth");
                            axisWidthAttribute.Value = AxisToEnum(boxPosition.DirectionWidth);
                            boxPositionElt.Attributes.Append(axisWidthAttribute);
                        }
                    }
                    InterlayerPos interlayerPos = layer as InterlayerPos;
                    if (null != interlayerPos)
                    {
                        // Interlayer
                        XmlElement interlayerElt = xmlDoc.CreateElement("Interlayer");
                        layersElt.AppendChild(interlayerElt);
                        // ZLow
                        XmlAttribute zlowAttribute = xmlDoc.CreateAttribute("ZLow");
                        zlowAttribute.Value = string.Format("{0}", interlayerPos.ZLow);
                        interlayerElt.Attributes.Append(zlowAttribute);
                    }
                }
            }
        }
        private string AxisToEnum(HalfAxis.HAxis axis)
        {
            switch (axis)
            {
                case HalfAxis.HAxis.AXIS_X_N: return "XN";
                case HalfAxis.HAxis.AXIS_X_P: return "XP";
                case HalfAxis.HAxis.AXIS_Y_N: return "YN";
                case HalfAxis.HAxis.AXIS_Y_P: return "YP";
                case HalfAxis.HAxis.AXIS_Z_N: return "ZN";
                default: return "ZP";
            }
        }
        #endregion

        #region Helpers
        private ItemProperties GetTypeByGuid(Guid guid)
        {
            foreach (ItemProperties type in _typeList)
                if (type.Guid == guid)
                    return type;
            throw new Exception(string.Format("No type with Guid = {0}", guid.ToString()));
        }
        #endregion

        #region Listener related methods
        public void AddListener(IDocumentListener listener)
        {
            _listeners.Add(listener);
            listener.OnNewDocument(this);
        }
        private void NotifyOnNewTypeCreated(ItemProperties itemProperties)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewTypeCreated(this, itemProperties);
        }
        private void NotifyOnNewAnalysisCreated(Analysis analysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewAnalysisCreated(this, analysis);
        }
        #endregion
    }
    #endregion
}
