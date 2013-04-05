#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    #region Box comparison
    public class CylinderComparerSimplifiedPainterAlgo : IComparer<Cylinder>
    {
        #region Constructor
        public CylinderComparerSimplifiedPainterAlgo(Transform3D transform)
        {
            _transform = transform;
        }
        #endregion

        #region Implementation IComparer
        public int Compare(Cylinder c1, Cylinder c2)
        {
            if (c1.Position.Z > c2.Position.Z)
                return 1;
            else if (c1.Position.Z == c2.Position.Z)
            {
                if (_transform.transform(c1.Position).Z < _transform.transform(c2.Position).Z)
                    return 1;
                else if (_transform.transform(c1.Position).Z == _transform.transform(c2.Position).Z)
                    return 0;
                else
                    return -1;
            }
            else
                return -1;
        }
        #endregion

        #region Data members
        Transform3D _transform;
        #endregion
    }
    #endregion
}
