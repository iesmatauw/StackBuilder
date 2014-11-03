#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    /// <summary>
    /// Cylinder position
    /// </summary>
    public struct CylPosition
    {
        #region Data members
        private Vector3D _vPosition;
        private HalfAxis.HAxis _axis;
        #endregion

        #region Constructor
        public CylPosition(Vector3D vPosition, HalfAxis.HAxis axis)
        {
            _vPosition = vPosition;
            _axis = axis;        
        }
        #endregion

        #region Public properties
        public Vector3D Position
        {
            get { return _vPosition; }
            set { _vPosition = value; }
        }
        public HalfAxis.HAxis Direction
        {
            get { return _axis; }
            set { _axis = value; }
        }
        #endregion

        #region Transformation
        public static CylPosition Transform(CylPosition cylPosition, Transform3D transform)
        {
            return new CylPosition(
                transform.transform(cylPosition._vPosition),
                HalfAxis.ToHalfAxis(
                    transform.transformRot(HalfAxis.ToVector3D(cylPosition._axis))
                    )
                );
        }
        #endregion
    }
}
