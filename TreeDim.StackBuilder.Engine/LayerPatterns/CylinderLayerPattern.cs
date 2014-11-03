#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    #region CylinderLayerPattern
    internal abstract class CylinderLayerPattern
    {
        #region Abstract methods
        abstract public string Name { get; }
        abstract public void GetLayerDimensions(LayerCyl layer, out double length, out double width); 
        abstract public void GenerateLayer(LayerCyl layer, double actualLength, double actualWidth);
        abstract public bool CanBeSwaped { get; }
        #endregion

        #region Public properties
        public bool Swaped
        {
            get { return _swaped; }
            set { _swaped = value; }
        }
        #endregion

        #region Private methods
        protected double GetPalletLength(LayerCyl layer)
        {
            if (!_swaped)
                return layer.PalletLength;
            else
                return layer.PalletWidth;
        }

        protected double GetPalletWidth(LayerCyl layer)
        {
            if (!_swaped)
                return layer.PalletWidth;
            else
                return layer.PalletLength;
        }

        public void AddPosition(LayerCyl layer, Vector2D vPosition)
        {
            Matrix4D matRot = Matrix4D.Identity;
            Vector3D vTranslation = Vector3D.Zero;

            if (_swaped)
            {
                matRot = new Matrix4D(
                    0.0, -1.0, 0.0, 0.0
                    , 1.0, 0.0, 0.0, 0.0
                    , 0.0, 0.0, 1.0, 0.0
                    , 0.0, 0.0, 0.0, 1.0
                    );
                vTranslation = new Vector3D(layer.PalletLength, 0.0, 0.0);
            }
            Transform3D transfRot = new Transform3D(matRot);

            matRot.M14 = vTranslation[0];
            matRot.M24 = vTranslation[1];
            matRot.M34 = vTranslation[2];

            Transform3D transfRotTranslation = new Transform3D(matRot);
            Vector3D vPositionSwapped = transfRotTranslation.transform(new Vector3D(vPosition.X, vPosition.Y, 0.0));

            if (!layer.IsValidPosition(new Vector2D(vPositionSwapped.X, vPositionSwapped.Y)))
            {
                _log.Warn(string.Format("Attempt to add an invalid position in pattern = {0}, Swaped = true", this.Name));
                return;
            }
            layer.Add(new Vector2D(vPositionSwapped.X, vPositionSwapped.Y));
        }
        #endregion

        #region Data members
        private bool _swaped = false;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(CylinderLayerPattern));
        #endregion
    }
    #endregion

    #region CylinderLayerPatternHorizontal
    internal abstract class CylinderLayerPatternHorizontal
    {
        #region Data members

        #endregion
    }
    #endregion
}
