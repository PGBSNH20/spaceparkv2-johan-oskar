using SpaceParkAPI.SWAPI.Models;
using System.Collections.Generic;

namespace SpaceParkAPI.SWAPI
{
    public class APIResponse<T>
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public List<T> Results { get; set; }
    }
}
