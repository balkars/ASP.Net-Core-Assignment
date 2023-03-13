using AutoMapper;
using CarSales.Controllers.Resources;
using CarSales.Core;
using CarSales.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarSales.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepositery repositery;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper,
            IVehicleRepositery repositery, IUnitOfWork unitOfWork)
        {
            this.repositery = repositery;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }


        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            repositery.Add(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await repositery.GetVehicle(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var vehicle = await repositery.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await unitOfWork.CompleteAsync();

            vehicle = await repositery.GetVehicle(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await repositery.GetVehicle(id);
            if (vehicle == null)
                return NotFound();

            repositery.Remove(vehicle);
            await unitOfWork.CompleteAsync();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await repositery.GetVehicle(id);
            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(vehicleResource);


        }

    }
}
