using ItsUmbria.Fps;
using ItsUmbria.Game.Abstractions;
using ItsUmbria.Game.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Game.Levels
{
    public class TrainingRoom
    {
        private static readonly HeroFactory heroFactory = new HeroFactory();
        private static TrainingRoom instance = null;
        public static TrainingRoom GetInstance()
        {
            if (instance == null)
            {
                instance = new TrainingRoom();
            }
            return instance;
        }
        private readonly Dictionary<string, Hero> heroesInGame = new Dictionary<string, Hero>();
        public Hero GetHero(string name, HeroClass heroClass)
        {
            if (!heroesInGame.TryGetValue(name, out Hero hero))
            {
                hero = heroFactory.Create(heroClass, name);
                heroesInGame.Add(name, hero);
            }
            return hero;
        }
    }
}
