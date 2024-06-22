using System;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.MaintenanceManagement;

namespace GarageManagement.Application.Interfaces
{
    public interface IRepairBillApp
    {
        Task<bool> CreateRepairBill(RepairBill repairBill);
        Task<IEnumerable<RepairBill>> GetAllRepairBill();
        Task<RepairBill> GetRepairBillById(int RepairCardId);
        Task<bool> UpdateRepairBill(RepairBill repairBill);
        Task<bool> DeleteRepairBill(int RepairCardId);
    }
}

