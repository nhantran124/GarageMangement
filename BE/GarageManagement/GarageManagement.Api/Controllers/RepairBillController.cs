using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarageManagement.Application.DTO;
using GarageManagement.Infrastructure.Data;
using GarageManagement.Domain.Entities.MaintenanceManagement;

namespace GarageManagement.API.Controllers
{
    [Route("api/RepairBill")]
    [ApiController]
    public class RepairBillsController : ControllerBase
    {
        private readonly DataContext _context;

        public RepairBillsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairBillDTO>>> GetRepairBills()
        {
            var repairBills = await _context.RepairBillDb
                .Include(rb => rb.Staff)
                .Include(rb => rb.VehicleDetails)
                .Include(rb => rb.CustomerInfo)
                .ToListAsync();

            var repairBillDTOs = repairBills.Select(rb => MapToDTO(rb)).ToList();
            return Ok(repairBillDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepairBillDTO>> GetRepairBill(int id)
        {
            var repairBill = await _context.RepairBillDb
                .Include(rb => rb.Staff)
                .Include(rb => rb.VehicleDetails)
                .Include(rb => rb.CustomerInfo)
                .FirstOrDefaultAsync(rb => rb.RepairCardId == id);

            if (repairBill == null)
            {
                return NotFound();
            }

            var repairBillDTO = MapToDTO(repairBill);
            return Ok(repairBillDTO);
        }

        [HttpPost]
        public async Task<ActionResult<RepairBillDTO>> CreateRepairBill(RepairBillDTO repairBillDTO)
        {
            var repairBill = MapToEntity(repairBillDTO);
            _context.RepairBillDb.Add(repairBill);
            await _context.SaveChangesAsync();

            repairBillDTO.RepairCardId = repairBill.RepairCardId;
            return CreatedAtAction(nameof(GetRepairBill), new { id = repairBill.RepairCardId }, repairBillDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRepairBill(int id, RepairBillDTO repairBillDTO)
        {
            if (id != repairBillDTO.RepairCardId)
            {
                return BadRequest();
            }

            var repairBill = MapToEntity(repairBillDTO);
            _context.Entry(repairBill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairBillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairBill(int id)
        {
            var repairBill = await _context.RepairBillDb.FindAsync(id);
            if (repairBill == null)
            {
                return NotFound();
            }

            _context.RepairBillDb.Remove(repairBill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepairBillExists(int id)
        {
            return _context.RepairBillDb.Any(rb => rb.RepairCardId == id);
        }

        private RepairBillDTO MapToDTO(RepairBill repairBill)
        {
            return new RepairBillDTO
            {
                RepairCardId = repairBill.RepairCardId,
                StaffId = repairBill.StaffId,
                DateEntryCard = repairBill.DateEntryCard,
                TotalPrice = repairBill.TotalPrice,
                TaxGTGT = repairBill.TaxGTGT,
                SearchWarrant = repairBill.SearchWarrant,
                VehicleId = repairBill.VehicleId,
                VehicleReturnDate = repairBill.VehicleReturnDate,
                CustomerId = repairBill.CustomerId,
                InsuranceId = repairBill.InsuranceId,
                Censor = repairBill.Censor,
                Kilometer = repairBill.Kilometer,
                InvoiceNumber = repairBill.InvoiceNumber,
                Note = repairBill.Note,
                FactoryId = repairBill.FactoryId
            };
        }

        private RepairBill MapToEntity(RepairBillDTO repairBillDTO)
        {
            return new RepairBill
            {
                RepairCardId = repairBillDTO.RepairCardId,
                StaffId = repairBillDTO.StaffId,
                DateEntryCard = repairBillDTO.DateEntryCard,
                TotalPrice = repairBillDTO.TotalPrice,
                TaxGTGT = repairBillDTO.TaxGTGT,
                SearchWarrant = repairBillDTO.SearchWarrant,
                VehicleId = repairBillDTO.VehicleId,
                VehicleReturnDate = repairBillDTO.VehicleReturnDate,
                CustomerId = repairBillDTO.CustomerId,
                InsuranceId = repairBillDTO.InsuranceId,
                Censor = repairBillDTO.Censor,
                Kilometer = repairBillDTO.Kilometer,
                InvoiceNumber = repairBillDTO.InvoiceNumber,
                Note = repairBillDTO.Note,
                FactoryId = repairBillDTO.FactoryId
            };
        }
    }
}