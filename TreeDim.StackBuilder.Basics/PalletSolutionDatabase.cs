#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using log4net;

using System.Globalization;
using System.Diagnostics;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region PalletSolutionKey
    public class PalletSolutionKey : IComparable<PalletSolutionKey>
    {
        #region Data members
        internal double[] _palletDimensions= new double[3];
        internal double[] _overhang= new double[2];
        #endregion

        #region Constructors
        public PalletSolutionKey()
        { 
        }
        public PalletSolutionKey(double palletLength, double palletWidth, double palletHeight, double overhangX, double overhangY)
        {
            _palletDimensions[0] = palletLength; _palletDimensions[1] = palletWidth; _palletDimensions[2] = palletHeight;
            _overhang[0] = overhangX; _overhang[1] = overhangY;
        }
        public PalletSolutionKey(double[] palletDimensions, double[] overhang)
        {
            for (int i = 0; i < 3; ++i)
                _palletDimensions[i] = palletDimensions[i];
            for (int i = 0; i < 2; ++i)
                _overhang[i] = overhang[i];
        }
        public PalletSolutionKey(string palletDimensions, string overhang)
        {
            this.PalletDimensions = palletDimensions;
            this.Overhang = overhang;
        }
        #endregion

        #region Public properties
        public string PalletDimensions
        {
            get
            {
                CultureInfo ci = new CultureInfo("en-US");
                return string.Format("{0:F},{1:F},{2:F}"
                    , _palletDimensions[0].ToString(ci)
                    , _palletDimensions[1].ToString(ci)
                    , _palletDimensions[2].ToString(ci));
            }
            set
            {
                Regex r = new Regex(@"(?<x>.*),(?<y>.*),(?<z>.*)", RegexOptions.Singleline);
                Match m = r.Match(value);
                if (m.Success)
                {
                    CultureInfo ci = new CultureInfo("en-US");
                    _palletDimensions[0] = double.Parse(m.Result("${x}"), ci);
                    _palletDimensions[1] = double.Parse(m.Result("${y}"), ci);
                    _palletDimensions[2] = double.Parse(m.Result("${z}"), ci);
                }
                else
                    throw new Exception("Failed to parse PalletDimensions");
            }
        }
        public string Overhang
        {
            get
            {
                CultureInfo ci = new CultureInfo("en-US");
                return string.Format("{0:F},{1:F}", _overhang[0].ToString(ci), _overhang[1].ToString(ci));
            }
            set
            {
                Regex r = new Regex(@"(?<x>.*),(?<y>.*)", RegexOptions.Singleline);
                Match m = r.Match(value);
                if (m.Success)
                {
                    CultureInfo ci = new CultureInfo("en-US");
                    _overhang[0] = double.Parse(m.Result("${x}"), ci);
                    _overhang[1] = double.Parse(m.Result("${y}"), ci);
                }
                else
                    throw new Exception("Failed to parse Overhang");
            }
        }
        #endregion

        #region Implementation of IComparable<PalletSolutionKey>
        public int CompareTo(PalletSolutionKey other)
        {
            int iValue1 = Compare3(_palletDimensions, other._palletDimensions);
            if (iValue1 == 0)
            {
                return Compare2(_overhang, other._overhang);
            }
            else
                return iValue1;
        }
        public int Compare2(double[] v1, double[] v2)
        {
            if (v1[0] > v2[0])
                return 1;
            else if (v1[0] == v2[0])
            {
                if (v1[1] > v2[1])
                    return 1;
                else if (v1[1] == v2[1])
                    return 0;
                else
                    return -1;
            }
            else
                return -1;
        }
        public int Compare3(double[] v1, double[] v2)
        {
            if (v1[0] > v2[0])
                return 1;
            else if (v1[0] == v2[0])
            {
                if (v1[1] > v2[1])
                    return 1;
                else if (v1[1] == v2[1])
                {
                    if (v1[2] > v2[2])
                        return 1;
                    else if (v1[2] == v2[2])
                        return 0;
                    else
                        return -1;
                }
                else
                    return -1;
            }
            else
                return -1;
        }
        #endregion

        #region System.Object Overrides
		/// <summary>
		/// Returns the hashcode for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode()
		{
			return _palletDimensions.GetHashCode() ^ _overhang.GetHashCode();
		}
		/// <summary>
		/// Returns a value indicating whether this instance is equal to
		/// the specified object.
		/// </summary>
		/// <param name="obj">An object to compare to this instance.</param>
		/// <returns><see langword="true"/> if <paramref name="obj"/> is a <see cref="Vector3D"/> and has the same values as this instance; otherwise, <see langword="false"/>.</returns>
		public override bool Equals(object obj)
		{
			if (obj is PalletSolutionKey)
			{
				PalletSolutionKey v = (PalletSolutionKey)obj;
				return (_palletDimensions[0] == v._palletDimensions[0])
                    && (_palletDimensions[1] == v._palletDimensions[1])
                    && (_palletDimensions[2] == v._palletDimensions[2])
                    && (_overhang[0] == v._overhang[0])
                    && (_overhang[1] == v._overhang[1]);
			}
			return false;
		}
		/// <summary>
		/// Returns a string representation of this object.
		/// </summary>
		/// <returns>A string representation of this object.</returns>
		public override string ToString()
		{
            CultureInfo ci = new CultureInfo("en-US");
            return string.Format("({0},{1},{2}) ({3}, {4})", _palletDimensions[0].ToString(ci), _palletDimensions[1].ToString(ci), _palletDimensions[2].ToString(ci), _overhang[0].ToString(ci), _overhang[1].ToString(ci));
		}
		#endregion
    }
    #endregion

    #region PalletSolutionDesc
    public class PalletSolutionDesc : IComparable<PalletSolutionDesc>
    {
        #region Data members
        // key parameters
        private PalletSolutionKey _key;
        // value parameters
        private double[] _caseDimensions = new double[3];
        private double[] _insideCaseDimensions = new double[3];
        private double _caseWeight;
        private double _palletWeight;

        private int _caseCount;
        private Guid _guid;
        private string _friendlyName;
        private string _caseOrientation;
        // parent database
        private PalletSolutionDatabase _parentDB;
        // cached pallet solution
        private CasePalletSolution _palletSolution;
        #endregion

        #region Constructors
        public PalletSolutionDesc(PalletSolutionDatabase db)
        {
            _parentDB = db;
        }
        public PalletSolutionDesc(PalletSolutionDatabase db, string palletDimensions, string overhang
            , string caseDimensions, string caseInsideDimensions
            , string caseWeight, string palletWeight
            , string caseCount, string sGuid, string friendlyName)
        {
            _key = new PalletSolutionKey(palletDimensions, overhang);
            this.CaseDimensionsString = caseDimensions;
            this.CaseInsideDimensionsString = caseInsideDimensions;
            this.CaseCount = int.Parse(caseCount);
            CultureInfo ci = new CultureInfo("en-US");
            this.CaseWeight = double.Parse(caseWeight, ci);
            this.PalletWeight = double.Parse(palletWeight, ci);
            _guid = new Guid(sGuid);
            _friendlyName = friendlyName;
            _parentDB = db;
        }
        public PalletSolutionDesc(PalletSolutionDatabase db, double palletLength, double palletWidth, double palletHeight
            , double overhangX, double overhangY
            , double caseLength, double caseWidth, double caseHeight
            , double insideCaseLength, double insideCaseWidth, double insideCaseHeight
            , double caseWeight, double palletWeight
            , int caseCount
            , Guid guid
            , string friendlyName)
        {
            _key = new PalletSolutionKey(palletLength, palletWidth, palletHeight, overhangX, overhangY);
            _caseDimensions[0] = caseLength; _caseDimensions[1] = caseWidth; _caseDimensions[2] = caseHeight;
            _insideCaseDimensions[0] = insideCaseLength; _insideCaseDimensions[1] = insideCaseWidth; _insideCaseDimensions[2] = insideCaseHeight;
            _caseWeight = caseWeight;
            _caseCount = caseCount;
            _guid = guid;
            _friendlyName = friendlyName;
            _parentDB = db;
        }
        public PalletSolutionDesc(PalletSolutionDatabase db, CasePalletSolution sol, string friendlyName)
        {
            BoxProperties boxProperties = sol.Analysis.BProperties as BoxProperties;
            PalletProperties palletProperties = sol.Analysis.PalletProperties;
            PalletConstraintSet constraintSet = sol.Analysis.ConstraintSet;
            _guid = Guid.NewGuid();
            _friendlyName = friendlyName;
            _key = new PalletSolutionKey(
                palletProperties.Length, palletProperties.Width, constraintSet.MaximumHeight
                , constraintSet.OverhangX, constraintSet.OverhangY);

            _caseDimensions[0] = boxProperties.Length;
            _caseDimensions[1] = boxProperties.Width;
            _caseDimensions[2] = boxProperties.Height;

            _insideCaseDimensions[0] = boxProperties.InsideLength;
            _insideCaseDimensions[1] = boxProperties.InsideWidth;
            _insideCaseDimensions[2] = boxProperties.InsideHeight;

            _caseWeight = boxProperties.Weight;
            _palletWeight = palletProperties.Weight;

            _caseOrientation = sol.CaseOrientation;
            _caseCount = sol.CaseCount;

            _parentDB = db;
        }
        #endregion

        #region Compare methods
        public bool MatchesKey(PalletSolutionKey key)
        {
            return _key.Equals(key);
        }
        public bool MatchesKeyAndCaseDimensions(PalletSolutionDesc descNew)
        {
            return _key.Equals(descNew.Key) && (0 == Compare3(_caseDimensions, descNew._caseDimensions));
        }
        #endregion 

        #region Public properties
        /// <summary>
        /// Solution key
        /// </summary>
        public PalletSolutionKey Key
        {
            get { return _key; }
            set { _key = value; }
        }
        /// <summary>
        /// dimensions string
        /// </summary>
        public string CaseDimensionsString
        {
            get
            {
                CultureInfo ci = new CultureInfo("en-US");
                return string.Format("{0:F},{1:F},{2:F}", _caseDimensions[0].ToString(ci), _caseDimensions[1].ToString(ci), _caseDimensions[2].ToString(ci)); 
            }
            set
            {
                Regex r = new Regex(@"(?<x>.*),(?<y>.*),(?<z>.*)", RegexOptions.Singleline);
			    Match m = r.Match(value);
                if (m.Success)
                {
                    CultureInfo ci = new CultureInfo("en-US");
                    _caseDimensions[0] = double.Parse(m.Result("${x}"), ci);
                    _caseDimensions[1] = double.Parse(m.Result("${y}"), ci);
                    _caseDimensions[2] = double.Parse(m.Result("${z}"), ci);
                }
                else
                    throw new Exception("Failed to parse CaseDimensions");
            }
        }
        /// <summary>
        /// inside dimensions string
        /// </summary>
        public string CaseInsideDimensionsString
        {
            get
            {
                CultureInfo ci = new CultureInfo("en-US");
                return string.Format("{0:F},{1:F},{2:F}", _insideCaseDimensions[0].ToString(ci), _insideCaseDimensions[1].ToString(ci), _insideCaseDimensions[2].ToString(ci)); 
            }
            set
            {
                Regex r = new Regex(@"(?<x>.*),(?<y>.*),(?<z>.*)", RegexOptions.Singleline);
			    Match m = r.Match(value);
                if (m.Success)
                {
                    CultureInfo ci = new CultureInfo("en-US");
                    _insideCaseDimensions[0] = double.Parse(m.Result("${x}"), ci);
                    _insideCaseDimensions[1] = double.Parse(m.Result("${y}"), ci);
                    _insideCaseDimensions[2] = double.Parse(m.Result("${z}"), ci);
                }
                else
                    throw new Exception("Failed to parse CaseInsideDimensions");
            }
        }
        /// <summary>
        /// Case dimensions
        /// </summary>
        public double[] CaseDimensions { get { return _caseDimensions; } }
        /// <summary>
        /// Inside case dimensions
        /// </summary>
        public double[] InsideCaseDimensions { get { return _insideCaseDimensions; } }
        /// <summary>
        /// Inside volume
        /// </summary>
        public double InsideVolume
        {
            get { return _insideCaseDimensions[0] * _insideCaseDimensions[1] * _insideCaseDimensions[2]; }
        }
        /// <summary>
        /// Case weight
        /// </summary>
        public double CaseWeight
        {
            get { return _caseWeight; }
            set { _caseWeight = value; }
        }
        /// <summary>
        /// Pallet weight
        /// </summary>
        public double PalletWeight
        {
            get { return _palletWeight; }
            set { _palletWeight = value; }
        }
        /// <summary>
        /// Case count
        /// </summary>
        public int CaseCount
        {
            get { return _caseCount; }
            set { _caseCount = value; }
        }
        /// <summary>
        /// Friendly name
        /// </summary>
        public string FriendlyName
        {
            get { return _friendlyName; }
            set { _friendlyName = value; }
        }
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }
        private string FileName
        {
            get { return _guid.ToString().Replace("-", "_") + ".stb"; }
        }
        /// <summary>
        /// get file path 
        /// </summary>
        public string FullFilePath
        {
            get { return Path.Combine(PalletSolutionDatabase.Directory, FileName); }        
        }
        /// <summary>
        /// Case orientation
        /// </summary>
        public string CaseOrientation
        {   get { return _caseOrientation; } }

        /// <summary>
        /// Loads pallet solution from database file
        /// </summary>
        public CasePalletSolution LoadPalletSolution()
        {
            if (null == _palletSolution)
            {
                if (!File.Exists(FullFilePath))
                    return null;    // database file not available -> existing
                else
                {
                    Document doc = new Document(FullFilePath, null);
                    if (doc.Analyses.Count < 1)
                        return null;    // no analysis -> exiting
                    if (doc.Analyses[0].Solutions.Count < 1)
                        return null;    // no solution -> exiting
                    _palletSolution = doc.Analyses[0].Solutions[0];
                }
            }
            return _palletSolution;
        }
        #endregion

        #region IComparable<PalletSolutionDesc> implementation
        public int CompareTo(PalletSolutionDesc other)
        {
            int iValue1 = _key.CompareTo(other._key);
            if (0 == iValue1)
            {
                int iValue2 = Compare3(_caseDimensions, other._caseDimensions);
                if (0 == iValue2)
                {
                    int iValue3 = Compare3(_insideCaseDimensions, other._insideCaseDimensions);
                    if (0 == iValue3)
                    {
                        if (_caseCount > other._caseCount)
                            return 1;
                        else if (_caseCount == other._caseCount)
                            return 0;
                        else
                            return -1;
                    }
                    else
                        return iValue3;
                }
                else
                    return iValue2;
            }
            else
                return iValue1;
        }
        public int Compare2(double[] v1, double[] v2)
        {
            if (v1[0] > v2[0])
                return 1;
            else if (v1[0] == v2[0])
            {
                if (v1[1] > v2[1])
                    return 1;
                else if (v1[1] == v2[1])
                    return 0;
                else
                    return -1;
            }
            else
                return -1;
        }
        public int Compare3(double[] v1, double[] v2)
        {
            if (v1[0] > v2[0])
                return 1;
            else if (v1[0] == v2[0])
            {
                if (v1[1] > v2[1])
                    return 1;
                else if (v1[1] == v2[1])
                {
                    if (v1[2] > v2[2])
                        return 1;
                    else if (v1[2] == v2[2])
                        return 0;
                    else
                        return -1;
                }
                else
                    return -1;
            }
            else
                return -1;
        }
        #endregion
    }
    #endregion

    #region PalletSolutionDatabase
    public class PalletSolutionDatabase
    {
        #region Data members
        /// <summary>
        /// 
        /// </summary>
        List<PalletSolutionDesc> _palletSolutionList = new List<PalletSolutionDesc>();
        /// <summary>
        /// database directory path
        /// </summary>
        static string _directoryPath;
        /// <summary>
        /// singleton's instance
        /// </summary>
        static PalletSolutionDatabase _instance;
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(PalletSolutionDatabase));
        #endregion

        #region Public properties
        public static string Directory
        {
            get { return _directoryPath; }
            set
            {
                _directoryPath = value;
                if (!System.IO.Directory.Exists(_directoryPath))
                    _log.Error(
                        string.Format(
                        "Cannot initialize Pallet solution database.\n{0} does not exist"
                        , _directoryPath)
                        );
            }
        }
        public static string IndexPath
        {
            get { return Path.Combine(_directoryPath, "index.xml"); }
        }
        public static PalletSolutionDatabase Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new PalletSolutionDatabase();
                    _instance.Load();
                }
                return _instance;
            }
        }
        #endregion

        #region Load / Save
        private void Load()
        {
            _palletSolutionList.Clear();
            if (!File.Exists(IndexPath))
                return;
            try
            {
                // instantiate XmlDocument
                XmlDocument xmlDoc = new XmlDocument();
                // load xml file in document and parse document
                using (FileStream fileStream = new FileStream(IndexPath, FileMode.Open))
                {
                    xmlDoc.Load(fileStream);
                    XmlElement xmlRootElement = xmlDoc.DocumentElement;
                    foreach (XmlNode node in xmlRootElement)
                    {
                        try
                        {
                            // case XmlNode to XmlElement
                            XmlElement solutionElt = node as XmlElement;
                            Debug.Assert(null != solutionElt);

                            _palletSolutionList.Add(new PalletSolutionDesc(this
                                , solutionElt.Attributes["PalletDimensions"].Value
                                , solutionElt.Attributes["Overhang"].Value
                                , solutionElt.Attributes["CaseDimensions"].Value
                                , solutionElt.Attributes["CaseInsideDimensions"].Value
                                , solutionElt.Attributes["CaseWeight"].Value
                                , solutionElt.Attributes["PalletWeight"].Value
                                , solutionElt.Attributes["CaseCount"].Value
                                , solutionElt.Attributes["Guid"].Value
                                , solutionElt.Attributes["FriendlyName"].Value));
                        }
                        catch (Exception ex) { _log.Error("Failed to read an index line:" + ex.ToString()); }
                    }
                    _palletSolutionList.Sort();
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


        public void Save()
        {
            XmlDocument xmlDoc = new XmlDocument();
            // solutions
            // let's add the XML declaration section
            XmlNode xmlnode = xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            xmlDoc.AppendChild(xmlnode);
            // create Document (root) element
            XmlElement xmlRootElement = xmlDoc.CreateElement("Solutions");
            xmlDoc.AppendChild(xmlRootElement);
            foreach (PalletSolutionDesc desc in _palletSolutionList)
            {
                // solution element
                XmlElement solutionElt = xmlDoc.CreateElement("Solution");
                xmlRootElement.AppendChild(solutionElt);
                // pallet dimensions
                XmlAttribute palletDimensions = xmlDoc.CreateAttribute("PalletDimensions");
                palletDimensions.Value = desc.Key.PalletDimensions;
                solutionElt.Attributes.Append(palletDimensions);
                // overhang
                XmlAttribute overhang = xmlDoc.CreateAttribute("Overhang");
                overhang.Value = desc.Key.Overhang;
                solutionElt.Attributes.Append(overhang);
                // case dimensions
                XmlAttribute caseDimensions = xmlDoc.CreateAttribute("CaseDimensions");
                caseDimensions.Value = desc.CaseDimensionsString;
                solutionElt.Attributes.Append(caseDimensions);
                // inside dimensions
                XmlAttribute caseInsideDimensions = xmlDoc.CreateAttribute("CaseInsideDimensions");
                caseInsideDimensions.Value = desc.CaseInsideDimensionsString;
                solutionElt.Attributes.Append(caseInsideDimensions);
                // case weight
                XmlAttribute caseWeightAttribute = xmlDoc.CreateAttribute("CaseWeight");
                caseWeightAttribute.Value = string.Format("{0:0.00}", desc.CaseWeight);
                solutionElt.Attributes.Append(caseWeightAttribute);
                // palletWeight
                XmlAttribute palletWeightAttribute = xmlDoc.CreateAttribute("PalletWeight");
                palletWeightAttribute.Value = string.Format("{0:0.00}", desc.PalletWeight);
                solutionElt.Attributes.Append(palletWeightAttribute);
                // case count
                XmlAttribute caseCount = xmlDoc.CreateAttribute("CaseCount");
                caseCount.Value = string.Format("{0}", desc.CaseCount);
                solutionElt.Attributes.Append(caseCount);
                // friendly name
                XmlAttribute friendlyName = xmlDoc.CreateAttribute("FriendlyName");
                friendlyName.Value = string.Format("{0}", desc.FriendlyName);
                solutionElt.Attributes.Append(friendlyName); 
                // guid
                XmlAttribute guid = xmlDoc.CreateAttribute("Guid");
                guid.Value = string.Format("{0}", desc.Guid);
                solutionElt.Attributes.Append(guid);
            }

            xmlDoc.Save(IndexPath);
        }
        #endregion

        #region Query
        /// <summary>
        /// Is database empty ?
        /// </summary>
        public bool IsEmpty
        {
            get { return _palletSolutionList.Count == 0; }
        }
        /// <summary>
        /// Get list of keys (pallet dimensions + overhang)
        /// </summary>
        public List<PalletSolutionKey> Keys
        {
            get
            {
                List<PalletSolutionKey> keys = new List<PalletSolutionKey>();
                foreach (PalletSolutionDesc desc in _palletSolutionList)
                    if (null == keys.Find( delegate(PalletSolutionKey key) { return key.Equals(desc.Key); } ) )
                        keys.Add(desc.Key);
                return keys;
            }
        }
        /// <summary>
        /// Get a list of pallet solution descriptor that match a defined key (pallet / overhang)
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>List of pallet solution descriptor</returns>
        public List<PalletSolutionDesc> QueryPalletSolutions(PalletSolutionKey key)
        {
            return _palletSolutionList.FindAll(
                delegate(PalletSolutionDesc palletSolDesc)
                { return palletSolDesc.MatchesKey(key); }
                );
        }
        /// <summary>
        /// Check if database has a certain key (pallet dimensions + overhangs)
        /// </summary>
        /// <param name="key">Key to search</param>
        /// <returns></returns>
        public bool HasKey(PalletSolutionKey key)
        {
            foreach (PalletSolutionDesc desc in _palletSolutionList)
                if (desc.MatchesKey(key))
                    return true;
            return false;
        }
        /// <summary>
        /// Check validity of a friendly name.
        /// A friendly name should only be used if not already used by an other solution.
        /// </summary>
        /// <param name="name">name to check </param>
        /// <param name="thisDesc">this descriptor</param>
        /// <returns>true if name can be used</returns>
        public bool IsValidFriendlyName(string name, PalletSolutionDesc thisDesc)
        {
            foreach (PalletSolutionDesc desc in _palletSolutionList)
            {
                if (thisDesc == desc) continue;
                if (string.Compare(desc.FriendlyName.Trim(), name.Trim(), true) == 0)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Check if database already contains a similar pallet solution for a specific case
        /// </summary>
        /// <returns>true if a solution with same pallet + case dimensions exists</returns>
        public bool AlreadyHasSimilarSolution(SelCasePalletSolution selSolution)
        {
            List<PalletSolutionDesc> similarDescList = _palletSolutionList.FindAll(
                delegate(PalletSolutionDesc desc) { return desc.MatchesKeyAndCaseDimensions(new PalletSolutionDesc(this, selSolution.Solution, "")); }
                );
            return similarDescList.Count > 0;
        }
        #endregion

        #region Modify (Append / Delete)
        /// <summary>
        /// Append new solution descriptor
        /// </summary>
        /// <param name="desc"></param>
        public void Append(SelCasePalletSolution selSolution, string name, bool keepSimilarSolutions)
        {
            Document document = selSolution.Analysis.ParentDocument;
            CasePalletSolution sol = selSolution.Solution;
            CasePalletAnalysis analysis = sol.Analysis;
            // instantiate new descriptor
            PalletSolutionDesc desc = new PalletSolutionDesc(this, sol, name);
            // remove similar solutions
            if (!keepSimilarSolutions)
                RemoveByKeyAndCaseDimensions(desc);
            // save solution as stb file
            document.WriteSolution(selSolution, desc.FullFilePath);
            _palletSolutionList.Add(desc);
            _palletSolutionList.Sort();
            if (null != SolutionAppended)
                SolutionAppended(this, new PalletSolutionEventArgs(desc));
            Save();
        }
        /// <summary>
        ///  Remove guid
        /// </summary>
        /// <param name="guid"></param>
        public void RemoveByGuid(Guid guid)
        {
            // find item
            PalletSolutionDesc desc = _palletSolutionList.Find(delegate(PalletSolutionDesc solutionDesc) { return solutionDesc.Guid == guid; });
            try { File.Delete(desc.FullFilePath); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
            _palletSolutionList.Remove(desc);
            // trigger event
            if (null != SolutionDeleted)
                SolutionDeleted(this, new PalletSolutionEventArgs(desc));
            Save();
        }
        private void RemoveByKeyAndCaseDimensions(PalletSolutionDesc descNew)
        { 
            // remove .stb files
            foreach (PalletSolutionDesc desc in _palletSolutionList)
            {
                if (desc.MatchesKeyAndCaseDimensions(descNew))
                {
                    try
                    { File.Delete(desc.FullFilePath); }
                    catch (Exception ex) { _log.Error(ex.ToString()); }
                    // trigger event
                    if (null != SolutionDeleted)
                        SolutionDeleted(this, new PalletSolutionEventArgs(desc));
                }
            }
            // remove descriptors from list
            _palletSolutionList.RemoveAll(delegate(PalletSolutionDesc desc) { return desc.MatchesKeyAndCaseDimensions(descNew); });
            Save();
        }
        #endregion

        #region Event
        public delegate void SolutionMoveHandler(object sender, PalletSolutionEventArgs eventArg);
        public event SolutionMoveHandler SolutionAppended;
        public event SolutionMoveHandler SolutionDeleted;
        #endregion
    }

    public class PalletSolutionEventArgs : EventArgs
    {
        #region Data members
        private PalletSolutionDesc _desc;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="desc">Pallet solution descriptor of solution saved/removed</param>
        /// <param name="added"></param>
        public PalletSolutionEventArgs(PalletSolutionDesc desc)
        {
            _desc = desc;
        }
        #endregion

        #region Public properties
        #endregion
    }
    #endregion
}
