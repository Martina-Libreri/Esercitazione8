using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco.Service
{
    public class ClasseService
    {
        private IClasseRepository _repo;

        public ClasseService(IClasseRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Classe> GetAllClassi()
        {
            return _repo.GetAll();
        }

        public Classe GetClasse(string name)
        {
            if (_repo.GetByName(name) != null)
            {
                return _repo.GetByName(name);
            }
            else
                return null;
        }

        public Classe GetClasseByID(int ID)
        {
            return _repo.GetById(ID);
        }
    }
}
