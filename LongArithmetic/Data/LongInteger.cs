using System;
using System.Collections.Generic;
using System.Globalization;

namespace LongArithmetic.Data
{
    public class LongInteger : ILongNumber
    {
        private readonly List<int> _values;
        private bool _negative;
        private const int Radix = 10000;
        private static readonly int RadixLength = (int)Math.Log10(Radix);

        private LongInteger()
        {
            _negative = false;
            _values = new List<int>();
        }

        private LongInteger(string str)
            : this()
        {
            if (str == "")
                throw new FormatException();
            if (str[0] == '-')
            {
                _negative = true;
                str = str.Substring(1);
            }

            int zeroLength = RadixLength - str.Length % RadixLength;
            str = Utils.ZeroString(zeroLength) + str;

            while (str.Length > 0)
            {
                var end = Math.Min(RadixLength, str.Length);
                _values.Add(Int32.Parse(str.Substring(0, end)));
                str = (str.Length == end) ? "" : str.Substring(end);
            }
            Normalize();
        }

        private void Normalize()
        {
            while (_values.Count > 1 && _values[0] == 0)
            {
                _values.RemoveAt(0);
            }
            if (_values.Count == 1 && _values[0] == 0)
                _negative = false;
        }

        public override string ToString()
        {
            var res = (_negative) ? "-" : "";
            for (var index = 0; index < _values.Count; index++)
            {
                var curValue = _values[index].ToString(CultureInfo.InvariantCulture);
                if (index > 0)
                {
                    curValue = Utils.ZeroString(RadixLength - curValue.Length) + curValue;
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