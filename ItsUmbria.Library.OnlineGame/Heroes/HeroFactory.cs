using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Library.OnlineGame.Heroes
{
    class HeroFactory
    {
        public Hero Create(HeroClass heroClass, string Name)
        {
            switch (heroClass)
            {
                case HeroClass.Tank:
                    return new Tank(Name);
                case HeroClass.Damage:
                    return new Damage(Name);
                case HeroClass.Support:
                    return new Support(Name);
                default:
                    return null;
            }
        }
    }
}
