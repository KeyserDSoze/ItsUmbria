using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CSharp
{
    public class GenericList : ITest
    {
        public void Do()
        {
            List<int> integers = new List<int>();
            integers.Add(3);
            integers.Add(5);
            foreach(int integer in integers) 
            {
                Console.WriteLine(integer);
            }

            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal());
            animals.Add(new Animal());
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }

            List<IHerbivore> herbivores = new List<IHerbivore>();
            herbivores.Add(new Animal());
            herbivores.Add(new Animal());
            foreach (IHerbivore animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
    public class Animal : IHerbivore
    {
    
    }
    public interface IHerbivore { }
}
