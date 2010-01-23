#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using TreeDim.StackBuilder.Basics;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    /// <summary>
    /// This class displays a computed solution using a gdi+ graphics from a control, a memory bitmap....
    /// </summary>
    public class SolutionViewer
    {
        #region Data members
        private Solution _solution;
        private BoxProperties _boxProperties;
        #endregion

        #region Constructor
        public SolutionViewer()
        {
        }
        #endregion

        #region Public methods
        public void Draw(Graphics3D graphics)
        { 
            // initialize Graphics3D object
            // draw pallet
            // draw solution
            uint pickId = 0;
            foreach (BoxPosition bPosition in _solution)
            {
                Box box = new Box(pickId++, _boxProperties);
                // set position
                box.Position = bPosition.Position;
                // set direction length
                switch (bPosition.DirectionLength)
                {
                    case HalfAxis.AXIS_X_N: box.LengthAxis = -Vector3D.XAxis; break;
                    case HalfAxis.AXIS_X_P: box.LengthAxis = Vector3D.XAxis; break;
                    case HalfAxis.AXIS_Y_N: box.LengthAxis = -Vector3D.YAxis; break;
                    case HalfAxis.AXIS_Y_P: box.LengthAxis = Vector3D.YAxis; break;
                    case HalfAxis.AXIS_Z_N: box.LengthAxis = -Vector3D.ZAxis; break;
                    case HalfAxis.AXIS_Z_P: box.LengthAxis = Vector3D.ZAxis; break;
                    default:
                        Debug.Assert(false);
                        break;
                }
                // set direction width
                switch (bPosition.DirectionWidth)
                {
                    case HalfAxis.AXIS_X_N: box.WidthAxis = -Vector3D.XAxis; break;
                    case HalfAxis.AXIS_X_P: box.WidthAxis = Vector3D.XAxis; break;
                    case HalfAxis.AXIS_Y_N: box.WidthAxis = -Vector3D.YAxis; break;
                    case HalfAxis.AXIS_Y_P: box.WidthAxis = Vector3D.YAxis; break;
                    case HalfAxis.AXIS_Z_N: box.WidthAxis = -Vector3D.ZAxis; break;
                    case HalfAxis.AXIS_Z_P: box.WidthAxis = Vector3D.ZAxis; break;
                    default:
                        Debug.Assert(false);
                        break;
                }
                // draw
                foreach (Face face in box.Faces)
                    graphics.AddFace(face);
            }

            // draw cotations

            // flush
            graphics.Flush();
        }
        #endregion

        #region Public properties
        Solution Solution
        {
            get { return _solution; }
            set { _solution = value; }
        }
        BoxProperties Box
        {
            get { return _boxProperties; }
            set { _boxProperties = value; }
        }
        #endregion
    }
}
