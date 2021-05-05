using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaceParkAPI.SWAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        // GET: api/<PeopleController>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            // todo: error handling
            return Fetch.People().Result;
        }

        // GET api/<PeopleController>/5
        /// <summary>
        /// Test comment <PeopleController>/5
        /// </summary>
        /// <param name="id">Id of person in the Star Wars API</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Person>> Get(int id)
        {
            var person = Fetch.People(id).Result;

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }
    }
}
