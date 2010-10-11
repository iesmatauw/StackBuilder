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
    public class BoxComparerTest
    {

        [Test]
        public void TestCompareOrtho()
        {
            Vector3D vCameraPos = new Vector3D(-10000.0, -10000.0, 10000.0);
            Vector3D vTarget = new Vector3D(0.0, 0.0, 0.0);
            BoxComparer comparer = new BoxComparer(vCameraPos, vTarget);

            Box b1 = new Box(1, 100.0, 100.0, 100.0);
            b1.Position = new Vector3D(900.0, 900.0, 0.0);
            Box b2 = new Box(2, 100.0, 100.0, 100.0);
            b2.Position = new Vector3D(800.0, 900.0, 0.0);
            Box b3 = new Box(3, 100.0, 100.0, 100.0);
            b3.Position = new Vector3D(900.0, 800.0, 0.0);
            Box b4 = new Box(4, 100.0, 100.0, 100.0);
            b4.Position = new Vector3D(800.0, 800.0, 0.0);

            Assert.AreEqual(0, comparer.Compare(b1, b1));

            Assert.AreEqual(-1, comparer.Compare(b1, b2));
            Assert.AreEqual(1, comparer.Compare(b2, b1));
            Assert.AreEqual(-1, comparer.Compare(b1, b3));
            Assert.AreEqual(1, comparer.Compare(b3, b1));
            Assert.AreEqual(-1, comparer.Compare(b1, b4));
            Assert.AreEqual(1, comparer.Compare(b4, b1));
            Assert.AreEqual(-1, comparer.Compare(b2, b4));
            Assert.AreEqual(1, comparer.Compare(b4, b2));
            Assert.AreEqual(-1, comparer.Compare(b3, b4));
            Assert.AreEqual(1, comparer.Compare(b4, b3));
        }
        [Test]
        public void TestCompareDifferent()
        {
            BoxComparer comparer = new BoxComparer(new Vector3D(-10000.0, -10000.0, 10000.0), new Vector3D(0.0, 0.0, 0.0));
            Box b1 = new Box(1, 1000.0, 100.0, 100.0);
            b1.Position = new Vector3D(0.0, 900.0, 0.0);
            Box b2 = new Box(2, 100.0, 100.0, 100.0);
            b2.Position = new Vector3D(400.0, 800.0, 0.0);

            Assert.AreEqual(-1, comparer.Compare(b1, b2));
            Assert.AreEqual(1, comparer.Compare(b2, b1));
        }

        [Test]
        public void TestCompareEqualRank()
        {
            BoxComparer comparer = new BoxComparer(new Vector3D(-10000.0, -10000.0, 10000.0), new Vector3D(0.0, 0.0, 0.0));
            Box b1 = new Box(1, 200.0, 100.0, 100.0);
            b1.Position = new Vector3D(800.0, 200.0, 0.0);
            Box b2 = new Box(2, 200.0, 100.0, 100.0);
            b2.Position = new Vector3D(200.0, 800.0, 0.0);

            Assert.AreEqual(0, comparer.Compare(b1, b2));
            Assert.AreEqual(0, comparer.Compare(b2, b1));
        }
    }
}
