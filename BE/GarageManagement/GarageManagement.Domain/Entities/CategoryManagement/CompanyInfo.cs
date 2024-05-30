using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
	public class CompanyInfo
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CompanyId { get; set; } 

        [StringLength(150)]
        public string CompanyName { get; set; }

        [StringLength(150)]
        public string CompanyAddress { get; set; }
            
        [Column(TypeName = "varchar(30)")]
        public string CompanyPhoneNumber { get; set; }

        [StringLength(150)]
        public string CompanyEmail { get; set; }

        [StringLength(50)]
        public string CompanyWeb { get; set; }

        [StringLength(50)]
        public string CompanyTax { get; set; }

        [Column(TypeName = "nvarchar(MAX)")] 
        public string NotePrice { get; set; }
    }
}

