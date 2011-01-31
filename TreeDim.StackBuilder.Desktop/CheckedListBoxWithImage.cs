#region Using directives
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    /// <summary>
    /// Custom draw list box inherits ListBox and shows images
    /// </summary>
    public partial class CheckedListBoxWithImage : ListBox
    {
        #region Data members
        private Size _imageSize;
        private StringFormat _fmt;
        private Font _titleFont;
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public CheckedListBoxWithImage()
        {
            InitializeComponent();
            _imageSize = new Size(80, 60);
            ItemHeight = _imageSize.Height + this.Margin.Vertical;
            _fmt = new StringFormat();
            _fmt.Alignment = StringAlignment.Near;
            _fmt.LineAlignment = StringAlignment.Near;
            _titleFont = new Font(this.Font, FontStyle.Regular);
        }
        /// <summary>
        /// Constructor with defining parameters
        /// </summary>
        /// <param name="titleFont"></param>
        /// <param name="imageSize"></param>
        /// <param name="aligment"></param>
        /// <param name="lineAligment"></param>
        public CheckedListBoxWithImage(Font titleFont, Size imageSize,
                         StringAlignment aligment, StringAlignment lineAligment)
        {
            _imageSize = imageSize;
            _fmt = new StringFormat();
            _fmt.Alignment = aligment;
            _fmt.LineAlignment = lineAligment;
            this.ItemHeight = _imageSize.Height + this.Margin.Vertical;
            _fmt.Alignment = aligment;
            _fmt.LineAlignment = lineAligment;
            _titleFont = titleFont;
        }
        #endregion

        #region ListBox override
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // prevent from error Visual Designer
            if (this.Items.Count > 0)
            {
                ListBoxItemWithImage item = (ListBoxItemWithImage)this.Items[e.Index];
                item.drawItem(e, this.Margin, _titleFont, _fmt, this._imageSize);
            }
        }
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
        }
        #endregion
    }

    public class ListBoxItemWithImage
    {
        #region Data members
        private string _title;
        private Image _itemImage;
        private CheckState _checkState;
        #endregion

        #region Constructor
        public ListBoxItemWithImage(string title, Image image, CheckState checkState)
        {
            _title = title;
            _itemImage = image;
            _checkState = checkState;
        }
        #endregion

        #region Public properties
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Image ItemImage
        {
            get { return _itemImage; }
            set { _itemImage = value; }
        }
        public CheckState CheckState
        {
            get { return _checkState; }
            set { _checkState = value; }
        }
        #endregion

        #region Drawing
        /// <summary>
        /// item drawing method
        /// </summary>
        /// <param name="e"></param>
        /// <param name="margin"></param>
        /// <param name="titleFont"></param>
        /// <param name="alignment"></param>
        /// <param name="imageSize"></param>
        public void drawItem(DrawItemEventArgs e, Padding margin
            , Font titleFont, StringFormat alignment
            , Size imageSize)
        {
            // draw background
            e.Graphics.FillRectangle(Brushes.Beige, e.Bounds);
            // draw some item separator
            e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.X, e.Bounds.Y, e.Bounds.X + e.Bounds.Width, e.Bounds.Y);
            // draw item image
            e.Graphics.DrawImage(this.ItemImage, e.Bounds.X + margin.Left, e.Bounds.Y + margin.Top, imageSize.Width, imageSize.Height);
            // calculate bounds for title text drawing
            Rectangle titleBounds = new Rectangle(e.Bounds.X + margin.Horizontal + imageSize.Width
                , e.Bounds.Y + (int)titleFont.GetHeight() + 2 + margin.Vertical + margin.Top
                , e.Bounds.Width - margin.Right - imageSize.Width - margin.Horizontal
                , (int) titleFont.GetHeight() + 2);
            // draw the text within the bounds
            e.Graphics.DrawString(this.Title, titleFont, Brushes.Black, titleBounds, alignment);
            // put some focus rectangle
            e.DrawFocusRectangle();
        }
        #endregion
    }
}
