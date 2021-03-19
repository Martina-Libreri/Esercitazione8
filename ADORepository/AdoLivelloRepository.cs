using ADORepository.Extension;
using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADORepository
{
    public class AdoLivelloRepository : ILivelloRepository
    {
        const string connectionstring = @"Persist Security Info = False; Integrated Security = true; Initial Catalog = EroiVSMostri; Server = .\SQLEXPRESS";
        public void Create(Livello obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Livello obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Livello> GetAll()
        {

            List<Livello> livelli = new List<Livello>();

            //ADO.NET
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Livello";

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dati
                while (reader.Read())
                {
                    livelli.Add(reader.ToLivello());
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return livelli; 

        }

        public Livello GetById(int ID)
        {
            Livello livello = new Livello();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Livello WHERE ID = @ID";

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
                    livello = reader.ToLivello();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return livello;
        }
        //non richiamo dal nome 
        public Livello GetByName(string name)
        {
            Livello livello = new Livello();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Livello WHERE Num = @name";

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
                    livello = reader.ToLivello();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return livello;
        }

        public bool Update(Livello obj)
        {
            throw new NotImplementedException();
        }
    }
}
