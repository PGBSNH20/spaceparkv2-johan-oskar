using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.SWAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceParkAPI.swapi.Repositories
{
    public interface IPeopleRepository
    {
        Task<List<Person>> GetAllPersons();
        Task<ActionResult<Person>> GetPerson(string name);
    }
}
