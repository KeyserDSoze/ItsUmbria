using ItsUmbria.Game.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Game.Weapons
{
    public class Knife : Weapon
    {
        public override string Name { get; } = "Knife";

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
