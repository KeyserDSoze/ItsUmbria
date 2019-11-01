using ItsUmbria.Library.OnlineGame.Enum;

namespace ItsUmbria.Library.OnlineGame.Weapons
{
    public class Socom : RangedWeapon
    {
        public Socom() : base(WeaponType.Gun) { }
        public override int MaxAmmo => 20;
        public override int MaxDamage => 30;
        public override int MinDamage => 20;
        public override int Range => 15;
        public override int AmmoConsumption => 2;
        public override int AccuracyPercentage => 60;
    }
}
