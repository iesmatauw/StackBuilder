#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class Graphics3DImage : Graphics3D
    {
        #region Data members
        Bitmap _bitmap;
        #endregion

        #region Constructor
        public Graphics3DImage(Size size)
        {
            _bitmap = new Bitmap(size.Width, size.Height);        
        }
        #endregion

        #region Graphics3D abstract method implementation
        public override Size Size
        {
            get { return _bitmap.Size;}
        }
        public override System.Drawing.Graphics Graphics
        {
            get { return System.Drawing.Graphics.FromImage(_bitmap); }
        }
        #endregion

        #region Public methods
        public void SaveAs(string filename)
        {
            ImageFormat format = ImageFormat.Bmp;
            _bitmap.Save(filename, format);
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
