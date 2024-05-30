using System;
using System.Globalization;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class CompanyInfoApp : ICompanyInfoApp
	{
        public IUnitOfWork _unitOfWork;

        public CompanyInfoApp(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> CreateCompanyInfo(CompanyInfo companyInfo)
        {
            if (companyInfo != null)
            {

                await _unitOfWork.CompanyInfos.Add(companyInfo);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteCompanyInfo(int CompanyId)
        {
            if (CompanyId != null)
            {
                var companyInfo = await _unitOfWork.CompanyInfos.GetById(CompanyId);
                if (companyInfo != null)
                {
                    _unitOfWork.CompanyInfos.Delete(companyInfo);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<CompanyInfo>> GetAllCompanyInfo()
        {
            var CompanyInfoList = await _unitOfWork.CompanyInfos.GetAll();
            return CompanyInfoList;
        }

        public async Task<CompanyInfo> GetCompanyInfoById(int CompanyId)
        {
            if (CompanyId != null)
            {
                var companyInfo = await _unitOfWork.CompanyInfos.GetById(CompanyId);
                if (companyInfo != null)
                {
                    return companyInfo;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCompanyInfo(CompanyInfo companyInfo)
        {
            if (companyInfo != null)
            {
                var companyInfos = await _unitOfWork.CompanyInfos.GetById(companyInfo.CompanyId);
                if (companyInfos != null)
                {
                    companyInfos.CompanyName = companyInfo.CompanyName;
                    companyInfos.CompanyAddress = companyInfo.CompanyAddress;
                    companyInfos.CompanyPhoneNumber = companyInfo.CompanyPhoneNumber;
                    companyInfos.CompanyEmail = companyInfo.CompanyEmail;
                    companyInfos.CompanyWeb = companyInfo.CompanyWeb;
                    companyInfos.CompanyTax = companyInfo.CompanyTax;
                    companyInfos.NotePrice = companyInfo.NotePrice;

                    _unitOfWork.CompanyInfos.Update(companyInfos);

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

