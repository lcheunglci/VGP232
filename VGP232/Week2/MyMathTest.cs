using System;
using System.IO;
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

        string myOutputFilename = "test.csv";
        string myInputFilename = "data.csv";
        string myTestInputPath = "";
        string myTestOutputPath = "";

        // Math instance
        [SetUp]
        public void Setup()
        {

            // The following ways will be needed for nUnit to get a path that 
            // you can write to
            string myDirPath = System.AppContext.BaseDirectory;

            myTestInputPath = Path.Combine(myDirPath, myInputFilename);
            myTestOutputPath = Path.Combine(myDirPath, myOutputFilename);

            //myDirPath = AppDomain.CurrentDomain.BaseDirectory;

            //myDirPath = this.GetType().Assembly.Location;
            //myDirPath = Path.GetDirectoryName(myDirPath);

            // don't work for nUnit
            //myDirPath = Directory.GetCurrentDirectory();
            //myDirPath = Environment.CurrentDirectory;
        }

        [TearDown]
        public void CleanUp()
        {
            if (File.Exists(myTestOutputPath))
            {
                File.Delete(myTestOutputPath);
            }
        }

        [Test]
        public void TestWritingFile()
        {
            using (StreamWriter writer = new StreamWriter(myTestOutputPath))
            {
                writer.WriteLine("Test");
            }

            Assert.IsTrue(File.Exists(myTestOutputPath));
        }

    }
}
