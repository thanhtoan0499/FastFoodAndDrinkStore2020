using System;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Supplier : IAggregateRoot
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}