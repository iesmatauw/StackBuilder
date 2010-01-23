#region Data members
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public abstract class Graphics3D
    {
        #region Data members
        /// <summary>
        /// Eye position
        /// </summary>
        Vector3D _vCameraPos = new Vector3D(0.0, 0.0, -1000.0);
        /// <summary>
        /// Light position
        /// </summary>
        Vector3D _vLight = new Vector3D(0.0, 0.0, -1.0);
        /// <summary>
        /// Target position
        /// </summary>
        Vector3D _vTarget = new Vector3D();
        /// <summary>
        /// Viewport
        /// </summary>
        float[] _viewport = new float[4];
        /// <summary>
        /// Compute viewport automatically if enabled
        /// </summary>
        bool _autoViewport = true;
        /// <summary>
        /// Margin coefficient
        /// </summary>
        double _margin = 0.01;
        /// <summary>
        /// Background color
        /// </summary>
        Color _backgroundColor = Color.White;
        /// <summary>
        /// entity (face) buffer used for drawing
        /// </summary>
        List<Face> _faces = new List<Face>();
        #endregion

        #region Constructors
        #endregion

        #region Public properties
        /// <summary>
        /// Background color
        /// </summary>
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        /// <summary>
        /// View point (position of the observer's eye
        /// </summary>
        public Vector3D CameraPosition
        {
            get { return _vCameraPos; }
            set { _vCameraPos = value; }
        }

        public Vector3D Target
        {
            get { return _vTarget; }
            set { _vTarget = value; }
        }

        public Vector3D LightDirection
        {
            get { return _vLight; }
            set
            {
                _vLight = value;
                _vLight.Normalize();
            }
        }
        #endregion
        
        #region Helpers
        private Point[] TransformPoint(Transform3D transform, Vector3D[] points3d)
        {
            Point[] points = new Point[points3d.Length];
            int i = 0;
            foreach (Vector3D v in points3d)
            {
                Vector3D vt = transform.transform(v);
                points[i] = new Point( (int)vt.X, (int)vt.Y);
                ++i;
            }
            return points;
        }

        private Transform3D GetWorldToEyeTransformation()
        {
            /*
            Orthographic transformation chain
            • Start with coordinates in object’s local coordinates
            • Transform into world coords (modeling transform, Mm)
            • Transform into eye coords (camera xf., Mcam = Fc–1)
            • Orthographic projection, Morth
            • Viewport transform, Mvp

            ps = Mvp*Morth*Mcam*Mm*po
            */
		    Vector3D zaxis = _vCameraPos-_vTarget;
            zaxis.Normalize();
            Vector3D up = Vector3D.ZAxis;
            if (Vector3D.CrossProduct(up, zaxis).GetLengthSquared() < 0.0001)
                up = Vector3D.ZAxis;
		    Vector3D xaxis = Vector3D.CrossProduct(up, zaxis);
		    xaxis.Normalize();
		    Vector3D yaxis = Vector3D.CrossProduct(zaxis,xaxis);
            Matrix4D Mcam = new Matrix4D(
                    xaxis.X, xaxis.Y, xaxis.Z, -Vector3D.DotProduct(_vCameraPos-_vTarget, xaxis),
                    yaxis.X, yaxis.Y, yaxis.Z, -Vector3D.DotProduct(_vCameraPos-_vTarget, yaxis),
                    -zaxis.X, -zaxis.Y, -zaxis.Z, -Vector3D.DotProduct(_vCameraPos-_vTarget, -zaxis),
                    0.0, 0.0, 0.0, 1.0
                );
            return new Transform3D(Mcam);
        }

        private Transform3D GetOrthographicProjection(Vector3D vecMin, Vector3D vecMax)
        {
            double[] sizeMin = new double[3];
            sizeMin[0] = 1.0;
            sizeMin[1] = Size.Height;
            sizeMin[2] = 0.0;

            double[] sizeMax = new double[3];
            sizeMax[0] = Size.Width;
            sizeMax[1] = 1.0;
            sizeMax[2] = 1.0;

            return Transform3D.OrthographicProjection(vecMin, vecMax, sizeMin, sizeMax);
        }

        public void AddFace(Face face)
        {
            Console.WriteLine(face.ToString() );
            _faces.Add(face);
        }
        #endregion

        #region Abstract methods
        abstract public Size Size { get; }
        abstract public System.Drawing.Graphics Graphics { get; }
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
            _viewport[0] = xmin;
            _viewport[1] = ymin;
            _viewport[2] = xmax;
            _viewport[3] = ymax;
        }

        /// <summary>
        /// Draw all entities stored in buffer
        /// </summary>
        public void Flush()
        {
            // get transformations
            Transform3D world2eye = GetWorldToEyeTransformation();
            Transform3D orthographicProj = GetOrthographicProjection(
                new Vector3D(_viewport[0], _viewport[1], -10000)
                , new Vector3D(_viewport[2], _viewport[3], 10000));

            // build automatic viewport
            if (_autoViewport)
            { 
                Vector3D vecMin = new Vector3D(double.MaxValue, double.MaxValue, double.MaxValue);
                Vector3D vecMax = new Vector3D(double.MinValue, double.MinValue, double.MinValue);

                foreach (Face face in _faces)
                    foreach (Vector3D pt in face.Points)
                    {
                        Vector3D ptT = world2eye.transform(pt);
                        vecMin.X = Math.Min(vecMin.X, ptT.X);
                        vecMin.Y = Math.Min(vecMin.Y, ptT.Y);
                        vecMin.Z = Math.Min(vecMin.Z, ptT.Z);
                        vecMax.X = Math.Max(vecMax.X, ptT.X);
                        vecMax.Y = Math.Max(vecMax.Y, ptT.Y);
                        vecMax.Z = Math.Max(vecMax.Z, ptT.Z);
                    }

                // adjust width/height
                if ((vecMax.Y - vecMin.Y) / Size.Height > (vecMax.X - vecMin.X) / Size.Width)
                {
                    double actualWidth = (vecMax.Y - vecMin.Y) * Size.Width / Size.Height;
                    vecMin.X = 0.5 * (vecMin.X + vecMax.X) - 0.5 * actualWidth;
                    vecMax.X = 0.5 * (vecMin.X + vecMax.X) + 0.5 * actualWidth;
                }
                else
                {
                    double actualHeight = (vecMax.X - vecMin.X) * Size.Height / Size.Width;
                    vecMin.Y = 0.5 * (vecMin.Y + vecMax.Y) - 0.5 * actualHeight;
                    vecMax.Y = 0.5 * (vecMin.Y + vecMax.Y) + 0.5 * actualHeight;
                }
                // set margins
                double width = vecMax.X - vecMin.X;
                vecMin.X -= _margin * width;
                vecMax.X += _margin * width;
                double height = vecMax.Y - vecMin.Y;
                vecMin.Y -= _margin * height;
                vecMax.Y += _margin * height;

                orthographicProj = GetOrthographicProjection( vecMin, vecMax);
            }

            System.Drawing.Graphics g = Graphics;
            g.Clear(_backgroundColor);

            // sort face list
            FaceComparison faceComparer = new FaceComparison(world2eye);
            _faces.Sort(faceComparer);

            foreach (Face face in _faces)
            {
                // compute face color
                double cosA = System.Math.Abs(Vector3D.DotProduct(face.Normal, _vLight));
                Color color = Color.FromArgb((int)(face.ColorFill.R * cosA), (int)(face.ColorFill.G * cosA), (int)(face.ColorFill.B * cosA));
                Point[] pt = TransformPoint(orthographicProj * world2eye, face.Points);
                Console.WriteLine("--- Face ---");
                foreach (Point p in pt)
                    Console.WriteLine(p.ToString());

                Brush brush = new SolidBrush(color);
                g.FillPolygon(brush, pt);
                Brush brush0 = new SolidBrush(face.ColorPath);
                g.DrawPolygon(new Pen(brush0), pt);
                if (face.HasBitmap)
                {
                    foreach (Texture texture in face.Textures)
                    {
                        Point[] ptsImage = TransformPoint(orthographicProj * world2eye, face.PointsImage(texture));
                        Point[] pts = new Point[3];
                        pts[0] = ptsImage[1];
                        pts[1] = ptsImage[0];
                        pts[2] = ptsImage[2];
                        g.DrawImage(texture.Bitmap, pts);
                    }
                }                
            }
        }
        #endregion
    }
}
