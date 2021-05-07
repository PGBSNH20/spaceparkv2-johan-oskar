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
    public class StarshipsController : ControllerBase
    {
        // GET: api/<StarshipsController>
        [HttpGet("[action]")]
        [ActionName("All")]
        public ActionResult<IEnumerable<Starship>> Get()
        {
            return Fetch.Starships().Result;
        }

        // GET api/<StarshipsController>/5
        [HttpGet]
        public ActionResult<Starship> Get([FromQuery] string name)
        {
            var starship = Fetch.Starships(name).Result.FirstOrDefault();

            if (starship == null)
            {
                return NotFound();
            }

            return starship;
        }
    }
}
