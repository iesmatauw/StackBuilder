#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    class DrawableComparerSimplifiedPainterAlgo : IComparer<Drawable>
    {
        #region Constructor
        public DrawableComparerSimplifiedPainterAlgo()
        {
        }
        #endregion

        #region Implementation IComparer
        public int Compare(Drawable d1, Drawable d2)
        {
            Vector3D position1 = Pos(d1);
            Vector3D position2 = Pos(d2);

            if (position1.Z > position2.Z)
                return 1;
            else if (position1.Z == position2.Z)
                    return 0;
            else
                return -1;
        }
        #endregion

        #region Helpers
        Vector3D Pos(Drawable d)
        {
            Box b = d as Box;
            if (null != b) return b.Position;
            Cylinder c = d as Cylinder;
            if (null != c) return c.Position.XYZ;
            return Vector3D.Zero;        
        }
        #endregion
    }
}
