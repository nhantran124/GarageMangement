using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface IVehicleApp
	{
		Task<bool> CreateVehicle(Vehicle vehicle);
		Task<IEnumerable<Vehicle>> GetAllVehicle();
		Task<Vehicle> GetVehicleById(string TypeOfVehicleId);
		Task<bool> UpdateVehicle(Vehicle vehicle);
		Task<bool> DeleteVehicle(string TypeOfVehicleId);
	}
}

