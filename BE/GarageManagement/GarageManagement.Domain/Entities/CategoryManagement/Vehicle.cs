using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
	public class Vehicle
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(15)")]
        [Required]
        public string TypeOfVehicle { get; set; }

        [Required]
        [StringLength(255)]
        public string NameOfVehicle { get; set; }

        [StringLength(2000)]
        public int Note { get; set; }
    }
}

