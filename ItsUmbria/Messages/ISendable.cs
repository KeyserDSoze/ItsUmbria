using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Messages
{
    public interface ISendable
    {
        void SendMessage(string username, string message);
    }
}
