using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class DetailReceipt : IAggregateRoot
    {
        public int id { get; set; }
        public int ReceiptID { get; set; }
        public int ProductID{get;set;}
        public int Quantity{get;set;}
        public int Cost{get;set;}
    }
}