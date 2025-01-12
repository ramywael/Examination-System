using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class User
    {
        public User(string name, string email, string password, string address)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }
    }
}
