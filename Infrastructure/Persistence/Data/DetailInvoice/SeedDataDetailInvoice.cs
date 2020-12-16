using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class SeedDataDetailInvoice
    {
        public static void Initialize(DetailInvoiceContext context)
        {
            context.Database.EnsureCreated();
            if (context.DetailInvoices.Any()) return;
            context.AddRange(
                new DetailInvoice
                {
                    InvoiceId = 1,
                    ProductId = 1,
                    ProductName = "Pizza",
                    Price = 80000,
                    Quantity = 40,
                    TotalCost = 3200000
                },
                new DetailInvoice
                {
                    InvoiceId = 1,
                    ProductId = 3,
                    ProductName = "Pure Water",
                    Price = 10000,
                    Quantity = 345,
                    TotalCost = 3450000
                },
                new DetailInvoice
                {
                    InvoiceId = 1,
                    ProductId = 2,
                    ProductName = "Milk",
                    Price = 12000,
                    Quantity = 75,
                    TotalCost = 90000
                },
                new DetailInvoice
                {
                    InvoiceId = 2,
                    ProductId = 18,
                    ProductName = "	Spring Rolls",
                    Price = 85000,
                    Quantity = 100,
                    TotalCost = 8500000
                },
                new DetailInvoice
                {
                    InvoiceId = 2,
                    ProductId = 26,
                    ProductName = "Girdle-cake",
                    Price = 10000,
                    Quantity = 59,
                    TotalCost = 590000
                }
            );
            context.SaveChanges();
        }
    }
}