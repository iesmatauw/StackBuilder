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
        private Orientation _globalOrientation;
        #endregion

        #region Constructor
        public CaseDefinitionViewer(CaseDefinition caseDefinition, BoxProperties boxProperties, CaseOptimConstraintSet caseConstraintSet)
        {
            _caseDefinition = caseDefinition;
            _boxProperties = boxProperties;
            _caseOptimConstraintSet = caseConstraintSet;
            _globalOrientation = new Orientation(HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
        }
        #endregion

        #region Public properties
        public BoxProperties CaseProperties
        {
            get { return _caseProperties; }
            set { _caseProperties = value; }
        }
        public bool ShowDimensions
        {
            get { return _showDimentions; }
            set { _showDimentions = value; }
        }
        public Orientation Orientation
        {
            get { return _globalOrientation; }
            set { _globalOrientation = value; }
        }
        #endregion

        #region Drawing
        public void Draw(Graphics3D graphics)
        {
            if (null == _caseDefinition || null == _boxProperties)
                return;

            // get global transformation
            Transform3D transf = _globalOrientation.Transformation;

            // draw case (back faces)
            Case case_ = _caseProperties != null ? new Case(_caseProperties, transf) : null;
            if (null != case_)
            {
                // add inside faces
                Face[] faces = case_.Faces;
                for (int i = 0; i < 6; ++i)
                    faces[i].IsSolid = false;
                foreach (Face f in faces)
                     graphics.AddFace(f);
            }
            // add boxes
            uint pickId = 0;
            for (int i=0; i<_caseDefinition.Arrangement._iLength; ++i)
                for (int j=0; j<_caseDefinition.Arrangement._iWidth; ++j)
                    for (int k = 0; k < _caseDefinition.Arrangement._iHeight; ++k)
                        graphics.AddBox( new Box(pickId++, _boxProperties, GetPosition(i, j, k, _caseDefinition.Dim0, _caseDefinition.Dim1) ) );
            if (_showDimentions)
            {
                // add external dimensions
                Vector3D outerDimensions = _caseDefinition.OuterDimensions(_boxProperties, _caseOptimConstraintSet);
                graphics.AddDimensions(DimensionCube.Transform(new DimensionCube(Vector3D.Zero, outerDimensions.X, outerDimensions.Y, outerDimensions.Z, Color.Black, true), transf));
                // add inner dimensions
                Vector3D innerOffset = _caseDefinition.InnerOffset(_caseOptimConstraintSet);
                Vector3D innerDimensions = _caseDefinition.InnerDimensions(_boxProperties);
                graphics.AddDimensions(DimensionCube.Transform(new DimensionCube(innerOffset, innerDimensions.X, innerDimensions.Y, innerDimensions.Z, Color.Red, false), transf));
            }
        }
        #endregion

        #region Helpers
        private Transform3D GlobalTransformation
        {
            get { return _globalOrientation.Transformation; }
        }
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
                vPosition = new Vector3D(0.0, 0.0, _boxProperties.Width);
            }
            else if (1 == dim0 && 0 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Y_P;
                dirWidth = HalfAxis.HAxis.AXIS_X_N;
                vPosition = new Vector3D(_boxProperties.Width, 0.0, 0.0);
            }
            else if (1 == dim0 && 2 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Z_N;
                dirWidth = HalfAxis.HAxis.AXIS_X_P;
                vPosition = new Vector3D(0.0, _boxProperties.Height, _boxProperties.Length);
            }
            else if (2 == dim0 && 0 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Y_P;
                dirWidth = HalfAxis.HAxis.AXIS_Z_N;
                vPosition = new Vector3D(_boxProperties.Height, 0.0, _boxProperties.Width);
            }
            else if (2 == dim0 && 1 == dim1)
            {
                dirLength = HalfAxis.HAxis.AXIS_Z_P;
                dirWidth = HalfAxis.HAxis.AXIS_Y_P;
                vPosition = new Vector3D(_boxProperties.Height, 0.0, 0.0);
            }
            // add wall thickness
            vPosition += new Vector3D(
                _caseOptimConstraintSet.NoWalls[0] * _caseOptimConstraintSet.WallThickness * 0.5
                , _caseOptimConstraintSet.NoWalls[1] * _caseOptimConstraintSet.WallThickness * 0.5
                , _caseOptimConstraintSet.NoWalls[2] * _caseOptimConstraintSet.WallThickness * 0.5);

            // apply global transformation using _dir0 / _dir1
            return BoxPosition.Transform(
                new BoxPosition(vPosition + new Vector3D(i * boxLength, j * boxWidth, k * boxHeight), dirLength, dirWidth)
                , GlobalTransformation
                );
        }
        #endregion
    }
}
