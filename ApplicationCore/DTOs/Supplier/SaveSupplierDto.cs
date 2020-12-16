using System;
using ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationCore.DTOs
{
    public class SaveSupplierDto
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [StringLength(60, MinimumLength = 3,ErrorMessage="Name can only be between 3 and 60 characters")]
        [Required]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3,ErrorMessage="Address can only be between 3 and 60 characters")]
        [Required]
        public string Address { get; set; }
    }
}