using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
	public class BusinessDetails
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(15)")]
        [Required]
        public string BusinessDetailsId { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");

        [StringLength(255)]
        public string BusinessDetailsName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string TypeOfBusinessDetailsId { get; set; }
    }
}

