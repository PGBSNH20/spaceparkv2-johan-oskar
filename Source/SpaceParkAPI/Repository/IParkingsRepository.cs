using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repository
{
    public interface IParkingsRepository
    {
        Task<IEnumerable<Parking>> GetAllParkings(SpaceParkContext context);
    }
}
