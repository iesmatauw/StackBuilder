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
    public class TruckSolutionViewer
    {
        #region Data members
        private TruckSolution _truckSolution;
        private bool _showDetails = true;
        #endregion

        #region Constructor
        public TruckSolutionViewer(TruckSolution truckSolution)
        {
            _truckSolution = truckSolution;
        }
        #endregion

        #region Public properties
        public bool ShowDetails
        {
            get { return _showDetails; }
            set { _showDetails = value; }
        }
        #endregion

        #region Public methods
        public void Draw(Graphics3D graphics)
        {
            if (null == _truckSolution)
                throw new Exception("No trucksolution defined!");
            // draw truck
            Truck truck = new Truck(_truckSolution.ParentTruckAnalysis.TruckProperties);
            truck.Draw(graphics);

            // get pallet height
            Analysis analysis = _truckSolution.ParentTruckAnalysis.ParentAnalysis;
            double palletLength = _truckSolution.ParentTruckAnalysis.ParentSolution.PalletLength;
            double palletWidth = _truckSolution.ParentTruckAnalysis.ParentSolution.PalletWidth;
            double palletHeight = _truckSolution.ParentTruckAnalysis.ParentSolution.PalletHeight;

            // get parent pallet solution
            Solution sol = _truckSolution.ParentTruckAnalysis.ParentSolution;

            // draw solution
            uint pickIdGlobal = 0;
            for (int i = 0; i < _truckSolution.NoLayers; ++i)
            {
                foreach (BoxPosition bPositionLayer in _truckSolution.Layer)
                {
                    BoxPosition bPalletPosition = new BoxPosition(
                        new Vector3D(
                            bPositionLayer.Position.X
                            , bPositionLayer.Position.Y
                            , bPositionLayer.Position.Z + palletHeight * i)
                        , bPositionLayer.DirectionLength
                        , bPositionLayer.DirectionWidth);
                    if (_showDetails)
                    {
                        // build transformation
                        Transform3D transformPallet = bPalletPosition.Transformation;

                        // draw pallet
                        Pallet pallet = new Pallet(analysis.PalletProperties);
                        pallet.Draw(graphics, transformPallet);

                        // draw solution
                        uint pickId = 0;
                        foreach (ILayer layer in sol)
                        {
                            BoxLayer bLayer = layer as BoxLayer;
                            if (null != bLayer)
                            {
                                foreach (BoxPosition bPosition in bLayer)
                                    graphics.AddBox(new Box(pickId++, analysis.BProperties, BoxPosition.Transform(bPosition, transformPallet)));
                            }

                            InterlayerPos interlayerPos = layer as InterlayerPos;
                            if (null != interlayerPos)
                            {
                                BoxPosition iPos = new BoxPosition(new Vector3D(0.0, 0.0, interlayerPos.ZLow), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                                graphics.AddBox(new Box(pickId++, analysis.InterlayerProperties, BoxPosition.Transform(iPos, transformPallet)));
                            }
                        }
                    }
                    else
                    {
                        Box b = new Box(pickIdGlobal++, new BoxProperties(null, palletLength, palletWidth, palletHeight), bPalletPosition);
                        b.SetAllFacesColor(Color.Chocolate);
                        graphics.AddBox(b);
                    }
                }
            }

            // fluch
            graphics.UseBoxelOrderer = false; // can not use boxel orderer for full truck view -> too slow...
            graphics.Flush();
        }

        public void Draw(Graphics2D graphics)
        {
            if (null == _truckSolution)
                throw new Exception("No trucksolution defined!");

            // get analysis
            Analysis analysis = _truckSolution.ParentTruckAnalysis.ParentAnalysis;
            double length = _truckSolution.ParentTruckAnalysis.ParentSolution.PalletLength;
            double width = _truckSolution.ParentTruckAnalysis.ParentSolution.PalletWidth;
            double height = _truckSolution.ParentTruckAnalysis.ParentSolution.PalletHeight;

            // initialize Graphics2D object
            graphics.NumberOfViews = 1;
            graphics.SetViewport(
                0.0f, 0.0f
                , (float)_truckSolution.ParentTruckAnalysis.TruckProperties.Length
                , (float)_truckSolution.ParentTruckAnalysis.TruckProperties.Width);

            graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_truckSolution.ParentTruckAnalysis.TruckProperties.Length, _truckSolution.ParentTruckAnalysis.TruckProperties.Width), Color.Black);

            uint pickId = 0;
            foreach (BoxPosition bPositionLayer in _truckSolution.Layer)
            {
                Box b = new Box(pickId++, length, width, height);
                b.Position = bPositionLayer.Position;
                b.LengthAxis = HalfAxis.ToVector3D(bPositionLayer.DirectionLength);
                b.WidthAxis = HalfAxis.ToVector3D(bPositionLayer.DirectionWidth);
                graphics.DrawBox(b);
            }
        }
        #endregion
    }
}
