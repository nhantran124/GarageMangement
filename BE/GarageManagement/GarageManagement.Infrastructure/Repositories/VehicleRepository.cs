using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
	{
		public VehicleRepository(DataContext dataContext) : base(dataContext)
		{
		}
	}
}

