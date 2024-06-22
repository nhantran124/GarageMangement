using System;
using System.ComponentModel.DataAnnotations;

namespace GarageManagement.Domain.Entities.Authorization
{
    public class ChangePasswordRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}

