using ItsUmbria.Game.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Game.Weapons
{
    public class WeaponFactory
    {
        public Weapon GetWeapon(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Knife:
                    return new Knife();
                case WeaponType.Gun:
                    return new Gun();
                case WeaponType.AssaultRifle:
                    return new AssaultRifle();
                case WeaponType.SniperRifle:
                    return new SniperRifle();
                default:
                    return null;               
            }
        }
    }
}
