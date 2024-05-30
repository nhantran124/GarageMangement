using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class VehicleApp : IVehicleApp 
	{
		public IUnitOfWork _unitOfWork;

        public VehicleApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
            {

                await _unitOfWork.Vehicles.Add(vehicle);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteVehicle(string TypeOfVehicleId)
        {
            if (TypeOfVehicleId != null)
            {
                var vehicle = await _unitOfWork.Vehicles.GetById(TypeOfVehicleId);
                if (vehicle != null)
                {
                    _unitOfWork.Vehicles.Delete(vehicle);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicle()
        {
            var VehicleList = await _unitOfWork.Vehicles.GetAll();
            return VehicleList;
        }

        public async Task<Vehicle> GetVehicleById(string TypeOfVehicleId)
        {
            if (TypeOfVehicleId != null)
            {
                var vehicle = await _unitOfWork.Vehicles.GetById(TypeOfVehicleId);
                if (vehicle != null)
                {
                    return vehicle;
                }
            }
            return null;
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                var vehicleDetails = await _unitOfWork.Vehicles.GetById(vehicle.TypeOfVehicleId);
                if (vehicleDetails != null)
                {
                    vehicleDetails.NameOfVehicle = vehicle.NameOfVehicle;
                    vehicleDetails.Note = vehicle.Note;

                    _unitOfWork.Vehicles.Update(vehicleDetails);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}

