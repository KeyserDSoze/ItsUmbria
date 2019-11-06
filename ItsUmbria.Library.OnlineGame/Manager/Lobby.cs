using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItsUmbria.Library.OnlineGame.Manager
{
    public class Lobby : GameObject, IPrintable
    {
        public Lobby(string id) : base(id)
        {
            teams.Enqueue(new Team(TeamColor.Red));
            teams.Enqueue(new Team(TeamColor.Blue));
        }
        private static readonly Dictionary<string, Lobby> lobbyes = new Dictionary<string, Lobby>();
        private readonly static object trafficlight = new object();
        private readonly Queue<Team> teams = new Queue<Team>();
        public static List<Lobby> Lobbies => lobbyes.Values.ToList();
        public static Lobby GetInstance(string id)
        {
            if (!lobbyes.ContainsKey(id)) 
            {
                lock (trafficlight)
                {
                    if (!lobbyes.ContainsKey(id))
                    {
                        lobbyes.Add(id, new Lobby(id));
                    }
                }
            }
            return lobbyes[id];
        }
        public static Lobby Restart(string id)
        {
            Lobby.Delete(id);
            return Lobby.GetInstance(id);
        }
        public static bool Delete(string id)
        {
            if (lobbyes.ContainsKey(id))
            {
                lock (trafficlight)
                {
                    if (lobbyes.ContainsKey(id))
                    {
                        lobbyes.Remove(id);
                        return true;
                    }
                }
            }
            return false;
        }
        public Team CurrenTeam => teams.Peek();
        public List<Hero> Members => teams.SelectMany(x => x.Members.Values).ToList();
        public Team TeamBlue => teams.Where(x => x.Name == TeamColor.Blue.ToString()).FirstOrDefault();
        public Team TeamRed => teams.Where(x => x.Name == TeamColor.Red.ToString()).FirstOrDefault();
        public Team GetTeam(TeamColor color) => teams.Where(x => x.Name == color.ToString()).FirstOrDefault();
        public Hero GetHero(string heroName) => teams.SelectMany(x => x.Members.Values).Where(x => x.Name == heroName).FirstOrDefault();
        public Hero JoinTeam(Hero hero, TeamColor color) => !Members.Any(x => x.Name == hero.Name)
                ? this.GetTeam(color).Join(hero)
                : Members.Where(x => x.Name == hero.Name).FirstOrDefault();
        public bool LeaveTeam(string heroName, TeamColor color) => this.GetTeam(color).Leave(heroName);
        public Team EndTurn()
        {
            Team temp = teams.Dequeue();
            teams.Enqueue(temp);
            foreach (Hero hero in CurrenTeam.Members.Values)
            {
                hero.RestoreActions();
                hero.DecreaseCoolDownIfNeeded();
            }
            return CurrenTeam;
        }
    }
}
