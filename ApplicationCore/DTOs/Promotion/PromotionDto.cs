using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;

namespace ApplicationCore.DTOs
{
    public class PromotionDto
    {
        public int id { get; set; }
        [Display(Name = "Code")]
        public string Name { get; set; }
        public int Discount { get; set; }

        [Display(Name = "Start Day")]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        [Display(Name = "End Day")]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }
    }
}