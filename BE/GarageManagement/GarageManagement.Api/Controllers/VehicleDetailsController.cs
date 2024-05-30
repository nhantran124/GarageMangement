using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
	[Route("api/vehicledetails")]
	[ApiController]
	public class VehicleDetailsController : ControllerBase
	{
		private readonly IVehicleDetailsApp _vehicleDetailsApp;
		public VehicleDetailsController(IVehicleDetailsApp vehicleDetailsApp)
		{
            _vehicleDetailsApp = vehicleDetailsApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicleDetails()
        {
            var vehicleDetailsList = await _vehicleDetailsApp.GetAllVehicleDetails();
            if (vehicleDetailsList == null)
            {
                return NotFound();
            }
            return Ok(vehicleDetailsList);
        }

        [HttpGet("{VehicleId}")]
        public async Task<IActionResult> GetVehicleDetailsById(string VehicleId)
        {
            var vehicleDetailsList = await _vehicleDetailsApp.GetVehicleDetailsById(VehicleId);

            if (vehicleDetailsList != null)
            {
                return Ok(vehicleDetailsList);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleDetails(VehicleDetails vehicleDetails)
        {
            var VehicleDetailsIsCreated = await _vehicleDetailsApp.CreateVehicleDetails(vehicleDetails);

            if (VehicleDetailsIsCreated)
            {
                return Ok(VehicleDetailsIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicleDetails(VehicleDetails vehicleDetails)
        {
            if (vehicleDetails != null)
            {
                var VehicleDetailsIsUpdated = await _vehicleDetailsApp.UpdateVehicleDetails(vehicleDetails);
                if (VehicleDetailsIsUpdated)
                {
                    return Ok(VehicleDetailsIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{VehicleId}")]
        public async Task<IActionResult> DeleteVehicleDetails(string VehicleId)
        {
            var VehicleDetailsIsDeleted = await _vehicleDetailsApp.DeleteVehicleDetails(VehicleId);

            if (VehicleDetailsIsDeleted)
            {
                return Ok(VehicleDetailsIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

