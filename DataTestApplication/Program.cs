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
            

            //Try the create method
            //Joke j = new Joke() { title = "Postcard", jokeText = "My wife told me: ‘Sex is better on holiday.’ That wasn’t a very nice postcard to receive." };
            //jdb.AddJoke(j);

            List<Joke> l = jdb.GetAllJokes();
            foreach(Joke jo in l)
            {
                Console.WriteLine($"Joke ID : {jo.jokeId }, Title : { jo.title }, Joke : { jo.jokeText }");
            }

            Joke jok = jdb.GetJoke(4);
            Console.WriteLine($"Joke ID : {jok.jokeId }, Title : { jok.title }, Joke : { jok.jokeText }");
        }
    }
}
