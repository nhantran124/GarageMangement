using System;
using GarageManagement.Domain.Entities.InboundManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class SparePartRepository : GenericRepository<SparePart>, ISparePartRepository
	{
		public SparePartRepository(DataContext dataContext) : base(dataContext)
		{
		}
	}
}

