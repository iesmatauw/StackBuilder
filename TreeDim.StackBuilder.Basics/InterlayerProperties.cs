#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class InterlayerProperties : ItemProperties
    {
        #region Data members
        private double _length = 0.0, _width = 0.0, _thickness = 0.0;
        private double _weight = 0.0;
        private Color _color;
        #endregion

        #region Constructor
        public InterlayerProperties(string name, string description
            , double length, double width, double thickness
            , double weight
            , Color color)
            : base(name, description)
        {
            _length = length;
            _width = width;
            _thickness = thickness;
            _color = color;
        }
        #endregion

        #region Public properties
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
        public double Thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append(string.Format("Length= {0} Width = {1} Thickness = {2}\nWeight = {3}", _length, _width, _thickness, _weight));
            return sBuilder.ToString();
        }
        #endregion
    }
}
