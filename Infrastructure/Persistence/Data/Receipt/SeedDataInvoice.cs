using System;
using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class SeedDataReceipt
    {
        public static void Initialize(ReceiptContext context)
        {
            context.Database.EnsureCreated();
            if (context.Receipts.Any()) return;
            context.AddRange(
                new Receipt
                {
                    StaffID=1,
                    CustomerID=3,
                    ExportDate = DateTime.Parse("01/01/0001"),
                    TotalCost = 0
                },
                new Receipt
                {
                    StaffID=3,
                    CustomerID=5,
                    ExportDate = DateTime.Parse("01/01/0001"),
                    TotalCost = 0
                },
                new Receipt
                {
                    StaffID=3,
                    CustomerID=3,
                    ExportDate = DateTime.Parse("01/01/0001"),
                    TotalCost = 0
                },
                new Receipt
                {
                    StaffID=4,
                    CustomerID=2,
                    ExportDate = DateTime.Parse("01/01/0001"),
                    TotalCost = 0
                },
                new Receipt
                {
                    StaffID=4,
                    CustomerID=6,
                    ExportDate = DateTime.Parse("01/01/0001"),
                    TotalCost = 0
                }
            );
            context.SaveChanges();
        }
    }
}