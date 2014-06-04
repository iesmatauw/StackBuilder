using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace treeDiM.StackBuilder.Plugin
{
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


        public override string ToString()
        {
            return string.Format("{0} - {1}", _ref.PadRight(8), _description);
        }
    }
}
