using System.Collections.Generic;

namespace SpaceParkConsole.SpacePortApi.Models
{
    public class Person
    {
        public string Name { get; set; }
        public List<string> Starships { get; set; }
    }
}
