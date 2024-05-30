using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class InsuranceRepository : GenericRepository<Insurance>, IInsuranceRepository
	{
		public InsuranceRepository(DataContext dataContext) : base(dataContext)
		{
		}
	}
}

