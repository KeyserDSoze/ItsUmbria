using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItsUmbria.Library.OnlineGame.Manager
{
    public class Team : GameObject, IPrintable
    {
        public Team(TeamColor color) : base(color.ToString()) { }
        public Dictionary<string, Hero> Members = new Dictionary<string, Hero>();
        public int Frags { get; private set; } = 0;
        public void MoreFrags(int frags) => Frags += frags;
        internal Hero Join(Hero hero)
        {
            if (!Members.ContainsKey(hero.Name))
            {
                Members.Add(hero.Name, hero);
            }
            return Members[hero.Name];
        }
        internal bool Leave(string heroName)
        {
            if (!Members.ContainsKey(heroName))
            {
                Members.Remove(heroName);
                return true;
            }
            return false;
        }
        public Hero this[string name] => Members.TryGetValue(name, out Hero hero) ? hero : Members.FirstOrDefault().Value ?? null;
        public Hero this[HeroClass heroClass, string name] => Members.Where(x => x.Value.Class == heroClass).FirstOrDefault(x => x.Key == name).Value ?? null;
        public List<Hero> this[HeroClass heroClass] => Members.Where(x => x.Value.Class == heroClass).Select(x => x.Value).ToList();
    }
}
