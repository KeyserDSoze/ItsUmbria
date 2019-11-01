using ItsUmbria.Library.OnlineGame.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Library.OnlineGame.Abstractions
{
    interface IAttacking
    {
        bool Attack(GameObject target);
    }
}
