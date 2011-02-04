#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.ComponentModel;

using TreeDim.StackBuilder.Basics;

using Sharp3D.Math.Core;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region IDocumentListener
    /// <summary>
    /// Listener class that is notified when the document is modified
    /// </summary>
    public interface IDocumentListener
    {
        // new
        void OnNewDocument(Document doc);
        void OnNewTypeCreated(Document doc, ItemBase itemBase);
        void OnNewAnalysisCreated(Document doc, Analysis analysis);
        void OnNewCaseAnalysisCreated(Document doc, CaseAnalysis caseAnalysis);
        void OnNewSolutionAdded(Document doc, Analysis analysis, SelSolution selectedSolution);
        void OnNewTruckAnalysisCreated(Document doc, Analysis analysis, SelSolution selSolution, TruckAnalysis truckAnalysis);
        // remove
        void OnTypeRemoved(Document doc, ItemBase itemBase);
        void OnAnalysisRemoved(Document doc, Analysis analysis);
        void OnCaseAnalysisRemoved(Document doc, CaseAnalysis caseAnalysis);
        void OnSolutionRemoved(Document doc, Analysis analysis, SelSolution selectedSolution);
        void OnTruckAnalysisRemoved(Document doc, Analysis analysis, SelSolution selSolution, TruckAnalysis truckAnalysis);

        // close
        void OnDocumentClosed(Document doc);
    }
    #endregion

    #region Document
    /// <summary>
    /// Classes that encapsulates data
    /// The application is MDI and might host several Document instance
    /// </summary>
    public class Document
    {
        #region Data members
        private string _name, _description, _author;
        private DateTime _dateCreated;
        private List<ItemBase> _typeList = new List<ItemBase>();
        private List<Analysis> _analyses = new List<Analysis>();
        private List<CaseAnalysis> _caseAnalyses = new List<CaseAnalysis>();
        private List<IDocumentListener> _listeners = new List<IDocumentListener>();
        protected static readonly ILog _log = LogManager.GetLogger(typeof(Document));
        #endregion

        #region Constructor
        public Document(string filePath, IDocumentListener listener)
        {
            // set name from file path
            _name = Path.GetFileNameWithoutExtension(filePath);
            if (null != listener)
            {
                // add listener
                AddListener(listener);
                // notify listener of document creation
                listener.OnNewDocument(this);
            }
            // load file
            Load(filePath);            
            // rechange name to match filePath
            _name = Path.GetFileNameWithoutExtension(filePath);
        }

        public Document(string name, string description, string author, DateTime dateCreated, IDocumentListener listener)
        {
            _name = name;
            _description = description;
            _author = author;
            _dateCreated = dateCreated;
            if (null != listener)
            {
                // add listener
                AddListener(listener);
                // notify listener of document creation
                listener.OnNewDocument(this);
            }
        }
        #endregion

        #region Public instantiation methods
        /// <summary>
        /// Create a new box
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="description">Description</param>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="weight">Weight</param>
        /// <param name="colors">Name</param>
        /// <returns>created BoxProperties instance</returns>
        public BoxProperties CreateNewBox(
            string name, string description
            , double length, double width, double height
            , double weight
            , Color[] colors)
        {
            // instantiate and initialize
            BoxProperties boxProperties = new BoxProperties(this, length, width, height);
            boxProperties.Weight = weight;
            boxProperties.Name = name;
            boxProperties.Description = description;
            boxProperties.SetAllColors(colors);
            // insert in list
            _typeList.Add(boxProperties);
            // notify listeners
            NotifyOnNewTypeCreated(boxProperties);
            Modify();
            return boxProperties;
        }
        /// <summary>
        /// Create a new case
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="insideLength"></param>
        /// <param name="insideWidth"></param>
        /// <param name="insideHeight"></param>
        /// <param name="weight"></param>
        /// <param name="colors"></param>
        /// <returns></returns>
        public BoxProperties CreateNewCase(
            string name, string description
            , double length, double width, double height
            , double insideLength, double insideWidth, double insideHeight
            , double weight
            , Color[] colors)
        {
            // instantiate and initialize
            BoxProperties boxProperties = new BoxProperties(this, length, width, height, insideLength, insideWidth, insideHeight);
            boxProperties.Weight = weight;
            boxProperties.Name = name;
            boxProperties.Description = description;
            boxProperties.SetAllColors(colors);
            // insert in list
            _typeList.Add(boxProperties);
            // notify listeners
            NotifyOnNewTypeCreated(boxProperties);
            Modify();
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
            BundleProperties bundle = new BundleProperties(this, name, description, length, width, thickness, weight, noFlats, color);
            // insert in list
            _typeList.Add(bundle);
            // notify listeners
            NotifyOnNewTypeCreated(bundle);
            Modify();
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
                this, name, description
                , length, width, thickness
                , weight, color);
            // insert in list
            _typeList.Add(interlayer);
            // notify listeners
            NotifyOnNewTypeCreated(interlayer);
            Modify();
            return interlayer;
        }

        public PalletProperties CreateNewPallet(
            string name, string description
            , PalletProperties.PalletType type
            , double length, double width, double height
            , double weight)
        {
            PalletProperties palletProperties = new PalletProperties(this, type, length, width, height);
            palletProperties.Name = name;
            palletProperties.Description = description;
            palletProperties.Weight = weight;
            // insert in list
            _typeList.Add(palletProperties);
            // notify listeners
            NotifyOnNewTypeCreated(palletProperties);
            Modify();
            return palletProperties;
        }
        /// <summary>
        /// Creates a new truck in this document
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="description">Description</param>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="admissibleLoadWeight">AdmissibleLoadWeight</param>
        /// <param name="color">Color</param>
        /// <returns>TruckProperties</returns>
        public TruckProperties CreateNewTruck(
            string name, string description
            , double length
            , double width
            , double height
            , double admissibleLoadWeight
            , Color color)
        {
            TruckProperties truckProperties = new TruckProperties(this, length, width, height);
            truckProperties.Name = name;
            truckProperties.Description = description;
            truckProperties.AdmissibleLoadWeight = admissibleLoadWeight;
            truckProperties.Color = color;
            // insert in list
            _typeList.Add(truckProperties);
            // notify listeners
            NotifyOnNewTypeCreated(truckProperties);
            Modify();
            return truckProperties;
        }
        /// <summary>
        /// Creates a new analysis in this document + compute solutions
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="box"></param>
        /// <param name="pallet"></param>
        /// <param name="interlayer"></param>
        /// <param name="constraintSet"></param>
        /// <param name="solver">Node : analysis creation requires a solver</param>
        /// <returns>An analysis</returns>
        public Analysis CreateNewAnalysis(
            string name, string description
            , BProperties box, PalletProperties pallet, InterlayerProperties interlayer
            , ConstraintSet constraintSet
            , IAnalysisSolver solver)
        {
            Analysis analysis = new Analysis(box, pallet, interlayer, constraintSet);
            analysis.Name = name;
            analysis.Description = description;
            // insert in list
            _analyses.Add(analysis);
            // compute analysis
            solver.ProcessAnalysis(analysis);
            if (analysis.Solutions.Count < 1)
            {	// remove analysis from list if it has no valid solution
                _analyses.Remove(analysis);
                return null;
            }
            // notify listeners
            NotifyOnNewAnalysisCreated(analysis);
            Modify();
            return analysis;
        }
        /// <summary>
        /// Creates a new analysis without generating solutions
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="box"></param>
        /// <param name="pallet"></param>
        /// <param name="interlayer"></param>
        /// <param name="constraintSet"></param>
        /// <param name="solutions"></param>
        /// <returns></returns>
        public Analysis CreateNewAnalysis(
            string name, string description
            , BProperties box, PalletProperties pallet, InterlayerProperties interlayer
            , ConstraintSet constraintSet
            , List<Solution> solutions)
        {
            Analysis analysis = new Analysis(box, pallet, interlayer, constraintSet);
            analysis.Name = name;
            analysis.Description = description;
            // insert in list
            _analyses.Add(analysis);
            // set solutions
            analysis.Solutions = solutions;
            // notify listeners
            NotifyOnNewAnalysisCreated(analysis);
            return analysis;
        }

        public CaseAnalysis CreateNewCaseAnalysis(
            string name, string description
            , BoxProperties bProperties
            , CaseConstraintSet constraintSet
            , List<PalletSolutionDesc> palletSolutionList
            , ICaseAnalysisSolver solver)
        {
            CaseAnalysis caseAnalysis = new CaseAnalysis(bProperties, palletSolutionList, constraintSet);
            caseAnalysis.Name = name;
            caseAnalysis.Description = description;
            // insert in list
            _caseAnalyses.Add(caseAnalysis);
            // compute analysis
            if (null != solver)
            {
                solver.ProcessAnalysis(caseAnalysis);
                if (caseAnalysis.Solutions.Count < 1)
                {	// remove analysis from list if it has no valid solution
                    _caseAnalyses.Remove(caseAnalysis);
                    return null;
                }
            }
            // notify listeners
            NotifyOnNewCaseAnalysisCreated(caseAnalysis);
            Modify();
            return caseAnalysis;
        }
        
        public void RemoveItem(ItemBase item)
        {
            // sanity check
            if (null == item)
            {
                Debug.Assert(false);
                return;
            }
            // dispose item first as it may remove dependancies itself
            _log.Debug(string.Format("Disposing {0}...", item.Name));
            item.Dispose();

            // notify listeners / remove
            if (item.GetType() == typeof(BoxProperties)
                || item.GetType() == typeof(BundleProperties)
                || item.GetType() == typeof(PalletProperties)
                || item.GetType() == typeof(InterlayerProperties)
                || item.GetType() == typeof(TruckProperties))
            {
                NotifyOnTypeRemoved(item);
                if (!_typeList.Remove(item))
                    _log.Warn(string.Format("Failed to properly remove item {0}", item.Name));
            }
            else if (item.GetType() == typeof(Analysis))
            {
                NotifyOnAnalysisRemoved(item as Analysis);
                if (!_analyses.Remove(item as Analysis))
                    _log.Warn(string.Format("Failed to properly remove analysis {0}", item.Name));
            }
            else if (item.GetType() == typeof(SelSolution))
            {
                SelSolution selSol = item as SelSolution;
                NotifyOnSolutionRemoved(selSol.Analysis, selSol);
            }
            else if (item.GetType() == typeof(TruckAnalysis))
            {
                TruckAnalysis truckAnalysis = item as TruckAnalysis;
                NotifyOnTruckAnalysisRemoved(truckAnalysis.ParentSelSolution, truckAnalysis);
            }
            else if (item.GetType() == typeof(CaseAnalysis))
            {
                CaseAnalysis caseAnalysis = item as CaseAnalysis;
                NotifyOnCaseAnalysisRemoved(caseAnalysis);
                if (!_caseAnalyses.Remove(caseAnalysis))
                    _log.Warn(string.Format("Failed to properly remove analysis {0}", item.Name));
            }
            else
                Debug.Assert(false);
            Modify();
        }
        #endregion

        #region Name methods
        public bool IsValidNewTypeName(string name, ItemBase itemToName)
        { 
            // make sure is not empty
            if (name.Trim() == string.Empty)
                return false;            
            // make sure that name is not already used
            foreach (ItemBase item in _typeList)
            {
                if (item == itemToName)
                    continue;
                if (item.Name.Trim().ToLower() == name.Trim().ToLower())
                    return false;
            }
            // success
            return true;
        }
        public bool IsValidNewAnalysisName(string name, ItemBase analysisToRename)
        {
            // make sure is not empty
            if (name.Trim() == string.Empty)
                return false;
            // make sure that name is not already used
            foreach (ItemBase item in _analyses)
            {
                if (item == analysisToRename)
                    continue;
                if (item.Name.Trim().ToLower() == name.Trim().ToLower())
                    return false;
            }
            foreach (ItemBase item in _caseAnalyses)
            {
                if (item == analysisToRename)
                    continue;
                if (item.Name.Trim().ToLower() == name.Trim().ToLower())
                    return false;
            }
            // success
            return true;
        }
        #endregion

        #region Public properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public DateTime DateOfCreation
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }
        /// <summary>
        /// Builds and returns a list of boxes
        /// </summary>
        public List<BoxProperties> Boxes
        {
            get
            {
                List<BoxProperties> boxList = new List<BoxProperties>();
                foreach (ItemBase item in _typeList)
                {
                    BoxProperties boxProperties = item as BoxProperties;
                    if (null != boxProperties && !boxProperties.HasInsideDimensions)
                        boxList.Add(boxProperties);                        
                }
                return boxList;
            }
        }
        /// <summary>
        /// Builds and returns a list of cases
        /// </summary>
        public List<BoxProperties> Cases
        {
            get
            {
                List<BoxProperties> caseList = new List<BoxProperties>();
                foreach (ItemBase item in _typeList)
                {
                    BoxProperties boxProperties = item as BoxProperties;
                    if (null != boxProperties && boxProperties.HasInsideDimensions)
                        caseList.Add(boxProperties);
                }
                return caseList;
            }
        }
        /// <summary>
        /// Builds and returns a list of bundles
        /// </summary>
        public List<BundleProperties> Bundles
        {
            get
            {
                List<BundleProperties> bundleList = new List<BundleProperties>();
                foreach (ItemBase item in _typeList)
                {
                    BundleProperties bundleProperties = item as BundleProperties;
                    if (null != bundleProperties)
                        bundleList.Add(bundleProperties); 
                }
                return bundleList;
            }
        }
        public List<PalletProperties> Pallets
        {
            get
            {
                List<PalletProperties> palletList = new List<PalletProperties>();
                foreach (ItemBase item in _typeList)
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
                foreach (ItemBase item in _typeList)
                {
                    InterlayerProperties interlayerProperties = item as InterlayerProperties;
                    if (null != interlayerProperties)
                        interlayerList.Add(interlayerProperties);
                }
                return interlayerList;
            }
        }

        public List<TruckProperties> Trucks
        {
            get
            {
                List<TruckProperties> truckPropertiesList = new List<TruckProperties>();
                foreach (ItemBase item in _typeList)
                {
                    TruckProperties truckProperties = item as TruckProperties;
                    if (null != truckProperties)
                        truckPropertiesList.Add(truckProperties);
                }
                return truckPropertiesList;
            }
        }

        public List<Analysis> Analyses
        {
            get { return _analyses; }
        }

        /// <summary>
        /// Returns true if pallet analysis can be created i.e. if documents contains at list a case and a pallet
        /// </summary>
        public bool CanCreatePalletAnalysis
        { get { return this.Cases.Count > 0 && this.Pallets.Count > 0; } }
        /// <summary>
        /// Returns true if a bundle analysis can be created i.e. if documents contains at list a bundle and a case
        /// </summary>
        public bool CanCreateBundleAnalysis
        { get { return this.Bundles.Count > 0 && this.Pallets.Count > 0; } }
        /// <summary>
        /// Returns true if a case analysis can be created i.e. if documents contains at list a box and pallet solutions database is not empty
        /// </summary>
        public bool CanCreateCaseAnalysis
        { get { return this.Boxes.Count > 0 && !PalletSolutionDatabase.Instance.IsEmpty; } }
        #endregion

        #region Load methods
        public void Load(string filePath)
        {
            try
            {
                // instantiate XmlDocument
                XmlDocument xmlDoc = new XmlDocument();
                // load xml file in document and parse document
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    xmlDoc.Load(fileStream);
                    XmlElement xmlRootElement = xmlDoc.DocumentElement;
                    LoadDocumentElement(xmlRootElement);
                }
            }
            catch (FileNotFoundException ex)
            {
                _log.Error("Caught FileNotFoundException in Document.Load() -> rethrowing...");
                throw ex;
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
            string sInsideLength = string.Empty, sInsideWidth = string.Empty, sInsideHeight = string.Empty;
            if (eltBoxProperties.HasAttribute("InsideLength"))
            {
                sInsideLength = eltBoxProperties.Attributes["InsideLength"].Value;
                sInsideWidth = eltBoxProperties.Attributes["InsideWidth"].Value;
                sInsideHeight = eltBoxProperties.Attributes["InsideHeight"].Value;
            }
            string sweight = eltBoxProperties.Attributes["Weight"].Value;

            bool hasInsideDimensions = eltBoxProperties.HasAttribute("InsideLength");
            if (hasInsideDimensions)
            { }

            Color[] colors = new Color[6];
            List<Pair<HalfAxis.HAxis, Texture>> listTexture = new List<Pair<HalfAxis.HAxis,Texture>>();
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
                else if (string.Equals(node.Name, "Textures", StringComparison.CurrentCultureIgnoreCase))
                {
                    XmlElement textureList = node as XmlElement;
                    foreach (XmlNode faceTextureNode in textureList.ChildNodes)
                    {
                        try
                        {
                            XmlElement xmlFaceTexture = faceTextureNode as XmlElement;
                            // face normal
                            HalfAxis.HAxis faceNormal = HalfAxis.Parse(xmlFaceTexture.Attributes["FaceNormal"].Value);
                            // position
                            Vector2D position = Vector2D.Parse(xmlFaceTexture.Attributes["Position"].Value);
                            // size
                            Vector2D size = Vector2D.Parse(xmlFaceTexture.Attributes["Size"].Value);
                            // angle
                            double angle = Convert.ToDouble(xmlFaceTexture.Attributes["Angle"].Value);
                            // bitmap
                            Bitmap bmp = Document.StringToBitmap(xmlFaceTexture.Attributes["Bitmap"].Value);
                            // add texture pair
                            listTexture.Add(new Pair<HalfAxis.HAxis, Texture>(faceNormal, new Texture(bmp, position, size, angle)));
                        }
                        catch (Exception ex)
                        {
                            _log.Error(ex.ToString());
                        }
                    }
                }
            }
            // create new BoxProperties instance
            BoxProperties boxProperties = null;
            if (!string.IsNullOrEmpty(sInsideLength)) // case
                boxProperties = CreateNewCase(
                sname
                , sdescription
                , System.Convert.ToDouble(slength)
                , System.Convert.ToDouble(swidth)
                , System.Convert.ToDouble(sheight)
                , System.Convert.ToDouble(sInsideLength)
                , System.Convert.ToDouble(sInsideWidth)
                , System.Convert.ToDouble(sInsideHeight)
                , System.Convert.ToDouble(sweight)
                , colors);
            else
                boxProperties = CreateNewBox(
                sname
                , sdescription
                , System.Convert.ToDouble(slength)
                , System.Convert.ToDouble(swidth)
                , System.Convert.ToDouble(sheight)
                , System.Convert.ToDouble(sweight)
                , colors);
            boxProperties.Guid = new Guid(sid);
            boxProperties.TextureList = listTexture;
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
                , System.Convert.ToDouble(sweight));
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
            string sid = eltBundleProperties.Attributes["Id"].Value;
            string sname = eltBundleProperties.Attributes["Name"].Value;
            string sdescription = eltBundleProperties.Attributes["Description"].Value;
            double length = double.Parse(eltBundleProperties.Attributes["Length"].Value);
            double width = double.Parse(eltBundleProperties.Attributes["Width"].Value);
            double unitThickness = double.Parse(eltBundleProperties.Attributes["UnitThickness"].Value);
            double unitWeight = double.Parse(eltBundleProperties.Attributes["UnitWeight"].Value);
            Color color = Color.FromArgb(Int32.Parse(eltBundleProperties.Attributes["Color"].Value));
            int noFlats = int.Parse(eltBundleProperties.Attributes["NumberFlats"].Value);
            BundleProperties bundleProperties = CreateNewBundle(
                sname
                , sdescription
                , length
                , width
                , unitThickness
                , unitWeight
                , color
                , noFlats);
            bundleProperties.Guid = new Guid(sid);
        }
        private void LoadTruckProperties(XmlElement eltTruckProperties)
        {
            string sid = eltTruckProperties.Attributes["Id"].Value;
            string sName = eltTruckProperties.Attributes["Name"].Value;
            string sDescription = eltTruckProperties.Attributes["Description"].Value;
            string slength = eltTruckProperties.Attributes["Length"].Value;
            string swidth = eltTruckProperties.Attributes["Width"].Value;
            string sheight = eltTruckProperties.Attributes["Height"].Value;
            string sadmissibleLoadWeight = eltTruckProperties.Attributes["AdmissibleLoadWeight"].Value;
            string sColor = eltTruckProperties.Attributes["Color"].Value;

            // create new truck
            TruckProperties truckProperties = CreateNewTruck(
                sName
                , sDescription
                , Convert.ToDouble(slength)
                , Convert.ToDouble(swidth)
                , Convert.ToDouble(sheight)
                , Convert.ToDouble(sadmissibleLoadWeight)
                , Color.FromArgb(System.Convert.ToInt32(sColor)));
            truckProperties.Guid = new Guid(sid);

        }
        private void LoadAnalysis(XmlElement eltAnalysis)
        {
            string sName = eltAnalysis.Attributes["Name"].Value;
            string sDescription = eltAnalysis.Attributes["Description"].Value;
            string sBoxId = eltAnalysis.Attributes["BoxId"].Value;
            string sInterlayerId = string.Empty;
            if (eltAnalysis.HasAttribute("InterlayerId"))
                sInterlayerId = eltAnalysis.Attributes["InterlayerId"].Value;

            if (string.Equals(eltAnalysis.Name, "AnalysisPallet", StringComparison.CurrentCultureIgnoreCase))
            {
                string sPalletId = eltAnalysis.Attributes["PalletId"].Value;

                // load constraint set / solution list
                ConstraintSet constraintSet = null;
                List<Solution> solutions = new List<Solution>();
                List<int> selectedIndices = new List<int>();

                foreach (XmlNode node in eltAnalysis.ChildNodes)
                {
                    // load constraint set
                    if (string.Equals(node.Name, "ConstraintSetBox", StringComparison.CurrentCultureIgnoreCase))
                        constraintSet = LoadConstraintSetBox(node as XmlElement);
                    else if (string.Equals(node.Name, "ConstraintSetBundle", StringComparison.CurrentCultureIgnoreCase))
                        constraintSet = LoadConstraintSetBundle(node as XmlElement);
                    // load solutions
                    else if (string.Equals(node.Name, "Solutions", StringComparison.CurrentCultureIgnoreCase))
                    {
                        int indexSol = 0;
                        foreach (XmlNode solutionNode in node.ChildNodes)
                        {
                            XmlElement eltSolution = solutionNode as XmlElement;
                            solutions.Add(LoadSolution(eltSolution));
                            // is solution selected ?
                            if (null != eltSolution.Attributes["Selected"] && "true" == eltSolution.Attributes["Selected"].Value)
                                selectedIndices.Add(indexSol);
                            ++indexSol;
                        }
                    }
                    if (null == constraintSet)
                        throw new Exception("Failed to load a valid ConstraintSet");
                }

                // instantiate analysis
                Analysis analysis = CreateNewAnalysis(
                    sName
                    , sDescription
                    , GetTypeByGuid(new Guid(sBoxId)) as BProperties
                    , GetTypeByGuid(new Guid(sPalletId)) as PalletProperties
                    , string.IsNullOrEmpty(sInterlayerId) ? null : GetTypeByGuid(new Guid(sInterlayerId)) as InterlayerProperties
                    , constraintSet
                    , solutions);
                // save selected solutions
                foreach (int indexSol in selectedIndices)
                    analysis.SelectSolutionByIndex(indexSol);


                // reprocess for truck analyses
                // Note : this is quite complicated, see later if it could be simplified 
                foreach (XmlNode node in eltAnalysis.ChildNodes)
                {
                    if (string.Equals(node.Name, "Solutions", StringComparison.CurrentCultureIgnoreCase))
                    {
                        int indexSol = 0;
                        foreach (XmlNode solutionNode in node.ChildNodes)
                        {
                            foreach (XmlNode solutionInnerNode in solutionNode.ChildNodes)
                            {
                                if (string.Equals("TruckAnalyses", solutionInnerNode.Name, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    XmlElement truckAnalysesElt = solutionInnerNode as XmlElement;
                                    foreach (XmlNode truckAnalysisNode in truckAnalysesElt.ChildNodes)
                                    {
                                        if (string.Equals("TruckAnalysis", truckAnalysisNode.Name, StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            XmlElement truckAnalysisElt = truckAnalysisNode as XmlElement;
                                            SelSolution selSolution = analysis.GetSelSolutionBySolutionIndex(indexSol);
                                            LoadTruckAnalysis(truckAnalysisElt, selSolution);
                                        }
                                    }
                                }
                            }
                            ++indexSol;
                        }
                    }
                }
            }
            else if (string.Equals(eltAnalysis.Name, "AnalysisCase", StringComparison.CurrentCultureIgnoreCase))
            {
                //string sCaseId = eltAnalysis.Attributes["CaseId"].Value;

                // load constraint set / pallet solutions descriptors / solution list
                CaseConstraintSet constraintSet = null;
                List<PalletSolutionDesc> palletSolutionDescriptors = new List<PalletSolutionDesc>();
                XmlElement caseSolutionsElt = null;

                // first
                foreach (XmlNode node in eltAnalysis.ChildNodes)
                {
                    // load constraint set
                    if (string.Equals(node.Name, "ConstraintSetCase", StringComparison.CurrentCultureIgnoreCase))
                        constraintSet = LoadCaseConstraintSet(node as XmlElement);
                    // load pallet solutions descriptors
                    else if (string.Equals(node.Name, "PalletSolutionDescriptors", StringComparison.CurrentCultureIgnoreCase))
                    {
                        foreach (XmlNode palletSolutionNode in node.ChildNodes)
                            palletSolutionDescriptors.Add(LoadPalletSolutionDescriptor(palletSolutionNode as XmlElement));
                    }
                    // load solutions
                    else if (string.Equals(node.Name, "CaseSolutions", StringComparison.CurrentCultureIgnoreCase))
                    {
                        caseSolutionsElt = node as XmlElement;
                    }
                }

                // instantiate caseAnalysis
                CaseAnalysis caseAnalysis = CreateNewCaseAnalysis(
                    sName
                    , sDescription
                    , GetTypeByGuid(new Guid(sBoxId)) as BoxProperties
                    , constraintSet
                    , palletSolutionDescriptors
                    , null
                    );
  
                // second : solutions
                List<CaseSolution> caseSolutions = new List<CaseSolution>();
                foreach (XmlNode palletSolutionDescNode in caseSolutionsElt.ChildNodes)
                    caseSolutions.Add(LoadCaseSolution(palletSolutionDescNode as XmlElement, caseAnalysis));
                caseAnalysis.Solutions = caseSolutions;
            }
        }

        private PalletSolutionDesc LoadPalletSolutionDescriptor(XmlElement palletSolutionDescriptorElt)
        {
            string palletDimensions = palletSolutionDescriptorElt.Attributes["PalletDimensions"].Value;
            string overhang = palletSolutionDescriptorElt.Attributes["PalletOverhang"].Value;
            string caseDimensions = palletSolutionDescriptorElt.Attributes["CaseDimensions"].Value;
            string caseInsideDimensions = palletSolutionDescriptorElt.Attributes["CaseInsideDimensions"].Value;
            string caseCount = palletSolutionDescriptorElt.Attributes["CaseCount"].Value;
            string sGuid = palletSolutionDescriptorElt.Attributes["Id"].Value;
            string friendlyName = palletSolutionDescriptorElt.Attributes["FriendlyName"].Value;
            return new PalletSolutionDesc(PalletSolutionDatabase.Instance, palletDimensions, overhang, caseDimensions, caseInsideDimensions, caseCount, sGuid, friendlyName);
        }

        private CaseConstraintSet LoadCaseConstraintSet(XmlElement eltConstraintSet)
        {
            CaseConstraintSet constraints = new CaseConstraintSet();
            // align layers allowed
            if (eltConstraintSet.HasAttribute("AlignedLayersAllowed"))
                constraints.AllowAlignedLayers = string.Equals(eltConstraintSet.Attributes["AlignedLayersAllowed"].Value, "true", StringComparison.CurrentCultureIgnoreCase);
            // alternate layers allowed
            if (eltConstraintSet.HasAttribute("AlternateLayersAllowed"))
                constraints.AllowAlternateLayers = string.Equals(eltConstraintSet.Attributes["AlternateLayersAllowed"].Value, "true", StringComparison.CurrentCultureIgnoreCase);
            // allowed orthogonal axes
            if (eltConstraintSet.HasAttribute("AllowedBoxPositions"))
                constraints.AllowOrthoAxisString = eltConstraintSet.Attributes["AllowedBoxPositions"].Value;
            // allowed patterns
            if (eltConstraintSet.HasAttribute("AllowedPatterns"))
                constraints.AllowedPatternString = eltConstraintSet.Attributes["AllowedPatterns"].Value;
            // stop criterions
            if (constraints.UseMaximumNumberOfItems = eltConstraintSet.HasAttribute("ManimumNumberOfItems"))
                constraints.MaximumNumberOfItems = int.Parse(eltConstraintSet.Attributes["ManimumNumberOfItems"].Value);
            // maximum 
            if (constraints.UseMaximumCaseWeight = eltConstraintSet.HasAttribute("MaximumCaseWeight"))
                constraints.MaximumCaseWeight = double.Parse(eltConstraintSet.Attributes["MaximumCaseWeight"].Value);
            // number of solutions to keep
            if (constraints.UseNumberOfSolutionsKept = eltConstraintSet.HasAttribute("NumberOfSolutions"))
                constraints.NumberOfSolutionsKept = int.Parse(eltConstraintSet.Attributes["NumberOfSolutions"].Value);
            // minimum number of items
            if (constraints.UseMinimumNumberOfItems = eltConstraintSet.HasAttribute("MinimumNumberOfItems"))
                constraints.MinimumNumberOfItems = int.Parse(eltConstraintSet.Attributes["MinimumNumberOfItems"].Value);
            // sanity check
            if (!constraints.IsValid)
                throw new Exception("Invalid constraint set");
            return constraints;
        }

        private ConstraintSet LoadConstraintSetBox(XmlElement eltConstraintSet)
        {
            ConstraintSetBox constraints = new ConstraintSetBox();
            // align layers allowed
            if (eltConstraintSet.HasAttribute("AlignedLayersAllowed"))
                constraints.AllowAlignedLayers = string.Equals(eltConstraintSet.Attributes["AlignedLayersAllowed"].Value, "true", StringComparison.CurrentCultureIgnoreCase);
            // alternate layers allowed
            if (eltConstraintSet.HasAttribute("AlternateLayersAllowed"))
                constraints.AllowAlternateLayers = string.Equals(eltConstraintSet.Attributes["AlternateLayersAllowed"].Value, "true", StringComparison.CurrentCultureIgnoreCase);
            // allowed orthogonal axes
            if (eltConstraintSet.HasAttribute("AllowedBoxPositions"))
            {
                string allowedOrthoAxes = eltConstraintSet.Attributes["AllowedBoxPositions"].Value;
                string[] sAxes = allowedOrthoAxes.Split(',');
                foreach (string sAxis in sAxes)
                    constraints.SetAllowedOrthoAxis(HalfAxis.Parse(sAxis), true);
            }
            // allowed patterns
            if (eltConstraintSet.HasAttribute("AllowedPatterns"))
                constraints.AllowedPatternString = eltConstraintSet.Attributes["AllowedPatterns"].Value;
            // stop criterions
            if (constraints.UseMaximumHeight = eltConstraintSet.HasAttribute("MaximumHeight"))
                constraints.MaximumHeight = double.Parse(eltConstraintSet.Attributes["MaximumHeight"].Value);
            if (constraints.UseMaximumNumberOfItems = eltConstraintSet.HasAttribute("ManimumNumberOfItems"))
                constraints.MaximumNumberOfItems = int.Parse(eltConstraintSet.Attributes["ManimumNumberOfItems"].Value);
            if (constraints.UseMaximumPalletWeight = eltConstraintSet.HasAttribute("MaximumPalletWeight"))
                constraints.MaximumPalletWeight = double.Parse(eltConstraintSet.Attributes["MaximumPalletWeight"].Value);
            if (constraints.UseMaximumWeightOnBox = eltConstraintSet.HasAttribute("MaximumWeightOnBox"))
                constraints.MaximumWeightOnBox = double.Parse(eltConstraintSet.Attributes["MaximumWeightOnBox"].Value);
            // overhang / underhang
            if (eltConstraintSet.HasAttribute("OverhangX"))
                constraints.OverhangX = double.Parse(eltConstraintSet.Attributes["OverhangX"].Value);
            if (eltConstraintSet.HasAttribute("OverhangY"))
                constraints.OverhangY = double.Parse(eltConstraintSet.Attributes["OverhangY"].Value);
            // number of solutions to keep
            if (constraints.UseNumberOfSolutionsKept = eltConstraintSet.HasAttribute("NumberOfSolutions"))
                constraints.NumberOfSolutionsKept = int.Parse(eltConstraintSet.Attributes["NumberOfSolutions"].Value);
            // sanity check
            if (!constraints.IsValid)
                throw new Exception("Invalid constraint set");
            return constraints;
        }
        ConstraintSet LoadConstraintSetBundle(XmlElement eltConstraintSet)
        {
            ConstraintSetBundle constraints = new ConstraintSetBundle();
            // align layers alowed
            if (eltConstraintSet.HasAttribute("AlignedLayersAllowed"))
                constraints.AllowAlignedLayers = string.Equals(eltConstraintSet.Attributes["AlignedLayersAllowed"].Value, "true", StringComparison.CurrentCultureIgnoreCase);
            // alternate layers allowed
            if (eltConstraintSet.HasAttribute("AlternateLayersAllowed"))
                constraints.AllowAlternateLayers = string.Equals(eltConstraintSet.Attributes["AlternateLayersAllowed"].Value, "true", StringComparison.CurrentCultureIgnoreCase);
            // allowed patterns
            if (eltConstraintSet.HasAttribute("AllowedPatterns"))
                constraints.AllowedPatternString = eltConstraintSet.Attributes["AllowedPatterns"].Value;
            // stop criterions
            if (constraints.UseMaximumHeight = eltConstraintSet.HasAttribute("MaximumHeight"))
                constraints.MaximumHeight = double.Parse(eltConstraintSet.Attributes["MaximumHeight"].Value);
            if (constraints.UseMaximumNumberOfItems = eltConstraintSet.HasAttribute("ManimumNumberOfItems"))
                constraints.MaximumNumberOfItems = int.Parse(eltConstraintSet.Attributes["ManimumNumberOfItems"].Value);
            if (constraints.UseMaximumPalletWeight = eltConstraintSet.HasAttribute("MaximumPalletWeight"))
                constraints.MaximumPalletWeight = double.Parse(eltConstraintSet.Attributes["MaximumPalletWeight"].Value);
            // overhang / underhang
            if (eltConstraintSet.HasAttribute("OverhangX"))
                constraints.OverhangX = double.Parse(eltConstraintSet.Attributes["OverhangX"].Value);
            if (eltConstraintSet.HasAttribute("OverhangY"))
                constraints.OverhangY = double.Parse(eltConstraintSet.Attributes["OverhangY"].Value);
            // number of solutions to keep
            if (constraints.UseNumberOfSolutionsKept = eltConstraintSet.HasAttribute("NumberOfSolutions"))
                constraints.NumberOfSolutionsKept = int.Parse(eltConstraintSet.Attributes["NumberOfSolutions"].Value);
            // sanity check
            if (!constraints.IsValid)
                throw new Exception("Invalid constraint set");
            return constraints;
        }

        private Solution LoadSolution(XmlElement eltSolution)
        {
            // title -> instantiation
            string stitle = eltSolution.Attributes["Title"].Value;
            Solution sol = new Solution(null, stitle, true);
            // homogeneous layers
            if (eltSolution.HasAttribute("HomogeneousLayers"))
            {
                string sHomogeneousLayers = eltSolution.Attributes["HomogeneousLayers"].Value;
                sol.HasHomogeneousLayers = string.Equals(sHomogeneousLayers, "true", StringComparison.CurrentCultureIgnoreCase);
            }
            else
                sol.HasHomogeneousLayers = false;
            // layers
            XmlElement eltLayers = eltSolution.ChildNodes[0] as XmlElement;
            foreach (XmlNode nodeLayer in eltLayers.ChildNodes)
                sol.Add( LoadLayer(nodeLayer as XmlElement));
            return sol;
        }

        private CaseSolution LoadCaseSolution(XmlElement eltSolution, CaseAnalysis analysis)
        {
            // title
            string stitle = eltSolution.Attributes["Title"].Value;
            // guid
            Guid guid = new Guid(eltSolution.Attributes["PalletSolutionId"].Value);
            // homogeneousLayers
            bool homogeneousLayers = string.Equals(eltSolution.Attributes["HomogeneousLayers"].Value, "true", StringComparison.CurrentCultureIgnoreCase);
            // instantiation
            CaseSolution sol = new CaseSolution(analysis, stitle, analysis.GetPalletSolutionDescByGuid(guid), homogeneousLayers);
            // layers
            XmlElement eltLayers = eltSolution.ChildNodes[0] as XmlElement;
            foreach (XmlNode nodeLayer in eltLayers.ChildNodes)
                sol.Add(LoadLayer(nodeLayer as XmlElement));
            return sol;
        }

        private ILayer LoadLayer(XmlElement eltLayer)
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

        private TruckAnalysis LoadTruckAnalysis(XmlElement eltTruckAnalysis, SelSolution selSolution)
        {
            string sName = eltTruckAnalysis.Attributes["Name"].Value;
            string sDescription = eltTruckAnalysis.Attributes["Description"].Value;
            string sTruckId = eltTruckAnalysis.Attributes["TruckId"].Value;

            TruckConstraintSet constraintSet = new TruckConstraintSet();
            List<TruckSolution> solutions = new List<TruckSolution>();
            List<int> selectedIndices = new List<int>();

            foreach (XmlNode node in eltTruckAnalysis.ChildNodes)
            { 
                // load constraint set
                if (string.Equals(node.Name, "ConstraintSet", StringComparison.CurrentCultureIgnoreCase))
                    constraintSet = LoadTruckConstraintSet(node as XmlElement);
                // load solutions
                else if (string.Equals(node.Name, "Solutions", StringComparison.CurrentCultureIgnoreCase))
                {
                    int indexSol = 0;
                    foreach (XmlNode solutionNode in node.ChildNodes)
                    {
                        XmlElement eltSolution = solutionNode as XmlElement;
                        solutions.Add(LoadTruckSolution(eltSolution));
                        // is solution selected ?
                        if (null != eltSolution.Attributes["Selected"]
                            && string.Equals("true", eltSolution.Attributes["Selected"].Value, StringComparison.CurrentCultureIgnoreCase))
                            selectedIndices.Add(indexSol);
                        ++indexSol;
                    }
                }
            }

            TruckAnalysis truckAnalysis = selSolution.CreateNewTruckAnalysis(
                sName
                , sDescription
                , GetTypeByGuid(new Guid(sTruckId)) as TruckProperties
                , constraintSet
                , solutions);
            foreach (int index in selectedIndices)
                truckAnalysis.SelectedSolutionIndex = index;
            return truckAnalysis;
        }

        private TruckConstraintSet LoadTruckConstraintSet(XmlElement eltTruckConstraintSet)
        {
            TruckConstraintSet constraintSet = new TruckConstraintSet();
            // multi layer allowed
            if (eltTruckConstraintSet.HasAttribute("MultilayerAllowed"))
                constraintSet.MultilayerAllowed = string.Equals(eltTruckConstraintSet.Attributes["MultilayerAllowed"].Value, "true", StringComparison.CurrentCultureIgnoreCase);
            if (eltTruckConstraintSet.HasAttribute("MinDistancePalletWall"))
            constraintSet.MinDistancePalletTruckWall = double.Parse(eltTruckConstraintSet.Attributes["MinDistancePalletWall"].Value);
            if (eltTruckConstraintSet.HasAttribute("MinDistancePalletRoof"))
                constraintSet.MinDistancePalletTruckRoof = double.Parse(eltTruckConstraintSet.Attributes["MinDistancePalletRoof"].Value);
            if (eltTruckConstraintSet.HasAttribute("AllowedPalletOrientations"))
            {
                string sAllowedPalletOrientations = eltTruckConstraintSet.Attributes["AllowedPalletOrientations"].Value;
                constraintSet.AllowPalletOrientationX = sAllowedPalletOrientations.Contains("X");
                constraintSet.AllowPalletOrientationY = sAllowedPalletOrientations.Contains("Y");

            }

            return constraintSet;
        }

        private TruckSolution LoadTruckSolution(XmlElement eltTruckSolution)
        {
            // title -> instantiation
            string stitle = string.Empty;
            if (eltTruckSolution.HasAttribute("Title"))
                stitle = eltTruckSolution.Attributes["Title"].Value;
            TruckSolution sol = new TruckSolution(stitle, null);
            // load only one BoxLayer (actually Pallet layer)
            XmlElement eltLayers = eltTruckSolution.ChildNodes[0] as XmlElement;
            XmlElement eltLayer = eltLayers.ChildNodes[0] as XmlElement;
            sol.Layer = LoadLayer(eltLayer) as BoxLayer;
            return sol;
        }
        #endregion

        #region Save methods
        public void Write(string filePath)
        {
            try
            {
                // instantiate XmlDocument
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
                foreach (ItemBase itemProperties in _typeList)
                {
                    BoxProperties boxProperties = itemProperties as BoxProperties;
                    if (null != boxProperties)
                        Save(boxProperties, xmlItemPropertiesElt, xmlDoc);
                    BundleProperties bundleProperties = itemProperties as BundleProperties;
                    if (null != bundleProperties)
                        Save(bundleProperties, xmlItemPropertiesElt, xmlDoc);
                    PalletProperties palletProperties = itemProperties as PalletProperties;
                    if (null != palletProperties)
                        Save(palletProperties, xmlItemPropertiesElt, xmlDoc);
                    InterlayerProperties interlayerProperties = itemProperties as InterlayerProperties;
                    if (null != interlayerProperties)
                        Save(interlayerProperties, xmlItemPropertiesElt, xmlDoc);
                    TruckProperties truckProperties = itemProperties as TruckProperties;
                    if (null != truckProperties)
                        Save(truckProperties, xmlItemPropertiesElt, xmlDoc);
                }

                // create Analyses element
                XmlElement xmlAnalysesElt = xmlDoc.CreateElement("Analyses");
                xmlRootElement.AppendChild(xmlAnalysesElt);
                foreach (Analysis analysis in _analyses)
                    SavePalletAnalysis(analysis, xmlAnalysesElt, xmlDoc);
                foreach (CaseAnalysis analysis in _caseAnalyses)
                    SaveCaseAnalysis(analysis, xmlAnalysesElt, xmlDoc);

                // finally save XmlDocument
                xmlDoc.Save(filePath);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        public void WriteSolution(SelSolution selSolution, string filePath)
        {
            try
            {
                // retrieve solution
                Solution sol = selSolution.Solution;
                // retrieve analysis
                Analysis analysis = sol.Analysis;
                // instantiate XmlDocument
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

                BoxProperties boxProperties = sol.Analysis.BProperties as BoxProperties;
                if (null != boxProperties)
                    Save(boxProperties, xmlItemPropertiesElt, xmlDoc);
                BundleProperties bundleProperties = sol.Analysis.BProperties as BundleProperties;
                if (null != bundleProperties)
                    Save(bundleProperties, xmlItemPropertiesElt, xmlDoc);
                PalletProperties palletProperties = sol.Analysis.PalletProperties as PalletProperties;
                if (null != palletProperties)
                    Save(palletProperties, xmlItemPropertiesElt, xmlDoc);
                InterlayerProperties interlayerProperties = sol.Analysis.InterlayerProperties as InterlayerProperties;
                if (null != interlayerProperties)
                    Save(interlayerProperties, xmlItemPropertiesElt, xmlDoc);
                if (null != selSolution && selSolution.TruckAnalyses.Count > 0)
                {
                    TruckProperties truckProperties = selSolution.TruckAnalyses[0].TruckProperties;
                    if (null != truckProperties)
                        Save(truckProperties, xmlItemPropertiesElt, xmlDoc);
                }

                // create Analyses element
                XmlElement xmlAnalysesElt = xmlDoc.CreateElement("Analyses");
                xmlRootElement.AppendChild(xmlAnalysesElt);
                Save(sol.Analysis, sol, selSolution, xmlAnalysesElt, xmlDoc);
                // finally save XmlDocument
                xmlDoc.Save(filePath);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                throw ex;
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
            // inside dimensions
            if (boxProperties.HasInsideDimensions)
            {
                // length
                XmlAttribute insideLengthAttribute = xmlDoc.CreateAttribute("InsideLength");
                insideLengthAttribute.Value = string.Format("{0}", boxProperties.InsideLength);
                xmlBoxProperties.Attributes.Append(insideLengthAttribute);
                // width
                XmlAttribute insideWidthAttribute = xmlDoc.CreateAttribute("InsideWidth");
                insideWidthAttribute.Value = string.Format("{0}", boxProperties.InsideWidth);
                xmlBoxProperties.Attributes.Append(insideWidthAttribute);
                // height
                XmlAttribute insideHeightAttribute = xmlDoc.CreateAttribute("InsideHeight");
                insideHeightAttribute.Value = string.Format("{0}", boxProperties.InsideHeight);
                xmlBoxProperties.Attributes.Append(insideHeightAttribute);
            }
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
            foreach (Pair<HalfAxis.HAxis, Texture> texPair in boxProperties.TextureList)
            {
                XmlElement xmlFaceTexture = xmlDoc.CreateElement("FaceTexture");
                xmlTexturesElement.AppendChild(xmlFaceTexture);
                // face index
                XmlAttribute xmlFaceNormal = xmlDoc.CreateAttribute("FaceNormal");
                xmlFaceNormal.Value = HalfAxis.ToString(texPair.first);
                xmlFaceTexture.Attributes.Append(xmlFaceNormal);
                // texture position
                XmlAttribute xmlPosition = xmlDoc.CreateAttribute("Position");
                xmlPosition.Value = texPair.second.Position.ToString();
                xmlFaceTexture.Attributes.Append(xmlPosition);
                // texture size
                XmlAttribute xmlSize = xmlDoc.CreateAttribute("Size");
                xmlSize.Value = texPair.second.Size.ToString();
                xmlFaceTexture.Attributes.Append(xmlSize);
                // angle
                XmlAttribute xmlAngle = xmlDoc.CreateAttribute("Angle");
                xmlAngle.Value = string.Format("{0}", texPair.second.Angle);
                xmlFaceTexture.Attributes.Append(xmlAngle);
                // bitmap
                XmlAttribute xmlBitmap = xmlDoc.CreateAttribute("Bitmap");
                xmlBitmap.Value = Document.BitmapToString(texPair.second.Bitmap);
                xmlFaceTexture.Attributes.Append(xmlBitmap);
            }
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
            XmlElement xmlBundleProperties = xmlDoc.CreateElement("BundleProperties");
            parentElement.AppendChild(xmlBundleProperties);
            // Id
            XmlAttribute guidAttribute = xmlDoc.CreateAttribute("Id");
            guidAttribute.Value = bundleProperties.Guid.ToString();
            xmlBundleProperties.Attributes.Append(guidAttribute);
            // name
            XmlAttribute nameAttribute = xmlDoc.CreateAttribute("Name");
            nameAttribute.Value = bundleProperties.Name;
            xmlBundleProperties.Attributes.Append(nameAttribute);
            // description
            XmlAttribute descAttribute = xmlDoc.CreateAttribute("Description");
            descAttribute.Value = bundleProperties.Description;
            xmlBundleProperties.Attributes.Append(descAttribute);
            // length
            XmlAttribute lengthAttribute = xmlDoc.CreateAttribute("Length");
            lengthAttribute.Value = string.Format("{0}", bundleProperties.Length);
            xmlBundleProperties.Attributes.Append(lengthAttribute);
            // width
            XmlAttribute widthAttribute = xmlDoc.CreateAttribute("Width");
            widthAttribute.Value = string.Format("{0}", bundleProperties.Width);
            xmlBundleProperties.Attributes.Append(widthAttribute);
            // height
            XmlAttribute heightAttribute = xmlDoc.CreateAttribute("UnitThickness");
            heightAttribute.Value = string.Format("{0}", bundleProperties.UnitThickness);
            xmlBundleProperties.Attributes.Append(heightAttribute);
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("UnitWeight");
            weightAttribute.Value = string.Format("{0}", bundleProperties.UnitWeight);
            xmlBundleProperties.Attributes.Append(weightAttribute);
            // color
            XmlAttribute colorAttribute = xmlDoc.CreateAttribute("Color");
            colorAttribute.Value = string.Format("{0}", bundleProperties.Color.ToArgb());
            xmlBundleProperties.Attributes.Append(colorAttribute);
            // numberFlats
            XmlAttribute numberFlatsAttribute = xmlDoc.CreateAttribute("NumberFlats");
            numberFlatsAttribute.Value = string.Format("{0}", bundleProperties.NoFlats);
            xmlBundleProperties.Attributes.Append(numberFlatsAttribute);
        }

        public void Save(TruckProperties truckProperties, XmlElement parentElement, XmlDocument xmlDoc)
        {
            // create xmlPalletProperties element
            XmlElement xmlTruckProperties = xmlDoc.CreateElement("TruckProperties");
            parentElement.AppendChild(xmlTruckProperties);
            // Id
            XmlAttribute guidAttribute = xmlDoc.CreateAttribute("Id");
            guidAttribute.Value = truckProperties.Guid.ToString();
            xmlTruckProperties.Attributes.Append(guidAttribute);
            // name
            XmlAttribute nameAttribute = xmlDoc.CreateAttribute("Name");
            nameAttribute.Value = truckProperties.Name;
            xmlTruckProperties.Attributes.Append(nameAttribute);
            // description
            XmlAttribute descAttribute = xmlDoc.CreateAttribute("Description");
            descAttribute.Value = truckProperties.Description;
            xmlTruckProperties.Attributes.Append(descAttribute);
            // length
            XmlAttribute lengthAttribute = xmlDoc.CreateAttribute("Length");
            lengthAttribute.Value = string.Format("{0}", truckProperties.Length);
            xmlTruckProperties.Attributes.Append(lengthAttribute);
            // width
            XmlAttribute widthAttribute = xmlDoc.CreateAttribute("Width");
            widthAttribute.Value = string.Format("{0}", truckProperties.Width);
            xmlTruckProperties.Attributes.Append(widthAttribute);
            // height
            XmlAttribute heightAttribute = xmlDoc.CreateAttribute("Height");
            heightAttribute.Value = string.Format("{0}", truckProperties.Height);
            xmlTruckProperties.Attributes.Append(heightAttribute);
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("AdmissibleLoadWeight");
            weightAttribute.Value = string.Format("{0}", truckProperties.AdmissibleLoadWeight);
            xmlTruckProperties.Attributes.Append(weightAttribute);
            // color
            XmlAttribute colorAttribute = xmlDoc.CreateAttribute("Color");
            colorAttribute.Value = string.Format("{0}", truckProperties.Color.ToArgb());
            xmlTruckProperties.Attributes.Append(colorAttribute);
        }
        private void SaveCaseAnalysis(CaseAnalysis analysis, XmlElement parentElement, XmlDocument xmlDoc)
        { 
            // create analysis element
            XmlElement xmlAnalysisElt = xmlDoc.CreateElement("AnalysisCase");
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
            // ConstraintSet : beg
            XmlElement constraintSetElement = xmlDoc.CreateElement("ConstraintSetCase");
            xmlAnalysisElt.AppendChild(constraintSetElement);
            XmlAttribute alignedLayersAttribute = xmlDoc.CreateAttribute("AlignedLayersAllowed");
            alignedLayersAttribute.Value = string.Format("{0}", analysis.ConstraintSet.AllowAlignedLayers);
            constraintSetElement.Attributes.Append(alignedLayersAttribute);
            XmlAttribute alternateLayersAttribute = xmlDoc.CreateAttribute("AlternateLayersAllowed");
            alternateLayersAttribute.Value = string.Format("{0}", analysis.ConstraintSet.AllowAlternateLayers);
            constraintSetElement.Attributes.Append(alternateLayersAttribute);
            // allowed box positions
            XmlAttribute allowedAxisAttribute = xmlDoc.CreateAttribute("AllowedBoxPositions");
            allowedAxisAttribute.Value = analysis.ConstraintSet.AllowOrthoAxisString;
            constraintSetElement.Attributes.Append(allowedAxisAttribute);
            // allowed layer patterns
            XmlAttribute allowedPatternAttribute = xmlDoc.CreateAttribute("AllowedPatterns");
            allowedPatternAttribute.Value = analysis.ConstraintSet.AllowedPatternString;
            constraintSetElement.Attributes.Append(allowedPatternAttribute);
            // stop criterions
            if (analysis.ConstraintSet.UseMaximumCaseWeight)
            {
                XmlAttribute maximumWeightAttribute = xmlDoc.CreateAttribute("MaximumCaseWeight");
                maximumWeightAttribute.Value = string.Format("{0}", analysis.ConstraintSet.MaximumCaseWeight);
                constraintSetElement.Attributes.Append(maximumWeightAttribute);
            }
            if (analysis.ConstraintSet.UseMaximumNumberOfItems)
            {
                XmlAttribute maximumNumberOfItems = xmlDoc.CreateAttribute("ManimumNumberOfItems");
                maximumNumberOfItems.Value = string.Format("{0}", analysis.ConstraintSet.MaximumNumberOfItems);
                constraintSetElement.Attributes.Append(maximumNumberOfItems);
            }
            // solution filtering
            if (analysis.ConstraintSet.UseMinimumNumberOfItems)
            {
                XmlAttribute minimumNumberOfItems = xmlDoc.CreateAttribute("MinimumNumberOfItems");
                minimumNumberOfItems.Value = string.Format("{0}", analysis.ConstraintSet.MinimumNumberOfItems);
                constraintSetElement.Attributes.Append(minimumNumberOfItems);
            }
            // number of solutions to keep
            if (analysis.ConstraintSet.UseNumberOfSolutionsKept)
            {
                XmlAttribute numberOfSolutionsKept = xmlDoc.CreateAttribute("NumberOfSolutions");
                numberOfSolutionsKept.Value = string.Format("{0}", analysis.ConstraintSet.NumberOfSolutionsKept);
                constraintSetElement.Attributes.Append(numberOfSolutionsKept);
            }
            // ConstraintSet : end

            // Pallet solution descriptors
            XmlElement palletSolutionsElement = xmlDoc.CreateElement("PalletSolutionDescriptors");
            xmlAnalysisElt.AppendChild(palletSolutionsElement);
            foreach (PalletSolutionDesc desc in analysis.PalletSolutionsList)
                SavePalletSolutionDescriptor(desc, palletSolutionsElement, xmlDoc);
            // Solutions
            XmlElement solutionsElt = xmlDoc.CreateElement("CaseSolutions");
            xmlAnalysisElt.AppendChild(solutionsElt);
            foreach (CaseSolution caseSolution in analysis.Solutions)
                SaveCaseSolution(caseSolution, solutionsElt, xmlDoc);
        }

        private void SavePalletSolutionDescriptor(PalletSolutionDesc desc, XmlElement parentElement, XmlDocument xmlDoc)
        {
            // pallet solution descriptor element
            XmlElement palletSolutionDescElt = xmlDoc.CreateElement("PalletSolutionDescriptor");
            parentElement.AppendChild(palletSolutionDescElt);
            // pallet dimensions
            XmlAttribute palletDimensionsAttribute = xmlDoc.CreateAttribute("PalletDimensions");
            palletDimensionsAttribute.Value = desc.Key.PalletDimensions;
            palletSolutionDescElt.Attributes.Append(palletDimensionsAttribute);
            // overhang
            XmlAttribute palletOverhangAttribute = xmlDoc.CreateAttribute("PalletOverhang");
            palletOverhangAttribute.Value = desc.Key.Overhang;
            palletSolutionDescElt.Attributes.Append(palletOverhangAttribute);
            // guid
            XmlAttribute idAttribute = xmlDoc.CreateAttribute("Id");
            idAttribute.Value = desc.Guid.ToString();
            palletSolutionDescElt.Attributes.Append(idAttribute);
            // friendly name
            XmlAttribute friendlyNameAttribute = xmlDoc.CreateAttribute("FriendlyName");
            friendlyNameAttribute.Value = desc.FriendlyName;
            palletSolutionDescElt.Attributes.Append(friendlyNameAttribute);
            // case dimensions
            XmlAttribute dimensionsAttribute = xmlDoc.CreateAttribute("CaseDimensions");
            dimensionsAttribute.Value = desc.CaseDimensionsString;
            palletSolutionDescElt.Attributes.Append(dimensionsAttribute);
            // case inside dimensions
            XmlAttribute insideDimensionsAttribute = xmlDoc.CreateAttribute("CaseInsideDimensions");
            insideDimensionsAttribute.Value = desc.CaseInsideDimensionsString;
            palletSolutionDescElt.Attributes.Append(insideDimensionsAttribute);
            // case count
            XmlAttribute caseCountAttribute = xmlDoc.CreateAttribute("CaseCount");
            caseCountAttribute.Value = desc.CaseCount.ToString();
            palletSolutionDescElt.Attributes.Append(caseCountAttribute);
            // case orientation
            XmlAttribute caseOrientationAttribute = xmlDoc.CreateAttribute("CaseOrientation");
            caseOrientationAttribute.Value = desc.CaseOrientation;
            palletSolutionDescElt.Attributes.Append(caseOrientationAttribute);
        }

        private void SaveCaseSolution(CaseSolution sol, XmlElement parentElement, XmlDocument xmlDoc)
        {
            // create case solution element
            XmlElement solutionElt = xmlDoc.CreateElement("CaseSolution");
            parentElement.AppendChild(solutionElt);
            // title
            XmlAttribute titleAttribute = xmlDoc.CreateAttribute("Title");
            titleAttribute.Value = sol.Title;
            solutionElt.Attributes.Append(titleAttribute);
            // homogeneousLayers ?
            XmlAttribute homogeneousLayersAttribute = xmlDoc.CreateAttribute("HomogeneousLayers");
            homogeneousLayersAttribute.Value = sol.HasHomogeneousLayers ? "true" : "false";
            solutionElt.Attributes.Append(homogeneousLayersAttribute);
            // pallet solution id
            XmlAttribute palletSolutionAttribute = xmlDoc.CreateAttribute("PalletSolutionId");
            palletSolutionAttribute.Value = sol.PalletSolutionDesc.Guid.ToString();
            solutionElt.Attributes.Append(palletSolutionAttribute);
            // layers
            XmlElement layersElt = xmlDoc.CreateElement("Layers");
            solutionElt.AppendChild(layersElt);

            foreach (ILayer layer in sol)
            {
                BoxLayer boxLayer = layer as BoxLayer;
                if (null != boxLayer)
                    Save(boxLayer, layersElt, xmlDoc);

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

            // Is selected ?
            if (sol.Selected)
            {
                // selected attribute
                XmlAttribute selAttribute = xmlDoc.CreateAttribute("Selected");
                selAttribute.Value = "true";
                solutionElt.Attributes.Append(selAttribute);
            }
        }

        private void SavePalletAnalysis(Analysis analysis, XmlElement parentElement, XmlDocument xmlDoc)
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
            boxIdAttribute.Value = string.Format("{0}", analysis.BProperties.Guid);
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
            // ###
            // ConstraintSet
            bool bundleAnalysis = (analysis.ConstraintSet.GetType() == typeof(ConstraintSetBundle));
            XmlElement constraintSetElement = xmlDoc.CreateElement(bundleAnalysis ? "ConstraintSetBundle":"ConstraintSetBox");
            XmlAttribute alignedLayersAttribute = xmlDoc.CreateAttribute("AlignedLayersAllowed");
            alignedLayersAttribute.Value = string.Format("{0}", analysis.ConstraintSet.AllowAlignedLayers);
            constraintSetElement.Attributes.Append(alignedLayersAttribute);
            XmlAttribute alternateLayersAttribute = xmlDoc.CreateAttribute("AlternateLayersAllowed");
            alternateLayersAttribute.Value = string.Format("{0}", analysis.ConstraintSet.AllowAlternateLayers);
            constraintSetElement.Attributes.Append(alternateLayersAttribute);
            if (!bundleAnalysis)
            {
                // allowed box positions
                XmlAttribute allowedAxisAttribute = xmlDoc.CreateAttribute("AllowedBoxPositions");
                HalfAxis.HAxis[] axes = { HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_Z_P };
                string allowedAxes = string.Empty;
                foreach (HalfAxis.HAxis axis in axes)
                    if (analysis.ConstraintSet.AllowOrthoAxis(axis))
                    {
                        if (!string.IsNullOrEmpty(allowedAxes))
                            allowedAxes += ",";
                        allowedAxes += HalfAxis.ToString(axis);
                    }
                allowedAxisAttribute.Value = allowedAxes;
                constraintSetElement.Attributes.Append(allowedAxisAttribute);
            }
            // allowed layer patterns
            XmlAttribute allowedPatternAttribute = xmlDoc.CreateAttribute("AllowedPatterns");
            allowedPatternAttribute.Value = analysis.ConstraintSet.AllowedPatternString;
            constraintSetElement.Attributes.Append(allowedPatternAttribute);
            // stop criterions
            if (analysis.ConstraintSet.UseMaximumHeight)
            { 
                XmlAttribute maximumHeightAttribute = xmlDoc.CreateAttribute("MaximumHeight");
                maximumHeightAttribute.Value = string.Format("{0}", analysis.ConstraintSet.MaximumHeight);
                constraintSetElement.Attributes.Append(maximumHeightAttribute);
            }
            if (analysis.ConstraintSet.UseMaximumNumberOfItems)
            {
                XmlAttribute maximumNumberOfItems = xmlDoc.CreateAttribute("ManimumNumberOfItems");
                maximumNumberOfItems.Value = string.Format("{0}", analysis.ConstraintSet.MaximumNumberOfItems);
                constraintSetElement.Attributes.Append(maximumNumberOfItems);
            }
            if (analysis.ConstraintSet.UseMaximumPalletWeight)
            {
                XmlAttribute maximumPalletWeight = xmlDoc.CreateAttribute("MaximumPalletWeight");
                maximumPalletWeight.Value = string.Format("{0}", analysis.ConstraintSet.MaximumPalletWeight);
                constraintSetElement.Attributes.Append(maximumPalletWeight);
            }
            if (analysis.ConstraintSet.UseMaximumWeightOnBox)
            {
                XmlAttribute maximumWeightOnBox = xmlDoc.CreateAttribute("MaximumWeightOnBox");
                maximumWeightOnBox.Value = string.Format("{0}", analysis.ConstraintSet.MaximumWeightOnBox);
                constraintSetElement.Attributes.Append(maximumWeightOnBox);
            }
            // overhang / underhang
            XmlAttribute overhangX = xmlDoc.CreateAttribute("OverhangX");
            overhangX.Value = string.Format("{0}", analysis.ConstraintSet.OverhangX);
            constraintSetElement.Attributes.Append(overhangX);
            XmlAttribute overhangY = xmlDoc.CreateAttribute("OverhangY");
            overhangY.Value = string.Format("{0}", analysis.ConstraintSet.OverhangY);
            constraintSetElement.Attributes.Append(overhangY);
            // number of solutions to keep
            if (analysis.ConstraintSet.UseNumberOfSolutionsKept)
            {
                XmlAttribute numberOfSolutionsKept = xmlDoc.CreateAttribute("NumberOfSolutions");
                numberOfSolutionsKept.Value = string.Format("{0}", analysis.ConstraintSet.NumberOfSolutionsKept);
                constraintSetElement.Attributes.Append(numberOfSolutionsKept);
            }
            xmlAnalysisElt.AppendChild(constraintSetElement);

            // Solutions
            int solIndex = 0;
            XmlElement solutionsElt = xmlDoc.CreateElement("Solutions");
            xmlAnalysisElt.AppendChild(solutionsElt);
            foreach (Solution sol in analysis.Solutions)
            {
                SaveSolution(
                    analysis
                    , sol
                    , analysis.GetSelSolutionBySolutionIndex(solIndex) // null if not selected
                    , false /*unique*/
                    , solutionsElt
                    , xmlDoc);
                ++solIndex;
            }
        }

        public void Save(Analysis analysis, Solution sol, SelSolution selSolution, XmlElement parentElement, XmlDocument xmlDoc)
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
            boxIdAttribute.Value = string.Format("{0}", analysis.BProperties.Guid);
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
            // ###
            // ConstraintSet
            bool bundleAnalysis = (analysis.ConstraintSet.GetType() == typeof(ConstraintSetBundle));
            XmlElement constraintSetElement = xmlDoc.CreateElement(bundleAnalysis ? "ConstraintSetBundle" : "ConstraintSetBox");
            XmlAttribute alignedLayersAttribute = xmlDoc.CreateAttribute("AlignedLayersAllowed");
            alignedLayersAttribute.Value = string.Format("{0}", analysis.ConstraintSet.AllowAlignedLayers);
            constraintSetElement.Attributes.Append(alignedLayersAttribute);
            XmlAttribute alternateLayersAttribute = xmlDoc.CreateAttribute("AlternateLayersAllowed");
            alternateLayersAttribute.Value = string.Format("{0}", analysis.ConstraintSet.AllowAlternateLayers);
            constraintSetElement.Attributes.Append(alternateLayersAttribute);
            if (!bundleAnalysis)
            {
                // allowed box positions
                XmlAttribute allowedAxisAttribute = xmlDoc.CreateAttribute("AllowedBoxPositions");
                HalfAxis.HAxis[] axes = { HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_Z_P };
                string allowedAxes = string.Empty;
                foreach (HalfAxis.HAxis axis in axes)
                    if (analysis.ConstraintSet.AllowOrthoAxis(axis))
                    {
                        if (!string.IsNullOrEmpty(allowedAxes))
                            allowedAxes += ",";
                        allowedAxes += HalfAxis.ToString(axis);
                    }
                allowedAxisAttribute.Value = allowedAxes;
                constraintSetElement.Attributes.Append(allowedAxisAttribute);
            }
            // allowed layer patterns
            XmlAttribute allowedPatternAttribute = xmlDoc.CreateAttribute("AllowedPatterns");
            allowedPatternAttribute.Value = analysis.ConstraintSet.AllowedPatternString;
            constraintSetElement.Attributes.Append(allowedPatternAttribute);
            // stop criterions
            if (analysis.ConstraintSet.UseMaximumHeight)
            {
                XmlAttribute maximumHeightAttribute = xmlDoc.CreateAttribute("MaximumHeight");
                maximumHeightAttribute.Value = string.Format("{0}", analysis.ConstraintSet.MaximumHeight);
                constraintSetElement.Attributes.Append(maximumHeightAttribute);
            }
            if (analysis.ConstraintSet.UseMaximumNumberOfItems)
            {
                XmlAttribute maximumNumberOfItems = xmlDoc.CreateAttribute("ManimumNumberOfItems");
                maximumNumberOfItems.Value = string.Format("{0}", analysis.ConstraintSet.MaximumNumberOfItems);
                constraintSetElement.Attributes.Append(maximumNumberOfItems);
            }
            if (analysis.ConstraintSet.UseMaximumPalletWeight)
            {
                XmlAttribute maximumPalletWeight = xmlDoc.CreateAttribute("MaximumPalletWeight");
                maximumPalletWeight.Value = string.Format("{0}", analysis.ConstraintSet.MaximumPalletWeight);
                constraintSetElement.Attributes.Append(maximumPalletWeight);
            }
            if (analysis.ConstraintSet.UseMaximumWeightOnBox)
            {
                XmlAttribute maximumWeightOnBox = xmlDoc.CreateAttribute("MaximumWeightOnBox");
                maximumWeightOnBox.Value = string.Format("{0}", analysis.ConstraintSet.MaximumWeightOnBox);
                constraintSetElement.Attributes.Append(maximumWeightOnBox);
            }
            // overhang / underhang
            XmlAttribute overhangX = xmlDoc.CreateAttribute("OverhangX");
            overhangX.Value = string.Format("{0}", analysis.ConstraintSet.OverhangX);
            constraintSetElement.Attributes.Append(overhangX);
            XmlAttribute overhangY = xmlDoc.CreateAttribute("OverhangY");
            overhangY.Value = string.Format("{0}", analysis.ConstraintSet.OverhangY);
            constraintSetElement.Attributes.Append(overhangY);
            // number of solutions to keep
            if (analysis.ConstraintSet.UseNumberOfSolutionsKept)
            {
                XmlAttribute numberOfSolutionsKept = xmlDoc.CreateAttribute("NumberOfSolutions");
                numberOfSolutionsKept.Value = "1";
                constraintSetElement.Attributes.Append(numberOfSolutionsKept);
            }

            xmlAnalysisElt.AppendChild(constraintSetElement);
            // ###
            // Solutions
            XmlElement solutionsElt = xmlDoc.CreateElement("Solutions");
            xmlAnalysisElt.AppendChild(solutionsElt);
            SaveSolution(analysis, sol, selSolution, true /* unique */, solutionsElt, xmlDoc );
        }

        public void SaveSolution(Analysis analysis, Solution sol, SelSolution selSolution, bool unique, XmlElement solutionsElt, XmlDocument xmlDoc)
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
                    Save(boxLayer, layersElt, xmlDoc);

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

            // Is selected ?
            if (null != selSolution)
            {
                // selected attribute
                XmlAttribute selAttribute = xmlDoc.CreateAttribute("Selected");
                selAttribute.Value = "true";
                solutionElt.Attributes.Append(selAttribute);

                // truck analyses
                XmlElement truckAnalysesElt = xmlDoc.CreateElement("TruckAnalyses");
                solutionElt.AppendChild(truckAnalysesElt);

                foreach (TruckAnalysis truckAnalysis in selSolution.TruckAnalyses)
                    Save(truckAnalysis, unique, truckAnalysesElt, xmlDoc);
            }
        }

        public void Save(TruckAnalysis truckAnalysis, bool unique, XmlElement truckAnalysesElt, XmlDocument xmlDoc)
        {
            XmlElement truckAnalysisElt = xmlDoc.CreateElement("TruckAnalysis");
            truckAnalysesElt.AppendChild(truckAnalysisElt);
            // name
            XmlAttribute nameAttribute = xmlDoc.CreateAttribute("Name");
            nameAttribute.Value = truckAnalysis.Name;
            truckAnalysisElt.Attributes.Append(nameAttribute);
            // description
            XmlAttribute descriptionAttribute = xmlDoc.CreateAttribute("Description");
            descriptionAttribute.Value = truckAnalysis.Description;
            truckAnalysisElt.Attributes.Append(descriptionAttribute);
            // truckId
            XmlAttribute truckIdAttribute = xmlDoc.CreateAttribute("TruckId");
            truckIdAttribute.Value = string.Format("{0}", truckAnalysis.TruckProperties.Guid);
            truckAnalysisElt.Attributes.Append(truckIdAttribute);
            // constraint set
            XmlElement contraintSetElt = xmlDoc.CreateElement("ConstraintSet");
            truckAnalysesElt.AppendChild(contraintSetElt);            
            // multilayer allowed
            XmlAttribute multilayerAllowedAttribute = xmlDoc.CreateAttribute("MultilayerAllowed");
            multilayerAllowedAttribute.Value = truckAnalysis.ConstraintSet.MultilayerAllowed ? "True" : "False";
            contraintSetElt.Attributes.Append(multilayerAllowedAttribute);
            // allowed pallet orientation
            XmlAttribute palletOrientationsAttribute = xmlDoc.CreateAttribute("AllowedPalletOrientations");
            string sAllowedPalletOrientations = string.Empty;
            if (truckAnalysis.ConstraintSet.AllowPalletOrientationX)
                sAllowedPalletOrientations += "X";
            if (truckAnalysis.ConstraintSet.AllowPalletOrientationY)
            {
                if (!string.IsNullOrEmpty(sAllowedPalletOrientations))
                    sAllowedPalletOrientations += ",";
                sAllowedPalletOrientations += "Y";
            }
            palletOrientationsAttribute.Value = sAllowedPalletOrientations;
            contraintSetElt.Attributes.Append(palletOrientationsAttribute);
            // min distance pallet / truck wall
            XmlAttribute minDistancePalletWallAttribute = xmlDoc.CreateAttribute("MinDistancePalletWall");
            minDistancePalletWallAttribute.Value = string.Format("{0}", truckAnalysis.ConstraintSet.MinDistancePalletTruckWall);
            contraintSetElt.Attributes.Append(minDistancePalletWallAttribute);
            // min distance pallet / truck roof
            XmlAttribute minDistancePalletRoofAttribute = xmlDoc.CreateAttribute("MinDistancePalletRoof");
            minDistancePalletRoofAttribute.Value = string.Format("{0}", truckAnalysis.ConstraintSet.MinDistancePalletTruckWall);
            contraintSetElt.Attributes.Append(minDistancePalletRoofAttribute);
            // solutions
            XmlElement truckSolutionsElt = xmlDoc.CreateElement("Solutions");
            truckAnalysisElt.AppendChild(truckSolutionsElt);
            int solutionIndex = 0;
            foreach (TruckSolution truckSolution in truckAnalysis.Solutions)
            {
                if (!unique || truckAnalysis.HasSolutionSelected(solutionIndex))
                {
                    XmlElement truckSolutionElt = xmlDoc.CreateElement("Solution");
                    truckSolutionsElt.AppendChild(truckSolutionElt);
                    // title
                    XmlAttribute titleAttribute = xmlDoc.CreateAttribute("Title");
                    titleAttribute.Value = truckSolution.Title;
                    truckSolutionsElt.Attributes.Append(titleAttribute);
                    // selected
                    XmlAttribute selectedAttribute = xmlDoc.CreateAttribute("Selected");
                    selectedAttribute.Value = truckAnalysis.HasSolutionSelected(solutionIndex) ? "True" : "False";
                    truckSolutionElt.Attributes.Append(selectedAttribute);
                    // layer
                    XmlElement layersElt = xmlDoc.CreateElement("Layers");
                    truckSolutionElt.AppendChild(layersElt);
                    Save(truckSolution.Layer, layersElt, xmlDoc);
                }
                // increment index
                ++solutionIndex;
            }
        }

        public void Save(BoxLayer boxLayer, XmlElement layersElt, XmlDocument xmlDoc)
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
                axisLengthAttribute.Value = HalfAxis.ToString(boxPosition.DirectionLength);
                boxPositionElt.Attributes.Append(axisLengthAttribute);
                // AxisWidth
                XmlAttribute axisWidthAttribute = xmlDoc.CreateAttribute("AxisWidth");
                axisWidthAttribute.Value = HalfAxis.ToString(boxPosition.DirectionWidth);
                boxPositionElt.Attributes.Append(axisWidthAttribute);
            }
        }
        #endregion

        #region Close
        public virtual void Close()
        {
            // remove all analysis and items
            // -> this should close any listening forms
            while (_caseAnalyses.Count > 0)
                RemoveItem(_caseAnalyses[0]);
            while (_analyses.Count > 0)
                RemoveItem(_analyses[0]);
            while (_typeList.Count > 0)
                RemoveItem(_typeList[0]);
            NotifyOnDocumentClosed();
        }
        #endregion

        #region Helpers
        private ItemBase GetTypeByGuid(Guid guid)
        {
            foreach (ItemBase type in _typeList)
                if (type.Guid == guid)
                    return type;
            throw new Exception(string.Format("No type with Guid = {0}", guid.ToString()));
        }
        private static string BitmapToString(Bitmap bmp)
        {
            byte[] bmpBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                bmpBytes = ms.GetBuffer();
                ms.Close();
            }
            return System.Convert.ToBase64String(bmpBytes);
        }
        private static Bitmap StringToBitmap(string bmpData)
        {
            byte[] bytes = System.Convert.FromBase64String(bmpData);
            return new Bitmap(new System.IO.MemoryStream(bytes));
        }
        #endregion

        #region Methods to be overriden
        public virtual void Modify()
        {
        }
        #endregion

        #region Listener notification methods
        public void AddListener(IDocumentListener listener)
        {
            _listeners.Add(listener);
        }
        private void NotifyOnNewTypeCreated(ItemBase item)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewTypeCreated(this, item);
        }
        private void NotifyOnNewAnalysisCreated(Analysis analysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewAnalysisCreated(this, analysis);
        }
        private void NotifyOnNewCaseAnalysisCreated(CaseAnalysis caseAnalysis)
        { 
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewCaseAnalysisCreated(this, caseAnalysis);
        }
        internal void NotifyOnNewSolutionAdded(Analysis analysis, SelSolution selSolution)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewSolutionAdded(this, analysis, selSolution);
        }
        internal void NotifyOnNewTruckAnalysisCreated(Analysis analysis, SelSolution selSolution, TruckAnalysis truckAnalysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewTruckAnalysisCreated(this, analysis, selSolution, truckAnalysis);
        }
        private void NotifyOnDocumentClosed()
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnDocumentClosed(this);
        }
        private void NotifyOnTypeRemoved(ItemBase item)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnTypeRemoved(this, item);
        }
        private void NotifyOnAnalysisRemoved(Analysis analysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnAnalysisRemoved(this, analysis);
        }
        private void NotifyOnCaseAnalysisRemoved(CaseAnalysis caseAnalysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnCaseAnalysisRemoved(this, caseAnalysis);
        }
        internal void NotifyOnSolutionRemoved(Analysis analysis, SelSolution selSolution)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnSolutionRemoved(this, analysis, selSolution);
        }
        internal void NotifyOnTruckAnalysisRemoved(SelSolution selSolution, TruckAnalysis truckAnalysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnTruckAnalysisRemoved(this, selSolution.Analysis, selSolution, truckAnalysis);
        }
        #endregion
    }
    #endregion
}
