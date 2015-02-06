using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{
    [TestClass]
    public class SumLongIntegerTests
    {
       [TestMethod]
        public void SumLongInteger_Positives()
        {
            var result = LongIntegerMath.SumLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("28076"));
            Assert.AreEqual(LongInteger.Parse("86754358512250952"), result);
        }

        [TestMethod]        public void SumLongInteger_Negatives()
        {
            var result = LongIntegerMath.SumLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("-28076"));
            Assert.AreEqual(LongInteger.Parse("-86754358512250952"), result);
        }

        [TestMethod]
        public void SumLongInteger_DifferentSign_FirstNegative()
        {
            var result = LongIntegerMath.SumLongInteger(LongInteger.Parse("-8675435851876"), LongInteger.Parse("28076"));
            Assert.AreEqual(LongInteger.Parse("-8675435823800"), result);
        }

        [TestMethod]
        public void SumLongInteger_DifferentSign_SecondNegative()
        {
            var result = LongIntegerMath.SumLongInteger(LongInteger.Parse("8675435851876"), LongInteger.Parse("-28076"));
            Assert.AreEqual(LongInteger.Parse("8675435823800"), result);
        }

        [TestMethod]
        public void SumLongInteger_EqualValues()
        {
            var result = LongIntegerMath.SumLongInteger(LongInteger.Parse("28076"), LongInteger.Parse("28076"));
            Assert.AreEqual(LongInteger.Parse("56152"), result);
        }

        [TestMethod]
        public void SumLongInteger_IncreasesSignificantBit()
        {
            var result = LongIntegerMath.SumLongInteger(LongInteger.Parse("9"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("10"), result);

            result = LongIntegerMath.SumLongInteger(LongInteger.Parse("99"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("100"), result);

            result = LongIntegerMath.SumLongInteger(LongInteger.Parse("999"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("1000"), result);

            result = LongIntegerMath.SumLongInteger(LongInteger.Parse("9999"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("10000"), result);

            result = LongIntegerMath.SumLongInteger(LongInteger.Parse("99999"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("100000"), result);

            result = LongIntegerMath.SumLongInteger(LongInteger.Parse("999999"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("1000000"), result);

            result = LongIntegerMath.SumLongInteger(LongInteger.Parse("9999999"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("10000000"), result);

            result = LongIntegerMath.SumLongInteger(LongInteger.Parse("99999999"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("100000000"), result);

            result = LongIntegerMath.SumLongInteger(LongInteger.Parse("999999999"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("1000000000"), result);

            result = LongIntegerMath.SumLongInteger(LongInteger.Parse("9999999999999999999999"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("10000000000000000000000"), result);
        }

        [TestMethod]
        public void SumLongInteger_ShouldNotChangeArguments()
        {
            var v1 = LongInteger.Parse("1");
            var v2 = LongInteger.Parse("200000000000000");
            var v3 = LongIntegerMath.SumLongInteger(v1, v2);

            Assert.AreEqual(v1.ToString(), "1");
            Assert.AreEqual(v2.ToString(), "200000000000000");
            Assert.AreEqual(v3.ToString(), "200000000000001");
        }
    }
}
