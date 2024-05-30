using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
    [Route("api/sparepartdetails")]
    [ApiController]
    public class SparePartDetailsController : ControllerBase
    {
        private readonly ISparePartDetailsApp _sparePartDetailsApp;

        public SparePartDetailsController(ISparePartDetailsApp sparePartDetailsApp)
        {
            _sparePartDetailsApp = sparePartDetailsApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSparePartDetails()
        {
            var sparePartDetailsList = await _sparePartDetailsApp.GetAllSparePartDetails();
            if (sparePartDetailsList == null)
            {
                return NotFound();
            }
            return Ok(sparePartDetailsList);
        }

        [HttpGet("{SparePartDetailsId}")]
        public async Task<IActionResult> GetSparePartDetailsById(string SparePartDetailsId)
        {
            var sparePartDetailsList = await _sparePartDetailsApp.GetSparePartDetailsById(SparePartDetailsId);
            if (sparePartDetailsList == null)
            {
                return NotFound();
            }
            return Ok(sparePartDetailsList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSparePartDetails(SparePartDetails sparePartDetails)
        {
            var SparePartDetailsIsCreated = await _sparePartDetailsApp.CreateSparePartDetails(sparePartDetails);

            if (SparePartDetailsIsCreated)
            {
                return Ok(SparePartDetailsIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSparePartDetails(SparePartDetails sparePartDetails)
        {
            if (sparePartDetails != null)
            {
                var SparePartDetailsIstUpdated = await _sparePartDetailsApp.UpdateSparePartDetails(sparePartDetails);
                if (SparePartDetailsIstUpdated)
                {
                    return Ok(SparePartDetailsIstUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{SparePartDetailsId}")]
        public async Task<IActionResult> DeleteSparePartDetails(string SparePartDetailsId)
        {

            var SparePartDetailsIstDeleted = await _sparePartDetailsApp.DeleteSparePartDetails(SparePartDetailsId);
            if (SparePartDetailsIstDeleted)
            {
                return Ok(SparePartDetailsIstDeleted);
            }
            return BadRequest();
        }
    }
}

