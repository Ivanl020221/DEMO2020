using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO2020GameShop.FirstWindow.Helpers
{
    class Validation
    {
        public static bool ValidationUser(string pass,string email,DateTime date, string First, string Last)
        {
            if (email.Contains("@") &&
                email.Contains(".") &&
                ValidationPassword(pass)&&
                First!= string.Empty &&
                Last!= string.Empty &&
                date!= null &&
                date< DateTime.Now)
            {

            }
            return false;
        }

        public static bool ValidationPassword(string pass)
        {
            if (pass.Length > 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
