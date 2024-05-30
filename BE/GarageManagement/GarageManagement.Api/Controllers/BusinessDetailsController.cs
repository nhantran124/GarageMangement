using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
	[Route("api/business")]
	[ApiController]
	public class BusinessDetailsController : ControllerBase
	{
		private readonly IBusinessDetailsApp _businessDetailsApp;
		public BusinessDetailsController(IBusinessDetailsApp businessDetailsApp)
		{
			_businessDetailsApp = businessDetailsApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBusinessDetails()
        {
            var businessList = await _businessDetailsApp.GetAllBusinessDetails();
            if (businessList == null)
            {
                return NotFound();
            }
            return Ok(businessList);
        }

        [HttpGet("{BusinessDetailsId}")]
        public async Task<IActionResult> GetBusinessDetailsById(string BusinessDetailsId)
        {
            var businessDetails = await _businessDetailsApp.GetBusinessDetailsById(BusinessDetailsId);

            if (businessDetails != null)
            {
                return Ok(businessDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessDetails(BusinessDetails businessDetails)
        {
            var BusinessDetailsIsCreated = await _businessDetailsApp.CreateBusinessDetails(businessDetails);

            if (BusinessDetailsIsCreated)
            {
                return Ok(BusinessDetailsIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBusinessDetails(BusinessDetails businessDetails)
        {
            if (businessDetails != null)
            {
                var BusinessDetailsIsUpdated = await _businessDetailsApp.UpdateBusinessDetails(businessDetails);
                if (BusinessDetailsIsUpdated)
                {
                    return Ok(BusinessDetailsIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{BusinessDetailsId}")]
        public async Task<IActionResult> DeleteBusinessDetails(string BusinessDetailsId)
        {
            var BusinessDetailsIsDeleted = await _businessDetailsApp.DeleteBusinessDetails(BusinessDetailsId);

            if (BusinessDetailsIsDeleted)
            {
                return Ok(BusinessDetailsIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

