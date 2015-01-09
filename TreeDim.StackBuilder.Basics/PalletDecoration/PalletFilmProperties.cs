#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class PalletFilmProperties : ItemBase
    {
        #region Data members
        public bool _useHatching, _useTransparency;
        public double _hatchSpacing;
        public Color _color; 
        #endregion

        #region Constructors
        public PalletFilmProperties(Document doc)
            : base(doc)
        { 
        }

        public PalletFilmProperties(Document doc,
            string name, string description,
            bool useTransparency,
            bool useHatching, double hatchSpacing,
            Color color)
            : base(doc, name, description)
        {
            _useTransparency = useTransparency;
            _useHatching = useHatching;
            _hatchSpacing = hatchSpacing;
            _color = color;
        }
        #endregion

        #region Public properties
        public bool UseTransparency
        {
            get { return _useTransparency; }
            set { _useTransparency = value; }
        }
        public bool UseHatching
        {
            get { return _useHatching; }
            set { _useHatching = value; }
        }
        public double HatchSpacing
        {
            get { return _hatchSpacing; }
            set { _hatchSpacing = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value;}
        }
        #endregion
    }
}
