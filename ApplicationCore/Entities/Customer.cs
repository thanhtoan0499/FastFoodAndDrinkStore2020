using System;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Customer : IAggregateRoot
    {
        public int id { get; set; }
        public String Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}