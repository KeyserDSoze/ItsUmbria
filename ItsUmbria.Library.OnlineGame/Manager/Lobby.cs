﻿using ItsUmbria.Library.OnlineGame.Abstractions;
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
        public Lobby() : base(Guid.NewGuid().ToString())
        {
            teams.Enqueue(new Team(TeamColor.Red));
            teams.Enqueue(new Team(TeamColor.Blue));
        }
        private static Lobby lobby = null;
        private readonly static object trafficlight = new object();
        private readonly Queue<Team> teams = new Queue<Team>();
        public static Lobby Instance
        {
            get
            {
                if (lobby == null) lock (trafficlight) lobby = new Lobby();
                return lobby;
            }
        }
        public static Lobby Restart()
        {
            lobby = null;
            return Lobby.Instance;
        }
        public Team CurrenTeam => teams.Peek();
        public List<Hero> Members => teams.SelectMany(x => x.Members.Values).ToList();
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