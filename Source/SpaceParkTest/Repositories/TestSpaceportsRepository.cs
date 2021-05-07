using SpaceParkAPI.Models;
using SpaceParkAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkTest.Repositories
{
    class TestSpaceportsRepository : ISpaceportsRepository
    {
        public List<Spaceport> Spaceports { get; } // readonly set

        public TestSpaceportsRepository(List<Spaceport> spaceports)
        {
            Spaceports = spaceports;
        }

        public Task<List<Spaceport>> GetAllSpaceports(SpaceParkContext context)
        {
            return Task.FromResult(Spaceports);
        }

        public Task<Spaceport> GetSpaceport(SpaceParkContext context, int id)
        {
            return Task.FromResult(Spaceports.SingleOrDefault(p => p.ID == id));
        }

        public Task<Spaceport> AddSpaceport(SpaceParkContext context, Spaceport spaceport)
        {
            Spaceports.Add(spaceport);

            return Task.FromResult(spaceport);
        }
    }
}
