using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CSharp
{
    public class GenericDictionary : ITest
    {
        public void Do()
        {
            Dictionary<int, int> dictionaryOfIntegers = new Dictionary<int, int>();
            dictionaryOfIntegers.Add(3, 4);
            dictionaryOfIntegers.Add(5, 6);
            foreach (KeyValuePair<int, int> keyValuePair in dictionaryOfIntegers)
            {
                Console.WriteLine(keyValuePair.Key);
                Console.WriteLine(keyValuePair.Value);
            }

            Dictionary<int, Animal> animals = new Dictionary<int, Animal>();
            animals.Add(1, new Animal());
            animals.Add(2, new Animal());
            foreach (KeyValuePair<int, Animal> animal in animals)
            {
                Console.WriteLine(animal.Key);
                Console.WriteLine(animal.Value);
            }

            Dictionary<int, IHerbivore> herbivores = new Dictionary<int, IHerbivore>();
            herbivores.Add(1, new Animal());
            herbivores.Add(2, new Animal());
            foreach (KeyValuePair<int, IHerbivore> herbivore in herbivores)
            {
                Console.WriteLine(herbivore.Key);
                Console.WriteLine(herbivore.Value);
            }
        }
    }
}
