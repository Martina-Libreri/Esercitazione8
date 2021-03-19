using Gioco.Core.Entità;
using Gioco.Service;
using MockRepository;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Diagnostics;

namespace Gioco
{
    class Program
    {
       static void Main(string[] args)
        {
            var serviceProvider = Configurazone.Configurazione();
            EroeService eroeservice = serviceProvider.GetService<EroeService>();
            GiocatoreService giocatoreService = serviceProvider.GetService<GiocatoreService>();
            MostroService mostroService = serviceProvider.GetService<MostroService>();
            ArmaService armaService = serviceProvider.GetService<ArmaService>();
            ClasseService classeService = serviceProvider.GetService<ClasseService>();
            LivelloService livelloService = serviceProvider.GetService<LivelloService>();

           
            List<Giocatore> listaG = giocatoreService.GetAllGiocatori().ToList();


            //inizio del gioco

            Console.WriteLine("Benvenuto in eroi contro mostri");
            Giocatore giocatore = new Giocatore();
            Console.WriteLine("Inserisci il tuo nome:");
            string n = Console.ReadLine();
            giocatore.Nome = n;

            Console.WriteLine();

            //Controllo sul giocatore
            Partita.ControlloGiocatore(giocatore,listaG);
            giocatore = giocatoreService.GetGiocatore(n);

            int x = 0;
            do 
            {
                //ogni volta che torno al menù vengono caricate le liste aggiornate
                List<Livello> listaLivelli = livelloService.GetAllLivelli().ToList();
                List<Classe> listaClassi = classeService.GetAllClassi().ToList();
                List<Arma> listaArmi = armaService.GetAllArmi().ToList();
                List<Giocatore> listaGiocatori = giocatoreService.GetAllGiocatori().ToList();
                List<Eroe> listaeroi = eroeservice.GetAllEroi().ToList();
                List<Mostro> listaMostri = mostroService.GetAllMostri().ToList();

                Console.WriteLine("Se vuoi iniziare una partita premi 1");
                Console.WriteLine("Se vuoi creare un eroe premi 2");
                Console.WriteLine("Se vuoi eliminare un eroe premi 3");
                Console.WriteLine("Se vuoi vedere le statistiche premi 4");
                //inserisco questa scelta solo se il giocatore ha la caratteristica richiesta
                if (giocatore.Ruolo == "Admin")
                {
                    Console.WriteLine("Dato che sei Admin, se vuoi inserire un mostro premi 5");
                }
                Console.WriteLine("Se vuoi uscire dal gioco premi un tasto");
                char a = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (a)
                {
                    case '1':
                        //Scelgo l'eroe per la partita
                        Eroe eroe = Partita.SceltaEroe(listaeroi, giocatore, listaClassi, listaArmi);
                        //controllo di non aver inserito male i dati
                        if(eroe == null) { giocatore.ListaEroi.Clear();  break; }
                        //aggiorno i restanti campi 
                        eroe.Classe = classeService.GetClasseByID(eroe.ClasseID);
                        eroe.Arma = armaService.GetArmaByID(eroe.ArmaID);
                        eroe.Giocatore = giocatoreService.GetGiocatore(giocatore.Nome);
                        eroe.GiocatoreID = eroe.Giocatore.ID;
                        eroe.Livello = livelloService.GetLivello(eroe.LivelloID);

                        if (eroe == null)
                        {
                            x = 0;
                            break;
                        }

                        //Scelgo il mostro con la funzione random
                        Mostro mostro = Partita.SceltaMostro(eroe, listaMostri);

                        //Inizia la battaglia
                        x = Partita.Battaglia(eroe,mostro);
                        Console.WriteLine("Se vuoi giocare ancora premi 0");
                        char d = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (d == '0')
                        {
                            giocatore.ListaEroi.Clear();
                            x =0;
                            break;
                        }
                        else
                            x = 1;
                        break;
                    case '2':
                        Eroe eroe3 = Partita.CreazioneEroe(giocatore, listaClassi, listaArmi, listaeroi);
                        break;
                    case '3':
                        Partita.VisualizzaEroi(listaeroi,giocatore);
                        Console.WriteLine("Inserisci il nome dell'eroe che vuoi eliminare");
                        string nome = Console.ReadLine();
                        Eroe eroe2 = eroeservice.GetEroeByName(nome);
                        if (eroe2.Nome == null)
                        {
                            Console.WriteLine("Non esiste questo eroe!");
                            break;
                        }
                        eroeservice.DeleteEroe(eroe2);
                        break;
                    case '4':
                        Partita.VisualizzaStatistiche(giocatore, listaGiocatori, listaeroi);
                        break;
                    case '5':
                        //nel caso in cui un giocatore Utente inserisca il 5 faccio un controllo e lo riporto al menù
                        if (giocatore.Ruolo != "Admin") { Console.WriteLine("Scelta sbagliata, Torna al menu"); break; }
                        Partita.CreazioneMostro(listaMostri,listaClassi,listaArmi,listaLivelli);
                        Console.WriteLine("Il Mostro é stato creato, torna al menù");
                        break;
                    default: 
                        x=1;
                        break;
                }
            } while (x==0);
        }
    }
}
