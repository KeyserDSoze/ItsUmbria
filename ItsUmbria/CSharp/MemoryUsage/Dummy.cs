using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.MemoryUsage
{
    /// <summary>
    /// Modello per eseguire il test di memoria
    /// </summary>
    public class Dummy
    {
        public string A = "MyA";
        public static string B = "MyB";
    }
    /// <summary>
    /// Test sulla memoria
    /// </summary>
    public class DummyTester : ITest
    {
        //Salvo una mia istanza Dummy in un campo statico, quindi gli do lo stesso punto di memoria per tutti quelli che lo accederanno.
        static Dummy Dummy = new Dummy();
        //Faccio la stessa cosa di Dummy per questo oggetto string.
        static string Immutable = "Immutable";
        public void Do()
        {
            //Creo una variabile in un metodo che prende lo stesso percorso di memoria
            Dummy c = Dummy;
            //Modifico tramite la mia variabile l'istanza
            c.A += "AddedValue";
            //Mi troverò sia la variabile
            Console.WriteLine(c.A);
            //che la mia istanza static di Dummy modificati
            Console.WriteLine(Dummy.A);
            //Ora provo a fare la stessa cosa con string. Creo una variabile e ci metto la mia static string
            string d = Immutable;
            //vado a fare una concatenazione di stringhe
            d += "AddedValue";
            //in questo caso vedrò d che si è modificata
            Console.WriteLine(d);
            //ma non la mia static string Immutable, perchè la stringa è una cosa speciale, è un oggetto immutabile
            //che al momento dell'assegnazione string d = Immutable, crea un nuovo punto di memoria nell'heap per d con il valore del percorso
            //di memoria di Immutable (il valore non il punto di memoria). Questi due oggetti quindi sono due cose differenti.
            Console.WriteLine(Immutable);
            //Provo ora a prendere una stringa statica all'interno della mia classe Dummy
            string e = Dummy.B;
            //posso vedere con facilità che ottengo lo stesso risultato
            e += "AddedValue";
            //questo ci fa capire che la stringa lavora per modo suo e che lo static estrapola dal contesto della propria classe la variabile
            //cioè, "static string B" non è un qualcosa che troverò nell'heap (nella memoria) della mia istanza Dummy, ma lo troverò in un altro percorso
            //di memoria, rendendo di fatto la classe Dummy solo un'estensione di namespace 
            Console.WriteLine(e);
            Console.WriteLine(Dummy.B);
        }
    }
}
