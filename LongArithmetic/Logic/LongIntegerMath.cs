using System;
using System.Runtime.Remoting.Messaging;
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
            throw new NotImplementedException();
        }

        public static LongInteger Add(LongInteger v1, LongInteger v2)
        {
            throw new NotImplementedException();
        }
    }
}

