using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LongArithmetic.Data;

namespace LongArithmetic.Logic
{
    public class LongIntegerMath
    {
        public static bool Equals(LongInteger v1, LongInteger v2)
        {
            if (v1.Values.Equals(v2.Values))
                return true;
            return false;
        }
//        public static int Compare(LongInteger v1, LongInteger v2)
//        {
//            //            if()
//        }
//
//        public static LongInteger Add(LongInteger v1, LongInteger v2)
//        {
////            var result;
//        }
    }
}
