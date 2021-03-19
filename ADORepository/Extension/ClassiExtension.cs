using Gioco.Core.Entità;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADORepository.Extension
{
    public static class ClassiExtension
    {
        public static Classe ToClasse(this SqlDataReader reader)
        {
            return new Classe()
            {
                ID = (int)reader["ID"],
                Valore = (bool)reader["Valore"],
                Nome = reader["Nome"].ToString()
            };
        }
    }
}
