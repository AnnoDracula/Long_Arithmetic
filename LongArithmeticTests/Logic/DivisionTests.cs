using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{

    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void DivisionIntoSmall_AtZero()
        {
            var result = LongIntegerMath.DivisionIntoSmall(LongInteger.Parse("78652868637835437863"), 0);
            Assert.AreEqual(new InfinityLongNumber(), result);
        }

        [TestMethod]
        public void DivisionIntoSmall_NegativeAtZero()
        {
            var result = LongIntegerMath.DivisionIntoSmall(LongInteger.Parse("-78652868637835437863"), 0);
            Assert.AreEqual(new InfinityLongNumber(true), result);
        }

        [TestMethod]
        public void DivisionIntoSmall_AtOne()
        {
            var result = LongIntegerMath.DivisionIntoSmall(LongInteger.Parse("78652868637835437863"), 1);
            Assert.AreEqual(LongInteger.Parse("78652868637835437863"), result);
        }

        [TestMethod]
        public void DivisionIntoSmall_AtNegativeOne()
        {
            var result = LongIntegerMath.DivisionIntoSmall(LongInteger.Parse("78652868637835437863"), -1);
            Assert.AreEqual(LongInteger.Parse("-78652868637835437863"), result);
        }

        [TestMethod]
        public void DivisionIntoSmall_NegativeAtOne()
        {
            var result = LongIntegerMath.DivisionIntoSmall(LongInteger.Parse("-78652868637835437863"), 1);
            Assert.AreEqual(LongInteger.Parse("-78652868637835437863"), result);
        }

        [TestMethod]
        public void DivisionIntoSmall_NegativeAtNegativeOne()
        {
            var result = LongIntegerMath.DivisionIntoSmall(LongInteger.Parse("-78652868637835437863"), -1);
            Assert.AreEqual(LongInteger.Parse("78652868637835437863"), result);
        }

        [TestMethod]
        public void DivisionIntoSmall_AtTwo()
        {
            var result = LongIntegerMath.DivisionIntoSmall(LongInteger.Parse("78652868637835437863"), 2);
            Assert.AreEqual(LongInteger.Parse("39326434318917718931"), result);
        }

        [TestMethod]
        public void DivisionIntoSmall_AtSomeInteger()
        {
            var result = LongIntegerMath.DivisionIntoSmall(LongInteger.Parse("78652868637835437863"), 37);
            Assert.AreEqual(LongInteger.Parse("2125753206427984807"), result);
        }

        [TestMethod]
        public void DivisionIntoSmall_AtBigInteger()
        {
            var result = LongIntegerMath.DivisionIntoSmall(LongInteger.Parse("78652868637835437863"), 999);
            Assert.AreEqual(LongInteger.Parse("78731600238073511"), result);
        }

        [TestMethod]
        public void DivisionIntoSmall_AtRadix()
        {
            var result = LongIntegerMath.DivisionIntoSmall(LongInteger.Parse("78652868637835437863"), 1000);
            Assert.AreEqual(LongInteger.Parse("78652868637835437"), result);
        }
        //Only for current radix; 

        [TestMethod]
        public void DivisionIntoSmall_AtIntegerGreaterThenRadix()
        {
            var result = LongIntegerMath.DivisionIntoSmall(LongInteger.Parse("78652868637835437863"), 5887637);
            Assert.AreEqual(LongInteger.Parse("13358987423619"), result);
        }     

        [TestMethod]
        public void DivisionLongInteger_AtZero()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("0"));
            Assert.AreEqual(new InfinityLongNumber(), result);
        }

        [TestMethod]
        public void DivisionLongInteger_NegativeAtZero()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("0"));
            Assert.AreEqual(new InfinityLongNumber(true), result);
        }

        [TestMethod]
        public void DivisionLongInteger_PositiveAtOne()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("86754358512222876"), result);
        }

        [TestMethod]
        public void DivisionLongInteger_PositiveAtNegativeOne()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("-1"));
            Assert.AreEqual(LongInteger.Parse("-86754358512222876"), result);
        }

        [TestMethod]
        public void DivisionLongInteger_NegativeAtOne()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("-86754358512222876"), result);
        }

        [TestMethod]
        public void DivisionLongInteger_NegativeAtNegativeOne()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("-1"));
            Assert.AreEqual(LongInteger.Parse("86754358512222876"), result);
        }

        [TestMethod]
        public void DivisionLongInteger_Positives()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("16378578"));
            Assert.AreEqual(LongInteger.Parse("5296818717"), result);
        }

        [TestMethod]
        public void DivisionLongInteger_Positives_SecondLonger()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("16378"), LongInteger.Parse("86754358"));
            Assert.AreEqual(LongInteger.Parse("0"), result);
        }

        [TestMethod]
        public void DivisionLongInteger_Negatives()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("-16378578"));
            Assert.AreEqual(LongInteger.Parse("5296818717"), result);
        }

        [TestMethod]
        public void DivisionLongInteger_Negatives_SecondLonger()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-16378"), LongInteger.Parse("-86754358"));
            Assert.AreEqual(LongInteger.Parse("0"), result);
        }

        [TestMethod]
        public void DivisionLongInteger_DifferentSign_FirstNegative()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("16378578"));
            Assert.AreEqual(LongInteger.Parse("-5296818717"), result);
        }

        [TestMethod]
        public void DivisionLongInteger_DifferentSign_SecondNegative()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("-16378578"));
            Assert.AreEqual(LongInteger.Parse("-5296818717"), result);
        }

    }
}
