using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco.Core.Entità
{
    public class Giocatore
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Ruolo { get; set; }
        public List<Eroe> ListaEroi { get; set; }

        public Giocatore()
        {
            ListaEroi = new List<Eroe>();
        }

    }
}
