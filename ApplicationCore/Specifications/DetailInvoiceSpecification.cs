using System;
using System.Diagnostics;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class DetailInvoiceSpecification : Specification<DetailInvoice>
    {
        public DetailInvoiceSpecification(int invoiceId, string productName, int quantityFrom, int quantityTo, int totalCostFrom, int totalCostTo)
            : base(MakeCriteria(invoiceId, productName, quantityFrom, quantityTo, totalCostFrom, totalCostTo))
        {

        }
        public DetailInvoiceSpecification(int invoiceId, string productName, int quantityFrom, int quantityTo, int totalCostFrom, int totalCostTo, int pageIndex, int pageSize)
            : this(invoiceId, productName, quantityFrom, quantityTo, totalCostFrom, totalCostTo)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        private static Expression<Func<DetailInvoice, bool>> MakeCriteria(int invoiceId, string productName, int quantityFrom, int quantityTo, int totalCostFrom, int totalCostTo)
        {
            Expression<Func<DetailInvoice, bool>> predicate = m => true;
            int quanFrom = 0;
            int quanTo = 999999;
            if (quantityFrom != 0 || quantityTo != 0)
            {
                quanFrom = quantityFrom;
                quanTo = quantityTo;
            }
            int costFrom = 0;
            int costTo = 999999999;
            if (totalCostFrom != 0 || totalCostTo != 0)
            {
                costFrom = totalCostFrom;
                costTo = totalCostTo;
            }
            if (invoiceId == 0)
            {
                if (!string.IsNullOrEmpty(productName))
                {
                    predicate = m => m.ProductName == productName && m.Quantity >= quanFrom && m.Quantity <= quanTo && m.TotalCost >= costFrom && m.TotalCost <= costTo;
                }
                else
                {
                    predicate = m => m.Quantity >= quanFrom && m.Quantity <= quanTo && m.TotalCost >= costFrom && m.TotalCost <= costTo;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(productName))
                {
                    predicate = m => m.InvoiceId == invoiceId && m.ProductName == productName && m.Quantity >= quanFrom && m.Quantity <= quanTo && m.TotalCost >= costFrom && m.TotalCost <= costTo;
                }
                else
                {
                    predicate = m => m.InvoiceId == invoiceId && m.Quantity >= quanFrom && m.Quantity <= quanTo && m.TotalCost >= costFrom && m.TotalCost <= costTo;
                }
            }

            return predicate;
        }
    }
}