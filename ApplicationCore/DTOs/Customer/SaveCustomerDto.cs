using System;
using ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationCore.DTOs
{
    public class SaveCustomerDto
    {
        
        [Display(Name = "ID")]
        public int id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public String Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Address { get; set; }

        [StringLength(60, MinimumLength = 3)]

        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone number")]
        [Required]
        public string Phone { get; set; }
    }
}