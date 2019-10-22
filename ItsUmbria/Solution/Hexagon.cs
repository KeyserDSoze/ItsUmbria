using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Solution
{
    /// <summary>
    /// Classe di esempio dell'esagono
    /// </summary>
    public class Hexagon : Figure, IAreable, IPerimeterable
    {
        public int CalculateArea()
        {
            Console.WriteLine("Calculate area of Hexagon");
            return 0;
        }

        public int CalculatePerimeter()
        {
            Console.WriteLine("Calculate perimeter of Hexagon");
            return 0;
        }
    }
}
