using System;
using System.Security.Cryptography;
using System.Text;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace GarageManagement.Application.Services
{
    public class StaffApp : IStaffApp
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateStaff(Staff staff)
        {
            if (staff != null)
            {
                staff.Password = EncryptPassword(staff.Password);
                await _unitOfWork.AllStaff.Add(staff);
                var result = _unitOfWork.Save();

                return result > 0;
            }
            return false;
        }

        public async Task<bool> DeleteStaff(string StaffId)
        {
            if (!string.IsNullOrEmpty(StaffId))
            {
                var staff = await _unitOfWork.AllStaff.GetById(StaffId);
                if (staff != null)
                {
                    _unitOfWork.AllStaff.Delete(staff);
                    var result = _unitOfWork.Save();
                    return result > 0;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Staff>> GetAllStaff()
        {
            return await _unitOfWork.AllStaff.GetAll();
        }

        public async Task<Staff> GetStaffById(string StaffId)
        {
            return !string.IsNullOrEmpty(StaffId) ? await _unitOfWork.AllStaff.GetById(StaffId) : null;
        }

        public async Task<Staff> LoginUser(string Username, string Password)
        {
            var hashedPassword = EncryptPassword(Password);
            var user = await _unitOfWork.AllStaff.GetUserByUsername(Username);
            return user != null && user.Password == hashedPassword ? user : null;
        }

        public async Task<bool> UpdateStaff(Staff staff)
        {
            if (staff != null)
            {
                var hashedPassword = EncryptPassword(staff.Password);
                var staffDetails = await _unitOfWork.AllStaff.GetById(staff.StaffId);
                if (staffDetails != null)
                {
                    staffDetails.DepartmentId = staff.DepartmentId;
                    staffDetails.RoleId = staff.RoleId;
                    staffDetails.StaffName = staff.StaffName;
                    staffDetails.StaffAddress = staff.StaffAddress;
                    staffDetails.StaffPhonenumber = staff.StaffPhonenumber;
                    staffDetails.Username = staff.Username;
                    staffDetails.Password = hashedPassword;
                    staffDetails.AccountActive = staff.AccountActive;
                    staffDetails.DayIn = staff.DayIn;
                    staffDetails.PremissionDay = staff.PremissionDay;
                    staffDetails.Status = staff.Status;

                    _unitOfWork.AllStaff.Update(staffDetails);
                    var result = _unitOfWork.Save();
                    return result > 0;
                }
            }
            return false;
        }

        public async Task<bool> ChangePassword(string staffId, string newPassword)
        {
            var staff = await _unitOfWork.AllStaff.GetById(staffId);
            if (staff == null)
            {
                return false; // Người dùng không tồn tại
            }

            // Thực hiện mã hóa mật khẩu mới
            staff.Password = EncryptPassword(newPassword);

            _unitOfWork.AllStaff.Update(staff);
            var result = await _unitOfWork.SaveAsync();

            return result > 0;
        }

        private string EncryptPassword(string password)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                // Convert byte array to hex string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                string hashedPassword = sb.ToString();
                hashedPassword = hashedPassword.Insert(3, "a6B");
                hashedPassword = hashedPassword.Insert(5, "Hh");
                return hashedPassword;
            }
        }
    }
}