using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IInvoiceService
    {
        InvoiceDto GetInvoice(int id);
        IEnumerable<InvoiceDto> GetInvoices(string staff, string supplier, int costFrom, int costTo, int pageIndex, int pageSize, out int count);
        IEnumerable<int> GetListInvoices();
        IEnumerable<string> GetStaffs();
        IEnumerable<string> GetSuppliers();
        void UpdateCostInvoice(int invoiceId);
        void CreateInvoice(SaveInvoiceDto productDto);
        void UpdateInvoice(SaveInvoiceDto productDto);
        void DeleteInvoice(int id);

        DetailInvoiceDto GetDetailInvoice(int id);
        IEnumerable<DetailInvoiceDto> GetDetailInvoices(int invoiceId, string productName, int quantityFrom, int quantityTo, int totalCostFrom, int totalCostTo, int pageIndex, int pageSize, out int count);
        IEnumerable<int> GetListInvoices(string str);
        IEnumerable<string> GetListProducts();
        int GetTotalCost(int invoiceId);
        void CreateDetailInvoice(SaveDetailInvoiceDto productDto);
        void UpdateDetailInvoice(SaveDetailInvoiceDto productDto);
        void DeleteDetailInvoice(int id);
        void DeleteDetailInvoices(int invoiceId);
    }
}