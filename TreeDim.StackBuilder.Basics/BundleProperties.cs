#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class BundleProperties : ItemProperties
    {
        #region Data members
        private double _length = 0.0, _width = 0.0, _unitThickness = 0.0, _unitWeight = 0.0;
        private int _noFlats;
        private Color _color;
        #endregion

        #region Constructor
        public BundleProperties(string name, string description,
            double length, double width
            , double unitThickness
            , double unitWeight
            , int noFlats
            , Color color)
            : base(name, description)
        {
            _length = length;
            _width = width;
            _unitThickness = unitThickness;
            _unitWeight = unitWeight;
            _noFlats = noFlats;
        }
        #endregion

        #region Public properties
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        #endregion
    }
}
