using Gioco.Core.Entità;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADORepository.Extension
{
    public static class MostriExtension
    {
        public static Mostro ToMostro(this SqlDataReader reader)
        {
            return new Mostro()
            {
                ID = (int)reader["ID"],
                Nome = reader["Nome"].ToString(),
                ClasseID = (int)reader["ClasseID"],
                LivelloID = (int)reader["LivelloID"],
                ArmaID = (int)reader["ArmaID"]
            };
        }
    }
}
