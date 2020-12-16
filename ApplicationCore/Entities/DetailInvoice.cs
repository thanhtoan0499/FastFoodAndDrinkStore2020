using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class DetailInvoice : IAggregateRoot
    {   
        public int id { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int TotalCost { get; set; }
    }
}