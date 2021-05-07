using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.swapi.Repositories;
using SpaceParkAPI.SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.SWAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarshipsController : ControllerBase
    {
        private IStarshipsRepository _starshipsRepository;

        public StarshipsController(IStarshipsRepository starshipsRepository)
        {
            _starshipsRepository = starshipsRepository;
        }

        // GET: api/<StarshipsController>
        [HttpGet("[action]")]
        [ActionName("All")]
        public async Task<ActionResult<IEnumerable<Starship>>> Get()
        {
            return await _starshipsRepository.GetAllStarships();
        }

        // GET api/<StarshipsController>/5
        [HttpGet]
        public async Task<ActionResult<Starship>> Get([FromQuery] string name)
        {
            return (await _starshipsRepository.GetStarship(name)).Value;
        }
    }
}
