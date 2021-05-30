using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.APIModels
{
    public class PostSpaceport
    {
        [Required]
        public string Name { get; set; }
        public string PlanetName { get; set; }
        public double MaxStarshipLength { get; set; }
    }
}
