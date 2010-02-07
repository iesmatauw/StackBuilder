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
        private Analysis _analysis;
        #endregion

        #region Constructor
        public SolutionViewer(Analysis analysis, Solution solution)
        {
            _analysis = analysis;
            _solution = solution;
        }
        #endregion

        #region Public methods
        public void Draw(Graphics3D graphics)
        {
            if (null == _solution)
                return;
            // initialize Graphics3D object
            // draw pallet
            Pallet pallet = new Pallet(_analysis.PalletProperties);
            pallet.Draw(graphics);
            // draw solution
            uint pickId = 0;
            foreach (BoxLayer layer in _solution)
                foreach (BoxPosition bPosition in layer)
                {
                    Box box = new Box(pickId++, _analysis.BoxProperties);
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
        public Solution Solution
        {
            get { return _solution; }
            set { _solution = value; }
        }
        #endregion
    }
}
