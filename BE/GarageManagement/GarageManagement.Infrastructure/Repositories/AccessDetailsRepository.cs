using System;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;


namespace GarageManagement.Infrastructure.Repositories
{
    public class AccessDetailsRepository : GenericRepository<AccessDetails>, IAccessDetailsRepository
    {
        public AccessDetailsRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<AccessDetails> GetById(int accessId)
        {
            return await _dataContext.Set<AccessDetails>().FindAsync(accessId); // Sử dụng _dataContext
        }
    }
}
