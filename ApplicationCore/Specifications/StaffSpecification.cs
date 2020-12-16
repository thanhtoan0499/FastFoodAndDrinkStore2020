using System;
using System.Diagnostics;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class StaffSpecification : Specification<Staff>
    {
        public StaffSpecification(string code ,string lastName, string firstName, string gender, string position)
            : base(MakeCriteria(code,lastName, firstName, gender, position))
        {

        }
        public StaffSpecification(string code,string lastName, string firstName, string gender, string position, int pageIndex, int pageSize)
            : this(code, lastName, firstName, gender, position)
        {
            ApplyPaging(pageIndex, pageSize);
        }
        private static Expression<Func<Staff, bool>> MakeCriteria(string code, string lastName, string firstName, string gender, string position)
        {
            Expression<Func<Staff, bool>> predicate = m => true;
            if(string.IsNullOrEmpty(code))
            {
                if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.LastName.Contains(lastName) && m.FirstName.Contains(firstName) && m.Gender == gender && m.Position == position;
                }
                else if (string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.FirstName.Contains(firstName) && m.Gender == gender && m.Position == position;
                }
                else if (!string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.LastName.Contains(lastName) && m.Gender == gender && m.Position == position;
                }
                else if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.LastName.Contains(lastName) && m.FirstName.Contains(firstName) && m.Position == position;
                }
                else if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.LastName.Contains(lastName) && m.FirstName.Contains(firstName) && m.Gender == gender;
                }
                //2 cai null
                else if (string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.Gender == gender && m.Position == position;
                }
                else if (string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.FirstName.Contains(firstName) && m.Position == position;
                }
                else if (string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.FirstName.Contains(firstName) && m.Gender == gender;
                }
                else if (!string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.LastName.Contains(lastName) && m.Position == position;
                }
                else if (!string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.LastName.Contains(lastName) && m.Gender == gender;
                }
                else if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.LastName.Contains(lastName) && m.FirstName.Contains(firstName);
                }
                //3cai null
                else if (string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.Position == position;
                }
                else if (string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.Gender == gender;
                }
                else if (string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.FirstName.Contains(firstName);
                }
                else if (!string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.LastName.Contains(lastName);
                }
            }
            else if(!string.IsNullOrEmpty(code))
            {
                int _code = Int32.Parse(code);
                if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.LastName.Contains(lastName) && m.FirstName.Contains(firstName) && m.Gender == gender && m.Position == position;
                }
                else if (string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.FirstName.Contains(firstName) && m.Gender == gender && m.Position == position;
                }
                else if (!string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.LastName.Contains(lastName) && m.Gender == gender && m.Position == position;
                }
                else if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.LastName.Contains(lastName) && m.FirstName.Contains(firstName) && m.Position == position;
                }
                else if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.LastName.Contains(lastName) && m.FirstName.Contains(firstName) && m.Gender == gender;
                }
                //2 cai null
                else if (string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.Gender == gender && m.Position == position;
                }
                else if (string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.FirstName.Contains(firstName) && m.Position == position;
                }
                else if (string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.FirstName.Contains(firstName) && m.Gender == gender;
                }
                else if (!string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.LastName.Contains(lastName) && m.Position == position;
                }
                else if (!string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.LastName.Contains(lastName) && m.Gender == gender;
                }
                else if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.LastName.Contains(lastName) && m.FirstName.Contains(firstName);
                }
                //3cai null
                else if (string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.Position == position;
                }
                else if (string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.Gender == gender;
                }
                else if (string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.FirstName.Contains(firstName);
                }
                else if (!string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code && m.LastName.Contains(lastName);
                }
                else if(string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(position))
                {
                    predicate = m => m.id == _code;
                }
            }
            return predicate;
        }
    }
}