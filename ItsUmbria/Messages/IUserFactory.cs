using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Messages
{
    public interface IUserFactory
    {
        User GetFromDB(UserType userType, string username);
    }
    
}
