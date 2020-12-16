using System;
using System.Diagnostics;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class ProductSpecification : Specification<Product>
    {
        public ProductSpecification(string searchCode, string searchName, string searchType, int searchPriceFrom, int searchPriceTo, int searchQuantityFrom, int searchQuantityTo)
            : base(MakeCriteria(searchCode, searchName, searchType, searchPriceFrom, searchPriceTo, searchQuantityFrom, searchQuantityTo))
        {

        }
        // public ProductSpecification(string name) : base(MakeCriteria(name))
        // {

        // }
        public ProductSpecification(string searchCode, string searchName, string searchType, int searchPriceFrom, int searchPriceTo, int searchQuantityFrom, int searchQuantityTo, int pageIndex, int pageSize)
            : this(searchCode, searchName, searchType, searchPriceFrom, searchPriceTo, searchQuantityFrom, searchQuantityTo)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        private static Expression<Func<Product, bool>> MakeCriteria(string _searchCode, string searchName, string searchType, int _searchPriceFrom, int _searchPriceTo, int _searchQuantityFrom, int _searchQuantityTo)
        {
            Expression<Func<Product, bool>> predicate = m => true;

            int searchPriceFrom = 0;
            int searchPriceTo = Int32.MaxValue;
            int searchQuantityFrom = 0;
            int searchQuantityTo = Int32.MaxValue;
            int searchCode = -1;
           
            
            if (_searchPriceFrom != 0 || _searchPriceTo != 0)
            {
                searchPriceFrom = _searchPriceFrom;
                searchPriceTo = _searchPriceTo;
            }
            if (_searchQuantityFrom != 0 || _searchQuantityTo != 0)
            {
                searchQuantityFrom = _searchQuantityFrom;
                searchQuantityTo = _searchQuantityTo;
            }
            if(string.IsNullOrEmpty(_searchCode))
            {
                if (!string.IsNullOrEmpty(searchName) && !string.IsNullOrEmpty(searchType))
                {
                    predicate = m => m.Type == searchType && m.Name.Contains(searchName) && m.Price >= searchPriceFrom && m.Price <= searchPriceTo && m.Quantity >= searchQuantityFrom && m.Quantity <= searchQuantityTo;
                }
                else if (!string.IsNullOrEmpty(searchName))
                {
                    predicate = m => m.Name.Contains(searchName) && m.Price >= searchPriceFrom && m.Price <= searchPriceTo && m.Quantity >= searchQuantityFrom && m.Quantity <= searchQuantityTo;
                }
                else if (!string.IsNullOrEmpty(searchType))
                {
                    predicate = m => m.Type == searchType && m.Price >= searchPriceFrom && m.Price <= searchPriceTo && m.Quantity >= searchQuantityFrom && m.Quantity <= searchQuantityTo;
                }
                else
                {
                    predicate = m => m.Price >= searchPriceFrom && m.Price <= searchPriceTo && m.Quantity >= searchQuantityFrom && m.Quantity <= searchQuantityTo;
                }
            }
            else if(!string.IsNullOrEmpty(_searchCode))
            {
                searchCode = Int32.Parse(_searchCode);
                if (!string.IsNullOrEmpty(searchName) && !string.IsNullOrEmpty(searchType))
                {
                    predicate = m => m.id == searchCode && m.Type == searchType && m.Name.Contains(searchName) && m.Price >= searchPriceFrom && m.Price <= searchPriceTo && m.Quantity >= searchQuantityFrom && m.Quantity <= searchQuantityTo;
                }
                else if (!string.IsNullOrEmpty(searchName))
                {
                    predicate = m => m.id == searchCode && m.Name.Contains(searchName) && m.Price >= searchPriceFrom && m.Price <= searchPriceTo && m.Quantity >= searchQuantityFrom && m.Quantity <= searchQuantityTo;
                }
                else if (!string.IsNullOrEmpty(searchType))
                {
                    predicate = m => m.id == searchCode && m.Type == searchType && m.Price >= searchPriceFrom && m.Price <= searchPriceTo && m.Quantity >= searchQuantityFrom && m.Quantity <= searchQuantityTo;
                }
                else
                {
                    predicate = m => m.id == searchCode && m.Price >= searchPriceFrom && m.Price <= searchPriceTo && m.Quantity >= searchQuantityFrom && m.Quantity <= searchQuantityTo;
                }
            }
            
            
            return predicate;
        }

        // private static Expression<Func<Product, bool>> MakeCriteria(string name)
        // {
        //     Expression<Func<Product, bool>> predicate = m => true;
        //     predicate = m => m.Name == name;
        //     return predicate;
        // }
    }
}