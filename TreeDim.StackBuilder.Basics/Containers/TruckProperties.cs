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
            set { _admissibleLoadWeight = value; Modify(); }
        }
        public double Length
        {
            get { return _length; }
            set { _length = value; Modify(); }
        }
        public double Width
        {
            get { return _width; }
            set { _width = value; Modify(); }
        }
        public double Height
        {
            get { return _height; }
            set { _height = value; Modify(); }
        }
        public double Volume
        {
            get { return _length * _width * _height; }
        }
        public Color Color
        {
            get { return _color;  }
            set { _color = value; Modify();}
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append(string.Format("TruckProperties => Length {0} Width {0} Height {0}", _length, _width, _height));
            return sBuilder.ToString();
        }
        #endregion
    }
}
