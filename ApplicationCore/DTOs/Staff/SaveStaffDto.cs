using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.DTOs
{
    public class SaveStaffDto
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 2,ErrorMessage="Last Name can only be between 3 and 60 characters")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 2,ErrorMessage="First Name can only be between 3 and 60 characters")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [StringLength(6)]
        [Required]
        public string Gender { get; set; }

        [StringLength(60, MinimumLength = 3,ErrorMessage="Address can only be between 3 and 60 characters")]
        [Required]
        public string Address { get; set; }

        [StringLength(60, MinimumLength = 3,ErrorMessage="Position can only be between 3 and 60 characters")]
        [Required]
        public string Position { get; set; }

        
        [Display(Name = "Salary Rate")]
        [Range(0, 100,ErrorMessage="Please enter valid Salary Rate")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalaryRate { get; set; }
    }
}