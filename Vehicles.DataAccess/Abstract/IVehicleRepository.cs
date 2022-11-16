using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Entities;

namespace Vehicles.DataAccess.Abstract
{
    public interface IVehicleRepository
    {
         Task<Car> GetCarByColor(string color);
         Task<Boat> GetBoatByColor(string color);
        Task<Bus> GetBusByColor(string color);
        Task<Car> TurnCarHeadLights(int id);
        Task<Car> CreateCar(Car vehicle);
         Task<Boat> CreateBoat(Boat vehicle);
         Task<Bus> CreateBus(Bus vehicle);

         Task<Car> UpdateCar(Car vehicle);
         Task<Boat> UpdateBoat(Boat vehicle);
         Task<Bus> UpdateBus(Bus vehicle);
         Task<int> DeleteVehicle(int id,int vehicleId);    

    }
}
