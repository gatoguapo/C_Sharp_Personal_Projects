using System.Collections.Generic;
using System;
using Entidades;

namespace Negocio
{
    public class UserHandler
    {
        private List<User> userList = new List<User>();

        public void addUser(string username, string password, string email)
        {
            userList.Add(new User(username, password, email));
        }

        public bool validateUniqueUsername(string username)
        {
            bool validate = userList.Exists(usr => usr.pUsername.Equals(username));
            return validate;
        }

        public bool validateUniqueEmail(string email)
        {
            bool validate = userList.Exists(usr => usr.pEmail.Equals(email));
            return validate;
        }

        public List<User> getUserList()
        {
            return userList;
        }

        public bool searchUser(string user)
        {
            bool search;
            search = userList.Exists(usr => usr.pUsername.Equals(user) || usr.pEmail.Equals(user));
            return search;
        }

        public bool searchUserPassword (string user, string password)
        {
            bool search;
            search = userList.Exists(usr => 
                (usr.pUsername.Equals(user) && usr.pPassword.Equals(password)) || 
                (usr.pEmail.Equals(user) && usr.pPassword.Equals(password))
            );
            return search;
        }
    }
}
