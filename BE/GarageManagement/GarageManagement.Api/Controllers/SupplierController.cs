using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
	[Route("api/supplier")]
	[ApiController]
	public class SupplierController : ControllerBase
	{
		private readonly ISupplierApp _supplierApp;
		public SupplierController(ISupplierApp supplierApp)
		{
			_supplierApp = supplierApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetSupplierList()
        {
            var supplierDetails = await _supplierApp.GetAllSupplier();
            if (supplierDetails == null)
            {
                return NotFound();
            }
            return Ok(supplierDetails);
        }

        [HttpGet("{SupplierId}")]
        public async Task<IActionResult> GetSupplierbyId(string SupplierId)
        {
            var supplierDetails = await _supplierApp.GetSupplierById(SupplierId);

            if (supplierDetails != null)
            {
                return Ok(supplierDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier(Supplier supplier)
        {
            var SupplierIsCreated = await _supplierApp.CreateSupplier(supplier);

            if (SupplierIsCreated)
            {
                return Ok(SupplierIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                var SupplierIsUpdated = await _supplierApp.UpdateSupplier(supplier);
                if (SupplierIsUpdated)
                {
                    return Ok(SupplierIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{SupplierId}")]
        public async Task<IActionResult> DeleteSupplier(string SupplierId)
        {
            var SupplierIsDeleted = await _supplierApp.DeleteSupplier(SupplierId);

            if (SupplierIsDeleted)
            {
                return Ok(SupplierIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

