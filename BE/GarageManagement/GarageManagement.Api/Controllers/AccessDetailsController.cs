using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
	[Route("api/accessDetails")]
	[ApiController]
	public class AccessDetailsController : ControllerBase
	{
		private readonly IAccessDetailsApp _accessDetailsApp;
		public AccessDetailsController(IAccessDetailsApp accessDetailsApp)
		{
			_accessDetailsApp = accessDetailsApp;
        }

		[HttpGet]
        public async Task<IActionResult> GetAllAccessDetails()
        {
            var AccessDetailsList = await _accessDetailsApp.GetAllAccessDetails();
            if (AccessDetailsList == null)
            {
                return NotFound();
            }
            return Ok(AccessDetailsList);
        }

        [HttpGet("{AccessId}")]
        public async Task<IActionResult> GetAccessDetailsById(int AccessId)
        {
            var AccessEachOneDetails = await _accessDetailsApp.GetAccessDetailsById(AccessId);

            if (AccessEachOneDetails != null)
            {
                return Ok(AccessEachOneDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccessDetails(AccessDetails accessDetails)
        {
            var AccessDetailsIsCreated = await _accessDetailsApp.CreateAccessDetails(accessDetails);

            if (AccessDetailsIsCreated)
            {
                return Ok(AccessDetailsIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccessDetails(AccessDetails accessDetails)
        {
            if (accessDetails != null)
            {
                var AccessDetailsIsUpdated = await _accessDetailsApp.UpdateAccessDetails(accessDetails);
                if (AccessDetailsIsUpdated)
                {
                    return Ok(AccessDetailsIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{AccessId}")]
        public async Task<IActionResult> DeleteAccessDetails(int AccessId)
        {
            var AccessDetailsIsDeleted = await _accessDetailsApp.DeleteAccessDetails(AccessId);

            if (AccessDetailsIsDeleted)
            {
                return Ok(AccessDetailsIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}

