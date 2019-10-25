using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Messages
{
    public class UserManagerTest : ITest
    {
        public void Do()
        {
            UserManager manager = new UserManager();
            manager.GetUser("KeyserDSoze", UserType.Telegram).SendMessage("Pyron", "Hello world!!!");
        }
    }
    public class UserManager
    {
        private IUserFactory UserFactory = new UserFactory();
        private Dictionary<string, User> Users = new Dictionary<string, User>();
        public ISendable GetUser(string username, UserType userType)
        {
            if (!this.Users.ContainsKey(username))
            {
                this.Users.Add(username, this.UserFactory.GetFromDB(userType, username));
            }
            return this.Users[username] as ISendable;
        }
    }
}
