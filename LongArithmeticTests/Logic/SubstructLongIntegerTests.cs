using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{
    [TestClass]
    public class SubstructLongIntegerTests
    {
        [TestMethod]
        public void SubstructLongInteger_Positives()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("86754358512250952"), LongInteger.Parse("28076"));
            Assert.AreEqual(LongInteger.Parse("86754358512222876"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_Positives_SubtrahendBiggerThenMinuend()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("28076"), LongInteger.Parse("86754358512250952"));
            Assert.AreEqual(LongInteger.Parse("-86754358512222876"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_Negatives()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("-86754358512250952"), LongInteger.Parse("-28076"));
            Assert.AreEqual(LongInteger.Parse("-86754358512222876"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_Negatives_SecondValueLongerThenFirst()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("-28076"), LongInteger.Parse("-86754358512250952"));
            Assert.AreEqual(LongInteger.Parse("86754358512222876"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_DifferentSign_FirstNegative()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("-8675435823800"), LongInteger.Parse("28076"));
            Assert.AreEqual(LongInteger.Parse("-8675435851876"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_DifferentSign_FirstNegative_SecondLonger()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("-28076"), LongInteger.Parse("8675435823800"));
            Assert.AreEqual(LongInteger.Parse("-8675435851876"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_DifferentSign_SecondNegative()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("8675435823800"), LongInteger.Parse("-28076"));
            Assert.AreEqual(LongInteger.Parse("8675435851876"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_DifferentSign_SecondNegativeAndLonger()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("28076"), LongInteger.Parse("-8675435823800"));
            Assert.AreEqual(LongInteger.Parse("8675435851876"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_EqualValues()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("56152"), LongInteger.Parse("56152"));
            Assert.AreEqual(LongInteger.Parse("0"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_EqualNegativeValues()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("-56152"), LongInteger.Parse("-56152"));
            Assert.AreEqual(LongInteger.Parse("0"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_EqualValues_DifferentSign_FirstNegative()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("-56152"), LongInteger.Parse("56152"));
            Assert.AreEqual(LongInteger.Parse("-112304"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_EqualValues_DifferentSign_SecondNegative()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("56152"), LongInteger.Parse("-56152"));
            Assert.AreEqual(LongInteger.Parse("112304"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_DecreasesSignificantBit()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("10000000000000000000000"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("9999999999999999999999"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_DecreasesSignificantBitInMiddle()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("10000000020000000000000"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("10000000019999999999999"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_SubtrahendBiggerThenMinuendByOne()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("786783732783542786378378"), LongInteger.Parse("786783732783542786378379"));
            Assert.AreEqual(LongInteger.Parse("-1"), result);
        }

        [TestMethod]
        public void SubstructLongInteger_EqualMiddle()
        {
            var result = LongIntegerMath.SubstructLongInteger(LongInteger.Parse("95555555555555555555555555555555555555555551"), LongInteger.Parse("15555555555555555555555555555555555555555559"));
            Assert.AreEqual(LongInteger.Parse("79999999999999999999999999999999999999999992"), result);
        }
    }
}
