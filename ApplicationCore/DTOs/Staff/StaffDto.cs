using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;

namespace ApplicationCore.DTOs
{
    public class StaffDto
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public String Position { get; set; }

        [Display(Name = "Salary Rate")]
        public decimal SalaryRate { get; set; }
    }
}