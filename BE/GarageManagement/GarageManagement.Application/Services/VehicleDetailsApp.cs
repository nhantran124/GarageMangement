using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class VehicleDetailsApp : IVehicleDetailsApp
	{
        public IUnitOfWork _unitOfWork;

		public VehicleDetailsApp(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
		}

        public async Task<bool> CreateVehicleDetails(VehicleDetails vehicleDetails)
        {
            if (vehicleDetails != null)
            {

                await _unitOfWork.VehicleDetailsDb.Add(vehicleDetails);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteVehicleDetails(string VehicleId)
        {
            if (VehicleId != null)
            {
                var vehicleDetails = await _unitOfWork.VehicleDetailsDb.GetById(VehicleId);
                if (vehicleDetails != null)
                {
                    _unitOfWork.VehicleDetailsDb.Delete(vehicleDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<VehicleDetails>> GetAllVehicleDetails()
        {
            var VehicleDetailsList = await _unitOfWork.VehicleDetailsDb.GetAll();
            return VehicleDetailsList;
        }

        public async Task<VehicleDetails> GetVehicleDetailsById(string VehicleId)
        {
            if (VehicleId != null)
            {
                var vehicleDetails = await _unitOfWork.VehicleDetailsDb.GetById(VehicleId);
                if (vehicleDetails != null)
                {
                    return vehicleDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateVehicleDetails(VehicleDetails vehicleDetails)
        {
            if (vehicleDetails != null)
            {
                var ListVehicleComponents = await _unitOfWork.VehicleDetailsDb.GetById(vehicleDetails.VehicleId);
                if (ListVehicleComponents != null)
                {
                    ListVehicleComponents.TypeOfVehicleId = vehicleDetails.TypeOfVehicleId;
                    ListVehicleComponents.LicensePlates = vehicleDetails.LicensePlates;
                    ListVehicleComponents.VehicleNumber = vehicleDetails.VehicleNumber;
                    ListVehicleComponents.ChassisNumber = vehicleDetails.ChassisNumber;
                    ListVehicleComponents.VehicleColor = vehicleDetails.VehicleColor;

                    _unitOfWork.VehicleDetailsDb.Update(ListVehicleComponents);

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

