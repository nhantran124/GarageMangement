using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface ISparePartApp
	{
        Task<bool> CreateSparePart(SparePart sparePart);
        Task<IEnumerable<SparePart>> GetAllSparePart();
        Task<SparePart> GetSparePartById(string SparePartId);
        Task<bool> UpdateSparePart(SparePart sparePart);
        Task<bool> DeleteSparePart(string SparePartId);
    }
}

