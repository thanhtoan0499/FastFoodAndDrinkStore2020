using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;
namespace ApplicationCore.DTOs
{
    public class SaveDetailInvoiceDto
    {
        public int id { get; set; }

        [Display(Name = "Invoice Code")]
        [Required]
        public int InvoiceId { get; set; }

        [Display(Name = "Product Code")]
        [Required]
        public int ProductId { get; set; }

        [StringLength(60, MinimumLength = 1,ErrorMessage="Product name can only be between 3 and 60 characters")]
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Display(Name = "Cost")]
        [Required]
        public int TotalCost { get; set; }
    }
}