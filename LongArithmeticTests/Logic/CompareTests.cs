using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{
    [TestClass]
    public class CompareTests
    {
        [TestMethod]
        public void Compare_DifferentSign()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-8567"), LongInteger.Parse("8567"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_Negatives_FirstLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-78895"), LongInteger.Parse("-85557"));
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Compare_Negatives_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-85157"), LongInteger.Parse("-78557"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_Positive_FirstLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("98895"), LongInteger.Parse("85557"));
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Compare_Positive_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("85157"), LongInteger.Parse("88557"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_NegativeDifferentLength_FirstLarger()
        {
            LongIntegerMath.Compare(LongInteger.Parse("225"), LongInteger.Parse("856"));
            var result = LongIntegerMath.Compare(LongInteger.Parse("-98895"), LongInteger.Parse("-85595455488432574564857"));
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Compare_NegativeDifferentLength_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-988852945965292398595"), LongInteger.Parse("-8557"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_PositiveDifferentLength_FirstLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("859529395263915725"), LongInteger.Parse("88557"));
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Compare_PositiveDifferentCount_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("851"), LongInteger.Parse("85649679898888648557"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_NegativeEqualFirstPart()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-85122228767945"), LongInteger.Parse("-85122228767456"));
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_PositiveEqualFirstPart()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("85122228767945"), LongInteger.Parse("85122228767456"));
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Compare_PositiveEquals()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("8512222876"), LongInteger.Parse("8512222876"));
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Compare_NegativeEquals()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-8512222876"), LongInteger.Parse("-8512222876"));
            Assert.AreEqual(0, result);
        }
    }
}
