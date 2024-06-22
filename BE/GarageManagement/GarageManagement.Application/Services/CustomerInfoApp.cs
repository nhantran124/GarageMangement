using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class CustomerInfoApp : ICustomerInfoApp
	{
        public IUnitOfWork _unitOfWork;

        public CustomerInfoApp(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> CreateCustomerInfoDetails(CustomerInfo customerInfo)
        {
            if (customerInfo != null)
            {

                await _unitOfWork.CustomerInfos.Add(customerInfo);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteCustomerInfo(string CustomerId)
        {
            if (CustomerId != null)
            {
                var customerInfo = await _unitOfWork.CustomerInfos.GetById(CustomerId);
                if (customerInfo != null)
                {
                    _unitOfWork.CustomerInfos.Delete(customerInfo);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<CustomerInfo>> GetAllCustomerInfo()
        {
            var CustomerInfoList = await _unitOfWork.CustomerInfos.GetAll();
            return CustomerInfoList;
        }

        public async Task<CustomerInfo> GetCustomerInfoById(string CustomerId)
        {
            if (CustomerId != null)
            {
                var CustomerInfoList = await _unitOfWork.CustomerInfos.GetById(CustomerId);
                if (CustomerInfoList != null)
                {
                    return CustomerInfoList;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCustomerInfo(CustomerInfo customerInfo)
        {
            if (customerInfo != null)
            {
                var ListCustomerComponent = await _unitOfWork.CustomerInfos.GetById(customerInfo.CustomerId);
                if (ListCustomerComponent != null)
                {
                    ListCustomerComponent.CustomerName = customerInfo.CustomerName;
                    ListCustomerComponent.CustomerAddress = customerInfo.CustomerAddress;
                    ListCustomerComponent.CustomerPhonenumber = customerInfo.CustomerPhonenumber;
                    ListCustomerComponent.CustomerTax = customerInfo.CustomerPhonenumber;
                    _unitOfWork.CustomerInfos.Update(ListCustomerComponent);

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

