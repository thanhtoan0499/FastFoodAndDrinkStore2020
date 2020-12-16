using System;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Staff : IAggregateRoot
    {
        public int id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public String Position { get; set; }
        public decimal SalaryRate { get; set; }
    }
}