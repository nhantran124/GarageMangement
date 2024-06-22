using System;
using System.ComponentModel.DataAnnotations;

namespace GarageManagement.Domain.Entities.Authorization
{
	public class LoginRequest
	{
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

