namespace LongArithmetic.Data
{
    public class Utils
    {
        public static string ZeroString(int length)
        {
            string result = "";
            for (var i = 0; i < length; i++)
            {
                result += "0";
            }
            return result;
        }
    }
}
