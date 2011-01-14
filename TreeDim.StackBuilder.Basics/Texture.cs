#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region Pair class
    public class Pair<T1, T2>
    {
        public Pair(T1 m1, T2 m2)
        {
            first = m1;
            second = m2;
        }

        public T1 first;
        public T2 second;
    }
    #endregion

    #region Texture
    public class Texture
    {
        #region Data members
        /// <summary>
        /// Texture bitmap
        /// </summary>
        private Bitmap _bitmap = null;
        /// <summary>
        /// Image position 
        /// </summary>
        private Vector2D _position = new Vector2D();
        /// <summary>
        /// Image size
        /// </summary>
        private Vector2D _size = new Vector2D();
        /// <summary>
        /// Angle
        /// </summary>
        private double _angle;
        #endregion

        #region Constructor
        public Texture(Bitmap bitmap, Vector2D position, Vector2D size, double angle)
        {
            _bitmap = bitmap;
            _position = position;
            _size = size;
            _angle = angle;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Bitmap
        /// </summary>
        public Bitmap Bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; }
        }
        /// <summary>
        /// Image position
        /// </summary>
        public Vector2D Position
        {
            get { return _position; }
            set { _position = value; }
        }
        /// <summary>
        /// Image size
        /// </summary>
        public Vector2D Size
        {
            get { return _size; }
            set { _size = value; }
        }
        /// <summary>
        /// Angle
        /// </summary>
        public double Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }
        #endregion

        #region Object method overrides
        public override string ToString()
        {
            return string.Format("Texture : Position {0} Size {1} Angle {2}", _position, _size, _angle);
        }
        #endregion
    }
    #endregion
}
