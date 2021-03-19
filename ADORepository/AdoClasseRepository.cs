using ADORepository.Extension;
using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADORepository
{
    public class AdoClasseRepository : IClasseRepository
    {
        const string connectionstring = @"Persist Security Info = False; Integrated Security = true; Initial Catalog = EroiVSMostri; Server = .\SQLEXPRESS";

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
            List<Classe> classi = new List<Classe>();

            //ADO.NET
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Classe";

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dati
                while (reader.Read())
                {
                    classi.Add(reader.ToClasse());
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return classi; 
        }

        public Classe GetById(int ID)
        {
            Classe classe = new Classe();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Classe WHERE ID = @ID";

                //Creare il parametro
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.Value = ID;
                command.Parameters.Add(param); 


                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dati
                while (reader.Read())
                {
                    classe = reader.ToClasse();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return classe;
        }

        public Classe GetByName(string name)
        {
            Classe classe = new Classe();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Classe WHERE Nome = @name";

                //Creare il parametro
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@name";
                param.Value = name;
                command.Parameters.Add(param);


                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dati
                while (reader.Read())
                {
                    classe = reader.ToClasse();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return classe;
        }

        public bool Update(Classe obj)
        {
            throw new NotImplementedException();
        }
    }
}
