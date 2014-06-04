#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace treeDiM.StackBuilder.Plugin
{
    public class PalletINTEX
    {
        #region Constructors
        public PalletINTEX()
        { }
        public PalletINTEX(string name, double length, double width, double height)
        { _name = name; _length = length; _width = width; _height = height; }
        #endregion

        #region Public properties
        public bool IsValid
        {
            get { return !string.IsNullOrWhiteSpace(_name) && _length > 0.0 && _width > 0.0 && _height > 0.0; }
        }
        #endregion

        #region Build list
        public static List<PalletINTEX> BuildList()
        {
            List<PalletINTEX> list = new List<PalletINTEX>();
            list.Add(new PalletINTEX() { _name = "Palette 80 x 120 x 15", _length = 120, _width = 80, _height = 15 });
            list.Add(new PalletINTEX() { _name = "Palette 92 x 120 x 15", _length = 92, _width = 120, _height = 15 });
            list.Add(new PalletINTEX() { _name = "Palette 100 x 120 x 15", _length = 100, _width = 120, _height = 15 });
            list.Add(new PalletINTEX() { _name = "Demi-palette 80 x 120 x 15", _length = 80, _width = 60, _height = 15 });
            list.Add(new PalletINTEX() { _name = "Demi-palette 80 x 120 x 15", _length = 100, _width = 60, _height = 15 });
            list.Add(new PalletINTEX() { _name = "Demi-palette 50 x 120 x 15", _length = 120, _width = 50, _height = 15 });
            return list;
        }
        #endregion

        #region Object overrides
        public override string ToString()
        {
            return _name;
        }
        #endregion

        #region Data members
        public string _name;
        public double _length = 0.0, _width = 0.0, _height = 0.0;
        #endregion
    }
}
