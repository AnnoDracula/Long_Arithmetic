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

        public static LongInteger SummLongInteger(LongInteger v1, LongInteger v2)
        {
            if (v1.Values.Count < v2.Values.Count)
            {
                return SummLongInteger(v2, v1);
            }
            if (v1.Negative == v2.Negative)
            {
                var summ = v1.Clone();
                var i = v1.Values.Count - 1;
                var j = v2.Values.Count - 1;
                var remember = 0;
                while (i >= 0 && (j>=0 || remember !=0))
                {
                    var res = summ.Values[i] + ((j >= 0) ? v2.Values[j] : 0) + remember;
                    remember = res / Constants.Radix;
                    summ.Values[i] = res % Constants.Radix;
                    i--;
                    j--;
                }
                if (remember != 0)
                    summ.Values.Insert(0, remember);
                return summ;
            }

            if (v1.Negative)
            {
                return OppositeValue(SubstructLongInteger(OppositeValue(v1), v2));
            }
            return SubstructLongInteger(v1, OppositeValue(v2));

        }

        public static LongInteger SubstructLongInteger(LongInteger v1, LongInteger v2)
        {
            if (Compare(v1, v2) == 0)
                return LongInteger.Parse("0");

            if (v1.Negative)
                return OppositeValue(SummLongInteger(v2, OppositeValue(v1)));

            if (v2.Negative)
                return SummLongInteger(v1, OppositeValue(v2));

            if (Compare(v1, v2) < 0)
                return OppositeValue(SubstructLongInteger(v2, v1));

            var substruct = v1.Clone();
            var i = v1.Values.Count - 1;
            var j = v2.Values.Count - 1;
            var hold = 0;
            while (i >= 0 && (j>=0 || hold !=0))
            {
                var substrahend = ((j >= 0) ? v2.Values[j] : 0);
                var res = substruct.Values[i] - substrahend + hold;
                hold = (res + Constants.Radix)/Constants.Radix - 1;
                substruct.Values[i] = (res + Constants.Radix)%Constants.Radix;
                i--;
                j--;
            }
            substruct.Normalize();
            return substruct;
        }

        public static LongInteger OppositeValue(LongInteger value)
        {
            var result = value.Clone();
            result.InverSign();
            return result;
        }
    }
}
