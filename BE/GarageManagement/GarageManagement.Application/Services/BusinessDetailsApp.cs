using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class BusinessDetailsApp : IBusinessDetailsApp
	{
		public IUnitOfWork _unitOfWork;

		public BusinessDetailsApp(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> CreateBusinessDetails(BusinessDetails businessDetails)
        {

            if (businessDetails != null)
            {

                await _unitOfWork.Business.Add(businessDetails);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteBusinessDetails(string BusinessDetailsId)
        {
            if (BusinessDetailsId != null)
            {
                var businessDetails = await _unitOfWork.Business.GetById(BusinessDetailsId);
                if (businessDetails != null)
                {
                    _unitOfWork.Business.Delete(businessDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<BusinessDetails>> GetAllBusinessDetails()
        {
            var BusinessList = await _unitOfWork.Business.GetAll();
            return BusinessList;
        }

        public async Task<BusinessDetails> GetBusinessDetailsById(string BusinessDetailsId)
        {
            if (BusinessDetailsId != null)
            {
                var businessDetails = await _unitOfWork.Business.GetById(BusinessDetailsId);
                if (businessDetails != null)
                {
                    return businessDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateBusinessDetails(BusinessDetails businessDetails)
        {
            if (businessDetails != null)
            {
                var business = await _unitOfWork.Business.GetById(businessDetails.BusinessDetailsId);
                if (business != null)
                {
                    business.BusinessDetailsName = businessDetails.BusinessDetailsName;
                    business.TypeOfBusinessDetailsId = businessDetails.TypeOfBusinessDetailsId;

                    _unitOfWork.Business.Update(business);

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

