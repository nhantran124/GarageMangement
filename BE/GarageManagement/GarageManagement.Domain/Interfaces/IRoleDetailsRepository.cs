using System;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Domain.Interfaces
{
    public interface IRoleDetailsRepository : IGenericRepository<RoleDetails>
    {
        Task<RoleDetails> GetById(int roleId);
    }
}

