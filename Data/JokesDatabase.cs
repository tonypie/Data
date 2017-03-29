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
            conn = GetConnection();

        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.AppSettings["DatabaseConnection"].ToString());
        }

        public List<Joke> GetAllJokes()
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
}
