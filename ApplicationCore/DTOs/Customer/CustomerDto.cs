using System;
using ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationCore.DTOs
{
    public class CustomerDto
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        public String Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}