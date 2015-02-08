using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{
    
    [TestClass]
    public class DivisionTests
    {
       [TestMethod]
        public void DivisionLongInteger_AtZero()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("0"));
            Assert.AreEqual(Constant.Infinity, result);
        }

       [TestMethod]
        public void DivisionLongInteger_NegativeAtZero()
        {
            var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("0"));
            Assert.AreEqual(Constant.Infinity, result);
        }

       [TestMethod]
       public void DivisionLongInteger_PositiveAtOne()
       {
           var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("1"));
           Assert.AreEqual(LongInteger.Parse("86754358512222876"), result);
       }

       [TestMethod]
       public void DivisionLongInteger_PositiveAtNegativeOne()
       {
           var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("-1"));
           Assert.AreEqual(LongInteger.Parse("-86754358512222876"), result);
       }

       [TestMethod]
       public void DivisionLongInteger_NegativeAtOne()
       {
           var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("1"));
           Assert.AreEqual(LongInteger.Parse("-86754358512222876"), result);
       }

       [TestMethod]
       public void DivisionLongInteger_NegativeAtNegativeOne()
       {
           var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("-1"));
           Assert.AreEqual(LongInteger.Parse("86754358512222876"), result);
       }

       [TestMethod]
       public void DivisionLongInteger_Positives()
       {
           var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("16378578"));
           Assert.AreEqual(LongInteger.Parse("5296818717"), result);
       }

       [TestMethod]
       public void DivisionLongInteger_Positives_SecondLonger()
       {
           var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("16378"), LongInteger.Parse("86754358"));
           Assert.AreEqual(LongInteger.Parse("0"), result);
       }

       [TestMethod]
       public void DivisionLongInteger_Negatives()
       {
           var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("-16378578"));
           Assert.AreEqual(LongInteger.Parse("5296818717"), result);
       }

       [TestMethod]
       public void DivisionLongInteger_Negatives_SecondLonger()
       {
           var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-16378"), LongInteger.Parse("-86754358"));
           Assert.AreEqual(LongInteger.Parse("0"), result);
       }

       [TestMethod]
       public void DivisionLongInteger_DifferentSign_FirstNegative()
       {
           var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("-86754358512222876"), LongInteger.Parse("16378578"));
           Assert.AreEqual(LongInteger.Parse("-5296818717"), result);
       }

       [TestMethod]
       public void DivisionLongInteger_DifferentSign_SecondNegative()
       {
           var result = LongIntegerMath.DivisionLongInteger(LongInteger.Parse("86754358512222876"), LongInteger.Parse("-16378578"));
           Assert.AreEqual(LongInteger.Parse("-5296818717"), result);
       }

    }
}
