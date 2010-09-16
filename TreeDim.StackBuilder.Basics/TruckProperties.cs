#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class TruckProperties : ItemBase
    {
        #region Data members
        private double _admissibleLoadWeight;
        private double _length, _width, _height;
        private Color _color = Color.Red;
        #endregion

        #region Constructor
        public TruckProperties(Document document)
            : base(document)
        { 
        }
        public TruckProperties(Document document, double length, double width, double height)
            : base(document)
        {
            _length = length;
            _width = width;
            _height = height;
        }
        #endregion

        #region Public properties
        public double AdmissibleLoadWeight
        {
            get { return _admissibleLoadWeight; }
            set { _admissibleLoadWeight = value; }
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
        public Color Color
        {
            set { _color = value; }
            get { return _color; }
        }
        #endregion
    }
}
