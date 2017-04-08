using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Data
{
    public class JokesDatabase
    {
        private SqlConnection conn;
        public JokesDatabase()
        {
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.AppSettings["DatabaseConnection"].ToString());
        }

        public Joke GetJoke(int jokeId)
        {
            using (conn = GetConnection())
            {
                List<Joke> jokes = new List<Joke>();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Jokes", conn);
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM Jokes WHERE JokeID = { jokeId }", conn);
                DataTable dt = new DataTable();

                da.Fill(dt);

                Joke j = new Joke() { jokeId = (int)dt.Rows[0]["JokeID"], title = (string)dt.Rows[0]["Title"], jokeText = (string)dt.Rows[0]["Joke"] };

                return j;
            }
        }

        public List<Joke> GetAllJokes()
        {
            using (conn = GetConnection())
            {
                List<Joke> jokes = new List<Joke>();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Jokes", conn);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Jokes", conn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Joke j = new Data.Joke() { jokeId = (int)row["JokeID"], title = (string)row["Title"], jokeText = (string)row["Joke"] };
                    jokes.Add(j);
                }


                return jokes;
            }
        }

        public int AddJoke(Joke j)
        {
            int jokeId;

            using (conn = GetConnection()) {
                SqlCommand cmd = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure, CommandText = "AddJoke" };
                cmd.Parameters.AddWithValue("@Title", j.title);
                cmd.Parameters.AddWithValue("@JokeText", j.jokeText);
                conn.Open();
                jokeId = Convert.ToInt32(cmd.ExecuteScalar());

                return jokeId;
            }
        }

        public void UpdateJoke(Joke j)
        {
            using (conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure, CommandText = "UpdateJoke" };
                cmd.Parameters.AddWithValue("@JokeID", j.jokeId);
                cmd.Parameters.AddWithValue("@Title", j.title);
                cmd.Parameters.AddWithValue("@JokeText", j.jokeText);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteJoke(int jokeId)
        {
            using (conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand() { Connection = conn, CommandType = CommandType.StoredProcedure, CommandText = "DeleteJoke" };
                cmd.Parameters.AddWithValue("@JokeID", jokeId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
