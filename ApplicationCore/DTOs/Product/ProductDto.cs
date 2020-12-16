using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.DTOs
{
    public class ProductDto
    {
        [Display(Name = "Code")]
        public int id { get; set; }

        public String Type { get; set; }

        public String Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
        
        [Display(Name = "Promotion")]
        public String Note { get; set; }
    }
}