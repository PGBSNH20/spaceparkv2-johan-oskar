using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.SWAPI;
using SpaceParkAPI.SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.swapi.Repositories
{
    public class StarshipsRepository : IStarshipsRepository
    {
        public async Task<List<Starship>> GetAllStarships()
        {
            return await Fetch.Starships();
        }

        public async Task<Starship> GetStarship(string name)
        {
            var test = (await Fetch.Starships(name));
            return test.FirstOrDefault();
        }
    }
}
