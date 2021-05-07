using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkTest.Repositories
{
    class TestParkingsRepository : IParkingsRepository
    {
        public List<Parking> Parkings { get; set; }

        public TestParkingsRepository(List<Parking> parkings)
        {
            Parkings = parkings ?? new List<Parking>();
        }

        public Task<List<Parking>> GetAllParkings(SpaceParkContext context)
        {
            return Task.FromResult(Parkings);
        }

        public Task<Parking> GetParking(SpaceParkContext context, int id)
        {
            return Task.FromResult(Parkings.SingleOrDefault(p => p.ID == id));
        }

        public Task<Parking> AddParking(SpaceParkContext context, Parking newParking)
        {
            Parkings.Add(newParking);

            return Task.FromResult(newParking);
        }

        public Task<Parking> GetActiveParking(SpaceParkContext context, string travellerName)
        {
            return Task.FromResult(Parkings.SingleOrDefault(parking => parking.Traveller == travellerName && parking.EndTime == null));
        }

        public Task<Parking> UpdateParking(SpaceParkContext context, Parking parking)
        {
            return Task.FromResult(parking);
        }
    }
}
