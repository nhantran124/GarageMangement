using System;
using GarageManagement.Domain.Entities.InboundManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class InboundRepository : GenericRepository<Inbound>, IInboundRepository
	{
		public InboundRepository(DataContext dataContext) : base(dataContext)
		{
		}
	}
}

