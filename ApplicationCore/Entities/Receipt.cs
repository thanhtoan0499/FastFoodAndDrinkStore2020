using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Receipt : IAggregateRoot
    {
        public int id { get; set; }
        public int StaffID { get; set; }
        public int CustomerID { get; set; }
        public DateTime ExportDate { get; set; }
        public int TotalCost { get; set; }
    }
}