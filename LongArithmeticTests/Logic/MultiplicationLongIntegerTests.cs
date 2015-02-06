using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{

    [TestClass]
    public class MultiplicationLongIntegerTests
    {
        [TestMethod]
        public void MultiplicationLongInteger_Positives()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("287576"));
            Assert.AreEqual(LongInteger.Parse("24948471403511005788576"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_Positives_SecondLonger()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("287576"), LongInteger.Parse("86754358512222876"));
            Assert.AreEqual(LongInteger.Parse("24948471403511005788576"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_Negatives()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("-287576"));
            Assert.AreEqual(LongInteger.Parse("24948471403511005788576"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_Negatives_SecondLonger()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("-287576"), LongInteger.Parse("-86754358512222876"));
            Assert.AreEqual(LongInteger.Parse("24948471403511005788576"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_DifferentSign_FirstNegative()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("287576"));
            Assert.AreEqual(LongInteger.Parse("-24948471403511005788576"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_DifferentSign_SecondNegative()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("-287576"));
            Assert.AreEqual(LongInteger.Parse("-24948471403511005788576"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_EqualValues()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("86754358512222876"));
            Assert.AreEqual(LongInteger.Parse("7526318720867297782959490697711376"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_HigestNumbersOfDischarge()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("999999999999999999"), LongInteger.Parse("99999999999999999"));
            Assert.AreEqual(LongInteger.Parse("99999999999999998900000000000000001"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_ByZero()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("786543767867865354"), LongInteger.Parse("0"));
            Assert.AreEqual(LongInteger.Parse("0"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_NegativeByZero()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("-786543767867865354"), LongInteger.Parse("0"));
            Assert.AreEqual(LongInteger.Parse("0"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_ByOne()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("786543767867865354"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("786543767867865354"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_NegativeByOne()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("-786543767867865354"), LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("-786543767867865354"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_ByNegativeOne()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("786543767867865354"), LongInteger.Parse("-1"));
            Assert.AreEqual(LongInteger.Parse("-786543767867865354"), result);
        }

        [TestMethod]
        public void MultiplicationLongInteger_NegativeByNegativeOne()
        {
            var result = LongIntegerMath.MultiplicationLongInteger(LongInteger.Parse("-786543767867865354"), LongInteger.Parse("-1"));
            Assert.AreEqual(LongInteger.Parse("786543767867865354"), result);
        }

        delegate int MathAction(int num1, int num2);

        [TestMethod]
        public void TestDelegate()
        {
            MathAction sum = (num1, num2) => num1 + num2;
            MathAction sub = (num1, num2) => num1 - num2;
            MathAction mult = (num1, num2) => num1*num2;
            MathAction div = (num1, num2) => num1/num2;

            Assert.AreEqual(sum(1,2), 3);
            Assert.AreEqual(sub(1,2), -1);
            Assert.AreEqual(mult(1,2), 2);
            Assert.AreEqual(div(1,2), 0);
        }

    }
}