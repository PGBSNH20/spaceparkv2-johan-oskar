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
        [HttpGet("[action]")]
        [ActionName("All")]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            // todo: error handling
            return Fetch.People().Result;
        }

        // GET api/<PeopleController>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name to search for on the "/people"-endpoint in the Star Wars API </param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Person> Get([FromQuery] string name)
        {
            var person = Fetch.People(name).Result.FirstOrDefault();

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }
    }
}
