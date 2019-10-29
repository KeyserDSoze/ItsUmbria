using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.MemoryUsage
{
    /// <summary>
    /// Un oggetto immutabile è un oggetto che permette di impostare valori solo tramite il proprio costruttore.
    /// Quindi per avere una modifica dei suoi valori deve avere per forza una nuova istanza.
    /// La classe simula una classe string.
    /// </summary>
    public class ImmutableObject
    {
        private char[] Values;
        public string Value
        {
            get
            {
                return new string(Values);
            }
        }
        public ImmutableObject(char[] values)
        {
            this.Values = values;
        }
    }
}
