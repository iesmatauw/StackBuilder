#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class BoxComparer : IComparer<Box>
    {
        #region Data members
        private Vector3D _vCameraPos, _vTarget;
        private StringBuilder sb = new StringBuilder();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vCameraPos">Camera position</param>
        /// <param name="vTarget">Target position</param>
        public BoxComparer(Vector3D vCameraPos, Vector3D vTarget)
        {
            _vCameraPos = vCameraPos;
            _vTarget = vTarget;
        }
        #endregion

        #region IComparer<Box> implementation
        public int Compare(Box b1, Box b2)
        {
            if (b1.Center.Z > b2.Center.Z)
                return -1;
            else if (b1.Center.Z == b2.Center.Z)
            {
                /*
                if (b1.Center == b2.Center)
                {
                    sb.AppendLine(string.Format("{0} == {1}", b1.PickId, b2.PickId));
                    return 0;
                }
                bool b2BehindB1 = b1.BoxBehind(b2, _vTarget - _vCameraPos);
                bool b1BehindB2 = b2.BoxBehind(b1, _vTarget - _vCameraPos);
                if (b2BehindB1 && !b1BehindB2)
                {
                    sb.AppendLine(string.Format("{0} < {1}", b2.PickId, b1.PickId));
                    return 1;
                }
                else if (!b2BehindB1 && b1BehindB2)
                {
                    sb.AppendLine(string.Format("{0} < {1}", b1.PickId, b2.PickId));
                    return -1;
                }
                else
                {
                    sb.AppendLine(string.Format("{0} == {1}", b1.PickId, b2.PickId));
                    return 0;
                }
                */
                return 0;
            }
            else
                return -1;
        }
        #endregion

        #region Properties
        public string SortString
        {
            get { return sb.ToString(); }
        }
        #endregion
    }

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
