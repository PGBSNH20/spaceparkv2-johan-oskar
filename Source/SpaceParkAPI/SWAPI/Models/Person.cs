using System.Collections.Generic;

namespace SpaceParkAPI.SWAPI.Models
{
    public class Person
    {
        public string Name { get; set; }
        public List<string> Starships { get; set; }
    }
}
