using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repositories
{
    public class SpaceportsRepository : ISpaceportsRepository
    {
        public async Task<List<Spaceport>> GetAllSpaceports(SpaceParkContext context)
        {
            return await context.Spaceports.ToListAsync();
        }

        public async Task<Spaceport> GetSpaceport(SpaceParkContext context, int id)
        {
            return await context.Spaceports.FindAsync(id);
        }

        public async Task<Spaceport> AddSpaceport(SpaceParkContext context, Spaceport spaceport)
        {
            context.Spaceports.Add(spaceport);

            await context.SaveChangesAsync();

            return spaceport;
        }
    }
}