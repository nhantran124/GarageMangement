using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class InsuranceApp : IInsuranceApp
	{
        public IUnitOfWork _unitOfWork;

        public InsuranceApp(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

        public async Task<bool> CreateInsurance(Insurance insurance)
        {
            if (insurance != null)
            {

                await _unitOfWork.Insurances.Add(insurance);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteInsurance(string InsuranceId)
        {
            if (InsuranceId != null)
            {
                var insurance = await _unitOfWork.Insurances.GetById(InsuranceId);
                if (insurance != null)
                {
                    _unitOfWork.Insurances.Delete(insurance);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Insurance>> GetAllInsurance()
        {
            var InsuranceList = await _unitOfWork.Insurances.GetAll();
            return InsuranceList;
        }

        public async Task<Insurance> GetInsuranceById(string InsuranceId)
        {
            if (InsuranceId != null)
            {
                var InsuranceList = await _unitOfWork.Insurances.GetById(InsuranceId);
                if (InsuranceList != null)
                {
                    return InsuranceList;
                }
            }
            return null;
        }

        public async Task<bool> UpdateInsurance(Insurance insurance)
        {
            if (insurance != null)
            {
                var ListInsurancesComponent = await _unitOfWork.Insurances.GetById(insurance.InsuranceId);
                if (ListInsurancesComponent != null)
                {
                    ListInsurancesComponent.InsuranceName = insurance.InsuranceName;
                    ListInsurancesComponent.InsuranceTax = insurance.InsuranceTax;
                    ListInsurancesComponent.InsuranceAddress = insurance.InsuranceAddress;
                    ListInsurancesComponent.InsuranceNumberAccount = insurance.InsuranceNumberAccount;
                    ListInsurancesComponent.InsuranceBank = insurance.InsuranceBank;
                    ListInsurancesComponent.InsuranceBranch = insurance.InsuranceBranch;

                    _unitOfWork.Insurances.Update(ListInsurancesComponent);

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

