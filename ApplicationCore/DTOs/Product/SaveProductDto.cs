using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs
{
    public class SaveProductDto
    {
        [Display(Name = "Code")]
        public int id { get; set; }

        [StringLength(60, MinimumLength = 3,ErrorMessage="Type can only be between 3 and 60 characters")]
        [Required]
        public String Type { get; set; }

        [StringLength(60, MinimumLength = 3,ErrorMessage="Name can only be between 3 and 60 characters")]
        [Required]
        public String Name { get; set; }

        [RegularExpression("([1-9][0-9]*)",ErrorMessage="Please enter valid price")]
        [Required]
        public int Price { get; set; }

        [RegularExpression("([0-9]+)",ErrorMessage="Please enter valid quantity")]
        [Required]
        public int Quantity { get; set; }


        [Display(Name = "Promotion")]
        public String Note { get; set; }
    }
}