using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.Authorization
{
	public class PermissionDetails
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PermissionId { get; set; }

        [StringLength(50)]
        public string PermissionName { get; set; }

        [StringLength(50)]
        public string PermissionSymbol { get; set; }
    }
}

