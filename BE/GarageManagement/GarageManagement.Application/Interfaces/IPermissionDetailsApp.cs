using System;
using GarageManagement.Domain.Entities.Authorization;

namespace GarageManagement.Application.Interfaces
{
	public interface IPermissionDetailsApp
	{
        Task<bool> CreatePermissionDetails(PermissionDetails permissionDetails);
        Task<IEnumerable<PermissionDetails>> GetAllPermissionDetails();
        Task<PermissionDetails> GetPermissionDetailsById(int PermissionId);
        Task<bool> UpdatePermissionDetails(PermissionDetails permissionDetails);
        Task<bool> DeletePermissionDetails(int PermissionId);
    }
}

