using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Heroes;
using System;

namespace ItsUmbria.Library.OnlineGame.Weapons
{
    public abstract class Weapon : GameObject, IAttacking
    {
        public Weapon(WeaponType weaponType) => WeaponType = weaponType;
        public WeaponType WeaponType { get; }
        public abstract int MaxDamage { get; }
        public abstract int MinDamage { get; }
        public virtual int Range { get; } = 1;
        public abstract int AccuracyPercentage { get; }
        public virtual bool Attack(GameObject target)
        {
            Random random = new Random((int)DateTime.UtcNow.Ticks);
            double targetDistance = (int)GetTargetDistance(target);
            if (target is Hero hero && targetDistance <= Range)
            {
                if (random.Next(0, 100) / targetDistance < AccuracyPercentage)
                {
                    hero.GetDamage(random.Next(this.MinDamage, this.MaxDamage + 1));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private double GetTargetDistance(GameObject target) => this.Position.Distance(target.Position).Magnitude;
    }
}
