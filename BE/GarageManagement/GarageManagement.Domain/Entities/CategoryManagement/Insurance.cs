using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
	public class Insurance
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(15)")]
        [Required]
        public string InsuranceId { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");

        [StringLength(255)]
        [Required]
        public string InsuranceName { get; set; }

        [StringLength(50)]
        public string InsuranceTax { get; set; }

        [StringLength(500)]
        public string InsuranceAddress { get; set; }

        [StringLength(50)]
        public string InsuranceNumberAccount { get; set; }

        [StringLength(255)]
        public string InsuranceBank { get; set; }

        [StringLength(255)]
        public string InsuranceBranch { get; set; }

    }
}

