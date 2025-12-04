using Login.Data;
using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Login.Services
{
    class UserManager
    {
        UserRepository userRepo = new UserRepository();
        int _counter = 3;

        public int Counter => _counter;

        public bool Register(string username, string password)
        {
            if (!userRepo.Users.ContainsKey(username))
            {
                userRepo.Users.Add(username, HashPassword(password));
                return true;
            }
            return false;
        }

        public bool TryLogin(Registration credentials)
        {
            if (userRepo.Users.TryGetValue(credentials.Username, out string pwd) && pwd == credentials.Password)
            {
                return true;
            }
            //if (Users.ContainsKey(credentials.Username) && Users[credentials.Username] == credentials.Password)
            //{
            //    return true;
            //}
            else
            {
                _counter--;
                return false;
            }
        }

        private string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
