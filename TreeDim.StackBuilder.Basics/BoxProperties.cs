#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    /// <summary>
    /// Box properties (dimensions, colors, textures)
    /// </summary>
    public class BoxProperties : BProperties
    {
        #region Data members
        private double _height;
        private bool _hasInsideDimensions;
        private double _insideLength, _insideWidth, _insideHeight;
        private Color[] _colors = new Color[6];
        private List<Pair<HalfAxis.HAxis, Texture>> _textures = new List<Pair<HalfAxis.HAxis, Texture>>();
        #endregion

        #region Constructor
        public BoxProperties(Document document, double length, double width, double height)
            : base(document)
        {
            _length     = length;
            _width      = width;
            _height     = height;
        }
        #endregion

        #region Height
        public override double Height
        {
            get { return _height; }
            set { _height = value; Modify(); }
        }
        #endregion

        #region InsideDimensions
        public bool HasInsideDimensions
        {
            get { return _hasInsideDimensions; }
            set { _hasInsideDimensions = value; Modify(); }
        }
        public double InsideLength
        {
            get { return _hasInsideDimensions ? _insideLength : _length; }
            set { _insideLength = value; Modify(); }
        }
        public double InsideWidth
        {
            get { return _hasInsideDimensions ? _insideWidth : _width; }
            set { _insideWidth = value; Modify(); }
        }
        public double InsideHeight
        {
            get { return _hasInsideDimensions ? _insideHeight : _height; }
            set { _insideHeight = value; Modify(); }
        }
        #endregion

        #region Colors
        public override void SetColor(Color color)
        {
            for (int i = 0; i < 6; ++i)
                _colors[i] = color;
            Modify();
        }
        public override Color GetColor(HalfAxis.HAxis axis)
        {
            return _colors[(int)axis];
        }

        public override Color[] Colors
        {
            get { return _colors; }
        }
        public void SetColor(HalfAxis.HAxis axis, Color color)
        {
            _colors[(int)axis] = color;
            Modify();
        }
        public void SetAllColors(Color[] color)
        {
            for (int i = 0; i < 6; ++i)
                _colors[i] = color[i];
            Modify();
        }
        public void AddTexture(HalfAxis.HAxis axis, Vector2D position, Vector2D size, Bitmap bmp)
        {
            _textures.Add(new Pair<HalfAxis.HAxis, Texture>(axis, new Texture(bmp, position, size)));
            Modify();
        }
        #endregion

        #region IsBundle
        public override bool IsBundle { get { return false; } }
        #endregion
    }
}
