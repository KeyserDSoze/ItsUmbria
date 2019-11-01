using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;

namespace ItsUmbria.Library.OnlineGame.Heroes
{
    public class Tank : Hero
    {
        public Tank(string name) : base(name, HeroClass.Tank) { }
        public override int MaxHealth => 150;
        public override double Speed => 4;
        public override int Cooldown => 3;
        protected override bool DoSpecialAbility(GameObject target, int intensity)
        {
            this.GetHealing(10);
            return true;
        }
    }
}
