using System;
namespace GarageManagement.Application.DTO
{
    public class RepairBillDTO
    {
        public int RepairCardId { get; set; }
        public string StaffId { get; set; }
        public DateTime DateEntryCard { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TaxGTGT { get; set; }
        public int SearchWarrant { get; set; }
        public string VehicleId { get; set; }
        public DateTime VehicleReturnDate { get; set; }
        public string CustomerId { get; set; }
        public string? InsuranceId { get; set; }
        public string? Censor { get; set; }
        public float? Kilometer { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? Note { get; set; }
        public int FactoryId { get; set; }
    }
}

