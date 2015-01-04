using System;
using LongArithmetic.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Data
{
    [TestClass]
    public class LongIntegerTests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Create_Empty()
        {
            LongInteger.Parse("");
        }

        [TestMethod]
        public void Create_Zero()
        {
            var number = LongInteger.Parse("0");
            Assert.AreEqual("0", number.ToString());
        }

        [TestMethod]
        public void Create_NegativeZero()
        {
            var number = LongInteger.Parse("-0");
            Assert.AreEqual("0", number.ToString());
        }

        [TestMethod]
        public void Create_StartsWhithZero()
        {
            var number = LongInteger.Parse("005894");
            Assert.AreEqual("5894", number.ToString());
        }

        [TestMethod]
        public void Create_StartsWhithManyZero()
        {
            var number = LongInteger.Parse("0000000000000005894");
            Assert.AreEqual("5894", number.ToString());
        }

        [TestMethod]
        public void Create_NegativeStartsWhithManyZero()
        {
            var number = LongInteger.Parse("-0000000000000005894");
            Assert.AreEqual("-5894", number.ToString());
        }

        [TestMethod]
        public void Create_Negative()
        {
            var number = LongInteger.Parse("-1");
            Assert.AreEqual("-1", number.ToString());
        }

        [TestMethod]
        public void Create_Positive()
        {
            var number = LongInteger.Parse("1");
            Assert.AreEqual("1", number.ToString());
        }

        [TestMethod]
        public void Create_Integer()
        {
            var number = LongInteger.Parse("450025");
            Assert.AreEqual("450025", number.ToString());
        }

        [TestMethod]
        public void Create_IntegerManyZeroes()
        {
            var number = LongInteger.Parse("450000000000000000000000000025");
            Assert.AreEqual("450000000000000000000000000025", number.ToString());
        }

        [TestMethod]
        public void Create_NegativeIntegerManyZeroes()
        {
            var number = LongInteger.Parse("-450000000000000000000000000025");
            Assert.AreEqual("-450000000000000000000000000025", number.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Create_Liter()
        {
            LongInteger.Parse("15fd");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Create_Double()
        {
            LongInteger.Parse("15.99");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Create_DoubleComa()
        {
            LongInteger.Parse("15,99");
        }
    }
}
