using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Application.Interfaces
{
	public interface IFactoryApp
	{
        Task<bool> CreateFactory(Factory factory);
        Task<IEnumerable<Factory>> GetAllFactory();
        Task<Factory> GetFactoryById(int FactoryId);
        Task<bool> UpdateFactory(Factory factory);
        Task<bool> DeleteFactory(int FactoryId);
    }
}

