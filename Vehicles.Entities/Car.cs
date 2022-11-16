using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Entities
{
    public class Car : Vehicle
    {
        public Car(string color) : base(color)
        {
        }
        [Required]
        public int Wheels { get; set; }
        [Required]
        public bool Headlights { get; set; }
    }
}
