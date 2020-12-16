using System;
using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class SeedDataInvoice
    {
        public static void Initialize(InvoiceContext context)
        {
            context.Database.EnsureCreated();
            if (context.Invoices.Any()) return;
            context.AddRange(
                new Invoice
                {
                    Staff = "Ngo Thi Huyen",
                    Supplier = "Lady Dutch",
                    ImportDate = DateTime.Parse("01/01/0001"),
                    Cost = 0
                },
                new Invoice
                {
                    Staff = "Luong Trieu Man",
                    Supplier = "Highlands",
                    ImportDate = DateTime.Parse("01/01/0001"),
                    Cost = 0
                },
                new Invoice
                {
                    Staff = "Le Duong Lam",
                    Supplier = "Highlands",
                    ImportDate = DateTime.Parse("01/01/0001"),
                    Cost = 0
                },
                new Invoice
                {
                    Staff = "Nguyen Van	Long",
                    Supplier = "Aquafina",
                    ImportDate = DateTime.Parse("01/01/0001"),
                    Cost = 0
                },
                new Invoice
                {
                    Staff = "Luong Trieu Man",
                    Supplier = "Isotonic Company",
                    ImportDate = DateTime.Parse("01/01/0001"),
                    Cost = 0
                },
                new Invoice
                {
                    Staff = "Luong Trieu Man",
                    Supplier = "Domino's Pizza",
                    ImportDate = DateTime.Parse("01/01/0001"),
                    Cost = 0
                }
            );
            context.SaveChanges();
        }
    }
}