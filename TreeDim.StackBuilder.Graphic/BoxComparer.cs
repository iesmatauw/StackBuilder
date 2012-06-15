#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
     #region Box comparison
    public class BoxComparerSimplifiedPainterAlgo : IComparer<Box>
    {
        #region Constructor
        public BoxComparerSimplifiedPainterAlgo(Transform3D transform)
        {
            _transform = transform;
        }
        #endregion

        #region Implementation IComparer
        public int Compare(Box b1, Box b2)
        {
            if (b1.Center.Z > b2.Center.Z)
                return 1;
            else if (b1.Center.Z == b2.Center.Z)
            {
                if (_transform.transform(b1.Center).Z < _transform.transform(b2.Center).Z)
                    return 1;
                else if (_transform.transform(b1.Center).Z == _transform.transform(b2.Center).Z)
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
