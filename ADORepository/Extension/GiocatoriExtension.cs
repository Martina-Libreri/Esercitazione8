using Gioco.Core.Entità;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADORepository.Extension
{
    public static class GiocatoriExtension
    {
        public static Giocatore ToGiocatori(this SqlDataReader reader)
        {
            return new Giocatore()
            {
                ID = (int)reader["ID"],
                Nome = reader["Nome"].ToString(),
                Ruolo = reader["Ruolo"].ToString()
            };
        }
    }
}
