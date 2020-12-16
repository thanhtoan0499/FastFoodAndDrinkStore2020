using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs
{
    public class ReceiptDto
    {
        [Display(Name="Receipt Code")]
       public int id { get; set; }
        [Display(Name = "Staff ID")]
        public int StaffID { get; set; }
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Display(Name = "Export Date")]
        [DataType(DataType.Date)]
        public DateTime ExportDate { get; set; }
        [Display(Name = "Total Cost")]
        public int TotalCost { get; set; }
    }
}