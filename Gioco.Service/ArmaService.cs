using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco.Service
{
    public class ArmaService
    {
        private IArmaRepository _armaRepository;

        public ArmaService(IArmaRepository repo)
        {
            _armaRepository = repo;
        }
        public IEnumerable<Arma> GetAllArmi()
        {
            return _armaRepository.GetAll();
        }
        
        public Arma GetArma(string name)
        {
            if (_armaRepository.GetByName(name) != null)
            {
                return _armaRepository.GetByName(name);
            }
            else
                return null;
        }
        public Arma GetArmaByID(int ID)
        {
            return _armaRepository.GetById(ID);
        }
        public void SceltaArma(List<Arma> armi, Personaggio p)
        {
            
            Console.WriteLine("Armi disponibili: ");
            foreach (var item in armi)
            {
                if (item.ClasseID == p.ClasseID)
                {
                    Console.WriteLine(item.Nome);
                }
            }

        }
    }
}
