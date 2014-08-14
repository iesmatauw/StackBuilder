#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class PalletProperties : ItemBase
    {
        #region Data members
        double _length, _width, _height;
        double _weight;
        double _admissibleLoadWeight, _admissibleLoadHeight;
        private Color _color = Color.Yellow;
        private string _typeName = "Block";
        #endregion

        #region Constructor
        public PalletProperties(Document document, string typeName, double length, double width, double height)
            : base(document)
        {
            _typeName = typeName;
            _length = length;
            _width = width;
            _height = height;
        }
        #endregion

        #region Public properties
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
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; Modify(); }
        }
        public double AdmissibleLoadWeight
        {
            get { return _admissibleLoadWeight; }
            set { _admissibleLoadWeight = value; Modify(); }
        }
        public double AdmissibleLoadHeight
        {
            get { return _admissibleLoadHeight; }
            set { _admissibleLoadHeight = value; Modify(); }
        }
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; Modify(); }
        }
        public Color Color
        {
            set { _color = value; }
            get { return _color; }
        }
        public BBox3D BoundingBox
        {
            get { return new BBox3D(Vector3D.Zero, new Vector3D(_length, _width, _height)); }
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append(string.Format("PalletProperties => Type {0} Length {1} Width {2} Height {3}", _typeName, _length, _width, _height));
            return sBuilder.ToString();
        }
        #endregion
    }
}
