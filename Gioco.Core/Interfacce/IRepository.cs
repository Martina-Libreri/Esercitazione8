using System;
using System.Collections.Generic;
using System.Text;

namespace Gioco.Core.Interfacce
{
    public interface IRepository<T>
        {
            //conterrà metodi base di accesso al dato
            //Metodi CRUD

            //Create
            void Create(T obj);

            //Read
            T GetById(int ID);

            T GetByName(string name);
            IEnumerable<T> GetAll();

            //Update
            bool Update(T obj);

            //Delete
            bool Delete(T obj);

    }
}

