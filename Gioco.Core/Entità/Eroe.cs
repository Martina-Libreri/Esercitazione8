using System;
using System.Collections.Generic;
using System.Text;
using static Gioco.Core.Entità.Personaggio;

namespace Gioco.Core.Entità
{
    public class Eroe : Personaggio
    {
        public int PuntiAccumulati { get; set; }
        public int GiocatoreID { get; set; }
        public Giocatore Giocatore { get; set; }
        public bool Vittoria { get; set; }
        public TimeSpan TempoDiGioco { get; set; }

        public Eroe()
        {
            Vittoria = false;
        }

        public bool TentareFuga()
        {
            //Se torna true l'eroe riesce nella fuga 
            Random random = new Random();
            int x = random.Next(1,10);
            if (x % 2 == 1)
                return true;
            else
                return false;
        }

        public bool AttaccareMostro(Eroe eroe, Mostro mostro)
        {
            mostro.Livello.PuntiVita -= eroe.Arma.Danni;
            Console.WriteLine("Punti vita mostro: {0}", mostro.Livello.PuntiVita);
            if (mostro.Livello.PuntiVita <= 0)
            {
                Console.WriteLine("Hai vinto");
                return true;
            }
            else
            {
                Console.WriteLine("Non hai ancora vinto");
                return false;
            }
            
        }

    }
}
