using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinesLib.Tests
{
    [TestClass()]
    public class LineSegmentTests
    {
        private readonly LineSigment TestLine;

        private readonly LineSigment TestLine1;

        public LineSegmentTests()
        {
            TestLine = new LineSigment(2, 7);
            TestLine1 = new LineSigment(3, 117);
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(10)]
        public void ToStringTestFalse(int point)
        {
            Assert.IsFalse(TestLine.Contains(point));
        }

        [TestMethod()]
        [DataRow(3)]
        [DataRow(4)]
        public void ToStringTestTrue(int point)
        {
            Assert.IsTrue(TestLine.Contains(point));
        }

        [TestMethod()]
        [DataRow(17)]
        [DataRow(50)]
        public void TestTrue(LineSigment lineSegment)
        {
            Assert.IsTrue(TestLine1.Contains(lineSegment));
        }

        [TestMethod()]
        [DataRow(2)]
        [DataRow(118)]
        public void TestFalse(LineSigment lineSegment)
        {
            Assert.IsFalse(TestLine1.Contains(lineSegment));
        }

    }
}