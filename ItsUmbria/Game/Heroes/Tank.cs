using ItsUmbria.Game.Abstractions;

namespace ItsUmbria.Game.Heroes
{
    public class Tank : Hero
    {
        public Tank(string name) : base(HeroClass.Tank)
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
