#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class PalletCapProperties : ItemBase
    {
        #region Data members
        public double _length, _width, _height, _insideLength, _insideWidth, _insideHeight;
        public double _weight;
        public Color _color;
        #endregion

        #region Constructor
        public PalletCapProperties(Document doc)
            : base(doc)
        { 
        }
        public PalletCapProperties(Document doc,
            string name, string description,
            double length, double width, double height,
            double insideLength, double insideWidth, double insideHeight,
            double weight,
            Color color)
            : base(doc, name, description)
        {
            _length = length; _width = width; _height = height;
            _insideLength = insideLength; _insideWidth = insideWidth; _insideHeight = insideHeight;
            _weight = weight;
            _color = color;
        }
        #endregion

        #region Public properties
        public double Length { get { return _length; } }
        public double Width { get { return _width; } }
        public double Height { get { return _height; } }
        public double InsideLength { get { return _insideLength; } }
        public double InsideWidth { get { return _insideWidth; } }
        public double InsideHeight { get { return _insideHeight; } }
        public double Thickness { get { return _height - _insideHeight; } }
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
    }
}
