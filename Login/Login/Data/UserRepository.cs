using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Data
{
    internal class UserRepository
    {
        public Dictionary<string, string> Users = new Dictionary<string, string>() { { "admin", "admin" } };
    }
}
