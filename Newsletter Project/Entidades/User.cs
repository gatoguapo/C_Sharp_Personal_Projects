using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class User
    {
        private string username;
        private string password;
        private string email;

        public User(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public string pUsername { get => username; set => username = value; }
        public string pPassword { get => password; set => password = value; }
        public string pEmail { get => email; set => email = value; }
    }
}
