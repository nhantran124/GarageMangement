using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.MaintenanceManagement
{
	public class RepairBillDetails
	{
        [Key]
        [Required]
        public int RepairCardId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RepairCVCardId { get; set; }

        [Required]
        public int TypeOfBusiness { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string BusinessDetailsId { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string? SparePartDetailsId { get; set; }

        [Required]
        //decimal (3, 1)
        public decimal Quantity { get; set; }

        [Required]
        //decimal (18, 0)
        public decimal UnitPrice { get; set; }

        [Required]
        //decimal (18, 0)
        public decimal Total { get; set; }
    }
}

