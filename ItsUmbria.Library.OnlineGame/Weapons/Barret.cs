using ItsUmbria.Library.OnlineGame.Enum;

namespace ItsUmbria.Library.OnlineGame.Weapons
{
    public class Barret : RangedWeapon
    {
        public Barret() : base(WeaponType.SniperRifle) { }
        public override int MaxAmmo => 1;
        public override int Range => 100;
        public override int MaxDamage => 60;
        public override int MinDamage => 40;
        public override int AmmoConsumption => 1;
        public override int AccuracyPercentage => 90;
    }
}
