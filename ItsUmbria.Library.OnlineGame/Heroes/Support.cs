using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Library.OnlineGame.Heroes
{
    public class Support : Hero
    {
        public Support(string name) : base(name, HeroClass.Support) { }
        public override int MaxHealth => 100;
        public override double Speed => 5;
        public override int Cooldown => 3;
        protected override bool DoSpecialAbility(GameObject target, int intensity)
        {
            if (target is Hero hero)
            {
                hero.GetHealing(50);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
