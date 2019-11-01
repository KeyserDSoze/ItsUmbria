using ItsUmbria.Library.OnlineGame.Enum;

namespace ItsUmbria.Library.OnlineGame.Weapons
{
    public class M16 : RangedWeapon
    {
        public M16() : base(WeaponType.AssaultRifle) { }
        public override int MaxAmmo => 100;
        public override int MaxDamage => 50;
        public override int MinDamage => 40;
        public override int Range => 30;
        public override int AmmoConsumption => 20;
        public override int AccuracyPercentage => 70;
    }
}
