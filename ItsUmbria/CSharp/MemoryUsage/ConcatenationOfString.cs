using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.MemoryUsage
{
    public class ConcatenationOfString : ITest
    {
        /// <summary>
        /// Concatenare tramite += è un enorme perdita di efficenza, e qui potete testare anche di quanto.
        /// </summary>
        public void Do()
        {
            DateTime start = DateTime.UtcNow;
            string test = string.Empty;
            for (int i = 0; i < 100000; i++)
                test += i.ToString();
            //Qui creo una marea di sporcizia nell'heap che avrà un doppio problema, la creazione di un oggeto di Heap
            //è lenta, ed inoltre dovrà passare il GC (Garbage Collector) a fare pulizia di tutto.
            Console.WriteLine(DateTime.UtcNow.Subtract(start).TotalSeconds.ToString() + " seconds.");
            start = DateTime.UtcNow;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 100000; i++)
                stringBuilder.Append(i.ToString());
            Console.WriteLine(DateTime.UtcNow.Subtract(start).TotalSeconds + " seconds.");
            //La differenza facendo il test è enorme, lo stringbuilder genera un buffer che occupa un solo punto di memoria nell'heap
            //la concatenzione avviene tramite espansione di questo punto di memoria.
        }
    }
}
