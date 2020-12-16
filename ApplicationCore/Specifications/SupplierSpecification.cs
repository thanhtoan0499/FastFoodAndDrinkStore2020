using System;
using System.Diagnostics;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class SupplierSpecification : Specification<Supplier>
    {
        public SupplierSpecification(string id, string name)
            : base(MakeCriteria(id, name))
        {

        }
        public SupplierSpecification(string id, string name, int pageIndex, int pageSize)
            : this(id, name)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        private static Expression<Func<Supplier, bool>> MakeCriteria(string id, string name)
        {
            Expression<Func<Supplier, bool>> predicate = m => true;
            if(!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name))
            {
                predicate = m => m.id == Int32.Parse(id) && m.Name.Contains(name);
            }
            else if(!string.IsNullOrEmpty(id))
            {
                predicate = m => m.id == Int32.Parse(id);
            }
            else if(!string.IsNullOrEmpty(name))
            {
                predicate = m => m.Name.Contains(name);
            }

            return predicate;
        }
    }
}