using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repositories
{
    public class SpaceportsRepository : ISpaceportsRepository
    {
        public async Task<IEnumerable<Spaceport>> GetAllSpaceports(SpaceParkContext context)
        {
            return await context.Spaceports.ToListAsync();
        }
    }
}