﻿using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repositories
{
    public interface IParkingsRepository
    {
        Task<IEnumerable<Parking>> GetAllParkings(SpaceParkContext context);
        Task<Parking> GetParking(SpaceParkContext context, int id);
    }
}
