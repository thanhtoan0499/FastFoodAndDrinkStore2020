using System;
using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<SaveProductDto, Product>();
            CreateMap<ProductDto, SaveProductDto>();
            

            CreateMap<Staff, StaffDto>();
            CreateMap<SaveStaffDto, Staff>();
            CreateMap<StaffDto, SaveStaffDto>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<SaveCustomerDto, Customer>();
            CreateMap<CustomerDto, SaveCustomerDto>();

            CreateMap<Supplier, SupplierDto>();
            CreateMap<SaveSupplierDto, Supplier>();
            CreateMap<SupplierDto, SaveSupplierDto>();

            CreateMap<Promotion, PromotionDto>();
            CreateMap<SavePromotionDto, Promotion>();
            CreateMap<PromotionDto, SavePromotionDto>();

            CreateMap<Invoice, InvoiceDto>();
            CreateMap<SaveInvoiceDto, Invoice>();
            CreateMap<InvoiceDto, SaveInvoiceDto>();

            CreateMap<DetailInvoice, DetailInvoiceDto>();
            CreateMap<SaveDetailInvoiceDto, DetailInvoice>();
            CreateMap<DetailInvoiceDto, SaveDetailInvoiceDto>();

            CreateMap<Receipt, ReceiptDto>();
            CreateMap<SaveReceiptDto, Receipt>();
            CreateMap<ReceiptDto, SaveReceiptDto>();

            CreateMap<DetailReceipt, DetailReceiptDto>();
            CreateMap<SaveDetailReceiptDto, DetailReceipt>();
            CreateMap<DetailReceiptDto, SaveDetailReceiptDto>();

            CreateMap<Account, AccountDto>();
            CreateMap<SaveAccountDto, Account>();
            CreateMap<AccountDto, SaveAccountDto>();
        }
    }

}