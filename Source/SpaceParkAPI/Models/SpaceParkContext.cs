using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class SpaceParkContext : DbContext
    {
        public SpaceParkContext(DbContextOptions<SpaceParkContext> options) : base(options)
        {
        }

        public DbSet<Parking> Parkings { get; set; }
        public DbSet<SpacePort> SpacePorts { get; set; }
    }
}
