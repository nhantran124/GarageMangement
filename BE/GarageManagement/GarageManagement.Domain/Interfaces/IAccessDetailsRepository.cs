using System;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Domain.Interfaces
{
	public interface IAccessDetailsRepository : IGenericRepository<AccessDetails>
	{
        Task<AccessDetails> GetById(int accessId);
    }
}

