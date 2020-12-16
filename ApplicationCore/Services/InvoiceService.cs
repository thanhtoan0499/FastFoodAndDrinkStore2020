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
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWorkInvoice _unitOfWork;
        private readonly IUnitOfWorkDetailInvoice _unitOfWorkDetail;
        private readonly IMapper _mapper;
        public InvoiceService(IUnitOfWorkInvoice unitOfWork, IMapper mapper,IUnitOfWorkDetailInvoice unitOfWorkDetail)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _unitOfWorkDetail = unitOfWorkDetail;
        }

        public InvoiceDto GetInvoice(int id)
        {
            var product = _unitOfWork.Invoices.GetBy(id);
            return _mapper.Map<Invoice, InvoiceDto>(product);
        }
        public DetailInvoiceDto GetDetailInvoice(int id)
        {
            var product = _unitOfWorkDetail.DetailInvoices.GetBy(id);
            return _mapper.Map<DetailInvoice, DetailInvoiceDto>(product);
        }
        public IEnumerable<InvoiceDto> GetInvoices(string staff, string supplier, int costFrom, int costTo, int pageIndex, int pageSize, out int count)
        {
            InvoiceSpecification spec = new InvoiceSpecification(staff, supplier, costFrom, costTo, pageIndex, pageSize);
            InvoiceSpecification spec1 = new InvoiceSpecification(staff, supplier, costFrom, costTo);

            var product = _unitOfWork.Invoices.Find(spec);
            count = _unitOfWork.Invoices.Count(spec1);
            return _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceDto>>(product);
        }
        public IEnumerable<DetailInvoiceDto> GetDetailInvoices(int invoiceId, string productName, int quantityFrom, int quantityTo, int totalCostFrom, int totalCostTo, int pageIndex, int pageSize, out int count)
        {
            DetailInvoiceSpecification spec = new DetailInvoiceSpecification(invoiceId, productName, quantityFrom, quantityTo, totalCostFrom, totalCostTo, pageIndex, pageSize);
            DetailInvoiceSpecification spec1 = new DetailInvoiceSpecification(invoiceId, productName, quantityFrom, quantityTo, totalCostFrom, totalCostTo);

            var product = _unitOfWorkDetail.DetailInvoices.Find(spec);
            count = _unitOfWorkDetail.DetailInvoices.Count(spec1);

            return _mapper.Map<IEnumerable<DetailInvoice>, IEnumerable<DetailInvoiceDto>>(product);
        }


        public IEnumerable<int> GetListInvoices()
        {
            return _unitOfWork.Invoices.GetListInvoices();
        }
        public IEnumerable<int> GetListInvoices(string str)
        {
            return _unitOfWorkDetail.DetailInvoices.GetListInvoices();
        }

        public IEnumerable<string> GetListProducts()
        {
            return _unitOfWorkDetail.DetailInvoices.GetListProducts();
        }
        public int GetTotalCost(int invoiceId)
        {
            return _unitOfWorkDetail.DetailInvoices.GetTotalCost(invoiceId);
        }

        public IEnumerable<string> GetStaffs()
        {
            return _unitOfWork.Invoices.GetStaffs();
        }
        public IEnumerable<string> GetSuppliers()
        {
            return _unitOfWork.Invoices.GetSuppliers();
        }
        public void CreateInvoice(SaveInvoiceDto saveInvoiceDto)
        {
            var product = _mapper.Map<SaveInvoiceDto, Invoice>(saveInvoiceDto);
            _unitOfWork.Invoices.Add(product);
            _unitOfWork.Complete();
        }
        public void UpdateInvoice(SaveInvoiceDto saveInvoiceDto)
        {
            var product = _unitOfWork.Invoices.GetBy(saveInvoiceDto.id);
            if (product == null) return;
            _mapper.Map<SaveInvoiceDto, Invoice>(saveInvoiceDto, product);
            _unitOfWork.Complete();
        }
        public void UpdateCostInvoice(int invoiceId)
        {
            int cost = GetTotalCost(invoiceId);
            var invoice = _unitOfWork.Invoices.GetBy(invoiceId);
            var invoiceUpdated = _unitOfWork.Invoices.GetBy(invoiceId);
            invoiceUpdated.Cost = cost;
            _mapper.Map<Invoice, Invoice>(invoiceUpdated, invoice);
            _unitOfWork.Complete();
        }
        public void DeleteInvoice(int id)
        {
            var product = _unitOfWork.Invoices.GetBy(id);
            if (product != null)
            {
                DeleteDetailInvoices(id);
                _unitOfWork.Invoices.Remove(product);
                _unitOfWork.Complete();
            }
        }

        //====================================
        public void CreateDetailInvoice(SaveDetailInvoiceDto saveDetailInvoiceDto)
        {
            var product = _mapper.Map<SaveDetailInvoiceDto, DetailInvoice>(saveDetailInvoiceDto);
            _unitOfWorkDetail.DetailInvoices.Add(product);
            _unitOfWorkDetail.Complete();
            UpdateCostInvoice(saveDetailInvoiceDto.InvoiceId);

        }
        public void UpdateDetailInvoice(SaveDetailInvoiceDto saveDetailInvoiceDto)
        {
            var product = _unitOfWorkDetail.DetailInvoices.GetBy(saveDetailInvoiceDto.id);
            if (product == null) return;
            var tem = product.InvoiceId;
            _mapper.Map<SaveDetailInvoiceDto, DetailInvoice>(saveDetailInvoiceDto, product);
            _unitOfWorkDetail.Complete();
            UpdateCostInvoice(saveDetailInvoiceDto.InvoiceId);
            UpdateCostInvoice(tem);
        }
        public void DeleteDetailInvoice(int id)
        {
            var product = _unitOfWorkDetail.DetailInvoices.GetBy(id);
            if (product != null)
            {
                _unitOfWorkDetail.DetailInvoices.Remove(product);
                _unitOfWorkDetail.Complete();
                UpdateCostInvoice(product.InvoiceId);
            }
            
        }
        public void DeleteDetailInvoices(int invoiceId)
        {
            var product = _unitOfWorkDetail.DetailInvoices.GetByInvoiceId(invoiceId);
            if (product != null)
            {
                _unitOfWorkDetail.DetailInvoices.RemoveRange(product);
                _unitOfWorkDetail.Complete();
                UpdateCostInvoice(invoiceId);
            }
        }
    }
}