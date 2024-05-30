using System;
using GarageManagement.Application.Interfaces;
using GarageManagement.Domain.Entities.CategoryManagement;
using GarageManagement.Domain.Entities.InboundManagement;
using GarageManagement.Domain.Interfaces;

namespace GarageManagement.Application.Services
{
	public class InboundApp : IInboundApp
	{
        public IUnitOfWork _unitOfWork;

        public InboundApp(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
		}

        public async Task<bool> CreateInbound(Inbound inbound)
        {
            if (inbound != null)
            {

                await _unitOfWork.Inbounds.Add(inbound);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteInbound(string InvoiceEnterId)
        {
            if (InvoiceEnterId != null)
            {
                var inbound = await _unitOfWork.Inbounds.GetById(InvoiceEnterId);
                if (inbound != null)
                {
                    _unitOfWork.Inbounds.Delete(inbound);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Inbound>> GetAllInbound()
        {
            var InboundList = await _unitOfWork.Inbounds.GetAll();
            return InboundList;
        }

        public async Task<Inbound> GetInboundById(string InvoiceEnterId)
        {
            if (InvoiceEnterId != null)
            {
                var InboundList = await _unitOfWork.Inbounds.GetById(InvoiceEnterId);
                if (InboundList != null)
                {
                    return InboundList;
                }
            }
            return null;
        }

        public async Task<bool> UpdateInbound(Inbound inbound)
        {
            if (inbound != null)
            {
                var ListInboundComponent = await _unitOfWork.Inbounds.GetById(inbound.InvoiceEnterId);
                if (ListInboundComponent != null)
                {
                    ListInboundComponent.DayEnter = inbound.DayEnter;
                    ListInboundComponent.SupplierId = inbound.SupplierId;
                    ListInboundComponent.TotalPrice = inbound.TotalPrice;
                    ListInboundComponent.Status = inbound.Status;
                    ListInboundComponent.StaffId = inbound.StaffId;
                    ListInboundComponent.InvoiceCode = inbound.InvoiceCode;
                    ListInboundComponent.VAT = inbound.VAT;
                    ListInboundComponent.RepairCodeId = inbound.RepairCodeId;

                    _unitOfWork.Inbounds.Update(inbound);

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

