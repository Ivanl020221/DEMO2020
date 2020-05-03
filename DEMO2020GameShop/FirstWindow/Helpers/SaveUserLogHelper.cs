using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DEMO2020GameShop.FirstWindow.Helpers
{
    class SaveUserLogHelper
    {
        private readonly string path = $"{AppDomain.CurrentDomain.BaseDirectory}/users.txt";

        public void SaveUser(string user)
        {
            if (File.Exists(path))
            {
                var users = File.ReadAllLines(path).ToList();
                if (users.Where(i => i == user).Count() == 0)
                {
                    users.Add(user);
                }
                File.WriteAllLines(path, users);
            }
            else
            {
                var usersList = new List<string>();
                usersList.Add(user);
                File.WriteAllLines(path, usersList);
            }
        }

        public List<string> GetAllUser()
        {
            if (File.Exists(path))
            {
                return File.ReadAllLines(path).ToList();
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
