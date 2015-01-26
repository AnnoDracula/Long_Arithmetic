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

    }
}
