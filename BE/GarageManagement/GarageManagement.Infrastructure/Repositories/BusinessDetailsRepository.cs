using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class BusinessDetailsRepository : GenericRepository<BusinessDetails>, IBusinessDetailsRepository
	{
		public BusinessDetailsRepository(DataContext dataContext) : base(dataContext)
		{
		}
	}
}

