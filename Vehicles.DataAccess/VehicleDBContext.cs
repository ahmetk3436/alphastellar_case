using Microsoft.EntityFrameworkCore;
using Vehicles.Entities;

namespace Vehicles.DataAccess
{
    public class VehicleDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=VehicleDB;TrustServerCertificate=False;Encrypt=False;Trusted_Connection=True;uid=sa;pwd=123456789");
        }
        public DbSet<Boat> Boat { get; set; }
        public DbSet<Bus> Bus { get; set; }
        public DbSet<Car> Car { get; set; }
    }
}