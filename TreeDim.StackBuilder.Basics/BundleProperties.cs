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
        public BundleProperties(Document document, string name, string description,
            double length, double width
            , double unitThickness
            , double unitWeight
            , int noFlats
            , Color color)
            : base(document, name, description)
        {
            _length = length;
            _width = width;
            _unitThickness = unitThickness;
            _unitWeight = unitWeight;
            _noFlats = noFlats;
            _color = color;
        }
        #endregion

        #region Public properties
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public double Length
        {
            get { return _length; }
        }
        public double Width
        {
            get { return _width; }
        }
        public double UnitThickness
        {
            get { return _unitThickness; }
            set { _unitThickness = value; }
        }
        public double UnitWeight
        {
            get { return _unitWeight; }
            set { _unitWeight = value; }
        }
        public double TotalThickness
        {
            get { return _unitThickness * _noFlats; }
        }
        public int NoFlats
        {
            get { return _noFlats; }
        }
        #endregion
    }
}
