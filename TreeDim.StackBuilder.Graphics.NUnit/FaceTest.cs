#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Graphics;

using NUnit.Framework;
#endregion

namespace TreeDim.StackBuilder.Graphics.NUnit
{
    [TestFixture]
    public class FaceTest
    {
        [Test]
        public void TestIsVisible()
        { 
            Face f = new Face(0, Vector3D.Zero, new Vector3D(100.0, 0.0, 0.0), new Vector3D(100.0, 0.0, 100.0), new Vector3D(0.0, 0.0, 100.0));
            Assert.True(f.IsVisible(new Vector3D(1.0, 1.0, -1.0)));
            Assert.False(f.IsVisible(new Vector3D(-1.0, -1.0, -1.0)));
        }
        [Test]
        public void TestIsPointBehind()
        {
            Face f = new Face(0, Vector3D.Zero, new Vector3D(100.0, 0.0, 0.0), new Vector3D(100.0, 0.0, 100.0), new Vector3D(0.0, 0.0, 100.0));
            Vector3D viewDir = new Vector3D(1.0, 1.0, -1.0);
            Assert.True(f.PointIsBehind(new Vector3D(50.0, 100.0, 50.0), viewDir));
            Assert.False(f.PointIsBehind(new Vector3D(50.0, -100.0, 50.0), viewDir));
        }
        [Test]
        public void TestIsPointInFront()
        {
            Face f = new Face(0, Vector3D.Zero, new Vector3D(100.0, 0.0, 0.0), new Vector3D(100.0, 0.0, 100.0), new Vector3D(0.0, 0.0, 100.0));
            Vector3D viewDir = new Vector3D(1.0, 1.0, -1.0);
            Assert.False(f.PointIsInFront(new Vector3D(50.0, 100.0, 50.0), viewDir));
            Assert.True(f.PointIsInFront(new Vector3D(50.0, -100.0, 50.0), viewDir));
        }
    }
}
