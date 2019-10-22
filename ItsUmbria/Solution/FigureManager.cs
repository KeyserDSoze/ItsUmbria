using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Solution
{
    public class FigureManager : ITest
    {
        public void Do()
        {
            IAreable areable = new IsosceleTriangle();
            areable.CalculateArea();
            IPerimeterable perimeterable = new Hexagon();
            perimeterable.CalculatePerimeter();
            ILineable lineable = new Line();
            lineable.CalculateLine();
        }
    }
}
