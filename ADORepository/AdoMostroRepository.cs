using ADORepository.Extension;
using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADORepository
{
    public class AdoMostroRepository : IMostroRepository
    {
        const string connectionstring = @"Persist Security Info = False; Integrated Security = true; Initial Catalog = EroiVSMostri; Server = .\SQLEXPRESS";

        public void Create(Mostro mostro)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Mostro VALUES (@Nome, @ClasseID, @LivelloID, @ArmaID)";

                //Aggiunta parametri
                command.Parameters.AddWithValue("@Nome", mostro.Nome);
                command.Parameters.AddWithValue("@ClasseID", mostro.ClasseID);
                command.Parameters.AddWithValue("@LivelloID", mostro.LivelloID);
                command.Parameters.AddWithValue("@ArmaID", mostro.ArmaID);

                //Esecuzione comando
                command.ExecuteNonQuery();

                //Chiusura
                connection.Close();
            }
        }

        public bool Delete(Mostro mostro)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string nome = mostro.Nome;
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM Mostro WHERE Nome = @nome";

                //Aggiunta parametri
                command.Parameters.AddWithValue("@Nome", mostro.Nome);
                try
                { 
                    //Esecuzione comando
                    command.ExecuteNonQuery();
                    
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {

                    //Chiusura
                    connection.Close();
                    
                }

            }
            return true;
        }

        public IEnumerable<Mostro> GetAll()
        {
            List<Mostro> mostri = new List<Mostro>();

            //ADO.NET
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Mostro";

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dati
                while (reader.Read())
                {
                    mostri.Add(reader.ToMostro());
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return mostri;
        }

        public Mostro GetById(int ID)
        {
            Mostro mostro = new Mostro();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Mostro WHERE ID = @ID";

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
                    mostro = reader.ToMostro();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return mostro;
        }

        public Mostro GetByName(string name)
        {

            Mostro mostro = new Mostro();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Mostro WHERE Nome = @name";

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
                    mostro = reader.ToMostro();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return mostro;
        }

        public bool Update(Mostro obj)
        {
            throw new NotImplementedException();
        }
    }
}
