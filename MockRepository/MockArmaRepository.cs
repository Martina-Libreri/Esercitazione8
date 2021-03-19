using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockRepository
{
    public class MockArmaRepository : IArmaRepository
    {
        private List<Arma> armi = new List<Arma>()
        {
             new Arma(){ID = 1, Nome = "Spada", ClasseID=2, Danni=10},
             new Arma(){ID = 2, Nome = "Bastone",ClasseID=3, Danni=5},
             new Arma(){ID = 3, Nome = "Bacchetta",ClasseID=1, Danni=10},
             new Arma(){ID = 4, Nome = "MagiaNera",ClasseID=1, Danni=15},
             new Arma(){ID = 5, Nome = "Fuoco",ClasseID=4, Danni=7},
             new Arma(){ID = 6, Nome = "Pugno",ClasseID=5, Danni=12}
        };

        public void Create(Arma obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Arma obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Arma> GetAll()
        {
            return armi;
        }

        public Arma GetById(int ID)
        {
            Arma arma = new Arma();
            foreach (var item in armi)
            {
                if (item.ID == ID)
                {
                    arma = item;
                }
            }
            return arma;
        }

        public Arma GetByName(string name)
        {
            Arma arma = new Arma();
            foreach(var item in armi)
            {
                if (item.Nome == name)
                {
                    arma = item;
                }
            }
            return arma;
        }

        public bool Update(Arma obj)
        {
            throw new NotImplementedException();
        }
    }
}
