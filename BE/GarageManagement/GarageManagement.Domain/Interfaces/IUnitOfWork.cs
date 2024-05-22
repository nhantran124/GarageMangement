using System;
namespace GarageManagement.Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
    {
		IDepartmentRepository Departments { get;  }
		IStaffRepository AllStaff { get;  }
		int Save();
	}
}

