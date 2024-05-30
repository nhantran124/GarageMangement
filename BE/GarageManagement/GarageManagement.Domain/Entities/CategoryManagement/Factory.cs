using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
	public class Factory
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int FactoryId { get; set; }

        [StringLength(150)]
        public string FactoryName { get; set; }

        [StringLength(150)]
        public string Note { get; set; }
    }
}

