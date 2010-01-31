#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

using TreeDim.StackBuilder.Graphics;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public interface IDocumentListener
    {
        // new
        void OnNewDocument(Document doc);
        void OnNewBoxCreated(Document doc, BoxProperties boxProperties);
        void OnNewPalletCreated(Document doc, PalletProperties palletProperties);
        void OnNewAnalysisCreated(Document doc, Analysis analysis);
        // remove
        void OnBoxRemoved(Document doc, Analysis analysis);
        void OnPalletRemoved(Document doc, Analysis analysis);
        void OnAnalysisRemoved(Document doc, Analysis analysis);
    }

    public class Document
    {
        #region Data members
        private List<BoxProperties> _boxList = new List<BoxProperties>();
        private List<PalletProperties> _palletList = new List<PalletProperties>();
        private List<Analysis> _analyses = new List<Analysis>();
        private List<IDocumentListener> _listeners = new List<IDocumentListener>();
        private string _filePath = string.Empty;
        #endregion

        #region Public methods
        public BoxProperties CreateNewBox(string name, string description, double length, double width, double height, double weight, Color[] colors)
        {
            // instantiate and initialize
            BoxProperties boxProperties = new BoxProperties(length, width, height);
            boxProperties.Name = name;
            boxProperties.Description = description;
            boxProperties.Colors = colors;
            // insert in list
            _boxList.Add(boxProperties);
            // notify listeners
            NotifyOnNewBoxCreated(boxProperties);

            return boxProperties;
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
            _palletList.Add(palletProperties);
            // notify listeners
            NotifyOnNewPalletCreated(palletProperties);

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

            return analysis;
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
        public List<BoxProperties> Boxes { get { return _boxList; } }
        public List<PalletProperties> Pallets { get { return _palletList; } }

        public bool CanCreateAnalysis
        {
            get { return _boxList.Count > 0 && _palletList.Count > 0; }
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
        private void NotifyOnNewBoxCreated(BoxProperties boxProperties)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewBoxCreated(this, boxProperties);
        }
        private void NotifyOnNewPalletCreated(PalletProperties palletProperties)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewPalletCreated(this, palletProperties);       
        }
        private void NotifyOnNewAnalysisCreated(Analysis analysis)
        {
            foreach (IDocumentListener listener in _listeners)
                listener.OnNewAnalysisCreated(this, analysis);
        }
        #endregion

    }
}
