using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockRepository
{
    public class MockClasseRepository : IClasseRepository
    {
        private List<Classe> listaClassi = new List<Classe>()
        {
            new Classe(){ID = 1, Nome ="Mago", Valore = true},
            new Classe(){ID = 2, Nome ="Guerriero", Valore = true},
            new Classe(){ID = 3, Nome ="Orco", Valore = false},
            new Classe(){ID = 4, Nome ="SignoreDelMale", Valore = false},
            new Classe(){ID = 5, Nome ="Cultista", Valore = false},
        };
        public void Create(Classe obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Classe obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Classe> GetAll()
        {
            return listaClassi;
        }

        public Classe GetById(int ID)
        {
            Classe classe = new Classe();
            foreach (var item in listaClassi)
            {
                if (item.ID == ID)
                {
                    classe = item;
                }
            }
            return classe;
        }

        public Classe GetByName(string name)
        {
            Classe classe = new Classe();
            foreach(var item in listaClassi)
            {
                if(item.Nome == name)
                {
                    classe = item;
                }
            }
            return classe;
        }

        public bool Update(Classe obj)
        {
            throw new NotImplementedException();
        }
    }
}
