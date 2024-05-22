using System;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork

	{
        private readonly DataContext _dataContext;

        public IDepartmentRepository Departments { get; }

        public UnitOfWork(DataContext dataContext,
            IDepartmentRepository departmentRepository
            )

        {
            _dataContext = dataContext;
            Departments = departmentRepository;
        }

        public int Save()
        {
            return _dataContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataContext.Dispose();
            }
        }
    }
}

