using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;

namespace ApplicationCore.DTOs
{
    public class DetailReceiptDto : IAggregateRoot
    {
        public int id { get; set; }

        [Display(Name="Receipt Code")]
        [Required]
        public int ReceiptID { get; set; }

        [Display(Name="Product Code")]
        [Required]
        public int ProductID{get;set;}
        [Required]
        public int Quantity{get;set;}
        [Required]
        public int Cost{get;set;}
    }
}