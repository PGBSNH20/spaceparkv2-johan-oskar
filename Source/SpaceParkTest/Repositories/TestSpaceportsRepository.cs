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
        public IEnumerable<Spaceport> Spaceports { get; } // readonly set
        public TestSpaceportsRepository(IEnumerable<Spaceport> spaceports)
        {
            Spaceports = spaceports;
        }

        public Task<IEnumerable<Spaceport>> GetAllSpaceports(SpaceParkContext context)
        {
            throw new NotImplementedException();
        }

        public Task<Spaceport> GetSpaceport(SpaceParkContext context, int id)
        {
            return Task.FromResult(Spaceports.SingleOrDefault(p => p.ID == id));
        }
    }
}
