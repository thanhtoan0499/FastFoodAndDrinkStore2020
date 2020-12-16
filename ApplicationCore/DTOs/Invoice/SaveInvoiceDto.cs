using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;

namespace ApplicationCore.DTOs
{
    public class SaveInvoiceDto
    {
        [Display (Name="Code")]
        public int id { get; set; }

        [StringLength(60, MinimumLength = 1,ErrorMessage="Staff name can only be between 3 and 60 characters")]
        [Required]
        public string Staff { get; set; }

        [StringLength(60, MinimumLength = 1,ErrorMessage="Supplier name can only be between 3 and 60 characters")]
        [Required]
        public string Supplier { get; set; }

        [DataType(DataType.Date)]
        public DateTime ImportDate { get; set; }

        [Display(Name = "Total Cost")]
        [Required]
        public int Cost { get; set; }
    }
}