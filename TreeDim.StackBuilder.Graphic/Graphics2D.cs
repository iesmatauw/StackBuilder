#region Data members
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public abstract class Graphics2D
    {
        #region Data members
        /// <summary>
        /// Viewport
        /// </summary>
        private float[] _viewport = new float[4];
        private uint _numberOfViews = 1;
        private uint _iIndexView = 0;
        #endregion

        #region Abstract methods and properties
        abstract public System.Drawing.Graphics Graphics { get; }
        abstract public System.Drawing.Size Size { get; }
        #endregion

        #region Public methods
        /// <summary>
        /// SetViewport
        /// </summary>
        /// <param name="xmin">xmin -> bottom</param>
        /// <param name="ymin">ymin -> left</param>
        /// <param name="xmax">xmax -> right</param>
        /// <param name="ymax">ymax -> top</param>
        public void SetViewport(float xmin, float ymin, float xmax, float ymax)
        {
            float aspectRatio = (float)Size.Width / ((float)Size.Height * _numberOfViews);
            float viewportRatio = (xmax-xmin)/(ymax-ymin);

            if (viewportRatio > aspectRatio)
            {   // pallet length
                float margin = 0.1f * (xmax-xmin) / _numberOfViews;
                _viewport[0] = -margin;
                _viewport[1] = -margin / aspectRatio;
                _viewport[2] = (xmax-xmin)/_numberOfViews + margin;
                _viewport[3] = ((xmax-xmin)/_numberOfViews + margin) / aspectRatio;
            }
            else
            {   // pallet width
                float margin = 0.1f * (xmax - xmin) / _numberOfViews;
                _viewport[0] = -margin * aspectRatio;
                _viewport[1] = -margin;
                _viewport[2] = (ymax - ymin + margin)*aspectRatio;
                _viewport[3] = ymax - ymin + margin;
            }
            
            _viewport[0] = xmin;
            _viewport[1] = ymin;
            _viewport[2] = xmax;
            _viewport[3] = ymax;
        }

        public void DrawBox(Box box)
        {
            System.Drawing.Graphics g = Graphics;

            // get points
            Point[] pt = TransformPoint( box.TopFace.Points);

            // draw solid face
            Brush brushSolid = new SolidBrush(box.TopFace.ColorFill);
            g.FillPolygon(brushSolid, pt);
            Brush brushPath = new SolidBrush(box.TopFace.ColorPath);
            Pen penPath = new Pen(brushPath);
            g.DrawPolygon(penPath, pt);
        }

        public void DrawCylinder(Cylinder cyl)
        {
            System.Drawing.Graphics g = Graphics;

            // get points
            Point[] pt = TransformPoint(cyl.TopPoints);
            // bottom (draw only path)
            Brush brushSolid = new SolidBrush(cyl.ColorTop);
            g.FillPolygon(brushSolid, pt);
            Brush brushPath = new SolidBrush(cyl.ColorPath);
            Pen penPath = new Pen(brushPath);
            g.DrawPolygon(penPath, pt);
        }

        public void DrawRectangle(Vector2D vMin, Vector2D vMax, Color penColor)
        {
            Point[] pt = TransformPoint(new Vector2D[] { vMin, vMax });
            System.Drawing.Graphics g = Graphics;
            Pen penRect = new Pen(penColor);
            g.DrawRectangle(penRect, pt[0].X, pt[0].Y, pt[1].X-pt[0].X, pt[1].Y-pt[0].Y);
        }
        public void DrawLine(Vector2D v1, Vector2D v2, Color penColor)
        {
            Point[] pt = TransformPoint(new Vector2D[] { v1, v2 });
            System.Drawing.Graphics g = Graphics;
            Pen pen = new Pen(penColor);
            g.DrawLines(pen, pt);
        }

        public uint NumberOfViews
        {
            get { return _numberOfViews; }
            set { _numberOfViews = value; }
        }

        public void SetCurrentView(uint iIndexView)
        {
            _iIndexView = iIndexView;
        }
        #endregion

        #region Helpers
        private Point[] TransformPoint(Vector2D[] points2d)
        {
            float aspectRatio = (float)Size.Width / ((float)Size.Height * _numberOfViews);
            float viewportRatio = (_viewport[2] - _viewport[0]) / (_viewport[3] - _viewport[1]);
            float margin = 0.1f * (_viewport[2] - _viewport[0]);

            Point[] points = new Point[points2d.Length];
            int i = 0;
            foreach (Vector2D v in points2d)
            {
                if (viewportRatio > aspectRatio)
                {
                    points[i].X = (int)
                        (
                        (float)(Size.Width / _numberOfViews)
                        * (_iIndexView + (v.X - _viewport[0] + margin)/(_viewport[2] - _viewport[0] + 2.0f * margin))
                        );
                    points[i].Y = (int)
                        (
                        Size.Height * aspectRatio / viewportRatio * (1.0f - (_viewport[3] - v.Y + margin) / (_viewport[3] - _viewport[1] + 2.0f * margin))
                        );
                }
                else
                {
                    points[i].X = (int)
                        (
                        (float)(Size.Width / _numberOfViews)
                        * (_iIndexView + (viewportRatio / aspectRatio) * (v.X - _viewport[0] + margin) / (_viewport[2] - _viewport[0] + 2.0f * margin))
                        );
                    points[i].Y = (int)
                        (
                        Size.Height * (v.Y - _viewport[1] + margin) / (_viewport[3] - _viewport[1] + 2.0f * margin)
                        );
                }
                ++i;
            }
            return points;
        }

        private Point[] TransformPoint(Vector3D[] points3d)
        {
            float aspectRatio = (float)Size.Width / ((float)Size.Height * _numberOfViews);
            float viewportRatio = (_viewport[2] - _viewport[0]) / (_viewport[3] - _viewport[1]);
            float margin = 0.1f * (_viewport[2] - _viewport[0]);

            Point[] points = new Point[points3d.Length];
            int i=0;
            foreach (Vector3D v in points3d)
            {
                if (viewportRatio > aspectRatio)
                {
                    points[i].X = (int)
                        (
                        (float)(Size.Width / _numberOfViews)
                        * (_iIndexView + (v.X - _viewport[0] + margin) / (_viewport[2] - _viewport[0] + 2.0f * margin))
                        );
                    points[i].Y = (int)
                        (
                        Size.Height * aspectRatio / viewportRatio * (v.Y - _viewport[1] + margin) / (_viewport[3] - _viewport[1] + 2.0f * margin)
                        );
                }
                else
                {
                    points[i].X = (int)
                        (
                        (float)(Size.Width / _numberOfViews)
                        * (_iIndexView + (viewportRatio / aspectRatio) * (v.X - _viewport[0] + margin) / (_viewport[2] - _viewport[0] + 2.0f * margin))
                        );
                    points[i].Y = (int)
                        (
                        Size.Height * (v.Y - _viewport[1] + margin) / (_viewport[3] - _viewport[1] + 2.0f * margin)
                        );
                }
                ++i;
            }
            return points;
        }
        #endregion
    }
}
