using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{
     [TestClass]
    public class PowerTests
    {
         [Timeout(1000)]
         [TestMethod]
         public void Power_PositiveAtZeroExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("8675435878387378512222876"), LongInteger.Parse("0"));
             Assert.AreEqual(LongInteger.Parse("1"), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_PositiveAtFirstExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("8675435878387378512222876"), LongInteger.Parse("1"));
             Assert.AreEqual(LongInteger.Parse("8675435878387378512222876"), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_PositiveAtNegativeFirstExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("86754"), LongInteger.Parse("-1"));
             Assert.AreEqual(LongInteger.Parse("0.00001152684"), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_PositiveAtSecondExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("8675435878387378512222876"), LongInteger.Parse("2"));
             Assert.AreEqual(LongInteger.Parse("75263187680010985770759262077222264890530697711376"), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_PositiveAtNegativeSecondExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("86754"), LongInteger.Parse("-2"));
             Assert.AreEqual(LongIntegerMath.DivisionLongInteger(LongInteger.Parse("1"), LongIntegerMath.Power(LongInteger.Parse("86754"), LongInteger.Parse("2")) as LongInteger), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_PositiveAtPositiveExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("1675"), LongInteger.Parse("51"));
             Assert.AreEqual(LongInteger.Parse("265922680624065947983569107236030250425751686180815786236546454206212173641431223389225987377498639067833261257629765057677699580107599786060745827853679656982421875"), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_NegativeAtZeroExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("-8675435878387378512222876"), LongInteger.Parse("0"));
             Assert.AreEqual(LongInteger.Parse("1"), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_NegativeAtFirstExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("-8675435878387378512222876"), LongInteger.Parse("1"));
             Assert.AreEqual(LongInteger.Parse("-8675435878387378512222876"), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_NegativeAtNegativeFirstExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("-86754"), LongInteger.Parse("-1"));
             Assert.AreEqual(LongInteger.Parse("-0.00001152684"), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_NegativeAtSecondExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("-8675435878387378512222876"), LongInteger.Parse("2"));
             Assert.AreEqual(LongInteger.Parse("75263187680010985770759262077222264890530697711376"), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_NegativeAtNegativeSecondExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("-86754"), LongInteger.Parse("-2"));
             Assert.AreEqual(LongIntegerMath.DivisionLongInteger(LongInteger.Parse("1"), LongIntegerMath.Power(LongInteger.Parse("-86754"), LongInteger.Parse("2")) as LongInteger), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_NegativeAtPositiveExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("-1675"), LongInteger.Parse("51"));
             Assert.AreEqual(LongInteger.Parse("-265922680624065947983569107236030250425751686180815786236546454206212173641431223389225987377498639067833261257629765057677699580107599786060745827853679656982421875"), result);
         }

         [Timeout(1000)]
         [TestMethod]
         public void Power_NegativeAtEvenPositiveExponent()
         {
             var result = LongIntegerMath.Power(LongInteger.Parse("-1675"), LongInteger.Parse("52"));
             Assert.AreEqual(LongInteger.Parse("445420490045310462872478254620350669463134074352866441946215310795405390849397299176953528857310220438620712606529856471610146796680229641651749261654913425445556640625"), result);
         }
    }
}
