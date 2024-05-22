using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
    public class AccessControlSystem
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(15)")]
        [Required]
        public string VehicleId { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string TypeOfVehicleId { get; set; }

        [Column(TypeName = "varchar(20)")]
        public int LicensePlates { get; set; }

        [Column(TypeName = "varchar(20)")]
        public int VehicleNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public int ChassisNumber { get; set; }

        [StringLength(255)]
        public int VehicleColor { get; set; }
    }
}

