using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockRepository
{
    public class MockLivelloRepository : ILivelloRepository
    {
        private List<Livello> livelli = new List<Livello>()
        {
             new Livello(){ID = 1, Num = 1, PuntiVita=20},
             new Livello(){ID = 2, Num = 2, PuntiVita=40},
             new Livello(){ID = 3, Num = 3, PuntiVita=60},
             new Livello(){ID = 4, Num = 4, PuntiVita=80},
             new Livello(){ID = 5, Num = 5, PuntiVita=100},
        };


        public void Create(Livello obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Livello obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Livello> GetAll()
        {
            return livelli;
        }

        public Livello GetById(int ID)
        {
            Livello livello = new Livello();
            foreach (var item in livelli)
            {
                if (item.ID == ID)
                {
                    livello = item;
                }
            }
            return livello;
        }

        public Livello GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Livello obj)
        {
            throw new NotImplementedException();
        }
    }
}
