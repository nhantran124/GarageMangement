using System;
using GarageManagement.Domain.Entities.CategoryManagement;


namespace GarageManagement.Application.Interfaces
{
	public interface IStaffApp
	{
        Task<bool> CreateStaff(Staff staff);
        Task<IEnumerable<Staff>> GetAllStaff();
        Task<Staff> GetStaffById(string StaffId);
        Task<bool> UpdateStaff(Staff staff);
        Task<bool> DeleteStaff(string StaffId);
        Task<Staff> LoginUser(string Username, string Password);
        Task<bool> ChangePassword(string staffId, string newPassword);
    }
}

