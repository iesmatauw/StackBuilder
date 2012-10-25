#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region InvalidBBoxException
    class InvalidBBoxException : Exception
    {
        #region Constructor
        public InvalidBBoxException(string message)
            : base(message)
        {
        }
        #endregion
    }
    #endregion

    #region BBox3D
    public class BBox3D : ICloneable
    {
        #region Data members
        private Vector3D _ptMin = new Vector3D(double.MaxValue, double.MaxValue, double.MaxValue);
        private Vector3D _ptMax = new Vector3D(double.MinValue, double.MinValue, double.MinValue);
        #endregion

        #region Constructor
        public BBox3D()
        {
        }
        public BBox3D(double xmin, double ymin, double zmin, double xmax, double ymax, double zmax)
        {
            Extend( new Vector3D(xmin, ymin, zmin) );
            Extend( new Vector3D(xmax, ymax, zmax) );
        }
        public BBox3D(Vector3D pt0, Vector3D pt1)
        {
            Extend(pt0);
            Extend(pt1);
        }
        public BBox3D(BBox3D box)
        {
            Extend(box._ptMin);
            Extend(box._ptMax);
        }
        #endregion

        #region Constants
        public static BBox3D Initial { get { return new BBox3D(); } }
        #endregion

        #region Public methods
        public bool IsValid
        {
            get { return (_ptMin.X <= _ptMax.X) && (_ptMin.Y <= _ptMax.Y) && (_ptMin.Z <= _ptMax.Z); }
        }
        public void Reset()
        {
            _ptMin = new Vector3D(double.MaxValue, double.MaxValue, double.MaxValue);
            _ptMax = new Vector3D(double.MinValue, double.MinValue, double.MinValue);
        }
        public void Extend(Vector3D vec)
        {
            _ptMin.X = Math.Min(_ptMin.X, vec.X);
            _ptMin.Y = Math.Min(_ptMin.Y, vec.Y);
            _ptMin.Z = Math.Min(_ptMin.Z, vec.Z);

            _ptMax.X = Math.Max(_ptMax.X, vec.X);
            _ptMax.Y = Math.Max(_ptMax.Y, vec.Y);
            _ptMax.Z = Math.Max(_ptMax.Z, vec.Z);

        }
        public void Extend(BBox3D box)
        {
            _ptMin.X = Math.Min(_ptMin.X, box._ptMin.X);
            _ptMin.Y = Math.Min(_ptMin.Y, box._ptMin.Y);
            _ptMin.Z = Math.Min(_ptMin.Z, box._ptMin.Z);
            _ptMax.X = Math.Max(_ptMax.X, box._ptMax.X);
            _ptMax.Y = Math.Max(_ptMax.Y, box._ptMax.Y);
            _ptMax.Z = Math.Max(_ptMax.Z, box._ptMax.Z);
        }
        public void Inflate(double margin)
        {
            if (!IsValid)
                throw new InvalidBBoxException("Box is invalid: can not set margin");
            _ptMin.X -= margin;
            _ptMax.X += margin;
            _ptMin.Y -= margin;
            _ptMax.Y += margin;
            _ptMin.Z -= margin;
            _ptMax.Z += margin;
        }
        #endregion

        #region Public properties
        public double Length { get { return _ptMax.X - _ptMin.X; } }
        public double Width { get { return _ptMax.Y - _ptMin.Y; } }
        public double Height { get { return _ptMax.Z - _ptMin.Z; } }
        public Vector3D PtMin { get { return _ptMin; } }
        #endregion

        #region ICloneable Members
        /// <summary>
        /// Creates an exact copy of this <see cref="Box2D"/> object.
        /// </summary>
        /// <returns>The <see cref="Box2D"/> object this method creates, cast as an object.</returns>
        object ICloneable.Clone()
        {
            return new BBox3D(this);
        }
        /// <summary>
        /// Creates an exact copy of this <see cref="Box2D"/> object.
        /// </summary>
        /// <returns>The <see cref="Box2D"/> object this method creates.</returns>
        public BBox3D Clone()
        {
            return new BBox3D(this);
        }
        #endregion

        #region System.Object overrides
        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return _ptMin.GetHashCode() ^ _ptMax.GetHashCode();
        }
        /// <summary>
        /// Returns a value indicating whether this instance is equal to
        /// the specified object.
        /// </summary>
        /// <param name="obj">An object to compare to this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="obj"/> is a <see cref="Box2D"/> and has the same values as this instance; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is BBox3D)
            {
                BBox3D v = (BBox3D)obj;
                return (_ptMin.Equals(v._ptMin)) && (_ptMax.Equals(v._ptMax));
            }
            return false;
        }
        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        /// <returns>A string representation of this object.</returns>        public override string ToString()
        public override string ToString()
        {
            return string.Format("xmin = {0}, ymin = {1}, zmin = {2}, xmax = {3}, ymax = {4}, zmax = {5}", _ptMin.X, _ptMin.Y, _ptMin.Z, _ptMax.X, _ptMax.Y, _ptMax.Z);
        }
        #endregion
    }
    #endregion
}
