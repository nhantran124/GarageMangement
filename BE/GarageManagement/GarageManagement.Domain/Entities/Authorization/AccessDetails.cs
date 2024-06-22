using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.Authorization
{
	public class AccessDetails
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccessId { get; set; }

        [StringLength(300)]
        public string AccessURL { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        [StringLength(50)]
        public string PermissionSymbol { get; set; }

        [StringLength(100)]
        public string? PermissionURL { get; set; }

    }
}

