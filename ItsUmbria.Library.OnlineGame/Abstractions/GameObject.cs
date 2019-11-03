using System;
using System.Linq;
using System.Text;

namespace ItsUmbria.Library.OnlineGame.Abstractions
{
    public abstract class GameObject : IPrintable
    {
        protected GameObject(string name) => Name = name;
        public string Type => this.GetType().Name;
        public string Name { get; protected set; }
        public virtual void Print() => Console.WriteLine($"Object Name:{this.Name}");
    }
    
}
