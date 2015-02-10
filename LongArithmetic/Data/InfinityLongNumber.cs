using System;

namespace LongArithmetic.Data
{
    public class InfinityLongNumber : BaseLongNumber
    {
        public InfinityLongNumber(bool isNegative = false) : base(isNegative) { }
        public override string ToString()
        {
            return (IsNegative() ? "-" : "") + Constant.Infinity;
        }

        public override bool Equals(object obj)
        {
            return (obj is InfinityLongNumber && IsNegative() == (obj as InfinityLongNumber).IsNegative());
        }
    }
}
