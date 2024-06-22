using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Domain.Entities.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
	[Route("api/permissionDetails")]
	[ApiController]
	public class PermissionDetailsController : ControllerBase
	{
		private readonly IPermissionDetailsApp _permissionDetailsApp;
		public PermissionDetailsController(IPermissionDetailsApp permissionDetailsApp)
		{
			_permissionDetailsApp = permissionDetailsApp;
        }

		[HttpGet]
        public async Task<IActionResult> GetAllPermissionDetails()
        {
            var PermissionDetailsList = await _permissionDetailsApp.GetAllPermissionDetails();
            if (PermissionDetailsList == null)
            {
                return NotFound();
            }
            return Ok(PermissionDetailsList);
        }

        [HttpGet("{PermissionId}")]
        public async Task<IActionResult> GetPermissionDetailsById(int PermissionId)
        {
            var PermissionEachOneDetails = await _permissionDetailsApp.GetPermissionDetailsById(PermissionId);

            if (PermissionEachOneDetails != null)
            {
                return Ok(PermissionEachOneDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermissionDetails(PermissionDetails permissionDetails)
        {
            var PermissionDetailsIsCreated = await _permissionDetailsApp.CreatePermissionDetails(permissionDetails);

            if (PermissionDetailsIsCreated)
            {
                return Ok(PermissionDetailsIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePermissionDetails(PermissionDetails permissionDetails)
        {
            if (permissionDetails != null)
            {
                var PermissionDetailsIsUpdated = await _permissionDetailsApp.UpdatePermissionDetails(permissionDetails);
                if (PermissionDetailsIsUpdated)
                {
                    return Ok(PermissionDetailsIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{PermissionId}")]
        public async Task<IActionResult> DeletePermissionDetails(int PermissionId)
        {
            var PermissionDetailsIsDeleted = await _permissionDetailsApp.DeletePermissionDetails(PermissionId);

            if (PermissionDetailsIsDeleted)
            {
                return Ok(PermissionDetailsIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

