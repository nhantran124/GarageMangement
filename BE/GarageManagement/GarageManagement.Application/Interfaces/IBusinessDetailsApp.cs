using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface IBusinessDetailsApp
	{
        Task<bool> CreateBusinessDetails(BusinessDetails businessDetails);
        Task<IEnumerable<BusinessDetails>> GetAllBusinessDetails();
        Task<BusinessDetails> GetBusinessDetailsById(string BusinessDetailsId);
        Task<bool> UpdateBusinessDetails(BusinessDetails businessDetails);
        Task<bool> DeleteBusinessDetails(string BusinessDetailsId);
    }
}

