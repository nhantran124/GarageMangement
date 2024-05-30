using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class CustomerInfoRepository : GenericRepository<CustomerInfo>, ICustomerInfoRepository
	{
		public CustomerInfoRepository(DataContext dataContext) : base(dataContext)
		{
		}
	}
}

