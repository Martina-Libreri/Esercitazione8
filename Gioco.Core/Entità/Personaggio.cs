using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco.Core.Entità
{
    public abstract class Personaggio
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int ClasseID { get; set; }
        public int LivelloID { get; set; }
        public int ArmaID { get; set; }
        public Classe Classe { get; set; }
        public Livello Livello { get; set; }
        public Arma Arma { get; set; }


        //public void GestionePuntiVita(int livello)
        //{
        //    if (livello == 1)
        //    {
        //        PuntiVita = 20;
        //    }
        //    else if (livello == 2)
        //    {
        //        PuntiVita = 40;
        //    }
        //    else if (livello == 3)
        //    {
        //        PuntiVita = 60;
        //    }
        //    else if (livello == 4)
        //    {
        //        PuntiVita = 80;
        //    }
        //    else
        //        PuntiVita = 100;
        //}

        //public int PuntiAccumulati { get; set; }

        //public virtual void SceltaClasse() { }
        

    }
}
