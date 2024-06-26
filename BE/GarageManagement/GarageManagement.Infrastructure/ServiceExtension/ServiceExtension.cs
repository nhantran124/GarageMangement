﻿using Microsoft.Extensions.DependencyInjection;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Repositories;

namespace GarageManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            // Register UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Add other repositories and services here
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IFactoryRepository, FactoryRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleDetailsRepository, VehicleDetailsRepository>();
            services.AddScoped<IBusinessDetailsRepository, BusinessDetailsRepository>();
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<ICompanyInfoRepository, CompanyInfoRepository>();
            services.AddScoped<ICustomerInfoRepository, CustomerInfoRepository>();
            services.AddScoped<ISparePartRepository, SparePartRepository>();
            services.AddScoped<ISparePartDetailsRepository, SparePartDetailsRepository>();
            services.AddScoped<IInboundRepository, InboundRepository>();
            return services;
        }
    }
}
