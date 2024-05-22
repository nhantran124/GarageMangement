using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class StaffRepository : GenericRepository<Staff>, IStaffRepository
	{
		public StaffRepository(DataContext dataContext) : base(dataContext)
        {

		}
	}
}

