using System;
using GarageManagement.Domain.Interfaces;
using GarageManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GarageManagement.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext _dataContext;
        protected GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }
        //public async Task<UserDetails> GetUserByUsername(string username)
        //{
        //    return await _dataContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        //}
        public async Task Add(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            _dataContext.Set<T>().Update(entity);
        }

        public async Task<T> GetById(string id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }
    }
}

