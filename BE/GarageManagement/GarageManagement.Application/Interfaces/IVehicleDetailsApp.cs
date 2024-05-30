using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface IVehicleDetailsApp
	{
		Task<bool> CreateVehicleDetails(VehicleDetails vehicleDetails);
		Task<IEnumerable<VehicleDetails>> GetAllVehicleDetails();
		Task<VehicleDetails> GetVehicleDetailsById(string VehicleId);
		Task<bool> UpdateVehicleDetails(VehicleDetails vehicleDetails);
		Task<bool> DeleteVehicleDetails(string VehicleId);
	}
}

