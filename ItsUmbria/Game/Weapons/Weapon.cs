using ItsUmbria.Game.Abstractions;

namespace ItsUmbria.Game.Weapons
{
    public abstract class Weapon : GameObject
    {
        public int Damage { get; set; }
        public int Ammo { get; set; } = 10;

        public void AddAmmo(int ammo)
        {
            Ammo += ammo;
        }
    }
    public enum WeaponType
    {
        Knife,
        Gun,
        AssaultRifle,
        SniperRifle
    }
}
