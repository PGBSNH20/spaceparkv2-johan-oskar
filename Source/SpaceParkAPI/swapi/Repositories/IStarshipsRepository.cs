using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.SWAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceParkAPI.swapi.Repositories
{
    public interface IStarshipsRepository
    {
        Task<List<Starship>> GetAllStarships();
        Task<Starship> GetStarship(string name);
    }
}