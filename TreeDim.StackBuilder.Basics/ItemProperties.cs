#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    /// <summary>
    /// Name / description properties for Box / Pallet / Interlayer
    /// </summary>
    public class ItemProperties
    {
        #region Data members
        private Document _parentDocument;
        protected string _name, _description;
        protected Guid _guid = Guid.NewGuid();
        private List<Analysis> _dependingAnalyses = new List<Analysis>();
        #endregion

        #region Constructors
        public ItemProperties(Document document)
        {
            _parentDocument = document;
        }
        public ItemProperties(Document document, string name, string description)
        {
            _parentDocument = document;
            _name = name;
            _description = description;
        }
        #endregion

        #region Public properties
        public Document ParentDocument
        {
            get { return _parentDocument; }
        }
        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }
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
        #endregion

        #region Depending analyses
        public void AddDependingAnalysis(Analysis analysis)
        {
            _dependingAnalyses.Add(analysis);
        }
        public bool HasDependingAnalyses
        {
            get { return _dependingAnalyses.Count > 0; }
        }
        public void RemoveDependingAnalysis(Analysis analysis)
        {
            _dependingAnalyses.Remove(analysis);
        }
        #endregion

        #region Object overrides
        public override string ToString()
        {
            return string.Format("Name:{0} \nDescription: {1}\n", _name, _description);
        }
        #endregion
    }
}
