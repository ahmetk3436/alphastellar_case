using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Business.Abstract;
using Vehicles.DataAccess.Abstract;
using Vehicles.DataAccess.Concrete;
using Vehicles.Entities;

namespace Vehicles.Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        private IVehicleRepository _vehicleRepository;
        public VehicleManager()
        {
            _vehicleRepository = new VehicleRepository();
        }
        async Task<Boat> IVehicleService.CreateBoat(Boat vehicle)
        {
            if(vehicle.seatCount > 0 && vehicle.engineHP > 0)
            {
                return  await _vehicleRepository.CreateBoat(vehicle);
            }
            throw new Exception("Seat Count And Engine HP cannot be equel or less than 0 !");
        }

        async Task<Bus> IVehicleService.CreateBus(Bus vehicle)
        {
            return  await _vehicleRepository.CreateBus(vehicle);

        }

        async Task<Car> IVehicleService.CreateCar(Car vehicle)
        {
            return await _vehicleRepository.CreateCar(vehicle);

        }

        async Task<AsyncVoidMethodBuilder> IVehicleService.DeleteVehicle(int id, int vehicleId)
        {
            if(id>0 && (vehicleId >= 0 && vehicleId < 3))
            {
                 _vehicleRepository.DeleteVehicle(id, vehicleId);
            }
            throw new Exception("id cannot be less than 1 and vehicleId is wrong !");
        }

        async Task<Boat> IVehicleService.GetBoatByColor(string color)
        {
            return await _vehicleRepository.GetBoatByColor(color);

        }

        async Task<Bus> IVehicleService.GetBusByColor(string color)
        {
            return await _vehicleRepository.GetBusByColor(color);
        }

        async Task<Car> IVehicleService.GetCarByColor(string color)
        {
            return await _vehicleRepository.GetCarByColor(color);
        }

        async Task<Car> IVehicleService.TurnCarHeadLights(int id)
        {
            if(id > 0)
            {
                return await _vehicleRepository.TurnCarHeadLights(id);
            }
            throw new Exception("id cannot be less than 1");
        }

        async Task<Boat> IVehicleService.UpdateBoat(Boat vehicle)
        {
            return await _vehicleRepository.UpdateBoat(vehicle);
        }

        async Task<Bus> IVehicleService.UpdateBus(Bus vehicle)
        {
            return await _vehicleRepository.UpdateBus(vehicle);

        }

        async Task<Car> IVehicleService.UpdateCar(Car vehicle)
        {
            return await _vehicleRepository.UpdateCar(vehicle);
        }
    }
}
