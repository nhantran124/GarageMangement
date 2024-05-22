using System;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;

namespace GarageManagement.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork

	{
        private readonly DataContext _dataContext;

        public IDepartmentRepository Departments { get; }
        public IStaffRepository AllStaff { get; }

        public UnitOfWork(DataContext dataContext,
            IDepartmentRepository departmentRepository,
            IStaffRepository staffRepository
            )

        {
            _dataContext = dataContext;
            Departments = departmentRepository;
            AllStaff = staffRepository;
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

