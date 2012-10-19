#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using TreeDim.StackBuilder.Basics;

using Sharp3D.Math.Core;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    /// <summary>
    /// Layer pattern abstract class
    /// </summary>
    internal abstract class LayerPattern
    {
        #region Abstract methods
        abstract public string Name { get; }
        abstract public void GetLayerDimensions(Layer layer, out double actualLength, out double actualWidth);
        abstract public void GenerateLayer(Layer layer, double actualLength, double actualWidth);
        abstract public int GetNumberOfVariants(Layer layer);
        abstract public bool CanBeSwaped { get; }
        abstract public bool CanBeInverted { get; }
        #endregion

        #region Public properties
        public int VariantIndex
        {
            get { return _variantIndex; }
            set { _variantIndex = value; }
        }
        public bool Swaped
        {
            get { return _swaped; }
            set
            {
                _swaped = value;
                if (!CanBeSwaped && _swaped)
                    throw new EngineException(string.Format("Pattern {0} can not be swapped.", Name));
            }
        }
        #endregion

        #region Private methods
        protected double GetPalletLength(Layer layer)
        {
            if (!_swaped)
                return layer.PalletLength;
            else
                return layer.PalletWidth;
        }

        protected double GetPalletWidth(Layer layer)
        { 
            if (!_swaped)
                return layer.PalletWidth;
            else
                return layer.PalletLength;        
        }

        public void GetLayerDimensionsChecked(Layer layer, out double actualLength, out double actualWidth)
        {
            GetLayerDimensions(layer, out actualLength, out actualWidth);
            if (actualLength > GetPalletLength(layer))
                throw new EngineException(string.Format("Pattern name={0} : actualLength={1} > palletLength={2} ?"
                    , this.Name, actualLength, GetPalletLength(layer)));
            if (actualWidth > GetPalletWidth(layer))
                throw new EngineException(string.Format("Pattern name={0} : actualWidth={1} > palletWidth={2} ?"
                    , this.Name, actualWidth, GetPalletWidth(layer)));
        }

        public void AddPosition(Layer layer, Vector2D vPosition, HalfAxis.HAxis lengthAxis, HalfAxis.HAxis widthAxis)
        {
            Matrix4D matRot = Matrix4D.Identity;
            Vector3D vTranslation = Vector3D.Zero;

            if (_swaped && !layer.Inversed)
            {
                matRot = new Matrix4D(
                    0.0, -1.0, 0.0, 0.0
                    , 1.0, 0.0, 0.0, 0.0
                    , 0.0, 0.0, 1.0, 0.0
                    , 0.0, 0.0, 0.0, 1.0
                    );
                vTranslation = new Vector3D(layer.PalletLength, 0.0, 0.0);
            }
            else if (!_swaped && layer.Inversed)
            {
                matRot = new Matrix4D(
                    -1.0, 0.0, 0.0, 0.0
                    , 0.0, -1.0, 0.0, 0.0
                    , 0.0, 0.0, 1.0, 0.0
                    , 0.0, 0.0, 0.0, 1.0
                    );
                vTranslation = new Vector3D(layer.PalletLength, layer.PalletWidth, 0.0);
            }
            else if (_swaped && layer.Inversed)
            {
                matRot = new Matrix4D(
                    0.0, 1.0, 0.0, 0.0
                    , -1.0, 0.0, 0.0, 0.0
                    , 0.0, 0.0, 1.0, 0.0
                    , 0.0, 0.0, 0.0, 1.0
                    );
                vTranslation = new Vector3D(0.0, layer.PalletWidth, 0.0);
            }
            Transform3D transfRot = new Transform3D(matRot);
            HalfAxis.HAxis lengthAxisSwaped = StackBuilder.Basics.HalfAxis.ToHalfAxis(transfRot.transform(StackBuilder.Basics.HalfAxis.ToVector3D(lengthAxis)));
            HalfAxis.HAxis widthAxisSwaped = StackBuilder.Basics.HalfAxis.ToHalfAxis(transfRot.transform(StackBuilder.Basics.HalfAxis.ToVector3D(widthAxis)));

            matRot.M14 = vTranslation[0];
            matRot.M24 = vTranslation[1];
            matRot.M34 = vTranslation[2];

            Transform3D transfRotTranslation = new Transform3D(matRot);
            Vector3D vPositionSwapped = transfRotTranslation.transform(new Vector3D(vPosition.X, vPosition.Y, 0.0));

            if (!layer.IsValidPosition(new Vector2D(vPositionSwapped.X, vPositionSwapped.Y), lengthAxisSwaped, widthAxisSwaped))
            {
                _log.Warn(string.Format("Attempt to add an invalid position in pattern = {0}, Variant = {1}, Swaped = true", this.Name, _variantIndex));
                return;
            }
            layer.AddPosition(new Vector2D(vPositionSwapped.X, vPositionSwapped.Y), lengthAxisSwaped, widthAxisSwaped);
        }
        #endregion

        #region Data members
        private int _variantIndex = 0;
        private bool _swaped = false;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(LayerPattern));
        #endregion
    }
}
