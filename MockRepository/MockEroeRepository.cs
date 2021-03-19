using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;

namespace MockRepository
{
    public class MockEroeRepository : IEroeRepository
    {
        private List<Eroe> eroi = new List<Eroe>()
        {
             new Eroe(){ID = 1, Nome = "Arno", ArmaID=1, GiocatoreID =1, ClasseID=1, LivelloID=1, PuntiAccumulati=0},
             new Eroe(){ID = 2, Nome = "Cadogan", ArmaID=1,  GiocatoreID =1, ClasseID=1, LivelloID=1, PuntiAccumulati=0}
        };

        public void Create(Eroe e)
        {
            eroi.Add(e);
        }

        public bool Delete(Eroe obj)
        {
            bool x = false;
            foreach(var item in eroi)
            {
                if(item == obj)
                {
                    x = true;
                }
            }
            if (x == true)
            {
                eroi.Remove(obj);
            }
            return x;
            
        }

        public IEnumerable<Eroe> GetAll()
        {
            return eroi;
        }

        public Eroe GetById(int ID)
        {
            throw new NotImplementedException();
        }

        public Eroe GetByName(string name)
        {
            Eroe eroe = new Eroe();
            foreach (var item in eroi)
            {
                if (item.Nome == name)
                {
                    eroe = item;
                }
            }
            return eroe;
        }

        public bool Update(Eroe e)
        {
            IEnumerable<Eroe> lista = GetAll();
            foreach(var item in lista)
            {
                if (item.ID == e.ID)
                {
                    Delete(item);
                    Create(e);
                    return true;
                }
            }
            return false;
        }
    }
}
