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
        public static LongInteger Add(LongInteger v1, LongInteger v2)
        {
            throw new NotImplementedException();
        }

    }
}




