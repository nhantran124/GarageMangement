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
        public ISupplierRepository Suppliers { get; }
        public IFactoryRepository Factories { get; }
        public IVehicleRepository Vehicles { get; }
        public IVehicleDetailsRepository VehicleDetailsDb { get; }
        public IBusinessDetailsRepository Business { get; }
        public IInsuranceRepository Insurances { get; }
        public ICompanyInfoRepository CompanyInfos { get; }
        public ICustomerInfoRepository CustomerInfos { get; }
        public ISparePartRepository  SpareParts { get; }
        public ISparePartDetailsRepository SparePartsDetails { get; }
        public IInboundRepository Inbounds { get; }

        public UnitOfWork(DataContext dataContext,
            IDepartmentRepository departmentRepository,
            IStaffRepository staffRepository,
            ISupplierRepository supplierRepository,
            IFactoryRepository factoryRepository,
            IVehicleRepository vehicleRepository,
            IVehicleDetailsRepository vehicleDetailsRepository,
            IBusinessDetailsRepository businessDetailsRepository,
            IInsuranceRepository insuranceRepository,
            ICompanyInfoRepository companyInfoRepository,
            ICustomerInfoRepository customerInfoRepository,
            ISparePartRepository sparePartRepository,
            ISparePartDetailsRepository sparePartDetailsRepository,
            IInboundRepository inboundRepository
            )

        {
            _dataContext = dataContext;
            Departments = departmentRepository;
            AllStaff = staffRepository;
            Suppliers = supplierRepository;
            Factories = factoryRepository;
            Vehicles = vehicleRepository;
            VehicleDetailsDb = vehicleDetailsRepository;
            Business = businessDetailsRepository;
            Insurances = insuranceRepository;
            CompanyInfos = companyInfoRepository;
            CustomerInfos = customerInfoRepository;
            SpareParts = sparePartRepository;
            SparePartsDetails = sparePartDetailsRepository;
            Inbounds = inboundRepository;
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

