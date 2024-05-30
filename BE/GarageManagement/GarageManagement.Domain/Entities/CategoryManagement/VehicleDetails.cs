using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
    public class VehicleDetails
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(15)")]
        [Required]
        public string VehicleId { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string TypeOfVehicleId { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string LicensePlates { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string VehicleNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ChassisNumber { get; set; }

        [StringLength(255)]
        public string VehicleColor { get; set; }
    }
}

