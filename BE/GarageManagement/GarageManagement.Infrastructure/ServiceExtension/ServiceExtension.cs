using System;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GarageManagement.Infrastructure.ServiceExtension
{
	public static class ServiceExtension
	{
		public static IServiceCollection AddDIServices(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			services.AddScoped<IStaffRepository, StaffRepository>();
			return services;
		}
	}
}

