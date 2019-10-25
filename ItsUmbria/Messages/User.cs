using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Messages
{
    public abstract class User
    {
        public string Username { get; }
        public string Password { get; }
        public User(string username, string password) 
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
