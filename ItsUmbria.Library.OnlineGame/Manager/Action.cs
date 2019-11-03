using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Library.OnlineGame.Manager
{
    public class Action
    {
        public Action(ActionType type, Hero hero, RigidBody target, int intensity, Vector vector)
        {
            Type = type;
            Hero = hero;
            Target = target;
            Intensity = intensity;
            Vector = vector;
        }
        public ActionType Type { get; }
        public Hero Hero { get; }
        public RigidBody Target { get; }
        public int Intensity { get; }
        public Vector Vector { get; }
        public bool Do() => Hero.DoAction(Type, Target, Intensity, Vector);
    }
}
