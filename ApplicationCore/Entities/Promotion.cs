using System;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Promotion : IAggregateRoot
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}