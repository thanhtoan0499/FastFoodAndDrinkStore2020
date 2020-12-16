using System;
using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IReceiptService
    {
        ReceiptDto GetReceipt(int id);
        IEnumerable<ReceiptDto> GetReceipts(int id, int staff, int customer, DateTime dateFrom, DateTime dateTo, int costFrom, int costTo, int pageIndex, int pageSize, out int count);
        IEnumerable<int> GetListReceipts();
        IEnumerable<int> GetStaffs();
        IEnumerable<int> GetCustomers();
        void UpdateCostReceipt(int invoiceId);
        void CreateReceipt(SaveReceiptDto productDto);
        void UpdateReceipt(SaveReceiptDto productDto);
        void DeleteReceipt(int id);


        DetailReceiptDto GetDetailReceipt(int id);
        IEnumerable<DetailReceiptDto> GetDetailReceipts(int receiptID, int productID, int quantityFrom, int quantityTo, int totalCostFrom, int totalCostTo, int pageIndex, int pageSize, out int count);
        IEnumerable<int> GetListReceipts(string str);
        IEnumerable<int> GetListProducts();
        int GetTotalCost(int receiptID);
        void CreateDetailReceipt(SaveDetailReceiptDto detail);
        void UpdateDetailReceipt(SaveDetailReceiptDto detail);
        void DeleteDetailReceipt(int id);
        void DeleteDetailReceipts(int receiptID);
    }
}