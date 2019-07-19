using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Week2
{
    public class MyMathTest
    {
        [Test]
        public void TestSum()
        {
            int expected = 2;
            MyMath math = new MyMath();
            int actual = math.Sum(1, 1);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(2, 10, 12)]
        [TestCase(1, 1, 2)]
        [TestCase(2, 11, 12)]
        [TestCase(3, 12, 12)]
        [TestCase(1, 10, 12)]
        public void TestSum(int a, int b, int expected)
        {
            MyMath math = new MyMath();
            int actual = math.Sum(a, b);
            Assert.AreEqual(expected, actual);
        }

    }
}
