using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Solution
{
    /// <summary>
    /// 
    /// </summary>
    public class IsosceleTriangle : Triangle, IPerimeterable, IAreable
    {
        /// <summary>
        /// Override del metodo astratto di Triangle, per permettere ad ogni tipologia di triangolo di calcolarsi
        /// a proprio modo l'altezza.
        /// </summary>
        /// <returns></returns>
        public override int GetHeight()
        {
            Console.WriteLine("Calculate Isoscele's height");
            return 0;
        }
    }
}
