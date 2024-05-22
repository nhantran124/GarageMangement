using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
        [Route("api/department")]
        [ApiController]
        public class DepartmentsController : ControllerBase
        {
            private readonly IDepartmentApp _departmentApp;

            public DepartmentsController(IDepartmentApp departmentApp)
            {
                _departmentApp = departmentApp;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllDepartment()
            {
                var departmentDetails = await _departmentApp.GetAllDepartments();
                return Ok(departmentDetails);
            }

            [HttpGet("{DepartmentId}")]
            public async Task<IActionResult> GetDepartmentById(string DepartmentId)
            {
                var departmentName = await _departmentApp.GetDepartmentById(DepartmentId);
                if (departmentName == null)
                {
                    return NotFound();
                }
                return Ok(departmentName);
            }

            [HttpPost]
            public async Task<IActionResult> CreateDepartment(DepartmentDetails departmentDetails)
            {
                var DepartmentIsCreated = await _departmentApp.CreateDepartment(departmentDetails);

                if (DepartmentIsCreated)
                {
                    return Ok(DepartmentIsCreated);
                }
                else
                {
                    return BadRequest();
                }
            }

            [HttpPut]
            public async Task<IActionResult> UpdateDepartment(DepartmentDetails departmentDetails)
            {
                if (departmentDetails != null)
                {
                    var DepIstUpdated = await _departmentApp.UpdateDepartment(departmentDetails);
                    if (DepIstUpdated)
                    {
                        return Ok(DepIstUpdated);
                    }
                    return BadRequest();
                }
                else
                {
                    return BadRequest();
                }
            }

            [HttpDelete("{DepartmentId}")]
            public async Task<IActionResult> DeleteDepartment(string DepartmentId)
            {
                
                    var DepIstDeleted = await _departmentApp.DeleteDepartment(DepartmentId);
                    if (DepIstDeleted)
                    {
                        return Ok(DepIstDeleted);
                    }
                    return BadRequest();
            }
        }
}

