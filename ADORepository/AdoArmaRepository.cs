using ADORepository.Extension;
using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADORepository
{
    public class AdoArmaRepository : IArmaRepository
    {
        const string connectionstring = @"Persist Security Info = False; Integrated Security = true; Initial Catalog = EroiVSMostri; Server = .\SQLEXPRESS";

        public void Create(Arma obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Arma obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Arma> GetAll()
        {
            List<Arma> armi = new List<Arma>();

            //ADO.NET
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Arma";

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dati
                while (reader.Read())
                {
                    armi.Add(reader.ToArmi());
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return armi;
        }

        public Arma GetById(int ID)
        {
            Arma arma = new Arma();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Arma WHERE ID = @ID";

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
                    arma = reader.ToArmi();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return arma;
        }

        public Arma GetByName(string name)
        {
            Arma arma = new Arma();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Arma WHERE Nome = @name";

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
                    arma = reader.ToArmi();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return arma;
        }

        public bool Update(Arma obj)
        {
            throw new NotImplementedException();
        }
    }
}
