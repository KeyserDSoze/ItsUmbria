using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Messages
{
    public class TelegramUser : User, ISendable
    {
        public string Name { get; }
        public string Surname { get; }
        public TelegramUser(string username, string password, string name, string surname) : base(username, password)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public void SendMessage(string username, string message)
        {
            Console.WriteLine($"{this.Name} {this.Surname} sending to {username} with body: {message}");
        }
    }
}
