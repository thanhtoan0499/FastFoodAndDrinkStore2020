using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;

namespace ApplicationCore.DTOs
{
    public class InvoiceDto
    {
         [Display (Name="Code")]
        public int id { get; set; }
        public string Staff { get; set; }
        public string Supplier { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Import Date")]
        public DateTime ImportDate { get; set; }
      
        [Display(Name = "Total Cost")]
        public int Cost { get; set; }
    }
}