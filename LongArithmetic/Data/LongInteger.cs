using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LongArithmetic.Data
{
    public class LongInteger : ILongNumber
    {
        // 10000 - основание системы счисления
        private List<int> values;
        private bool negative;
        private static int radix = 10000;
        private static int radixLength = (int)Math.Log10(radix);

        private LongInteger()
        {
            negative = false;
            values = new List<int>();
        }

        private LongInteger(string str)
            : this()
        {
            if (str == "")
                throw new FormatException();
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
            Normalize();
        }

        private void Normalize()
        {
            while (values.Count>1 && values[0] == 0)
            {
                values.RemoveAt(0);
            }
            if (values.Count == 1 && values[0] == 0)
                negative = false;
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