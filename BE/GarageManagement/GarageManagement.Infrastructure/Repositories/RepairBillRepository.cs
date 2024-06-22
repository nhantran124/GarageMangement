using System;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.MaintenanceManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
    public class RepairBillRepository : GenericRepository<RepairBill>, IRepairBillRepository
    {
        public RepairBillRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<RepairBill> GetById(int repairCardId)
        {
            return await _dataContext.Set<RepairBill>().FindAsync(repairCardId); // Sử dụng _dataContext
        }
    }
}

