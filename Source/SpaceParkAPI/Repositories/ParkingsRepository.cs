using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            context.Parkings.Add(parking);

            await context.SaveChangesAsync();

            return parking;
        }

        public async Task<Parking> GetActiveParking(SpaceParkContext context, string travellerName)
        {
            return await context.Parkings.Include(p => p.Spaceport).SingleOrDefaultAsync(parking => parking.Traveller == travellerName && parking.EndTime == null);
        }

        public async Task<Parking> UpdateParking(SpaceParkContext context, Parking parking)
        {
            context.Parkings.Update(parking);
            await context.SaveChangesAsync();

            //return activeParking;
            return parking;
        }

        public async Task<IEnumerable<Parking>> GetPreviousParkingsForTraveller(SpaceParkContext context, string travellerName)
        {
            return await context.Parkings.Include(p => p.Spaceport).Where(parking => parking.Traveller == travellerName && parking.EndTime != null).ToListAsync();
        }
    }
}
