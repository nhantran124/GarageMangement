using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface ICompanyInfoApp
	{
        Task<bool> CreateCompanyInfo(CompanyInfo companyInfo);
        Task<IEnumerable<CompanyInfo>> GetAllCompanyInfo();
        Task<CompanyInfo> GetCompanyInfoById(int CompanyId);
        Task<bool> UpdateCompanyInfo(CompanyInfo companyInfo);
        Task<bool> DeleteCompanyInfo(int CompanyId);
    }
}

