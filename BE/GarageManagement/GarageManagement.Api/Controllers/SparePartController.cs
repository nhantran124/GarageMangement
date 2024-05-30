using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.InboundManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
    [Route("api/sparepart")]
    [ApiController]
    public class SparePartController : ControllerBase
    {
        private readonly ISparePartApp _sparePartApp;
        public SparePartController(ISparePartApp sparePartApp)
        {
            _sparePartApp = sparePartApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSparePart()
        {
            var SparePartList = await _sparePartApp.GetAllSparePart();
            if (SparePartList == null)
            {
                return NotFound();
            }
            return Ok(SparePartList);
        }

        [HttpGet("{SparePartId}")]
        public async Task<IActionResult> GetSparePartById(string SparePartId)
        {
            var SparePartDetails = await _sparePartApp.GetSparePartById(SparePartId);

            if (SparePartDetails != null)
            {
                return Ok(SparePartDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessDetails(SparePart sparePart)
        {
            var SparePartIsCreated = await _sparePartApp.CreateSparePart(sparePart);

            if (SparePartIsCreated)
            {
                return Ok(SparePartIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSparePart(SparePart sparePart)
        {
            if (sparePart != null)
            {
                var SparePartIsUpdated = await _sparePartApp.UpdateSparePart(sparePart);
                if (SparePartIsUpdated)
                {
                    return Ok(SparePartIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{SparePartId}")]
        public async Task<IActionResult> DeleteSparePart(string SparePartId)
        {
            var SparePartIsDeleted = await _sparePartApp.DeleteSparePart(SparePartId);

            if (SparePartIsDeleted)
            {
                return Ok(SparePartIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

