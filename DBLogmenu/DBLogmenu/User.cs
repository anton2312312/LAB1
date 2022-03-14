using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLogmenu
{
    internal class User
    {
        public string id { get; set; }

        public string login, password;

        public User(){ }

        public User(string id, string login, string password) 
        { 
            this.login = login;
            this.password = password;
        }
    }
}
