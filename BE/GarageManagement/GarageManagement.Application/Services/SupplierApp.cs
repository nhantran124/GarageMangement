using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
    public class SupplierApp : ISupplierApp
    {
        public IUnitOfWork _unitOfWork;

        public SupplierApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateSupplier(Supplier supplier)
        {
            if (supplier != null)
            {

                await _unitOfWork.Suppliers.Add(supplier);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteSupplier(string SupplierId)
        {
            if (SupplierId != null)
            {
                var supplier = await _unitOfWork.Suppliers.GetById(SupplierId);
                if (supplier != null)
                {
                    _unitOfWork.Suppliers.Delete(supplier);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplier()
        {
            var SupplierList = await _unitOfWork.Suppliers.GetAll();
            return SupplierList;
        }

        public async Task<Supplier> GetSupplierById(string SupplierId)
        {
            if (SupplierId != null)
            {
                var supplier = await _unitOfWork.Suppliers.GetById(SupplierId);
                if (supplier != null)
                {
                    return supplier;
                }
            }
            return null;
        }

        public async Task<bool> UpdateSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                var supplierDetails = await _unitOfWork.Suppliers.GetById(supplier.SupplierId);
                if (supplierDetails != null)
                {
                    supplierDetails.SupplierName = supplier.SupplierName;
                    supplierDetails.SupplierAddress = supplier.SupplierAddress;
                    supplierDetails.SupplierPhonenumber = supplier.SupplierPhonenumber;
                    supplierDetails.SupplierTax = supplier.SupplierTax;
                    supplierDetails.SupplierBank = supplier.SupplierBank;
                    supplierDetails.SupplierBranch = supplier.SupplierBranch;
                    supplierDetails.AccountNumber = supplier.AccountNumber;

                    _unitOfWork.Suppliers.Update(supplierDetails);

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

