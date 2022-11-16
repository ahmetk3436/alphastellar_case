using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Vehicles.Entities.Domain;

namespace Vehicles.Entities
{
    public class Vehicle : BaseEntity
    {
        [Required]
        public String Color { get; set; }

        public Vehicle(String color)
        {
            this.Color = color; 
        }
    }
}