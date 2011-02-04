#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    /// <summary>
    /// Custom draw list box inherits ListBox
    /// </summary>
    public partial class ListBoxImages : ListBox
    {
        #region Data members
        private Size _imageSize;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ListBoxImages()
        {
            InitializeComponent();
            _imageSize = new Size(80, 80);
        }
        #endregion

        #region ListBox override
        /// <summary>
        /// overrides ListBox.OnDrawItem
        /// </summary>
        /// <param name="e">event argument used to retrieve item by index</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // prevent Visual Designer errors
            if (this.Items.Count > 0)
            {
                ListBoxImagesItem item = (ListBoxImagesItem)this.Items[e.Index];
                item.drawItem(e, this.Margin, this._imageSize, e.Index == SelectedIndex);
            }
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            e.ItemHeight = 84;
            base.OnMeasureItem(e);
        }
        #endregion

        #region Texture item insertion methods
        /// <summary>
        /// add unique texture item
        /// </summary>
        /// <param name="texture"></param>
        public void AddTextureItem(Texture texture)
        { 
            this.Items.Add(new ListBoxImagesItem(texture));
        }
        /// <summary>
        ///  set whole list of textures
        /// </summary>
        /// <param name="textures"></param>
        public void SetTextureList(List<Texture> textures)
        { 
            this.Items.Clear();
            foreach (Texture texture in textures)
                this.Items.Add(new ListBoxImagesItem(texture));
        }
        #endregion
    }
    /// <summary>
    /// List box image item used to display images in ListBoxImagesItem
    /// </summary>
    public class ListBoxImagesItem
    {
        #region Data members
        Texture _texture;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ListBoxImagesItem(Texture texture)
        {
            _texture = texture;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Texture
        /// </summary>
        public Texture Texture
        {
            get { return _texture; }
        }
        #endregion

        #region Drawing
        /// <summary>
        /// item drawing method
        /// </summary>
        /// <param name="e"></param>
        /// <param name="margin"></param>
        /// <param name="imageSize"></param>
        public void drawItem(DrawItemEventArgs e, Padding margin, Size imageSize, bool selected)
        {
            // draw background
            e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            // draw some item separator
            e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.X, e.Bounds.Y, e.Bounds.X + e.Bounds.Width, e.Bounds.Y);
            // draw item image
            e.Graphics.DrawImage(this._texture.Bitmap, e.Bounds.X + margin.Left, e.Bounds.Y + margin.Top, imageSize.Width, imageSize.Height);
            // if selected draw blue rectangle
            if (selected)
            {
                Rectangle rect = e.Bounds;
                rect.Inflate(new Size(-2, -2));
                e.Graphics.DrawRectangle(new Pen(Color.Blue, 2.0f), e.Bounds);
            }
            // put some focus rectangle
            e.DrawFocusRectangle();
        }
        #endregion
    }
}
