using Gioco.Core.Entità;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADORepository.Extension
{
    public static class LivelloExtension
    {
        public static Livello ToLivello(this SqlDataReader reader)
        {
            return new Livello()
            {
                ID = (int)reader["ID"],
                Num = (int)reader["Num"],
                PuntiVita = (int)reader["PuntiVita"]
            };
        }
    }
}
