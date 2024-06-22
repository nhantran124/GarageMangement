using System;
using GarageManagement.Domain.Entities.Authorization;

namespace GarageManagement.Domain.Interfaces
{
	public interface IPermissionDetailsRepository : IGenericRepository<PermissionDetails>
	{
        Task<PermissionDetails> GetById(int permissionId);
    }
}

