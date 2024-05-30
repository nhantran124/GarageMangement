using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class SparePartApp : ISparePartApp
	{
        public IUnitOfWork _unitOfWork;

        public SparePartApp(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> CreateSparePart(SparePart sparePart)
        {
            if (sparePart != null)
            {

                await _unitOfWork.SpareParts.Add(sparePart);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteSparePart(string SparePartId)
        {
            if (SparePartId != null)
            {
                var sparePart = await _unitOfWork.SpareParts.GetById(SparePartId);
                if (sparePart != null)
                {
                    _unitOfWork.SpareParts.Delete(sparePart);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<SparePart>> GetAllSparePart()
        {
            var SparePartList = await _unitOfWork.SpareParts.GetAll();
            return SparePartList;
        }

        public async Task<SparePart> GetSparePartById(string SparePartId)
        {
            if (SparePartId != null)
            {
                var sparePart = await _unitOfWork.SpareParts.GetById(SparePartId);
                if (sparePart != null)
                {
                    return sparePart;
                }
            }
            return null;
        }

        public async Task<bool> UpdateSparePart(SparePart sparePart)
        {
            if (sparePart != null)
            {
                var sparePartDetails = await _unitOfWork.SpareParts.GetById(sparePart.SparePartId);
                if (sparePartDetails != null)
                {
                    sparePartDetails.SparePartName = sparePart.SparePartName;
                    sparePartDetails.SparePartContent = sparePart.SparePartContent;

                    _unitOfWork.SpareParts.Update(sparePartDetails);

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

