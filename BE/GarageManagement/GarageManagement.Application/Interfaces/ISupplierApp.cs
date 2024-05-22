using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface ISupplierApp
    {
		
        Task<bool> CreateSupplier(Supplier supplier);
        Task<IEnumerable<Supplier>> GetAllSupplier();
        Task<Supplier> GetSupplierById(string SupplierId);
        Task<bool> UpdateSupplier(Supplier supplier);
        Task<bool> DeleteSupplier(string SupplierId);
    }
}


