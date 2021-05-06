using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkTest
{
    class TestParkingsRepository : IParkingsRepository
    {
        public IEnumerable<Parking> Parkings { get; } // readonly set

        public TestParkingsRepository(IEnumerable<Parking> parkings)
        {
            Parkings = parkings;
        }

        public Task<IEnumerable<Parking>> GetAllParkings(SpaceParkContext context)
        {
            return Task.FromResult(Parkings);
        }

        public Task<Parking> GetParking(SpaceParkContext context, int id)
        {
            return Task.FromResult(Parkings.SingleOrDefault(p => p.ID == id));
        }
    }
}
