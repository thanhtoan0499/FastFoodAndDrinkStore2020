using System;
using System.Diagnostics;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class InvoiceSpecification : Specification<Invoice>
    {
        public InvoiceSpecification(string staff, string supplier, int costFrom, int costTo)
            : base(MakeCriteria(staff, supplier, costFrom, costTo))
        {

        }
        public InvoiceSpecification(string staff, string supplier, int costFrom, int costTo, int pageIndex, int pageSize)
            : this(staff, supplier, costFrom, costTo)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        private static Expression<Func<Invoice, bool>> MakeCriteria(string staff, string supplier, int _costFrom, int _costTo)
        {
            Expression<Func<Invoice, bool>> predicate = m => true;
            int costFrom = 0;
            int costTo = Int32.MaxValue;
            if (_costFrom != 0 || _costTo != 0)
            {
                costFrom = _costFrom;
                costTo = _costTo;
            }
            if (!string.IsNullOrEmpty(staff) && !string.IsNullOrEmpty(supplier))
            {
                predicate = m => m.Staff == staff && m.Supplier == supplier && m.Cost >= costFrom && m.Cost <= costTo;
            }
            else if (!string.IsNullOrEmpty(staff))
            {
                predicate = m => m.Staff == staff && m.Cost >= costFrom && m.Cost <= costTo;
            }
            else if (!string.IsNullOrEmpty(supplier))
            {
                predicate = m => m.Supplier == supplier && m.Cost >= costFrom && m.Cost <= costTo;
            }
            return predicate;
        }
    }
}