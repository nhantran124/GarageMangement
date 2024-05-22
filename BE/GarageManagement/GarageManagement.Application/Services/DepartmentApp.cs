using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
    public class DepartmentApp : IDepartmentApp
    {
        public IUnitOfWork _unitOfWork;

        public DepartmentApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> CreateDepartment(DepartmentDetails departmentDetails)
        {
            if (departmentDetails != null)
            {
                
                await _unitOfWork.Departments.Add(departmentDetails);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteDepartment(string DepartmentId)
        {
            if (DepartmentId != null)
            {
                var departmentDetails = await _unitOfWork.Departments.GetById(DepartmentId);
                if (departmentDetails != null)
                {
                    _unitOfWork.Departments.Delete(departmentDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<DepartmentDetails>> GetAllDepartments()
        {
            var DepartmentsList = await _unitOfWork.Departments.GetAll();
            return DepartmentsList;
        }

        public async Task<DepartmentDetails> GetDepartmentById(string DepartmentId)
        {
            if (DepartmentId != null )
            {
                var departmentDetails = await _unitOfWork.Departments.GetById(DepartmentId);
                if (departmentDetails != null)
                {
                    return departmentDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateDepartment(DepartmentDetails departmentDetails)
        {
            if (departmentDetails != null)
            {
                var department = await _unitOfWork.Departments.GetById(departmentDetails.DepartmentId);
                if (department != null)
                {
                    department.DepartmentName = departmentDetails.DepartmentName;
                    department.DepartmentNote = departmentDetails.DepartmentNote;

                    _unitOfWork.Departments.Update(department);

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

