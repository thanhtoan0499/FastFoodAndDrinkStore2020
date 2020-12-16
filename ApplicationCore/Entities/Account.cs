using System;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Account : IAggregateRoot
    {
        public int id{get;set;}
        public string username{get;set;}
        public string password{get;set;}
        public int permission{get;set;}
    }
}