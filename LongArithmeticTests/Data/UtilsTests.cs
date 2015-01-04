using System;
using LongArithmetic.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Data
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void Create_Zero_String()
        {
            Assert.AreEqual("", Utils.ZeroString(0));
            Assert.AreEqual("0", Utils.ZeroString(1));
            Assert.AreEqual("0000000", Utils.ZeroString(7));
        }
    }
}
