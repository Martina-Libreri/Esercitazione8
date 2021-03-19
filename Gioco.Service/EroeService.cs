using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;

namespace Gioco.Service
{
    public class EroeService
    {
        private IEroeRepository _repo;

        public EroeService(IEroeRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Eroe> GetAllEroi()
        {
            return _repo.GetAll();
        }
        public Eroe GetEroeByName(string name)
        {
            return _repo.GetByName(name);
        }
        public void Update(Eroe e)
        {
            _repo.Update(e);
        }

        public Eroe CreateEroe(Eroe e)
        {
            if(e != null)
            {
                _repo.Create(e);
                return e;
            }
            else
               return null;
        }

        public void DeleteEroe(Eroe e)
        {
            if (e != null)
            {
                _repo.Delete(e);
            }
            else
                Console.WriteLine("Eroe non valido");
        }

        public void SceltaClasse(List<Classe> classi)
        {
            Console.WriteLine("Classi disponibili: ");
            foreach (var item in classi)
            {
                if (item.Valore == true)
                {
                    Console.WriteLine(item.Nome);
                }
            }
           
        }

    }
}
