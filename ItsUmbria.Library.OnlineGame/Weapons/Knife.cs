using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Library.OnlineGame.Weapons
{
    public class Knife : Weapon
    {
        public Knife() : base(WeaponType.Melee) {}
        public override int MaxDamage => 30;
        public override int MinDamage => 20;
        public override int Range => 1;
        public override int AccuracyPercentage => 90;
    }
}
