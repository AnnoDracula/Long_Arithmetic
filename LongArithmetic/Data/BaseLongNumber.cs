namespace LongArithmetic.Data
{
    public abstract class BaseLongNumber : ILongNumber
    {
        internal bool Negative;
        
        internal BaseLongNumber(bool isNegative = false)
        {
            Negative = isNegative;
        }
        
        public bool IsNegative()
        {
            return Negative;
        }

        public void InverSign()
        {
            Negative = !Negative;
        }
    }
}
