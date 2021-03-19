using Gioco.Core.Entità;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADORepository.Extension
{
    public static class ArmiExtension
    {
        public static Arma ToArmi(this SqlDataReader reader)
        {
            return new Arma()
            {
                ID = (int)reader["ID"],
                Nome = reader["Nome"].ToString(),
                ClasseID=(int)reader["ClasseID"],
                Danni=(int)reader["Danni"]
            };
        }
    }
}
