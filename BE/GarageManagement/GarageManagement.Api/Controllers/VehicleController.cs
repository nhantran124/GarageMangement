using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
	[Route("api/vehicle")]
	[ApiController]
	public class VehicleController : ControllerBase
	{
		private readonly IVehicleApp _vehicleApp;
		public VehicleController(IVehicleApp vehicleApp)
		{
			_vehicleApp = vehicleApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicle()
        {
            var vehicleDetails = await _vehicleApp.GetAllVehicle();
            if (vehicleDetails == null)
            {
                return NotFound();
            }
            return Ok(vehicleDetails);
        }

        [HttpGet("{TypeOfVehicleId}")]
        public async Task<IActionResult> GetVehicleById(string TypeOfVehicleId)
        {
            var vehicleDetails = await _vehicleApp.GetVehicleById(TypeOfVehicleId);

            if (vehicleDetails != null)
            {
                return Ok(vehicleDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle(Vehicle vehicle)
        {
            var VehicleIsCreated = await _vehicleApp.CreateVehicle(vehicle);

            if (VehicleIsCreated)
            {
                return Ok(VehicleIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                var VehicleIsUpdated = await _vehicleApp.UpdateVehicle(vehicle);
                if (VehicleIsUpdated)
                {
                    return Ok(VehicleIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{IDTypeOfVehicle}")]
        public async Task<IActionResult> DeleteVehicle(string IDTypeOfVehicle)
        {
            var VehicleIsDeleted = await _vehicleApp.DeleteVehicle(IDTypeOfVehicle);

            if (VehicleIsDeleted)
            {
                return Ok(VehicleIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

