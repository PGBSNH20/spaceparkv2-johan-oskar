using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpaceParkAPI.swapi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceParkAPI.SWAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        // GET: api/<PeopleController>
        [HttpGet("[action]")]
        [ActionName("All")]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            return await _peopleRepository.GetAllPersons();
        }

        // GET api/<PeopleController>/5
        /// <summary>
        /// Test comment <PeopleController>/5
        /// </summary>
        /// <param name="name">Id of person in the Star Wars API</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Person>> Get([FromQuery] string name)
        {
            var person = (await _peopleRepository.GetPerson(name)).Value;

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }
    }
}
