using ADORepository.Extension;
using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADORepository
{
    public class AdoGiocatoreRepository : IGiocatoreRepository
    {
        const string connectionstring = @"Persist Security Info = False; Integrated Security = true; Initial Catalog = EroiVSMostri; Server = .\SQLEXPRESS";

        public void Create(Giocatore giocatore)
        {

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Giocatore VALUES (@Nome, @Ruolo)";

                //Aggiunta parametri
                command.Parameters.AddWithValue("@Nome", giocatore.Nome);
                command.Parameters.AddWithValue("@Ruolo", giocatore.Ruolo);
                

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Chiusura
                reader.Close();
                connection.Close();

            }
        }

        public bool Delete(Giocatore obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Giocatore> GetAll()
        {
            List<Giocatore> giocatori = new List<Giocatore>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Giocatore";

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dati
                while (reader.Read())
                {
                    giocatori.Add(reader.ToGiocatori());
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return giocatori;
        }

        public Giocatore GetById(int ID)
        {
            Giocatore giocatore = new Giocatore();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Giocatore WHERE ID = @ID";

                //Aggiunta parametri
                command.Parameters.AddWithValue("@ID", giocatore.ID);

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dati
                while (reader.Read())
                {
                    giocatore =reader.ToGiocatori();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return giocatore;
        }

        public Giocatore GetByName(string name)
        {
            Giocatore giocatore = new Giocatore();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Giocatore WHERE Nome = @name";

                //Aggiunta parametri
                command.Parameters.AddWithValue("@name", name);

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    giocatore = reader.ToGiocatori();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return giocatore;
        }

        public bool Update(Giocatore obj)
        {
            throw new NotImplementedException();
        }
    }
}
