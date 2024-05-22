using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
	public class DepartmentDetails
	{
		[Key]
		[Required]
		[Column(TypeName = "varchar(15)")]
		public string DepartmentId { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");

        [StringLength(255)]
		[Required]
		public string DepartmentName { get; set; }

        [StringLength(2000)]
        public string DepartmentNote { get; set; }
    }
}

