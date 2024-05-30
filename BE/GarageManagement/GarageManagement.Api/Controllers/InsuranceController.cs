using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
	[Route("api/insurance")]
	[ApiController]
	public class InsuranceController : ControllerBase
	{
		private readonly IInsuranceApp _insuranceApp;
		public InsuranceController(IInsuranceApp insuranceApp)
		{
            _insuranceApp = insuranceApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInsurance()
        {
            var InsuranceList = await _insuranceApp.GetAllInsurance();
            if (InsuranceList == null)
            {
                return NotFound();
            }
            return Ok(InsuranceList);
        }

        [HttpGet("{InsuranceId}")]
        public async Task<IActionResult> GetInsuranceById(string InsuranceId)
        {
            var insuranceDetails = await _insuranceApp.GetInsuranceById(InsuranceId);

            if (insuranceDetails != null)
            {
                return Ok(insuranceDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateInsurance(Insurance insurance)
        {
            var InsuranceIsCreated = await _insuranceApp.CreateInsurance(insurance);

            if (InsuranceIsCreated)
            {
                return Ok(InsuranceIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInsurance(Insurance insurance)
        {
            if (insurance != null)
            {
                var InsuranceIsUpdated = await _insuranceApp.UpdateInsurance(insurance);
                if (InsuranceIsUpdated)
                {
                    return Ok(InsuranceIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{InsuranceId}")]
        public async Task<IActionResult> DeleteInsurance(string InsuranceId)
        {
            var InsuranceIsDeleted = await _insuranceApp.DeleteInsurance(InsuranceId);

            if (InsuranceIsDeleted)
            {
                return Ok(InsuranceIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

