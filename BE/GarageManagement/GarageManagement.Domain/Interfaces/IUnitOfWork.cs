using System;
namespace GarageManagement.Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
    {
		IDepartmentRepository Departments { get;  }
		int Save();
	}
}

