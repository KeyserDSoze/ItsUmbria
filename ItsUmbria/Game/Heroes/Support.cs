using ItsUmbria.Game.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Game.Heroes
{
    public class Support : Hero
    {
        public Support(string name) : base(HeroClass.Tank)
        {
            Name = name;
        }
        public override string Name { get; }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
