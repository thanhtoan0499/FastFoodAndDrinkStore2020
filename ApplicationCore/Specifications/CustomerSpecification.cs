using System;
using System.Diagnostics;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class CustomerSpecification : Specification<Customer>
    {
        public CustomerSpecification(string code, string name, string gender, string phone)
            : base(MakeCriteria(code, name, gender, phone))
        {

        }
        public CustomerSpecification(string code, string name, string gender, string phone, int pageIndex, int pageSize)
            : this(code, name, gender, phone)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        private static Expression<Func<Customer, bool>> MakeCriteria(string code, string name, string gender, string phone)
        {
            Expression<Func<Customer, bool>> predicate = m => true;
            if(string.IsNullOrEmpty(code))
            {
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.Name.Contains(name) && m.Gender == gender && m.Phone.Contains(phone);
                }
                else if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.Gender == gender && m.Phone.Contains(phone);
                }
                else if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.Name.Contains(name) && m.Phone.Contains(phone);
                }
                else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.Name.Contains(name) && m.Gender == gender;
                }
                //2 thang null
                else if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.Phone.Contains(phone);
                }
                else if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.Gender == gender;
                }
                else if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.Name.Contains(name);
                }
            }
            else if(!string.IsNullOrEmpty(code))
            {
                int _code = Int32.Parse(code);
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.id == _code && m.Name.Contains(name) && m.Gender == gender && m.Phone.Contains(phone);
                }
                else if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.id == _code && m.Gender == gender && m.Phone.Contains(phone);
                }
                else if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.id == _code && m.Name.Contains(name) && m.Phone.Contains(phone);
                }
                else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.id == _code && m.Name.Contains(name) && m.Gender == gender;
                }
                //2 thang null
                else if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.id == _code && m.Phone.Contains(phone);
                }
                else if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.id == _code && m.Gender == gender;
                }
                else if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.id == _code && m.Name.Contains(name);
                }
                else if(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(phone))
                {
                    predicate = m => m.id == _code;
                }
            }
            
            return predicate;
        }
    }
}