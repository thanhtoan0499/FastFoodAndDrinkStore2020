using System;
using ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationCore.DTOs
{
    public class SupplierDto
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}