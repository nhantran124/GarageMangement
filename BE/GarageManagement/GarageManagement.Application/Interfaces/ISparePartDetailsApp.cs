using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface ISparePartDetailsApp
	{
        Task<bool> CreateSparePartDetails(SparePartDetails sparePartDetails);
        Task<IEnumerable<SparePartDetails>> GetAllSparePartDetails();
        Task<SparePartDetails> GetSparePartDetailsById(string SparePartDetailsId);
        Task<bool> UpdateSparePartDetails(SparePartDetails sparePartDetails);
        Task<bool> DeleteSparePartDetails(string SparePartDetailsId);
    }
}

