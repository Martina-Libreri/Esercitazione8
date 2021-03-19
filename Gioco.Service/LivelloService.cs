using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco.Service
{
    public class LivelloService
    {
        private ILivelloRepository _repo;

        public LivelloService(ILivelloRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Livello> GetAllLivelli()
        {
            return _repo.GetAll();
        }
        public Livello GetLivello(int n)
        {
            return _repo.GetById(n);
        }
        public void SceltaLivello(List<Livello> livelli)
        {

            Console.WriteLine("Livelli disponibili: ");
            foreach (var item in livelli)
            {
              Console.WriteLine(item.Num);
               
            }
        }
    }
}
