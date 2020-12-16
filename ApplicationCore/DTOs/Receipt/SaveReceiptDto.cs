using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs
{
    public class SaveReceiptDto
    {
        [Display(Name="Receipt Code")]
        public int id { get; set; }
        [Display(Name = "Staff ID")]
        [Required]
        public int StaffID { get; set; }
        [Display(Name = "Customer ID")]

        [Required]
        public int CustomerID { get; set; }

        [Display(Name = "Export Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ExportDate { get; set; }

        [Display(Name = "Total Cost")]
        [Required]
        public int TotalCost { get; set; }
    }
}