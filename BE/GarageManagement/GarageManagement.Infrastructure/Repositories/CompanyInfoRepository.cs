using System.Threading.Tasks;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
    public class CompanyInfoRepository : GenericRepository<CompanyInfo>, ICompanyInfoRepository
    {
        public CompanyInfoRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<CompanyInfo> GetById(int companyId)
        {
            return await _dataContext.Set<CompanyInfo>().FindAsync(companyId);
        }
    }
}
