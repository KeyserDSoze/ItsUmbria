using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Stuff
{
    public abstract class Animal
    {
        public string Name { get; set; }
        //È errato creare dei metodi astratti che non sono implementabili da tutti gli animali,
        //è sempre meglio utilizzare delle interfacce per dargli questi comportamenti.
        //public abstract void Run();
        //public abstract void Fly();
    }
    /// <summary>
    /// Esempio di un animale che non sarebbe riuscito ne a correre Run(), ne a volare Fly()
    /// </summary>
    public class SimpleFish : Animal
    {
 
    }
}
