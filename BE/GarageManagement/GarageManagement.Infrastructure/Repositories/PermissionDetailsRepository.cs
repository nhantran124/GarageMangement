using System;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class PermissionDetailsRepository : GenericRepository<PermissionDetails>, IPermissionDetailsRepository
	{
		public PermissionDetailsRepository(DataContext dataContext) : base(dataContext)
		{

		}

		public async Task<PermissionDetails> GetById(int permissionId)
		{
			return await _dataContext.Set<PermissionDetails>().FindAsync(permissionId);
		}
	}
}

