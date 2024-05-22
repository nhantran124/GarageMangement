using Microsoft.Extensions.DependencyInjection;
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

            return services;
        }
    }
}
