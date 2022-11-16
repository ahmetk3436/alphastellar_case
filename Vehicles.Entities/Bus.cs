using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Entities
{
    public class Bus : Vehicle
    {
        [Required]
        public int seatCount { get; set; }
        [Required]
        public int horizontalLength { get; set; }
        public Bus(string color) : base(color)
        {
        }
    }
}
