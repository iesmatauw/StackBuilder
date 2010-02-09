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
    public class BoxProperties : ItemProperties
    {
        #region Data members
        private double _length, _width, _height;
        private double _weight;
        private Color[] _colors = new Color[6];
        private List<Pair<HalfAxis, Texture>> _textures = new List<Pair<HalfAxis, Texture>>();
        #endregion

        #region Constructor
        public BoxProperties()
        { 
        }
        public BoxProperties(double length, double width, double height)
        {
            _length     = length;
            _width      = width;
            _height     = height;
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
        public double Volume
        {
            get { return _length * _width * _height; }
        }
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public Color[] Colors
        {
            get { return _colors; }
            set { _colors = value; }
        }
        #endregion

        #region Public methods
        public void SetAllColors(Color color)
        {
            for (int i = 0; i < 6; ++i)
                _colors[i] = color;
        }
        public void SetColor(HalfAxis axis, Color color)
        {
            _colors[(int)axis] = color;        
        }
        public void AddTexture(HalfAxis axis, Vector2D position, Vector2D size, Bitmap bmp)
        {
            _textures.Add(new Pair<HalfAxis, Texture>(axis, new Texture(bmp, position, size)));
        }
        public double Dimension(HalfAxis axis)
        {
            switch (axis)
            { 
                case HalfAxis.AXIS_X_N:
                case HalfAxis.AXIS_X_P:
                    return _length;
                case HalfAxis.AXIS_Y_N:
                case HalfAxis.AXIS_Y_P:
                    return _width;
                case HalfAxis.AXIS_Z_N:
                case HalfAxis.AXIS_Z_P:
                    return _height;
                default:
                    return 0.0;
            }
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append(string.Format("BoxProperties => Length = {0}      Width = {1}     Height = {2}", _length, _width, _height) );
            return sBuilder.ToString();
        }
        #endregion
    }
}
