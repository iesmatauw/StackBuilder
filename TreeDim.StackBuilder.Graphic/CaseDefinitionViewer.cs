#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using TreeDim.StackBuilder.Basics;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    /// <summary>
    /// This class displays a case layout as generated when performing a case optimisation.
    /// It uses a gdi+ graphics from a control, a memory bitmap
    /// </summary>
    public class CaseDefinitionViewer
    {
        #region Data members
        private BoxProperties _boxProperties;
        private BoxProperties _caseProperties;
        private CaseDefinition _caseDefinition;
        private CaseOptimConstraintSet _caseOptimConstraintSet;
        private bool _showDimentions = true;
        #endregion

        #region Constructor
        public CaseDefinitionViewer(CaseDefinition caseDefinition, BoxProperties boxProperties, CaseOptimConstraintSet caseConstraintSet)
        {
            _caseDefinition = caseDefinition;
            _boxProperties = boxProperties;
            _caseOptimConstraintSet = caseConstraintSet;
        }
        #endregion

        #region Public properties
        public BoxProperties CaseProperties
        {
            get { return _caseProperties; }
            set { _caseProperties = value; }
        }
        #endregion

        #region Public methods
        public void Draw(Graphics3D graphics)
        {
            if (null == _caseDefinition || null == _boxProperties)
                return;
            // draw case (back faces)
            Case case_ = _caseProperties != null ? new Case(_caseProperties) : null;
            if (null != case_)
                case_.DrawBegin(graphics);
            // initialize Graphics3D object
            double boxLength = _caseDefinition.BoxLength(_boxProperties);
            double boxWidth = _caseDefinition.BoxWidth(_boxProperties);
            double boxHeight = _caseDefinition.BoxHeight(_boxProperties);
            // add boxes
            uint pickId = 0;
            for (int i=0; i<_caseDefinition.Arrangement._iLength; ++i)
                for (int j=0; j<_caseDefinition.Arrangement._iWidth; ++j)
                    for (int k = 0; k < _caseDefinition.Arrangement._iHeight; ++k)
                        graphics.AddBox( new Box(pickId++, _boxProperties, GetPosition(i, j, k, _caseDefinition.Dim0, _caseDefinition.Dim1) ) );
            // add external dimensions
            Vector3D outerDimensions = _caseDefinition.OuterDimensions(_boxProperties, _caseOptimConstraintSet);
            graphics.AddDimensions(new DimensionCube(Vector3D.Zero,outerDimensions.X, outerDimensions.Y, outerDimensions.Z, Color.Black, true));
            // add inner dimensions
            Vector3D innerOffset = _caseDefinition.InnerOffset(_caseOptimConstraintSet);
            Vector3D innerDimensions = _caseDefinition.InnerDimensions(_boxProperties);
            graphics.AddDimensions(new DimensionCube(innerOffset, innerDimensions.X, innerDimensions.Y, innerDimensions.Z, Color.Red, false));
            // flush
            graphics.Flush();
            // draw case (front faces)
            if (null != case_)
                case_.DrawEnd(graphics);
        }
        #endregion

        #region Helpers
        private BoxPosition GetPosition(int i, int j, int k, int dim0, int dim1)
        {
            double boxLength = _caseDefinition.BoxLength(_boxProperties);
            double boxWidth = _caseDefinition.BoxWidth(_boxProperties);
            double boxHeight = _caseDefinition.BoxHeight(_boxProperties);
            HalfAxis.HAxis dirLength = HalfAxis.HAxis.AXIS_X_P;
            HalfAxis.HAxis dirWidth = HalfAxis.HAxis.AXIS_Y_P;

            Vector3D vPosition = Vector3D.Zero;
            if (0 == dim0 && 1 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_X_P;
                dirWidth = HalfAxis.HAxis.AXIS_Y_P;
                vPosition = Vector3D.Zero;
            }
            else if (0 == dim0 && 2 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_X_P;
                dirWidth = HalfAxis.HAxis.AXIS_Z_N;
                vPosition = new Vector3D(0.0, 0.0, _boxProperties.Width/*boxWidth*/);
            }
            else if (1 == dim0 && 0 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Y_P;
                dirWidth = HalfAxis.HAxis.AXIS_X_N;
                vPosition = new Vector3D(_boxProperties.Width/*boxWidth*/, 0.0, 0.0);
            }
            else if (1 == dim0 && 2 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Z_N;
                dirWidth = HalfAxis.HAxis.AXIS_X_P;
                vPosition = new Vector3D(0.0, _boxProperties.Height/*boxHeight*/, _boxProperties.Length/*boxLength*/);
            }
            else if (2 == dim0 && 0 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Y_P;
                dirWidth = HalfAxis.HAxis.AXIS_Z_N;
                vPosition = new Vector3D(_boxProperties.Height/*boxHeight*/, 0.0, _boxProperties.Width/*boxWidth*/);
            }
            else if (2 == dim0 && 1 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Z_P;
                dirWidth = HalfAxis.HAxis.AXIS_Y_P;
                vPosition = new Vector3D(_boxProperties.Height/*boxHeight*/, 0.0, 0.0);
            }
            // add wall thickness
            vPosition += new Vector3D(
                _caseOptimConstraintSet.NoWalls[0] * _caseOptimConstraintSet.WallThickness * 0.5
                , _caseOptimConstraintSet.NoWalls[1] * _caseOptimConstraintSet.WallThickness * 0.5
                , _caseOptimConstraintSet.NoWalls[2] * _caseOptimConstraintSet.WallThickness * 0.5);

            return new BoxPosition(vPosition + new Vector3D(i * boxLength, j * boxWidth, k * boxHeight), dirLength, dirWidth);
        }
        #endregion
    }
}
