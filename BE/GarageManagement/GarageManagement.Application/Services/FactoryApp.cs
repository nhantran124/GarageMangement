using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class FactoryApp : IFactoryApp
	{
        public IUnitOfWork _unitOfWork;

		public FactoryApp(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
		}

        public async Task<bool> CreateFactory(Factory factory)
        {
            if (factory != null)
            {

                await _unitOfWork.Factories.Add(factory);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteFactory(int FactoryId)
        {
            if (FactoryId != null)
            {
                var factory = await _unitOfWork.Factories.GetById(FactoryId);
                if (factory != null)
                {
                    _unitOfWork.Factories.Delete(factory);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Factory>> GetAllFactory()
        {
            var FactoryList = await _unitOfWork.Factories.GetAll();
            return FactoryList;
        }

        public async Task<Factory> GetFactoryById(int FactoryId)
        {
            if (FactoryId != null)
            {
                var factory = await _unitOfWork.Factories.GetById(FactoryId);
                if (factory != null)
                {
                    return factory;
                }
            }
            return null;
        }

        public async Task<bool> UpdateFactory(Factory factory)
        {
            if (factory != null)
            {
                var factories = await _unitOfWork.Factories.GetById(factory.FactoryId);
                if (factories != null)
                {
                    factories.FactoryName = factory.FactoryName;
                    factories.Note = factory.Note;

                    _unitOfWork.Factories.Update(factories);

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

