using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
        [Route("api/staff")]
        [ApiController]
        public class StaffController : ControllerBase
        {
            private readonly IStaffApp _staffApp;
            public StaffController(IStaffApp staffApp)
            {
                _staffApp = staffApp;
            }

            [HttpGet]
            public async Task<IActionResult> GetStaffList()
            {
                var staffDetails = await _staffApp.GetAllStaff();
                if (staffDetails == null)
                {
                    return NotFound();
                }
                return Ok(staffDetails);
            }

            [HttpGet("{StaffId}")]
            public async Task<IActionResult> GetStaffById(string StaffId)
            {
                var staffdetails = await _staffApp.GetStaffById(StaffId);

                if (staffdetails != null)
                {
                    return Ok(staffdetails);
                }
                else
                {
                    return BadRequest();
                }
            }

            [HttpPost]
            public async Task<IActionResult> CreateStaff(Staff staff)
            {
                var StaffIsCreated = await _staffApp.CreateStaff(staff);

                if (StaffIsCreated)
                {
                    return Ok(StaffIsCreated);
                }
                else
                {
                    return BadRequest();
                }
            }

            [HttpPut]
            public async Task<IActionResult> UpdateStaff(Staff staff)
            {
                if (staff != null)
                {
                    var StaffIsUpdated = await _staffApp.UpdateStaff(staff);
                    if (StaffIsUpdated)
                    {
                        return Ok(StaffIsUpdated);
                    }
                    return BadRequest();
                }
                else
                {
                    return BadRequest();
                }
            }

            [HttpDelete("{StaffId}")]
            public async Task<IActionResult> DeleteStaff(string StaffId)
            {
                var StaffIsDeleted = await _staffApp.DeleteStaff(StaffId);

                if (StaffIsDeleted)
                {
                    return Ok(StaffIsDeleted);
                }
                else
                {
                    return BadRequest();
                }
            }
        }
}
