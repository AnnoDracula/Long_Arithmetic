using LongArithmetic.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{
    [TestClass]
    public class EqualsTests
    {
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
    }
}
