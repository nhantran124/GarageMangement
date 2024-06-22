using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.InboundManagement
{
	public class AccessoryWarehouse
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string SupplierSparePartId { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string SparePartDetailsId { get; set; }

        [Column(TypeName = "float")]
        public float? InputPrice { get; set; }

        [Column(TypeName = "float")]
        public float? Quantity { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? SupplierId { get; set; }

        public DateTime? DayEnter { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Barcode { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? InvoiceEnterId { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? RepairCardId { get; set; }
    }
}

