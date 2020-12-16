using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Invoice : IAggregateRoot
    {
        public int id { get; set; }
        public string Staff { get; set; }
        public string Supplier { get; set; }
        public DateTime ImportDate { get; set; }
        public int Cost { get; set; }
    }
}