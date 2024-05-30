using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Domain.Interfaces
{
    public interface IFactoryRepository : IGenericRepository<Factory>
    {
        Task<Factory> GetById(int factoryId);
    }
}

