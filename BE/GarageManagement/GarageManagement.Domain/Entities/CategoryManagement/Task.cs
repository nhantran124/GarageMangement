using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageManagement.Domain.Entities.CategoryManagement
{
	public class Task
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(15)")]
        [Required]
        public string TaskId { get; set; }

        [StringLength(255)]
        public string TaskName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public int TypeOfTask { get; set; }
    }
}

