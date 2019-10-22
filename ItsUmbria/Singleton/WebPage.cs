using System;
using System.Collections.Generic;
using System.Text;

//Link utili
//https://www.dofactory.com/net/singleton-design-pattern


/// <summary>
/// Il Singleton è il motivo per cui ogni tanto le macchine vanno riavviate. Un singleton che sfarfalla e che non è temporalizzato,
/// può essere tolto solo tramite il riavvio della macchina. Ecco svelato il segreto di Windows e dei suoi mille riavvi, troppi Singleton
/// fatti male.
/// </summary>
namespace ItsUmbria.Singleton
{
    /// <summary>
    /// Classe per eseguire il test nella nostra Console App
    /// </summary>
    public class WebPageSingleton : ITest
    {
        public void Do()
        {
            WebPage webPage = WebPage.Instance();
            WebPage webPage2 = WebPage.Instance();
            WebPage webPage3 = WebPage.Instance();
            webPage = WebPage.InstanceAsParameter;
            webPage2 = WebPage.InstanceAsParameter;
            webPage3 = WebPage.InstanceAsParameter;
        }
    }
    public class WebPage
    {
        //Oggetto statico dove sarà salvata la nostra unica istanza (da qui il nome Singleton) (unica posizione di memoria)
        private static WebPage SingletonedWebPage;
        //Proprietà del nostro modello
        public string Color { get; set; }
        //Proprietà del nostro modello
        public string Html { get; set; }
        //Tempo di scadenza dell'istanza in Ticks (i clock della nostra CPU dal 1 Gennaio dell'anno 1).
        private long ExpiringDate = DateTime.UtcNow.AddSeconds(Seconds).Ticks;
        //Oggetto statico che ci permette di creare una posizione di memoria per tutti uguali per eseguire un lock, e creare una coda di accesso.
        private readonly static object TrafficLight = new object();
        //Costante utilizzata al momento della creazione della ExpiringDate
        private const int Seconds = 5;
        /// <summary>
        /// Prendiamo l'istanza tramite un metodo
        /// </summary>
        /// <returns>L'unica istanza di WebPage</returns>
        public static WebPage Instance()
        {
            //Il controllo va a vedere se la variabile è nulla, e quindi non è nell'heap, 
            //oppure se il tempo trascorso dalla prima creazione dell'istanza è scaduto,
            //se andate a vedere sopra, ExpiringDate è un campo privato della vostra istanza generato
            //come autovalore ogni volta che un'istanza è creata nuovamente.
            //Il valore di expiring è il momento della creazione più i secondi (in questo caso) della scadenza
            if (SingletonedWebPage == null || DateTime.UtcNow.Ticks > SingletonedWebPage.ExpiringDate)
            {
                //TrafficLight, letteralmente semaforo (non serve di chiamarlo così), permette di essere lockato perchè
                //è uno static object, quindi viene creato solo una volta nell'heap ed il puntamento di memoria è lo stesso per tutti sempre.
                //Quindi chiunque entri in questo metodo, deve per forza mettersi in coda qui, aspettando il proprio turno di accesso a quel
                //punto di memoria
                lock (TrafficLight)
                {
                    //Dopo essere passati dal semaforo per sicurezza sulle contemporaneità viene messo lo stesso controllo eseguito prima
                    //Questo doppio controllo evita che dei thread messi in coda sul nostro semaforo creino il nostro oggetto più di una volta.
                    if (SingletonedWebPage == null || DateTime.UtcNow.Ticks > SingletonedWebPage.ExpiringDate)
                    {
                        //Creazione della nuova istanza di WebPage e posizionamento dentro una variabile statica.
                        //Questo ci permette di avere la nostra istanza dentro una posizione di memoria ben specifica, sarà sempre quella.
                        SingletonedWebPage = new WebPage()
                        {
                            Color = "#444",
                            Html = "<html></html>"
                        };
                    }
                }
            }
            return SingletonedWebPage;
        }
        /// <summary>
        /// Prendiamo l'istanza tramite una proprietà
        /// </summary>
        public static WebPage InstanceAsParameter
        {
            get
            {
                //Vedi sopra, tanto valgono le stesse cose. Questa proprietà serve solo a far vedere che era possibile fare
                //il Singleton anche tramite una proprietà (è un doppione di quello visto sopra).
                if (SingletonedWebPage == null || DateTime.UtcNow.Ticks > SingletonedWebPage.ExpiringDate)
                {
                    lock (TrafficLight)
                    {
                        if (SingletonedWebPage == null || DateTime.UtcNow.Ticks > SingletonedWebPage.ExpiringDate)
                        {
                            SingletonedWebPage = new WebPage()
                            {
                                Color = "#444",
                                Html = "<html></html>"
                            };
                        }
                    }
                }
                return SingletonedWebPage;
            }
        }
    }
}
