using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.APIModels;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repositories;

namespace SpaceParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceportsController : ControllerBase
    {
        private readonly SpaceParkContext _context;
        private readonly ISpaceportsRepository _spaceportRepository;

        public SpaceportsController(SpaceParkContext context, ISpaceportsRepository spaceportsRepository)
        {
            _context = context;
            _spaceportRepository = spaceportsRepository;
        }

        // GET: api/Spaceports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spaceport>>> GetSpaceports()
        {
            return (await _spaceportRepository.GetAllSpaceports(_context)).ToList();
        }

        // GET: api/Spaceports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spaceport>> GetSpaceport(int id)
        {
            var spaceport = await _spaceportRepository.GetSpaceport(_context, id);

            if (spaceport == null)
            {
                return NotFound();
            }

            return spaceport;
        }

        // POST: api/Spaceports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Spaceport>> PostSpaceport(PostSpaceport postSpaceport)
        {
            var spaceport = new Spaceport
            {
                PlanetName = postSpaceport.PlanetName,
                Name = postSpaceport.Name,
                MaxStarshipLength = postSpaceport.MaxStarshipLength
            };

            await _spaceportRepository.AddSpaceport(_context, spaceport);

            return CreatedAtAction(nameof(GetSpaceport), new { id = spaceport.ID }, spaceport);
        }
    }
}
