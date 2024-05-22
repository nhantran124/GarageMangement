using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class StaffApp : IStaffApp
	{
        public IUnitOfWork _unitOfWork;

		public StaffApp(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
		}

        public async Task<bool> CreateStaff(Staff staff)
        {
            if (staff != null)
            {

                await _unitOfWork.AllStaff.Add(staff);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteStaff(string StaffId)
        {
            if (StaffId != null)
            {
                var staff = await _unitOfWork.AllStaff.GetById(StaffId);
                if (staff != null)
                {
                    _unitOfWork.AllStaff.Delete(staff);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Staff>> GetAllStaff()
        {
            var StaffList = await _unitOfWork.AllStaff.GetAll();
            return StaffList;
        }

        public async Task<Staff> GetStaffById(string StaffId)
        {
            if (StaffId != null)
            {
                var staff = await _unitOfWork.AllStaff.GetById(StaffId);
                if (staff != null)
                {
                    return staff;
                }
            }
            return null;
        }

        public async Task<bool> UpdateStaff(Staff staff)
        {
            if (staff != null)
            {
                var staffDetails = await _unitOfWork.AllStaff.GetById(staff.StaffId);
                if (staffDetails != null)
                {
                    staffDetails.DepartmentId = staff.DepartmentId;
                    staffDetails.RoleId = staff.RoleId;
                    staffDetails.StaffName = staff.StaffName;
                    staffDetails.StaffAddress = staff.StaffAddress;
                    staffDetails.StaffPhonenumber = staff.StaffPhonenumber;
                    staffDetails.Username = staff.Username;
                    staffDetails.Password = staff.Password;
                    staffDetails.AccountActive = staff.AccountActive;
                    staffDetails.DayIn = staff.DayIn;
                    staffDetails.PremissionDay = staff.PremissionDay;
                    staffDetails.Status = staff.Status;

                    _unitOfWork.AllStaff.Update(staffDetails);

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

