using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface ICustomerInfoApp
	{
        Task<bool> CreateCustomerInfoDetails(CustomerInfo customerInfo);
        Task<IEnumerable<CustomerInfo>> GetAllCustomerInfo();
        Task<CustomerInfo> GetCustomerInfoById(string CustomerId);
        Task<bool> UpdateCustomerInfo(CustomerInfo customerInfo);
        Task<bool> DeleteCustomerInfo(string CustomerId);
    }
}

