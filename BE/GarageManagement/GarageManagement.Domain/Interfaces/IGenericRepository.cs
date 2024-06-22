using System;
using GarageManagement.Domain.Entities.CategoryManagement;

namespace GarageManagement.Domain.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
        Task<T> GetById(string id);
        Task<IEnumerable<T>> GetAll();
        Task<Staff> GetUserByUsername(string username);
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}

