using System;
using System.Runtime.Serialization;

namespace Data
{
    [Serializable]
    [DataContract( Namespace = "")]
    public class Joke
    {
        [DataMember]
        public int JokeId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string JokeText { get; set; }
    }
}