using Gioco.Core.Entità;
using Gioco.Service;
using Microsoft.Extensions.DependencyInjection;
using MockRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Gioco
{
    public static class Partita
    {
        private static ServiceProvider serviceProvider = Configurazone.Configurazione();
        private static EroeService eroeservice = serviceProvider.GetService<EroeService>();
        private static GiocatoreService giocatoreService = serviceProvider.GetService<GiocatoreService>();
        private static MostroService mostroService = serviceProvider.GetService<MostroService>();
        private static ArmaService armaService = serviceProvider.GetService<ArmaService>();
        private static ClasseService classeService = serviceProvider.GetService<ClasseService>();
        private static LivelloService livelloService = serviceProvider.GetService<LivelloService>();


        public static bool ControlloGiocatore(Giocatore giocatore, List<Giocatore> listaGiocatori)
        {
            //Controllo sul giocatore

            foreach (var item in listaGiocatori)
            {
                if (giocatore.Nome == item.Nome)
                {
                    giocatore.ID = item.ID;
                    giocatore.Ruolo = item.Ruolo;
                    Console.WriteLine("Bentornato!");
                    return true;
                }
            }

            giocatore.Ruolo = "Utente";
            giocatoreService.CreateGiocatore(giocatore);
            Console.WriteLine("La registrazione è stata effettuata!");

            return true;
    
        }
        public static Eroe CreazioneEroe(Giocatore giocatore, List<Classe> listaClassi, List<Arma> listaArmi, List<Eroe> listaEroi)
        {
            Eroe eroe = new Eroe();
            Console.WriteLine("Inserisci il Nome");
            string nome = Console.ReadLine();
            int e = 0;
            do
            {
                foreach (var item in listaEroi)
                {
                    if (item.Nome == nome)
                    {
                        Console.WriteLine("Nome già presente! Inserisci un nuovo nome");
                        e = 0;
                        break;
                    }
                    else
                    {
                        e = 1;
                    }
                }
                
            } while (e == 0);
            eroe.Nome = nome;
            int x = 0;
            do
            {
                Console.WriteLine("Scegli la classe:");
                eroeservice.SceltaClasse(listaClassi);
                string classe = Console.ReadLine();

                eroe.Classe = classeService.GetClasse(classe);
                if (eroe.Classe.Nome == null)
                {
                    x = 0;
                    Console.WriteLine("Inserisci la classe corretta!");
                }
                else
                {
                    eroe.ClasseID = eroe.Classe.ID;
                    x = 1;
                }
            } while (x == 0);

            int y = 0;
            do
            {
                Console.WriteLine("Scegli l'arma:");
                armaService.SceltaArma(listaArmi, eroe);
                string arma = Console.ReadLine();
                eroe.Arma = armaService.GetArma(arma);
                if (eroe.Arma.Nome == null)
                {
                    y = 0;
                    Console.WriteLine("Inserisci la classe corretta!");
                }
                else
                {
                    eroe.ArmaID = eroe.Arma.ID;
                    y = 1;
                }
            } while (y == 0);
            eroe.Giocatore = giocatoreService.GetGiocatore(giocatore.Nome);
            eroe.GiocatoreID = giocatore.ID;
            eroe.Livello = livelloService.GetLivello(1);
            eroe.LivelloID = 1;

            eroeservice.CreateEroe(eroe);
            giocatore.ListaEroi.Add(eroe);

            return eroe;
        }
        public static bool CreazioneMostro(List<Mostro> listaMostri, List<Classe> listaClassi, List<Arma> listaArmi, List<Livello> listaLivelli)
        {
            Mostro mostro = new Mostro();
            Console.WriteLine("Inserisci il Nome");
            string nome = Console.ReadLine();
            int e = 0;
            do
            {
                foreach (var item in listaMostri)
                {
                    if (item.Nome == nome)
                    {
                        Console.WriteLine("Nome già presente! Inserisci un nuovo nome");
                        e = 0;
                        break;
                    }
                    else
                    {
                        e = 1;
                    }
                }

            } while (e == 0);
            mostro.Nome = nome;
            int x = 0;
            do
            {
                Console.WriteLine("Scegli la classe:");
                mostroService.SceltaClasse(listaClassi);
                string classe = Console.ReadLine();

                mostro.Classe = classeService.GetClasse(classe);
                if (mostro.Classe.Nome == null)
                {
                    x = 0;
                    Console.WriteLine("Inserisci la classe corretta!");
                }
                else
                {
                    mostro.ClasseID = mostro.Classe.ID;
                    x = 1;
                }
            } while (x == 0);

            int y = 0;
            do
            {
                Console.WriteLine("Scegli l'arma:");
                armaService.SceltaArma(listaArmi, mostro);
                string arma = Console.ReadLine();
                mostro.Arma = armaService.GetArma(arma);
                if (mostro.Arma.Nome == null)
                {
                    y = 0;
                    Console.WriteLine("Inserisci la classe corretta!");
                }
                else
                {
                    mostro.ArmaID = mostro.Arma.ID;
                    y = 1;
                }
            } while (y == 0);
            int  z= 0;
            do
            {
                Console.WriteLine("Scegli il livello:");
                livelloService.SceltaLivello(listaLivelli);
                int num = Int32.Parse(Console.ReadLine());
                mostro.Livello = livelloService.GetLivello(num);
                if (mostro.Arma.Nome == null)
                {
                    z = 0;
                    Console.WriteLine("Inserisci la classe corretta!");
                }
                else
                {
                    mostro.ArmaID = mostro.Arma.ID;
                    z = 1;
                }
            } while (z == 0);
            mostro.LivelloID = mostro.Livello.ID;

            mostroService.CreateMostro(mostro);
            return true;
        }
        public static void RicercaEroiGiocatore(Giocatore giocatore) 
        {
            List<Eroe> listaEroi = eroeservice.GetAllEroi().ToList();
            foreach (var item in listaEroi)
            {
                if (item.GiocatoreID == giocatore.ID)
                {
                    giocatore.ListaEroi.Add(item);
                }
            }
           
        }
        public static Eroe SceltaEroe(List<Eroe> eroi, Giocatore giocatore, List<Classe> listaClassi, List<Arma> listaArmi)
        {
            RicercaEroiGiocatore(giocatore);
  
            if (giocatore.ListaEroi.Count == 0)
            {
                Console.WriteLine("Non ci sono eroi nella tua lista, crea un eroe per giocare");
                Eroe eroe1 = CreazioneEroe(giocatore, listaClassi, listaArmi, eroi);
                Eroe eroe2 = eroeservice.CreateEroe(eroe1);
                return eroe2;
            }
            else
            {
                Console.WriteLine("Gli eroi nella tua lista sono:");
                foreach (var item in giocatore.ListaEroi)
                {
                    Console.WriteLine(item.Nome);
                }
                Console.WriteLine("Scegli tra:");
                Console.WriteLine("1 - usa un eroe dalla tua lista");
                Console.WriteLine("2 - crea un eroe");
                char a = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (a)
                {
                    case '1':
                        Console.WriteLine("inserisci il nome");
                        string Nome = Console.ReadLine();
                        Eroe eroe = eroeservice.GetEroeByName(Nome);
                        return eroe;
                    case '2':
                        Eroe eroe1 = CreazioneEroe(giocatore, listaClassi, listaArmi, eroi);
                        Eroe eroe2 = eroeservice.CreateEroe(eroe1);
                        return eroe2;
                    default:
                        Console.WriteLine("Scelta non disponibile! Torna al menù");
                        return null;
                }
            }
            
        }

        //ritorna true se la battaglia è finita, ritorna false se è il turno del mostro
        public static bool TurnoEroe(Eroe eroe, Mostro mostro)
        {
            Console.WriteLine("Scegli:");
            Console.WriteLine("1 - Attaccare il Mostro");
            Console.WriteLine("Premi un tasto per Tentare la fuga");

            char a = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (a)
            {
                case '1':
                    bool z = eroe.AttaccareMostro(eroe, mostro);
                    if (z == true)
                    {
                        Console.WriteLine("Il Mostro è morto");
                        //hai vinto la battaglia
                        eroe.PuntiAccumulati += (mostro.Livello.Num * 10);
                        //Controllo sul livello
                        eroe.LivelloID = eroe.Livello.DefinizioneLivello(eroe.PuntiAccumulati);
                        eroeservice.Update(eroe);
                        if(eroe.PuntiAccumulati >= 200)
                        {
                            //l'eroe ha vinto inserire un flag
                            eroe.Vittoria = true;
                            Console.WriteLine("Vittoria!!!!!!");
                            return true;
                        }
                        return true;
                    }
                    else
                    {
                        
                        //la battaglia continua
                        return false;
                    }

                default:
                    bool x = eroe.TentareFuga();
                    if (x == true)
                    {
                        Console.WriteLine("Tentativo riuscito sei scappato!");
                        eroe.PuntiAccumulati -= (mostro.Livello.Num * 5);
                        //battaglia finita
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Tentativo fallito! Turno del Mostro");
                        return false;
                    }

            }
        }

        //ritorna true se la battaglia è finita e false se è il turno del eroe
        public static bool TurnoMostro(Eroe eroe, Mostro mostro)
        {
            bool y = mostro.Attacco(eroe, mostro);
            if (y == true)
            {
                //non sei morto continua la battaglia
                return false;
            }
            //se y==false sei morto
            eroeservice.DeleteEroe(eroe);
            return true;
        }
       
        public static void VisualizzaEroi(List<Eroe> list,Giocatore g)
        {
            foreach (var item in list)
            {
                if(item.GiocatoreID == g.ID)
                Console.WriteLine(item.Nome);
            }
        }
        public static Mostro SceltaMostro(Eroe eroe)
        {
            IEnumerable<Mostro> listaMostri = mostroService.GetAllMostri();
            int count = 0;
            int livello = eroe.LivelloID;
            List<Mostro> lista = new List<Mostro>();
            foreach (var item in listaMostri)
            {
                if (item.LivelloID <= livello)
                {
                    lista.Add(item);
                    count++;
                }
            }
            Random random = new Random();
            int a = random.Next(1, count);
            Mostro mostro = mostroService.GetMostroByID(a);
            mostro.Arma = armaService.GetArmaByID(mostro.ArmaID);
            mostro.Classe = classeService.GetClasseByID(mostro.ClasseID);
            mostro.Livello = livelloService.GetLivello(mostro.LivelloID);

            return mostro;

        }

        public static int Battaglia(Eroe eroe, Mostro mostro)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int x = 0;
            do
            {
                bool y = Partita.TurnoEroe(eroe, mostro);
                //ritorna true se la battaglia è finita, ritorna false se è il turno del mostro
                if (y == true)
                {
                    Console.WriteLine("Vuoi salvare i tuoi progressi? Premi 1, altrimenti esci dal gioco");
                    char ex = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    switch (ex)
                    {
                        case '1':
                            stopWatch.Stop();
                            eroe.TempoDiGioco = stopWatch.Elapsed;
                            eroeservice.Update(eroe);
                            x= 1;
                            break;
                        default: x= 1;
                            break;
                    }
                }
                else
                {
                    bool z = Partita.TurnoMostro(eroe, mostro);
                    if (z == true)
                    {
                        //la battaglia è terminata e l'eroe è morto
                        x = 1;
                    }
                    else
                    {
                        x = 0;
                    }
                    
                    
                }
            } while (x == 0);
            return 0;
        }

        public static void VisualizzaStatistiche(List<Giocatore> listaGiocatori, List<Eroe> listaEroi)
        {
            
            Console.WriteLine("Di seguito le statistiche del gioco");
            foreach(var g in listaGiocatori)
            {
                RicercaEroiGiocatore(g);
                Console.WriteLine("Giocatore {0}", g.Nome);
                //int x = g.ListaEroi.Count;
                foreach(var e in g.ListaEroi)
                {
                    Console.WriteLine(e.Nome + " - Punti Accumulati: " + e.PuntiAccumulati + " - Tempo di Gioco: " + e.TempoDiGioco);
                }
            }

        }
    }
}
