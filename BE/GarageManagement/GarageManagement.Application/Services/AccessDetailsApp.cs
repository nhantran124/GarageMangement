using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.InboundManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
    public class AccessDetailsApp : IAccessDetailsApp
    {
        public IUnitOfWork _unitOfWork;

        public AccessDetailsApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAccessDetails(AccessDetails accessDetails)
        {
            if (accessDetails != null)
            {
                accessDetails.PermissionURL = GeneratePermissionURL(accessDetails.AccessURL, accessDetails.PermissionSymbol);
                await _unitOfWork.Access.Add(accessDetails);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteAccessDetails(int AccessId)
        {
            if (AccessId != null)
            {
                var accessDetails = await _unitOfWork.Access.GetById(AccessId);
                if (accessDetails != null)
                {
                    _unitOfWork.Access.Delete(accessDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<AccessDetails> GetAccessDetailsById(int AccessId)
        {
            if (AccessId != null)
            {
                var AccessDetailsList = await _unitOfWork.Access.GetById(AccessId);
                if (AccessDetailsList != null)
                {
                    return AccessDetailsList;
                }
            }
            return null;
        }

        public async Task<IEnumerable<AccessDetails>> GetAllAccessDetails()
        {
            var AccessDetailsList = await _unitOfWork.Access.GetAll();
            return AccessDetailsList;
        }

        public async Task<bool> UpdateAccessDetails(AccessDetails accessDetails)
        {
            if (accessDetails != null)
            {
                var AccessDetailsComponent = await _unitOfWork.Access.GetById(accessDetails.AccessId);
                if (AccessDetailsComponent != null)
                {
                    AccessDetailsComponent.AccessURL = accessDetails.AccessURL;
                    AccessDetailsComponent.RoleId = accessDetails.RoleId;
                    AccessDetailsComponent.PermissionId = accessDetails.PermissionId;
                    AccessDetailsComponent.PermissionSymbol = accessDetails.PermissionSymbol;
                    AccessDetailsComponent.PermissionURL = accessDetails.PermissionURL;


                    _unitOfWork.Access.Update(AccessDetailsComponent);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        private string GeneratePermissionURL(string AccessURL, string PermissionSymbol)
        {
            return $"{AccessURL}_{PermissionSymbol}";
        }
    }
}

