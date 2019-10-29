using ItsUmbria.Game.Levels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Fps
{
    public class GameManager : ITest
    {
        public void Do()
        {
            Game.Heroes.Hero hero = Level.GetInstance().GetHero("Solid Snake", Game.Heroes.HeroClass.Damage);
        }
    }
}
