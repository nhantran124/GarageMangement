using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class VehicleDetailsRepository : GenericRepository<VehicleDetails>, IVehicleDetailsRepository
	{
		public VehicleDetailsRepository(DataContext dataContext) : base(dataContext)
		{
		}
	}
}

