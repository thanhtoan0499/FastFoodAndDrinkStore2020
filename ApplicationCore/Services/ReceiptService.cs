using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IUnitOfWorkReceipt _unitOfWork;
        private readonly IUnitOfWorkDetailReceipt _unitOfWorkDetail;
        private readonly IMapper _mapper;
        public ReceiptService(IUnitOfWorkReceipt unitOfWork, IMapper mapper,IUnitOfWorkDetailReceipt unitOfWorkDetail)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _unitOfWorkDetail = unitOfWorkDetail;
        }

        public ReceiptDto GetReceipt(int id)
        {
            var product = _unitOfWork.Receipts.GetBy(id);
            return _mapper.Map<Receipt, ReceiptDto>(product);
        }

        public DetailReceiptDto GetDetailReceipt(int id)
        {
            var detail = _unitOfWorkDetail.DetailReceipts.GetBy(id);
            return _mapper.Map<DetailReceipt, DetailReceiptDto>(detail);
        }
        public IEnumerable<ReceiptDto> GetReceipts(int id, int staff, int customer, DateTime dateFrom, DateTime dateTo, int costFrom, int costTo, int pageIndex, int pageSize, out int count)
        {
            ReceiptSpecification spec = new ReceiptSpecification(id, staff, customer, dateFrom, dateTo, costFrom, costTo, pageIndex, pageSize);
            ReceiptSpecification spec1 = new ReceiptSpecification(id, staff, customer, dateFrom, dateTo, costFrom, costTo);

            var product = _unitOfWork.Receipts.Find(spec);
            count = _unitOfWork.Receipts.Count(spec1);
            return _mapper.Map<IEnumerable<Receipt>, IEnumerable<ReceiptDto>>(product);
        }
        public IEnumerable<DetailReceiptDto> GetDetailReceipts(int receiptID, int productID, int quantityFrom, int quantityTo, int costFrom, int costTo, int pageIndex, int pageSize, out int count)
        {
            DetailReceiptSpecification spec = new DetailReceiptSpecification(receiptID, productID,quantityFrom, quantityTo,costFrom, costTo, pageIndex, pageSize);
            DetailReceiptSpecification spec1 = new DetailReceiptSpecification(receiptID, productID,quantityFrom, quantityTo,costFrom, costTo);

            var detail = _unitOfWorkDetail.DetailReceipts.Find(spec);
            count = _unitOfWorkDetail.DetailReceipts.Count(spec1);
            return _mapper.Map<IEnumerable<DetailReceipt>, IEnumerable<DetailReceiptDto>>(detail);
        }
        public IEnumerable<int> GetListReceipts()
        {
            return _unitOfWork.Receipts.GetListReceipts();
        }
        public IEnumerable<int> GetListReceipts(string str)
        {
            return _unitOfWorkDetail.DetailReceipts.GetListReceipts();
        }
        public IEnumerable<int> GetListProducts()
        {
            return _unitOfWorkDetail.DetailReceipts.GetListProducts();
        }
        public IEnumerable<int> GetStaffs()
        {
            return _unitOfWork.Receipts.GetStaffs();
        }
        public int GetTotalCost(int receiptID)
        {
            return _unitOfWorkDetail.DetailReceipts.GetTotalCost(receiptID);
        }
        public IEnumerable<int> GetCustomers()
        {
            return _unitOfWork.Receipts.GetCustomers();
        }

        public void CreateReceipt(SaveReceiptDto saveReceiptDto)
        {
            var product = _mapper.Map<SaveReceiptDto, Receipt>(saveReceiptDto);
            _unitOfWork.Receipts.Add(product);
            _unitOfWork.Complete();
        }
        public void CreateDetailReceipt(SaveDetailReceiptDto saveDetailReceiptDto)
        {
            var detail = _mapper.Map<SaveDetailReceiptDto, DetailReceipt>(saveDetailReceiptDto);
            _unitOfWorkDetail.DetailReceipts.Add(detail);
            _unitOfWorkDetail.Complete();
            UpdateCostReceipt(detail.ReceiptID);
        }
        public void UpdateReceipt(SaveReceiptDto saveReceiptDto)
        {
            var product = _unitOfWork.Receipts.GetBy(saveReceiptDto.id);
            if (product == null) return;
            _mapper.Map<SaveReceiptDto, Receipt>(saveReceiptDto, product);
            _unitOfWork.Complete();
        }
        public void UpdateDetailReceipt(SaveDetailReceiptDto saveDetailReceiptDto)
        {
            var detail = _unitOfWorkDetail.DetailReceipts.GetBy(saveDetailReceiptDto.id);
         
            if (detail == null) return;
            var tem = detail.ReceiptID;
            _mapper.Map<SaveDetailReceiptDto, DetailReceipt>(saveDetailReceiptDto, detail);
            _unitOfWorkDetail.Complete();
            UpdateCostReceipt(saveDetailReceiptDto.ReceiptID);
            UpdateCostReceipt(tem);
        }
        public void UpdateCostReceipt(int receiptId)
        {
            int cost = GetTotalCost(receiptId);
            var invoice = _unitOfWork.Receipts.GetBy(receiptId);
            var invoiceUpdated = _unitOfWork.Receipts.GetBy(receiptId);
            invoiceUpdated.TotalCost = cost;
            _mapper.Map<Receipt, Receipt>(invoiceUpdated, invoice);
            _unitOfWork.Complete();
        }
        public void DeleteReceipt(int id)
        {
            var product = _unitOfWork.Receipts.GetBy(id);
            if (product != null)
            {
                _unitOfWork.Receipts.Remove(product);
                _unitOfWork.Complete();
                DeleteDetailReceipts(id);
            }
        }
        public void DeleteDetailReceipt(int id)
        {
            var detail = _unitOfWorkDetail.DetailReceipts.GetBy(id);
            if (detail != null)
            {
                _unitOfWorkDetail.DetailReceipts.Remove(detail);
                _unitOfWorkDetail.Complete();
                UpdateCostReceipt(detail.ReceiptID);
            }
        }
        public void DeleteDetailReceipts(int receiptID)
        {
            var details = _unitOfWorkDetail.DetailReceipts.GetByReceiptId(receiptID);
            if(details != null)
            {
                _unitOfWorkDetail.DetailReceipts.RemoveRange(details);
                _unitOfWorkDetail.Complete();
                UpdateCostReceipt(receiptID);
            }
        }
    }
}