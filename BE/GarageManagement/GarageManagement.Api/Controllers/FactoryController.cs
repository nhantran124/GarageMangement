using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
    [Route("api/factory")]
    [ApiController]
    public class FactoryController : ControllerBase
	{
        private readonly IFactoryApp _factoryApp;
        public FactoryController(IFactoryApp factoryApp)
		{
            _factoryApp = factoryApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetFactoryList()
        {
            var factoryDetails = await _factoryApp.GetAllFactory();
            if (factoryDetails == null)
            {
                return NotFound();
            }
            return Ok(factoryDetails);
        }

        [HttpGet("{FactoryId}")]
        public async Task<IActionResult> GetFactorybyId(int FactoryId)
        {
            var factoryDetails = await _factoryApp.GetFactoryById(FactoryId);

            if (factoryDetails != null)
            {
                return Ok(factoryDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFactory(Factory factory)
        {
            var FactoryIsCreated = await _factoryApp.CreateFactory(factory);

            if (FactoryIsCreated)
            {
                return Ok(FactoryIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFactory(Factory factory)
        {
            if (factory != null)
            {
                var FactoryIsUpdated = await _factoryApp.UpdateFactory(factory);
                if (FactoryIsUpdated)
                {
                    return Ok(FactoryIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{FactoryId}")]
        public async Task<IActionResult> DeleteFactory(int FactoryId)
        {
            var FactoryIsDeleted = await _factoryApp.DeleteFactory(FactoryId);

            if (FactoryIsDeleted)
            {
                return Ok(FactoryIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

