using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.Authorization;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.MaintenanceManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class RepairBillApp : IRepairBillApp
	{
        public IUnitOfWork _unitOfWork;

        public RepairBillApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateRepairBill(RepairBill repairBill)
        {
            if (repairBill != null)
            {

                await _unitOfWork.RepairBills.Add(repairBill);
                var result = await _unitOfWork.SaveAsync();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteRepairBill(int RepairCardId)
        {
            if (RepairCardId != null)
            {
                var repairBillIsDel = await _unitOfWork.RepairBills.GetById(RepairCardId);
                if (repairBillIsDel != null)
                {
                    _unitOfWork.RepairBills.Delete(repairBillIsDel);
                    var result = await _unitOfWork.SaveAsync();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<RepairBill>> GetAllRepairBill()
        {
            var RepairBillList = await _unitOfWork.RepairBills.GetAll();
            return RepairBillList;
        }

        public async Task<RepairBill> GetRepairBillById(int RepairCardId)
        {
            if (RepairCardId != null)
            {
                var repairBill = await _unitOfWork.RepairBills.GetById(RepairCardId);
                if (repairBill != null)
                {
                    return repairBill;
                }
            }
            return null;
        }

        public async Task<bool> UpdateRepairBill(RepairBill repairBill)
        {
            if (repairBill != null)
            {
                var existingRepairBill = await _unitOfWork.RepairBills.GetById(repairBill.RepairCardId);
                if (existingRepairBill != null)
                {
                    existingRepairBill.RepairCardId = repairBill.RepairCardId;
                    existingRepairBill.StaffId = repairBill.StaffId;
                    existingRepairBill.DateEntryCard = repairBill.DateEntryCard;
                    existingRepairBill.TotalPrice = repairBill.TotalPrice;
                    existingRepairBill.TaxGTGT = repairBill.TaxGTGT;
                    existingRepairBill.SearchWarrant = repairBill.SearchWarrant;
                    existingRepairBill.VehicleId = repairBill.VehicleId;
                    existingRepairBill.VehicleReturnDate = repairBill.VehicleReturnDate;
                    existingRepairBill.CustomerId = repairBill.CustomerId;
                    existingRepairBill.InsuranceId = repairBill.InsuranceId;
                    existingRepairBill.Censor = repairBill.Censor;
                    existingRepairBill.Kilometer = repairBill.Kilometer;
                    existingRepairBill.InvoiceNumber = repairBill.InvoiceNumber;
                    existingRepairBill.Note = repairBill.Note;
                    existingRepairBill.FactoryId = repairBill.FactoryId;

                    _unitOfWork.RepairBills.Update(existingRepairBill);

                    var result = await _unitOfWork.SaveAsync();

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

