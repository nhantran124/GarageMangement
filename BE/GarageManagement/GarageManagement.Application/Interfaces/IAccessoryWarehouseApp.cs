using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface IAccessoryWarehouseApp
	{
        Task<bool> CreateAccessoryWarehouse(AccessoryWarehouse accessoryWarehouse);
        Task<IEnumerable<AccessoryWarehouse>> GetAllAccessoryWarehouse();
        Task<AccessoryWarehouse> GetAccessoryWarehouseById(string SupplierSparePartId);
        Task<bool> UpdateAccessoryWarehouse(AccessoryWarehouse accessoryWarehouse);
        Task<bool> DeleteAccessoryWarehouse(string SupplierSparePartId);
    }
}

