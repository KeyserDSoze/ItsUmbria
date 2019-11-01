using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Library.OnlineGame.Weapons
{
    public class WeaponFactory
    {
        public Weapon GetWeapon(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Melee:
                    return new Knife();
                case WeaponType.Gun:
                    return new Socom();
                case WeaponType.AssaultRifle:
                    return new M16();
                case WeaponType.SniperRifle:
                    return new Barret();
                default:
                    return null;               
            }
        }
    }
}
