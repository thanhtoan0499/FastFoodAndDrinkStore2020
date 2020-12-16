using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Store
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(IEnumerable<T> items, int pageIndex, int pageSize, int count)
        {
            PageTotal = (int)Math.Ceiling(count / (double)pageSize);
            PageIndex = pageIndex;
            this.AddRange(items);
        }

        public int PageTotal { get; }
        public int PageIndex { get; }
        public bool HasPrevious
        {
            get { return PageIndex > 1; }
        }
        public bool HasNext
        {
            get { return PageIndex < PageTotal; }
        }

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int count = source.Count();

            var items = source.Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize).ToList();

            return new PaginatedList<T>(items, pageIndex, pageSize, count);
        }
    }
}