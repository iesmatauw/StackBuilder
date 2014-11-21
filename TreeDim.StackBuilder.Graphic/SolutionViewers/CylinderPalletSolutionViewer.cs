#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

using TreeDim.StackBuilder.Basics;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    /// <summary>
    /// This class displays a computed solution using a gdi+ graphics from a control, a memory bitmap....
    /// </summary>
    public class CylinderPalletSolutionViewer
    {
        #region Data members
        private CylinderPalletSolution _solution;
        private CylinderPalletAnalysis _analysis;
        private bool _showDimensions = true;
        #endregion

        #region Constructor
        public CylinderPalletSolutionViewer(CylinderPalletSolution solution)
        {
            _analysis = null != solution ? solution.Analysis : null;
            _solution = solution;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Use this method when drawing a solution that belongs an analysis
        /// </summary>
        public void Draw(Graphics3D graphics)
        {
            if (null == _solution)
                return;
            // initialize Graphics3D object
            if (!graphics.ShowBoxIds)
            {
                // draw pallet
                Pallet pallet = new Pallet(_analysis.PalletProperties);
                pallet.Draw(graphics, Transform3D.Identity);
            }
            // draw solution
            uint pickId = 0;
            foreach (ILayer layer in _solution)
            {
                CylinderLayer cylLayer = layer as CylinderLayer;
                if (null != cylLayer)
                {
                    foreach (Vector3D pos in cylLayer)
                        graphics.AddCylinder(
                            new Cylinder(pickId++, _analysis.CylinderProperties, new CylPosition(pos, HalfAxis.HAxis.AXIS_Z_P))
                            );
                }

                InterlayerPos interlayerPos = layer as InterlayerPos;
                if (null != interlayerPos)
                {
                    Box box = new Box(pickId++, _analysis.InterlayerProperties);
                    // set position
                    box.Position = new Vector3D(
                        0.5 * (_analysis.PalletProperties.Length - _analysis.InterlayerProperties.Length)
                        , 0.5 * (_analysis.PalletProperties.Width - _analysis.InterlayerProperties.Width)
                        , interlayerPos.ZLow);
                    // draw
                    graphics.AddBox(box);
                }
            }
            if (_showDimensions)
            {
                if (_showDimensions)
                {
                    graphics.AddDimensions(
                        new DimensionCube(BoundingBoxDim(Properties.Settings.Default.DimCasePalletSol1)
                        , Color.Black, false));
                    graphics.AddDimensions(
                        new DimensionCube(BoundingBoxDim(Properties.Settings.Default.DimCasePalletSol2)
                        , Color.Red, true));
                }
            }

            // flush
            graphics.Flush();
        }
        public void Draw(Graphics2D graphics)
        {
            if (null == _solution || _solution.Count == 0)
                return;

            bool showAxis = false;

            // initialize Graphics2D object
            graphics.NumberOfViews = 1;
            graphics.SetViewport(0.0f, 0.0f, (float)_solution.PalletLength, (float)_solution.PalletWidth);

            CylinderLayer cylLayer = _solution.CylinderLayerFirst;
            if (cylLayer != null)
            {
                graphics.SetCurrentView(0);
                graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, _analysis.PalletProperties.Width), Color.Black);
                uint pickId = 0;
                foreach (Vector3D pos in cylLayer)
                    graphics.DrawCylinder(
                        new Cylinder(pickId++, _analysis.CylinderProperties, new CylPosition(pos, HalfAxis.HAxis.AXIS_Z_P))
                        );

                // draw axes
                if (showAxis)
                {
                    // draw axis X
                    graphics.DrawLine(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, 0.0), Color.Red);
                    // draw axis Y
                    graphics.DrawLine(Vector2D.Zero, new Vector2D(0.0, _analysis.PalletProperties.Width), Color.Green);
                }
            }
        }

                /// <summary>
        /// Draw layers
        /// Images are used during report generation
        /// </summary>
        public void DrawLayers(Graphics3D graphics, bool showPallet, int layerIndex)
        {
            if (null == _solution)
                throw new Exception("No solution defined!");

            if (!graphics.ShowBoxIds) // -> if box ids are drawn, we do not draw pallet
            {
                // draw pallet
                Pallet pallet = new Pallet(_analysis.PalletProperties);
                pallet.Draw(graphics, Transform3D.Identity);
            }
            // draw solution
            uint pickId = 0;
            CylinderLayer cylLayer = _solution.CylinderLayerFirst;
            if (cylLayer != null)
            {
                foreach (Vector3D pos in cylLayer)
                    graphics.AddCylinder(new Cylinder(pickId++, _analysis.CylinderProperties, new CylPosition(pos, HalfAxis.HAxis.AXIS_Z_P)));
            }
            // flush
            graphics.Flush();
        }

        BBox3D BoundingBoxDim(int index)
        {
            switch (index)
            {
                case 0: return _solution.BoundingBox;
                case 1: return _solution.LoadBoundingBox;
                case 2: return _analysis.PalletProperties.BoundingBox;
                case 3: return new BBox3D(0.0, 0.0, 0.0, _analysis.PalletProperties.Length, _analysis.PalletProperties.Width, 0.0);
                default: return _solution.BoundingBox;
            }
        }
        #endregion

        #region Public properties
        public bool ShowDimensions
        {
            get { return _showDimensions; }
            set { _showDimensions = value; }
        }
        #endregion
    }

    public class HCylinderPalletSolutionViewer
    {
        #region Data members
        private HCylinderPalletSolution _solution;
        private HCylinderPalletAnalysis _analysis;
        private bool _showDimensions = true;
        #endregion

        #region Constructor
        public HCylinderPalletSolutionViewer(HCylinderPalletSolution solution)
        {
            _analysis = null != solution ? solution.Analysis : null;
            _solution = solution;
        }
        #endregion

        #region Public methods
        public void Draw(Graphics3D graphics)
        {
            if (null == _solution)
                return;
            // initialize Graphics3D object
            if (!graphics.ShowBoxIds)
            {
                // draw pallet
                Pallet pallet = new Pallet(_analysis.PalletProperties);
                pallet.Draw(graphics, Transform3D.Identity);
            }
            // draw solution
            uint pickId = 0;
            foreach (CylPosition pos in _solution)
                graphics.AddCylinder(new Cylinder(pickId++, _analysis.CylinderProperties, pos));

            if (_showDimensions)
            {
                graphics.AddDimensions(
                    new DimensionCube(BoundingBoxDim(Properties.Settings.Default.DimCasePalletSol1)
                    , Color.Black, false));
                graphics.AddDimensions(
                    new DimensionCube(BoundingBoxDim(Properties.Settings.Default.DimCasePalletSol2)
                    , Color.Red, true));
            }
            // flush
            graphics.Flush();
        }

        public void Draw(Graphics2D graphics)
        {
            if (null == _solution || _solution.Count == 0)
                return;

            bool showAxis = false;


        }

        BBox3D BoundingBoxDim(int index)
        {
            switch (index)
            {
                case 0: return _solution.BoundingBox;
                case 1: return _solution.LoadBoundingBox;
                case 2: return _analysis.PalletProperties.BoundingBox;
                case 3: return new BBox3D(0.0, 0.0, 0.0, _analysis.PalletProperties.Length, _analysis.PalletProperties.Width, 0.0);
                default: return _solution.BoundingBox;
            }
        }
        #endregion

        #region Public properties
        public bool ShowDimensions
        {
            get { return _showDimensions; }
            set { _showDimensions = value; }
        }
        #endregion
    }
}
