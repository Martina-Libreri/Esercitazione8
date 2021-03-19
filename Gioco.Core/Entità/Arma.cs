using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco.Core.Entità
{
    public class Arma  
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int ClasseID { get; set; }
        public Classe classe { get; set; }
        public int Danni { get; set; }
    
    }
}
