using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{
    [TestClass]
    public class LongIntegerMathTests
    {
        [TestMethod]
        public void Equals_Zero_IsTrue()
        {
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("0"), LongInteger.Parse("0")));
        }

        [TestMethod]
        public void Equals_Int_IsTrue()
        {
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("5"), LongInteger.Parse("5")));
        }

        [TestMethod]
        public void Equals_NegativeInt_IsTrue()
        {
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("-8"), LongInteger.Parse("-8")));
        }

        [TestMethod]
        public void Equals_LongInt_IsTrue()
        {
            var str = "8181651268481683184198419841952629518411252952951051091091501098";
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse(str), LongInteger.Parse(str)));
        }

        [TestMethod]
        public void Equals_NegativeLongInt_IsTrue()
        {
            var str = "8181651268481683184198419841952629518411252952951051091091501098";
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("-" + str), LongInteger.Parse("-" + str)));
        }

        [TestMethod]
        public void Equals_AnyNumberIsEqualToItself_IsTrue()
        {
            var number = LongInteger.Parse("15977");
            Assert.IsTrue(LongIntegerMath.Equals(number, number));
        }

        [TestMethod]
        public void Equals_StartWithZero_IsTrue()
        {
            Assert.IsTrue(LongIntegerMath.Equals(LongInteger.Parse("0128"), LongInteger.Parse("128")));
        }

        [TestMethod]
        public void Compare_DifferentSign()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-8567"), LongInteger.Parse("8567"));
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Compare_Negatives_FirstLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-78895"), LongInteger.Parse("-85557"));
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Compare_Negatives_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-85157"), LongInteger.Parse("-78557"));
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Compare_Positive_FirstLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("98895"), LongInteger.Parse("85557"));
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Compare_Positive_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("85157"), LongInteger.Parse("88557"));
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Compare_NegativeDifferentCount_FirstLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-98895"), LongInteger.Parse("-8559557"));
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Compare_NegativeDifferentCount_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-98895"), LongInteger.Parse("-8557"));
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Compare_PositiveDifferentCount_FirstLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("8515725"), LongInteger.Parse("88557"));
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Compare_PositiveDifferentCount_SecondLarger()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("851"), LongInteger.Parse("88557"));
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Compare_NegativeEqualFirstPart()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("-85122228767945"), LongInteger.Parse("-85122228767456"));
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Compare_PositiveEqualFirstPart()
        {
            var result = LongIntegerMath.Compare(LongInteger.Parse("85122228767945"), LongInteger.Parse("85122228767456"));
            Assert.AreEqual(1, result);
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
