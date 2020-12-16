using System;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Product : IAggregateRoot
    {
        public int id { get; set; }
        public String Type { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public String Note { get; set; }
    }
}