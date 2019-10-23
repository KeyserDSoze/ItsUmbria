using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Noe
{
    public class ArcaTest : ITest
    {
        public void Do()
        {
            Arca.Instance.FeedCarnivore(4D);
            Arca.Instance.FeedHerbivore(3);
        }
    }
    public class Arca
    {
        private List<ICarnivore> Carnivores;
        private List<IHerbivore> Herbivores;
        private static Arca _Arca;
        public Arca()
        {
            this.Carnivores = new List<ICarnivore>();
            this.Carnivores.Add(new Cat("Micio", "Gatto"));
            this.Herbivores = new List<IHerbivore>();
            this.Herbivores.Add(new Elephant("Ele", "Fante"));
        }
        public static Arca Instance
        {
            get
            {
                if (_Arca == null)
                {
                    _Arca = new Arca();
                }
                return _Arca;
            }
        }
        public void FeedHerbivore(int x)
        {
            foreach (IHerbivore herbivore in this.Herbivores)
            {
                herbivore.Feed(x);
            }
        }
        public void FeedCarnivore(double x)
        {
            foreach (ICarnivore carnivore in this.Carnivores)
            {
                carnivore.Feed(x);
            }
        }
        //Questa è una cosa fatta male
        //public List<Animal> animals = new List<Animal>();
        //public void TestHerbivoreFeeding(int x) 
        //{
        //    foreach(Animal animal in animals) 
        //    {
        //        if(animal is IHerbivore) 
        //        {
        //            (animal as IHerbivore).Feed(x);
        //        }
        //    }
        //}
    }
}
