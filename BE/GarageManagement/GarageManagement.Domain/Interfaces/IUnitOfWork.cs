﻿using System;
namespace GarageManagement.Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IDepartmentRepository Departments { get; }
		IStaffRepository AllStaff { get; }
		ISupplierRepository Suppliers { get; }
		IFactoryRepository Factories { get; }
		IVehicleRepository Vehicles { get; }
		IVehicleDetailsRepository VehicleDetailsDb { get; }
		IBusinessDetailsRepository Business { get; }
		IInsuranceRepository Insurances { get; }
		ICompanyInfoRepository CompanyInfos { get; }
		ICustomerInfoRepository CustomerInfos { get; }
		ISparePartRepository SpareParts { get;  }
		ISparePartDetailsRepository SparePartsDetails { get; }
		IInboundRepository Inbounds { get; }
		int Save();
	}
}

