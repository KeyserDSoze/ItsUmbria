using ItsUmbria.Game.Abstractions;
using ItsUmbria.Game.Weapons;
using System;
using System.Collections.Generic;

namespace ItsUmbria.Game.Heroes
{
    #region Heroes
    public abstract class Hero : GameObject
    {
        private static readonly WeaponFactory weaponFactory = new WeaponFactory();
        public Hero(HeroClass heroClass)
        {
            Class = heroClass;
        }
        public HeroClass Class { get; }
        public int Health { get; private set; } = 100;
        // Flyweight
        public Dictionary<WeaponType, Weapon> Weapons { get; } = new Dictionary<WeaponType, Weapon>();
        public void PickWeapon(WeaponType weaponType)
        {
            if (!Weapons.TryGetValue(weaponType, out Weapon weapon))
            {
                Weapons.Add(weaponType, weaponFactory.GetWeapon(weaponType));
            }
            else
            { 
                weapon.AddAmmo(10);
            }
        }
        public void DropWeapon(WeaponType weaponType)
        {
            if (Weapons.ContainsKey(weaponType))
            {
                Weapons.Remove(weaponType);
            }
        }
    }
    public enum HeroClass
    {
        Tank,
        Damage,
        Support
    }
    #endregion
}
