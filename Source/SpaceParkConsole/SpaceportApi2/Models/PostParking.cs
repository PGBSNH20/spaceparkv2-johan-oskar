using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkConsole.SpaceportApi.Models
{
    public class PostParking
    {
        [Required]
        public string Traveller { get; set; }
        [Required]
        public string StarShip { get; set; }
        [Required]
        public int SpaceportId { get; set; }
    }
}
