using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repositories
{
    public interface ISpaceportsRepository
    {
        Task<List<Spaceport>> GetAllSpaceports(SpaceParkContext context);

        Task<Spaceport> GetSpaceport(SpaceParkContext context, int id);
        Task<Spaceport> AddSpaceport(SpaceParkContext context, Spaceport spaceport);
    }
}
