#region Data members
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public abstract class Graphics3D
    {
        #region Data members
        double _angleX = 0.0, _angleY = 0.0;
        /// <summary>
        /// Eye position
        /// </summary>
        Vector3D _vEye = new Vector3D(0.0, 0.0, -1000.0);
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
        /// Background color
        /// </summary>
        Color _backgroundColor = Color.White;
        /// <summary>
        /// face buffer used for drawing
        /// </summary>
        List<Face> _faces = new List<Face>();
        #endregion

        #region Constructors
        #endregion

        #region Public properties
        public double AngleX
        {
            get { return _angleX; }
            set { _angleX = value; }
        }
        public double AngleY
        {
            get { return _angleY; }
            set { _angleY = value; }
        }

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
        public Vector3D ViewPoint
        {
            get { return _vEye; }
            set { _vEye = value; }
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
            float w = (float)Size.Width;
            float h = (float)Size.Height;

            Point[] points = new Point[points3d.Length];
            int i = 0;
            foreach (Vector3D v in points3d)
            {
                Vector3D vt = transform.transform(v);
                points[i] = new Point(
                    (int)(((float)vt.X - _viewport[0]) * w / (_viewport[2] - _viewport[0]))
                    , (int)(((float)vt.Y - _viewport[1]) * h / (_viewport[3] - _viewport[1]))
                    );
                ++i;
            }
            return points;
        }

        private Transform3D BuildTransformation()
        {
            return Transform3D.Translation(-_vTarget)
                * Transform3D.RotationY(_angleY)
                * Transform3D.RotationX(_angleX)
                * Transform3D.Translation(_vEye);
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
        public void SetViewport(float xmin, float ymin, float xmax, float ymax)
        {
            _viewport[0] = xmin;
            _viewport[1] = ymin;
            _viewport[2] = xmax;
            _viewport[3] = ymax;
        }
        public void Draw()
        {
            Transform3D transform = BuildTransformation();

            System.Drawing.Graphics g = Graphics;
            g.Clear(_backgroundColor);

            // sort face list
            FaceComparison faceComparer = new FaceComparison(transform);
            _faces.Sort(faceComparer);

            foreach (Face face in _faces)
            {
                // compute face color
                double cosA = System.Math.Abs(Vector3D.DotProduct(face.Normal, _vLight));
                Color color = Color.FromArgb((int)(face.ColorFill.R * cosA), (int)(face.ColorFill.G * cosA), (int)(face.ColorFill.B * cosA));
                Point[] pt = TransformPoint(transform, face.Points);
                Console.WriteLine("--- Face ---");
                foreach (Point p in pt)
                    Console.WriteLine(p.ToString());

                Brush brush = new SolidBrush(color);
                g.FillPolygon(brush, pt);
                Brush brush0 = new SolidBrush(face.ColorPath);
                g.DrawPolygon(new Pen(brush0), pt);
            }
        }
        #endregion
    }
}
