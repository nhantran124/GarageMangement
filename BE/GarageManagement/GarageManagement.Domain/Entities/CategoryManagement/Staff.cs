using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
	public class Staff
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(15)")]
        [Required]    
		public string StaffId { get; set; }

		[Required]
		[Column(TypeName = "varchar(20)")]
		public string DepartmentId { get; set; }

		public int RoleId { get; set; }

		[StringLength(255)]
		[Required]
		public string StaffName { get; set; }

		[StringLength(255)]
		[Required]
		public string StaffAddress { get; set; }

		[Required]
		[Column(TypeName = "varchar(255)")]
		public string StaffPhonenumber { get; set; }

		[StringLength(255)]
		public string Username { get; set; }

		[StringLength(512)]
		public string Password { get; set; }
	
		public int AccountActive { get; set; }

		[Column(TypeName = "date")]
		public DateTime DayIn { get; set; }

		public int PremissionDay { get; set; }

		[DefaultValue(0)]
		public int Status { get; set; }
	}
}

