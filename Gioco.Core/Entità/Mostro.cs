using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco.Core.Entità
{
    public class Mostro : Personaggio
    {
        public bool Attacco(Eroe eroe, Mostro mostro)
        {
            eroe.Livello.PuntiVita -= mostro.Arma.Danni;
            Console.WriteLine("Punti vita mostro: {0}", eroe.Livello.PuntiVita);
            if (eroe.Livello.PuntiVita <= 0)
            {
                Console.WriteLine("Il mostro ti ha battuto");
                return false;
            }
            else
            {
                Console.WriteLine("Gioca un altro turno! Puoi batterlo");
                return true;
            }
        }
    }
}
