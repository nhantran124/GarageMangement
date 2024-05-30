using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GarageManagement.Infrastructure.Repositories
{
    public class FactoryRepository : GenericRepository<Factory>, IFactoryRepository
    {
        public FactoryRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<Factory> GetById(int factoryId)
        {
            return await _dataContext.Set<Factory>().FindAsync(factoryId); // Sử dụng _dataContext
        }
    }
}

