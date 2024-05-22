using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
	public class CustomerInfo
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(15)")]
        [Required]
        public string CustomerId { get; set; }

        [StringLength(255)]
        [Required]
        public string CustomerName { get; set; }

        [StringLength(255)]
        public string CustomerAddress { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string CustomerPhonenumber { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string CustomerTax { get; set; }
    }
}

