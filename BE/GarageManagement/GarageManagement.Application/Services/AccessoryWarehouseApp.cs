using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.InboundManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class AccessoryWarehouseApp : IAccessoryWarehouseApp
    {
        public IUnitOfWork _unitOfWork;

        public AccessoryWarehouseApp(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAccessoryWarehouse(AccessoryWarehouse accessoryWarehouse)
        {
            if (accessoryWarehouse != null)
            {

                await _unitOfWork.AccessoriesWarehouse.Add(accessoryWarehouse);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteAccessoryWarehouse(string SupplierSparePartId)
        {
            if (SupplierSparePartId != null)
            {
                var accessoryWarehouse = await _unitOfWork.AccessoriesWarehouse.GetById(SupplierSparePartId);
                if (accessoryWarehouse != null)
                {
                    _unitOfWork.AccessoriesWarehouse.Delete(accessoryWarehouse);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<AccessoryWarehouse> GetAccessoryWarehouseById(string SupplierSparePartId)
        {
            if (SupplierSparePartId != null)
            {
                var AccessoryWarehouseList = await _unitOfWork.AccessoriesWarehouse.GetById(SupplierSparePartId);
                if (AccessoryWarehouseList != null)
                {
                    return AccessoryWarehouseList;
                }
            }
            return null;
        }

        public async Task<IEnumerable<AccessoryWarehouse>> GetAllAccessoryWarehouse()
        {
            var AccessoryWarehouseList = await _unitOfWork.AccessoriesWarehouse.GetAll();
            return AccessoryWarehouseList;
        }

        public async Task<bool> UpdateAccessoryWarehouse(AccessoryWarehouse accessoryWarehouse)
        {
            if (accessoryWarehouse != null)
            {
                var AccessoryWarehouseComponent = await _unitOfWork.AccessoriesWarehouse.GetById(accessoryWarehouse.SupplierSparePartId);
                if (AccessoryWarehouseComponent != null)
                {
                    AccessoryWarehouseComponent.SparePartDetailsId = accessoryWarehouse.SparePartDetailsId;
                    AccessoryWarehouseComponent.InputPrice = accessoryWarehouse.InputPrice;
                    AccessoryWarehouseComponent.Quantity = accessoryWarehouse.Quantity;
                    AccessoryWarehouseComponent.SupplierId = accessoryWarehouse.SupplierId;
                    AccessoryWarehouseComponent.DayEnter = accessoryWarehouse.DayEnter;
                    AccessoryWarehouseComponent.Barcode = accessoryWarehouse.Barcode;
                    AccessoryWarehouseComponent.InvoiceEnterId = accessoryWarehouse.InvoiceEnterId;
                    AccessoryWarehouseComponent.RepairCardId = accessoryWarehouse.RepairCardId;

                    _unitOfWork.AccessoriesWarehouse.Update(AccessoryWarehouseComponent);

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

