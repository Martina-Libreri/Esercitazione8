using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockRepository
{
    public class MockGiocatoreRepository : IGiocatoreRepository

    {
        private List<Giocatore> giocatori = new List<Giocatore>() 
        {
            new Giocatore{ID=1, Nome="Sara"},
            new Giocatore{ID=2,Nome="Giulio"}
        };
        public void Create(Giocatore obj)
        {
            obj.ID = giocatori.Count + 1;
            giocatori.Add(obj);
        }

        public bool Delete(Giocatore obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Giocatore> GetAll()
        {
            return giocatori;
        }

        public Giocatore GetById(int ID)
        {
            throw new NotImplementedException();
        }

        public Giocatore GetByName(string name)
        {
            Giocatore giocatore = new Giocatore();
            foreach(var item in giocatori)
            {
                if(item.Nome == name)
                {
                    giocatore = item;
                }
            }
            return giocatore;
        }

        public bool Update(Giocatore obj)
        {
            IEnumerable<Giocatore> lista = GetAll();
            foreach (var item in lista)
            {
                if (item.ID == obj.ID)
                {
                    Delete(item);
                    Create(obj);
                    return true;
                }
            }
            return false;
        }
    }
}
