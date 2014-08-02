#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace treeDiM.StackBuilder.Plugin
{
    #region DataItemINTEX
    public class DataItemINTEX
    {
        #region Data members
        public string _ref;
        public string _description;
        public string _UPC;
        public int _PCB;
        public string _gencode;
        public double _length, _width, _height;
        public double _weight;
        #endregion
        #region Object override
        public override string ToString()
        {
            return string.Format("{0} - {1}", _ref.PadRight(8), _description);
        }
        #endregion
    }
    #endregion

    #region DataPalletINTEX
    public class DataPalletINTEX
    {
        #region Data members
        public string _type;
        public double _length, _width, _height;
        public double _weight;
        #endregion
        #region Object override
        public override string ToString()
        {
            return string.Format("{0} - {1}*{2}", _type, _length, _width);
        }
        #endregion
    }
    #endregion

    #region DataCaseINTEX
    public class DataCaseINTEX
    {
        #region Data members
        public string _type;
        public double _lengthExt, _widthExt, _heightExt, _lengthInt, _widthInt, _heightInt;
        #endregion
        #region Object override
        public override string ToString()
        {
            return string.Format("{0} - {1}*{2}*{3}", _type, _lengthExt, _widthExt, _heightExt);
        }
        #endregion
    }
    #endregion
}
