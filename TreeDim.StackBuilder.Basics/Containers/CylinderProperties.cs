#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class CylinderProperties : ItemBase
    {
        #region Data members
        protected double _radius, _height;
        private double _weight;
        private Color _colorTop;
        private Color _colorWall;
        #endregion

        #region Constructor
        public CylinderProperties(Document document)
            : base(document)
        {
        }
        public CylinderProperties(Document document, string name, string description
            , double radius, double height, double weight, Color colorTop, Color colorWall)
            : base(document, name, description)
        {
            _radius = radius;
            _height = height;
            _weight = weight;
            _colorTop = colorTop;
            _colorWall = colorWall;
        }
        #endregion

        #region Public properties
        public double Radius
        {
            get { return _radius; }
            set { _radius = value; Modify(); }
        }
        public double Height
        {
            get { return _height; }
            set { _height = value; Modify(); }
        }
        public double Volume
        {
            get { return _height * Math.PI * _radius * _radius; }
        }
        public virtual double Weight
        {
            get { return _weight; }
            set { _weight = value; Modify(); }
        }
        public Color ColorTop
        {
            get { return _colorTop; }
            set { _colorTop = value; Modify(); }
        }
        public Color ColorWall
        {
            get { return _colorWall; }
            set { _colorWall = value; Modify(); }
        }
        #endregion

        #region Public methods

        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append(string.Format("Cylinder => Radius = {0} Height = {1} Weight = {2}", _radius, _height, _weight) );
            return sBuilder.ToString();
        }
        #endregion
    }
}
