using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Models;

namespace SpaceParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceportsController : ControllerBase
    {
        private readonly SpaceParkContext _context;

        public SpaceportsController(SpaceParkContext context)
        {
            _context = context;
        }

        // GET: api/Spaceports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spaceport>>> GetSpaceports()
        {
            return await _context.Spaceports.ToListAsync();
        }

        // GET: api/Spaceports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spaceport>> GetSpaceport(int id)
        {
            var spaceport = await _context.Spaceports.FindAsync(id);

            if (spaceport == null)
            {
                return NotFound();
            }

            return spaceport;
        }

        // PUT: api/Spaceports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpaceport(int id, Spaceport spaceport)
        {
            if (id != spaceport.ID)
            {
                return BadRequest();
            }

            _context.Entry(spaceport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpaceportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Spaceports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Spaceport>> PostSpaceport(Spaceport spaceport)
        {
            _context.Spaceports.Add(spaceport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSpaceport), new { id = spaceport.ID }, spaceport);
        }

        // DELETE: api/Spaceports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpaceport(int id)
        {
            var spaceport = await _context.Spaceports.FindAsync(id);
            if (spaceport == null)
            {
                return NotFound();
            }

            _context.Spaceports.Remove(spaceport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpaceportExists(int id)
        {
            return _context.Spaceports.Any(e => e.ID == id);
        }
    }
}
