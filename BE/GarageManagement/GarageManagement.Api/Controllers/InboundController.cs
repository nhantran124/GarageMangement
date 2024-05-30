using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Application.Services;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;
using Microsoft.AspNetCore.Mvc;

namespace GarageManagement.Api.Controllers
{
    [Route("api/inbound")]
    [ApiController]
    public class InboundController : ControllerBase
	{
		private readonly IInboundApp _inboundApp;
		public InboundController(IInboundApp inboundApp)
		{
			_inboundApp = inboundApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInbound()
        {
            var inboundDetails = await _inboundApp.GetAllInbound();
            if (inboundDetails == null)
            {
                return NotFound();
            }
            return Ok(inboundDetails);
        }

        [HttpGet("{InvoiceEnterId}")]
        public async Task<IActionResult> GetInboundById(string InvoiceEnterId)
        {
            var inboundDetails = await _inboundApp.GetInboundById(InvoiceEnterId);

            if (inboundDetails != null)
            {
                return Ok(inboundDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateInbound(Inbound inbound)
        {
            var InboundIsCreated = await _inboundApp.CreateInbound(inbound);

            if (InboundIsCreated)
            {
                return Ok(InboundIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInbound(Inbound inbound)
        {
            if (inbound != null)
            {
                var InboundIsUpdated = await _inboundApp.UpdateInbound(inbound);
                if (InboundIsUpdated)
                {
                    return Ok(InboundIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{InvoiceEnterId}")]
        public async Task<IActionResult> DeleteInbound(string InvoiceEnterId)
        {
            var InboundIsDeleted = await _inboundApp.DeleteInbound(InvoiceEnterId);

            if (InboundIsDeleted)
            {
                return Ok(InboundIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

