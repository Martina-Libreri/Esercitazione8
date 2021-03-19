using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco.Core.Entità
{
    public class Livello
    {
        public int ID { get; set; }
        public int Num { get; set; }
        public int PuntiVita { get; set; }

        public int DefinizioneLivello(int puntiacc)
        {
            if (puntiacc <= 30)
                return 1;
            else if (puntiacc <= 60)
                return 2;
            else if (puntiacc <= 90)
                return 3;
            else if (puntiacc <= 120)
                return 4;
            else
                return 5;
        }
    }
}
