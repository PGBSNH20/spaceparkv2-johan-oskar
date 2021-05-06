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
    public class ParkingsController : ControllerBase
    {
        private readonly SpaceParkContext _context;
        private readonly IParkingsRepository _parkingsRepository;
        //private readonly ILogger _logger; // från Stephans genomgång 2021-04-30

        public ParkingsController(SpaceParkContext context, IParkingsRepository parkingsRepository)
        {
            _context = context;
            _parkingsRepository = parkingsRepository;
        }

        // GET: api/Parkings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parking>>> GetParkings()
        {
            return (await _parkingsRepository.GetAllParkings(_context)).ToList();
        }

        // GET: api/Parkings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parking>> GetParking(int id)
        {
            var parking = await _parkingsRepository.GetParking(_context, id);

            if (parking == null)
            {
                return NotFound();
            }

            return parking;
        }

        // PUT: api/Parkings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParking(int id, Parking parking)
        {
            if (id != parking.ID)
            {
                return BadRequest();
            }

            _context.Entry(parking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingExists(id))
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

        // POST: api/Parkings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parking>> PostParking(PostParking postParking)
        //public async Task<ActionResult<Parking>> PostParking(Parking parking)
        {
            var spaceport = await _context.Spaceports.SingleOrDefaultAsync(s => s.ID == postParking.SpaceportId);

            if (spaceport == null)
            {
                return NotFound();
            }

            var newParking = new Parking
            {
                Traveller = postParking.Traveller,
                StarShip = postParking.StarShip,
                Spaceport = spaceport
            };

            _context.Parkings.Add(newParking);

            //if (_context.Spaceports.Single(s => parking.Spaceport != null && s.ID == parking.Spaceport.ID) != null) {
            //    _context.Parkings.Add(parking);

            //}
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParking), new { id = newParking.ID }, newParking);
            //return CreatedAtAction(nameof(GetParking), new { id = parking.ID }, parking);
        }

        // DELETE: api/Parkings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParking(int id)
        {
            var parking = await _context.Parkings.FindAsync(id);
            if (parking == null)
            {
                return NotFound();
            }

            _context.Parkings.Remove(parking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParkingExists(int id)
        {
            return _context.Parkings.Any(e => e.ID == id);
        }
    }
}
