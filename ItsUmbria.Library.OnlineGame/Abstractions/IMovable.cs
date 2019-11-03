using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Library.OnlineGame.Abstractions
{
    public interface IMovable
    {
        bool Move(Vector distance);
    }
}
