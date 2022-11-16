using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vehicles.DataAccess.Abstract;
using Vehicles.Entities;

namespace Vehicles.DataAccess.Concrete
{
    public enum Vehicles
    {
        Car,
        Boat,
        Bus
    }
    public class VehicleRepository : IVehicleRepository
    {
        async Task<Boat> IVehicleRepository.CreateBoat(Boat vehicle)
        {
            using (var vehicleDbContext = new VehicleDBContext())
            {
                vehicleDbContext.Boat.Add(vehicle);
                vehicleDbContext.SaveChanges();
                return vehicle;
            }
        }

        async Task<Bus> IVehicleRepository.CreateBus(Bus vehicle)
        {
            using (var vehicleDbContext = new VehicleDBContext())
            {
                vehicleDbContext.Bus.Add(vehicle);
                vehicleDbContext.SaveChanges();
                return vehicle;
            }
        }

       async Task<Car> IVehicleRepository.CreateCar(Car vehicle)
        {
            using (var vehicleDbContext = new VehicleDBContext())
            {
                vehicleDbContext.Car.Add(vehicle);
                vehicleDbContext.SaveChanges();
                return vehicle;
            }
        }

        async Task<int> IVehicleRepository.DeleteVehicle(int id,int vehicleId)
        {
            using (var vehicleDbContext = new VehicleDBContext())
            {
                switch (vehicleId)
                {
                    case (int)Vehicles.Car:
                        var deletedVehicle = vehicleDbContext.Car.Find(id);
                        vehicleDbContext.Car.Remove(deletedVehicle);
                        break;
                    case (int)Vehicles.Boat:
                        var deletedVehicle2 = vehicleDbContext.Boat.Find(id);
                        vehicleDbContext.Boat.Remove(deletedVehicle2);
                        break;
                    case (int)Vehicles.Bus:
                        var deletedVehicle3 = vehicleDbContext.Bus.Find(id);
                        vehicleDbContext.Bus.Remove(deletedVehicle3);
                        break;
                    default:
                        break;
                }
               return  vehicleDbContext.SaveChanges();               
            }
        }
        async Task<Boat> IVehicleRepository.GetBoatByColor(string color)
        {
            using (var vehicleDbContext = new VehicleDBContext())
            {
                return   vehicleDbContext.Boat.Where(x => x.Color == color).FirstOrDefault();
            }
        }

        async Task<Bus> IVehicleRepository.GetBusByColor(string color)
        {
            using (var vehicleDbContext = new VehicleDBContext())
            {
                return vehicleDbContext.Bus.Where(x => x.Color == color).FirstOrDefault();
            }
        }

        async Task<Car> IVehicleRepository.GetCarByColor(string color)
        {
            using (var vehicleDbContext = new VehicleDBContext())
            {
                return vehicleDbContext.Car.Where(x => x.Color == color).FirstOrDefault();
            }
        }

        async Task<Car> IVehicleRepository.TurnCarHeadLights(int id)
        {
            using (var vehicleDbContext = new VehicleDBContext())
            {
                var car = vehicleDbContext.Car.Find(id);
                if(car != null)
                {
                    car.Headlights = !car.Headlights;
                    vehicleDbContext.Update(car);
                    vehicleDbContext.SaveChanges();
                    return car;
                }
                else
                {
                    new Exception("CAR IS NULL !");
                    return null;
                }
              
            }

        }

        async Task<Boat> IVehicleRepository.UpdateBoat(Boat vehicle)
        {
            using (var vehicleDbContext = new VehicleDBContext())
            {
                var oldVehicle = vehicleDbContext.Boat.Find(vehicle.Id);
                if(oldVehicle != null)
                {
                    oldVehicle.Color = vehicle.Color;
                    vehicleDbContext.Boat.Update(vehicle);
                    vehicleDbContext.SaveChanges();
                    return oldVehicle;
                } else
                {
                    new Exception("BOAT IS NULL !");
                    return null;
                }
              
            }
        }

        async Task<Bus> IVehicleRepository.UpdateBus(Bus vehicle)
        {
            using (var vehicleDbContext = new VehicleDBContext())
            {
                var oldVehicle = vehicleDbContext.Bus.Find(vehicle.Id);
                if(oldVehicle != null )
                {
                    oldVehicle.Color = vehicle.Color;
                    vehicleDbContext.Bus.Update(vehicle);
                    vehicleDbContext.SaveChanges();
                    return oldVehicle;
                }
                else
                {
                    new Exception("BUS IS NULL !");
                    return null;
                }
              
            }
        }

        async Task<Car> IVehicleRepository.UpdateCar(Car vehicle)
        {
            using (var vehicleDbContext = new VehicleDBContext())
            {
                var oldVehicle = vehicleDbContext.Car.Find(vehicle.Id);
                if(oldVehicle != null)
                {
                    oldVehicle.Color = vehicle.Color;
                    oldVehicle.Wheels = vehicle.Wheels;
                    oldVehicle.Headlights = vehicle.Headlights;
                    vehicleDbContext.Car.Update(vehicle);
                    vehicleDbContext.SaveChanges();
                    return oldVehicle;
                }
                else
                {
                    new Exception("CAR IS NULL !");
                    return null;
                }


            }
        }
    }
}
