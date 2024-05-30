using System;
using GarageManagement.Domain.Entities.InboundManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class SparePartDetailsRepository : GenericRepository<SparePartDetails>, ISparePartDetailsRepository
	{
		public SparePartDetailsRepository(DataContext dataContext) : base(dataContext)
		{
		}
	}
}

