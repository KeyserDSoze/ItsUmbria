using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Noe
{
    public class Elephant : Animal, IHerbivore
    {
        public Elephant(string name, string surname) : base(name, surname)
        {
        }
        public void Feed(int x)
        {
            Console.WriteLine($"{this.Name} {this.Surname} eats {x} as an Elephant");
        }
    }
}
