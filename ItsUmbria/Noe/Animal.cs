using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Noe
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Animal(string name, string surname) 
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}
