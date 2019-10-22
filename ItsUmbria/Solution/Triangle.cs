using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Solution
{
    /// <summary>
    /// Astrazione di un'astrazione, creazione di un nuovo concetto non istanziabile.
    /// Il concetto di triangolo come un oggetto non reale (non istanziabile), i suoi oggetti reali
    /// sono cose come il triangolo isoscele.
    /// </summary>
    public abstract class Triangle : Figure, IPerimeterable, IAreable
    {
        /// <summary>
        /// Predispongo il metodo per calcolare l'altezza in ogni triangolo che estenderà la mia classe Triangle
        /// </summary>
        /// <returns></returns>
        public abstract int GetHeight();
        public int CalculateArea()
        {
            //Nel calcolo dell'area utilizzo il metodo GetHeight() sperando che la mia classe concreta lo abbia implementato
            //andate a vedere la classe Isoscele e troverete l'override del metodo GetHeight()
            this.GetHeight();
            Console.WriteLine("Area of Triangle");
            return 0;
        }

        public int CalculatePerimeter()
        {
            Console.WriteLine("Perimeter of Triangle");
            return 0;
        }
    }
}
