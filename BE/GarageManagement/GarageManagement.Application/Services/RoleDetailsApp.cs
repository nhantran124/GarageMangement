using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class RoleDetailsApp : IRoleDetailsApp
	{
        public IUnitOfWork _unitOfWork;

        public RoleDetailsApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateRoleDetails(RoleDetails roleDetails)
        {
            if (roleDetails != null)
            {

                await _unitOfWork.Roles.Add(roleDetails);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteRoleDetails(int RoleId)
        {
            if (RoleId != null)
            {
                var roleDetails = await _unitOfWork.Roles.GetById(RoleId);
                if (roleDetails != null)
                {
                    _unitOfWork.Roles.Delete(roleDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<RoleDetails>> GetAllRoleDetails()
        {
            var RoleDetailsList = await _unitOfWork.Roles.GetAll();
            return RoleDetailsList;
        }

        public async Task<RoleDetails> GetRoleDetailsById(int RoleId)
        {
            if (RoleId != null)
            {
                var RoleDetailsList = await _unitOfWork.Roles.GetById(RoleId);
                if (RoleDetailsList != null)
                {
                    return RoleDetailsList;
                }
            }
            return null;
        }

        public async Task<bool> UpdateRoleDetails(RoleDetails roleDetails)
        {
            if (roleDetails != null)
            {
                var RoleDetailsComponent = await _unitOfWork.Roles.GetById(roleDetails.RoleId);
                if (RoleDetailsComponent != null)
                {
                    RoleDetailsComponent.RoleName = roleDetails.RoleName;

                    _unitOfWork.Roles.Update(RoleDetailsComponent);

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

