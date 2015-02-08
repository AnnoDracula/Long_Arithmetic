using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{
    [TestClass]
    public class ModuleTests
    {
        [TestMethod]
        public void Module_Positive()
        {
            var result = LongIntegerMath.Module(LongInteger.Parse("8675435878387378512222876"));
            Assert.AreEqual(LongInteger.Parse("8675435878387378512222876"), result);
        }

        [TestMethod]
        public void Module_Negative()
        {
            var result = LongIntegerMath.Module(LongInteger.Parse("-8675435878387378512222876"));
            Assert.AreEqual(LongInteger.Parse("8675435878387378512222876"), result);
        }

        [TestMethod]
        public void Module_Zero()
        {
            var result = LongIntegerMath.Module(LongInteger.Parse("0"));
            Assert.AreEqual(LongInteger.Parse("0"), result);
        }
    }
}
