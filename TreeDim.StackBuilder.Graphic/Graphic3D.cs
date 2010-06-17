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
        #region Enums
        enum PaintingAlgorithm
        { 
            ALGO_PAINTER,
            ALGO_BSPTREE
        }
        #endregion

        #region Data members
        /// <summary>
        /// Eye position
        /// </summary>
        private Vector3D _vCameraPos = new Vector3D(0.0, 0.0, -1000.0);
        /// <summary>
        /// Light position
        /// </summary>
        private Vector3D _vLight = new Vector3D(0.0, 0.0, -1.0);
        /// <summary>
        /// Target position
        /// </summary>
        private Vector3D _vTarget = new Vector3D();
        /// <summary>
        /// Viewport
        /// </summary>
        private float[] _viewport = new float[4];
        /// <summary>
        /// Compute viewport automatically if enabled
        /// </summary>
        private bool _autoViewport = true;
        /// <summary>
        /// Margin coefficient
        /// </summary>
        private double _margin = 0.01;
        /// <summary>
        /// Background color
        /// </summary>
        private Color _backgroundColor = Color.White;
        /// <summary>
        /// face buffer used for drawing
        /// </summary>
        private List<Face> _faces = new List<Face>();
        /// <summay>
        /// box buffer used for drawing
        /// </summay>
        private List<Box> _boxes = new List<Box>();
        /// <summary>
        /// segment
        /// </summary>
        private List<Segment> _segments = new List<Segment>();
        /// <summary>
        /// Current transformation
        /// </summary>
        private Transform3D _currentTransf;
        private PaintingAlgorithm _algo = PaintingAlgorithm.ALGO_PAINTER;
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
        /// <summary>
        /// add face
        /// </summary>
        /// <param name="face">Face item</param>
        public void AddFace(Face face)
        {
            _faces.Add(face);
        }

        public void AddBox(Box box)
        {
            _boxes.Add(box);
        }
        #endregion

        #region Abstract methods and properties
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
            // initialize
            _currentTransf = null;
            System.Drawing.Graphics g = Graphics;
            g.Clear(_backgroundColor);

            if (PaintingAlgorithm.ALGO_PAINTER == _algo)
            {
                // sort face list
                FaceComparison faceComparer = new FaceComparison(GetWorldToEyeTransformation());
                _faces.Sort(faceComparer);
                // draw all faces
                foreach (Face face in _faces)
                    Draw(face);

                // sort box list
                BoxComparison boxComparer = new BoxComparison(GetWorldToEyeTransformation());
                _boxes.Sort(boxComparer);
                // draw all boxes
                foreach (Box box in _boxes)
                    Draw(box);

                // sort segment list
                foreach (Segment seg in _segments)
                    Draw(seg);
            }
            else
            {
                // build BSP tree
                BSPTree tree = new BSPTree();
                foreach (Face face in _faces)
                    tree.insert(face);
                // draw
                tree.draw(_vCameraPos - _vTarget, this);
            }
        }

        private Transform3D GetCurrentTransformation()
        {
            if (null == _currentTransf)
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

                    foreach (Box box in _boxes)
                        foreach (Vector3D pt in box.Points)
                        {
                            Vector3D ptT = world2eye.transform(pt);
                            vecMin.X = Math.Min(vecMin.X, ptT.X);
                            vecMin.Y = Math.Min(vecMin.Y, ptT.Y);
                            vecMin.Z = Math.Min(vecMin.Z, ptT.Z);
                            vecMax.X = Math.Max(vecMax.X, ptT.X);
                            vecMax.Y = Math.Max(vecMax.Y, ptT.Y);
                            vecMax.Z = Math.Max(vecMax.Z, ptT.Z);
                        }

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
                    Vector3D vecMin1 = vecMin, vecMax1 = vecMax;
                    // adjust width/height
                    if ((vecMax.Y - vecMin.Y) / Size.Height > (vecMax.X - vecMin.X) / Size.Width)
                    {
                        double actualWidth = (vecMax.Y - vecMin.Y) * Size.Width / Size.Height;
                        vecMin1.X = 0.5 * (vecMin.X + vecMax.X) - 0.5 * actualWidth;
                        vecMax1.X = 0.5 * (vecMin.X + vecMax.X) + 0.5 * actualWidth;
                    }
                    else
                    {
                        double actualHeight = (vecMax.X - vecMin.X) * Size.Height / Size.Width;
                        vecMin1.Y = 0.5 * (vecMin.Y + vecMax.Y) - 0.5 * actualHeight;
                        vecMax1.Y = 0.5 * (vecMin.Y + vecMax.Y) + 0.5 * actualHeight;
                    }
                    // set margins
                    double width = vecMax1.X - vecMin1.X;
                    vecMin1.X -= _margin * width;
                    vecMax1.X += _margin * width;
                    double height = vecMax1.Y - vecMin1.Y;
                    vecMin1.Y -= _margin * height;
                    vecMax1.Y += _margin * height;

                    orthographicProj = GetOrthographicProjection(vecMin1, vecMax1);
                }
                _currentTransf = orthographicProj * world2eye;
            }
            return _currentTransf;
        }

        public void AddSegment(Segment seg)
        {
            _segments.Add(seg);        
        }

        /// <summary>
        /// Draw a line segment
        /// </summary>
        /// <param name="seg">Segment object to be drawn</param>
        internal void Draw(Segment seg)
        {
            System.Drawing.Graphics g = Graphics;
            Brush brush = new SolidBrush(seg.Color);
            Pen pen = new Pen(brush);
            Point[] pt = TransformPoint(GetCurrentTransformation(), seg.Points);
            g.DrawLine(pen, pt[0], pt[1]);
        }

        /// <summary>
        /// Draw a face
        /// </summary>
        /// <param name="face">Face object to be drawn</param>
        internal void Draw(Face face)
        {
            System.Drawing.Graphics g = Graphics;

            // compute face color
            double cosA = System.Math.Abs(Vector3D.DotProduct(face.Normal, _vLight));
            Color color = Color.FromArgb((int)(face.ColorFill.R * cosA), (int)(face.ColorFill.G * cosA), (int)(face.ColorFill.B * cosA));
            Point[] pt = TransformPoint(GetCurrentTransformation(), face.Points);

            Brush brush = new SolidBrush(color);
            g.FillPolygon(brush, pt);
            // draw path
            Brush brush0 = new SolidBrush(face.ColorPath);
            int ptCount = pt.Length;
            for (int i = 1; i < ptCount; ++i)
            {
                // there is a bug here!
                // -> a polygon that result from first split will lose all edges
                // when split a second time
                if (!(face._isIntersection[i - 1] && face._isIntersection[i]))
                    g.DrawLine(new Pen(brush0, 1.5f), pt[i - 1], pt[i]);
            }
            if (!(face._isIntersection[ptCount - 1] && face._isIntersection[0]))
                g.DrawLine(new Pen(brush0, 1.5f), pt[ptCount - 1], pt[0]);

            if (face.HasBitmap)
            {
                foreach (Texture texture in face.Textures)
                {
                    Point[] ptsImage = TransformPoint(GetCurrentTransformation(), face.PointsImage(texture));
                    Point[] pts = new Point[3];
                    pts[0] = ptsImage[1];
                    pts[1] = ptsImage[0];
                    pts[2] = ptsImage[2];
                    g.DrawImage(texture.Bitmap, pts);
                }
            }
        }

        internal void Draw(Box box)
        {
            System.Drawing.Graphics g = Graphics;

            Vector3D[] points = box.Points;

            Face[] faces = new Face[6];
            faces[0] = new Face(0, new Vector3D[] { points[3], points[0], points[4], points[7] }); // AXIS_X_N
            faces[1] = new Face(0, new Vector3D[] { points[1], points[2], points[6], points[5] }); // AXIS_X_P
            faces[2] = new Face(0, new Vector3D[] { points[0], points[1], points[5], points[4] }); // AXIS_Y_N
            faces[3] = new Face(0, new Vector3D[] { points[2], points[3], points[7], points[6] }); // AXIS_Y_P
            faces[4] = new Face(0, new Vector3D[] { points[3], points[2], points[1], points[0] }); // AXIS_Z_N
            faces[5] = new Face(0, new Vector3D[] { points[4], points[5], points[6], points[7] }); // AXIS_Z_P

            for (int i=0; i<6; ++i)
            {
                // face normal
                Vector3D normal = faces[i].Normal;
                // visible ?
                if (Vector3D.DotProduct(_vCameraPos - _vTarget, normal) > 0.0)
                    continue;
                // color
                faces[i].ColorFill = box.Colors[i];
                double cosA = System.Math.Abs(Vector3D.DotProduct(faces[i].Normal, _vLight));
                Color color = Color.FromArgb((int)(faces[i].ColorFill.R * cosA), (int)(faces[i].ColorFill.G * cosA), (int)(faces[i].ColorFill.B * cosA));
                // points
                Vector3D[] points3D = faces[i].Points;
                Point[] pt = TransformPoint(GetCurrentTransformation(), points3D);
                //  draw solid face
                Brush brush = new SolidBrush(color);
                g.FillPolygon(brush, pt);
                // draw path
                Brush brushPath = new SolidBrush(faces[i].ColorPath);
                Pen penPath = new Pen(brushPath, 1.5f);
                int ptCount = pt.Length;
                for (int j = 1; j < ptCount; ++j)
                    g.DrawLine(penPath, pt[j - 1], pt[j]);
                g.DrawLine(penPath, pt[ptCount - 1], pt[0]);
                // draw bundle lines
                if (box.IsBundle && i<4)
                {
                    int noSlice = box.BundleFlats;
                    for (int iSlice = 0; iSlice < noSlice - 1; ++iSlice)
                    {
                        Vector3D[] ptSlice = new Vector3D[2];
                        ptSlice[0] = points3D[0] + ((double)(iSlice + 1) / (double)noSlice) * (points3D[3] - points3D[0]);
                        ptSlice[1] = points3D[1] + ((double)(iSlice + 1) / (double)noSlice) * (points3D[2] - points3D[1]);

                        Point[] pt2D = TransformPoint(GetCurrentTransformation(), ptSlice);
                        g.DrawLine(penPath, pt2D[0], pt2D[1]);                        
                    }
                }
            }  
        }
        #endregion
    }
}
