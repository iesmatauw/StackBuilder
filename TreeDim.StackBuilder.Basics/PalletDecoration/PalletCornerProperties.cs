#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class PalletCornerProperties : ItemBase
    {
        #region Data members
        public double _length, _width, _thickness, _weight;
        public Color _color;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor 1
        /// </summary>
        /// <param name="document">Parent document</param>
        public PalletCornerProperties(Document document)
            : base(document)
        { 
        }
        /// <summary>
        /// Constructor 2
        /// </summary>
        /// <param name="document">Parent document</param>
        /// <param name="width">Width</param>
        /// <param name="color">Color</param>
        public PalletCornerProperties(Document document,
            string name, string description,
            double length, double width, double thickness,
            double weight,
            Color color)
            : base(document, name, description)
        {
            _length = length;
            _width = width;
            _thickness = thickness;
            _weight = weight;
        }
        #endregion

        #region Properties
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
    }
}
