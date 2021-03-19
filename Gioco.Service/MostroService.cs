using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco.Service
{
    public class MostroService
    {
        private IMostroRepository _repo;

        public MostroService(IMostroRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Mostro> GetAllMostri()
        {
            return _repo.GetAll();
        }

        public Mostro GetMostroByID(int ID)
        {
            return _repo.GetById(ID);
        }

        public Mostro CreateMostro(Mostro m)
        {
            if (m != null)
            {
                _repo.Create(m);
                return m;
            }
            else
                return null;
        }
        public void SceltaClasse(List<Classe> classi)
        {
            Console.WriteLine("Classi disponibili: ");
            foreach (var item in classi)
            {
                if (item.Valore == false)
                {
                    Console.WriteLine(item.Nome);
                }
            }

        }
    }
}
