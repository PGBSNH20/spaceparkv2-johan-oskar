using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class Spaceport
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string PlanetName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double MaxStarshipLength { get; set; }
    }
}
