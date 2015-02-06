using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{
    [TestClass]
    public class LongIntegerMathTests
    {
        #region Equals
        [TestMethod]
        public void Equals_Zero_IsTrue()
        {
            Assert.AreEqual(LongInteger.Parse("0"), LongInteger.Parse("0"));
        }

        [TestMethod]
        public void Equals_Int_IsTrue()
        {
            Assert.AreEqual(LongInteger.Parse("5"), LongInteger.Parse("5"));
        }

        [TestMethod]
        public void Equals_NegativeInt_IsTrue()
        {
            Assert.AreEqual(LongInteger.Parse("-8"), LongInteger.Parse("-8"));
        }

        [TestMethod]
        public void Equals_LongInt_IsTrue()
        {
            const string str = "8181651268481683184198419841952629518411252952951051091091501098";
            Assert.AreEqual(LongInteger.Parse(str), LongInteger.Parse(str));
        }

        [TestMethod]
        public void Equals_NegativeLongInt_IsTrue()
        {
            const string str = "8181651268481683184198419841952629518411252952951051091091501098";
            Assert.AreEqual(LongInteger.Parse("-" + str), LongInteger.Parse("-" + str));
        }

        [TestMethod]
        public void Equals_AnyNumberIsEqualToItself_IsTrue()
        {
            var number = LongInteger.Parse("15977");
            Assert.AreEqual(number, number);
        }

        [TestMethod]
        public void Equals_StartWithZero_IsTrue()
        {
            Assert.AreEqual(LongInteger.Parse("0128"), LongInteger.Parse("128"));
        }
        #endregion

        #region Compare
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
        #endregion

        #region SumLongInteger
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
        #endregion

        #region SubstructLongInteger
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

        #endregion

        #region internal

        [TestMethod]
        public void Div()
        {
            Assert.AreEqual(0, -1 / 3);
            Assert.AreEqual(-2, -2 % 3);
        }
        #endregion
    }
}
