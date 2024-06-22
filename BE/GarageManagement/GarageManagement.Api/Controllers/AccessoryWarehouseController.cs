using System;
using System.Text;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GarageManagement.Api.Controllers
{
    [Route("api/accessoryWarehouse")]
    [ApiController]
    public class AccessoryWarehouseController : ControllerBase
    {
        private readonly IAccessoryWarehouseApp _accessoryWarehouseApp;
        public AccessoryWarehouseController(IAccessoryWarehouseApp accessoryWarehouseApp)
        {
            _accessoryWarehouseApp = accessoryWarehouseApp;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccessoryWarehouse()
        {
            var AccessoryWarehouseList = await _accessoryWarehouseApp.GetAllAccessoryWarehouse();
            if (AccessoryWarehouseList == null)
            {
                return NotFound();
            }
            return Ok(AccessoryWarehouseList);

        }

        [HttpGet("{SupplierSparePartId}")]
        public async Task<IActionResult> GetAccessoryWarehouseById(string GetAccessoryWarehouseById)
        {
            var AccessoryWarehouseDetails = await _accessoryWarehouseApp.GetAccessoryWarehouseById(GetAccessoryWarehouseById);
            if (AccessoryWarehouseDetails != null)
            {
                return Ok(AccessoryWarehouseDetails);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAccessoryWarehouse([FromBody] AccessoryWarehouse accessoryWarehouse)
        {
            var accessoryWarehouseIsCreated = await _accessoryWarehouseApp.CreateAccessoryWarehouse(accessoryWarehouse);

            if (accessoryWarehouseIsCreated)
            {
                return Ok(accessoryWarehouseIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }



        [HttpPut]
        public async Task<IActionResult> UpdateAccessoryWarehouse(AccessoryWarehouse accessoryWarehouse)
        {
            if (accessoryWarehouse != null)
            {
                var AccessoryWarehouseIsUpdated = await _accessoryWarehouseApp.UpdateAccessoryWarehouse(accessoryWarehouse);
                if (AccessoryWarehouseIsUpdated)
                {
                    return Ok(AccessoryWarehouseIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{SupplierSparePartId}")]
        public async Task<IActionResult> DeleteAccessoryWarehouse(string SupplierSparePartId)
        {
            var AccessoryWarehouseIsDeleted = await _accessoryWarehouseApp.DeleteAccessoryWarehouse(SupplierSparePartId);

            if (AccessoryWarehouseIsDeleted)
            {
                return Ok(AccessoryWarehouseIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    } 
}

