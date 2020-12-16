using System;
using System.Diagnostics;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class DetailReceiptSpecification : Specification<DetailReceipt>
    {
        public DetailReceiptSpecification(int ReceiptId, int productID, int quantityFrom, int quantityTo, int totalCostFrom, int totalCostTo)
            : base(MakeCriteria(ReceiptId, productID, quantityFrom, quantityTo, totalCostFrom, totalCostTo))
        {

        }
        public DetailReceiptSpecification(int ReceiptId, int productID, int quantityFrom, int quantityTo, int totalCostFrom, int totalCostTo, int pageIndex, int pageSize)
            : this(ReceiptId, productID, quantityFrom, quantityTo, totalCostFrom, totalCostTo)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        private static Expression<Func<DetailReceipt, bool>> MakeCriteria(int ReceiptId, int productID, int quantityFrom, int quantityTo, int totalCostFrom, int totalCostTo)
        {
            Expression<Func<DetailReceipt, bool>> predicate = m => true;
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
            if (ReceiptId == 0)
            {
                if (productID != 0)
                {
                    predicate = m => m.ProductID == productID && m.Quantity >= quanFrom && m.Quantity <= quanTo && m.Cost >= costFrom && m.Cost <= costTo;
                }
                else
                {
                    predicate = m => m.Quantity >= quanFrom && m.Quantity <= quanTo && m.Cost >= costFrom && m.Cost <= costTo;
                }
            }
            else
            {
                if (productID != 0)
                {
                    predicate = m => m.ReceiptID == ReceiptId && m.ProductID == productID && m.Quantity >= quanFrom && m.Quantity <= quanTo && m.Cost >= costFrom && m.Cost <= costTo;
                }
                else
                {
                    predicate = m => m.ReceiptID == ReceiptId && m.Quantity >= quanFrom && m.Quantity <= quanTo && m.Cost >= costFrom && m.Cost <= costTo;
                }
            }

            return predicate;
        }
    }
}