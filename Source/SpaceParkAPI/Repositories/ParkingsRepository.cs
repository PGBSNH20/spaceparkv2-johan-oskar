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
            context.Add(parking);

            await context.SaveChangesAsync();

            return parking;
        }

        public async Task<Parking> EndParking(SpaceParkContext context, string travellerName)
        {
            var activeParking = await context.Parkings
                .Include(parking => parking.Spaceport)
                .SingleOrDefaultAsync(parking => parking.Traveller == travellerName && parking.EndTime == null);

            if (activeParking == null)
            {
                return null;
            }

            activeParking.EndTime = DateTime.Now;

            var duration = activeParking.EndTime - activeParking.StartTime;
            if (duration.HasValue)
            {
                // cost = 2 credits / minute
                activeParking.TotalSum = Convert.ToDecimal(duration.Value.TotalMinutes) * 2; 
            }

            context.SaveChanges();
            return activeParking;
        }
    }
}
