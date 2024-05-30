using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.InboundManagement
{
	public class SparePart
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(15)")]
        [Required]
        public string SparePartId { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");

        [StringLength(255)]
        [Required]
        public string SparePartName { get; set; }

        [StringLength(2000)]
        public string SparePartContent { get; set; }
    }
}

