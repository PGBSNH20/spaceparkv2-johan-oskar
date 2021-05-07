using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly ISpaceportsRepository _spaceportsRepository;
        //private readonly ILogger _logger; // från Stephans genomgång 2021-04-30

        public ParkingsController(SpaceParkContext context, IParkingsRepository parkingsRepository, ISpaceportsRepository spaceportsRepository)
        {
            _context = context;
            _parkingsRepository = parkingsRepository;
            _spaceportsRepository = spaceportsRepository;
        }

        /// <summary>
        /// Get all parking rows/entities from the database.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parking>>> GetParkings()
        {
            return (await _parkingsRepository.GetAllParkings(_context)).ToList();
        }

        /// <summary>
        /// Get all parking rows/entities from the database.
        /// </summary>
        [HttpGet("[action]")]
        [ActionName("Ended")]
        public async Task<ActionResult<IEnumerable<Parking>>> GetEndedForTraveller([FromQuery] string traveller)
        {
            return (await _parkingsRepository.GetPreviousParkingsForTraveller(_context, traveller)).ToList();
        }

        /// <summary>
        /// Find and return a {parking} entity with the specified {id} from the database.
        /// If no entity can be found, then {null} is returned.
        /// </summary>
        /// <param name="id">The {id} of requested {parking} entity.</param>
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

        // POST: api/Parkings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parking>> PostParking(PostParking postParking)
        {
            var activeParking = await _parkingsRepository.GetActiveParking(_context, postParking.Traveller);

            if (activeParking != null)
            {
                return BadRequest("This traveller already has an active parking.");
            }

            var spaceport = await _spaceportsRepository.GetSpaceport(_context, postParking.SpaceportId);

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

            newParking = await _parkingsRepository.AddParking(_context, newParking);

            return CreatedAtAction(nameof(GetParking), new { id = newParking.ID }, newParking);
        }

        // PATCH: api/Parkings/5
        [HttpPatch("[action]")]
        [ActionName("Checkout")]
        public async Task<ActionResult<Parking>> EndParking([FromQuery] string traveller)
        {
            var activeParking = await _parkingsRepository.GetActiveParking(_context, traveller);

            if (activeParking == null)
            {
                return NotFound();
            }

            activeParking.EndTime = DateTime.Now;

            var duration = activeParking.EndTime - activeParking.StartTime;
            if (duration.HasValue)
            {
                // cost = 2 credits / minute
                activeParking.TotalSum = Convert.ToDecimal(duration.Value.TotalMinutes) * 2;
            }

            var endedParking = await _parkingsRepository.UpdateParking(_context, activeParking);

            return endedParking;
        }

        private bool ParkingExists(int id)
        {
            return _context.Parkings.Any(e => e.ID == id);
        }
    }
}
