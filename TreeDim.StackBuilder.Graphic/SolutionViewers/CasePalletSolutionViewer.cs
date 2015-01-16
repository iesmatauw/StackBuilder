#region Using directives
using System;
using System.Collections.Generic;
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
    public class CasePalletSolutionViewer
    {
        #region Data members
        private CasePalletSolution _solution;
        private CasePalletAnalysis _analysis;
        private bool _showDimensions = true;
        #endregion

        #region Constructor
        public CasePalletSolutionViewer(CasePalletSolution solution)
        {
            _analysis = null != solution ? solution.Analysis : null;
            _solution = solution;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Use this method when drawing a solution that belongs an analysis
        /// </summary>
        /// <param name="graphics"></param>
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
            // load bounding box
            BBox3D loadBBox = _solution.LoadBoundingBox; 
            BBox3D loadBBoxWDeco = _solution.LoadBoundingBoxWDeco;

            #region Pallet film : begin
            // draw film
            Film film = null;
            if (_solution.Analysis.HasPalletFilm)
            {
                PalletFilmProperties palletFilmProperties = _solution.Analysis.PalletFilmProperties;
                film = new Film(
                    palletFilmProperties.Color,
                    palletFilmProperties.UseTransparency,
                    palletFilmProperties.UseHatching,
                    palletFilmProperties.HatchSpacing,
                    palletFilmProperties.HatchAngle);
                film.AddRectangle(new FilmRectangle(loadBBoxWDeco.PtMin,
                    HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Z_P, new Vector2D(loadBBoxWDeco.Length, loadBBoxWDeco.Height), 0.0));
                film.AddRectangle(new FilmRectangle(loadBBoxWDeco.PtMin + loadBBoxWDeco.Length * Vector3D.XAxis,
                    HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_Z_P, new Vector2D(loadBBoxWDeco.Width, loadBBoxWDeco.Height), 0.0));
                film.AddRectangle(new FilmRectangle(loadBBoxWDeco.PtMin + loadBBoxWDeco.Length * Vector3D.XAxis + loadBBoxWDeco.Width * Vector3D.YAxis,
                    HalfAxis.HAxis.AXIS_X_N, HalfAxis.HAxis.AXIS_Z_P, new Vector2D(loadBBoxWDeco.Length, loadBBoxWDeco.Height), 0.0));
                film.AddRectangle(new FilmRectangle(loadBBoxWDeco.PtMin + loadBBoxWDeco.Width * Vector3D.YAxis,
                    HalfAxis.HAxis.AXIS_Y_N, HalfAxis.HAxis.AXIS_Z_P, new Vector2D(loadBBoxWDeco.Width, loadBBoxWDeco.Height), 0.0));
                film.AddRectangle(new FilmRectangle(loadBBoxWDeco.PtMin + loadBBoxWDeco.Height * Vector3D.ZAxis,
                    HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P, new Vector2D(loadBBoxWDeco.Length, loadBBoxWDeco.Width),
                    UnitsManager.ConvertLengthFrom(200.0, UnitsManager.UnitSystem.UNIT_METRIC1)));
                film.DrawBegin(graphics);
            }
            #endregion

            #region Pallet corners
            // *** pallet corners 
            // positions
            Vector3D[] cornerPositions =
            {
                loadBBox.PtMin
                , new Vector3D(loadBBox.PtMax.X, loadBBox.PtMin.Y, loadBBox.PtMin.Z)
                , new Vector3D(loadBBox.PtMax.X, loadBBox.PtMax.Y, loadBBox.PtMin.Z)
                , new Vector3D(loadBBox.PtMin.X, loadBBox.PtMax.Y, loadBBox.PtMin.Z)
            };
            // length axes
            HalfAxis.HAxis[] lAxes =
            {
                HalfAxis.HAxis.AXIS_X_P,
                HalfAxis.HAxis.AXIS_Y_P,
                HalfAxis.HAxis.AXIS_X_N,
                HalfAxis.HAxis.AXIS_Y_N
            };
            // width axes
            HalfAxis.HAxis[] wAxes =
            {
                HalfAxis.HAxis.AXIS_Y_P,
                HalfAxis.HAxis.AXIS_X_N,
                HalfAxis.HAxis.AXIS_Y_N,
                HalfAxis.HAxis.AXIS_X_P
            };
            // corners
            Corner[] corners = new Corner[4];
            if (_solution.Analysis.HasPalletCorners)
            {
                for (int i = 0; i < 4; ++i)
                {
                    corners[i] = new Corner(_solution.Analysis.PalletCornerProperties);
                    corners[i].Height = Math.Min(_solution.Analysis.PalletCornerProperties.Length, loadBBox.Height);
                    corners[i].SetPosition(cornerPositions[i], lAxes[i], wAxes[i]);
                    corners[i].DrawBegin(graphics);
                }
            }
            // *** pallet corners : end
            #endregion

            // draw solution
            uint pickId = 0;
            foreach (ILayer layer in _solution)
            {
                BoxLayer blayer = layer as BoxLayer;
                if (null != blayer)
                {
                    foreach (BoxPosition bPosition in blayer)
                        graphics.AddBox(new Box(pickId++, _analysis.BProperties, bPosition));
                }

                InterlayerPos interlayerPos = layer as InterlayerPos;
                if (null != interlayerPos)
                {
                    InterlayerProperties currInterlayerProperties = (0 == interlayerPos.TypeId)
                        ? _analysis.InterlayerProperties : _analysis.InterlayerPropertiesAntiSlip;
                    Box box = new Box(pickId++, currInterlayerProperties);
                    // set position
                    box.Position = new Vector3D(
                        0.5 * (_analysis.PalletProperties.Length - currInterlayerProperties.Length)
                        , 0.5 * (_analysis.PalletProperties.Width - currInterlayerProperties.Width)
                        , interlayerPos.ZLow);
                    // draw
                    graphics.AddBox(box);
                }
            }

            if (_showDimensions)
            {
                graphics.AddDimensions(
                    new DimensionCube(BoundingBoxDim(Properties.Settings.Default.DimCasePalletSol1)
                    , Color.Black, false));
                graphics.AddDimensions(
                    new DimensionCube(BoundingBoxDim(Properties.Settings.Default.DimCasePalletSol2)
                    , Color.Red, true));
            }

            // pallet corners
            if (_solution.Analysis.HasPalletCorners)
            {
                for (int i = 0; i < 4; ++i)
                    corners[i].DrawEnd(graphics);
            }
            // pallet cap
            if (_solution.Analysis.HasPalletCap)
            {
                PalletCapProperties capProperties = _solution.Analysis.PalletCapProperties;
                Vector3D pos = new Vector3D(
                    0.5 * (_analysis.PalletProperties.Length - capProperties.Length),
                    0.5 * (_analysis.PalletProperties.Width - capProperties.Width),
                    loadBBox.PtMax.Z - capProperties.InsideHeight);
                PalletCap cap = new PalletCap(0, capProperties, pos);
                cap.DrawEnd(graphics);
            }
            // pallet film
            if (_solution.Analysis.HasPalletFilm)
            {
                film.DrawEnd(graphics);
            }
            // flush
            graphics.EnableFaceSorting = false;
            graphics.Flush();
        }
        BBox3D BoundingBoxDim(int index)
        {
            switch (index)
            {
                case 0: return _solution.BoundingBoxWDeco;//_solution.BoundingBox;
                case 1: return _solution.LoadBoundingBoxWDeco;//_solution.LoadBoundingBox;
                case 2: return _analysis.PalletProperties.BoundingBox;
                case 3: return new BBox3D(0.0, 0.0, 0.0, _analysis.PalletProperties.Length, _analysis.PalletProperties.Width, 0.0);
                default: return _solution.BoundingBoxWDeco;
            }
        }
        /// <summary>
        ///  Use this method when solution does not refer an analysis (e.g. when displaying CaseOptimizer result)
        /// </summary>
        public static void Draw(Graphics3D graphics
            , CasePalletSolution solution
            , BoxProperties boxProperties, InterlayerProperties interlayerProperties, PalletProperties palletProperties)
        {
            // draw pallet
            Pallet pallet = new Pallet(palletProperties);
            pallet.Draw(graphics, Transform3D.Identity);
            // draw solution
            uint pickId = 0;
            foreach (ILayer layer in solution)
            {
                BoxLayer blayer = layer as BoxLayer;
                if (null != blayer)
                {
                    foreach (BoxPosition bPosition in blayer)
                        graphics.AddBox(new Box(pickId++, boxProperties, bPosition));
                }

                InterlayerPos interlayerPos = layer as InterlayerPos;
                if (null != interlayerPos && null != interlayerProperties)
                {
                    Box box = new Box(pickId++, interlayerProperties);
                    // set position
                    box.Position = new Vector3D(
                        0.5 * (palletProperties.Length - interlayerProperties.Length)
                        , 0.5 * (palletProperties.Width - interlayerProperties.Width)
                        , interlayerPos.ZLow);
                    // draw
                    graphics.AddBox(box);
                }
            }
 
            // always show dimensions
            BoxLayer bLayer = solution[solution.Count - 1] as BoxLayer;
            double palletHeight = solution[solution.Count - 1].ZLow + (null != bLayer ? bLayer.Thickness(boxProperties) : 0.0);

            // show dimensions
            graphics.AddDimensions(new DimensionCube(solution.BoundingBox, Color.Black, false));
            graphics.AddDimensions(new DimensionCube(solution.LoadBoundingBox, Color.Red, true));

            // flush
            graphics.Flush();
        }
        /// <summary>
        /// Draw a 2D representation of first (and second, if solution does not have homogeneous layers) layer(s)
        /// The images produced are used in 
        /// </summary>
        public void Draw(Graphics2D graphics)
        {
            if (null == _solution || _solution.Count == 0)
                return;

            bool showAxis = false;

            if (_solution.HasHomogeneousLayers)
            {
                // initialize Graphics2D object
                graphics.NumberOfViews = 1;
                graphics.SetViewport(0.0f, 0.0f, (float)_solution.PalletLength, (float)_solution.PalletWidth);

                BoxLayer blayer = _solution.CaseLayerFirst;
                if (blayer != null)
                {
                    graphics.SetCurrentView(0);
                    graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, _analysis.PalletProperties.Width), Color.Black);
                    uint pickId = 0;
                    foreach (BoxPosition bPosition in blayer)
                        graphics.DrawBox(new Box(pickId++, _analysis.BProperties, bPosition));

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
            else
            {
                graphics.NumberOfViews = 2;
                graphics.SetViewport(0.0f, 0.0f, (float)_analysis.PalletProperties.Length, (float)_analysis.PalletProperties.Width);

                // get first box layer
                if (_solution.CaseLayersCount < 1) return;
                BoxLayer blayer0 = _solution.CaseLayerFirst;
                if (blayer0 != null)
                {
                    graphics.SetCurrentView(0);
                    graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, _analysis.PalletProperties.Width), Color.Black);
                    uint pickId = 0;
                    foreach (BoxPosition bPosition in blayer0)
                        graphics.DrawBox(new Box(pickId++, _analysis.BProperties, bPosition));

                    // show axes
                    if (showAxis)
                    {
                        // draw axis X
                        graphics.DrawLine(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, 0.0), Color.Red);
                        // draw axis Y
                        graphics.DrawLine(Vector2D.Zero, new Vector2D(0.0, _analysis.PalletProperties.Width), Color.Green);
                    }
                }

                // get second box layer
                if (_solution.CaseLayersCount < 2) return;
                BoxLayer blayer1 = _solution.CaseLayerSecond;
                if (null == blayer1 && _solution.Count > 2)
                    blayer1 = _solution[2] as BoxLayer;
                if (blayer1 != null)
                {
                    graphics.SetCurrentView(1);
                    graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, _analysis.PalletProperties.Width), Color.Black);
                    uint pickId = 0;
                    foreach (BoxPosition bPosition in blayer1)
                        graphics.DrawBox(new Box(pickId++, _analysis.BProperties, bPosition));
                    // show axes
                    if (showAxis)
                    {
                        // draw axis X
                        graphics.DrawLine(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, 0.0), Color.Red);
                        // draw axis Y
                        graphics.DrawLine(Vector2D.Zero, new Vector2D(0.0, _analysis.PalletProperties.Width), Color.Green);
                    }
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
            int iLayer = 0, iLayerCount = 0;
            while (iLayerCount <= layerIndex && iLayer < _solution.Count)
            {
                ILayer layer = _solution[iLayer];
                BoxLayer blayer = layer as BoxLayer;
                if (null != blayer)
                {
                    foreach (BoxPosition bPosition in blayer)
                        graphics.AddBox(new Box(pickId++, _analysis.BProperties, bPosition));
                    ++iLayerCount;
                }
                ++iLayer;
            }
            // flush
            graphics.Flush();
        }
        #endregion

        #region Public properties
        public CasePalletSolution Solution
        {
            get { return _solution; }
            set { _solution = value; }
        }
        public bool ShowDimensions
        {
            get { return _showDimensions; }
            set { _showDimensions = value; }
        }
        #endregion
    }
}
