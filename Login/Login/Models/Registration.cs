using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Models
{
    class Registration
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Registration(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
