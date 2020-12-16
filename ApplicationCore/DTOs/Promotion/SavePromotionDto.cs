using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.DTOs
{
    public class SavePromotionDto
    {
        public int id { get; set; }
        
        [Display(Name = "Code")]
        [StringLength(60, MinimumLength = 3,ErrorMessage="Name can only be between 3 and 60 characters")]
        [Required]
        public string Name { get; set; }
        
        [Range(0, 100,ErrorMessage="Discount can be only between 0 and 100")]
        public int Discount { get; set; }

        [Display(Name = "Start Day")]
        [DataType(DataType.Date)]
       
        public DateTime Start { get; set; }

        [Display(Name = "End Day")]
        [DataType(DataType.Date)]
       
        public DateTime End { get; set; }
    }
}