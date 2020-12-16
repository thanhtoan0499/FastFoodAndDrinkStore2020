using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;
namespace ApplicationCore.DTOs
{
    public class DetailInvoiceDto
    {
        public int id { get; set; }

        [Display(Name = "Invoice Code")]
        public int InvoiceId { get; set; }

        [Display(Name = "Product Code")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
        
        [Display(Name = "Cost")]
        public int TotalCost { get; set; }
    }
}