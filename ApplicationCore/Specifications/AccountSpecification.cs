using System;
using System.Diagnostics;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class AccountSpecification : Specification<Account>
    {
        public AccountSpecification()
            : base(MakeCriteria())
        {

        }
        public AccountSpecification(int pageIndex, int pageSize)
            : this()
        {
            ApplyPaging(pageIndex, pageSize);
        }
        private static Expression<Func<Account, bool>> MakeCriteria()
        {
            Expression<Func<Account, bool>> predicate = m => true;
            
            return predicate;
        }
    }
}