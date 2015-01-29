﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace LongArithmetic.Data
{
    public class LongInteger : ILongNumber
    {
        internal readonly List<int> Values;
        internal bool Negative;


        private LongInteger()
        {
            Negative = false;
            Values = new List<int>();
        }

        private LongInteger(LongInteger clonableObject)
        {
            Negative = clonableObject.Negative;
            Values = new List<int>(clonableObject.Values);
        }

        private LongInteger(string str)
            : this()
        {
            if (str == "")
                throw new FormatException();
            if (str[0] == '-')
            {
                Negative = true;
                str = str.Substring(1);
            }

            int zeroLength = Constants.RadixLength - str.Length % Constants.RadixLength;
            str = Utils.ZeroString(zeroLength) + str;

            while (str.Length > 0)
            {
                var end = Math.Min(Constants.RadixLength, str.Length);
                Values.Add(Int32.Parse(str.Substring(0, end)));
                str = (str.Length == end) ? "" : str.Substring(end);
            }
            Normalize();
        }

        private void Normalize()
        {
            while (Values.Count > 1 && Values[0] == 0)
            {
                Values.RemoveAt(0);
            }
            if (Values.Count == 1 && Values[0] == 0)
                Negative = false;
        }

        public LongInteger Clone()
        {
            return new LongInteger(this);
        }

        public void InverSign()
        {
            Negative = !Negative;
        }

        public bool IsNegative()
        {
            return Negative;
        }

        //        public override bool Equals(object obj)
        //        {
        //            if (obj.GetType() != typeof (LongInteger))
        //                return false;
        //            var v2 = (LongInteger)obj;
        //
        //            if (Negative != v2.Negative)
        //                return false;
        //            if (Values.Count != v2.Values.Count)
        //                return false;
        //
        //            for (var i = 0; i < Values.Count; i++)
        //            {
        //                if (Values[i] != v2.Values[i])
        //                    return false;
        //            }
        //            return true;
        //        }

        public override string ToString()
        {
            var res = (Negative) ? "-" : "";
            for (var index = 0; index < Values.Count; index++)
            {
                var curValue = Values[index].ToString(CultureInfo.InvariantCulture);
                if (index > 0)
                {
                    curValue = Utils.ZeroString(Constants.RadixLength - curValue.Length) + curValue;
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