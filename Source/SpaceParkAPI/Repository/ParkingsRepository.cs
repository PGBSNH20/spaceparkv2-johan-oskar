using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repository
{
    public class ParkingsRepository : IParkingsRepository
    {
        public async Task<IEnumerable<Parking>> GetAllParkings(SpaceParkContext context)
        {
            return await context.Parkings.ToListAsync();
        }
    }
}