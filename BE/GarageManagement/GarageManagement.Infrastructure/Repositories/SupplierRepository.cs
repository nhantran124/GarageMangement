using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
	{
        public SupplierRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}

