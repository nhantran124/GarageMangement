using System;
using GarageManagement.Domain.Entities.InboundManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class AccessoryWarehouseRepository : GenericRepository<AccessoryWarehouse>, IAccessoryWarehouseRepository
    {
		public AccessoryWarehouseRepository(DataContext dataContext) : base(dataContext)
		{

		}
	}
}

