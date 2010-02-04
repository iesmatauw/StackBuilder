#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class PalletProperties : ItemProperties
    {
        #region Enums
        public enum PalletType
        { 
            BLOCK
        }
        public static string[] PalletTypeNames = { "Block" };
        #endregion

        #region Data members
        double _length, _width, _height;
        double _weight;
        double _admissibleLoadWeight, _admissibleLoadHeight;
        private Color _color = Color.Yellow;
        private PalletType _type = PalletType.BLOCK;
        #endregion

        #region Constructor
        public PalletProperties(PalletType type, double length, double width, double height)
        {
            _type = type;
            _length = length;
            _width = width;
            _height = height;
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
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public double AdmissibleLoadWeight
        {
            get { return _admissibleLoadWeight; }
            set { _admissibleLoadWeight = value; }
        }
        public double AdmissibleLoadHeight
        {
            get { return _admissibleLoadHeight; }
            set { _admissibleLoadHeight = value; }
        }
        public PalletType Type
        {
            get { return _type; }
        }
        public Color Color
        {
            set { _color = value; }
            get { return _color; }
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append(string.Format("PalletProperties => Length {0} Width {0} Height {0}", _length, _width, _height));
            return sBuilder.ToString();
        }
        #endregion
    }
}
