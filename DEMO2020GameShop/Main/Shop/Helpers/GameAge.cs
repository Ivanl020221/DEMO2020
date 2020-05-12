using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO2020GameShop.Main.Shop.Helpers
{
    class GameAge
    {
        public static bool IsAgeComplete(DateTime dateOfBirth, Model.ageLimit limit)
        {
            int age = (DateTime.Now - dateOfBirth).Days/365;
            if (age < 18 && limit.ID == 2)
                return false;
            if (age < 13 && limit.ID == 1)
                return false;

            return true;
        }
    }
}
