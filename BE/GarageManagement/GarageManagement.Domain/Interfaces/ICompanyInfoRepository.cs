using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Domain.Interfaces
{
	public interface ICompanyInfoRepository : IGenericRepository<CompanyInfo>
	{
		Task<CompanyInfo> GetById(int companyId);
	}
}

