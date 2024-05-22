using System;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<DepartmentDetails>, IDepartmentRepository
    {
        public DepartmentRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}

