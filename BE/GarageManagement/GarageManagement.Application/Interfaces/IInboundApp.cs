using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface IInboundApp
	{
        Task<bool> CreateInbound(Inbound inbound);
        Task<IEnumerable<Inbound>> GetAllInbound();
        Task<Inbound> GetInboundById(string InvoiceEnterId);
        Task<bool> UpdateInbound(Inbound inbound);
        Task<bool> DeleteInbound(string InvoiceEnterId);
    }
}

