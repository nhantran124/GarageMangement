using System;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
    public class RoleDetailsRepository : GenericRepository<RoleDetails>, IRoleDetailsRepository
    {
        public RoleDetailsRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<RoleDetails> GetById(int roleId)
        {
            return await _dataContext.Set<RoleDetails>().FindAsync(roleId); // Sử dụng _dataContext
        }
    }
}

