using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicles.Business.Abstract;
using Vehicles.Business.Concrete;
using Vehicles.Entities;

namespace Vehicles.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
      
       
        private IVehicleService _vehicleService;

        public VehiclesController()
        {
           _vehicleService = new VehicleManager();
        }

        [HttpGet]
        [Route("[action]/{color}")]
        public async Task<IActionResult> GetCarByColor(string color)
        {
           
            if(ModelState.IsValid)
            {

                var car =  _vehicleService.GetCarByColor(color);
                return CreatedAtAction("GetCarByColor", car);
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("[action]/{color}")]
        public async Task<IActionResult> GetBoatByColor(string color)
        {
            if (ModelState.IsValid)
            {
                var car = await _vehicleService.GetBoatByColor(color);
                return CreatedAtAction("GetBoatByColor", car);
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("[action]/{color}")]
        public async Task<IActionResult> GetBusByColor(string color)
        {
            if (ModelState.IsValid)
            {
                var car = _vehicleService.GetBusByColor(color);
                return CreatedAtAction("GetBusByColor", new { color, car }, car);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("createBus")]
        public async Task<IActionResult> CreateBus([FromBody] Bus vehicle)
        {
            if (ModelState.IsValid)
            {
                var bus = _vehicleService.CreateBus(vehicle);
                return CreatedAtAction("CreateBus", new { bus });
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("createBoat")]
        public async Task<IActionResult> CreateBoat([FromBody] Boat vehicle)
        {
            if (ModelState.IsValid)
            {
                var boat = _vehicleService.CreateBoat(vehicle);
                return CreatedAtAction("CreateBoat", new { boat });
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("createCar")]
        public async Task<IActionResult> CreateCar([FromBody]Car vehicle)
        {
            if (ModelState.IsValid)
            {
                var car = _vehicleService.CreateCar(vehicle);
                return CreatedAtAction("CreateCar", new { car.Result.Id },car);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        [Route("deleteVehicle")]
        public async Task<IActionResult> DeleteVehicle(int id,int vehicleId)
        {
            if (ModelState.IsValid)
            {
                 _vehicleService.DeleteVehicle(id,vehicleId);
                return Ok("Successfully deleted !" + " " + id);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("changeHeadlights")]
        public async Task<IActionResult> ChangeCarHeadlights(int id)
        {
            if (ModelState.IsValid)
            {
                var car = await _vehicleService.TurnCarHeadLights(id);
                return CreatedAtAction("Successfully changed !" + " Yeni değer : " + car.Headlights,car);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("updateBoat")]
        public async Task<IActionResult> UpdateBoat([FromBody]Boat vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.UpdateBoat(vehicle);
                return CreatedAtAction("Successfully updated !", new { vehicle.Id }, vehicle);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        [Route("updateCar")]
        public async Task<IActionResult> UpdateCar([FromBody]Car vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.UpdateCar(vehicle);
                return CreatedAtAction("Successfully updated !", new { vehicle.Id }, vehicle);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        [Route("updateBus")]
        public async Task<IActionResult> UpdateBus([FromBody]Bus vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.UpdateBus(vehicle);
                return CreatedAtAction("Successfully updated !", new { vehicle.Id }, vehicle);
            }
            return BadRequest(ModelState);
        }
    }
}
