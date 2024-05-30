using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.InboundManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class SparePartDetailsApp : ISparePartDetailsApp
	{
        public IUnitOfWork _unitOfWork;

        public SparePartDetailsApp(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateSparePartDetails(SparePartDetails sparePartDetails)
        {
            if (sparePartDetails != null)
            {

                await _unitOfWork.SparePartsDetails.Add(sparePartDetails);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteSparePartDetails(string SparePartDetailsId)
        {
            if (SparePartDetailsId != null)
            {
                var sparePartDetails = await _unitOfWork.SparePartsDetails.GetById(SparePartDetailsId);
                if (sparePartDetails != null)
                {
                    _unitOfWork.SparePartsDetails.Delete(sparePartDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<SparePartDetails>> GetAllSparePartDetails()
        {
            var SparePartDetailsList = await _unitOfWork.SparePartsDetails.GetAll();
            return SparePartDetailsList;
        }

        public async Task<SparePartDetails> GetSparePartDetailsById(string SparePartDetailsId)
        {
            if(SparePartDetailsId != null)
            {
                var sparePartDetails = await _unitOfWork.SparePartsDetails.GetById(SparePartDetailsId);
                if (sparePartDetails != null)
                {
                    return sparePartDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateSparePartDetails(SparePartDetails sparePartDetails)
        {
            if (sparePartDetails != null)
            {
                var sparePartsDetails = await _unitOfWork.SparePartsDetails.GetById(sparePartDetails.SparePartDetailsId);
                if (sparePartsDetails != null)
                {
                    sparePartsDetails.SparePartDetailsName = sparePartsDetails.SparePartDetailsName;
                    sparePartsDetails.SparePartDetailsOtherName = sparePartsDetails.SparePartDetailsOtherName;
                    sparePartsDetails.SparePartId = sparePartsDetails.SparePartId;
                    sparePartsDetails.SparePartSupplierId = sparePartsDetails.SparePartSupplierId;
                    sparePartsDetails.SparePartPrice = sparePartsDetails.SparePartPrice;
                    sparePartsDetails.SparePartPosition = sparePartsDetails.SparePartPosition;
                    sparePartsDetails.SparePartUnitCal = sparePartsDetails.SparePartUnitCal;

                    _unitOfWork.SparePartsDetails.Update(sparePartDetails);

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

