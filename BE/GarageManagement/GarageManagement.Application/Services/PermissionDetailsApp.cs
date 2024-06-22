using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class PermissionDetailsApp : IPermissionDetailsApp
    {
        public IUnitOfWork _unitOfWork;

        public PermissionDetailsApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreatePermissionDetails(PermissionDetails permissionDetails)
        {
            if (permissionDetails != null)
            {

                await _unitOfWork.Permission.Add(permissionDetails);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeletePermissionDetails(int PermissionId)
        {
            if (PermissionId != null)
            {
                var permissionDetails = await _unitOfWork.Permission.GetById(PermissionId);
                if (permissionDetails != null)
                {
                    _unitOfWork.Permission.Delete(permissionDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<PermissionDetails>> GetAllPermissionDetails()
        {
            var PermissionDetailsList = await _unitOfWork.Permission.GetAll();
            return PermissionDetailsList;
        }

        public async Task<PermissionDetails> GetPermissionDetailsById(int PermissionId)
        {
            if (PermissionId != null)
            {
                var PermissionDetailsList = await _unitOfWork.Permission.GetById(PermissionId);
                if (PermissionDetailsList != null)
                {
                    return PermissionDetailsList;
                }
            }
            return null;
        }

        public async Task<bool> UpdatePermissionDetails(PermissionDetails permissionDetails)
        {
            if (permissionDetails != null)
            {
                var PermissionDetailsComponent = await _unitOfWork.Permission.GetById(permissionDetails.PermissionId);
                if (PermissionDetailsComponent != null)
                {
                    PermissionDetailsComponent.PermissionId = permissionDetails.PermissionId;
                    PermissionDetailsComponent.PermissionName = permissionDetails.PermissionName;
                    PermissionDetailsComponent.PermissionSymbol = permissionDetails.PermissionSymbol;

                    _unitOfWork.Permission.Update(PermissionDetailsComponent);

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

