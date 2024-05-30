using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyInfoController : ControllerBase
	{
		private readonly ICompanyInfoApp _companyInfoApp;
		public CompanyInfoController(ICompanyInfoApp companyInfoApp)
		{
			_companyInfoApp = companyInfoApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanyInfo()
        {
            var companyGroupInfo= await _companyInfoApp.GetAllCompanyInfo();
            if (companyGroupInfo == null)
            {
                return NotFound();
            }
            return Ok(companyGroupInfo);
        }

        [HttpGet("{CompanyId}")]
        public async Task<IActionResult> GetFactorybyId(int CompanyId)
        {
            var companyGroupInfo = await _companyInfoApp.GetCompanyInfoById(CompanyId);

            if (companyGroupInfo != null)
            {
                return Ok(companyGroupInfo);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyInfo(CompanyInfo companyInfo)
        {
            var CompanyInfoIsCreated = await _companyInfoApp.CreateCompanyInfo(companyInfo);

            if (CompanyInfoIsCreated)
            {
                return Ok(CompanyInfoIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompanyInfo(CompanyInfo companyInfo)
        {
            if (companyInfo != null)
            {
                var CompanyInfoIsUpdated = await _companyInfoApp.UpdateCompanyInfo(companyInfo);
                if (CompanyInfoIsUpdated)
                {
                    return Ok(CompanyInfoIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{CompanyId}")]
        public async Task<IActionResult> DeleteCompanyInfo(int CompanyId)
        {
            var CompanyInfoIsDeleted = await _companyInfoApp.DeleteCompanyInfo(CompanyId);

            if (CompanyInfoIsDeleted)
            {
                return Ok(CompanyInfoIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

