#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

using Sharp3D.Math;
using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class FilmRectangle
    {
        #region Data members
        private Vector2D _dimensions;
        private Vector3D _origin;
        private HalfAxis.HAxis _axis1, _axis2;
        private double _dBorder;
        // hatching segment cache
        private double _hatchAngle, _hatchSpacing;
        private Color _color;
        private List<Segment> _segmentCache = new List<Segment>();
        #endregion

        #region Constructors
        public FilmRectangle(
            Vector3D origin,
            HalfAxis.HAxis axis1, HalfAxis.HAxis axis2,
            Vector2D dimensions,
            double dBorder)
        {
            _origin = origin;
            _axis1 = axis1;
            _axis2 = axis2;
            _dimensions = dimensions;
            _dBorder = dBorder;
        }
        #endregion

        #region Public properties
        public Vector3D Normal
        {
            get { return Vector3D.CrossProduct( HalfAxis.ToVector3D(_axis1), HalfAxis.ToVector3D(_axis2)); }
        }
        public Transform3D Transformation
        {
            get
            {
                Vector3D v1 = HalfAxis.ToVector3D(_axis1);
                Vector3D v2 = HalfAxis.ToVector3D(_axis2);
                Vector3D v3 = Normal;
                Vector3D v4 = _origin;
                return new Transform3D(new Matrix4D(v1, v2, v3, v4));
            }
        }
        public Segment[] Segments
        {
            get
            {
                if (_segmentCache.Count == 0)
                {
                    Sharp3D.Math.Geometry2D.Hatching hatching;
                    if (_dBorder <= 0.0)
                        hatching = new Sharp3D.Math.Geometry2D.Hatching(
                            new Sharp3D.Math.Geometry2D.Rectangle(Vector2D.Zero, _dimensions)
                            );
                    else
                        hatching = new Sharp3D.Math.Geometry2D.Hatching(
                            new Sharp3D.Math.Geometry2D.Rectangle(Vector2D.Zero, _dimensions),
                            new Sharp3D.Math.Geometry2D.Rectangle(new Vector2D(_dBorder, _dBorder), new Vector2D(_dimensions.X - 2.0*_dBorder, _dimensions.Y - 2.0*_dBorder))
                            );
                    foreach (Sharp3D.Math.Geometry2D.Segment s in hatching.GetHatchingSegments(_hatchAngle, _hatchSpacing))
                        _segmentCache.Add(
                            new Segment(
                                Transformation.transform(new Vector3D(s.P0.X, s.P0.Y, 0.0)),
                                Transformation.transform(new Vector3D(s.P1.X, s.P1.Y, 0.0)),
                                _color) );
                }
                return _segmentCache.ToArray();
            }
        }
        public Face[] Faces
        {
            get
            {
                if (_dBorder <= 0)
                {
                    Vector3D[] points = new Vector3D[]
                    {
                        Transformation.transform(Vector3D.Zero)
                        , Transformation.transform(new Vector3D(_dimensions.X, 0.0, 0.0))
                        , Transformation.transform(new Vector3D(_dimensions.X, _dimensions.Y, 0.0))
                        , Transformation.transform(new Vector3D(0.0, _dimensions.Y, 0.0))
                    };
                    Face[] faces = new Face[1];
                    faces[0] = new Face(0, points, _color, _color, false);
                    return faces;
                }
                else
                {
                    Vector3D[] points = new Vector3D[]
                    {
                        Transformation.transform(Vector3D.Zero)
                        , Transformation.transform(new Vector3D(_dimensions.X, 0.0, 0.0))
                        , Transformation.transform(new Vector3D(_dimensions.X, _dimensions.Y, 0.0))
                        , Transformation.transform(new Vector3D(0.0, _dimensions.Y, 0.0))
                        , Transformation.transform(new Vector3D(_dBorder, _dBorder, 0.0))
                        , Transformation.transform(new Vector3D(_dimensions.X - _dBorder, _dBorder, 0.0))
                        , Transformation.transform(new Vector3D(_dimensions.X - _dBorder, _dimensions.Y - _dBorder, 0.0))
                        , Transformation.transform(new Vector3D(_dBorder, _dimensions.Y - _dBorder, 0.0))
                    };

                    // 3 --------------------- 2
                    // |                       |
                    // |   7 ----------- 6     |
                    // |   4 ----------- 5     |
                    // |                       |
                    // 0 --------------------- 1


                    Face[] faces = new Face[4];
                    faces[0] = new Face(0, new Vector3D[] { points[0], points[1], points[5], points[4] }, _color, _color, false);
                    faces[1] = new Face(0, new Vector3D[] { points[1], points[2], points[6], points[5] }, _color, _color, false);
                    faces[2] = new Face(0, new Vector3D[] { points[2], points[3], points[7], points[6] }, _color, _color, false);
                    faces[3] = new Face(0, new Vector3D[] { points[3], points[0], points[4], points[7] }, _color, _color, false);
                    return faces;
                }
            }
        }
        public double HatchAngle
        {
            set { _hatchAngle = value; }
        }
        public double HatchSpacing
        {
            set { _hatchSpacing = value; }
        }
        public Color Color
        {
            set { _color = value; }
            get { return _color; }
        }
        #endregion
    }

    public class Film : Drawable
    {
        #region Data members
        private bool _hasTransparency = false, _hasHatching = false;
        private double _hatchSpacing, _hatchAngle;
        private Color _color;
        private List<FilmRectangle> _rectangles = new List<FilmRectangle>();
        #endregion

        #region Constructors
        public Film(Color color, bool transparency, bool hatching, double hatchSpacing, double hatchAngle)
        {
            _color = color;
            _hasTransparency = transparency;
            _hasHatching = hatching;
            _hatchSpacing = hatchSpacing;
            _hatchAngle = hatchAngle;
        }
        #endregion

        #region Public methods
        public bool HasTransparency { get { return _hasTransparency; } }
        public bool HasHatching { get { return _hasHatching; } }

        public void AddRectangle(FilmRectangle rect)
        {
            rect.Color = _color;
            rect.HatchSpacing = _hatchSpacing;
            rect.HatchAngle = _hatchAngle;
            _rectangles.Add(rect);
        }
        public override void DrawBegin(Graphics3D graph)
        {

            foreach (FilmRectangle rectangle in _rectangles)
                if (Vector3D.DotProduct(rectangle.Normal, graph.ViewDirection) > 0)
                {
                    // hatching
                    if (HasHatching)
                    {
                        Segment[] segments = rectangle.Segments;
                        foreach (Segment s in segments)
                            graph.AddSegmentBackgound(s);
                    }
                }
        }
        public override void DrawEnd(Graphics3D graph)
        {
            foreach (FilmRectangle rectangle in _rectangles)
            {
                double cosA = System.Math.Abs(Vector3D.DotProduct(rectangle.Normal, graph.ViewDirection));
                Color color = Color.FromArgb(
                    255
                    , (int)(rectangle.Color.R * cosA)
                    , (int)(rectangle.Color.G * cosA)
                    , (int)(rectangle.Color.B * cosA));
                if (Vector3D.DotProduct(rectangle.Normal, graph.ViewDirection) < 0)
                {
                    // transparency
                    if (HasTransparency)
                    {
                        foreach (Face face in rectangle.Faces)
                            graph.AddFace(face);
                    }
                    // hatching
                    if (HasHatching)
                    {
                        Segment[] segments = rectangle.Segments;
                        foreach (Segment s in segments)
                        {
                            s.Color = color;
                            graph.AddSegment(s);
                        }
                    }
                }
            }

        }
        public override void Draw(Graphics3D graphics)
        {
        }
        #endregion
    }
}
