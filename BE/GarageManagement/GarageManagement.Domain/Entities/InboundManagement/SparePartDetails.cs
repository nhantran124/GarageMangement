using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.InboundManagement
{
	public class SparePartDetails
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(15)")]
        [Required]
        public string SparePartDetailsId { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");

        [StringLength(500)]
        public string SparePartDetailsName { get; set; }

        [StringLength(150)]
        public string SparePartDetailsOtherName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? SparePartId { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string SparePartSupplierId { get; set; }

        [Column(TypeName = "float")]
        public float SparePartPrice { get; set; }

        [StringLength(50)]
        public string SparePartPosition { get; set; }

        [StringLength(20)]
        public string SparePartUnitCal { get; set; }

    }
}

