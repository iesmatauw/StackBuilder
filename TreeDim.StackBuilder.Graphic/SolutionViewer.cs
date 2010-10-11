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
                throw new Exception("No solution defined!");
            // initialize Graphics3D object
            if (!graphics.ShowBoxIds)
            {
                // draw pallet
                Pallet pallet = new Pallet(_analysis.PalletProperties);
                pallet.Draw(graphics);
            }
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
                    Box box = new Box(pickId++, _analysis.InterlayerProperties);
                    // set position
                    box.Position = new Vector3D(0.0, 0.0, interlayerPos.ZLow);
                    // draw
                    graphics.AddBox(box);
                }
            }
            bool showAxes = false;
            if (showAxes)
            {
                // draw axis
                graphics.AddSegment(new Segment(Vector3D.Zero, new Vector3D(2000.0, 0.0, 0.0), Color.Red));
                graphics.AddSegment(new Segment(Vector3D.Zero, new Vector3D(0.0, 2000.0, 0.0), Color.Green));
                graphics.AddSegment(new Segment(Vector3D.Zero, new Vector3D(0.0, 0.0, 2000.0), Color.Blue));
            }

            // flush
            graphics.Flush();
        }

        public void Draw(Graphics2D graphics)
        {
            if (null == _solution || _solution.Count == 0)
                return;

            if (_solution.HasHomogeneousLayers)
            {
                // initialize Graphics2D object
                graphics.NumberOfViews = 1;
                graphics.SetViewport(0.0f, 0.0f, (float)_analysis.PalletProperties.Length, (float)_analysis.PalletProperties.Width);

                BoxLayer blayer = _solution[0] as BoxLayer;
                if (blayer != null)
                {
                    graphics.SetCurrentView(0);
                    graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, _analysis.PalletProperties.Width), Color.Black);
                    uint pickId = 0;
                    foreach (BoxPosition bPosition in blayer)
                        graphics.DrawBox(new Box(pickId++, _analysis.BProperties, bPosition));
                    // draw axis X
                    graphics.DrawLine(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, 0.0), Color.Red);
                    // draw axis Y
                    graphics.DrawLine(Vector2D.Zero, new Vector2D(0.0, _analysis.PalletProperties.Width), Color.Green);
                }
            }
            else
            {
                graphics.NumberOfViews = 2;
                graphics.SetViewport(0.0f, 0.0f, (float)_analysis.PalletProperties.Length, (float)_analysis.PalletProperties.Width);

                // get first box layer
                if (_solution.Count < 1) return;
                BoxLayer blayer0 = _solution[0] as BoxLayer;
                if (blayer0 != null)
                {
                    graphics.SetCurrentView(0);
                    graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, _analysis.PalletProperties.Width), Color.Black);
                    uint pickId = 0;
                    foreach (BoxPosition bPosition in blayer0)
                        graphics.DrawBox(new Box(pickId++, _analysis.BProperties, bPosition));
                    // draw axis X
                    graphics.DrawLine(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, 0.0), Color.Red);
                    // draw axis Y
                    graphics.DrawLine(Vector2D.Zero, new Vector2D(0.0, _analysis.PalletProperties.Width), Color.Green);
                }

                // get second box layer
                if (_solution.Count < 2) return;
                BoxLayer blayer1 = _solution[1] as BoxLayer;
                if (null == blayer1 && _solution.Count > 2)
                    blayer1 = _solution[2] as BoxLayer;
                if (blayer1 != null)
                {
                    graphics.SetCurrentView(1);
                    graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, _analysis.PalletProperties.Width), Color.Black);
                    uint pickId = 0;
                    foreach (BoxPosition bPosition in blayer1)
                        graphics.DrawBox(new Box(pickId++, _analysis.BProperties, bPosition));
                    // draw axis X
                    graphics.DrawLine(Vector2D.Zero, new Vector2D(_analysis.PalletProperties.Length, 0.0), Color.Red);
                    // draw axis Y
                    graphics.DrawLine(Vector2D.Zero, new Vector2D(0.0, _analysis.PalletProperties.Width), Color.Green);
                }
            }
        }

        public void DrawLayers(Graphics3D graphics, bool showPallet, int layerIndex)
        {
             if (null == _solution)
                throw new Exception("No solution defined!");

            // initialize Graphics3D object
             if (!graphics.ShowBoxIds)
             {
                 // draw pallet
                 Pallet pallet = new Pallet(_analysis.PalletProperties);
                 pallet.Draw(graphics);
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
        public Solution Solution
        {
            get { return _solution; }
            set { _solution = value; }
        }
        #endregion
    }
}
