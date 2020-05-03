using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMO2020GameShop.Model;
using System.IO;

namespace DEMO2020GameShop.FirstWindow.Helpers
{
    class Authhelper
    {
        DEMO2020Entities context = new DEMO2020Entities();

        private readonly string path = $"{AppDomain.CurrentDomain.BaseDirectory}/auth.txt";

        public user AuthSaveUser()
        {
            if (File.Exists(path))
            {
                string[] userdata = File.ReadAllLines(path);
                return Auth(userdata[0], userdata[1]);
            }
            return null;
        }

        public void AuthCreateFile(string login, string pass)
        {
            string[] user = new string[2];
            user[0] = login;
            user[1] = pass;
            File.WriteAllLines(path, user);
        }

        public user Auth(string login, string pass)
        {
            var user = context.user.ToList().Where(i => i.Login == login && i.Password ==  Encrypt.EncryptData(pass));
            if (user.Count() == 1)
            {
                return user.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public void LogOut()
        {
            File.Delete(path);
        }
    }
}
