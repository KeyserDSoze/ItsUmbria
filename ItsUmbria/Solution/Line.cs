using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Solution
{
    /// <summary>
    /// Implementazione di una figura geometrica come la linea, con il suo calcolo della lunghezza
    /// </summary>
    public class Line : Figure, ILineable
    {
        public int CalculateLine()
        {
            Console.WriteLine("Line");
            return 0;
        }
    }
}
