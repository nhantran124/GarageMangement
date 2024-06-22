using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Domain.Entities.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
    [Route("api/roleDetails")]
    [ApiController]
    public class RoleDetailsController : ControllerBase
    {
        private readonly IRoleDetailsApp _roleDetailsApp;
        public RoleDetailsController(IRoleDetailsApp roleDetailsApp)
        {
            _roleDetailsApp = roleDetailsApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoleDetails()
        {
            var RoleDetailsList = await _roleDetailsApp.GetAllRoleDetails();
            if (RoleDetailsList == null)
            {
                return NotFound();
            }
            return Ok(RoleDetailsList);
        }

        [HttpGet("{RoleId}")]
        public async Task<IActionResult> GetRoleDetailsById(int RoleId)
        {
            var RoleEachOneDetails = await _roleDetailsApp.GetRoleDetailsById(RoleId);

            if (RoleEachOneDetails != null)
            {
                return Ok(RoleEachOneDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleDetails(RoleDetails roleDetails)
        {
            var RoleDetailsIsCreated = await _roleDetailsApp.CreateRoleDetails(roleDetails);

            if (RoleDetailsIsCreated)
            {
                return Ok(RoleDetailsIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoleDetails(RoleDetails roleDetails)
        {
            if (roleDetails != null)
            {
                var RoleDetailsIsUpdated = await _roleDetailsApp.UpdateRoleDetails(roleDetails);
                if (RoleDetailsIsUpdated)
                {
                    return Ok(RoleDetailsIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{RoleId}")]
        public async Task<IActionResult> DeleteRoleDetails(int RoleId)
        {
            var RoleDetailsIsDeleted = await _roleDetailsApp.DeleteRoleDetails(RoleId);

            if (RoleDetailsIsDeleted)
            {
                return Ok(RoleDetailsIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

