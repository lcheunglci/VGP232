using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Week02
{
    [TestFixture]
    public class CharacterTests
    {
        Character testCharacter;

        [SetUp]
        public void Setup()
        {
            testCharacter = new Character("Bob", 100, 50);
        }

        [Test]
        public void Character_Create_SetProperly()
        {
            int expectedHP = 100;
            int expectedMP = 50;
            string expectedName = "Bob";

            Assert.AreEqual(expectedHP, testCharacter.HP);
            Assert.AreEqual(expectedMP, testCharacter.MP);
            Assert.AreEqual(expectedName, testCharacter.Name);
        }

        [Test]
        public void Character_TakeDamage_50_50HP()
        {
            int expectedHP = 50;

            testCharacter.TakeDamage(50);

            Assert.AreEqual(expectedHP, testCharacter.HP);

        }

    }
}
