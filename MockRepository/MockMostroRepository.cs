using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockRepository
{
    public class MockMostroRepository : IMostroRepository
    {
        private List<Mostro> mostri = new List<Mostro>()
        {
            new Mostro(){ID = 1, Nome="Tor", ClasseID=3, ArmaID=2, LivelloID=1 },
            new Mostro(){ID = 2, Nome="Tor", ClasseID=3, ArmaID=2, LivelloID=1 },
            new Mostro(){ID = 3, Nome="Tor", ClasseID=3, ArmaID=2, LivelloID=1 },
            new Mostro(){ID = 4, Nome="Tor", ClasseID=3, ArmaID=2, LivelloID=1 }
        };
        public void Create(Mostro obj)
        {
            mostri.Add(obj);
        }

        public bool Delete(Mostro obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mostro> GetAll()
        {
            return mostri;
        }

        public Mostro GetById(int ID)
        {
            Mostro mostro = new Mostro();
            foreach (var item in mostri)
            {
                if(item.ID == ID)
                {
                    mostro = item;
                }
            }
            return mostro;
        }

        public Mostro GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Mostro obj)
        {
            throw new NotImplementedException();
        }
    }
}
