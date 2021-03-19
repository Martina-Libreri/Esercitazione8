using ADORepository.Extension;
using Gioco.Core.Entità;
using Gioco.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADORepository
{
    public class AdoEroeRepository : IEroeRepository
    {
        const string connectionstring = @"Persist Security Info = False; Integrated Security = true; Initial Catalog = EroiVSMostri; Server = .\SQLEXPRESS";
        //non finito
        public void Create(Eroe eroe)
        {

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Eroe VALUES (@Nome, @GiocatoreID, @ClasseID,@LivelloID,@ArmaID, @PuntiAccumulati,@Vittoria,@TempoDiGioco)";

                //Aggiunta parametri
                command.Parameters.AddWithValue("@Nome", eroe.Nome);
                command.Parameters.AddWithValue("@GiocatoreID", eroe.GiocatoreID);
                command.Parameters.AddWithValue("@ClasseID", eroe.ClasseID);
                command.Parameters.AddWithValue("@LivelloID", eroe.LivelloID);
                command.Parameters.AddWithValue("@ArmaID", eroe.ArmaID);
                command.Parameters.AddWithValue("@PuntiAccumulati", eroe.PuntiAccumulati);
                command.Parameters.AddWithValue("@Vittoria", eroe.Vittoria);
                command.Parameters.AddWithValue("@TempoDiGioco", eroe.TempoDiGioco);

                //Esecuzione comando
                //SqlDataReader reader = 
                command.ExecuteNonQuery();

                //Chiusura
                //reader.Close();
                connection.Close();
         
                
            }
        }
        public bool Delete(Eroe eroe)
        {
            string nome = eroe.Nome;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM Eroe WHERE Nome = @nome";

                //Aggiunta parametri
                command.Parameters.AddWithValue("@Nome", eroe.Nome);

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Chiusura
                reader.Close();
                connection.Close();

            }
            return true;
        }
        public IEnumerable<Eroe> GetAll()
        {
            List<Eroe> eroi = new List<Eroe>();

            //ADO.NET
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Eroe";

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dati
                while (reader.Read())
                {
                    eroi.Add(reader.ToEroe());
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return eroi; 

        }
        public Eroe GetById(int ID)
        {
            Eroe eroe = new Eroe();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Eroe WHERE ID = @ID";

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
                    eroe = reader.ToEroe();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return eroe;
        }
        public Eroe GetByName(string nome)
        {
            Eroe eroe = new Eroe();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Eroe WHERE Nome = @nome";

                //Creare il parametro
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@nome";
                param.Value = nome;
                command.Parameters.Add(param);


                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dati
                while (reader.Read())
                {
                    eroe = reader.ToEroe();
                }

                //Chiusura
                reader.Close();
                connection.Close();
            }
            return eroe;
        }
        public bool Update(Eroe eroe)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //Aprire la connessione
                connection.Open();

                //Comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE Eroe SET PuntiAccumulati = @PuntiAccumulati, LivelloID = @LivelloID, TempoDiGioco = @TempoDiGioco, Vittoria = @Vittoria WHERE ID = @ID";

                //Aggiunta parametri
                command.Parameters.AddWithValue("@PuntiAccumulati", eroe.PuntiAccumulati);
                command.Parameters.AddWithValue("@LivelloID", eroe.LivelloID);
                command.Parameters.AddWithValue("@TempoDiGioco", eroe.TempoDiGioco);
                command.Parameters.AddWithValue("@Vittoria", eroe.Vittoria);
                command.Parameters.AddWithValue("@ID", eroe.ID);

                //Esecuzione comando
                SqlDataReader reader = command.ExecuteReader();
         
                //Chiusura
                reader.Close();
                connection.Close();
            }
            return true;
        }
    }
}
