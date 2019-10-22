using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Stuff
{
    /// <summary>
    /// Capisco al volo che la mia classe cavallo è un animale ed ha il dono della corsa.
    /// </summary>
    public class Horse : Animal, IRunnable
    {
       
        public void Run()
        {
            Console.WriteLine("Run");
        }
        public void Make(string a, string b) 
        {
        
        }
    }
}
