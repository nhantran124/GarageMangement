using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
	public class Supplier
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(15)")]
        [Required]
        public string SupplierId { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");

        [StringLength(255)]
        [Required]
        public string SupplierName { get; set; }

        [StringLength(255)]
        public string SupplierAddress { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string SupplierPhonenumber { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string SupplierTax { get; set; }

        [StringLength(255)]
        public string SupplierBank { get; set; }

        [StringLength(255)]
        public string SupplierBranch { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string AccountNumber { get; set; }

    }
}

