using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Domain.Entities.MaintenanceManagement
{
	public class RepairBill
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int RepairCardId { get; set; }

        [Required]
        [ForeignKey("Staff")]
        public string StaffId { get; set; }
        public Staff Staff { get; set; }

        [Required]
        public DateTime DateEntryCard { get; set; }

        //decimal (18, 0)
        [Required]
        public decimal TotalPrice { get; set; } = 0;

        //decimal (2, 1)
        [Required]
        public decimal TaxGTGT { get; set; } = 10;

        [Required]
        public int SearchWarrant { get; set; } = 0;

        [Required]
        [ForeignKey("VehicleDetails")]
        public string VehicleId { get; set; }
        public VehicleDetails VehicleDetails { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public DateTime VehicleReturnDate { get; set; }

        [Required]
        [ForeignKey("CustomerInfo")]
        public string CustomerId { get; set; }
        public CustomerInfo CustomerInfo { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? InsuranceId { get; set; }

        [StringLength(520)]
        public string? Censor { get; set; }

        [Column(TypeName = "float")]
        public float? Kilometer { get; set; }

        [StringLength(400)]
        public string? InvoiceNumber { get; set; }

        [StringLength(400)]
        public string? Note { get; set; }

        [Required]
        [ForeignKey("Factory")]
        public int FactoryId { get; set; } = 0;
        public Factory Factory { get; set; }
    }
}

