using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaloonsPop.Client;

namespace BaloonsPop.Tests
{
    [TestClass]
    public class CoordinatesTest
    {
        [TestMethod]
        public void TryParse_InputCountIsTwo_Parsed()
        {
            string input = "3 4";
            Coordinates coordinates = new Coordinates();
            bool result = Coordinates.TryParse(input, ref coordinates);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParse_InputCountIsDifferentFromTwo_ParsedFailed()
        {
            string input = "3    4";
            Coordinates coordinates = new Coordinates();
            bool result = Coordinates.TryParse(input, ref coordinates);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_InvalidRow_ParsedFailed()
        {
            string input = "5 4";
            Coordinates coordinates = new Coordinates();
            bool result = Coordinates.TryParse(input, ref coordinates);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_InvalidRow_NotNumber()
        {
            string input = "z 4";
            Coordinates coordinates = new Coordinates();
            bool result = Coordinates.TryParse(input, ref coordinates);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_InvalidCol_NotNumber()
        {
            string input = "4 z";
            Coordinates coordinates = new Coordinates();
            bool result = Coordinates.TryParse(input, ref coordinates);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParse_InvalidCol_ParsedFailed()
        {
            string input = "3 10";
            Coordinates coordinates = new Coordinates();
            bool result = Coordinates.TryParse(input, ref coordinates);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Col_PropertieGet()
        {
            string input = "3 0";
            Coordinates coordinates = new Coordinates();
            Coordinates.TryParse(input, ref coordinates);
            Assert.AreEqual(0, coordinates.Col);
        }

        [TestMethod]
        public void Row_PropertieGet()
        {
            string input = "3 0";
            Coordinates coordinates = new Coordinates();
            Coordinates.TryParse(input, ref coordinates);
            Assert.AreEqual(3, coordinates.Row);
        }


    }
}