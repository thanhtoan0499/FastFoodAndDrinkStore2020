using System;
using System.Diagnostics;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class ReceiptSpecification : Specification<Receipt>
    {
        public ReceiptSpecification(int id, int staff, int customer, DateTime dateFrom, DateTime dateTo, int costFrom, int costTo)
            : base(MakeCriteria(id, staff, customer, dateFrom, dateTo, costFrom, costTo))
        {

        }
        public ReceiptSpecification(int id, int staff, int customer, DateTime dateFrom, DateTime dateTo, int costFrom, int costTo, int pageIndex, int pageSize)
            : this(id, staff, customer, dateFrom, dateTo, costFrom, costTo)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        private static Expression<Func<Receipt, bool>> MakeCriteria(int id, int staff, int customer, DateTime _dateFrom, DateTime _dateTo, int _costFrom, int _costTo)
        {
            Expression<Func<Receipt, bool>> predicate = m => true;
            int costFrom = 0;
            int costTo = Int32.MaxValue;
            if (_costFrom != 0 || _costTo != 0)
            {
                costFrom = _costFrom;
                costTo = _costTo;
            }
            var dateFrom = DateTime.Parse("01/01/0001");
            var dateTo = DateTime.Parse("01/01/9999");
            if (_dateFrom != DateTime.Parse("01/01/0001") || _dateTo != DateTime.Parse("01/01/0001"))
            {
                dateFrom = _dateFrom;
                dateTo = _dateTo;
            }
            if(id != 0 && staff != 0 && customer != 0)
            {
                predicate = m => m.id == id && m.StaffID == staff && m.CustomerID == customer && m.TotalCost >= costFrom && m.TotalCost <= costTo && m.ExportDate >= dateFrom && m.ExportDate <= dateTo;
            }
            else if(id == 0 && staff != 0 && customer != 0)
            {
                predicate = m => m.StaffID == staff && m.CustomerID == customer && m.TotalCost >= costFrom && m.TotalCost <= costTo && m.ExportDate >= dateFrom && m.ExportDate <= dateTo;   
            }
            else if(id != 0 && staff == 0 && customer != 0)
            {
                predicate = m => m.id == id && m.CustomerID == customer && m.TotalCost >= costFrom && m.TotalCost <= costTo && m.ExportDate >= dateFrom && m.ExportDate <= dateTo; 
            }
            else if( id != 0 && staff != 0 && customer == 0)
            {
                predicate = m => m.id == id && m.StaffID == staff && m.TotalCost >= costFrom && m.TotalCost <= costTo && m.ExportDate >= dateFrom && m.ExportDate <= dateTo;
            }
            else if(id != 0 && staff == 0 && customer == 0)
            {
                predicate = m => m.id == id && m.TotalCost >= costFrom && m.TotalCost <= costTo && m.ExportDate >= dateFrom && m.ExportDate <= dateTo;
            }
            else if(id == 0 && staff != 0 && customer == 0)
            {
                predicate = m => m.StaffID == staff && m.TotalCost >= costFrom && m.TotalCost <= costTo && m.ExportDate >= dateFrom && m.ExportDate <= dateTo;
            }
            else if(id == 0 && staff == 0 && customer != 0)
            {
                predicate = m => m.CustomerID == customer && m.TotalCost >= costFrom && m.TotalCost <= costTo && m.ExportDate >= dateFrom && m.ExportDate <= dateTo;
            }
            else if(id == 0 && staff == 0 && customer == 0)
            {
                predicate = m => m.TotalCost >= costFrom && m.TotalCost <= costTo && m.ExportDate >= dateFrom && m.ExportDate <= dateTo;
            }
            return predicate;
        }
    }
}