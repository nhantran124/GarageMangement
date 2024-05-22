using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
	public class WorkShop
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int WorkShopId { get; set; }

        [StringLength(155)]
        public int WorkShopName { get; set; }

        [StringLength(155)]
        public int Note { get; set; }
    }
}

