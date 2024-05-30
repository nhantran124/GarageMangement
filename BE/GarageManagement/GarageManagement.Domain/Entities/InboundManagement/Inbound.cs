using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.InboundManagement
{
	public class Inbound
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string InvoiceEnterId { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime DayEnter { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string SupplierId { get; set; }

        [Column(TypeName = "float")]
        public float TotalPrice { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string StaffId { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string InvoiceCode { get; set; }

        [Column(TypeName = "float")]
        public float VAT { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string RepairCodeId { get; set; }
    }
}

