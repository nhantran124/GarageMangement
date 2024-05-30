using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
	[Route("api/customer")]
	[ApiController]
	public class CustomerInfoController : ControllerBase
	{
		private readonly ICustomerInfoApp _customerInfoApp;
		public CustomerInfoController(ICustomerInfoApp customerInfoApp)
		{
			_customerInfoApp = customerInfoApp;
		}

        [HttpGet]
        public async Task<IActionResult> GetAllCustomerInfo()
        {
            var customerGroupInfo = await _customerInfoApp.GetAllCustomerInfo();
            if (customerGroupInfo == null)
            {
                return NotFound();
            }
            return Ok(customerGroupInfo);
        }

        [HttpGet("{CustomerId}")]
        public async Task<IActionResult> GetCustomerInfoById(string CustomerId)
        {
            var customerGroupInfo = await _customerInfoApp.GetCustomerInfoById(CustomerId);

            if (customerGroupInfo != null)
            {
                return Ok(customerGroupInfo);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerInfoDetails(CustomerInfo customerInfo)
        {
            var CustomerInfoIsCreated = await _customerInfoApp.CreateCustomerInfoDetails(customerInfo);

            if (CustomerInfoIsCreated)
            {
                return Ok(CustomerInfoIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerInfo(CustomerInfo customerInfo)
        {
            if (customerInfo != null)
            {
                var CustomerInfoIsUpdated = await _customerInfoApp.UpdateCustomerInfo(customerInfo);
                if (CustomerInfoIsUpdated)
                {
                    return Ok(CustomerInfoIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{CustomerId}")]
        public async Task<IActionResult> DeleteCustomerInfo(string CustomerId)
        {
            var CustomerInfoIsDeleted = await _customerInfoApp.DeleteCustomerInfo(CustomerId);

            if (CustomerInfoIsDeleted)
            {
                return Ok(CustomerInfoIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

