using SpaceParkAPI.swapi.Repositories;
using SpaceParkAPI.SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkTest.Repositories
{
    class TestStarshipsRepository : IStarshipsRepository
    {
        public List<Starship> Starships { get; set; }

        public TestStarshipsRepository(List<Starship> starships)
        {
            Starships = starships ?? new List<Starship>();
        }

        public Task<List<Starship>> GetAllStarships()
        {
            return Task.FromResult(Starships);
        }

        public Task<Starship> GetStarship(string name)
        {
            return Task.FromResult(Starships.SingleOrDefault(p => p.Name == name));
        }
    }
}
