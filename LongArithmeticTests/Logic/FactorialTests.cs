using System;
using System.Text;
using System.Collections.Generic;
using LongArithmetic.Data;
using LongArithmetic.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongArithmeticTests.Logic
{
    [TestClass]
    public class FactorialTests
    {
        [TestMethod]
        public void Factorial()
        {
            var result = LongIntegerMath.Factorial(LongInteger.Parse("125"));
            Assert.AreEqual(LongInteger.Parse("188267717688892609974376770249160085759540364871492425887598231508353156331613598866882932889495923133646405445930057740630161919341380597818883457558547055524326375565007131770880000000000000000000000000000000"), result);
        }

        [TestMethod]
        public void Factorial_Zero()
        {
            var result = LongIntegerMath.Factorial(LongInteger.Parse("0"));
            Assert.AreEqual(LongInteger.Parse("1"), result);
        }

        [TestMethod]
        public void Factorial_One()
        {
            var result = LongIntegerMath.Factorial(LongInteger.Parse("1"));
            Assert.AreEqual(LongInteger.Parse("1"), result);
        }

        [TestMethod]
        public void Factorial_SmallValue()
        {
            var result = LongIntegerMath.Factorial(LongInteger.Parse("8"));
            Assert.AreEqual(LongInteger.Parse("40320"), result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Factorial x! is not defined for negative x")]
        public void Factorial_Negative()
        {
            var result = LongIntegerMath.Factorial(LongInteger.Parse("-78637836786"));
        }
    }
}
