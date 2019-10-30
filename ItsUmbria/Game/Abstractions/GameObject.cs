using System;
using System.Linq;
using System.Text;

namespace ItsUmbria.Game.Abstractions
{
    public abstract class GameObject
    {
        public string Type => this.GetType().Name;
        public virtual string Name { get; }
        public Vector Position { get; set; } = new Vector(0, 0);
        public virtual void Print() => Console.WriteLine($"Object Name:{this.Name}");
    }
    public struct Vector
    {
        public static Vector Zero = new Vector(0, 0);
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; }
        public double Y { get; }
    }
    
}
