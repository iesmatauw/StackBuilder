#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics.PalletDecoration
{
    public class Corner : ItemBase
    {
        #region Data members
        private double _width;
        private Color _color;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor 1
        /// </summary>
        /// <param name="document">Parent document</param>
        public Corner(Document document)
            : base(document)
        { 
        }
        /// <summary>
        /// Constructor 2
        /// </summary>
        /// <param name="document">Parent document</param>
        /// <param name="width">Width</param>
        /// <param name="color">Color</param>
        public Corner(Document document, double width, Color color)
            : base(document)
        { 
        }
        #endregion

        #region Properties
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        #endregion
    }
}
