using System;

namespace LongArithmetic.Data
{
     internal class Constants
    {
        internal const int Radix = 1000;
        internal static readonly int RadixLength = (int)Math.Log10(Radix);
    }

    public class Constant
    {
        public const int Radix = Constants.Radix;
        public const string Infinity = "Infinity";
    }
}
