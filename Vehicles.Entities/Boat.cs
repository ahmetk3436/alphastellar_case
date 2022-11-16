using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Entities
{
    public class Boat : Vehicle
    {
        [Required]

        public int engineHP { get; set; }
        [Required]

        public int seatCount { get; set; }
        public Boat(string color) : base(color)
        {
        }
    }
}
