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
    public class BoxTest
    {
        [Test]
        public void TestNormals()
        {
            Box b = new Box(1, 100.0, 100.0, 100.0);
            Assert.AreEqual(-Vector3D.XAxis, b.Faces[0].Normal);
            Assert.AreEqual(Vector3D.XAxis, b.Faces[1].Normal);
            Assert.AreEqual(-Vector3D.YAxis, b.Faces[2].Normal);
            Assert.AreEqual(Vector3D.YAxis, b.Faces[3].Normal);
            Assert.AreEqual(-Vector3D.ZAxis, b.Faces[4].Normal);
            Assert.AreEqual(Vector3D.ZAxis, b.Faces[5].Normal);
        }
        [Test]
        public void TestPointInside()
        {
            Box b1 = new Box(1, 100.0, 100.0, 100.0);
            Assert.True(b1.PointInside(new Vector3D(50.0, 50.0, 50.0)));
            Assert.False(b1.PointInside(new Vector3D(150.0, 50.0, 50.0)));
        }
        [Test]
        public void TestIsPointBehind()
        {
            Box b1 = new Box(1, 100.0, 100.0, 100.0);
            Vector3D viewDir = new Vector3D(1.0, 1.0, -1.0);
            Assert.True(b1.PointBehind(new Vector3D(50.0, 150.0, 50.0), viewDir));            
            Assert.False(b1.PointBehind(new Vector3D(50.0, -150.0, 50.0), viewDir));
        }
        [Test]
        public void TestBoxBehind()
        {
            Vector3D vCameraPos = new Vector3D(-10000.0, -10000.0, 10000.0);
            Vector3D vTarget = new Vector3D(0.0, 0.0, 0.0);
            Vector3D vDir = vTarget - vCameraPos;

            Box b1 = new Box(1, 100.0, 100.0, 100.0);
            b1.Position = new Vector3D(900.0, 900.0, 0.0);
            Box b2 = new Box(2, 100.0, 100.0, 100.0);
            b2.Position = new Vector3D(800.0, 900.0, 0.0);
            Box b3 = new Box(3, 100.0, 100.0, 100.0);
            b3.Position = new Vector3D(900.0, 800.0, 0.0);
            Box b4 = new Box(3, 100.0, 100.0, 100.0);
            b4.Position = new Vector3D(800.0, 800.0, 0.0);
            Box b5 = new Box(3, 1000.0, 100.0, 100.0);
            b5.Position = new Vector3D(0.0, 900.0, 0.0);
            Box b6 = new Box(3, 100.0, 1000.0, 100.0);
            b6.Position = new Vector3D(900.0, 0.0, 0.0);

            Assert.False(b1.BoxBehind(b2, vDir));
            Assert.False(b1.BoxBehind(b3, vDir));
            Assert.False(b1.BoxBehind(b4, vDir));
            Assert.False(b2.BoxBehind(b4, vDir));
            Assert.False(b3.BoxBehind(b4, vDir));

            Assert.False(b5.BoxBehind(b3, vDir));
            Assert.False(b6.BoxBehind(b2, vDir));
        }

        [Test]
        public void TestBoxInFront()
        {
            Vector3D vCameraPos = new Vector3D(-10000.0, -10000.0, 10000.0);
            Vector3D vTarget = new Vector3D(0.0, 0.0, 0.0);
            Vector3D vDir = vTarget - vCameraPos;

            Box b1 = new Box(1, 100.0, 100.0, 100.0);
            b1.Position = new Vector3D(900.0, 900.0, 0.0);
            Box b2 = new Box(2, 100.0, 100.0, 100.0);
            b2.Position = new Vector3D(800.0, 900.0, 0.0);
            Box b3 = new Box(3, 100.0, 100.0, 100.0);
            b3.Position = new Vector3D(900.0, 800.0, 0.0);
            Box b4 = new Box(3, 100.0, 100.0, 100.0);
            b4.Position = new Vector3D(800.0, 800.0, 0.0);
            Box b5 = new Box(3, 1000.0, 100.0, 100.0);
            b5.Position = new Vector3D(0.0, 900.0, 0.0);
            Box b6 = new Box(3, 100.0, 1000.0, 100.0);
            b6.Position = new Vector3D(900.0, 0.0, 0.0);

            Assert.False(b2.BoxInFront(b1, vDir));
            Assert.False(b3.BoxInFront(b1, vDir));
            Assert.False(b4.BoxInFront(b1, vDir));
            Assert.False(b4.BoxInFront(b2, vDir));
            Assert.False(b4.BoxInFront(b3, vDir));

            Assert.False(b3.BoxInFront(b5, vDir));
            Assert.False(b2.BoxInFront(b6, vDir));
        }
    }
}
