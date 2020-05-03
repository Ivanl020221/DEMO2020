using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO2020GameShop.Helpers
{
    static class Converter
    {
        public static int ToInt(this string str)
        {
            
            return Convert.ToInt32(str);
        }

        public static long ToLong(this string str)
        {
            return Convert.ToInt64(str);
        }
        public static decimal ToDecimal(this string str)
        {
            return Convert.ToDecimal(str);
        }
    }
}
