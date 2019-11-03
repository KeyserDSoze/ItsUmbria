using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Heroes;
using System;

namespace ItsUmbria.Library.OnlineGame.Weapons
{
    public abstract class RangedWeapon : Weapon, IRanged, IAttacking
    {
        public RangedWeapon(WeaponType weaponType) : base(weaponType) => Ammo = MaxAmmo;
        public abstract int MaxAmmo { get; }
        public override abstract int Range { get; }
        public int Ammo { get; protected set; }
        public abstract int AmmoConsumption { get; }
        public override bool Attack(RigidBody target)
        {
            if (Ammo > 0)
            {
                Ammo = Ammo - AmmoConsumption < 0 ? 0 : Ammo -AmmoConsumption;
                return base.Attack(target);
            }
            return false;
        }
        public void Reload(int ammo = 0) => Ammo = ammo <= 0 ? MaxAmmo : Ammo + ammo > MaxAmmo ? MaxAmmo : Ammo + ammo; // Chi la capisce questa espressione condizionale?
    }
    public abstract class MeleeWeapon : Weapon, IAttacking
    {
        public MeleeWeapon(WeaponType weaponType) : base(weaponType) { }
    }
}
