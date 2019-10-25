using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Messages
{
    public class WhatsappUser : User, ISendable
    {
        public string Image { get; }
        public WhatsappUser(string username, string password, string image) : base(username, password)
        {
            this.Image = image;
        }

        public void SendMessage(string username, string message)
        {
            Console.WriteLine($"{this.Image} sending to {username} with body: {message}");
        }
    }
}
