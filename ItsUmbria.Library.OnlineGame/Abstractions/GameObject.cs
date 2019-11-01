using System;
using System.Linq;
using System.Text;

namespace ItsUmbria.Library.OnlineGame.Abstractions
{
    public abstract class GameObject : IPrintable, IMovable
    {
        public string Type => this.GetType().Name;
        public string Name { get; protected set; }
        public Vector Position { get; set; } = new Vector(0, 0);
        public virtual void Move(Vector distance) => Position += distance;
        public virtual void Print() => Console.WriteLine($"Object Name:{this.Name}");
    }
    
}
