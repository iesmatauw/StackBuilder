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
    public class CaseSolutionViewer
    {
        #region Data members
        private CaseSolution _caseSolution;
        private bool _showDimensions = true;
        #endregion

        #region Constructor
        public CaseSolutionViewer(CaseSolution caseSolution)
        {
            _caseSolution = caseSolution;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Draw case solution
        /// </summary>
        public void Draw(Graphics3D graphics)
        {
            if (null == _caseSolution)
                throw new Exception("No case solution defined!");

            // load pallet solution
            BoxProperties caseProperties;

            Solution palletSolution = _caseSolution.PalletSolutionDesc.LoadPalletSolution();
            if (null == palletSolution)
                caseProperties = new BoxProperties(null, _caseSolution.CaseLength, _caseSolution.CaseWidth, _caseSolution.CaseHeight);
            else
            {
                Analysis palletAnalysis = palletSolution.Analysis;
                // retrieve case properties 
                caseProperties = palletAnalysis.BProperties as BoxProperties;
            }
            if (null == caseProperties) return;
            Case case_ = new Case(caseProperties);
            case_.DrawBegin(graphics);

            // get case analysis
            CaseAnalysis caseAnalysis = _caseSolution.ParentCaseAnalysis;

            // draw solution
            uint pickId = 0;
            foreach (ILayer layer in _caseSolution)
            {
                BoxLayer blayer = layer as BoxLayer;
                if (null != blayer)
                {
                    foreach (BoxPosition bPosition in blayer)
                        graphics.AddBox(new Box(pickId++, caseAnalysis.BoxProperties, bPosition));
                }

                InterlayerPos interlayerPos = layer as InterlayerPos;
                if (null != interlayerPos)
                {
                    Box box = new Box(pickId++, caseAnalysis.InterlayerProperties);
                    // set position
                    box.Position = new Vector3D(0.0, 0.0, interlayerPos.ZLow);
                    // draw
                    graphics.AddBox(box);
                }
            }
            if (_showDimensions)
            {
                graphics.AddDimensions(new DimensionCube(_caseSolution.CaseLength, _caseSolution.CaseWidth, _caseSolution.CaseHeight));
            }
            // flush
            graphics.Flush();
        }
        /// <summary>
        /// Draw a 2D representation of first (and second, if solution does not have homogeneous layers) layer(s)
        /// </summary>
        public void Draw(Graphics2D graphics)
        {
            if (null == _caseSolution)
                throw new Exception("No case solution defined!");

            CaseAnalysis caseAnalysis = _caseSolution.ParentCaseAnalysis;

            if (_caseSolution.HasHomogeneousLayers)
            {
                graphics.NumberOfViews = 1;
                graphics.SetViewport(0.0f, 0.0f, (float)_caseSolution.CaseLength, (float)_caseSolution.CaseWidth);

                BoxLayer blayer = _caseSolution[0] as BoxLayer;
                if (blayer != null)
                {
                    graphics.SetCurrentView(0);
                    graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_caseSolution.CaseLength, _caseSolution.CaseWidth), Color.Black);
                    uint pickId = 0;
                    foreach (BoxPosition bPosition in blayer)
                        graphics.DrawBox(new Box(pickId++, caseAnalysis.BoxProperties, bPosition));
                }
            }
            else 
            {
                graphics.NumberOfViews = 2;
                graphics.SetViewport(0.0f, 0.0f, (float)_caseSolution.CaseLength, (float)_caseSolution.CaseWidth);

                // get first box layer
                if (_caseSolution.Count < 1) return;
                BoxLayer blayer0 = _caseSolution[0] as BoxLayer;
                if (blayer0 != null)
                {
                    graphics.SetCurrentView(0);
                    graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_caseSolution.CaseLength, _caseSolution.CaseWidth), Color.Black);
                    uint pickId = 0;
                    foreach (BoxPosition bPosition in blayer0)
                        graphics.DrawBox(new Box(pickId++, caseAnalysis.BoxProperties, bPosition));
                }

                // get second box layer
                if (_caseSolution.Count < 2) return;
                BoxLayer blayer1 = _caseSolution[1] as BoxLayer;
                if (null == blayer1 && _caseSolution.Count > 2)
                    blayer1 = _caseSolution[2] as BoxLayer;
                if (blayer1 != null)
                {
                    graphics.SetCurrentView(1);
                    graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_caseSolution.CaseLength, _caseSolution.CaseWidth), Color.Black);
                    uint pickId = 0;
                    foreach (BoxPosition bPosition in blayer1)
                        graphics.DrawBox(new Box(pickId++, caseAnalysis.BoxProperties, bPosition));
                }
            }
        }
        /// <summary>
        /// Draw layers
        /// Images are used during report generation
        /// </summary>
        public void DrawLayers(Graphics3D graphics, bool showPallet, int layerIndex)
        {
            if (null == _caseSolution)
                throw new Exception("No solution defined!");
            CaseAnalysis caseAnalysis = _caseSolution.ParentCaseAnalysis;

            // draw solution
            uint pickId = 0;
            int iLayer = 0, iLayerCount = 0;
            while (iLayerCount <= layerIndex && iLayer < _caseSolution.Count)
            {
                ILayer layer = _caseSolution[iLayer];
                BoxLayer blayer = layer as BoxLayer;
                if (null != blayer)
                {
                    foreach (BoxPosition bPosition in blayer)
                        graphics.AddBox(new Box(pickId++, caseAnalysis.BoxProperties, bPosition));
                    ++iLayerCount;
                }
                ++iLayer;
            }
            // flush
            graphics.Flush();
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
