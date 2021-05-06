using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repositories
{
    public class ParkingsRepository : IParkingsRepository
    {
        public async Task<List<Parking>> GetAllParkings(SpaceParkContext context)
        {
            return await context.Parkings.Include(parking => parking.Spaceport).ToListAsync();
        }

        public async Task<Parking> GetParking(SpaceParkContext context, int id)
        {
            return await context.Parkings.FindAsync(id);
        }

        public async Task<Parking> AddParking(SpaceParkContext context, Parking parking)
        {
            context.Add(parking);

            await context.SaveChangesAsync();

            return parking;
        }
    }
}
