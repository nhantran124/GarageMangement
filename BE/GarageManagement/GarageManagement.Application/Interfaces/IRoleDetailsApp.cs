using System;
using GarageManagement.Domain.Entities.Authorization;

namespace GarageManagement.Application.Interfaces
{
	public interface IRoleDetailsApp
	{
        Task<bool> CreateRoleDetails(RoleDetails roleDetails);
        Task<IEnumerable<RoleDetails>> GetAllRoleDetails();
        Task<RoleDetails> GetRoleDetailsById(int RoleId);
        Task<bool> UpdateRoleDetails(RoleDetails roleDetails);
        Task<bool> DeleteRoleDetails(int RoleId);
    }
}

