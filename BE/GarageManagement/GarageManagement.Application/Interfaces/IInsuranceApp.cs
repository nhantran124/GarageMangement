using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface IInsuranceApp
	{
        Task<bool> CreateInsurance(Insurance insurance);
        Task<IEnumerable<Insurance>> GetAllInsurance();
        Task<Insurance> GetInsuranceById(string InsuranceId);
        Task<bool> UpdateInsurance(Insurance insurance);
        Task<bool> DeleteInsurance(string InsuranceId);
    }
}

