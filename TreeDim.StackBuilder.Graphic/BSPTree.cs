#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    internal class BSPTree : IDisposable
    {
        #region Data members
        BSPNode _root;
        bool _showInfo = false;
        #endregion

        #region Constructor
        public BSPTree()
        { 
        }
        #endregion

        #region Insertion
        public void insert(Face face)
        {
            if (null == _root)
                _root = new BSPNode(face);
            else
                _root.insert(face);
        }
        public void recursFillFaceArray(ref List<Face> faces)
        {
            if (null == _root)
                _root.recursFillFaceArray(ref faces);
        }
        #endregion

        #region Drawing
        public void draw(Vector3D ptEye, Graphics3D graphics3D)
        {
            if (_showInfo) Console.WriteLine("BSP Tree");
            if (_root != null && _showInfo)
                _root.Print(string.Empty);
            if (_showInfo) Console.WriteLine("Drawing");
            draw(_root, ptEye, graphics3D, string.Empty);
        }
        private void draw(BSPNode node, Vector3D ptEye, Graphics3D graphics3D, string offset)
        {
            if (null == node) return;
            double result = node.classifyPoint(ptEye);
            if (result > 0.0)
            {
                draw(node._nodeRight, ptEye, graphics3D, offset);
                if (_showInfo)  Console.WriteLine(offset + node._face.PickingId);
                graphics3D.Draw(node._face);
                draw(node._nodeCoincident, ptEye, graphics3D, offset);
                draw(node._nodeLeft, ptEye, graphics3D, offset);
            }
            else if (result < 0.0)
            {
                draw(node._nodeLeft, ptEye, graphics3D, offset);
                if (_showInfo) Console.WriteLine(offset + node._face.PickingId);
                graphics3D.Draw(node._face);
                draw(node._nodeCoincident, ptEye, graphics3D, offset);
                draw(node._nodeRight, ptEye, graphics3D, offset);
            }
            else // result = 0.0 -> the eye point is on the partition plane
            {
                draw(node._nodeCoincident, ptEye, graphics3D, offset);
                draw(node._nodeLeft, ptEye, graphics3D, offset);
                draw(node._nodeRight, ptEye, graphics3D, offset);
            }
        }
        #endregion

        #region Disposable
        public void Dispose()
        { 
        }
        #endregion
    }
}
