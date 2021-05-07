using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repositories
{
    public interface IParkingsRepository
    {
        Task<List<Parking>> GetAllParkings(SpaceParkContext context);
        //Task<List<Parking>> GetAllParkingsForPerson(SpaceParkContext context, string travellerName);
        Task<Parking> GetParking(SpaceParkContext context, int id);
        Task<Parking> AddParking(SpaceParkContext context, Parking newParking);
        Task<Parking> EndParking(SpaceParkContext context, string travellerName);
    }
}
