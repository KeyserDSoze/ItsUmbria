using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Solution
{
    /// <summary>
    /// Interfaccia che permette di dare ad un oggetto la possibilità di avere un comportamento di tipo figura geometrica con area.
    /// Le interfacce sono da vedere come delle maschere.
    /// </summary>
    public interface IAreable
    {
        int CalculateArea();
    }
}
