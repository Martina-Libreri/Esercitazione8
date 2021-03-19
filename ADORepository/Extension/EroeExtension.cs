using Gioco.Core.Entità;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADORepository.Extension
{
    public static class EroeExtension
    {
        public static Eroe ToEroe(this SqlDataReader reader)
        {
            return new Eroe()
            {
                ID = (int)reader["ID"],
                Nome = reader["Nome"].ToString(),
                ArmaID = (int)reader["ArmaID"],
                GiocatoreID= (int)reader["GiocatoreID"],
                ClasseID= (int)reader["ClasseID"],
                LivelloID= (int)reader["LivelloID"],
                PuntiAccumulati = (int)reader["PuntiAccumulati"]
            };
        }
    }
}
