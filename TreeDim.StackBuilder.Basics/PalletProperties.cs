using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Basics
{
    public class PalletProperties
    {
        #region Data members
        string _name;
        double _length, _width, _height;
        private List<Analysis> _dependingAnalyses = new List<Analysis>();
        #endregion

        #region Constructor
        public PalletProperties(double length, double width, double height)
        {
            _length = length;
            _width = width;
            _height = height;
        }
        #endregion

        #region Public properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        #endregion

        #region Public methods
        public void AddDependingAnalysis(Analysis analysis)
        {
            _dependingAnalyses.Add(analysis);
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            return string.Format("PalletProperties => Length {0} Width {0} Height {0}", _length, _width, _height) ;
        }
        #endregion
    }
}
