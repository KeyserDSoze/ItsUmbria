using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Noe
{
    public class Cat : Animal, ICarnivore
    {
        public Cat(string name, string surname) : base(name, surname)
        {
        }

        public void Feed(double x)
        {
            Console.WriteLine($"{this.Name} {this.Surname} eats {x} as a Cat");
        }
    }
}
