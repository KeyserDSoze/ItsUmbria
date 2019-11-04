using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;

namespace ItsUmbria.Library.OnlineGame.Heroes
{
    public class Damage : Hero
    {
        protected int cooldown = 5;
        public Damage(string name) : base(name, HeroClass.Damage) { }

        public override int MaxHealth => 100;
        public override double Speed => 6;

        public override int Cooldown => 5;
        protected override bool DoSpecialAbility(RigidBody target, int intensity) => base.Attack(target) & base.Attack(target);
    }
}
