using System;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;

namespace GarageManagement.Application.Interfaces
{
    public interface IAccessDetailsApp
    {
        Task<bool> CreateAccessDetails(AccessDetails accessDetails);
        Task<IEnumerable<AccessDetails>> GetAllAccessDetails();
        Task<AccessDetails> GetAccessDetailsById(int AccessId);
        Task<bool> UpdateAccessDetails(AccessDetails accessDetails);
        Task<bool> DeleteAccessDetails(int AccessId);
    }
}

