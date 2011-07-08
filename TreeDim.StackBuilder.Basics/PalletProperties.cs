#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class PalletProperties : ItemBase
    {
        #region Enums
        public enum PalletType
        { 
            BLOCK
            , UK_STANDARD
            , EUR
            , EUR2
            , EUR3
            , EUR6
            , US_48_40
        }
        public static string[] PalletTypeNames = {"Block", "UK Standard", "EUR", "EUR2", "EUR3", "EUR6", "US 48 x 40"};
        #endregion

        #region Data members
        double _length, _width, _height;
        double _weight;
        double _admissibleLoadWeight, _admissibleLoadHeight;
        private Color _color = Color.Yellow;
        private PalletType _type = PalletType.BLOCK;
        #endregion

        #region Constructor
        public PalletProperties(Document document, PalletType type, double length, double width, double height)
            : base(document)
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
        public PalletType Type
        {
            get { return _type; }
            set { _type = value; Modify(); }
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
