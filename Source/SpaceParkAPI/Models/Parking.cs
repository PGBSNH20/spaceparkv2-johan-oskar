using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class Parking
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        [Required]
        public string Traveller { get; set; }
        [Required]
        public string StarShip { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? TotalSum { get; set; }
        [Required]
        public Spaceport Spaceport { get; set; }
    }
}
