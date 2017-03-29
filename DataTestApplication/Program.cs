using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            JokesDatabase jdb = new JokesDatabase();
            List<Joke> l = jdb.GetAllJokes();
        }
    }
}
