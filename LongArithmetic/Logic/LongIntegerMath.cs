using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using LongArithmetic.Data;

namespace LongArithmetic.Logic
{
    public class LongIntegerMath
    {
        /// <summary> Return "0" if (v1 = v2);  Return positive result if (v1 > v2);  Return negative result if (v2 > v1)</summary>>
        /// <param name="v1">compared value 1</param>
        /// <param name="v2"> compared value 2</param>
        public static int Compare(LongInteger v1, LongInteger v2)
        {
            if (Equals(v1, v2))
                return 0;

            var sign = ((v1.Negative) ? -1 : 1);
            if (v1.Negative != v2.Negative)
                return sign;

            if (v1.Values.Count != v2.Values.Count)
                return sign * (v1.Values.Count - v2.Values.Count);

            var i = 0;
            while (i < v1.Values.Count && v1.Values[i] == v2.Values[i])
                i++;
            return sign * v1.Values[i].CompareTo(v2.Values[i]);
        }

        public static LongInteger SumLongInteger(LongInteger v1, LongInteger v2)
        {
            if (v1.Values.Count < v2.Values.Count)
                return SumLongInteger(v2, v1);

            if (v1.Negative == v2.Negative)
                return CalculationSumAndSubstruct(v1, v2, 1);

            if (v1.Negative)
                return OppositeValue(SubstructLongInteger(OppositeValue(v1), v2));

            return SubstructLongInteger(v1, OppositeValue(v2));

        }

        public static LongInteger SubstructLongInteger(LongInteger v1, LongInteger v2)
        {
            if (Compare(v1, v2) == 0)
                return LongInteger.Parse("0");

            if (v1.Negative)
                return OppositeValue(SumLongInteger(v2, OppositeValue(v1)));

            if (v2.Negative)
                return SumLongInteger(v1, OppositeValue(v2));

            if (Compare(v1, v2) < 0)
                return OppositeValue(SubstructLongInteger(v2, v1));

            return CalculationSumAndSubstruct(v1, v2, -1);
        }

        public static LongInteger MultiplicationLongInteger(LongInteger v1, LongInteger v2)
        {
            if (v1.Values.Count < v2.Values.Count)
                MultiplicationLongInteger(v2, v1);

            if (v1.Equals("0") || v2.Equals("0")) return LongInteger.Parse("0");

            var multResult = LongInteger.Parse("0");

            var j = v2.Values.Count - 1;
            var n = 0;
            while (j >= 0)
            {
                var result = v1.Clone();
                result.Negative = false;
                var i = v1.Values.Count - 1;
                var hold = 0;
                while (i >= 0)
                {
                    var res = v1.Values[i] * v2.Values[j] + hold;
                    hold = res / Constants.Radix;
                    result.Values[i] = res % Constants.Radix;
                    i--;
                }
                if (hold != 0)
                    result.Values.Insert(0, hold);

                for (var k = 0; k < n; k++)
                {
                    result.Values.Add(0);
                }

                multResult = SumLongInteger(multResult, result);
                j--;
                n++;
            }

            multResult.Negative = v1.Negative != v2.Negative;
            multResult.Normalize();
            return multResult;
        }

        public static LongInteger OppositeValue(LongInteger value)
        {
            var result = value.Clone();
            result.InverSign();
            return result;
        }

        private static LongInteger CalculationSumAndSubstruct(LongInteger v1, LongInteger v2, int sign)
        {
            var result = v1.Clone();
            var i = v1.Values.Count - 1;
            var j = v2.Values.Count - 1;
            var hold = 0;

            while (i >= 0 && (j >= 0 || hold != 0))
            {
                var res = result.Values[i] + (((j >= 0) ? v2.Values[j] : 0)) * sign + hold;
                hold = (res + Constants.Radix) / Constants.Radix - 1;
                result.Values[i] = (res + Constants.Radix) % Constants.Radix;
                i--;
                j--;
            }

            if (sign > 0 && hold != 0)
                result.Values.Insert(0, hold);
            else
                result.Normalize();

            return result;
        }
    }
}
