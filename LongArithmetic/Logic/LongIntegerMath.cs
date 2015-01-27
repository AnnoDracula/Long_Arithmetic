using System;
using LongArithmetic.Data;

namespace LongArithmetic.Logic
{
    public class LongIntegerMath
    {
        public static bool Equals(LongInteger v1, LongInteger v2)
        {
            if (v1.Negative != v2.Negative)
                return false;
            if (v1.Values.Count != v2.Values.Count)
                return false;

            for (var i = 0; i < v1.Values.Count; i++)
            {
                if (v1.Values[i] != v2.Values[i])
                    return false;
            }
            return true;
        }
        public static int Compare(LongInteger v1, LongInteger v2)
        {
            var result = 0;
            if (Equals(v1, v2))
                return result;

            if (v1.Negative != v2.Negative)
            {
                result = v1.Negative ? 2 : 1;
                return result;
            }
            if (v1.Values.Count != v2.Values.Count)
            {
                if (v1.Negative && v1.Values.Count > v2.Values.Count)
                    result = 2;
                else
                    result = 1;
                return result;
            }
            for (var i = 0; i < v1.Values.Count; i++)
            {
                if (v1.Negative)
                {
                    result = v1.Values[i] > v2.Values[i] ? 2 : 1;
                }
                else
                {
                    result = v1.Values[i] > v2.Values[i] ? 1 : 2;
                }
            }
            return result;
        }
        public static LongInteger Add(LongInteger v1, LongInteger v2)
        {
            throw new NotImplementedException();
        }
    }
}




