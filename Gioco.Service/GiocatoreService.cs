using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco.Service
{
    public class GiocatoreService
    {
        private IGiocatoreRepository _repo;

        public GiocatoreService(IGiocatoreRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Giocatore> GetAllGiocatori()
        {
            return _repo.GetAll();
        }

        public void UpdateGiocatore(Giocatore g)
        {
            _repo.Update(g);
        }

        public Giocatore CreateGiocatore(Giocatore g)
        {
            if (g!= null)
            {
                _repo.Create(g);
                return g;
            }
            else
                return null;
        }

        public Giocatore GetGiocatore(string name)
        {
            return _repo.GetByName(name);
        }
    }
}
