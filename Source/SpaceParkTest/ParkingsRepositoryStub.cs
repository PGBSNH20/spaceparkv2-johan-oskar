using SpaceParkAPI.Models;
using SpaceParkAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkTest
{
    class ParkingsRepositoryStub : IParkingsRepository
    {
        public IEnumerable<Parking> Parkings { get; } // readonly set

        public ParkingsRepositoryStub(IEnumerable<Parking> parkings)
        {
            Parkings = parkings;
        }

        public Task<IEnumerable<Parking>> GetAllParkings(SpaceParkContext context)
        {
            return Task.FromResult(Parkings);
        }
    }
}
