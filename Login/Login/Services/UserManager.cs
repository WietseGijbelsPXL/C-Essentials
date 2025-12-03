using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Login.Services
{
    class UserManager
    {
        public Dictionary<string, string> Users = new Dictionary<string, string>() { {"admin","admin" } };

        public bool Register(string username, string password)
        {
            Users.Add(username, HashPassword(password));
            return true;
        }

        public bool TryLogin(Registration credentials)
        {
            if (Users.ContainsKey(credentials.Username))
            {
                return true;
            }
            else
            {
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
