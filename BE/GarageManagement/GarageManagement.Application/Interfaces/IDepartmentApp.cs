using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface IDepartmentApp
	{
        Task<bool> CreateDepartment(DepartmentDetails departmentDetails);
        // Dòng dưới câu DepartmentDetails có thể thay đổi tên khi sở hữu khoá ngoại
        Task<IEnumerable<DepartmentDetails>> GetAllDepartments();
        Task<DepartmentDetails> GetDepartmentById(string DepartmentId);
        Task<bool> UpdateDepartment(DepartmentDetails departmentDetails);
        Task<bool> DeleteDepartment(string DepartmentId);
    }
}

