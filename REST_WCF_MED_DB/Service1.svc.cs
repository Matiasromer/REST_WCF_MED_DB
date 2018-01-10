using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace REST_WCF_MED_DB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private const string ConnectionString =
                "Server=tcp:eventmserver.database.windows.net,1433;Initial Catalog=EMDatabase;Persist Security Info=False;User ID=Matias;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            ;
        public void AddGame(Game newGame)
        {
            SqlConnection conn = new SqlConnection(ConnectionString); 
            SqlCommand command = new SqlCommand(); 
            command.Connection = conn;
            conn.Open();  
            command.CommandText = @"INSERT INTO Games(Titel, Rating) 
                                VALUES (@Titel, @Rating)";

            command.Parameters.AddWithValue("@Titel", newGame.Titel);
            command.Parameters.AddWithValue("@Rating", newGame.Rating);

            command.ExecuteNonQuery(); 
            conn.Close();

        }

        public void Deletegame(string id)
        {
           
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            string sql = $"DELETE FROM Games WHERE Id = '{id}'";
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

            }
        }

        public List<Game> GetGame()
        {
            List<Game> liste = new List<Game>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                String sql = "SELECT * FROM Games ";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Game c = new Game
                    {
                        Id = reader.GetInt32(0),
                        Titel = reader.GetString(1),
                        Rating = reader.GetDouble(2),                      
                    };
                    liste.Add(c);
                }

            }

            return liste;
        }

        public Game GetOneGame(string id)
        {
            Game spil = new Game();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                String sql = $"SELECT * FROM Games WHERE ID = '{id}'";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    spil.Id = reader.GetInt32(0);
                    spil.Titel = reader.GetString(1);
                    spil.Rating = reader.GetDouble(2);
                }

            }

            return spil;

        }

        public void UpdateMovie(Game myGame)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand();

            command.Connection = conn;
            conn.Open();

            command.CommandText = @"UPDATE Games SET Titel = @titel Rating = @rating WHERE Movies.Id = @id";

            command.Parameters.AddWithValue("@id", myGame.Id);
            command.Parameters.AddWithValue("@titel", myGame.Titel);
            command.Parameters.AddWithValue("@rating", myGame.Rating);


            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
