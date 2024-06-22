using System;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.MaintenanceManagement;

namespace GarageManagement.Domain.Interfaces
{
	public interface IRepairBillRepository : IGenericRepository<RepairBill>
	{
        Task<RepairBill> GetById(int repairCardId);
    }
}

