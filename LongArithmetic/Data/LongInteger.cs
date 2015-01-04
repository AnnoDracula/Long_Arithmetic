using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LongArithmetic.Data
{
    public class LongInteger : ILongNumber
    {
        // 10000 - основание системы счисления
        private string str;
        private List<int> values;
        private bool negative;
        private static int radix = 10000;
        private static int radixLength = (int) Math.Log10(radix);

        private LongInteger()
        {
            negative = false;
            values = new List<int>();
        }

        private LongInteger(string str)
            : this()
        {
            if (str[0] == '-')
            {
                negative = true;
                str = str.Substring(1);
            }

            int zeroLength = radixLength - str.Length % radixLength;
            str = Utils.ZeroString(zeroLength) + str;

            while (str.Length > 0)
            {
                var end = Math.Min(radixLength, str.Length);
                values.Add(Int32.Parse(str.Substring(0, end)));
                str = (str.Length == end) ? "" : str.Substring(end);
            }
        }

        public override string ToString()
        {
            var res = (negative) ? "-" : "";
            for (var index = 0; index < values.Count; index++)
            {
                var curValue = values[index].ToString();
                if (index > 0)
                {
                    curValue = Utils.ZeroString(radixLength - curValue.Length) + curValue;
                }
                res += curValue;
            }
            return res;
        }

        public static LongInteger Parse(string str)
        {
            return new LongInteger(str);
        }
    }
}