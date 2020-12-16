using System;
using System.Diagnostics;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class PromotionSpecification : Specification<Promotion>
    {
        public PromotionSpecification(string name, int discountFrom, int discountTo, DateTime start, DateTime end)
            : base(MakeCriteria(name, discountFrom, discountTo, start, end))
        {

        }
        public PromotionSpecification(string name, int discountFrom, int discountTo, DateTime start, DateTime end, int pageIndex, int pageSize)
            : this(name, discountFrom, discountTo, start, end)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        private static Expression<Func<Promotion, bool>> MakeCriteria(string name, int discountFrom, int discountTo, DateTime start, DateTime end)
        {
            Expression<Func<Promotion, bool>> predicate = m => true;
            if (!string.IsNullOrEmpty(name))
            {
                if (discountFrom != 0 || discountTo != 0)
                {
                    if (start != DateTime.Parse("01/01/0001") || end != DateTime.Parse("01/01/0001"))
                    {
                        predicate = m => m.Name.Contains(name) && m.Discount >= discountFrom && m.Discount <= discountTo && m.Start >= start && m.End <= end;
                    }
                    else
                    {
                        predicate = m => m.Name.Contains(name) && m.Discount >= discountFrom && m.Discount <= discountTo;
                    }
                }
                else
                {
                    if (start != DateTime.Parse("01/01/0001") || end != DateTime.Parse("01/01/0001"))
                    {
                        predicate = m => m.Name.Contains(name) && m.Start >= start && m.End <= end;
                    }
                    else
                    {
                        predicate = m => m.Name.Contains(name);
                    }
                }
            }
            else
            {
                if (discountFrom != 0 || discountTo != 0)
                {
                    if (start != DateTime.Parse("01/01/0001") || end != DateTime.Parse("01/01/0001"))
                    {
                        predicate = m => m.Discount >= discountFrom && m.Discount <= discountTo && m.Start >= start && m.End <= end;
                    }
                    else
                    {
                        predicate = m => m.Discount >= discountFrom && m.Discount <= discountTo;
                    }
                }
                else
                {
                    if (start != DateTime.Parse("01/01/0001") || end != DateTime.Parse("01/01/0001"))
                    {
                        predicate = m => m.Start >= start && m.End <= end;
                    }
                }
            }
            return predicate;
        }
    }
}