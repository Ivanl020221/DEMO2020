using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO2020GameShop.FirstWindow.Helpers
{
    class Capch
    {
        Random Random = new Random();
        
        public string CapchText { get; set; }

        public string GenerateCapch()
        {
            string capch = string.Empty;
            for (int i = 0; i < Random.Next(4,8); i++)
            {
                capch += Convert.ToChar(Random.Next(77, 130));
            }
            CapchText = capch;
            return capch;
        }
    }
}
