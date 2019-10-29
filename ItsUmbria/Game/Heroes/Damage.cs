using ItsUmbria.Game.Abstractions;

namespace ItsUmbria.Game.Heroes
{
    public class Damage : Hero
    {
        public Damage(string name) : base(HeroClass.Damage)
        {
            Name = name;
        }
        public override string Name { get; }

        public override void Print()
        {
            throw new System.NotImplementedException();
        }
    }
}
