using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.CategoryManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace GarageManagement.Api.Controllers
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffApp _staffApp;
        private readonly IConfiguration _configuration;

        public StaffController(IStaffApp staffApp, IConfiguration configuration)
        {
            _staffApp = staffApp;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginRequest request)
        {
            var user = await _staffApp.LoginUser(request.Username, request.Password);

            if (user != null)
            {
                var token = GenerateJwtToken(user.StaffId);
                return Ok(new
                {
                    username = user.Username,
                    token = token,
                });
            }
            else
            {
                return BadRequest("Invalid username or password");
            }
        }


        [HttpPut("{staffId}/change-password")]
        public async Task<IActionResult> ChangePassword(string staffId, ChangePasswordRequest request)
        {
            var result = await _staffApp.ChangePassword(staffId, request.NewPassword);

            if (result)
            {
                return Ok(new { Status = "Success", Message = "Password changed successfully" });
            }
            else
            {
                return BadRequest(new { Status = "Error", Message = "Failed to change password" });
            }
        }

        private string GenerateJwtToken(string StaffId)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var authClaims = new List<Claim>
            {
                new Claim("StaffId" ,StaffId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(8),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        public async Task<IActionResult> GetStaffList()
        {
            var staffDetails = await _staffApp.GetAllStaff();
            if (staffDetails == null)
            {
                return NotFound();
            }
            return Ok(staffDetails);
        }

        [HttpGet("{StaffId}")]
        public async Task<IActionResult> GetStaffById(string StaffId)
        {
            var staffdetails = await _staffApp.GetStaffById(StaffId);

            if (staffdetails != null)
            {
                return Ok(staffdetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff(Staff staff)
        {
            var StaffIsCreated = await _staffApp.CreateStaff(staff);

            if (StaffIsCreated)
            {
                return Ok(StaffIsCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStaff(Staff staff)
        {
            if (staff != null)
            {
                var StaffIsUpdated = await _staffApp.UpdateStaff(staff);
                if (StaffIsUpdated)
                {
                    return Ok(StaffIsUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{StaffId}")]
        public async Task<IActionResult> DeleteStaff(string StaffId)
        {
            var StaffIsDeleted = await _staffApp.DeleteStaff(StaffId);

            if (StaffIsDeleted)
            {
                return Ok(StaffIsDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}