using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment2
{
    class PokemonTest
    {
        const string TEST_DATA_OUTPUT_FILE = "output.txt";
        const string TEST_DATA_INPUT_FILE = "data_temp.csv";
        string testOutputFile = "";
        string testInputFile = "";


        [Test]
        public void Test()
        {
            string actualName = "Test";
            string expectedName = "Test1";
            Assert.AreEqual(actualName, expectedName);
        }

        [TestCase("0", "0")]
        [TestCase("TEST", "TEST")]
        [TestCase("teST", "TEST")]
        [TestCase("test123", "TEST123")]
        [TestCase("test", "TEST")]
        public void AnotherTest(string input, string expected)
        {
            string actual = input.ToUpper();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExceptionTest()
        {
            Assert.That(() => {
                List<Pokemon> pokemons = new List<Pokemon>();
                Console.WriteLine(pokemons[1]);
            },
                Throws.InstanceOf<System.ArgumentOutOfRangeException>());
        }

        [SetUp]
        public void Setup()
        {
            //string currentDir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
            //string appDir = AppContext.BaseDirectory;
            //testOutputFile = Path.Combine(appDir, TEST_DATA_OUTPUT_FILE);
            //testInputFile = Path.Combine(appDir, TEST_DATA_INPUT_FILE);


            if (File.Exists(TEST_DATA_OUTPUT_FILE))
            {
                File.Delete(TEST_DATA_OUTPUT_FILE);
            }

            if (!File.Exists(TEST_DATA_INPUT_FILE))
            {
                using (var writer = new StreamWriter(TEST_DATA_INPUT_FILE))
                {
                    writer.WriteLine("Test,Test,Test");
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(TEST_DATA_OUTPUT_FILE))
            {
                File.Delete(TEST_DATA_OUTPUT_FILE);
            }
        }

    }
}
