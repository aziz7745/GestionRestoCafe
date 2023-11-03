using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRestoCafe.domaine
{
    public class User
    {

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public User(string name, string password, string type)
        {
            Name = name;
            Password = password;
            Type = type;
        }
    }
}
