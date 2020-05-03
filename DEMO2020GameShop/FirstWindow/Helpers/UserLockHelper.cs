using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMO2020GameShop.Helpers;

namespace DEMO2020GameShop.FirstWindow.Helpers
{
    class UserLockHelper
    {
        private readonly string path = $"{AppDomain.CurrentDomain.BaseDirectory}/usersLock.txt";

        public bool IsUserLock(string login)
        {
            var users = GetUsers();
            if (users.Where(i => i.Login == login)?.FirstOrDefault()?.LockNum.ToInt() >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteLock(string login)
        {
            var users = GetUsers();
            if (users.Where(i => i.Login == login).Count() > 0)
            {
                users.Remove(users.Where(i => i.Login == login).FirstOrDefault());
            }
            File.WriteAllLines(path, users.Select(i =>$"{i.Login}|{i.LockNum}"));
        }

        public void IncrementLockUser(string login)
        {
            var users = GetUsers();
            if (users.Where(i => i.Login == login).Count() > 0)
            {
                var increment = users.Where(i => i.Login == login).FirstOrDefault().LockNum;
                users.Where(i => i.Login == login).FirstOrDefault().LockNum = (increment.ToInt() + 1).ToString();
            }
            else
            {
                users.Add(new UserLock { Login = login, LockNum = "1" });
            }
            File.WriteAllLines(path, users.Select(i => $"{i.Login}|{i.LockNum}"));
        }

        private List<UserLock> GetUsers()
        {
            if (File.Exists(path))
            {
                var users = File.ReadAllLines(path).
                                    ToList().
                                    Select(
                                    i => new UserLock
                                    {
                                        Login = i.Split('|')[0],
                                        LockNum = i.Split('|')[1]

                                    }).ToList();
                return users;
            }
            else
            {
                return new List<UserLock>();
            }
        }

    }

    public class UserLock
    {
        public string Login { get; set; }

        public string LockNum { get; set; }
    }
}
