#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Globalization;

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
        void OnNewCasePalletAnalysisCreated(Document doc, CasePalletAnalysis analysis);
        void OnNewBoxCaseAnalysisCreated(Document doc, BoxCaseAnalysis analysis);
        void OnNewBoxCasePalletAnalysisCreated(Document doc, BoxCasePalletAnalysis caseAnalysis);
        void OnNewTruckAnalysisCreated(Document doc, CasePalletAnalysis analysis, SelCasePalletSolution selSolution, TruckAnalysis truckAnalysis);
        void OnNewECTAnalysisCreated(Document doc, CasePalletAnalysis analysis, SelCasePalletSolution selSolution, ECTAnalysis ectAnalysis);
        // remove
        void OnTypeRemoved(Document doc, ItemBase itemBase);
        void OnAnalysisRemoved(Document doc, ItemBase itemBase); 
        /*
        void OnCasePalletAnalysisRemoved(Document doc, CasePalletAnalysis analysis);
        void OnBoxCaseAnalysisRemoved(Document doc, BoxCaseAnalysis analysis);
        void OnCaseAnalysisRemoved(Document doc, BoxCasePalletAnalysis caseAnalysis);
         */ 
        void OnTruckAnalysisRemoved(Document doc, CasePalletAnalysis analysis, SelCasePalletSolution selSolution, TruckAnalysis truckAnalysis);
        void OnECTAnalysisRemoved(Document doc, CasePalletAnalysis analysis, SelCasePalletSolution selSolution, ECTAnalysis ectAnalysis);
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
        private List<CasePalletAnalysis> _casePalletAnalyses = new List<CasePalletAnalysis>();
        private List<BoxCaseAnalysis> _boxCaseAnalyses = new List<BoxCaseAnalysis>();
        private List<BoxCasePalletAnalysis> _boxCasePalletOptimizations = new List<BoxCasePalletAnalysis>();
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
        public BoxProperties CreateNewCase(BoxProperties boxProp)
        {
            // instantiate and initialize
            BoxProperties boxPropClone = new BoxProperties(this
                , boxProp.Length
                , boxProp.Width
                , boxProp.Height
                , boxProp.InsideLength
                , boxProp.InsideWidth
                , boxProp.InsideHeight);
            boxPropClone.Weight = boxProp.Weight;
            boxPropClone.Name = boxProp.Name;
            boxPropClone.Description = boxProp.Description;
            boxPropClone.SetAllColors(boxProp.Colors);
            // insert in list
            _typeList.Add(boxPropClone);
            // notify listeners
            NotifyOnNewTypeCreated(boxPropClone);
            Modify();
            return boxPropClone;
        }

        public CaseOfBoxesProperties CreateNewCaseOfBoxes(
            string name, string description
            , BoxProperties boxProperties
            , CaseDefinition caseDefinition
            , CaseOptimConstraintSet constraintSet)
        {
            CaseOfBoxesProperties caseProperties = new CaseOfBoxesProperties(this, boxProperties, caseDefinition, constraintSet);
            caseProperties.Name = name;
            caseProperties.Description = description;
            // insert in list
            _typeList.Add(caseProperties);
            // notify listeners
            NotifyOnNewTypeCreated(caseProperties);
            Modify();
            return caseProperties;
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

        public CylinderProperties CreateNewCylinder(
            string name, string description
            , double radius, double height
            , double weight
            , Color colorTop
            , Color colorWall)
        {
            CylinderProperties cylinder = new CylinderProperties(this, name, description, radius, height, weight, colorTop, colorWall);
            // insert in list
            _typeList.Add(cylinder);
            // notify listeners
            NotifyOnNewTypeCreated(cylinder);
            Modify();
            return cylinder;        
        }

        public void AddType(ItemBase item)
        {
            // insert in list
            _typeList.Add(item);
            // notify listeners
            NotifyOnNewTypeCreated(item);
            Modify();
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
        public InterlayerProperties CreateNewInterlayer(InterlayerProperties interlayerProp)
        {
            // instantiate and intialize
            InterlayerProperties interlayerClone = new InterlayerProperties(
                this, interlayerProp.Name, interlayerProp.Description
                , interlayerProp.Length, interlayerProp.Width, interlayerProp.Thickness
                , interlayerProp.Weight
                , interlayerProp.Color);
            // insert in list
            _typeList.Add(interlayerClone);
            // notify listeners
            NotifyOnNewTypeCreated(interlayerClone);
            Modify();
            return interlayerClone;       
        }
        public PalletProperties CreateNewPallet(
            string name, string description
            , string typeName
            , double length, double width, double height
            , double weight)
        {
            PalletProperties palletProperties = new PalletProperties(this, typeName, length, width, height);
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

        public PalletProperties CreateNewPallet(PalletProperties palletProp)
        {
            PalletProperties palletPropClone = new PalletProperties(this, palletProp.TypeName, palletProp.Length, palletProp.Width, palletProp.Height);
            palletPropClone.Name = palletProp.Name;
            palletPropClone.Description = palletProp.Description;
            palletPropClone.Weight = palletProp.Weight;
            palletPropClone.Color = palletProp.Color;
            palletPropClone.AdmissibleLoadWeight = palletProp.AdmissibleLoadWeight;
            // insert in list
            _typeList.Add(palletPropClone);
            // notify listeners
            NotifyOnNewTypeCreated(palletPropClone);
            Modify();
            return palletPropClone;           
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
        public CasePalletAnalysis CreateNewCasePalletAnalysis(
            string name, string description
            , BProperties box, PalletProperties pallet, InterlayerProperties interlayer
            , PalletConstraintSet constraintSet
            , ICasePalletAnalysisSolver solver)
        {
            CasePalletAnalysis analysis = new CasePalletAnalysis(box, pallet, interlayer, constraintSet);
            analysis.Name = name;
            analysis.Description = description;
            // insert in list
            _casePalletAnalyses.Add(analysis);
            // compute analysis
            solver.ProcessAnalysis(analysis);
            if (analysis.Solutions.Count < 1)
            {	// remove analysis from list if it has no valid solution
                _casePalletAnalyses.Remove(analysis);
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
        /// <param name="name">Name of analysis</param>
        /// <param name="description">Description</param>
        /// <param name="box">Case</param>
        /// <param name="pallet">Pallet</param>
        /// <param name="interlayer">Interlayer</param>
        /// <param name="constraintSet">PalletConstraintSet</param>
        /// <param name="solutions">Solutions</param>
        /// <returns>CasePalletAnalysis generated using input parameters</returns>
        public CasePalletAnalysis CreateNewCasePalletAnalysis(
            string name, string description
            , BProperties box, PalletProperties pallet, InterlayerProperties interlayer
            , PalletConstraintSet constraintSet
            , List<CasePalletSolution> solutions)
        {
            CasePalletAnalysis analysis = new CasePalletAnalysis(box, pallet, interlayer, constraintSet);
            analysis.Name = name;
            analysis.Description = description;
            // insert in list
            _casePalletAnalyses.Add(analysis);
            // set solutions
            analysis.Solutions = solutions;
            // notify listeners
            NotifyOnNewAnalysisCreated(analysis);
            // set solution selected if it is unique
            if (solutions.Count == 1)
                analysis.SelectSolutionByIndex(0);
            return analysis;
        }

        public BoxCaseAnalysis CreateNewBoxCaseAnalysis(
            string name, string description
            , BoxProperties boxProperties, BoxProperties caseProperties
            , BoxCaseConstraintSet constraintSet
            , List<BoxCaseSolution> solutions)
        {
            BoxCaseAnalysis analysis = new BoxCaseAnalysis(boxProperties, caseProperties, constraintSet);
            analysis.Name = name;
            analysis.Description = description;
            // insert in list
            _boxCaseAnalyses.Add(analysis);
            // set solutions
            analysis.Solutions = solutions;
            // notify listeners
            NotifyOnNewBoxCaseAnalysis(analysis);
            // set solution selected if it is unique
            if (solutions.Count == 1)
                analysis.SelectSolutionByIndex(0);
            return analysis;
        }

        public BoxCaseAnalysis CreateNewBoxCaseAnalysis(
            string name, string description
            , BoxProperties boxProperties, BoxProperties caseProperties
            , BoxCaseConstraintSet constraintSet
            , IBoxCaseAnalysisSolver solver)
        {
            BoxCaseAnalysis analysis = new BoxCaseAnalysis(boxProperties, caseProperties, constraintSet);
            analysis.Name = name;
            analysis.Description = description;
            // insert in list
            _boxCaseAnalyses.Add(analysis);
            // compute analysis
            solver.ProcessAnalysis(analysis);
            if (analysis.Solutions.Count < 1)
            {	// remove analysis from list if it has no valid solution
                _boxCaseAnalyses.Remove(analysis);
                return null;
            }
            // notify listeners
            NotifyOnNewBoxCaseAnalysis(analysis);
            Modify();
            return analysis;
        }

        public BoxCasePalletAnalysis CreateNewBoxCasePalletOptimization(
            string name, string description
            , BoxProperties bProperties
            , BoxCasePalletConstraintSet constraintSet
            , List<PalletSolutionDesc> palletSolutionList
            , IBoxCasePalletAnalysisSolver solver)
        {
            BoxCasePalletAnalysis analysis = new BoxCasePalletAnalysis(bProperties, palletSolutionList, constraintSet);
            analysis.Name = name;
            analysis.Description = description;
            // insert in list
            _boxCasePalletOptimizations.Add(analysis);
            // compute analysis
            if (null != solver)
            {
                solver.ProcessAnalysis(analysis);
                if (analysis.Solutions.Count < 1)
                {	// remove analysis from list if it has no valid solution
                    _boxCasePalletOptimizations.Remove(analysis);
                    _log.InfoFormat("Failed to find any solution {0}", analysis.Name);
                    return null;
                }
            }
            // notify listeners
            NotifyOnNewCaseAnalysisCreated(analysis);
            Modify();
            return analysis;
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
                || item.GetType() == typeof(CaseOfBoxesProperties)
                || item.GetType() == typeof(PalletProperties)
                || item.GetType() == typeof(InterlayerProperties)
                || item.GetType() == typeof(TruckProperties))
            {
                NotifyOnTypeRemoved(item);
                if (!_typeList.Remove(item))
                    _log.Warn(string.Format("Failed to properly remove item {0}", item.Name));
            }
            else if (item.GetType() == typeof(CasePalletAnalysis))
            {
                NotifyOnAnalysisRemoved(item as CasePalletAnalysis);
                if (!_casePalletAnalyses.Remove(item as CasePalletAnalysis))
                    _log.Warn(string.Format("Failed to properly remove analysis {0}", item.Name));
            }
            else if (item.GetType() == typeof(BoxCaseAnalysis))
            {
                NotifyOnAnalysisRemoved(item as BoxCaseAnalysis);
                if (!_boxCaseAnalyses.Remove(item as BoxCaseAnalysis))
                    _log.Warn(string.Format("Failed to properly remove analysis {0}", item.Name));
            }
            else if (item.GetType() == typeof(TruckAnalysis))
            {
                TruckAnalysis truckAnalysis = item as TruckAnalysis;
                NotifyOnTruckAnalysisRemoved(truckAnalysis.ParentSelSolution, truckAnalysis);
            }
            else if (item.GetType() == typeof(BoxCasePalletAnalysis))
            {
                BoxCasePalletAnalysis caseAnalysis = item as BoxCasePalletAnalysis;
                NotifyOnAnalysisRemoved(caseAnalysis);
                if (!_boxCasePalletOptimizations.Remove(caseAnalysis))
                    _log.Warn(string.Format("Failed to properly remove analysis {0}", item.Name));
            }
            else if (item.GetType() == typeof(ECTAnalysis))
            {
                ECTAnalysis ectAnalysis = item as ECTAnalysis;
                NotifyOnECTAnalysisRemoved(ectAnalysis.ParentSelSolution, ectAnalysis);
            }
            else if (item.GetType() == typeof(SelCasePalletSolution))            {}
            else if (item.GetType() == typeof(SelBoxCasePalletSolution))         {}
            else if (item.GetType() == typeof(SelBoxCaseSolution))               {}
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
            foreach (ItemBase item in _casePalletAnalyses)
            {
                if (item == analysisToRename)
                    continue;
                if (item.Name.Trim().ToLower() == name.Trim().ToLower())
                    return false;
            }
            foreach (ItemBase item in _boxCasePalletOptimizations)
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
        /// <summary>
        /// Builds and return a list of cylinders
        /// </summary>
        public List<CylinderProperties> Cylinders
        {
            get
            {
                List<CylinderProperties> cylinderList = new List<CylinderProperties>();
                foreach (ItemBase item in _typeList)
                {
                    CylinderProperties cylinderProperties = item as CylinderProperties;
                    if (null != cylinderProperties)
                        cylinderList.Add(cylinderProperties);
                }
                return cylinderList;
            }
        }
        /// <summary>
        /// Builds and returns a list of pallets
        /// </summary>
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
        /// <summary>
        /// Builds and returns a list of interlayers
        /// </summary>
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
        /// <summary>
        /// Build and returns a list of trucks
        /// </summary>
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
        /// <summary>
        /// Get list of analyses
        /// </summary>
        public List<CasePalletAnalysis> Analyses
        {
            get { return _casePalletAnalyses; }
        }
        /// <summary>
        /// Returns true if pallet analysis can be created i.e. if documents contains at list a case and a pallet
        /// </summary>
        public bool CanCreateCasePalletAnalysis
        { get { return this.Cases.Count > 0 && this.Pallets.Count > 0; } }
        /// <summary>
        /// Returns true if a bundle analysis can be created i.e. if documents contains at list a bundle and a case
        /// </summary>
        public bool CanCreateBundlePalletAnalysis
        { get { return this.Bundles.Count > 0 && this.Pallets.Count > 0; } }
        /// <summary>
        /// Returns true if a box case analysis can be created i.e. if document contains at list one box and one case
        /// </summary>
        public bool CanCreateBoxCaseAnalysis
        { get { return this.Boxes.Count > 0 && this.Cases.Count > 0; } }
        /// <summary>
        /// Returns true if a case analysis can be created i.e. if documents contains at list a box and pallet solutions database is not empty
        /// </summary>
        public bool CanCreateBoxCasePalletAnalysis
        { get { return this.Boxes.Count > 0 && !PalletSolutionDatabase.Instance.IsEmpty; } }
        /// <summary>
        /// Returns true if user can proceed to case optimization i.e. if documents contains at list one box and one pallet 
        /// </summary>
        public bool CanCreateCaseOptimization
        { get { return this.Boxes.Count > 0 && this.Pallets.Count > 0; } }
        /// <summary>
        /// Returns true if a cylinder/pallet analysis can be created i.e. if document contains at list one cylinder and one pallet
        /// </summary>
        public bool CanCreateCylinderPalletAnalysis
        { get { return this.Cylinders.Count > 0 && this.Pallets.Count > 0; } }
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
            {
                try
                {
                    _dateCreated = System.Convert.ToDateTime(docElement.Attributes["DateCreated"].Value, new CultureInfo("en-US"));
                }
                catch (Exception /*ex*/)
                {
                    _dateCreated = DateTime.Now;
                    _log.Debug("Failed to load date of creation correctly: Loading file generated with former version?");
                }
            }

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
                            else if (string.Equals(itemPropertiesNode.Name, "CaseOfBoxesProperties", StringComparison.CurrentCultureIgnoreCase))
                                LoadCaseOfBoxesProperties(itemPropertiesNode as XmlElement);
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
        #region Load containers / basics element
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
            bool hasTape = false;
            double tapeWidth = 0.0;
            Color tapeColor = Color.Black;
            foreach (XmlNode node in eltBoxProperties.ChildNodes)
            {
                if (string.Equals(node.Name, "FaceColors", StringComparison.CurrentCultureIgnoreCase))
                {
                    XmlElement faceColorList = node as XmlElement;
                    LoadFaceColors(faceColorList, ref colors);
                }
                else if (string.Equals(node.Name, "Textures", StringComparison.CurrentCultureIgnoreCase))
                {
                    XmlElement textureElt = node as XmlElement;
                    LoadTextureList(textureElt, ref listTexture);
                }
                else if (string.Equals(node.Name, "Tape", StringComparison.CurrentCultureIgnoreCase))
                {
                    XmlElement tapeElt = node as XmlElement;
                    hasTape = LoadTape(tapeElt, out tapeWidth,  out tapeColor);
                }
            }
            // create new BoxProperties instance
            BoxProperties boxProperties = null;
            if (!string.IsNullOrEmpty(sInsideLength)) // case
                boxProperties = CreateNewCase(
                sname
                , sdescription
                , System.Convert.ToDouble(slength, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(swidth, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(sheight, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(sInsideLength, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(sInsideWidth, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(sInsideHeight, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(sweight, System.Globalization.CultureInfo.InvariantCulture)
                , colors);
            else
                boxProperties = CreateNewBox(
                sname
                , sdescription
                , System.Convert.ToDouble(slength, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(swidth, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(sheight, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(sweight, System.Globalization.CultureInfo.InvariantCulture)
                , colors);
            boxProperties.Guid = new Guid(sid);
            boxProperties.TextureList = listTexture;
            // tape
            boxProperties.ShowTape = hasTape;
            boxProperties.TapeColor = tapeColor;
            boxProperties.TapeWidth = tapeWidth;
        }
        private void LoadCaseOfBoxesProperties(XmlElement eltCaseOfBoxesProperties)
        {
            string sid = eltCaseOfBoxesProperties.Attributes["Id"].Value;
            string sname = eltCaseOfBoxesProperties.Attributes["Name"].Value;
            string sdescription = eltCaseOfBoxesProperties.Attributes["Description"].Value;
            string sweight = eltCaseOfBoxesProperties.Attributes["Weight"].Value;
            string sBoxId = eltCaseOfBoxesProperties.Attributes["InsideBoxId"].Value;

            CaseDefinition caseDefinition = null;
            CaseOptimConstraintSet constraintSet = null;
            Color[] colors = new Color[6];
            List<Pair<HalfAxis.HAxis, Texture>> listTexture = new List<Pair<HalfAxis.HAxis,Texture>>();
            foreach (XmlNode node in eltCaseOfBoxesProperties.ChildNodes)
            {
                if (string.Equals(node.Name, "FaceColors", StringComparison.CurrentCultureIgnoreCase))
                {
                    XmlElement faceColorList = node as XmlElement;
                    LoadFaceColors(faceColorList, ref colors);
                }
                else if (string.Equals(node.Name, "Textures", StringComparison.CurrentCultureIgnoreCase))
                {
                    XmlElement textureElt = node as XmlElement;
                    LoadTextureList(textureElt, ref listTexture);
                }
                else if (string.Equals(node.Name, "CaseDefinition", StringComparison.CurrentCultureIgnoreCase))
                {
                    XmlElement caseDefinitionElt = node as XmlElement;
                    LoadCaseDefinition(caseDefinitionElt, out caseDefinition);
                }
                else if (string.Equals(node.Name, "OptimConstraintSet", StringComparison.CurrentCultureIgnoreCase))
                {
                    XmlElement constraintSetElt = node as XmlElement;
                    LoadOptimConstraintSet(constraintSetElt, out constraintSet);
                }
            }
            CaseOfBoxesProperties caseOfBoxProperties = CreateNewCaseOfBoxes(
                sname
                , sdescription
                , GetTypeByGuid(new Guid(sBoxId)) as BoxProperties
                , caseDefinition
                , constraintSet);
            caseOfBoxProperties.Weight = Convert.ToDouble(sweight, System.Globalization.CultureInfo.InvariantCulture);
            caseOfBoxProperties.Guid = new Guid(sid);
            caseOfBoxProperties.TextureList = listTexture;
            caseOfBoxProperties.SetAllColors( colors );
        }
        private void LoadFaceColors(XmlElement eltColors, ref Color[] colors)
        {
            foreach (XmlNode faceColorNode in eltColors.ChildNodes)
            {
                XmlElement faceColorElt = faceColorNode as XmlElement;
                string sFaceIndex = faceColorElt.Attributes["FaceIndex"].Value;
                string sColorArgb = faceColorElt.Attributes["Color"].Value;
                int iFaceIndex = System.Convert.ToInt32(sFaceIndex);
                Color faceColor = Color.FromArgb(System.Convert.ToInt32(sColorArgb));
                colors[iFaceIndex] = faceColor;
            }
        }
        private void LoadTextureList(XmlElement eltTextureList, ref List<Pair<HalfAxis.HAxis, Texture>> listTexture)
        {
            foreach (XmlNode faceTextureNode in eltTextureList.ChildNodes)
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
        private bool LoadTape(XmlElement eltTape, out double tapeWidth, out Color tapeColor)
        {
            tapeWidth = 0.0;
            tapeColor = Color.Black;
            try
            {
                tapeWidth = Convert.ToDouble(eltTape.Attributes["TapeWidth"].Value);
                string sColorArgb = eltTape.Attributes["TapeColor"].Value;
                tapeColor = Color.FromArgb(System.Convert.ToInt32(sColorArgb));
            }
            catch (Exception /*ex*/)
            {
                return false;
            }
            return true;
        }
        private void LoadCaseDefinition(XmlElement eltCaseDefinition, out CaseDefinition caseDefinition)
        {
            string sArrangement = eltCaseDefinition.Attributes["Arrangement"].Value;
            string sDim = eltCaseDefinition.Attributes["Orientation"].Value;
            int[] iOrientation = Document.ParseInt2(sDim);
            caseDefinition = new CaseDefinition(
                CaseOptimArrangement.TryParse(sArrangement)
                , iOrientation[0]
                , iOrientation[1]);
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

            if ("0" == stype)
                stype = "Block";
            else if ("1" == stype)
                stype = "UK Standard";

            // create new PalletProperties instance
            PalletProperties palletProperties = CreateNewPallet(
                sname
                , sdescription
                , stype
                , System.Convert.ToDouble(slength, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(swidth, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(sheight, System.Globalization.CultureInfo.InvariantCulture)
                , System.Convert.ToDouble(sweight, System.Globalization.CultureInfo.InvariantCulture));
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
                , Convert.ToDouble(slength, System.Globalization.CultureInfo.InvariantCulture)
                , Convert.ToDouble(swidth, System.Globalization.CultureInfo.InvariantCulture)
                , Convert.ToDouble(sthickness, System.Globalization.CultureInfo.InvariantCulture)
                , Convert.ToDouble(sweight, System.Globalization.CultureInfo.InvariantCulture)
                , Color.FromArgb(System.Convert.ToInt32(sColor)));
            interlayerProperties.Guid = new Guid(sid);
        }
        private void LoadBundleProperties(XmlElement eltBundleProperties)
        {
            string sid = eltBundleProperties.Attributes["Id"].Value;
            string sname = eltBundleProperties.Attributes["Name"].Value;
            string sdescription = eltBundleProperties.Attributes["Description"].Value;
            double length = double.Parse(eltBundleProperties.Attributes["Length"].Value, System.Globalization.CultureInfo.InvariantCulture);
            double width = double.Parse(eltBundleProperties.Attributes["Width"].Value, System.Globalization.CultureInfo.InvariantCulture);
            double unitThickness = double.Parse(eltBundleProperties.Attributes["UnitThickness"].Value, System.Globalization.CultureInfo.InvariantCulture);
            double unitWeight = double.Parse(eltBundleProperties.Attributes["UnitWeight"].Value, System.Globalization.CultureInfo.InvariantCulture);
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
        #endregion

        #region Load case optimisation
        private void LoadOptimConstraintSet(XmlElement eltConstraintSet, out CaseOptimConstraintSet constraintSet)
        {
            string sNoWalls = eltConstraintSet.Attributes["NumberOfWalls"].Value;
            int[] iNoWalls = ParseInt3(sNoWalls);
            double wallThickness = Convert.ToDouble(eltConstraintSet.Attributes["WallThickness"].Value);
            constraintSet = new CaseOptimConstraintSet(iNoWalls, wallThickness, Vector3D.Zero, Vector3D.Zero, false); 
        }
        #endregion

        #region Load analysis
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
                PalletConstraintSet constraintSet = null;
                List<CasePalletSolution> solutions = new List<CasePalletSolution>();
                List<int> selectedIndices = new List<int>();

                foreach (XmlNode node in eltAnalysis.ChildNodes)
                {
                    // load constraint set
                    if (string.Equals(node.Name, "ConstraintSetBox", StringComparison.CurrentCultureIgnoreCase))
                        constraintSet = LoadCasePalletConstraintSet_Box(node as XmlElement);
                    else if (string.Equals(node.Name, "ConstraintSetBundle", StringComparison.CurrentCultureIgnoreCase))
                        constraintSet = LoadCasePalletConstraintSet_Bundle(node as XmlElement);
                    // load solutions
                    else if (string.Equals(node.Name, "Solutions", StringComparison.CurrentCultureIgnoreCase))
                    {
                        int indexSol = 0;
                        foreach (XmlNode solutionNode in node.ChildNodes)
                        {
                            XmlElement eltSolution = solutionNode as XmlElement;
                            solutions.Add(LoadCasePalletSolution(eltSolution));
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
                CasePalletAnalysis analysis = CreateNewCasePalletAnalysis(
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
                                            SelCasePalletSolution selSolution = analysis.GetSelSolutionBySolutionIndex(indexSol);
                                            LoadTruckAnalysis(truckAnalysisElt, selSolution);
                                        }
                                    }
                                }
                                else if (string.Equals("ECTAnalyses", solutionInnerNode.Name, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    XmlElement ectAnalysesElt = solutionInnerNode as XmlElement;
                                    foreach (XmlNode ectAnalysisNode in ectAnalysesElt.ChildNodes)
                                    {
                                        if (string.Equals("EctAnalysis", ectAnalysisNode.Name, StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            XmlElement ectAnalysisElt = ectAnalysisNode as XmlElement;
                                            SelCasePalletSolution selSolution = analysis.GetSelSolutionBySolutionIndex(indexSol);
                                            LoadECTAnalysis(ectAnalysisElt, selSolution);
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
                // load constraint set / pallet solutions descriptors / solution list
                BoxCasePalletConstraintSet constraintSet = null;
                List<PalletSolutionDesc> palletSolutionDescriptors = new List<PalletSolutionDesc>();
                XmlElement caseSolutionsElt = null;

                // first load ConstraintSetCase / PalletSolutionDescriptors / CaseSolutions
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
                BoxCasePalletAnalysis caseAnalysis = CreateNewBoxCasePalletOptimization(
                    sName
                    , sDescription
                    , GetTypeByGuid(new Guid(sBoxId)) as BoxProperties
                    , constraintSet
                    , palletSolutionDescriptors
                    , null
                    );
  
                // second : solutions
                List<BoxCasePalletSolution> caseSolutions = new List<BoxCasePalletSolution>();
                int indexSol = 0;
                List<int> selectedIndices = new List<int>();
                foreach (XmlNode solutionNode in caseSolutionsElt.ChildNodes)
                {
                    XmlElement eltSolution = solutionNode as XmlElement;
                    caseSolutions.Add(LoadBoxCasePalletSolution(eltSolution, caseAnalysis));

                    // is solution selected ?
                    if (null != eltSolution.Attributes["Selected"] && "true" == eltSolution.Attributes["Selected"].Value)
                        selectedIndices.Add(indexSol);
                    ++indexSol;
                }
                caseAnalysis.Solutions = caseSolutions;

                foreach (int index in selectedIndices)
                    caseAnalysis.SelectSolutionByIndex(index);
            }
            else if (string.Equals(eltAnalysis.Name, "AnalysisBoxCase", StringComparison.CurrentCultureIgnoreCase))
            {
                // load caseId
                string sCaseId = eltAnalysis.Attributes["CaseId"].Value;

                // load constraint set / solution list
                BoxCaseConstraintSet constraintSet = null;
                List<BoxCaseSolution> solutions = new List<BoxCaseSolution>();
                List<int> selectedIndices = new List<int>();

                // first load BoxCaseConstraintSet / BoxCaseSolution(s)
                XmlElement boxCaseSolutionsElt = null;
                foreach (XmlNode node in eltAnalysis.ChildNodes)
                {
                    // load constraint set
                    if (string.Equals(node.Name, "ConstraintSetCase", StringComparison.CurrentCultureIgnoreCase))
                        constraintSet = LoadBoxCaseConstraintSet(node as XmlElement);
                    // load solutions
                    else if (string.Equals(node.Name, "Solutions", StringComparison.CurrentCultureIgnoreCase))
                    {
                        boxCaseSolutionsElt = node as XmlElement;

                        int indexSol = 0;
                        foreach (XmlNode solutionNode in boxCaseSolutionsElt.ChildNodes)
                        {
                            XmlElement eltSolution = solutionNode as XmlElement;
                            solutions.Add(LoadBoxCaseSolution(eltSolution));
                            // is solution selected ?
                            if (null != eltSolution.Attributes["Selected"] && "true" == eltSolution.Attributes["Selected"].Value)
                                selectedIndices.Add(indexSol);
                            ++indexSol;
                        }
                    }
                }
                 
                // instantiate box/case analysis
                BoxCaseAnalysis analysis = CreateNewBoxCaseAnalysis(
                    sName
                    , sDescription
                    , GetTypeByGuid(new Guid(sBoxId)) as BoxProperties
                    , GetTypeByGuid(new Guid(sCaseId)) as BoxProperties
                    , constraintSet
                    , solutions
                    );

                // save selected solutions
                foreach (int indexSol in selectedIndices)
                    analysis.SelectSolutionByIndex(indexSol);
            }
        }

        private PalletSolutionDesc LoadPalletSolutionDescriptor(XmlElement palletSolutionDescriptorElt)
        {
            string palletDimensions = palletSolutionDescriptorElt.Attributes["PalletDimensions"].Value;
            string overhang = palletSolutionDescriptorElt.Attributes["PalletOverhang"].Value;
            string caseDimensions = palletSolutionDescriptorElt.Attributes["CaseDimensions"].Value;
            string caseInsideDimensions = palletSolutionDescriptorElt.Attributes["CaseInsideDimensions"].Value;
            string caseWeight = string.Empty;
            if (palletSolutionDescriptorElt.HasAttribute("CaseWeight"))
                caseWeight = palletSolutionDescriptorElt.Attributes["CaseWeight"].Value;
            else
                caseWeight = "0.0";
            string palletWeight = string.Empty;
            if (palletSolutionDescriptorElt.HasAttribute("palletWeight"))
                palletWeight = palletSolutionDescriptorElt.Attributes["PalletWeight"].Value;
            else
                palletWeight = "0.0";
            string caseCount = palletSolutionDescriptorElt.Attributes["CaseCount"].Value;
            string sGuid = palletSolutionDescriptorElt.Attributes["Id"].Value;
            string friendlyName = palletSolutionDescriptorElt.Attributes["FriendlyName"].Value;
            return new PalletSolutionDesc(PalletSolutionDatabase.Instance
                , palletDimensions
                , overhang
                , caseDimensions
                , caseInsideDimensions
                , caseWeight
                , palletWeight
                , caseCount
                , sGuid
                , friendlyName);
        }

        private BoxCasePalletConstraintSet LoadCaseConstraintSet(XmlElement eltConstraintSet)
        {
            BoxCasePalletConstraintSet constraints = new BoxCasePalletConstraintSet();
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
            // maximum case weight
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

        private BoxCaseConstraintSet LoadBoxCaseConstraintSet(XmlElement eltConstraintSet)
        {
            BoxCaseConstraintSet constraints = new BoxCaseConstraintSet();
            // allowed orthogonal axes
            if (eltConstraintSet.HasAttribute("AllowedBoxPositions"))
                constraints.AllowOrthoAxisString = eltConstraintSet.Attributes["AllowedBoxPositions"].Value;
            // maximum case weight
            if (constraints.UseMaximumCaseWeight = eltConstraintSet.HasAttribute("MaximumCaseWeight"))
                constraints.MaximumCaseWeight = double.Parse(eltConstraintSet.Attributes["MaximumCaseWeight"].Value);
            // allowed patterns
            if (constraints.UseMaximumNumberOfBoxes = eltConstraintSet.HasAttribute("ManimumNumberOfItems"))
                constraints.MaximumNumberOfBoxes = int.Parse(eltConstraintSet.Attributes["ManimumNumberOfItems"].Value);
            // number of solutions to keep
            if (constraints.UseNumberOfSolutionsKept = eltConstraintSet.HasAttribute("NumberOfSolutions"))
                constraints.NumberOfSolutionsKept = int.Parse(eltConstraintSet.Attributes["NumberOfSolutions"].Value);
            // sanity check
            if (!constraints.IsValid)
                throw new Exception("Invalid constraint set");
            return constraints;
        }

        private PalletConstraintSet LoadCasePalletConstraintSet_Box(XmlElement eltConstraintSet)
        {
            CasePalletConstraintSet constraints = new CasePalletConstraintSet();
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
            if (constraints.UseMaximumNumberOfCases = eltConstraintSet.HasAttribute("ManimumNumberOfItems"))
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
        PalletConstraintSet LoadCasePalletConstraintSet_Bundle(XmlElement eltConstraintSet)
        {
            BundlePalletConstraintSet constraints = new BundlePalletConstraintSet();
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
            if (constraints.UseMaximumNumberOfCases = eltConstraintSet.HasAttribute("ManimumNumberOfItems"))
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
        private CasePalletSolution LoadCasePalletSolution(XmlElement eltSolution)
        {
            // title -> instantiation
            string stitle = eltSolution.Attributes["Title"].Value;
            CasePalletSolution sol = new CasePalletSolution(null, stitle, true);
            // homogeneous layers
            if (eltSolution.HasAttribute("HomogeneousLayers"))
            {
                string sHomogeneousLayers = eltSolution.Attributes["HomogeneousLayers"].Value;
                sol.HasHomogeneousLayers = string.Equals(sHomogeneousLayers, "true", StringComparison.CurrentCultureIgnoreCase);
            }
            else
                sol.HasHomogeneousLayers = false;
            // limit reached
            if (eltSolution.HasAttribute("LimitReached"))
            {
                string sLimitReached = eltSolution.Attributes["LimitReached"].Value;
                sol.LimitReached = (CasePalletSolution.Limit)(int.Parse(sLimitReached));
            }
            // layers
            XmlElement eltLayers = eltSolution.ChildNodes[0] as XmlElement;
            foreach (XmlNode nodeLayer in eltLayers.ChildNodes)
                sol.Add( LoadLayer(nodeLayer as XmlElement));
            return sol;
        }
        private BoxCaseSolution LoadBoxCaseSolution(XmlElement eltSolution)
        {
            // pattern
            string patternName = eltSolution.Attributes["Pattern"].Value;
            // orientation
            HalfAxis.HAxis orthoAxis = HalfAxis.Parse(eltSolution.Attributes["OrthoAxis"].Value);
            // instantiate box case solution
            BoxCaseSolution sol = new BoxCaseSolution(null, orthoAxis, patternName);
            // limit reached
            if (eltSolution.HasAttribute("LimitReached"))
            {
                string sLimitReached = eltSolution.Attributes["LimitReached"].Value;
                sol.LimitReached = (BoxCaseSolution.Limit)(int.Parse(sLimitReached));
            }
            // layers
            XmlElement eltLayers = eltSolution.ChildNodes[0] as XmlElement;
            foreach (XmlNode nodeLayer in eltLayers.ChildNodes)
            {
                BoxLayer boxLayer = LoadLayer(nodeLayer as XmlElement) as BoxLayer;
                sol.Add(boxLayer);
            }
            return sol;
        }
        private BoxCasePalletSolution LoadBoxCasePalletSolution(XmlElement eltSolution, BoxCasePalletAnalysis analysis)
        {
            // title
            string stitle = eltSolution.Attributes["Title"].Value;
            // guid
            Guid guid = new Guid(eltSolution.Attributes["PalletSolutionId"].Value);
            // homogeneousLayers
            bool homogeneousLayers = string.Equals(eltSolution.Attributes["HomogeneousLayers"].Value, "true", StringComparison.CurrentCultureIgnoreCase);
            // instantiation
            BoxCasePalletSolution sol = new BoxCasePalletSolution(analysis, stitle, analysis.GetPalletSolutionDescByGuid(guid), homogeneousLayers);
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
        #endregion

        #region TruckAnalysis
        private TruckAnalysis LoadTruckAnalysis(XmlElement eltTruckAnalysis, SelCasePalletSolution selSolution)
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
        #endregion // Load truck analysis

        #region Load ECT analysis
        private ECTAnalysis LoadECTAnalysis(XmlElement eltEctAnalysis, SelCasePalletSolution selSolution)
        {
            string name = eltEctAnalysis.Attributes["Name"].Value;
            string description = eltEctAnalysis.Attributes["Description"].Value;
            ECTAnalysis ectAnalysis = selSolution.CreateNewECTAnalysis(name, description);
            // Cardboard
            foreach (XmlNode node in eltEctAnalysis.ChildNodes)
            {
                if (string.Equals(node.Name, "Cardboard", StringComparison.CurrentCultureIgnoreCase))
                {
                    string cardboardName = string.Empty;
                    double thickness = 0.0, ect = 0.0, stiffnessX = 0.0, stiffnessY = 0.0;

                    XmlElement eltCardboard = node as XmlElement;
                    if (eltCardboard.HasAttribute("Name"))
                        cardboardName = eltCardboard.Attributes["Name"].Value;
                    if (eltCardboard.HasAttribute("Thickness"))
                        thickness = double.Parse(eltCardboard.Attributes["Thickness"].Value);
                    if (eltCardboard.HasAttribute("ECT"))
                        ect = double.Parse(eltCardboard.Attributes["ECT"].Value);
                    if (eltCardboard.HasAttribute("StiffnessX"))
                        stiffnessX = double.Parse(eltCardboard.Attributes["StiffnessX"].Value);
                    if (eltCardboard.HasAttribute("StiffnessY"))
                        stiffnessY = double.Parse(eltCardboard.Attributes["StiffnessY"].Value);
                    ectAnalysis.Cardboard = new EdgeCrushTest.McKeeFormula.QualityData(name, thickness, ect, stiffnessX, stiffnessY);
                }                
            }
            // CaseType
            if (eltEctAnalysis.HasAttribute("CaseType"))
                ectAnalysis.CaseType = eltEctAnalysis.Attributes["CaseType"].Value;
            // PrintSurface
            if (eltEctAnalysis.HasAttribute("PrintSurface"))
                ectAnalysis.PrintSurface = eltEctAnalysis.Attributes["PrintSurface"].Value;
            // McKeeFormulaMode
            if (eltEctAnalysis.HasAttribute("McKeeFormulaMode"))
                ectAnalysis.McKeeFormulaText = eltEctAnalysis.Attributes["McKeeFormulaMode"].Value;
            return ectAnalysis;
        }
        #endregion // load ECT analysis
        #endregion // load methods

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
                xmlDateCreatedAttribute.Value = Convert.ToString(_dateCreated, new CultureInfo("en-US")); //string.Format("{0}", _dateCreated);
                xmlRootElement.Attributes.Append(xmlDateCreatedAttribute);
                // create ItemProperties element
                XmlElement xmlItemPropertiesElt = xmlDoc.CreateElement("ItemProperties");
                xmlRootElement.AppendChild(xmlItemPropertiesElt);
                foreach (ItemBase itemProperties in _typeList)
                {
                    CaseOfBoxesProperties caseOfBoxesProperties = itemProperties as CaseOfBoxesProperties;
                    if (null != caseOfBoxesProperties)
                        Save(caseOfBoxesProperties, xmlItemPropertiesElt, xmlDoc);
                    BoxProperties boxProperties = itemProperties as BoxProperties;
                    if (null != boxProperties && null == caseOfBoxesProperties)
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
                foreach (CasePalletAnalysis analysis in _casePalletAnalyses)
                    SavePalletAnalysis(analysis, xmlAnalysesElt, xmlDoc);
                foreach (BoxCaseAnalysis analysis in _boxCaseAnalyses)
                    SaveBoxCaseAnalysis(analysis, xmlAnalysesElt, xmlDoc);
                foreach (BoxCasePalletAnalysis analysis in _boxCasePalletOptimizations)
                    SaveCaseAnalysis(analysis, xmlAnalysesElt, xmlDoc);

                // finally save XmlDocument
                xmlDoc.Save(filePath);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        public void WriteSolution(SelCasePalletSolution selSolution, string filePath)
        {
            try
            {
                // retrieve solution
                CasePalletSolution sol = selSolution.Solution;
                // retrieve analysis
                CasePalletAnalysis analysis = sol.Analysis;
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
                SaveCasePalletAnalysis(sol.Analysis, sol, selSolution, xmlAnalysesElt, xmlDoc);
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
            lengthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", boxProperties.Length);
            xmlBoxProperties.Attributes.Append(lengthAttribute);
            // width
            XmlAttribute widthAttribute = xmlDoc.CreateAttribute("Width");
            widthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", boxProperties.Width);
            xmlBoxProperties.Attributes.Append(widthAttribute);
            // height
            XmlAttribute heightAttribute = xmlDoc.CreateAttribute("Height");
            heightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", boxProperties.Height);
            xmlBoxProperties.Attributes.Append(heightAttribute);
            // inside dimensions
            if (boxProperties.HasInsideDimensions)
            {
                // length
                XmlAttribute insideLengthAttribute = xmlDoc.CreateAttribute("InsideLength");
                insideLengthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", boxProperties.InsideLength);
                xmlBoxProperties.Attributes.Append(insideLengthAttribute);
                // width
                XmlAttribute insideWidthAttribute = xmlDoc.CreateAttribute("InsideWidth");
                insideWidthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", boxProperties.InsideWidth);
                xmlBoxProperties.Attributes.Append(insideWidthAttribute);
                // height
                XmlAttribute insideHeightAttribute = xmlDoc.CreateAttribute("InsideHeight");
                insideHeightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", boxProperties.InsideHeight);
                xmlBoxProperties.Attributes.Append(insideHeightAttribute);
            }
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("Weight");
            weightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", boxProperties.Weight);
            xmlBoxProperties.Attributes.Append(weightAttribute);
            // colors
            SaveColors(boxProperties.Colors, xmlBoxProperties, xmlDoc);
            // texture
            SaveTextures(boxProperties.TextureList, xmlBoxProperties, xmlDoc);
            // tape
            XmlAttribute tapeAttribute = xmlDoc.CreateAttribute("ShowTape");
            tapeAttribute.Value = string.Format("{0}", boxProperties.ShowTape);
            xmlBoxProperties.Attributes.Append(tapeAttribute);
            if (boxProperties.ShowTape)
            {
                XmlElement tapeElt = xmlDoc.CreateElement("Tape");
                xmlBoxProperties.AppendChild(tapeElt);

                XmlAttribute tapeWidthAttribute = xmlDoc.CreateAttribute("TapeWidth");
                tapeWidthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", boxProperties.TapeWidth);
                tapeElt.Attributes.Append(tapeWidthAttribute);

                XmlAttribute tapeColorAttribute = xmlDoc.CreateAttribute("TapeColor");
                tapeColorAttribute.Value = string.Format("{0}", boxProperties.TapeColor.ToArgb());
                tapeElt.Attributes.Append(tapeColorAttribute);
            }

        }

        public void Save(CaseOfBoxesProperties caseOfBoxesProperties, XmlElement parentElement, XmlDocument xmlDoc)
        {
            // create xmlBoxProperties element
            XmlElement xmlBoxProperties = xmlDoc.CreateElement("CaseOfBoxesProperties");
            parentElement.AppendChild(xmlBoxProperties);
            // Id
            XmlAttribute guidAttribute = xmlDoc.CreateAttribute("Id");
            guidAttribute.Value = caseOfBoxesProperties.Guid.ToString();
            xmlBoxProperties.Attributes.Append(guidAttribute);
            // name
            XmlAttribute nameAttribute = xmlDoc.CreateAttribute("Name");
            nameAttribute.Value = caseOfBoxesProperties.Name;
            xmlBoxProperties.Attributes.Append(nameAttribute);
            // description
            XmlAttribute descAttribute = xmlDoc.CreateAttribute("Description");
            descAttribute.Value = caseOfBoxesProperties.Description;
            xmlBoxProperties.Attributes.Append(descAttribute);
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("Weight");
            weightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", caseOfBoxesProperties.Weight);
            xmlBoxProperties.Attributes.Append(weightAttribute);
            // save inside ref to box properties
            XmlAttribute insideBoxId = xmlDoc.CreateAttribute("InsideBoxId");
            insideBoxId.Value = caseOfBoxesProperties.InsideBoxProperties.Guid.ToString();
            xmlBoxProperties.Attributes.Append(insideBoxId);
            // save case definition
            SaveCaseDefinition(caseOfBoxesProperties.CaseDefinition, xmlBoxProperties, xmlDoc);
            // save optim constraintset
            SaveCaseOptimConstraintSet(caseOfBoxesProperties.CaseOptimConstraintSet, xmlBoxProperties, xmlDoc);
            // colors
            SaveColors(caseOfBoxesProperties.Colors, xmlBoxProperties, xmlDoc);
            // texture
            SaveTextures(caseOfBoxesProperties.TextureList, xmlBoxProperties, xmlDoc);
        }
        private void SaveCaseDefinition(CaseDefinition caseDefinition, XmlElement xmlBoxProperties, XmlDocument xmlDoc)
        {
            XmlElement xmlCaseDefElement = xmlDoc.CreateElement("CaseDefinition");
            xmlBoxProperties.AppendChild(xmlCaseDefElement);
            // case arrangement
            XmlAttribute xmlArrangement = xmlDoc.CreateAttribute("Arrangement");
            xmlArrangement.Value = caseDefinition.Arrangement.ToString();
            xmlCaseDefElement.Attributes.Append(xmlArrangement);
            // box orientation
            XmlAttribute xmlOrientation = xmlDoc.CreateAttribute("Orientation");
            xmlOrientation.Value = string.Format("{0} {1}", caseDefinition.Dim0, caseDefinition.Dim1);
            xmlCaseDefElement.Attributes.Append(xmlOrientation);
        }
        private void SaveCaseOptimConstraintSet(CaseOptimConstraintSet caseOptimConstraintSet, XmlElement xmlBoxProperties, XmlDocument xmlDoc)
        {
            XmlElement xmlCaseOptimConstraintSet = xmlDoc.CreateElement("OptimConstraintSet");
            xmlBoxProperties.AppendChild(xmlCaseOptimConstraintSet);
            // wall thickness
            XmlAttribute xmlWallThickness = xmlDoc.CreateAttribute("WallThickness");
            xmlWallThickness.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", caseOptimConstraintSet.WallThickness);
            xmlCaseOptimConstraintSet.Attributes.Append(xmlWallThickness);
            // no walls
            XmlAttribute xmlNumberOfWalls = xmlDoc.CreateAttribute("NumberOfWalls");
            xmlNumberOfWalls.Value = string.Format("{0} {1} {2}"
                , caseOptimConstraintSet.NoWalls[0]
                , caseOptimConstraintSet.NoWalls[1]
                , caseOptimConstraintSet.NoWalls[2]);
            xmlCaseOptimConstraintSet.Attributes.Append(xmlNumberOfWalls);
        }
        private void SaveTextures(List<Pair<HalfAxis.HAxis, Texture>> textureList, XmlElement xmlBoxProperties, XmlDocument xmlDoc)
        { 
            XmlElement xmlTexturesElement = xmlDoc.CreateElement("Textures");
            xmlBoxProperties.AppendChild(xmlTexturesElement);
            foreach (Pair<HalfAxis.HAxis, Texture> texPair in textureList)
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
                xmlAngle.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", texPair.second.Angle);
                xmlFaceTexture.Attributes.Append(xmlAngle);
                // bitmap
                XmlAttribute xmlBitmap = xmlDoc.CreateAttribute("Bitmap");
                xmlBitmap.Value = Document.BitmapToString(texPair.second.Bitmap);
                xmlFaceTexture.Attributes.Append(xmlBitmap);
            }
        }

        private void SaveColors(Color[] colors, XmlElement eltBoxProperties, XmlDocument xmlDoc)
        { 
            // face colors
            XmlElement xmlFaceColors = xmlDoc.CreateElement("FaceColors");
            eltBoxProperties.AppendChild(xmlFaceColors);
            short i = 0;
            foreach (Color color in colors)
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
            lengthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", palletProperties.Length);
            xmlPalletProperties.Attributes.Append(lengthAttribute);
            // width
            XmlAttribute widthAttribute = xmlDoc.CreateAttribute("Width");
            widthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", palletProperties.Width);
            xmlPalletProperties.Attributes.Append(widthAttribute);
            // height
            XmlAttribute heightAttribute = xmlDoc.CreateAttribute("Height");
            heightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", palletProperties.Height);
            xmlPalletProperties.Attributes.Append(heightAttribute);
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("Weight");
            weightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", palletProperties.Weight);
            xmlPalletProperties.Attributes.Append(weightAttribute);
            // admissible load weight
            XmlAttribute admLoadWeightAttribute = xmlDoc.CreateAttribute("AdmissibleLoadWeight");
            admLoadWeightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", palletProperties.AdmissibleLoadWeight);
            xmlPalletProperties.Attributes.Append(admLoadWeightAttribute);
            // admissible load height
            XmlAttribute admLoadHeightAttribute = xmlDoc.CreateAttribute("AdmissibleLoadHeight");
            admLoadHeightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", palletProperties.AdmissibleLoadHeight);
            xmlPalletProperties.Attributes.Append(admLoadHeightAttribute);
            // type
            XmlAttribute typeAttribute = xmlDoc.CreateAttribute("Type");
            typeAttribute.Value = string.Format("{0}", palletProperties.TypeName);
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
            lengthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", interlayerProperties.Length);
            xmlInterlayerProperties.Attributes.Append(lengthAttribute);
            // width
            XmlAttribute widthAttribute = xmlDoc.CreateAttribute("Width");
            widthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", interlayerProperties.Width);
            xmlInterlayerProperties.Attributes.Append(widthAttribute);
            // height
            XmlAttribute heightAttribute = xmlDoc.CreateAttribute("Thickness");
            heightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", interlayerProperties.Thickness);
            xmlInterlayerProperties.Attributes.Append(heightAttribute);
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("Weight");
            weightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", interlayerProperties.Weight);
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
            lengthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", bundleProperties.Length);
            xmlBundleProperties.Attributes.Append(lengthAttribute);
            // width
            XmlAttribute widthAttribute = xmlDoc.CreateAttribute("Width");
            widthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", bundleProperties.Width);
            xmlBundleProperties.Attributes.Append(widthAttribute);
            // height
            XmlAttribute heightAttribute = xmlDoc.CreateAttribute("UnitThickness");
            heightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", bundleProperties.UnitThickness);
            xmlBundleProperties.Attributes.Append(heightAttribute);
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("UnitWeight");
            weightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", bundleProperties.UnitWeight);
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
            lengthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", truckProperties.Length);
            xmlTruckProperties.Attributes.Append(lengthAttribute);
            // width
            XmlAttribute widthAttribute = xmlDoc.CreateAttribute("Width");
            widthAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", truckProperties.Width);
            xmlTruckProperties.Attributes.Append(widthAttribute);
            // height
            XmlAttribute heightAttribute = xmlDoc.CreateAttribute("Height");
            heightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", truckProperties.Height);
            xmlTruckProperties.Attributes.Append(heightAttribute);
            // weight
            XmlAttribute weightAttribute = xmlDoc.CreateAttribute("AdmissibleLoadWeight");
            weightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", truckProperties.AdmissibleLoadWeight);
            xmlTruckProperties.Attributes.Append(weightAttribute);
            // color
            XmlAttribute colorAttribute = xmlDoc.CreateAttribute("Color");
            colorAttribute.Value = string.Format("{0}", truckProperties.Color.ToArgb());
            xmlTruckProperties.Attributes.Append(colorAttribute);
        }
        private void SaveCaseAnalysis(BoxCasePalletAnalysis analysis, XmlElement parentElement, XmlDocument xmlDoc)
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
                maximumWeightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", analysis.ConstraintSet.MaximumCaseWeight);
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
            int solIndex = 0;
            foreach (BoxCasePalletSolution caseSolution in analysis.Solutions)
                SaveCaseSolution(caseSolution, analysis.GetSelCaseSolutionBySolutionIndex(solIndex++), solutionsElt, xmlDoc);
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
            // case weight
            XmlAttribute caseWeightAttribute = xmlDoc.CreateAttribute("CaseWeight");
            caseWeightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", desc.CaseWeight);
            palletSolutionDescElt.Attributes.Append(caseWeightAttribute);
            // pallet weight
            XmlAttribute palletWeightAttribute = xmlDoc.CreateAttribute("PalletWeight");
            palletWeightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", desc.PalletWeight);
            palletSolutionDescElt.Attributes.Append(palletWeightAttribute);
            // case count
            XmlAttribute caseCountAttribute = xmlDoc.CreateAttribute("CaseCount");
            caseCountAttribute.Value = desc.CaseCount.ToString();
            palletSolutionDescElt.Attributes.Append(caseCountAttribute);
            // case orientation
            XmlAttribute caseOrientationAttribute = xmlDoc.CreateAttribute("CaseOrientation");
            caseOrientationAttribute.Value = desc.CaseOrientation;
            palletSolutionDescElt.Attributes.Append(caseOrientationAttribute);
        }

        private void SaveCaseSolution(BoxCasePalletSolution sol, SelBoxCasePalletSolution selSolution, XmlElement parentElement, XmlDocument xmlDoc)
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
                    zlowAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", interlayerPos.ZLow);
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
            }
        }

        private void SavePalletAnalysis(CasePalletAnalysis analysis, XmlElement parentElement, XmlDocument xmlDoc)
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
            bool bundleAnalysis = (analysis.ConstraintSet.GetType() == typeof(BundlePalletConstraintSet));
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
                maximumHeightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", analysis.ConstraintSet.MaximumHeight);
                constraintSetElement.Attributes.Append(maximumHeightAttribute);
            }
            if (analysis.ConstraintSet.UseMaximumNumberOfCases)
            {
                XmlAttribute maximumNumberOfItems = xmlDoc.CreateAttribute("ManimumNumberOfItems");
                maximumNumberOfItems.Value = string.Format("{0}", analysis.ConstraintSet.MaximumNumberOfItems);
                constraintSetElement.Attributes.Append(maximumNumberOfItems);
            }
            if (analysis.ConstraintSet.UseMaximumPalletWeight)
            {
                XmlAttribute maximumPalletWeight = xmlDoc.CreateAttribute("MaximumPalletWeight");
                maximumPalletWeight.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", analysis.ConstraintSet.MaximumPalletWeight);
                constraintSetElement.Attributes.Append(maximumPalletWeight);
            }
            if (analysis.ConstraintSet.UseMaximumWeightOnBox)
            {
                XmlAttribute maximumWeightOnBox = xmlDoc.CreateAttribute("MaximumWeightOnBox");
                maximumWeightOnBox.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", analysis.ConstraintSet.MaximumWeightOnBox);
                constraintSetElement.Attributes.Append(maximumWeightOnBox);
            }
            // overhang / underhang
            XmlAttribute overhangX = xmlDoc.CreateAttribute("OverhangX");
            overhangX.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", analysis.ConstraintSet.OverhangX);
            constraintSetElement.Attributes.Append(overhangX);
            XmlAttribute overhangY = xmlDoc.CreateAttribute("OverhangY");
            overhangY.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", analysis.ConstraintSet.OverhangY);
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
            foreach (CasePalletSolution sol in analysis.Solutions)
            {
                SaveCasePalletSolution(
                    analysis
                    , sol
                    , analysis.GetSelSolutionBySolutionIndex(solIndex) // null if not selected
                    , false /*unique*/
                    , solutionsElt
                    , xmlDoc);
                ++solIndex;
            }
        }

        public void SaveBoxCaseAnalysis(BoxCaseAnalysis analysis, XmlElement parentElement, XmlDocument xmlDoc)
        { 
            // create analysis element
            XmlElement xmlAnalysisElt = xmlDoc.CreateElement("AnalysisBoxCase");
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
            XmlAttribute palletIdAttribute = xmlDoc.CreateAttribute("CaseId");
            palletIdAttribute.Value = string.Format("{0}", analysis.CaseProperties.Guid);
            xmlAnalysisElt.Attributes.Append(palletIdAttribute);
            // ###
            // ConstraintSet
            XmlElement constraintSetElement = xmlDoc.CreateElement("ConstraintSetCase");
            xmlAnalysisElt.AppendChild(constraintSetElement);
            // allowed box positions
            XmlAttribute allowedAxisAttribute = xmlDoc.CreateAttribute("AllowedBoxPositions");
            constraintSetElement.Attributes.Append(allowedAxisAttribute);
            allowedAxisAttribute.Value = analysis.ConstraintSet.AllowOrthoAxisString;
            // stop criterions
            // 1. maximum number of boxes
            if (analysis.ConstraintSet.UseMaximumNumberOfBoxes)
            {
                XmlAttribute maximumNumberOfBoxes = xmlDoc.CreateAttribute("ManimumNumberOfBoxes");
                maximumNumberOfBoxes.Value = string.Format("{0}", analysis.ConstraintSet.MaximumNumberOfBoxes);
                constraintSetElement.Attributes.Append(maximumNumberOfBoxes);
            }
            // 2. maximum case weight
            if (analysis.ConstraintSet.UseMaximumCaseWeight)
            {
                XmlAttribute maximumPalletWeight = xmlDoc.CreateAttribute("MaximumCaseWeight");
                maximumPalletWeight.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", analysis.ConstraintSet.MaximumCaseWeight);
                constraintSetElement.Attributes.Append(maximumPalletWeight);
            }
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
            foreach (BoxCaseSolution sol in analysis.Solutions)
            {
                SaveBoxCaseSolution(
                    analysis
                    , sol
                    , analysis.GetSelSolutionBySolutionIndex(solIndex) // null if not selected
                    , solutionsElt
                    , xmlDoc);
                ++solIndex;
            }
        }

        public void SaveBoxCaseSolution(BoxCaseAnalysis analysis, BoxCaseSolution sol, SelBoxCaseSolution selSolution, XmlElement solutionsElt, XmlDocument xmlDoc)
        {
            // Solution
            XmlElement solutionElt = xmlDoc.CreateElement("Solution");
            solutionsElt.AppendChild(solutionElt);
            // Pattern name
            XmlAttribute patternNameAttribute = xmlDoc.CreateAttribute("Pattern");
            patternNameAttribute.Value = sol.PatternName;
            solutionElt.Attributes.Append(patternNameAttribute);
            // ortho axis
            XmlAttribute orthoAxisAttribute = xmlDoc.CreateAttribute("OrthoAxis");
            orthoAxisAttribute.Value = HalfAxis.ToString(sol.OrthoAxis);
            solutionElt.Attributes.Append(orthoAxisAttribute);
            // limit
            XmlAttribute limitReached = xmlDoc.CreateAttribute("LimitReached");
            limitReached.Value = string.Format("{0}", (int)sol.LimitReached);
            solutionElt.Attributes.Append(limitReached);
            // layers
            XmlElement layersElt = xmlDoc.CreateElement("Layers");
            solutionElt.AppendChild(layersElt);

            foreach (BoxLayer boxLayer in sol)
                Save(boxLayer, layersElt, xmlDoc);

            // Is selected ?
            if (null != selSolution)
            {
                // selected attribute
                XmlAttribute selAttribute = xmlDoc.CreateAttribute("Selected");
                selAttribute.Value = "true";
                solutionElt.Attributes.Append(selAttribute);
            }
        }

        public void SaveCasePalletAnalysis(CasePalletAnalysis analysis, CasePalletSolution sol, SelCasePalletSolution selSolution, XmlElement parentElement, XmlDocument xmlDoc)
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
            bool bundleAnalysis = (analysis.ConstraintSet.GetType() == typeof(BundlePalletConstraintSet));
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
                maximumHeightAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", analysis.ConstraintSet.MaximumHeight);
                constraintSetElement.Attributes.Append(maximumHeightAttribute);
            }
            if (analysis.ConstraintSet.UseMaximumNumberOfCases)
            {
                XmlAttribute maximumNumberOfItems = xmlDoc.CreateAttribute("ManimumNumberOfItems");
                maximumNumberOfItems.Value = string.Format("{0}", analysis.ConstraintSet.MaximumNumberOfItems);
                constraintSetElement.Attributes.Append(maximumNumberOfItems);
            }
            if (analysis.ConstraintSet.UseMaximumPalletWeight)
            {
                XmlAttribute maximumPalletWeight = xmlDoc.CreateAttribute("MaximumPalletWeight");
                maximumPalletWeight.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", analysis.ConstraintSet.MaximumPalletWeight);
                constraintSetElement.Attributes.Append(maximumPalletWeight);
            }
            if (analysis.ConstraintSet.UseMaximumWeightOnBox)
            {
                XmlAttribute maximumWeightOnBox = xmlDoc.CreateAttribute("MaximumWeightOnBox");
                maximumWeightOnBox.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", analysis.ConstraintSet.MaximumWeightOnBox);
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
            SaveCasePalletSolution(analysis, sol, selSolution, true /* unique */, solutionsElt, xmlDoc );
        }

        public void SaveCasePalletSolution(CasePalletAnalysis analysis, CasePalletSolution sol, SelCasePalletSolution selSolution, bool unique, XmlElement solutionsElt, XmlDocument xmlDoc)
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
            // limit
            XmlAttribute limitReached = xmlDoc.CreateAttribute("LimitReached");
            limitReached.Value = string.Format("{0}", (int)sol.LimitReached);
            solutionElt.Attributes.Append(limitReached);
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

                // ect analyses
                XmlElement ectAnalysesElt = xmlDoc.CreateElement("EctAnalyses");
                solutionElt.AppendChild(ectAnalysesElt);

                foreach (ECTAnalysis ectAnalysis in selSolution.EctAnalyses)
                    Save(ectAnalysis, unique, ectAnalysesElt, xmlDoc);
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
            minDistancePalletWallAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", truckAnalysis.ConstraintSet.MinDistancePalletTruckWall);
            contraintSetElt.Attributes.Append(minDistancePalletWallAttribute);
            // min distance pallet / truck roof
            XmlAttribute minDistancePalletRoofAttribute = xmlDoc.CreateAttribute("MinDistancePalletRoof");
            minDistancePalletRoofAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", truckAnalysis.ConstraintSet.MinDistancePalletTruckWall);
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

        public void Save(ECTAnalysis ectAnalysis, bool unique, XmlElement ectAnalysesElt, XmlDocument xmlDoc)
        {
            XmlElement ectAnalysisElt = xmlDoc.CreateElement("EctAnalysis");
            ectAnalysesElt.AppendChild(ectAnalysisElt);
            // name
            XmlAttribute nameAttribute = xmlDoc.CreateAttribute("Name");
            nameAttribute.Value = ectAnalysis.Name;
            ectAnalysisElt.Attributes.Append(nameAttribute);
            // description
            XmlAttribute descriptionAttribute = xmlDoc.CreateAttribute("Description");
            descriptionAttribute.Value = ectAnalysis.Description;
            ectAnalysisElt.Attributes.Append(descriptionAttribute);
            // cardboard
            XmlElement cardboardElt = xmlDoc.CreateElement("Cardboard");
            ectAnalysesElt.AppendChild(cardboardElt);
            // - name
            XmlAttribute nameCardboardAttribute = xmlDoc.CreateAttribute("Name");
            nameCardboardAttribute.Value = ectAnalysis.Cardboard.Name;
            cardboardElt.Attributes.Append(nameCardboardAttribute);
            // - thickness
            XmlAttribute thicknessAttribute = xmlDoc.CreateAttribute("Thickness");
            thicknessAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", ectAnalysis.Cardboard.Thickness);
            cardboardElt.Attributes.Append(thicknessAttribute);
             // - ect
            XmlAttribute ectAttribute = xmlDoc.CreateAttribute("ECT");
            ectAttribute.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", ectAnalysis.Cardboard.ECT);
            cardboardElt.Attributes.Append(ectAttribute);
            // - stiffnessX
            XmlAttribute stiffnessAttributeX = xmlDoc.CreateAttribute("StiffnessX");
            stiffnessAttributeX.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", ectAnalysis.Cardboard.RigidityDX);
            cardboardElt.Attributes.Append(stiffnessAttributeX);
            // - stiffnessY
            XmlAttribute stiffnessAttributeY = xmlDoc.CreateAttribute("StiffnessY");
            stiffnessAttributeY.Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", ectAnalysis.Cardboard.RigidityDY);
            cardboardElt.Attributes.Append(stiffnessAttributeY);
            // case type
            XmlAttribute caseTypeAttribute = xmlDoc.CreateAttribute("CaseType");
            caseTypeAttribute.Value = ectAnalysis.CaseType;
            ectAnalysisElt.Attributes.Append(caseTypeAttribute);
            // print surface
            XmlAttribute printSurfaceAttribute = xmlDoc.CreateAttribute("PrintSurface");
            printSurfaceAttribute.Value = ectAnalysis.PrintSurface;
            ectAnalysesElt.Attributes.Append(printSurfaceAttribute);
            // mc kee formula mode
            XmlAttribute mcKeeFormulaAttribute = xmlDoc.CreateAttribute("McKeeFormulaMode");
            mcKeeFormulaAttribute.Value = ectAnalysis.McKeeFormulaText;
            ectAnalysisElt.Attributes.Append(mcKeeFormulaAttribute);
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
            while (_boxCasePalletOptimizations.Count > 0)
                RemoveItem(_boxCasePalletOptimizations[0]);
            while (_casePalletAnalyses.Count > 0)
                RemoveItem(_casePalletAnalyses[0]);
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
        private static int[] ParseInt2(string value)
        {
            string regularExp = "(?<i1>.*) (?<i2>.*)";
            Regex r = new Regex(regularExp, RegexOptions.Singleline);
            Match m = r.Match(value);
            if (m.Success)
            {
                int[] iArray = new int[2];
                iArray[0] = int.Parse(m.Result("${i1}"));
                iArray[1] = int.Parse(m.Result("${i2}"));
                return iArray;
            }
            else
                throw new Exception("Failed parsing int[2] from " + value);
        }
        private static int[] ParseInt3(string value)
        {
            string regularExp = "(?<i1>.*) (?<i2>.*) (?<i3>.*)";
            Regex r = new Regex(regularExp, RegexOptions.Singleline);
            Match m = r.Match(value);
            if (m.Success)
            {
                int[] iArray = new int[3];
                iArray[0] = int.Parse(m.Result("${i1}"));
                iArray[1] = int.Parse(m.Result("${i2}"));
                iArray[2] = int.Parse(m.Result("${i3}"));
                return iArray;
            }
            else
                throw new Exception("Failed parsing int[3] from " + value);
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
        private void NotifyOnNewAnalysisCreated(CasePalletAnalysis analysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewCasePalletAnalysisCreated(this, analysis);
        }
        private void NotifyOnNewBoxCaseAnalysis(BoxCaseAnalysis analysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewBoxCaseAnalysisCreated(this, analysis);
        }
        private void NotifyOnNewCaseAnalysisCreated(BoxCasePalletAnalysis caseAnalysis)
        { 
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewBoxCasePalletAnalysisCreated(this, caseAnalysis);
        }
        internal void NotifyOnNewTruckAnalysisCreated(CasePalletAnalysis analysis, SelCasePalletSolution selSolution, TruckAnalysis truckAnalysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewTruckAnalysisCreated(this, analysis, selSolution, truckAnalysis);
        }
        internal void NotifyOnNewECTAnalysisCreated(CasePalletAnalysis analysis, SelCasePalletSolution selSolution, ECTAnalysis ectAnalysis)
        { 
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewECTAnalysisCreated(this, analysis, selSolution, ectAnalysis);
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
        private void NotifyOnAnalysisRemoved(ItemBase analysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnAnalysisRemoved(this, analysis);
        }
/*
        private void NotifyOnAnalysisRemoved(CasePalletAnalysis analysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnCasePalletAnalysisRemoved(this, analysis);
        }
        private void NotifyOnAnalysisRemoved(BoxCaseAnalysis analysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnBoxCaseAnalysisRemoved(this, analysis);
        }
        private void NotifyOnCaseAnalysisRemoved(BoxCasePalletAnalysis caseAnalysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnCaseAnalysisRemoved(this, caseAnalysis);
        }
*/ 
        internal void NotifyOnTruckAnalysisRemoved(SelCasePalletSolution selSolution, TruckAnalysis truckAnalysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnTruckAnalysisRemoved(this, selSolution.Analysis, selSolution, truckAnalysis);
        }
        internal void NotifyOnECTAnalysisRemoved(SelCasePalletSolution selSolution, ECTAnalysis ectAnalysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnECTAnalysisRemoved(this, selSolution.Analysis, selSolution, ectAnalysis);
        }
        #endregion
    }
    #endregion
}
