using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Messages
{
    public class UserFactory : IUserFactory
    {
        public User GetFromDB(UserType userType, string username)
        {
            switch (userType)
            {
                case UserType.Whatsapp:
                    return new WhatsappUser(username, "password", "Real image");
                case UserType.Telegram:
                    return new TelegramUser(username, "password", "Alessandro", "Rapiti");
                default:
                    throw new ArgumentException($"UserType {userType} not found");
            }
        }
    }
}
