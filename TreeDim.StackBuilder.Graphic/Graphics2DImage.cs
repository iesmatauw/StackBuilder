#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class Graphics2DImage : Graphics2D
    {
        #region Data members
        private Bitmap _bitmap;
        #endregion

        #region Constructor
        public Graphics2DImage(Size size)
        {
            _bitmap = new Bitmap(size.Width, size.Height);
        }
        #endregion

        #region Graphics2D abstract method implementation
        public override Size Size
        {
            get { return _bitmap.Size; }
        }
        public override System.Drawing.Graphics Graphics
        {
            get { return System.Drawing.Graphics.FromImage(_bitmap); }
        }
        #endregion

        #region Public methods
        public void SaveAs(string filename)
        {
            _bitmap.Save(filename, ImageFormat.Bmp);
        }
        #endregion

        #region Public properties
        public Bitmap Bitmap
        {
            get { return _bitmap; }
        }
        #endregion
    }
}
