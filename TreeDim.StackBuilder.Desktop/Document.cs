#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

using TreeDim.StackBuilder.Graphics;
using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
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

    public class Document
    {
        #region Data members
        private List<ItemProperties> _typeList = new List<ItemProperties>();
        private List<Analysis> _analyses = new List<Analysis>();
        private List<IDocumentListener> _listeners = new List<IDocumentListener>();
        private string _filePath = string.Empty;
        #endregion

        #region Public ItemProperties instantiation methods
        public BoxProperties CreateNewBox(
            string name, string description
            , double length, double width, double height, double weight
            , Color[] colors)
        {
            // instantiate and initialize
            BoxProperties boxProperties = new BoxProperties(length, width, height);
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
            , BoxProperties box, PalletProperties pallet, ConstraintSet constraintSet)
        {
            Analysis analysis = new Analysis(box, pallet, constraintSet);
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
        public string Title
        {
            get
            {
                if (0 == _filePath.Length)
                    return "Untitled";
                else
                    return Path.GetFileNameWithoutExtension(_filePath);
            }
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

        #region Save / load methods
        public void Save()
        { 
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
}
